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
            this.labelWindowsMediaPlayer = new System.Windows.Forms.Label();
            this.labelWaveOutWrite = new System.Windows.Forms.Label();
            this.labelMCI = new System.Windows.Forms.Label();
            this.labelRecord = new System.Windows.Forms.Label();
            this.bRecord = new System.Windows.Forms.Button();
            this.bWOW_stop = new System.Windows.Forms.Button();
            this.bWOW_play = new System.Windows.Forms.Button();
            this.bWMP_stop = new System.Windows.Forms.Button();
            this.bWMP_pause = new System.Windows.Forms.Button();
            this.bWMP_play = new System.Windows.Forms.Button();
            this.bWOW_pause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.textBoxChanels = new System.Windows.Forms.TextBox();
            this.textBoxSamples = new System.Windows.Forms.TextBox();
            this.textBoxBits = new System.Windows.Forms.TextBox();
            this.bRecordFiltered = new System.Windows.Forms.Button();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.textBoxAlbum = new System.Windows.Forms.TextBox();
            this.textBoxArtist = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
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
            // labelWindowsMediaPlayer
            // 
            this.labelWindowsMediaPlayer.AutoSize = true;
            this.labelWindowsMediaPlayer.Location = new System.Drawing.Point(272, 87);
            this.labelWindowsMediaPlayer.Name = "labelWindowsMediaPlayer";
            this.labelWindowsMediaPlayer.Size = new System.Drawing.Size(235, 20);
            this.labelWindowsMediaPlayer.TabIndex = 3;
            this.labelWindowsMediaPlayer.Text = "Windows Media Player (ActiveX)";
            // 
            // labelWaveOutWrite
            // 
            this.labelWaveOutWrite.AutoSize = true;
            this.labelWaveOutWrite.Location = new System.Drawing.Point(286, 293);
            this.labelWaveOutWrite.Name = "labelWaveOutWrite";
            this.labelWaveOutWrite.Size = new System.Drawing.Size(203, 20);
            this.labelWaveOutWrite.TabIndex = 4;
            this.labelWaveOutWrite.Text = "WaveOutWrite (WaveForm)";
            // 
            // labelMCI
            // 
            this.labelMCI.AutoSize = true;
            this.labelMCI.Location = new System.Drawing.Point(387, 503);
            this.labelMCI.Name = "labelMCI";
            this.labelMCI.Size = new System.Drawing.Size(228, 20);
            this.labelMCI.TabIndex = 5;
            this.labelMCI.Text = "Nagrywanie z filtrem (tłumienie)";
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
            this.bRecord.Image = global::Karta_muzyczna.Properties.Resources.record1;
            this.bRecord.Location = new System.Drawing.Point(207, 542);
            this.bRecord.Name = "bRecord";
            this.bRecord.Size = new System.Drawing.Size(49, 49);
            this.bRecord.TabIndex = 20;
            this.bRecord.UseVisualStyleBackColor = true;
            this.bRecord.Click += new System.EventHandler(this.bRecord_Click);
            // 
            // bWOW_stop
            // 
            this.bWOW_stop.Cursor = System.Windows.Forms.Cursors.Default;
            this.bWOW_stop.Image = ((System.Drawing.Image)(resources.GetObject("bWOW_stop.Image")));
            this.bWOW_stop.Location = new System.Drawing.Point(421, 331);
            this.bWOW_stop.Name = "bWOW_stop";
            this.bWOW_stop.Size = new System.Drawing.Size(51, 49);
            this.bWOW_stop.TabIndex = 14;
            this.bWOW_stop.UseVisualStyleBackColor = true;
            this.bWOW_stop.Click += new System.EventHandler(this.bWOW_stop_Click);
            // 
            // bWOW_play
            // 
            this.bWOW_play.Image = ((System.Drawing.Image)(resources.GetObject("bWOW_play.Image")));
            this.bWOW_play.Location = new System.Drawing.Point(290, 331);
            this.bWOW_play.Name = "bWOW_play";
            this.bWOW_play.Size = new System.Drawing.Size(51, 49);
            this.bWOW_play.TabIndex = 13;
            this.bWOW_play.UseVisualStyleBackColor = true;
            this.bWOW_play.Click += new System.EventHandler(this.bWOW_play_Click);
            // 
            // bWMP_stop
            // 
            this.bWMP_stop.Image = ((System.Drawing.Image)(resources.GetObject("bWMP_stop.Image")));
            this.bWMP_stop.Location = new System.Drawing.Point(427, 126);
            this.bWMP_stop.Name = "bWMP_stop";
            this.bWMP_stop.Size = new System.Drawing.Size(51, 49);
            this.bWMP_stop.TabIndex = 12;
            this.bWMP_stop.UseVisualStyleBackColor = true;
            this.bWMP_stop.Click += new System.EventHandler(this.bWMP_stop_Click);
            // 
            // bWMP_pause
            // 
            this.bWMP_pause.Image = ((System.Drawing.Image)(resources.GetObject("bWMP_pause.Image")));
            this.bWMP_pause.Location = new System.Drawing.Point(358, 126);
            this.bWMP_pause.Name = "bWMP_pause";
            this.bWMP_pause.Size = new System.Drawing.Size(51, 49);
            this.bWMP_pause.TabIndex = 11;
            this.bWMP_pause.UseVisualStyleBackColor = true;
            this.bWMP_pause.Click += new System.EventHandler(this.bWMP_pause_Click);
            // 
            // bWMP_play
            // 
            this.bWMP_play.Image = ((System.Drawing.Image)(resources.GetObject("bWMP_play.Image")));
            this.bWMP_play.Location = new System.Drawing.Point(290, 126);
            this.bWMP_play.Name = "bWMP_play";
            this.bWMP_play.Size = new System.Drawing.Size(51, 49);
            this.bWMP_play.TabIndex = 10;
            this.bWMP_play.UseVisualStyleBackColor = true;
            this.bWMP_play.Click += new System.EventHandler(this.bWMP_play_Click);
            // 
            // bWOW_pause
            // 
            this.bWOW_pause.Image = global::Karta_muzyczna.Properties.Resources.video_pause_button;
            this.bWOW_pause.Location = new System.Drawing.Point(356, 331);
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
            this.label1.Location = new System.Drawing.Point(149, 238);
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
            this.label2.Size = new System.Drawing.Size(246, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Odtwarzanie dźwięku .mp3";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(701, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Odczytane pola nagłówka WAV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(740, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "wFormatTag";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(762, 394);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "nChanels";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(706, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "nSamplesPerSec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(713, 476);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "wBitsPerSample";
            // 
            // textBoxTag
            // 
            this.textBoxTag.Location = new System.Drawing.Point(857, 353);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.Size = new System.Drawing.Size(100, 26);
            this.textBoxTag.TabIndex = 32;
            // 
            // textBoxChanels
            // 
            this.textBoxChanels.Location = new System.Drawing.Point(857, 391);
            this.textBoxChanels.Name = "textBoxChanels";
            this.textBoxChanels.Size = new System.Drawing.Size(100, 26);
            this.textBoxChanels.TabIndex = 33;
            // 
            // textBoxSamples
            // 
            this.textBoxSamples.Location = new System.Drawing.Point(857, 433);
            this.textBoxSamples.Name = "textBoxSamples";
            this.textBoxSamples.Size = new System.Drawing.Size(100, 26);
            this.textBoxSamples.TabIndex = 34;
            // 
            // textBoxBits
            // 
            this.textBoxBits.Location = new System.Drawing.Point(857, 473);
            this.textBoxBits.Name = "textBoxBits";
            this.textBoxBits.Size = new System.Drawing.Size(100, 26);
            this.textBoxBits.TabIndex = 35;
            // 
            // bRecordFiltered
            // 
            this.bRecordFiltered.Image = global::Karta_muzyczna.Properties.Resources.record1;
            this.bRecordFiltered.Location = new System.Drawing.Point(457, 542);
            this.bRecordFiltered.Name = "bRecordFiltered";
            this.bRecordFiltered.Size = new System.Drawing.Size(49, 49);
            this.bRecordFiltered.TabIndex = 36;
            this.bRecordFiltered.UseVisualStyleBackColor = true;
            this.bRecordFiltered.Click += new System.EventHandler(this.bRecordFiltered_Click);
            // 
            // textBoxGenre
            // 
            this.textBoxGenre.Location = new System.Drawing.Point(857, 201);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(100, 26);
            this.textBoxGenre.TabIndex = 45;
            // 
            // textBoxAlbum
            // 
            this.textBoxAlbum.Location = new System.Drawing.Point(857, 161);
            this.textBoxAlbum.Name = "textBoxAlbum";
            this.textBoxAlbum.Size = new System.Drawing.Size(100, 26);
            this.textBoxAlbum.TabIndex = 44;
            // 
            // textBoxArtist
            // 
            this.textBoxArtist.Location = new System.Drawing.Point(857, 119);
            this.textBoxArtist.Name = "textBoxArtist";
            this.textBoxArtist.Size = new System.Drawing.Size(100, 26);
            this.textBoxArtist.TabIndex = 43;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(857, 81);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 26);
            this.textBoxTitle.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(784, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 41;
            this.label10.Text = "Genre";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(784, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 40;
            this.label11.Text = "Album";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(792, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 20);
            this.label12.TabIndex = 39;
            this.label12.Text = "Artist";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(800, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 20);
            this.label13.TabIndex = 38;
            this.label13.Text = "Title";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(701, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(280, 25);
            this.label14.TabIndex = 37;
            this.label14.Text = "Odczytane pola nagłówka mp3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(768, 242);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 20);
            this.label15.TabIndex = 46;
            this.label15.Text = "Duration";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(857, 239);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(100, 26);
            this.textBoxDuration.TabIndex = 47;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1052, 753);
            this.Controls.Add(this.textBoxDuration);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxGenre);
            this.Controls.Add(this.textBoxAlbum);
            this.Controls.Add(this.textBoxArtist);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.bRecordFiltered);
            this.Controls.Add(this.textBoxBits);
            this.Controls.Add(this.textBoxSamples);
            this.Controls.Add(this.textBoxChanels);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bWOW_pause);
            this.Controls.Add(this.bRecord);
            this.Controls.Add(this.bWOW_stop);
            this.Controls.Add(this.bWOW_play);
            this.Controls.Add(this.bWMP_stop);
            this.Controls.Add(this.bWMP_pause);
            this.Controls.Add(this.bWMP_play);
            this.Controls.Add(this.labelRecord);
            this.Controls.Add(this.labelMCI);
            this.Controls.Add(this.labelWaveOutWrite);
            this.Controls.Add(this.labelWindowsMediaPlayer);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.bChooseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bChooseFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label labelWindowsMediaPlayer;
        private System.Windows.Forms.Label labelWaveOutWrite;
        private System.Windows.Forms.Label labelMCI;
        private System.Windows.Forms.Label labelRecord;
        private System.Windows.Forms.Button bWMP_play;
        private System.Windows.Forms.Button bWMP_pause;
        private System.Windows.Forms.Button bWMP_stop;
        private System.Windows.Forms.Button bWOW_play;
        private System.Windows.Forms.Button bWOW_stop;
        private System.Windows.Forms.Button bRecord;
        private System.Windows.Forms.Button bWOW_pause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.TextBox textBoxChanels;
        private System.Windows.Forms.TextBox textBoxSamples;
        private System.Windows.Forms.TextBox textBoxBits;
        private System.Windows.Forms.Button bRecordFiltered;
        private System.Windows.Forms.TextBox textBoxGenre;
        private System.Windows.Forms.TextBox textBoxAlbum;
        private System.Windows.Forms.TextBox textBoxArtist;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxDuration;
    }
}

