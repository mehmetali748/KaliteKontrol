using DevExpress.XtraPrinting.Native.WebClientUIControl;
using Newtonsoft.Json;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using OpenCvSharp.Extensions;


namespace QualityControl.UI
{
    public partial class MaİnForm : Form
    {
        private VideoCapture _capture;
        
        private List<Mat>[] _samples;
        private Bitmap _currentFrameBmp;
        private bool _isCapturing = false;
        private string _baseDir;

        public MaİnForm()
        {
            InitializeComponent();
            AppendLog("[INFO] Çalışma dizini: " + AppDomain.CurrentDomain.BaseDirectory);
            InitializeDirectories();
            SetupClassControls();
        }

        private void InitializeDirectories()
        {
            try
            {
                // Belgelerim altında QualityControlData/Trainer/live_dataset
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                _baseDir = Path.Combine(documents, "QualityControlData", "Trainer", "live_dataset");
                AppendLog("[INFO] Kayıt dizini: " + _baseDir);
                if (!Directory.Exists(_baseDir))
                {
                    Directory.CreateDirectory(_baseDir);
                    AppendLog($"[INFO] Ana klasör oluşturuldu: {_baseDir}");
                }
            }
            catch (Exception ex)
            {
                AppendLog($"[ERR] Klasör oluşturma hatası: {ex.Message}");
                MessageBox.Show("Klasör oluşturma hatası!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupClassControls()
        {
            cmbClassCount.Items.AddRange(new object[] { "2", "3" });
            cmbClassCount.SelectedIndex = 0;
            cmbClassCount.SelectedIndexChanged += (s, e) =>
            {
                GenerateSampleControls(int.Parse(cmbClassCount.SelectedItem.ToString()));
            };
            GenerateSampleControls(2);

            btnStartCam.Click += btnStartCam_Click;
            btnStopCam.Click += btnStopCam_Click;
            btnTrain.Click += btnTrain_Click;
        }

        private void GenerateSampleControls(int classCount)
        {
            try
            {
                panelSampleControls.Controls.Clear();
                _samples = new List<Mat>[classCount];

                for (int i = 0; i < classCount; i++)
                {
                    _samples[i] = new List<Mat>();

                    var txt = new TextBox
                    {
                        Name = $"txtClassName_{i}",
                        Text = $"Sınıf{i + 1}",
                        Location = new System.Drawing.Point(0, i * 40),
                        Width = 120
                    };

                    var btn = new Button
                    {
                        Name = $"btnCapture_{i}",
                        Text = "Örnek Yakala",
                        Location = new System.Drawing.Point(130, i * 40),
                        Tag = i
                    };
                    btn.Click += btnCapture_i_Click;

                    var lbl = new Label
                    {
                        Name = $"lblCount_{i}",
                        Text = "Toplanan: 0",
                        Location = new System.Drawing.Point(250, i * 40 + 3),
                        AutoSize = true
                    };

                    panelSampleControls.Controls.Add(txt);
                    panelSampleControls.Controls.Add(btn);
                    panelSampleControls.Controls.Add(lbl);
                }
            }
            catch (Exception ex)
            {
                AppendLog($"[ERR] Kontrol oluşturma hatası: {ex.Message}");
            }
        }
        





        private void MaİnForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStartCam_Click(object sender, EventArgs e)
        {
            try
            {
                if (_capture != null)
                {
                    _capture.Release();
                    _capture = null;
                }

                _capture = new VideoCapture();
                if (!_capture.Open(0))
                {
                    MessageBox.Show("Kamera açılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrameTimer = new Timer { Interval = 33 };
                FrameTimer.Tick += FrameTimer_Tick;
                FrameTimer.Start();
                _isCapturing = true;
                AppendLog("[INFO] Kamera başlatıldı");
            }
            catch (Exception ex)
            {
                AppendLog($"[ERR] Kamera başlatma hatası: {ex.Message}");
                MessageBox.Show("Kamera başlatma hatası!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_capture == null || !_capture.IsOpened())
                    return;

                using (var mat = new Mat())
                {
                    if (!_capture.Read(mat) || mat.Empty())
                        return;

                    pictureBoxPreview.Image?.Dispose();
                    _currentFrameBmp?.Dispose();
                    _currentFrameBmp = mat.ToBitmap();
                    pictureBoxPreview.Image = _currentFrameBmp;
                }
            }
            catch (Exception ex)
            {
                AppendLog($"[ERR] Frame yakalama hatası: {ex.Message}");
                _isCapturing = false;
                FrameTimer?.Stop();
            }
        }

        private void btnCapture_i_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isCapturing || _currentFrameBmp == null)
                {
                    MessageBox.Show("Lütfen önce kamerayı başlatın!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idx = (int)((Button)sender).Tag;
                using (var mat = BitmapConverter.ToMat(_currentFrameBmp))
                {
                    _samples[idx].Add(mat.Clone());
                }

                var lbl = panelSampleControls.Controls
                    .OfType<Label>()
                    .First(l => l.Name == $"lblCount_{idx}");
                lbl.Text = $"Toplanan: {_samples[idx].Count}";
                AppendLog($"[INFO] Örnek yakalandı: Sınıf {idx}, Toplam: {_samples[idx].Count}");
            }
            catch (Exception ex)
            {
                AppendLog($"[ERR] Örnek yakalama hatası: {ex.Message}");
            }
        }

        private void btnStopCam_Click(object sender, EventArgs e)
        {
            try
            {
                _isCapturing = false;
                FrameTimer?.Stop();
                _capture?.Release();
                _capture = null;
                pictureBoxPreview.Image?.Dispose();
                pictureBoxPreview.Image = null;
                AppendLog("[INFO] Kamera durduruldu");
            }
            catch (Exception ex)
            {
                AppendLog($"[ERR] Kamera durdurma hatası: {ex.Message}");
            }
        }

       
        private void SaveLiveSamplesToDisk()
        {
            try
            {
                // Ensure _baseDir is set to the user's Documents folder
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                _baseDir = Path.Combine(documents, "QualityControlData", "Trainer", "live_dataset");
                AppendLog($"[INFO] Kayıt dizini: {_baseDir}");

                if (!Directory.Exists(_baseDir))
                {
                    Directory.CreateDirectory(_baseDir);
                    AppendLog($"[INFO] Ana klasör oluşturuldu: {_baseDir}");
                }

                int totalSaved = 0;
                for (int i = 0; i < _samples.Length; i++)
                {
                    if (_samples[i].Count == 0) continue;

                    // Sınıf ismini textbox'tan al
                    var txt = panelSampleControls.Controls
                        .OfType<TextBox>()
                        .First(t => t.Name == $"txtClassName_{i}");
                    string className = txt.Text.Trim();
                    if (string.IsNullOrWhiteSpace(className))
                        className = $"class_{i}"; // Yedek olarak

                    var classDir = Path.Combine(_baseDir, className);
                    if (!Directory.Exists(classDir))
                    {
                        Directory.CreateDirectory(classDir);
                        AppendLog($"[INFO] Sınıf klasörü oluşturuldu: {classDir}");
                    }

                    int classSaved = 0;
                    for (int j = 0; j < _samples[i].Count; j++)
                    {
                        var filePath = Path.Combine(classDir, $"{j:0000}.png");
                        try
                        {
                            AppendLog($"[DBG] Kaydedilecek dosya yolu: {filePath}");
                            _samples[i][j].SaveImage(filePath);
                            if (File.Exists(filePath))
                            {
                                AppendLog($"[INFO] Kaydedildi: {filePath}");
                                classSaved++;
                                totalSaved++;
                            }
                            else
                            {
                                AppendLog($"[ERR] Dosya oluşturulamadı: {filePath}");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppendLog($"[ERR] SaveImage Exception: {ex.Message}");
                        }
                    }
                    AppendLog($"[INFO] Sınıf {i} için {classSaved} dosya kaydedildi");
                }

                if (totalSaved == 0)
                {
                    throw new Exception("Hiç örnek kaydedilmedi!");
                }

                AppendLog($"[INFO] Toplam {totalSaved} örnek kaydedildi");
            }
            catch (Exception ex)
            {
                AppendLog($"[ERR] Kayıt hatası: {ex.Message}");
                throw;
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Örnekleri kaydet
                SaveLiveSamplesToDisk();

                // 2) Python script yolunu hazırla
                var scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Trainer", "train_model.py");
                if (!File.Exists(scriptPath))
                {
                    throw new Exception($"train_model.py bulunamadı: {scriptPath}");
                }

                // 3) Python exe yolunu hazırla
                var pythonExe = @"C:\Users\malib\source\repos\QualityControl\python_env\venv310\Scripts\python.exe";
                if (!File.Exists(pythonExe))
                {
                    throw new Exception($"python.exe bulunamadı: {pythonExe}");
                }
                // 3.a) Sınıf isimlerini topla:
                var classNames = panelSampleControls.Controls
                    .OfType<TextBox>()
                    .Select(t => t.Text.Trim())
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .ToArray();
                // 3.b) Virgülle ayır ve değişkene ata:
                string usedClasses = string.Join(",", classNames);

                // 4) Argümanları hazırla, artık usedClasses var:
                var args = string.Join(" ",
                    $"\"{scriptPath}\"",
                    $"--classes \"{_baseDir}\"",
                    $"--epochs {nudEpoch.Value}",
                    $"--batch_size {nudBatchSize.Value}",
                    $"--img_size 224",
                    $"--model_prefix \"{string.Join("_", classNames)}\"",
                    $"--used_classes \"{usedClasses}\""
                );
                //// Sınıf isimlerini topla ve birleştir
                //var classNames = panelSampleControls.Controls
                //    .OfType<TextBox>()
                //    .Select(t => t.Text.Trim())
                //    .Where(t => !string.IsNullOrWhiteSpace(t))
                //    .ToArray();
                //var classNamesConcat = string.Join("", classNames);

                //// 4) Argümanları hazırla
                //var args = string.Join(" ",
                //    $"\"{scriptPath}\"",
                //    $"--classes \"{_baseDir}\"",
                //    $"--epochs {nudEpoch.Value}",
                //    $"--batch_size {nudBatchSize.Value}",
                //    $"--img_size 224",
                //    $"--model_prefix \"{classNamesConcat}\"",
                //    $"--used_classes \"{usedClasses}\""
                //);
                AppendLog($"[DEBUG] Python args: {args}");

                // 5) Process'i başlat
                var psi = new ProcessStartInfo
                {
                    FileName = pythonExe,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = Path.GetDirectoryName(scriptPath)
                };

                // 6) UI'ı güncelle
                progressBarTrain.Style = ProgressBarStyle.Marquee;
                btnTrain.Enabled = false;
                txtLog.Clear();

                var proc = Process.Start(psi);
                if (proc == null)
                {
                    throw new Exception("Python süreci başlatılamadı");
                }

                proc.OutputDataReceived += (s, ev) => { if (ev.Data != null) AppendLog(ev.Data); };
                proc.ErrorDataReceived += (s, ev) => { if (ev.Data != null) AppendLog("[ERR] " + ev.Data); };

                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();

                if (proc.ExitCode != 0)
                {
                    // Hata varsa train_log.txt dosyasının son 20 satırını oku ve loga ekle
                    var logPath = Path.Combine(_baseDir, "train_log.txt");
                    if (File.Exists(logPath))
                    {
                        var allLines = File.ReadAllLines(logPath);
                        AppendLog("[ERR] --- train_log.txt (son 20 satır) ---");
                        foreach (var line in allLines.Skip(Math.Max(0, allLines.Length - 20)))
                            AppendLog(line);
                        AppendLog("[ERR] --- train_log.txt sonu ---");
                    }
                    else
                    {
                        AppendLog("[ERR] train_log.txt dosyası bulunamadı.");
                    }
                    throw new Exception($"Python scripti hata ile sonlandı (ExitCode: {proc.ExitCode})");
                }

                MessageBox.Show("Eğitim tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AppendLog($"[ERR] Eğitim hatası: {ex.Message}");
                MessageBox.Show($"Eğitim sırasında hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBarTrain.Style = ProgressBarStyle.Blocks;
                btnTrain.Enabled = true;
            }
        }



        /// <summary>
        /// Herhangi bir thread'den çağrılsa bile güvenli bir şekilde
        /// txtLog'a satır satır metin ekler.
        /// </summary>
        private void AppendLog(string text)
        {
            if (this.IsDisposed || !this.IsHandleCreated || txtLog.IsDisposed)
                return;

            // Logu dosyaya da yaz
            try
            {
                File.AppendAllText("ui_debug_log.txt", text + Environment.NewLine);
            }
            catch { }

            if (this.InvokeRequired)
            {
                try { this.BeginInvoke(new Action<string>(AppendLog), text); }
                catch { }
                return;
            }

            txtLog.AppendText(text + Environment.NewLine);
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }
    }

}

