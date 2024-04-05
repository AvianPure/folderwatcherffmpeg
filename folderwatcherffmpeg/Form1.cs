using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing;
using System.Text.RegularExpressions;


namespace folderwatcherffmpeg
{
    public partial class MainForm : Form
    {
        bool loadSucces = true;
        public MainForm()
        {
            InitializeComponent();
            LoadSettings();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
           
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
            StartBtn.Text = "Stop Watching";

        }

        private void timerStop()
        {

            Timer.Text = "00:00:00";
            timer1.Enabled = false;
            Hours.ReadOnly = false;
            minutes.ReadOnly = false;
            seconds.ReadOnly = false;
            StartBtn.Text = "Start Watching";

        }

        private void fileCheck()
        {
            int result = 0;
            if (ffmpegpath.Text == "..." || WatchPath.Text == "..." || BackUpPath.Text == "..." || OutputPath.Text == "...")
            {
                MessageBox.Show("Please ensure all settings have valid paths before proceeding.");
                logFailed("Please ensure all settings have valid paths before proceeding.\n");
                return;
            }else if (ffmpegpath.Text == "" || WatchPath.Text == "" || BackUpPath.Text == "" || OutputPath.Text == "")
            {
                MessageBox.Show("Please ensure all settings have valid paths before proceeding.");
                logFailed("Please ensure all settings have valid paths before proceeding.\n");
                return;
            }
            Log.AppendText($"New run at: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            string[] files = Directory.GetFiles(WatchPath.Text);
            foreach (var item in SelectedFileTypes.CheckedItems)
            {

                Console.WriteLine("Checking for " + item + " items in path " + WatchPath.Text);

                if (files.Count() > 0)
                {
                    progressBar1.Maximum = files.Count();
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    progressBar1.Minimum = 1;
                }

                foreach (var file in files)
                {
                    CurrentFileLabel.Text = file;
                    if (file.ToLower().Contains("." + item.ToString().ToLower()))
                    {
                        bool dublicateSafe = true;

                        string path = OutputPath.Text;
                        string filename = System.IO.Path.GetFileNameWithoutExtension(file);
                        string extension = SelectedFileType.ToLower();
                        string outputFile = System.IO.Path.Combine(path, $"{filename}{CurrentSuffix.Text}.{extension}");

                        string oldFileExtension = System.IO.Path.GetExtension(file);
                        string backUpPath = BackUpPath.Text;
                        string backupFile = System.IO.Path.Combine(backUpPath, $"{filename}{CurrentSuffix.Text}{oldFileExtension}");


                        if (DubCheck.Checked == true)
                        {
                            string dubprotection = GenerateRandomString(10);
                            if (System.IO.File.Exists(outputFile))
                            {
                               outputFile = System.IO.Path.Combine(path, $"{filename}{CurrentSuffix.Text}{dubprotection}.{extension}");
                            }
                            if (System.IO.File.Exists(backupFile))
                            {
                                backupFile = System.IO.Path.Combine(backUpPath, $"{filename}{CurrentSuffix.Text}{dubprotection}{oldFileExtension}");
                            }
                        }

                        if (System.IO.File.Exists(outputFile))
                        {
                            logFailed($"Couldn't convert: {file} Already exists\n");
                            dublicateSafe = false;
                        }
                        else
                        {

                            if (ffmpegpath.Text.Contains("ffmpeg.exe") && ffmpegpath.Text.Substring(ffmpegpath.Text.LastIndexOf('\\') + 1) == "ffmpeg.exe")
                            {
                                Execute(ffmpegpath.Text, $"-y -i \"{file}\" -preset ultrafast \"{outputFile}\"");

                            }
                            else
                            {
                                logFailed("ffmpeg not found.\n");
                                progressBar1.Value = progressBar1.Maximum;
                                progressBar1.ForeColor = Color.Red;
                                progressBar1.BackColor = Color.Red;
                                dublicateSafe = true;
                                break;
                            }
                                
                        }


                        if (System.IO.File.Exists(backupFile) && !dublicateSafe)
                        {
                            logFailed($"Couldn't move: {backupFile} Already exists\n");
                        }
                        else
                        {
                            System.IO.File.Move(file, backupFile);
                        }

                        if (!dublicateSafe)
                            result++;
                        
                        progressBar1.PerformStep();
                        Log.AppendText($"output: {outputFile}\n");
                        Log.ScrollToCaret();
                    }
                    
                }
                double averageResult = (double)(((double)result / files.Count()) * 100);

                if (averageResult > 5)
                    logFailed($"Failed to move {result}/{files.Count()} : {averageResult}%\n");
                else
                    logSucces($"Moved {result}/{files.Count()} : {averageResult}%\n");

            }
            CurrentFileLabel.Text = "Done";
        }

        private void ManualCheck_Click(object sender, EventArgs e)
        {
            fileCheck();
        }

        string SelectedFileType = "JPG";
        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(rb == null)
            {
                MessageBox.Show("Error 1");
                return;
            }

            if(rb.Checked)
            {
                SelectedFileType = rb.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool foundmmpeg = false;
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = runPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(dialog.FileName);
                foreach (string file in files)
                {
                    if (file.Contains("ffmpeg.exe") && file.Substring(file.LastIndexOf('\\') + 1) == "ffmpeg.exe")
                    {
                        ffmpegpath.Text = file;
                        foundmmpeg = true;
                    }
                }
                if(foundmmpeg== false)
                {
                    MessageBox.Show("Error ffmpeg not found");
                    logFailed("Error ffmpeg not found.\n");
                }
                
            }
        }

        private void FolderToWatchBtn_Click(object sender, EventArgs e)
        {
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = runPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                WatchPath.Text = dialog.FileName;
            }
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string newFolderPath = System.IO.Path.Combine(runPath, "Settings");

            // Check if the directory exists
            if (!Directory.Exists(newFolderPath))
            {
                // If it doesn't exist, create it
                Directory.CreateDirectory(newFolderPath);
            }

            string newFilePath = System.IO.Path.Combine(newFolderPath, "Settings.txt");

            string content = $"ffmpeg:{ffmpegpath.Text}\nwatch:{WatchPath.Text}\ndefault:{SelectedFileType}\noutput:{OutputPath.Text}\nbackup:{BackUpPath.Text}\noutput:{OutputPath.Text}\nhour:{Hours.Value}\nminute:{minutes.Value}\nseconds:{seconds.Value}\nonboot:{StartOnBoot.Checked}\nsuffix:{CurrentSuffix.Text}\ndubprotection:{DubCheck.Checked}\n";
            string SelectedTypesCollection = $"filetypes:{string.Join(",", SelectedFileTypes.CheckedItems.Cast<string>())}\n";
            System.IO.File.WriteAllText(newFilePath, $"{content}{SelectedTypesCollection}");
            logSucces($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\nSettings saved\n" );
        }
            
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string newFolderPath = System.IO.Path.Combine(runPath, "Settings");
            string newFilePath = System.IO.Path.Combine(newFolderPath, "Settings.txt");
            bool runcheck = true;

            if (!Directory.Exists(newFolderPath))
            {
                runcheck = false;
            }
            if (!System.IO.File.Exists(newFilePath))
            {
                runcheck = false;
            }

            if (runcheck)
            {
                string[] lines = System.IO.File.ReadAllLines(newFilePath);

                // Print each line to the console
                foreach (string line in lines)
                {
                    switch (line)
                    {
                        case var _ when line.Contains("ffmpeg:"):
                            ffmpegpath.Text = pathValidation(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("suffix:"):
                            CurrentSuffix.Text = CleanPath(line.Substring(line.IndexOf(':') + 1));
                            PrefixTXT.Text = CleanPath(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("dubprotection:"):
                            bool isDubProtectionEnabled = line.Substring(line.IndexOf(':') + 1).Equals("True", StringComparison.OrdinalIgnoreCase);
                            DubCheck.Checked = isDubProtectionEnabled;
                            break;
                        case var _ when line.Contains("watch:"):
                            WatchPath.Text = pathValidation(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("default:"):
                            SelectedFileType = line.Substring(line.IndexOf(':') + 1);
                            switch (SelectedFileType)
                            {
                                case "PNG":
                                    RBPNG.Checked = true;
                                    break;
                                case "JPG":
                                    RBJPG.Checked = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case var _ when line.Contains("backup:"):
                            BackUpPath.Text = pathValidation(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("output:"):
                            OutputPath.Text = pathValidation(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("hour:"):
                            Hours.Value = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("minute:"):
                            minutes.Value = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("second:"):
                            seconds.Value = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("onboot:"):
                            if (line.Substring(line.IndexOf(':') + 1) == "True")
                            {
                                StartOnBoot.Checked = true;
                                timerStart();
                            }
                            else
                            {
                                StartOnBoot.Checked = false;
                            }
                            break;
                        case var _ when line.Contains("filetypes:"):
                            string fileTypesFromTextFile = line.Substring(line.IndexOf(':') + 1);
                            string[] fileTypes = fileTypesFromTextFile.Split(',');
                            for (int i = 0; i < SelectedFileTypes.Items.Count; i++)
                            {
                                SelectedFileTypes.SetItemChecked(i, false);
                            }
                            foreach (string fileType in fileTypes)
                            {
                                for (int i = 0; i < SelectedFileTypes.Items.Count; i++)
                                {
                                    if (SelectedFileTypes.Items[i].ToString() == fileType)
                                    {
                                        SelectedFileTypes.SetItemChecked(i, true);
                                        break; // Exit the loop once a match is found
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

            }
            Log.AppendText($"Started {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            if (!runcheck)
                logFailed("No settings found.\n");
            else if(!loadSucces)
                logFailed("Some settings failed to load.\n");
            else
                logSucces("Settings Loaded.\n");
        }

        private void OutputBtn_Click(object sender, EventArgs e)
        {
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = runPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                OutputPath.Text = dialog.FileName;
            }
        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = runPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BackUpPath.Text = dialog.FileName;
            }
        }

        private void WatchPath_Click(object sender, EventArgs e)
        {

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
        private void Defaults_Click(object sender, EventArgs e)
        {
            CurrentSuffix.Text = "";
            PrefixTXT.Text = "";
            timerStop();
            StartOnBoot.Checked = false;
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            bool foundmmpeg = false;
            for (int i = 0; i < SelectedFileTypes.Items.Count; i++)
            {
                SelectedFileTypes.SetItemChecked(i, false);
            }
            string[] files = Directory.GetFiles(runPath);
            foreach (string file in files)
            {
                if (file.Contains("ffmpeg.exe") && file.Substring(file.LastIndexOf('\\') + 1) == "ffmpeg.exe")
                {
                    ffmpegpath.Text = file;
                    foundmmpeg = true;
                }
                Console.WriteLine($"{file}");
            }
            if (foundmmpeg == false)
            {
                MessageBox.Show("Error ffmpeg not found");
                logFailed("Error ffmpeg not found\n");
                ffmpegpath.Text = "";
            }

            string newFolderPath = System.IO.Path.Combine(runPath, "backup");
            if (!Directory.Exists(newFolderPath))
            {
                // If it doesn't exist, create it
                Directory.CreateDirectory(newFolderPath);
            }
            BackUpPath.Text = newFolderPath;

            newFolderPath = System.IO.Path.Combine(runPath, "sampledata");
            if (!Directory.Exists(newFolderPath))
            {
                // If it doesn't exist, create it
                Directory.CreateDirectory(newFolderPath);
            }
            WatchPath.Text = newFolderPath;

            newFolderPath = System.IO.Path.Combine(runPath, "output");
            if (!Directory.Exists(newFolderPath))
            {
                // If it doesn't exist, create it
                Directory.CreateDirectory(newFolderPath);
            }
            OutputPath.Text = newFolderPath;

            logSucces("Succesfully reseted settings to default\n");

        }

        private void RandomPreFix_Click(object sender, EventArgs e)
        {
            PrefixTXT.Text = GenerateRandomString(5);
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

        private void SetSuffixBtn_Click(object sender, EventArgs e)
        {
            CurrentSuffix.Text = CleanPath(PrefixTXT.Text);
        }

        private string pathValidation(string path)
        {
            try
            {
                string inputPath = path; // Replace with your path
                string fullPath = System.IO.Path.GetFullPath(inputPath);
                if (!Directory.Exists(fullPath))
                {
                    throw new DirectoryNotFoundException("Path does not currently excists");
                }
                path = fullPath;
            }
            catch (Exception ex)
            {
                logFailed($"Invalid path {path}: {ex.Message}\n");
                loadSucces = false;
                path = "";
            }

            return path;
        }
        //E:\ffmpeg-2024-02-15-git-a2cfd6062c-essentials_build\bin\ffmpeg.exe -i input.avif -preset ultrafast output.jpg
    }
}

