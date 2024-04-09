namespace folderwatcherffmpeg
{
    partial class SettingsForm
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
            this.BackupLabel = new System.Windows.Forms.Label();
            this.MoveBtn = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.OutputBtn = new System.Windows.Forms.Button();
            this.Watch = new System.Windows.Forms.Label();
            this.FolderToWatchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SelectedFileTypes = new System.Windows.Forms.CheckedListBox();
            this.Types = new System.Windows.Forms.Label();
            this.BackUpPath = new System.Windows.Forms.Label();
            this.OutputPath = new System.Windows.Forms.Label();
            this.WatchPath = new System.Windows.Forms.Label();
            this.ffmpegpath = new System.Windows.Forms.Label();
            this.DubCheck = new System.Windows.Forms.CheckBox();
            this.CurrentSuffix = new System.Windows.Forms.Label();
            this.RandomPreFix = new System.Windows.Forms.Button();
            this.PrefixTXT = new System.Windows.Forms.TextBox();
            this.Currentsuffixlabel = new System.Windows.Forms.Label();
            this.SetSuffixBtn = new System.Windows.Forms.Button();
            this.StartOnBoot = new System.Windows.Forms.CheckBox();
            this.Defaults = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.Apply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.seconds = new System.Windows.Forms.NumericUpDown();
            this.minutes = new System.Windows.Forms.NumericUpDown();
            this.Hours = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).BeginInit();
            this.SuspendLayout();
            // 
            // BackupLabel
            // 
            this.BackupLabel.AutoSize = true;
            this.BackupLabel.Location = new System.Drawing.Point(12, 300);
            this.BackupLabel.Name = "BackupLabel";
            this.BackupLabel.Size = new System.Drawing.Size(72, 13);
            this.BackupLabel.TabIndex = 34;
            this.BackupLabel.Text = "Backup Path:";
            // 
            // MoveBtn
            // 
            this.MoveBtn.Location = new System.Drawing.Point(12, 274);
            this.MoveBtn.Name = "MoveBtn";
            this.MoveBtn.Size = new System.Drawing.Size(136, 23);
            this.MoveBtn.TabIndex = 33;
            this.MoveBtn.Text = "Select Backup Folder";
            this.MoveBtn.UseVisualStyleBackColor = true;
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(11, 257);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(74, 13);
            this.OutputLabel.TabIndex = 32;
            this.OutputLabel.Text = "Image Output:";
            // 
            // OutputBtn
            // 
            this.OutputBtn.Location = new System.Drawing.Point(12, 230);
            this.OutputBtn.Name = "OutputBtn";
            this.OutputBtn.Size = new System.Drawing.Size(136, 23);
            this.OutputBtn.TabIndex = 31;
            this.OutputBtn.Text = "Select Output Path";
            this.OutputBtn.UseVisualStyleBackColor = true;
            // 
            // Watch
            // 
            this.Watch.AutoSize = true;
            this.Watch.Location = new System.Drawing.Point(11, 214);
            this.Watch.Name = "Watch";
            this.Watch.Size = new System.Drawing.Size(88, 13);
            this.Watch.TabIndex = 30;
            this.Watch.Text = "Watching Folder:";
            // 
            // FolderToWatchBtn
            // 
            this.FolderToWatchBtn.Location = new System.Drawing.Point(12, 183);
            this.FolderToWatchBtn.Name = "FolderToWatchBtn";
            this.FolderToWatchBtn.Size = new System.Drawing.Size(136, 23);
            this.FolderToWatchBtn.TabIndex = 29;
            this.FolderToWatchBtn.Text = "Select Folder To Watch";
            this.FolderToWatchBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ffmpeg path: ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Select ffmpeg folder";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // SelectedFileTypes
            // 
            this.SelectedFileTypes.CheckOnClick = true;
            this.SelectedFileTypes.FormattingEnabled = true;
            this.SelectedFileTypes.Items.AddRange(new object[] {
            "Avif",
            "PNG",
            "JPG",
            "JFIF",
            "WEBP",
            "BMP"});
            this.SelectedFileTypes.Location = new System.Drawing.Point(466, 35);
            this.SelectedFileTypes.Name = "SelectedFileTypes";
            this.SelectedFileTypes.Size = new System.Drawing.Size(120, 109);
            this.SelectedFileTypes.TabIndex = 26;
            this.SelectedFileTypes.ThreeDCheckBoxes = true;
            // 
            // Types
            // 
            this.Types.AutoSize = true;
            this.Types.Location = new System.Drawing.Point(463, 12);
            this.Types.Name = "Types";
            this.Types.Size = new System.Drawing.Size(124, 13);
            this.Types.TabIndex = 25;
            this.Types.Text = "File Types To Watch For";
            // 
            // BackUpPath
            // 
            this.BackUpPath.AutoSize = true;
            this.BackUpPath.Location = new System.Drawing.Point(98, 300);
            this.BackUpPath.Name = "BackUpPath";
            this.BackUpPath.Size = new System.Drawing.Size(16, 13);
            this.BackUpPath.TabIndex = 38;
            this.BackUpPath.Text = "...";
            // 
            // OutputPath
            // 
            this.OutputPath.AutoSize = true;
            this.OutputPath.Location = new System.Drawing.Point(98, 256);
            this.OutputPath.Name = "OutputPath";
            this.OutputPath.Size = new System.Drawing.Size(16, 13);
            this.OutputPath.TabIndex = 37;
            this.OutputPath.Text = "...";
            // 
            // WatchPath
            // 
            this.WatchPath.AutoSize = true;
            this.WatchPath.Location = new System.Drawing.Point(98, 214);
            this.WatchPath.Name = "WatchPath";
            this.WatchPath.Size = new System.Drawing.Size(16, 13);
            this.WatchPath.TabIndex = 36;
            this.WatchPath.Text = "...";
            // 
            // ffmpegpath
            // 
            this.ffmpegpath.AutoSize = true;
            this.ffmpegpath.Location = new System.Drawing.Point(98, 167);
            this.ffmpegpath.Name = "ffmpegpath";
            this.ffmpegpath.Size = new System.Drawing.Size(16, 13);
            this.ffmpegpath.TabIndex = 35;
            this.ffmpegpath.Text = "...";
            // 
            // DubCheck
            // 
            this.DubCheck.AutoSize = true;
            this.DubCheck.Location = new System.Drawing.Point(200, 67);
            this.DubCheck.Name = "DubCheck";
            this.DubCheck.Size = new System.Drawing.Size(122, 17);
            this.DubCheck.TabIndex = 47;
            this.DubCheck.Text = "Dublicate Protection";
            this.DubCheck.UseVisualStyleBackColor = true;
            // 
            // CurrentSuffix
            // 
            this.CurrentSuffix.AutoSize = true;
            this.CurrentSuffix.Location = new System.Drawing.Point(87, 118);
            this.CurrentSuffix.Name = "CurrentSuffix";
            this.CurrentSuffix.Size = new System.Drawing.Size(0, 13);
            this.CurrentSuffix.TabIndex = 46;
            // 
            // RandomPreFix
            // 
            this.RandomPreFix.Location = new System.Drawing.Point(93, 64);
            this.RandomPreFix.Name = "RandomPreFix";
            this.RandomPreFix.Size = new System.Drawing.Size(100, 23);
            this.RandomPreFix.TabIndex = 45;
            this.RandomPreFix.Text = "Randomize Suffix";
            this.RandomPreFix.UseVisualStyleBackColor = true;
            this.RandomPreFix.Click += new System.EventHandler(this.RandomPreFix_Click);
            // 
            // PrefixTXT
            // 
            this.PrefixTXT.Location = new System.Drawing.Point(12, 95);
            this.PrefixTXT.Name = "PrefixTXT";
            this.PrefixTXT.Size = new System.Drawing.Size(301, 20);
            this.PrefixTXT.TabIndex = 44;
            // 
            // Currentsuffixlabel
            // 
            this.Currentsuffixlabel.AutoSize = true;
            this.Currentsuffixlabel.Location = new System.Drawing.Point(11, 118);
            this.Currentsuffixlabel.Name = "Currentsuffixlabel";
            this.Currentsuffixlabel.Size = new System.Drawing.Size(73, 13);
            this.Currentsuffixlabel.TabIndex = 43;
            this.Currentsuffixlabel.Text = "Current Suffix:";
            // 
            // SetSuffixBtn
            // 
            this.SetSuffixBtn.Location = new System.Drawing.Point(12, 64);
            this.SetSuffixBtn.Name = "SetSuffixBtn";
            this.SetSuffixBtn.Size = new System.Drawing.Size(75, 23);
            this.SetSuffixBtn.TabIndex = 42;
            this.SetSuffixBtn.Text = "Set Suffix";
            this.SetSuffixBtn.UseVisualStyleBackColor = true;
            this.SetSuffixBtn.Click += new System.EventHandler(this.SetSuffixBtn_Click);
            // 
            // StartOnBoot
            // 
            this.StartOnBoot.AutoSize = true;
            this.StartOnBoot.Location = new System.Drawing.Point(12, 41);
            this.StartOnBoot.Name = "StartOnBoot";
            this.StartOnBoot.Size = new System.Drawing.Size(139, 17);
            this.StartOnBoot.TabIndex = 41;
            this.StartOnBoot.Text = "Start Watching On Start";
            this.StartOnBoot.UseVisualStyleBackColor = true;
            // 
            // Defaults
            // 
            this.Defaults.Location = new System.Drawing.Point(12, 12);
            this.Defaults.Name = "Defaults";
            this.Defaults.Size = new System.Drawing.Size(107, 23);
            this.Defaults.TabIndex = 50;
            this.Defaults.Text = "Load Defaults";
            this.Defaults.UseVisualStyleBackColor = true;
            this.Defaults.Click += new System.EventHandler(this.Defaults_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(238, 12);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(107, 23);
            this.LoadBtn.TabIndex = 49;
            this.LoadBtn.Text = "Load Settings";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // SaveBTN
            // 
            this.SaveBTN.Location = new System.Drawing.Point(125, 12);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(107, 23);
            this.SaveBTN.TabIndex = 48;
            this.SaveBTN.Text = "Save Settings";
            this.SaveBTN.UseVisualStyleBackColor = true;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(351, 12);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(75, 23);
            this.Apply.TabIndex = 51;
            this.Apply.Text = "Apply Settings";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Seconds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Minutes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Hours";
            // 
            // seconds
            // 
            this.seconds.Location = new System.Drawing.Point(387, 98);
            this.seconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(39, 20);
            this.seconds.TabIndex = 54;
            // 
            // minutes
            // 
            this.minutes.Location = new System.Drawing.Point(387, 70);
            this.minutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(39, 20);
            this.minutes.TabIndex = 53;
            // 
            // Hours
            // 
            this.Hours.Location = new System.Drawing.Point(387, 41);
            this.Hours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(39, 20);
            this.Hours.TabIndex = 52;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(599, 325);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seconds);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.Hours);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.Defaults);
            this.Controls.Add(this.LoadBtn);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.DubCheck);
            this.Controls.Add(this.CurrentSuffix);
            this.Controls.Add(this.RandomPreFix);
            this.Controls.Add(this.PrefixTXT);
            this.Controls.Add(this.Currentsuffixlabel);
            this.Controls.Add(this.SetSuffixBtn);
            this.Controls.Add(this.StartOnBoot);
            this.Controls.Add(this.BackUpPath);
            this.Controls.Add(this.OutputPath);
            this.Controls.Add(this.WatchPath);
            this.Controls.Add(this.ffmpegpath);
            this.Controls.Add(this.BackupLabel);
            this.Controls.Add(this.MoveBtn);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.OutputBtn);
            this.Controls.Add(this.Watch);
            this.Controls.Add(this.FolderToWatchBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SelectedFileTypes);
            this.Controls.Add(this.Types);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label BackupLabel;
        private System.Windows.Forms.Button MoveBtn;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Button OutputBtn;
        private System.Windows.Forms.Label Watch;
        private System.Windows.Forms.Button FolderToWatchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox SelectedFileTypes;
        private System.Windows.Forms.Label Types;
        private System.Windows.Forms.Label BackUpPath;
        private System.Windows.Forms.Label OutputPath;
        private System.Windows.Forms.Label WatchPath;
        private System.Windows.Forms.Label ffmpegpath;
        private System.Windows.Forms.CheckBox DubCheck;
        private System.Windows.Forms.Label CurrentSuffix;
        private System.Windows.Forms.Button RandomPreFix;
        private System.Windows.Forms.TextBox PrefixTXT;
        private System.Windows.Forms.Label Currentsuffixlabel;
        private System.Windows.Forms.Button SetSuffixBtn;
        private System.Windows.Forms.CheckBox StartOnBoot;
        private System.Windows.Forms.Button Defaults;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown seconds;
        private System.Windows.Forms.NumericUpDown minutes;
        private System.Windows.Forms.NumericUpDown Hours;
    }
}