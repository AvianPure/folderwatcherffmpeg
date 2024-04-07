using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace folderwatcherffmpeg
{
    public partial class SettingsForm : Form
    {
        private Settings appSettings;


        public SettingsForm(Settings settings) // Pass Settings object in constructor
        {
            InitializeComponent();
            this.appSettings = settings; // Initialize appSettings
            appSettings.LoadSettings();
            setup();

        }

        private void setup()
        {
            ffmpegpath.Text = appSettings.ffmpegpath;
            WatchPath.Text = appSettings.WatchPath;
            OutputPath.Text = appSettings.OutputPath;
            BackUpPath.Text = appSettings.BackUpPath;
            CurrentSuffix.Text = appSettings.CurrentSuffix;
            PrefixTXT.Text = appSettings.PrefixTXT;
            DubCheck.Checked = appSettings.DubCheck;
            StartOnBoot.Checked = appSettings.StartOnBoot;
            foreach (string fileType in appSettings.fileTypes)
            {
                for (int i = 0; i < SelectedFileTypes.Items.Count; i++)
                {
                    if (SelectedFileTypes.Items[i].ToString() == fileType)
                    {
                        SelectedFileTypes.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appSettings.LoadSettings();
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
            string SelectedFileType;
            if (appSettings.RBJPG)
            {
                SelectedFileType = "JPG";
            }
            else
            {
                SelectedFileType = "PNG";
            }

            string content = $"ffmpeg:{ffmpegpath.Text}\nwatch:{WatchPath.Text}\ndefault:" +
                $"{SelectedFileType}\noutput:{OutputPath.Text}\nbackup:{BackUpPath.Text}\noutput:" +
                $"{OutputPath.Text}\nhour:{appSettings.Hours}\nminute:{appSettings.minutes}\nseconds:" +
                $"{appSettings.seconds}\nonboot:{StartOnBoot.Checked}\nsuffix:{CurrentSuffix.Text}\ndubprotection:" +
                $"{DubCheck.Checked}\n";

            string selectedTypesCollection = $"filetypes:{string.Join(",", appSettings.fileTypes)}\n";
            System.IO.File.WriteAllText(newFilePath, $"{content}{selectedTypesCollection}");

            //TODO
            //logSucces($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\nSettings saved\n");

            GC.Collect();
            appSettings.LoadSettings();
            setup();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            appSettings.LoadSettings();
            setup();
        }

        private void SetSuffixBtn_Click(object sender, EventArgs e)
        {
            CurrentSuffix.Text = CleanPath(PrefixTXT.Text);
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
    }
}


