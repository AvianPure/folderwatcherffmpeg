using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace folderwatcherffmpeg
{
    public class Settings
    {
        bool loadSucces = true;
        public string ffmpegpath { get; set; }
        public string CurrentSuffix { get; set; }
        public string PrefixTXT { get; set; }
        public bool DubCheck { get; set; }
        public string WatchPath { get; set; }
        public string SelectedFileType { get; set; }
        public bool RBPNG { get; set; }
        public bool RBJPG { get; set; }
        public string BackUpPath { get; set; }
        public string OutputPath { get; set; }
        public int Hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public bool StartOnBoot { get; set; }
        public string[] fileTypes { get; set; }

        public List<Log> logs = new List<Log>();

        public void LoadSettings()
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
                            ffmpegpath = pathValidation(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("suffix:"):
                            CurrentSuffix = CleanPath(line.Substring(line.IndexOf(':') + 1));
                            PrefixTXT = CleanPath(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("dubprotection:"):
                            bool isDubProtectionEnabled = line.Substring(line.IndexOf(':') + 1).Equals("True", StringComparison.OrdinalIgnoreCase);
                            DubCheck = isDubProtectionEnabled;
                            break;
                        case var _ when line.Contains("watch:"):
                            WatchPath = pathValidation(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("default:"):
                            string SelectedFileType = line.Substring(line.IndexOf(':') + 1);
                            switch (SelectedFileType)
                            {
                                case "PNG":
                                    RBPNG = true;
                                    break;
                                case "JPG":
                                    RBJPG = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case var _ when line.Contains("backup:"):
                            BackUpPath = pathValidation(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("output:"):
                            OutputPath = pathValidation(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("hour:"):
                                Hours = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("minute:"):
                            minutes = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("second:"):
                            seconds = Int32.Parse(line.Substring(line.IndexOf(':') + 1));
                            break;
                        case var _ when line.Contains("onboot:"):
                            if (line.Substring(line.IndexOf(':') + 1) == "True")
                            {
                                StartOnBoot = true;
                            }
                            else
                            {
                                StartOnBoot = false;
                            }
                            break;
                        case var _ when line.Contains("filetypes:"):
                            string fileTypesFromTextFile = line.Substring(line.IndexOf(':') + 1);
                            fileTypes = fileTypesFromTextFile.Split(',');
                            break;
                        default:
                            break;
                    }
                }

                GC.Collect();

            }

            logs.Add(new Log { Type = 2, Message = $"Started {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n" });
            if (!runcheck)
                logs.Add(new Log { Type = 0, Message = "No settings found.\n" });
            else if (!loadSucces)
                logs.Add(new Log { Type = 0, Message = "Some settings failed to load.\n" });
            else
                logs.Add(new Log { Type = 1, Message = "Settings Loaded.\n" });

        }


        private string pathValidation(string path)
        {
            try
            {
                string inputPath = path; // Replace with your path
                string fullPath = System.IO.Path.GetFullPath(inputPath);
                if (!Directory.Exists(fullPath.Substring(0, fullPath.LastIndexOf('\\') + 1)))
                {
                    throw new DirectoryNotFoundException("Path does not currently excists");
                }
                path = fullPath;
            }
            catch (Exception ex)
            {
                logs.Add(new Log { Type = 0, Message = $"Invalid path {path}: {ex.Message}\n" });

                loadSucces = false;
                path = "";
            }

            return path;
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

    public class Log
    {
        public int Type { get; set; } // Type is either 0 or 1
        public string Message { get; set; }
    }
}
