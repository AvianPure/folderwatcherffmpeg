using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace folderwatcherffmpeg
{
    public partial class MainForm : Form
    {
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
                timer1.Enabled = false;
                Hours.ReadOnly = false;
                minutes.ReadOnly = false;
                seconds.ReadOnly = false;
                StartBtn.Text = "Start Watching";
            }
            else
            {
                Timer.Text = "Loading";
                time = (int)Hours.Value * 3600 + (int)minutes.Value * 60 + (int)seconds.Value;
                timer1.Enabled = true;
                Hours.ReadOnly = true;
                minutes.ReadOnly = true;
                seconds.ReadOnly = true;
                StartBtn.Text = "Stop Watching";
            }
            
        }

        private void fileCheck()
        {
            if (ffmpegpath.Text == "..." && WatchPath.Text == "..." && BackUpPath.Text == "..." && OutputPath.Text == "...")
            {
                MessageBox.Show("Please ensure all settings have valid paths before proceeding.");
                return;
            }
            Log.AppendText($"New run at: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            string[] files = Directory.GetFiles(WatchPath.Text);
            foreach (var item in SelectedFileTypes.CheckedItems)
            {

                Console.WriteLine("Checking for " + item + " items in path " + WatchPath.Text);
                progressBar1.Maximum = files.Count();
                progressBar1.Value = 1;
                progressBar1.Step = 1;
                progressBar1.Minimum = 1;
                foreach (var file in files)
                {
                    CurrentFileLabel.Text = file;
                    if (file.ToLower().Contains("." + item.ToString().ToLower()))
                    {
                        Console.WriteLine($"{file} {item}");
                        string path = OutputPath.Text;
                        string filename = Path.GetFileNameWithoutExtension(file);
                        string oldFile = Path.GetFileName(file);
                        Execute(ffmpegpath.Text, $"-y -i {file} -preset ultrafast {path}\\{filename}.{SelectedFileType.ToLower()}");
                        File.Move(file, $"{BackUpPath.Text}\\{oldFile}");
                        Log.AppendText($"output: {path}\\{filename}.{SelectedFileType.ToLower()}\n");
                    }
                    progressBar1.PerformStep();
                }

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
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(dialog.FileName);
                foreach (string file in files)
                {
                    if (file.Contains("ffmpeg.exe"))
                    {
                        ffmpegpath.Text = file;
                        foundmmpeg = true;
                    }
                    Console.WriteLine($"{file}");
                }
                if(foundmmpeg== false)
                {
                    MessageBox.Show("Error ffmpeg not found");
                }
                
            }
        }

        private void FolderToWatchBtn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                WatchPath.Text = dialog.FileName;
            }
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string newFolderPath = Path.Combine(runPath, "Settings");

            // Check if the directory exists
            if (!Directory.Exists(newFolderPath))
            {
                // If it doesn't exist, create it
                Directory.CreateDirectory(newFolderPath);
            }

            string newFilePath = Path.Combine(newFolderPath, "Settings.txt");

            // Create a new text file with three lines of content
            string content = $"ffmpeg:{ffmpegpath.Text}\nwatch:{WatchPath.Text}\ndefault:{SelectedFileType}\noutput:{OutputPath.Text}\nbackup:{BackUpPath.Text}\noutput:{OutputPath.Text}\nhour:{Hours.Value}\nminute:{minutes.Value}\nseconds:{seconds.Value}\nonboot:{StartOnBoot.Checked}";
            File.WriteAllText(newFilePath, content);
            Log.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\nSettings saved" );
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            string runPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string newFolderPath = Path.Combine(runPath, "Settings");
            string newFilePath = Path.Combine(newFolderPath, "Settings.txt");
            bool runcheck = true;

            if (!Directory.Exists(newFolderPath))
            {
                runcheck = false;
            }
            if (!File.Exists(newFilePath))
            {
                runcheck = false;
            }

            if (runcheck)
            {
                string[] lines = File.ReadAllLines(newFilePath);

                // Print each line to the console
                foreach (string line in lines)
                {
                    if (line.Contains("ffmpeg:"))
                    {
                        ffmpegpath.Text = line.Substring(line.IndexOf(':') + 1);
                    }
                    if (line.Contains("watch:"))
                    {
                        WatchPath.Text = line.Substring(line.IndexOf(':') + 1);
                    }
                    if (line.Contains("default:"))
                    {
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
                    }
                    if (line.Contains("backup:"))
                    {
                        BackUpPath.Text = line.Substring(line.IndexOf(':') + 1);
                    }
                    if (line.Contains("output:"))
                    {
                        OutputPath.Text = line.Substring(line.IndexOf(':') + 1);
                    }

                    if (line.Contains("hour:"))
                    {
                        Hours.Value = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                    }
                    if (line.Contains("minute:"))
                    {
                        minutes.Value = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                    }
                    if (line.Contains("second:"))
                    {
                        seconds.Value = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                    }
                    if (line.Contains("onboot:"))
                    {
                        if(line.Substring(line.IndexOf(':') + 1) == "True")
                        {
                            StartOnBoot.Checked = true;
                            StartBtn_Click(this, null);
                        }
                        else
                        {
                            StartOnBoot.Checked = false;
                        }
                        
                    }

                }
            }
            Log.AppendText($"Started {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            if (!runcheck)
                Log.AppendText("No settings found.\n");
            else
                Log.AppendText("Settings Loaded.\n");
        }

        private void OutputBtn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                OutputPath.Text = dialog.FileName;
            }
        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                BackUpPath.Text = dialog.FileName;
            }
        }

        private void WatchPath_Click(object sender, EventArgs e)
        {

        }
        //E:\ffmpeg-2024-02-15-git-a2cfd6062c-essentials_build\bin\ffmpeg.exe -i input.avif -preset ultrafast output.jpg
    }
}
