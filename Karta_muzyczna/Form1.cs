using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WMPLib;
using System.Runtime.InteropServices;
using SharpDX.DirectSound;
using SharpDX.Multimedia;
using System;
using System.IO;
using System.Windows.Forms;
using SharpDX;

namespace Karta_muzyczna
{
    public partial class Form1 : Form
    {
        // PlaySound()
        SoundPlayer player = null;

        // ActiveX
        WMPLib.WindowsMediaPlayer wmp = null;

        // WaveForm

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutOpen(out IntPtr hWaveOut, int uDeviceID, ref WaveFormat lpFormat, WaveOutProc dwCallback, IntPtr dwInstance, int dwFlags);

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutPrepareHeader(IntPtr hWaveOut, ref WaveHeader lpWaveOutHdr, int uSize);

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutWrite(IntPtr hWaveOut, ref WaveHeader lpWaveOutHdr, int uSize);

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutUnprepareHeader(IntPtr hWaveOut, ref WaveHeader lpWaveOutHdr, int uSize);

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutClose(IntPtr hWaveOut);

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutReset(IntPtr hWaveOut);

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutPause(IntPtr hWaveOut);

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutRestart(IntPtr hWaveOut);

        private delegate void WaveOutProc(IntPtr hwo, int uMsg, int dwInstance, int dwParam1, int dwParam2);

        [StructLayout(LayoutKind.Sequential)]
        private struct WaveFormat
        {
            public short wFormatTag;
            public short nChannels;
            public int nSamplesPerSec;
            public int nAvgBytesPerSec;
            public short nBlockAlign;
            public short wBitsPerSample;
            public short cbSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WaveHeader
        {
            public IntPtr lpData;
            public int dwBufferLength;
            public int dwBytesRecorded;
            public IntPtr dwUser;
            public int dwFlags;
            public int dwLoops;
            public IntPtr lpNext;
            public IntPtr reserved;
        }

        private IntPtr waveOutHandle = IntPtr.Zero;
        private WaveHeader waveHeader;
        private byte[] audioData;
        private GCHandle audioDataHandle;
        private bool isPlaying = false;
        private bool isPaused = false;


        // Direct Sound
        private DirectSound directSound;
        private SecondarySoundBuffer secondaryBuffer;


        // MCI
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);

        bool mci = false;

        // Recording
        private bool isRecording = false;


        public Form1()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------------

        private void bChooseFile_Click(object sender, EventArgs e)
        {
            // Okno dialogowe do wyboru pliku
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Ustawienia okna dialogowego
            openFileDialog.Title = "Wybierz plik";
            openFileDialog.Filter = "Muzyka(*.mp3;*.wav)|*.mp3; *.wav;";

            // Sprawdzamy, czy użytkownik wybrał plik i zatwierdził wybór
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Wyświetlenie ścieżki wybranego pliku w textBoxie
                txtFilePath.Text = openFileDialog.FileName;
            }

            // Zatrzymanie odtwarzania dzwieku, dla poprzedniego pliku dzwiekowego
            if(player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }

            if (wmp != null)
            {
                wmp.controls.stop();
                wmp = null;
            }

        }

        private void bPS_play_Click(object sender, EventArgs e)
        {
            if(txtFilePath.Text == string.Empty)
            {
                MessageBox.Show("Wybierz plik, aby moc go odtworzyc!", "Nie wybrano pliku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            player = new SoundPlayer(txtFilePath.Text);
           
            try
            {
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                player.Dispose();
            }
        }

        private void bPS_stop_Click(object sender, EventArgs e)
        {
            if(player!=null)
            {
                player.Stop();
                player.Dispose();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------

        private void bWMP_play_Click(object sender, EventArgs e)
        {
            if(txtFilePath.Text == string.Empty)
            {
                MessageBox.Show("Wybierz plik, aby moc go odtworzyc!", "Nie wybrano pliku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(wmp==null)
            {
                wmp = new WindowsMediaPlayer();
                wmp.URL = txtFilePath.Text;
            }
            
            wmp.controls.play();
        }


        private void bWMP_pause_Click(object sender, EventArgs e)
        {
            if(wmp!=null)
            {
                wmp.controls.pause();
            }
        }


        private void bWMP_stop_Click(object sender, EventArgs e)
        {
            if(wmp!=null)
            {
                wmp.controls.stop();
                wmp = null;
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------

        private void bWOW_play_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Wybierz plik, aby moc go odtworzyc!", "Nie wybrano pliku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isPaused && waveOutHandle != IntPtr.Zero)
            {
                // Jeśli jest wstrzymany, wznowienie odtwarzania
                waveOutRestart(waveOutHandle);
                isPaused = false;
                return;
            }

            try
            {
                audioData = File.ReadAllBytes(txtFilePath.Text);

                WaveFormat waveF = new WaveFormat();

                using (var reader = new BinaryReader(new FileStream(txtFilePath.Text, FileMode.Open)))
                {
                    reader.BaseStream.Seek(20, SeekOrigin.Begin);
                    short wFormatTag = reader.ReadInt16();  //Odczytywanie formatu dźwięku (pozycja 20) 2 bajty
                    short nChannels = reader.ReadInt16();   // Odczytanie liczby kanałów (pozycja 22)   2 bajty
                    int nSamplesPerSec = reader.ReadInt32();    //Odczytanie częstotliwości próbkowania (pozycja 24) 4 bajty
                    reader.BaseStream.Seek(34, SeekOrigin.Begin); // Przesunięcie do bitów na próbkę
                    short wBitsPerSample = reader.ReadInt16();  //Odczytanie liczby bitów na próbkę (pozycja 34) 2 bajty

                    waveF.wFormatTag = wFormatTag;
                    waveF.nChannels = nChannels;
                    waveF.nSamplesPerSec = nSamplesPerSec;
                    waveF.wBitsPerSample = wBitsPerSample;
                    waveF.nBlockAlign = (short)(nChannels * wBitsPerSample / 8);
                    waveF.nAvgBytesPerSec = nSamplesPerSec * nChannels * wBitsPerSample / 8;
                    waveF.cbSize = 0;
                }

                waveHeader = new WaveHeader
                {
                    dwBufferLength = audioData.Length,
                    dwFlags = 0,
                    dwLoops = 1
                };

                audioDataHandle = GCHandle.Alloc(audioData, GCHandleType.Pinned);
                waveHeader.lpData = audioDataHandle.AddrOfPinnedObject();

                int result = waveOutOpen(out waveOutHandle, -1, ref waveF, null, IntPtr.Zero, 0);
                if (result != 0)
                {
                    MessageBox.Show("Błąd podczas otwierania urządzenia audio: " + result);
                    return;
                }

                waveOutPrepareHeader(waveOutHandle, ref waveHeader, Marshal.SizeOf(waveHeader));
                result = waveOutWrite(waveOutHandle, ref waveHeader, Marshal.SizeOf(waveHeader));

                if (result != 0)
                {
                    MessageBox.Show("Błąd podczas odtwarzania dźwięku: " + result);
                }
                else
                {
                    isPlaying = true;
                    isPaused = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }


        private void bWOW_pause_Click(object sender, EventArgs e)
        {
            if (isPlaying && !isPaused)
            {
                waveOutPause(waveOutHandle); // Wstrzymuje odtwarzanie
                isPaused = true;
            }
        }


        private void bWOW_stop_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                waveOutReset(waveOutHandle); // Zatrzymuje odtwarzanie
                waveOutUnprepareHeader(waveOutHandle, ref waveHeader, Marshal.SizeOf(waveHeader));
                waveOutClose(waveOutHandle);

                if (audioDataHandle.IsAllocated)
                {
                    audioDataHandle.Free();
                }

                isPlaying = false;
                isPaused = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------

        private void InitializeDirectSound()
        {
            try
            {
                directSound = new DirectSound();
                directSound.SetCooperativeLevel(this.Handle, CooperativeLevel.Priority);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd inicjalizacji DirectSound: " + ex.Message);
            }
        }

        private void bDS_play_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Wybierz plik, aby moc go odtworzyc!", "Nie wybrano pliku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Upewnij się, że DirectSound jest zainicjalizowany
            if (directSound == null)
            {
                InitializeDirectSound();
                if (directSound == null)
                {
                    MessageBox.Show("Nie udało się zainicjalizować DirectSound.");
                    return;
                }
            }

            // Wczytaj plik audio i stwórz bufor dźwięku
            var waveFormat = new SharpDX.Multimedia.WaveFormat(44100, 16, 2); // 44.1 kHz, 16-bit, stereo

            var bufferDescription = new SoundBufferDescription
            {
                Flags = BufferFlags.ControlVolume,
                BufferBytes = (int)new FileInfo(txtFilePath.Text).Length,
                Format = waveFormat
            };

            // Inicjalizacja SecondarySoundBuffer
            try
            {
                secondaryBuffer = new SecondarySoundBuffer(directSound, bufferDescription);

                // Wczytaj dane audio i zapisz je do bufora
                using (var audioStream = new FileStream(txtFilePath.Text, FileMode.Open, FileAccess.Read))
                {
                    byte[] audioData = new byte[audioStream.Length];
                    audioStream.Read(audioData, 0, audioData.Length);
                    secondaryBuffer.Write(audioData, 0, LockFlags.None);
                }

                // Odtwórz dźwięk
                secondaryBuffer.Play(0, PlayFlags.Looping);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas odtwarzania dźwięku: " + ex.Message);
            }
        }

        private void bDS_stop_Click(object sender, EventArgs e)
        {
            if (secondaryBuffer != null)
            {
                secondaryBuffer.Stop();
                secondaryBuffer.Dispose();
                secondaryBuffer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------

        private void bMCI_play_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == string.Empty)
            {
                MessageBox.Show("Wybierz plik, aby moc go odtworzyc!", "Nie wybrano pliku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string command;

            if(mci)
            {
                command = "resume soundFile";
                mciSendString(command, null, 0, IntPtr.Zero);
                return;
            }
            
            command = $"open \"{txtFilePath.Text}\" type waveaudio alias soundFile";
            mciSendString(command, null, 0, IntPtr.Zero);

            // Odtworzenie dźwięku
            command = "play soundFile";
            mciSendString(command, null, 0, IntPtr.Zero);
            mci = true;
        }

        private void bMCI_pause_Click(object sender, EventArgs e)
        {
            if(mci)
            {
                string command = "pause soundFile";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }

        private void bMCI_stop_Click(object sender, EventArgs e)
        {
            if (mci)
            {
                string command = "close soundFile";
                mciSendString(command, null, 0, IntPtr.Zero);
                mci = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------

        private void bRecord_Click(object sender, EventArgs e)
        {
            string command = null;

            if(!isRecording)
            {
                // Zmień wygląd przycisku na wciśnięty
                bRecord.BackColor = Color.Red;
                isRecording = true;

                // Rozpocznij nagrywanie
                command = "open new type waveaudio alias mic";
                mciSendString(command, null, 0, IntPtr.Zero);

                command = "set mic channels 2 samplespersec 44100 bitspersample 16";
                mciSendString(command, null, 0, IntPtr.Zero);

                command = "record mic";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
            else
            {
                // Zmień wygląd przycisku na odciśnięty
                bRecord.BackColor = Color.White;
                isRecording = false;

                // Zatrzymaj nagrywanie i zapisz plik
                command = "stop mic";
                mciSendString(command, null, 0, IntPtr.Zero);

                // Otwórz okno dialogowe zapisu pliku
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Zapisz nagranie jako";
                    saveFileDialog.Filter = "Pliki WAV (*.wav)|*.wav";
                    saveFileDialog.DefaultExt = "wav";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Zapisz nagrany plik dźwiękowy na wybraną ścieżkę
                        command = $"save mic \"{saveFileDialog.FileName}\"";
                        mciSendString(command, null, 0, IntPtr.Zero);
                    }
                }

                command = "close mic";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------

    }
}
