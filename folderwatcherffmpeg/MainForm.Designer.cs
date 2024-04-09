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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LogLabel = new System.Windows.Forms.Label();
            this.CurrentFileLabel = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer = new System.Windows.Forms.Label();
            this.ManualCheck = new System.Windows.Forms.Button();
            this.RBJPG = new System.Windows.Forms.RadioButton();
            this.RBPNG = new System.Windows.Forms.RadioButton();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.labellog = new System.Windows.Forms.Label();
            this.ConvertLabel = new System.Windows.Forms.Label();
            this.Hours = new System.Windows.Forms.NumericUpDown();
            this.minutes = new System.Windows.Forms.NumericUpDown();
            this.seconds = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Turquoise;
            this.progressBar1.Location = new System.Drawing.Point(12, 415);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(810, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(11, 399);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(37, 13);
            this.LogLabel.TabIndex = 3;
            this.LogLabel.Text = "Status";
            // 
            // CurrentFileLabel
            // 
            this.CurrentFileLabel.AutoSize = true;
            this.CurrentFileLabel.Location = new System.Drawing.Point(12, 399);
            this.CurrentFileLabel.Name = "CurrentFileLabel";
            this.CurrentFileLabel.Size = new System.Drawing.Size(0, 13);
            this.CurrentFileLabel.TabIndex = 4;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(205, 41);
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
            this.Timer.Location = new System.Drawing.Point(205, 71);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(49, 13);
            this.Timer.TabIndex = 6;
            this.Timer.Text = "00:00:00";
            // 
            // ManualCheck
            // 
            this.ManualCheck.Location = new System.Drawing.Point(205, 9);
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
            this.RBJPG.Location = new System.Drawing.Point(12, 31);
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
            this.RBPNG.Location = new System.Drawing.Point(12, 57);
            this.RBPNG.Name = "RBPNG";
            this.RBPNG.Size = new System.Drawing.Size(48, 17);
            this.RBPNG.TabIndex = 9;
            this.RBPNG.TabStop = true;
            this.RBPNG.Text = "PNG";
            this.RBPNG.UseVisualStyleBackColor = true;
            this.RBPNG.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(11, 100);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.Size = new System.Drawing.Size(811, 283);
            this.Log.TabIndex = 18;
            this.Log.Text = "";
            // 
            // labellog
            // 
            this.labellog.AutoSize = true;
            this.labellog.Location = new System.Drawing.Point(12, 84);
            this.labellog.Name = "labellog";
            this.labellog.Size = new System.Drawing.Size(25, 13);
            this.labellog.TabIndex = 19;
            this.labellog.Text = "Log";
            // 
            // ConvertLabel
            // 
            this.ConvertLabel.AutoSize = true;
            this.ConvertLabel.Location = new System.Drawing.Point(9, 9);
            this.ConvertLabel.Name = "ConvertLabel";
            this.ConvertLabel.Size = new System.Drawing.Size(87, 13);
            this.ConvertLabel.TabIndex = 26;
            this.ConvertLabel.Text = "Convert Files To:";
            // 
            // Hours
            // 
            this.Hours.Location = new System.Drawing.Point(155, 9);
            this.Hours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(44, 20);
            this.Hours.TabIndex = 27;
            // 
            // minutes
            // 
            this.minutes.Location = new System.Drawing.Point(155, 38);
            this.minutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(44, 20);
            this.minutes.TabIndex = 28;
            // 
            // seconds
            // 
            this.seconds.Location = new System.Drawing.Point(155, 66);
            this.seconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(44, 20);
            this.seconds.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Hours";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Minutes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Seconds";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(718, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "Open Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.openSettigns);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seconds);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.Hours);
            this.Controls.Add(this.ConvertLabel);
            this.Controls.Add(this.labellog);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.RBPNG);
            this.Controls.Add(this.RBJPG);
            this.Controls.Add(this.ManualCheck);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.CurrentFileLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.progressBar1);
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Label CurrentFileLabel;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Button ManualCheck;
        private System.Windows.Forms.RadioButton RBJPG;
        private System.Windows.Forms.RadioButton RBPNG;
        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.Label labellog;
        private System.Windows.Forms.Label ConvertLabel;
        private System.Windows.Forms.NumericUpDown Hours;
        private System.Windows.Forms.NumericUpDown minutes;
        private System.Windows.Forms.NumericUpDown seconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}

