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
using System.IO;
using System.Linq;

namespace Karta_muzyczna
{
    public partial class Form1 : Form
    {

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


        // Nagrywanie (MCI)
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);

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
            openFileDialog.Filter = "Audio(*.mp3;*.wav)|*.mp3; *.wav;";

            // Sprawdzamy, czy użytkownik wybrał plik i zatwierdził wybór
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Wyświetlenie ścieżki wybranego pliku w textBoxie
                txtFilePath.Text = openFileDialog.FileName;
            }

            // Zatrzymanie odtwarzania dzwieku, dla poprzedniego pliku dzwiekowego

            // Windows Media Player
            if (wmp != null)
            {
                wmp.controls.stop();
                wmp = null;
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
            
            try
            {
                wmp.controls.play();

                // Odczyt naglowka MP3
                var file = TagLib.File.Create(txtFilePath.Text);

                textBoxTitle.Text = $"{file.Tag.Title ?? "Unknown"}";
                textBoxArtist.Text = $"{file.Tag.Performers.FirstOrDefault() ?? "Unknown"}";
                textBoxAlbum.Text = $"{file.Tag.Album ?? "Unknown"}";
                textBoxGenre.Text = $"{file.Tag.Genres.FirstOrDefault() ?? "Unknown"}";
                textBoxDuration.Text = $"{file.Properties.Duration}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading MP3 metadata: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                    short wFormatTag = reader.ReadInt16();  // Odczytywanie formatu dźwięku (pozycja 20) 2 bajty
                    short nChannels = reader.ReadInt16();   // Odczytanie liczby kanałów (pozycja 22) 2 bajty
                    int nSamplesPerSec = reader.ReadInt32();    // Odczytanie częstotliwości próbkowania (pozycja 24) 4 bajty
                    reader.BaseStream.Seek(34, SeekOrigin.Begin); // Przesunięcie do bitów na próbkę
                    short wBitsPerSample = reader.ReadInt16();  // Odczytanie liczby bitów na próbkę (pozycja 34) 2 bajty

                    waveF.wFormatTag = wFormatTag;
                    waveF.nChannels = nChannels;
                    waveF.nSamplesPerSec = nSamplesPerSec;
                    waveF.wBitsPerSample = wBitsPerSample;
                    waveF.nBlockAlign = (short)(nChannels * wBitsPerSample / 8);
                    waveF.nAvgBytesPerSec = nSamplesPerSec * nChannels * wBitsPerSample / 8;
                    waveF.cbSize = 0;

                    // Wyświetlanie odczytanych pól nagłówka WAV
                    textBoxTag.Text = wFormatTag.ToString();
                    textBoxChanels.Text = nChannels.ToString();
                    textBoxSamples.Text = nSamplesPerSec.ToString();
                    textBoxBits.Text = wBitsPerSample.ToString();
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

        private void bRecord_Click(object sender, EventArgs e)
        {
            record(false);
        }

        private void bRecordFiltered_Click(object sender, EventArgs e)
        {
            record(true);
        }

        private void record(bool isFiltered)
        {
            string command = null;

            if (!isRecording)
            {
                // Zmień wygląd przycisku na wciśnięty
                if(isFiltered) bRecordFiltered.BackColor = Color.Red;
                else bRecord.BackColor = Color.Red;
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
                if(isFiltered) bRecordFiltered.BackColor = Color.White;
                else bRecord.BackColor = Color.White;
                isRecording = false;

                // Zatrzymaj nagrywanie i zapisz plik
                command = "stop mic";
                mciSendString(command, null, 0, IntPtr.Zero);

                string savedFilePath = null;

                // Otwórz okno dialogowe zapisu pliku
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Zapisz nagranie jako";
                    saveFileDialog.Filter = "Pliki WAV (*.wav)|*.wav";
                    saveFileDialog.DefaultExt = "wav";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Zapisz nagrany plik dźwiękowy na wybraną ścieżkę
                        savedFilePath = saveFileDialog.FileName;
                        command = $"save mic \"{savedFilePath}\"";
                        mciSendString(command, null, 0, IntPtr.Zero);
                    }
                }

                command = "close mic";
                mciSendString(command, null, 0, IntPtr.Zero);

                if (isFiltered)
                {
                    // Zastosowanie filtru dla nagrania
                    if (!string.IsNullOrEmpty(savedFilePath))
                    {
                        string filteredFilePath = Path.Combine(
                            Path.GetDirectoryName(savedFilePath),
                            Path.GetFileNameWithoutExtension(savedFilePath) + "_filtered.wav"
                        );

                        ApplyDeadenFilter(savedFilePath, filteredFilePath);

                        MessageBox.Show($"Nagranie z filtrem zapisane jako:\n{filteredFilePath}", "Filtr zastosowany", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

      
        private void ApplyDeadenFilter(string inputFilePath, string outputFilePath)
        {
            try
            {
                using (var reader = new WaveFileReader(inputFilePath))
                {
                    NAudio.Wave.WaveFormat format = reader.WaveFormat;

                    using (var writer = new WaveFileWriter(outputFilePath, format))
                    {
                        int bytesPerSample = format.BitsPerSample / 8;
                        byte[] buffer = new byte[reader.WaveFormat.BlockAlign];
                        int bytesRead;

                        while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            for (int i = 0; i < bytesRead; i += bytesPerSample)
                            {
                                short sample = BitConverter.ToInt16(buffer, i);

                                // Skalowanie amplitudy - tlumienie dzwieku
                                sample = (short)(sample * 0.2); // Tlumienie o 80%

                                // Zapisanie zmodyfikowanego dzwieku do bufora
                                byte[] processedSample = BitConverter.GetBytes(sample);
                                buffer[i] = processedSample[0];
                                buffer[i + 1] = processedSample[1];
                            }

                            // Zapis z bufora do pliku wyjsciowego
                            writer.Write(buffer, 0, bytesRead);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystapil blad podczas nakladania filtru na nagranie audio: {ex.Message}", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------

    }
}
