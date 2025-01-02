namespace Karta_muzyczna
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bChooseFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.labelPlaySound = new System.Windows.Forms.Label();
            this.labelWindowsMediaPlayer = new System.Windows.Forms.Label();
            this.labelWaveOutWrite = new System.Windows.Forms.Label();
            this.labelMCI = new System.Windows.Forms.Label();
            this.labelDirectSound = new System.Windows.Forms.Label();
            this.labelRecord = new System.Windows.Forms.Label();
            this.bRecord = new System.Windows.Forms.Button();
            this.bDS_stop = new System.Windows.Forms.Button();
            this.bDS_play = new System.Windows.Forms.Button();
            this.bMCI_stop = new System.Windows.Forms.Button();
            this.bMCI_pause = new System.Windows.Forms.Button();
            this.bMCI_play = new System.Windows.Forms.Button();
            this.bWOW_stop = new System.Windows.Forms.Button();
            this.bWOW_play = new System.Windows.Forms.Button();
            this.bWMP_stop = new System.Windows.Forms.Button();
            this.bWMP_pause = new System.Windows.Forms.Button();
            this.bWMP_play = new System.Windows.Forms.Button();
            this.bPS_stop = new System.Windows.Forms.Button();
            this.bPS_play = new System.Windows.Forms.Button();
            this.bWOW_pause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bChooseFile
            // 
            this.bChooseFile.Location = new System.Drawing.Point(78, 675);
            this.bChooseFile.Name = "bChooseFile";
            this.bChooseFile.Size = new System.Drawing.Size(113, 36);
            this.bChooseFile.TabIndex = 0;
            this.bChooseFile.Text = "Wybierz plik";
            this.bChooseFile.UseVisualStyleBackColor = true;
            this.bChooseFile.Click += new System.EventHandler(this.bChooseFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(198, 680);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(413, 26);
            this.txtFilePath.TabIndex = 1;
            // 
            // labelPlaySound
            // 
            this.labelPlaySound.AutoSize = true;
            this.labelPlaySound.Location = new System.Drawing.Point(180, 91);
            this.labelPlaySound.Name = "labelPlaySound";
            this.labelPlaySound.Size = new System.Drawing.Size(85, 20);
            this.labelPlaySound.TabIndex = 2;
            this.labelPlaySound.Text = "PlaySound";
            // 
            // labelWindowsMediaPlayer
            // 
            this.labelWindowsMediaPlayer.AutoSize = true;
            this.labelWindowsMediaPlayer.Location = new System.Drawing.Point(369, 91);
            this.labelWindowsMediaPlayer.Name = "labelWindowsMediaPlayer";
            this.labelWindowsMediaPlayer.Size = new System.Drawing.Size(235, 20);
            this.labelWindowsMediaPlayer.TabIndex = 3;
            this.labelWindowsMediaPlayer.Text = "Windows Media Player (ActiveX)";
            // 
            // labelWaveOutWrite
            // 
            this.labelWaveOutWrite.AutoSize = true;
            this.labelWaveOutWrite.Location = new System.Drawing.Point(381, 288);
            this.labelWaveOutWrite.Name = "labelWaveOutWrite";
            this.labelWaveOutWrite.Size = new System.Drawing.Size(203, 20);
            this.labelWaveOutWrite.TabIndex = 4;
            this.labelWaveOutWrite.Text = "WaveOutWrite (WaveForm)";
            // 
            // labelMCI
            // 
            this.labelMCI.AutoSize = true;
            this.labelMCI.Location = new System.Drawing.Point(476, 503);
            this.labelMCI.Name = "labelMCI";
            this.labelMCI.Size = new System.Drawing.Size(42, 20);
            this.labelMCI.TabIndex = 5;
            this.labelMCI.Text = "MCI ";
            // 
            // labelDirectSound
            // 
            this.labelDirectSound.AutoSize = true;
            this.labelDirectSound.Location = new System.Drawing.Point(176, 288);
            this.labelDirectSound.Name = "labelDirectSound";
            this.labelDirectSound.Size = new System.Drawing.Size(102, 20);
            this.labelDirectSound.TabIndex = 6;
            this.labelDirectSound.Text = "Direct Sound";
            // 
            // labelRecord
            // 
            this.labelRecord.AutoSize = true;
            this.labelRecord.Location = new System.Drawing.Point(187, 503);
            this.labelRecord.Name = "labelRecord";
            this.labelRecord.Size = new System.Drawing.Size(91, 20);
            this.labelRecord.TabIndex = 7;
            this.labelRecord.Text = "Nagrywanie";
            // 
            // bRecord
            // 
            this.bRecord.Image = global::Karta_muzyczna.Properties.Resources.rec_button;
            this.bRecord.Location = new System.Drawing.Point(207, 542);
            this.bRecord.Name = "bRecord";
            this.bRecord.Size = new System.Drawing.Size(49, 49);
            this.bRecord.TabIndex = 20;
            this.bRecord.UseVisualStyleBackColor = true;
            this.bRecord.Click += new System.EventHandler(this.bRecord_Click);
            // 
            // bDS_stop
            // 
            this.bDS_stop.Image = global::Karta_muzyczna.Properties.Resources.stop_button;
            this.bDS_stop.Location = new System.Drawing.Point(238, 327);
            this.bDS_stop.Name = "bDS_stop";
            this.bDS_stop.Size = new System.Drawing.Size(49, 49);
            this.bDS_stop.TabIndex = 19;
            this.bDS_stop.UseVisualStyleBackColor = true;
            this.bDS_stop.Click += new System.EventHandler(this.bDS_stop_Click);
            // 
            // bDS_play
            // 
            this.bDS_play.Image = global::Karta_muzyczna.Properties.Resources.play_button;
            this.bDS_play.Location = new System.Drawing.Point(172, 327);
            this.bDS_play.Name = "bDS_play";
            this.bDS_play.Size = new System.Drawing.Size(51, 49);
            this.bDS_play.TabIndex = 18;
            this.bDS_play.UseVisualStyleBackColor = true;
            this.bDS_play.Click += new System.EventHandler(this.bDS_play_Click);
            // 
            // bMCI_stop
            // 
            this.bMCI_stop.Image = ((System.Drawing.Image)(resources.GetObject("bMCI_stop.Image")));
            this.bMCI_stop.Location = new System.Drawing.Point(533, 542);
            this.bMCI_stop.Name = "bMCI_stop";
            this.bMCI_stop.Size = new System.Drawing.Size(51, 49);
            this.bMCI_stop.TabIndex = 17;
            this.bMCI_stop.UseVisualStyleBackColor = true;
            this.bMCI_stop.Click += new System.EventHandler(this.bMCI_stop_Click);
            // 
            // bMCI_pause
            // 
            this.bMCI_pause.Image = ((System.Drawing.Image)(resources.GetObject("bMCI_pause.Image")));
            this.bMCI_pause.Location = new System.Drawing.Point(467, 542);
            this.bMCI_pause.Name = "bMCI_pause";
            this.bMCI_pause.Size = new System.Drawing.Size(51, 49);
            this.bMCI_pause.TabIndex = 16;
            this.bMCI_pause.UseVisualStyleBackColor = true;
            this.bMCI_pause.Click += new System.EventHandler(this.bMCI_pause_Click);
            // 
            // bMCI_play
            // 
            this.bMCI_play.Image = ((System.Drawing.Image)(resources.GetObject("bMCI_play.Image")));
            this.bMCI_play.Location = new System.Drawing.Point(404, 542);
            this.bMCI_play.Name = "bMCI_play";
            this.bMCI_play.Size = new System.Drawing.Size(51, 49);
            this.bMCI_play.TabIndex = 15;
            this.bMCI_play.UseVisualStyleBackColor = true;
            this.bMCI_play.Click += new System.EventHandler(this.bMCI_play_Click);
            // 
            // bWOW_stop
            // 
            this.bWOW_stop.Cursor = System.Windows.Forms.Cursors.Default;
            this.bWOW_stop.Image = ((System.Drawing.Image)(resources.GetObject("bWOW_stop.Image")));
            this.bWOW_stop.Location = new System.Drawing.Point(516, 326);
            this.bWOW_stop.Name = "bWOW_stop";
            this.bWOW_stop.Size = new System.Drawing.Size(51, 49);
            this.bWOW_stop.TabIndex = 14;
            this.bWOW_stop.UseVisualStyleBackColor = true;
            this.bWOW_stop.Click += new System.EventHandler(this.bWOW_stop_Click);
            // 
            // bWOW_play
            // 
            this.bWOW_play.Image = ((System.Drawing.Image)(resources.GetObject("bWOW_play.Image")));
            this.bWOW_play.Location = new System.Drawing.Point(385, 326);
            this.bWOW_play.Name = "bWOW_play";
            this.bWOW_play.Size = new System.Drawing.Size(51, 49);
            this.bWOW_play.TabIndex = 13;
            this.bWOW_play.UseVisualStyleBackColor = true;
            this.bWOW_play.Click += new System.EventHandler(this.bWOW_play_Click);
            // 
            // bWMP_stop
            // 
            this.bWMP_stop.Image = ((System.Drawing.Image)(resources.GetObject("bWMP_stop.Image")));
            this.bWMP_stop.Location = new System.Drawing.Point(524, 130);
            this.bWMP_stop.Name = "bWMP_stop";
            this.bWMP_stop.Size = new System.Drawing.Size(51, 49);
            this.bWMP_stop.TabIndex = 12;
            this.bWMP_stop.UseVisualStyleBackColor = true;
            this.bWMP_stop.Click += new System.EventHandler(this.bWMP_stop_Click);
            // 
            // bWMP_pause
            // 
            this.bWMP_pause.Image = ((System.Drawing.Image)(resources.GetObject("bWMP_pause.Image")));
            this.bWMP_pause.Location = new System.Drawing.Point(455, 130);
            this.bWMP_pause.Name = "bWMP_pause";
            this.bWMP_pause.Size = new System.Drawing.Size(51, 49);
            this.bWMP_pause.TabIndex = 11;
            this.bWMP_pause.UseVisualStyleBackColor = true;
            this.bWMP_pause.Click += new System.EventHandler(this.bWMP_pause_Click);
            // 
            // bWMP_play
            // 
            this.bWMP_play.Image = ((System.Drawing.Image)(resources.GetObject("bWMP_play.Image")));
            this.bWMP_play.Location = new System.Drawing.Point(387, 130);
            this.bWMP_play.Name = "bWMP_play";
            this.bWMP_play.Size = new System.Drawing.Size(51, 49);
            this.bWMP_play.TabIndex = 10;
            this.bWMP_play.UseVisualStyleBackColor = true;
            this.bWMP_play.Click += new System.EventHandler(this.bWMP_play_Click);
            // 
            // bPS_stop
            // 
            this.bPS_stop.Image = ((System.Drawing.Image)(resources.GetObject("bPS_stop.Image")));
            this.bPS_stop.Location = new System.Drawing.Point(234, 130);
            this.bPS_stop.Name = "bPS_stop";
            this.bPS_stop.Size = new System.Drawing.Size(51, 49);
            this.bPS_stop.TabIndex = 9;
            this.bPS_stop.UseVisualStyleBackColor = true;
            this.bPS_stop.Click += new System.EventHandler(this.bPS_stop_Click);
            // 
            // bPS_play
            // 
            this.bPS_play.Image = ((System.Drawing.Image)(resources.GetObject("bPS_play.Image")));
            this.bPS_play.Location = new System.Drawing.Point(165, 130);
            this.bPS_play.Name = "bPS_play";
            this.bPS_play.Size = new System.Drawing.Size(51, 49);
            this.bPS_play.TabIndex = 8;
            this.bPS_play.UseVisualStyleBackColor = true;
            this.bPS_play.Click += new System.EventHandler(this.bPS_play_Click);
            // 
            // bWOW_pause
            // 
            this.bWOW_pause.Image = global::Karta_muzyczna.Properties.Resources.video_pause_button;
            this.bWOW_pause.Location = new System.Drawing.Point(451, 326);
            this.bWOW_pause.Name = "bWOW_pause";
            this.bWOW_pause.Size = new System.Drawing.Size(49, 49);
            this.bWOW_pause.TabIndex = 21;
            this.bWOW_pause.UseVisualStyleBackColor = true;
            this.bWOW_pause.Click += new System.EventHandler(this.bWOW_pause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(167, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Odtwarzanie dźwięku zapisanego w zbiorze WAV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(271, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Odtwarzanie dźwięku";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(272, 462);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Zapisywanie dźwięku";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(254, 636);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "Wybór pliku do odtwarzania";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(778, 744);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bWOW_pause);
            this.Controls.Add(this.bRecord);
            this.Controls.Add(this.bDS_stop);
            this.Controls.Add(this.bDS_play);
            this.Controls.Add(this.bMCI_stop);
            this.Controls.Add(this.bMCI_pause);
            this.Controls.Add(this.bMCI_play);
            this.Controls.Add(this.bWOW_stop);
            this.Controls.Add(this.bWOW_play);
            this.Controls.Add(this.bWMP_stop);
            this.Controls.Add(this.bWMP_pause);
            this.Controls.Add(this.bWMP_play);
            this.Controls.Add(this.bPS_stop);
            this.Controls.Add(this.bPS_play);
            this.Controls.Add(this.labelRecord);
            this.Controls.Add(this.labelDirectSound);
            this.Controls.Add(this.labelMCI);
            this.Controls.Add(this.labelWaveOutWrite);
            this.Controls.Add(this.labelWindowsMediaPlayer);
            this.Controls.Add(this.labelPlaySound);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.bChooseFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bChooseFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label labelPlaySound;
        private System.Windows.Forms.Label labelWindowsMediaPlayer;
        private System.Windows.Forms.Label labelWaveOutWrite;
        private System.Windows.Forms.Label labelMCI;
        private System.Windows.Forms.Label labelDirectSound;
        private System.Windows.Forms.Label labelRecord;
        private System.Windows.Forms.Button bPS_play;
        private System.Windows.Forms.Button bPS_stop;
        private System.Windows.Forms.Button bWMP_play;
        private System.Windows.Forms.Button bWMP_pause;
        private System.Windows.Forms.Button bWMP_stop;
        private System.Windows.Forms.Button bWOW_play;
        private System.Windows.Forms.Button bWOW_stop;
        private System.Windows.Forms.Button bMCI_play;
        private System.Windows.Forms.Button bMCI_pause;
        private System.Windows.Forms.Button bMCI_stop;
        private System.Windows.Forms.Button bDS_play;
        private System.Windows.Forms.Button bDS_stop;
        private System.Windows.Forms.Button bRecord;
        private System.Windows.Forms.Button bWOW_pause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

