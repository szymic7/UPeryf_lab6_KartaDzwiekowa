using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.Runtime.InteropServices;
using SharpDX.DirectSound;
using NAudio.Wave;

namespace Karta_muzyczna
{
    public partial class Form1 : Form
    {
        // PlaySound()
        SoundPlayer soundPlayer = null;

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
        bool isPausedDS = false;
        int pausedPosition = 0;


        // MCI
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);

        bool mci = false;

        // Recording
        private bool isRecording = false;


        public Form1()
        {
            InitializeComponent();
            InitializeDirectSound();
        }

        //------------------------------------------------------------------------------------------------------------------------------

        private void bChooseFile_Click(object sender, EventArgs e)
        {
            // Okno dialogowe do wyboru pliku
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Ustawienia okna dialogowego
            openFileDialog.Title = "Wybierz plik";
            openFileDialog.Filter = "Audio(*.mp3;*.wav)|*.mp3; *.wav;";

            // Sprawdzamy, czy użytkownik wybrał plik i zatwierdził wybór
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Wyświetlenie ścieżki wybranego pliku w textBoxie
                txtFilePath.Text = openFileDialog.FileName;
            }

            // Zatrzymanie odtwarzania dzwieku, dla poprzedniego pliku dzwiekowego
            // PlaySound()
            if(soundPlayer != null)
            {
                soundPlayer.Stop();
                soundPlayer.Dispose();
                soundPlayer = null;
            }

            // Windows Media Player
            if (wmp != null)
            {
                wmp.controls.stop();
                wmp = null;
            }

            // DirectSound
            if(directSound != null)
            {
                if (secondaryBuffer != null)
                {
                    secondaryBuffer.Stop();
                    secondaryBuffer.Dispose();
                    secondaryBuffer = null;
                }
            }

            // WaveOutWrite
            if(isPlaying)
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

        private void bPS_play_Click(object sender, EventArgs e)
        {
            if(txtFilePath.Text == string.Empty)
            {
                MessageBox.Show("Wybierz plik, aby moc go odtworzyc!", "Nie wybrano pliku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            soundPlayer = new SoundPlayer(txtFilePath.Text);
           
            try
            {
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                soundPlayer.Dispose();
            }
        }

        private void bPS_stop_Click(object sender, EventArgs e)
        {
            if(soundPlayer!=null)
            {
                soundPlayer.Stop();
                soundPlayer.Dispose();
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
                wmp.close();
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

            // Jesli nie udalo sie zainicjalizowac DirectSound
            if (directSound == null)
            {
                InitializeDirectSound();
                if (directSound == null)
                {
                    MessageBox.Show("Nie udało się zainicjalizować DirectSound.");
                    return;
                }
            }

            try
            {
                // Plik jest juz odtwarzany i nie zostal zatrzymany
                if (secondaryBuffer != null && !isPausedDS)
                {
                    return;
                }

                // Plik zostal zatrzymany - nastepuje wznowienie
                if(isPausedDS)
                {
                    secondaryBuffer.CurrentPosition = pausedPosition;
                    secondaryBuffer.Play(0, PlayFlags.Looping);
                }
                else // Plik nie zostal jeszcze uruchomiony
                {
                    // Odczytanie parametrow pliku WAV
                    using (var audioReader = new WaveFileReader(txtFilePath.Text))
                    {
                        var waveFormat = new SharpDX.Multimedia.WaveFormat(
                            audioReader.WaveFormat.SampleRate,
                            audioReader.WaveFormat.BitsPerSample,
                            audioReader.WaveFormat.Channels
                        );

                        var bufferDescription = new SoundBufferDescription
                        {
                            Flags = BufferFlags.ControlVolume,
                            BufferBytes = (int)audioReader.Length,
                            Format = waveFormat
                        };

                        // Inicjalizacja SecondarySoundBuffer
                        secondaryBuffer = new SecondarySoundBuffer(directSound, bufferDescription);

                        // Wczytaj dane audio i zapisz je do bufora
                        byte[] audioData = new byte[audioReader.Length];
                        audioReader.Read(audioData, 0, audioData.Length);
                        secondaryBuffer.Write(audioData, 0, LockFlags.None);

                        // Odtwórz dźwięk
                        secondaryBuffer.Play(0, PlayFlags.Looping);
                    }
                }

                isPausedDS = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas odtwarzania dźwięku: " + ex.Message);
            }
        }

        private void bDS_pause_Click(object sender, EventArgs e)
        {
            if (secondaryBuffer != null && !isPausedDS)
            {
                // Declare variables for the output of GetCurrentPosition
                int playCursor;
                int writeCursor;

                // Pause: Get the current play position
                secondaryBuffer.GetCurrentPosition(out playCursor, out writeCursor);
                pausedPosition = playCursor;

                secondaryBuffer.Stop();
                isPausedDS = true; // Mark as paused if you want to track it
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
