namespace folderwatcherffmpeg
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Types = new System.Windows.Forms.Label();
            this.SelectedFileTypes = new System.Windows.Forms.CheckedListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LogLabel = new System.Windows.Forms.Label();
            this.CurrentFileLabel = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer = new System.Windows.Forms.Label();
            this.ManualCheck = new System.Windows.Forms.Button();
            this.RBJPG = new System.Windows.Forms.RadioButton();
            this.RBPNG = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ffmpegpath = new System.Windows.Forms.Label();
            this.FolderToWatchBtn = new System.Windows.Forms.Button();
            this.Watch = new System.Windows.Forms.Label();
            this.WatchPath = new System.Windows.Forms.Label();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.labellog = new System.Windows.Forms.Label();
            this.OutputBtn = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.OutputPath = new System.Windows.Forms.Label();
            this.MoveBtn = new System.Windows.Forms.Button();
            this.BackupLabel = new System.Windows.Forms.Label();
            this.BackUpPath = new System.Windows.Forms.Label();
            this.ConvertLabel = new System.Windows.Forms.Label();
            this.Hours = new System.Windows.Forms.NumericUpDown();
            this.minutes = new System.Windows.Forms.NumericUpDown();
            this.seconds = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StartOnBoot = new System.Windows.Forms.CheckBox();
            this.Defaults = new System.Windows.Forms.Button();
            this.SetSuffixBtn = new System.Windows.Forms.Button();
            this.Currentsuffixlabel = new System.Windows.Forms.Label();
            this.PrefixTXT = new System.Windows.Forms.TextBox();
            this.RandomPreFix = new System.Windows.Forms.Button();
            this.CurrentSuffix = new System.Windows.Forms.Label();
            this.DubCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // Types
            // 
            this.Types.AutoSize = true;
            this.Types.Location = new System.Drawing.Point(15, 194);
            this.Types.Name = "Types";
            this.Types.Size = new System.Drawing.Size(124, 13);
            this.Types.TabIndex = 0;
            this.Types.Text = "File Types To Watch For";
            // 
            // SelectedFileTypes
            // 
            this.SelectedFileTypes.CheckOnClick = true;
            this.SelectedFileTypes.FormattingEnabled = true;
            this.SelectedFileTypes.Items.AddRange(new object[] {
            "Avif",
            "PNG",
            "JPG"});
            this.SelectedFileTypes.Location = new System.Drawing.Point(15, 211);
            this.SelectedFileTypes.Name = "SelectedFileTypes";
            this.SelectedFileTypes.Size = new System.Drawing.Size(120, 34);
            this.SelectedFileTypes.TabIndex = 1;
            this.SelectedFileTypes.ThreeDCheckBoxes = true;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Turquoise;
            this.progressBar1.Location = new System.Drawing.Point(13, 415);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(810, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 399);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(37, 13);
            this.LogLabel.TabIndex = 3;
            this.LogLabel.Text = "Status";
            // 
            // CurrentFileLabel
            // 
            this.CurrentFileLabel.AutoSize = true;
            this.CurrentFileLabel.Location = new System.Drawing.Point(13, 399);
            this.CurrentFileLabel.Name = "CurrentFileLabel";
            this.CurrentFileLabel.Size = new System.Drawing.Size(0, 13);
            this.CurrentFileLabel.TabIndex = 4;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(429, 216);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(87, 23);
            this.StartBtn.TabIndex = 5;
            this.StartBtn.Text = "Start Watching";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timerCountDown);
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Location = new System.Drawing.Point(429, 246);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(49, 13);
            this.Timer.TabIndex = 6;
            this.Timer.Text = "00:00:00";
            // 
            // ManualCheck
            // 
            this.ManualCheck.Location = new System.Drawing.Point(429, 184);
            this.ManualCheck.Name = "ManualCheck";
            this.ManualCheck.Size = new System.Drawing.Size(87, 23);
            this.ManualCheck.TabIndex = 7;
            this.ManualCheck.Text = "Manual Check";
            this.ManualCheck.UseVisualStyleBackColor = true;
            this.ManualCheck.Click += new System.EventHandler(this.ManualCheck_Click);
            // 
            // RBJPG
            // 
            this.RBJPG.AutoSize = true;
            this.RBJPG.Checked = true;
            this.RBJPG.Location = new System.Drawing.Point(148, 216);
            this.RBJPG.Name = "RBJPG";
            this.RBJPG.Size = new System.Drawing.Size(45, 17);
            this.RBJPG.TabIndex = 8;
            this.RBJPG.TabStop = true;
            this.RBJPG.Text = "JPG";
            this.RBJPG.UseVisualStyleBackColor = true;
            this.RBJPG.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // RBPNG
            // 
            this.RBPNG.AutoSize = true;
            this.RBPNG.Location = new System.Drawing.Point(148, 242);
            this.RBPNG.Name = "RBPNG";
            this.RBPNG.Size = new System.Drawing.Size(48, 17);
            this.RBPNG.TabIndex = 9;
            this.RBPNG.TabStop = true;
            this.RBPNG.Text = "PNG";
            this.RBPNG.UseVisualStyleBackColor = true;
            this.RBPNG.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Select ffmpeg folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ffmpeg path: ";
            // 
            // ffmpegpath
            // 
            this.ffmpegpath.AutoSize = true;
            this.ffmpegpath.Location = new System.Drawing.Point(106, 38);
            this.ffmpegpath.Name = "ffmpegpath";
            this.ffmpegpath.Size = new System.Drawing.Size(16, 13);
            this.ffmpegpath.TabIndex = 12;
            this.ffmpegpath.Text = "...";
            // 
            // FolderToWatchBtn
            // 
            this.FolderToWatchBtn.Location = new System.Drawing.Point(13, 54);
            this.FolderToWatchBtn.Name = "FolderToWatchBtn";
            this.FolderToWatchBtn.Size = new System.Drawing.Size(136, 23);
            this.FolderToWatchBtn.TabIndex = 13;
            this.FolderToWatchBtn.Text = "Select Folder To Watch";
            this.FolderToWatchBtn.UseVisualStyleBackColor = true;
            this.FolderToWatchBtn.Click += new System.EventHandler(this.FolderToWatchBtn_Click);
            // 
            // Watch
            // 
            this.Watch.AutoSize = true;
            this.Watch.Location = new System.Drawing.Point(12, 85);
            this.Watch.Name = "Watch";
            this.Watch.Size = new System.Drawing.Size(88, 13);
            this.Watch.TabIndex = 14;
            this.Watch.Text = "Watching Folder:";
            // 
            // WatchPath
            // 
            this.WatchPath.AutoSize = true;
            this.WatchPath.Location = new System.Drawing.Point(106, 85);
            this.WatchPath.Name = "WatchPath";
            this.WatchPath.Size = new System.Drawing.Size(16, 13);
            this.WatchPath.TabIndex = 15;
            this.WatchPath.Text = "...";
            this.WatchPath.Click += new System.EventHandler(this.WatchPath_Click);
            // 
            // SaveBTN
            // 
            this.SaveBTN.Location = new System.Drawing.Point(710, 12);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(107, 23);
            this.SaveBTN.TabIndex = 16;
            this.SaveBTN.Text = "Save Settings";
            this.SaveBTN.UseVisualStyleBackColor = true;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(710, 42);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(107, 23);
            this.LoadBtn.TabIndex = 17;
            this.LoadBtn.Text = "Load Settings";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(12, 270);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.Size = new System.Drawing.Size(811, 113);
            this.Log.TabIndex = 18;
            this.Log.Text = "";
            // 
            // labellog
            // 
            this.labellog.AutoSize = true;
            this.labellog.Location = new System.Drawing.Point(12, 251);
            this.labellog.Name = "labellog";
            this.labellog.Size = new System.Drawing.Size(25, 13);
            this.labellog.TabIndex = 19;
            this.labellog.Text = "Log";
            // 
            // OutputBtn
            // 
            this.OutputBtn.Location = new System.Drawing.Point(13, 101);
            this.OutputBtn.Name = "OutputBtn";
            this.OutputBtn.Size = new System.Drawing.Size(136, 23);
            this.OutputBtn.TabIndex = 20;
            this.OutputBtn.Text = "Select Output Path";
            this.OutputBtn.UseVisualStyleBackColor = true;
            this.OutputBtn.Click += new System.EventHandler(this.OutputBtn_Click);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(12, 128);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(74, 13);
            this.OutputLabel.TabIndex = 21;
            this.OutputLabel.Text = "Image Output:";
            // 
            // OutputPath
            // 
            this.OutputPath.AutoSize = true;
            this.OutputPath.Location = new System.Drawing.Point(106, 127);
            this.OutputPath.Name = "OutputPath";
            this.OutputPath.Size = new System.Drawing.Size(16, 13);
            this.OutputPath.TabIndex = 22;
            this.OutputPath.Text = "...";
            // 
            // MoveBtn
            // 
            this.MoveBtn.Location = new System.Drawing.Point(13, 145);
            this.MoveBtn.Name = "MoveBtn";
            this.MoveBtn.Size = new System.Drawing.Size(136, 23);
            this.MoveBtn.TabIndex = 23;
            this.MoveBtn.Text = "Select Backup Folder";
            this.MoveBtn.UseVisualStyleBackColor = true;
            this.MoveBtn.Click += new System.EventHandler(this.MoveBtn_Click);
            // 
            // BackupLabel
            // 
            this.BackupLabel.AutoSize = true;
            this.BackupLabel.Location = new System.Drawing.Point(13, 171);
            this.BackupLabel.Name = "BackupLabel";
            this.BackupLabel.Size = new System.Drawing.Size(72, 13);
            this.BackupLabel.TabIndex = 24;
            this.BackupLabel.Text = "Backup Path:";
            // 
            // BackUpPath
            // 
            this.BackUpPath.AutoSize = true;
            this.BackUpPath.Location = new System.Drawing.Point(106, 171);
            this.BackUpPath.Name = "BackUpPath";
            this.BackUpPath.Size = new System.Drawing.Size(16, 13);
            this.BackUpPath.TabIndex = 25;
            this.BackUpPath.Text = "...";
            // 
            // ConvertLabel
            // 
            this.ConvertLabel.AutoSize = true;
            this.ConvertLabel.Location = new System.Drawing.Point(145, 194);
            this.ConvertLabel.Name = "ConvertLabel";
            this.ConvertLabel.Size = new System.Drawing.Size(87, 13);
            this.ConvertLabel.TabIndex = 26;
            this.ConvertLabel.Text = "Convert Files To:";
            // 
            // Hours
            // 
            this.Hours.Location = new System.Drawing.Point(303, 187);
            this.Hours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(120, 20);
            this.Hours.TabIndex = 27;
            // 
            // minutes
            // 
            this.minutes.Location = new System.Drawing.Point(303, 216);
            this.minutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(120, 20);
            this.minutes.TabIndex = 28;
            // 
            // seconds
            // 
            this.seconds.Location = new System.Drawing.Point(303, 244);
            this.seconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(120, 20);
            this.seconds.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Hours";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Minutes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Seconds";
            // 
            // StartOnBoot
            // 
            this.StartOnBoot.AutoSize = true;
            this.StartOnBoot.Location = new System.Drawing.Point(690, 71);
            this.StartOnBoot.Name = "StartOnBoot";
            this.StartOnBoot.Size = new System.Drawing.Size(139, 17);
            this.StartOnBoot.TabIndex = 33;
            this.StartOnBoot.Text = "Start Watching On Start";
            this.StartOnBoot.UseVisualStyleBackColor = true;
            // 
            // Defaults
            // 
            this.Defaults.Location = new System.Drawing.Point(597, 12);
            this.Defaults.Name = "Defaults";
            this.Defaults.Size = new System.Drawing.Size(107, 23);
            this.Defaults.TabIndex = 34;
            this.Defaults.Text = "Load Defaults";
            this.Defaults.UseVisualStyleBackColor = true;
            this.Defaults.Click += new System.EventHandler(this.Defaults_Click);
            // 
            // SetSuffixBtn
            // 
            this.SetSuffixBtn.Location = new System.Drawing.Point(522, 184);
            this.SetSuffixBtn.Name = "SetSuffixBtn";
            this.SetSuffixBtn.Size = new System.Drawing.Size(75, 23);
            this.SetSuffixBtn.TabIndex = 35;
            this.SetSuffixBtn.Text = "Set Suffix";
            this.SetSuffixBtn.UseVisualStyleBackColor = true;
            this.SetSuffixBtn.Click += new System.EventHandler(this.SetSuffixBtn_Click);
            // 
            // Currentsuffixlabel
            // 
            this.Currentsuffixlabel.AutoSize = true;
            this.Currentsuffixlabel.Location = new System.Drawing.Point(519, 246);
            this.Currentsuffixlabel.Name = "Currentsuffixlabel";
            this.Currentsuffixlabel.Size = new System.Drawing.Size(73, 13);
            this.Currentsuffixlabel.TabIndex = 36;
            this.Currentsuffixlabel.Text = "Current Suffix:";
            // 
            // PrefixTXT
            // 
            this.PrefixTXT.Location = new System.Drawing.Point(522, 215);
            this.PrefixTXT.Name = "PrefixTXT";
            this.PrefixTXT.Size = new System.Drawing.Size(301, 20);
            this.PrefixTXT.TabIndex = 37;
            // 
            // RandomPreFix
            // 
            this.RandomPreFix.Location = new System.Drawing.Point(603, 184);
            this.RandomPreFix.Name = "RandomPreFix";
            this.RandomPreFix.Size = new System.Drawing.Size(100, 23);
            this.RandomPreFix.TabIndex = 38;
            this.RandomPreFix.Text = "Randomize Suffix";
            this.RandomPreFix.UseVisualStyleBackColor = true;
            this.RandomPreFix.Click += new System.EventHandler(this.RandomPreFix_Click);
            // 
            // CurrentSuffix
            // 
            this.CurrentSuffix.AutoSize = true;
            this.CurrentSuffix.Location = new System.Drawing.Point(596, 245);
            this.CurrentSuffix.Name = "CurrentSuffix";
            this.CurrentSuffix.Size = new System.Drawing.Size(0, 13);
            this.CurrentSuffix.TabIndex = 39;
            // 
            // DubCheck
            // 
            this.DubCheck.AutoSize = true;
            this.DubCheck.Location = new System.Drawing.Point(710, 187);
            this.DubCheck.Name = "DubCheck";
            this.DubCheck.Size = new System.Drawing.Size(122, 17);
            this.DubCheck.TabIndex = 40;
            this.DubCheck.Text = "Dublicate Protection";
            this.DubCheck.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 450);
            this.Controls.Add(this.DubCheck);
            this.Controls.Add(this.CurrentSuffix);
            this.Controls.Add(this.RandomPreFix);
            this.Controls.Add(this.PrefixTXT);
            this.Controls.Add(this.Currentsuffixlabel);
            this.Controls.Add(this.SetSuffixBtn);
            this.Controls.Add(this.Defaults);
            this.Controls.Add(this.StartOnBoot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seconds);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.Hours);
            this.Controls.Add(this.ConvertLabel);
            this.Controls.Add(this.BackUpPath);
            this.Controls.Add(this.BackupLabel);
            this.Controls.Add(this.MoveBtn);
            this.Controls.Add(this.OutputPath);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.OutputBtn);
            this.Controls.Add(this.labellog);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.LoadBtn);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.WatchPath);
            this.Controls.Add(this.Watch);
            this.Controls.Add(this.FolderToWatchBtn);
            this.Controls.Add(this.ffmpegpath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RBPNG);
            this.Controls.Add(this.RBJPG);
            this.Controls.Add(this.ManualCheck);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.CurrentFileLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.SelectedFileTypes);
            this.Controls.Add(this.Types);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Folder Watcher";
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Types;
        private System.Windows.Forms.CheckedListBox SelectedFileTypes;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Label CurrentFileLabel;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Button ManualCheck;
        private System.Windows.Forms.RadioButton RBJPG;
        private System.Windows.Forms.RadioButton RBPNG;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ffmpegpath;
        private System.Windows.Forms.Button FolderToWatchBtn;
        private System.Windows.Forms.Label Watch;
        private System.Windows.Forms.Label WatchPath;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.Label labellog;
        private System.Windows.Forms.Button OutputBtn;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Label OutputPath;
        private System.Windows.Forms.Button MoveBtn;
        private System.Windows.Forms.Label BackupLabel;
        private System.Windows.Forms.Label BackUpPath;
        private System.Windows.Forms.Label ConvertLabel;
        private System.Windows.Forms.NumericUpDown Hours;
        private System.Windows.Forms.NumericUpDown minutes;
        private System.Windows.Forms.NumericUpDown seconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox StartOnBoot;
        private System.Windows.Forms.Button Defaults;
        private System.Windows.Forms.Button SetSuffixBtn;
        private System.Windows.Forms.Label Currentsuffixlabel;
        private System.Windows.Forms.TextBox PrefixTXT;
        private System.Windows.Forms.Button RandomPreFix;
        private System.Windows.Forms.Label CurrentSuffix;
        private System.Windows.Forms.CheckBox DubCheck;
    }
}

