using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
    using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace folderwatcherffmpeg
{
    public partial class MainForm : Form
    {
        public Settings appSettings;
        bool loadSucces = true;
        public MainForm()
        {
            InitializeComponent();
            appSettings = new Settings();
            LoadSettings();


        }

        private static string Execute(string exePath, string parameters)
        {

            string result = String.Empty;

            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = exePath;
                p.StartInfo.Arguments = parameters;
                p.Start();
                p.WaitForExit();

                result = p.StandardOutput.ReadToEnd();
                p.Close();
            }

            return result;


        }

        int time = 3540;//3540;
        private void timerCountDown(object sender, EventArgs e)
        {
            time--;
            int timeSeconds = time % 60;
            int timeMinutes = (time / 60) % 60;
            int timeHours = time / 3600;

            Timer.Text = $"{timeHours:D2}:{timeMinutes:D2}:{timeSeconds:D2}";
            if (time <= 0)
            {
                time = (int)Hours.Value * 3600 + (int)minutes.Value * 60 + (int)seconds.Value;
                fileCheck();
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timerStop();
            }
            else
            {
                timerStart();
            }

        }

        private void timerStart()
        {

            Timer.Text = "Loading";
            time = (int)Hours.Value * 3600 + (int)minutes.Value * 60 + (int)seconds.Value;
            timer1.Enabled = true;
            Hours.ReadOnly = true;
            minutes.ReadOnly = true;
            seconds.ReadOnly = true;
            Hours.Enabled = false;
            minutes.Enabled = false;
            seconds.Enabled = false;
            StartBtn.Text = "Stop Watching";

        }

        private void timerStop()
        {

            Timer.Text = "00:00:00";
            timer1.Enabled = false;
            Hours.ReadOnly = false;
            minutes.ReadOnly = false;
            seconds.ReadOnly = false;
            Hours.Enabled = true;
            minutes.Enabled = true;
            seconds.Enabled = true;
            StartBtn.Text = "Start Watching";

        }

        private void fileCheck()
        {


            int result = 0;
            List<string> errorLog = new List<string>();
            errorLog.Clear();
            int errorcode = 0;

            //failsafe
            if (appSettings.ffmpegpath == "..." || appSettings.WatchPath == "..." || appSettings.BackUpPath == "..." || appSettings.OutputPath == "...")
            {
                MessageBox.Show("Please ensure all settings have valid paths before proceeding.");
                logFailed("Please ensure all settings have valid paths before proceeding.\n");
                return;
            }
            else if (appSettings.ffmpegpath == "" || appSettings.WatchPath == "" || appSettings.BackUpPath  == "" || appSettings.OutputPath == "")
            {
                MessageBox.Show("Please ensure all settings have valid paths before proceeding.");
                logFailed("Please ensure all settings have valid paths before proceeding.\n");
                return;
            }

            Log.AppendText($"New run at: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");

            string[] files = Directory.GetFiles(appSettings.WatchPath);

            // Get the selected file types
            var selectedExtensions = appSettings.fileTypes.Cast<string>().Select(ext => ext.StartsWith(".") ? ext.ToLower() : "." + ext.ToLower()).ToList();

            // Filter the files
            var filteredFiles = files.Where(file => selectedExtensions.Contains(Path.GetExtension(file).ToLower())).ToArray();

            // The rest of the files
            // var otherFiles = files.Except(filteredFiles).ToArray();
            logSucces($"Checking for items in path {System.IO.Path.GetFullPath(appSettings.WatchPath)}. Found {filteredFiles.Count()} files.\n");
            if (filteredFiles.Count() > 0)
            {
                progressBar1.Maximum = filteredFiles.Count();
                progressBar1.Value = 1;
                progressBar1.Step = 1;
                progressBar1.Minimum = 1;
            }



            foreach (var item in filteredFiles)
            {
                errorcode = 0;
                logSucces($"Working on {System.IO.Path.GetFileName(item)}\n");

                CurrentFileLabel.Text = item;
                bool dublicateSafe = true;
                bool readyToMove = true;


                //pathing
                string path = appSettings.OutputPath;
                string filename = System.IO.Path.GetFileNameWithoutExtension(item);
                string extension = SelectedFileType.ToLower();
                string outputFile = System.IO.Path.Combine(path, $"{filename}{appSettings.CurrentSuffix}.{extension}");

                string oldFileExtension = System.IO.Path.GetExtension(item);
                string backUpPath = appSettings.BackUpPath;
                string backupFile = System.IO.Path.Combine(backUpPath, $"{filename}{appSettings.CurrentSuffix}{oldFileExtension}");


                if (appSettings.DubCheck == true)
                {
                    string dubprotection = GenerateRandomString(10);
                    if (System.IO.File.Exists(outputFile))
                    {
                        outputFile = System.IO.Path.Combine(path, $"{filename}{appSettings.CurrentSuffix}{dubprotection}.{extension}");
                    }
                    if (System.IO.File.Exists(backupFile))
                    {
                        backupFile = System.IO.Path.Combine(backUpPath, $"{filename}{appSettings.CurrentSuffix}{dubprotection}{oldFileExtension}");
                    }
                }

                if (System.IO.File.Exists(outputFile))
                {
                    logFailed($"Couldn't convert: {item} Already exists\n");
                    errorcode++;
                    readyToMove = false;
                    dublicateSafe = false;
                }
                else
                {

                    if (appSettings.ffmpegpath.Contains("ffmpeg.exe") && appSettings.ffmpegpath.Substring(appSettings.ffmpegpath.LastIndexOf('\\') + 1) == "ffmpeg.exe")
                    {
                        Execute(appSettings.ffmpegpath, $"-y -i \"{item}\" -preset ultrafast \"{outputFile}\"");

                    }
                    else
                    {
                        logFailed("ffmpeg not found.\n");
                        errorcode += 4;
                        dublicateSafe = false;
                        break;
                    }

                }


                if (System.IO.File.Exists(backupFile) || !dublicateSafe || !readyToMove)
                {
                    logFailed($"Couldn't move: {backupFile} Allready exists\n");
                    errorcode += 2;
                }
                else
                {
                    System.IO.File.Move(item, backupFile);
                }

                if (!dublicateSafe)
                {
                    result++;
                }


                progressBar1.PerformStep();
                Log.AppendText($"output: {outputFile}\n");
                Log.ScrollToCaret();

                if (errorcode < 1)
                {
                    errorLog.Add($"Succesfully acted on {item}");
                }
                else
                {
                    errorLog.Add($"Couldn't act on {item} error {errorcode}");
                }
            }
            double averageResult = (double)(((double)result / files.Count()) * 100);

            CurrentFileLabel.Text = "Done";



            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string newFolderPath = System.IO.Path.Combine(runPath, "Logs");
            string errorLogFileName = $"Log{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.txt";
            // Check if the directory exists
            if (!Directory.Exists(newFolderPath))
            {
                // If it doesn't exist, create it
                Directory.CreateDirectory(newFolderPath);
            }
            string newFilePath = System.IO.Path.Combine(newFolderPath, errorLogFileName);

            string errocodelegend = "Error code legend\r\n1. couldnt convert file allready exists\r\n2. couldnt move file allready exists\r\n3. couldnt move or convert files allready exists\r\n4. FFmpeg missing\r\n5. FFmpeg missing couldnt convert file allready exists\r\n6. FFmpeg missing move file allready exists\r\n7. FFmpeg missing couldnt move or convert files allready exists\r\n\r\n";
            System.IO.File.AppendAllText(newFilePath, $"{errocodelegend}");

            foreach (string line in errorLog)
            {
                System.IO.File.AppendAllText(newFilePath, line + "\n");
            }

            if (averageResult > 5)
                logFailed($"Failed to convert. {files.Count() - result}/{files.Count()} : {averageResult}% failure rate\nOver 5% failure rate check {errorLogFileName}\n");
            else
                logSucces($"converted {files.Count() - result}/{files.Count()} : {averageResult}%\n");

            GC.Collect();

        }

        private void ManualCheck_Click(object sender, EventArgs e)
        {
            fileCheck();
        }

        string SelectedFileType = "JPG";
        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
            {
                MessageBox.Show("Error 1");
                return;
            }

            if (rb.Checked)
            {
                SelectedFileType = rb.Text;
            }
        }

        private void LoadSettings()
        {
            appSettings.LoadSettings();
            Log.AppendText($"Started {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");

            if (appSettings.ffmpegpath != null)
                logFailed("No settings found.\n");
            else if (!loadSucces)
                logFailed("Some settings failed to load.\n");
            else
                logSucces("Settings Loaded.\n");
        }


        private void logFailed(string LogMessage)
        {
            // Assuming you have a RichTextBox named "Log"
            Log.SelectionStart = Log.TextLength; // Set the selection start to the end of the text
            Log.SelectionLength = 0; // Set the selection length to zero (no selection)
            Log.SelectionColor = Color.Red; // Set the color to red
            Log.AppendText(LogMessage);
            Log.SelectionColor = Log.ForeColor; // Reset the color to the default (optional)
            Log.ScrollToCaret();
        }
        private void logSucces(string LogMessage)
        {
            // Assuming you have a RichTextBox named "Log"
            Log.SelectionStart = Log.TextLength; // Set the selection start to the end of the text
            Log.SelectionLength = 0; // Set the selection length to zero (no selection)
            Log.SelectionColor = Color.Blue; // Set the color to red
            Log.AppendText(LogMessage);
            Log.SelectionColor = Log.ForeColor; // Reset the color to the default (optional)
            Log.ScrollToCaret();
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return CleanPath(new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()));
        }

        public static string CleanPath(string inputPath)
        {
            // Remove invalid characters from the input path
            string cleanedPath = string.Concat(inputPath.Split(System.IO.Path.GetInvalidFileNameChars()));

            // Replace any remaining invalid characters with underscores
            cleanedPath = Regex.Replace(cleanedPath, @"[^\w\d\s-]", "_");

            return cleanedPath;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SettingsForm form2 = new SettingsForm(appSettings); // Pass appSettings to SettingsForm
            form2.FormClosed += SettingsCLosed;
            form2.Show();
        }

        private void SettingsCLosed(object sender, FormClosedEventArgs e)
        {
            // Enable the settings button
            //settingsButton.Enabled = true;

            // Load the settings
            LoadSettings();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = appSettings.RBJPG.ToString();
        }

        //E:\ffmpeg-2024-02-15-git-a2cfd6062c-essentials_build\bin\ffmpeg.exe -i input.avif -preset ultrafast output.jpg
    }
}

