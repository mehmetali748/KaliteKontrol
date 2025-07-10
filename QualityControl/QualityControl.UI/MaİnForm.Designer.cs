namespace QualityControl.UI
{
    partial class MaİnForm
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabTraining = new System.Windows.Forms.TabPage();
            this.flowLayoutClasses = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudScale = new System.Windows.Forms.NumericUpDown();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudLr = new System.Windows.Forms.NumericUpDown();
            this.nudEpoch = new System.Windows.Forms.NumericUpDown();
            this.nudBatchSize = new System.Windows.Forms.NumericUpDown();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBarTrain = new System.Windows.Forms.ProgressBar();
            this.btnTrain = new System.Windows.Forms.Button();
            this.panelSampleControls = new System.Windows.Forms.Panel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.btnStopCam = new System.Windows.Forms.Button();
            this.btnStartCam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClassCount = new System.Windows.Forms.ComboBox();
            this.inferans = new System.Windows.Forms.TabPage();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.btnInfer = new System.Windows.Forms.Button();
            this.pictureBoxInput = new System.Windows.Forms.PictureBox();
            this.plc_ayar = new System.Windows.Forms.TabPage();
            this.lblPlcStatus = new System.Windows.Forms.Label();
            this.btnPlcConnect = new System.Windows.Forms.Button();
            this.nudPlcUnit = new System.Windows.Forms.NumericUpDown();
            this.nudPlcPort = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPlcIp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.kamera_ayar = new System.Windows.Forms.TabPage();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.btnApplyCam = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.cmbCameras = new System.Windows.Forms.ComboBox();
            this.FrameTimer = new System.Windows.Forms.Timer(this.components);
            this.tabMain.SuspendLayout();
            this.tabTraining.SuspendLayout();
            this.flowLayoutClasses.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEpoch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBatchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.inferans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).BeginInit();
            this.plc_ayar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlcUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlcPort)).BeginInit();
            this.kamera_ayar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabTraining);
            this.tabMain.Controls.Add(this.inferans);
            this.tabMain.Controls.Add(this.plc_ayar);
            this.tabMain.Controls.Add(this.kamera_ayar);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(984, 661);
            this.tabMain.TabIndex = 0;
            // 
            // tabTraining
            // 
            this.tabTraining.Controls.Add(this.flowLayoutClasses);
            this.tabTraining.Controls.Add(this.txtLog);
            this.tabTraining.Controls.Add(this.progressBarTrain);
            this.tabTraining.Controls.Add(this.btnTrain);
            this.tabTraining.Controls.Add(this.panelSampleControls);
            this.tabTraining.Controls.Add(this.pictureBoxPreview);
            this.tabTraining.Controls.Add(this.btnStopCam);
            this.tabTraining.Controls.Add(this.btnStartCam);
            this.tabTraining.Controls.Add(this.label1);
            this.tabTraining.Controls.Add(this.cmbClassCount);
            this.tabTraining.Location = new System.Drawing.Point(4, 22);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Padding = new System.Windows.Forms.Padding(3);
            this.tabTraining.Size = new System.Drawing.Size(976, 635);
            this.tabTraining.TabIndex = 0;
            this.tabTraining.Text = "Eğitim";
            this.tabTraining.UseVisualStyleBackColor = true;
            // 
            // flowLayoutClasses
            // 
            this.flowLayoutClasses.AutoScroll = true;
            this.flowLayoutClasses.Controls.Add(this.groupBox1);
            this.flowLayoutClasses.Controls.Add(this.groupBox2);
            this.flowLayoutClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutClasses.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutClasses.Name = "flowLayoutClasses";
            this.flowLayoutClasses.Size = new System.Drawing.Size(970, 180);
            this.flowLayoutClasses.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudScale);
            this.groupBox1.Controls.Add(this.nudMin);
            this.groupBox1.Controls.Add(this.nudMax);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boyut Bilgisi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Scale:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Max:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Min:";
            // 
            // nudScale
            // 
            this.nudScale.DecimalPlaces = 4;
            this.nudScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudScale.Location = new System.Drawing.Point(159, 98);
            this.nudScale.Name = "nudScale";
            this.nudScale.Size = new System.Drawing.Size(120, 20);
            this.nudScale.TabIndex = 15;
            // 
            // nudMin
            // 
            this.nudMin.Location = new System.Drawing.Point(159, 19);
            this.nudMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(120, 20);
            this.nudMin.TabIndex = 13;
            // 
            // nudMax
            // 
            this.nudMax.Location = new System.Drawing.Point(159, 57);
            this.nudMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(120, 20);
            this.nudMax.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.nudLr);
            this.groupBox2.Controls.Add(this.nudEpoch);
            this.groupBox2.Controls.Add(this.nudBatchSize);
            this.groupBox2.Location = new System.Drawing.Point(479, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 170);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eğitim Parametreleri";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Learn:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(95, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Bach Size:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(112, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Epoch:";
            // 
            // nudLr
            // 
            this.nudLr.DecimalPlaces = 5;
            this.nudLr.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudLr.Location = new System.Drawing.Point(159, 98);
            this.nudLr.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.nudLr.Name = "nudLr";
            this.nudLr.Size = new System.Drawing.Size(120, 20);
            this.nudLr.TabIndex = 15;
            this.nudLr.Value = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            // 
            // nudEpoch
            // 
            this.nudEpoch.Location = new System.Drawing.Point(159, 19);
            this.nudEpoch.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudEpoch.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEpoch.Name = "nudEpoch";
            this.nudEpoch.Size = new System.Drawing.Size(120, 20);
            this.nudEpoch.TabIndex = 13;
            this.nudEpoch.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudBatchSize
            // 
            this.nudBatchSize.Location = new System.Drawing.Point(159, 57);
            this.nudBatchSize.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nudBatchSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBatchSize.Name = "nudBatchSize";
            this.nudBatchSize.Size = new System.Drawing.Size(120, 20);
            this.nudBatchSize.TabIndex = 14;
            this.nudBatchSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(500, 231);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(452, 20);
            this.txtLog.TabIndex = 12;
            // 
            // progressBarTrain
            // 
            this.progressBarTrain.Location = new System.Drawing.Point(89, 228);
            this.progressBarTrain.Name = "progressBarTrain";
            this.progressBarTrain.Size = new System.Drawing.Size(405, 23);
            this.progressBarTrain.TabIndex = 11;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(8, 228);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 10;
            this.btnTrain.Text = "Modeli Eğit";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // panelSampleControls
            // 
            this.panelSampleControls.Location = new System.Drawing.Point(498, 358);
            this.panelSampleControls.Name = "panelSampleControls";
            this.panelSampleControls.Size = new System.Drawing.Size(470, 240);
            this.panelSampleControls.TabIndex = 9;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(6, 358);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(470, 240);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 4;
            this.pictureBoxPreview.TabStop = false;
            // 
            // btnStopCam
            // 
            this.btnStopCam.Location = new System.Drawing.Point(110, 604);
            this.btnStopCam.Name = "btnStopCam";
            this.btnStopCam.Size = new System.Drawing.Size(101, 23);
            this.btnStopCam.TabIndex = 3;
            this.btnStopCam.Text = "Kamera Durdur";
            this.btnStopCam.UseVisualStyleBackColor = true;
            this.btnStopCam.Click += new System.EventHandler(this.btnStopCam_Click);
            // 
            // btnStartCam
            // 
            this.btnStartCam.Location = new System.Drawing.Point(3, 604);
            this.btnStartCam.Name = "btnStartCam";
            this.btnStartCam.Size = new System.Drawing.Size(101, 23);
            this.btnStartCam.TabIndex = 2;
            this.btnStartCam.Text = "Kamera Başlat";
            this.btnStartCam.UseVisualStyleBackColor = true;
            this.btnStartCam.Click += new System.EventHandler(this.btnStartCam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sınıf Sayısı:";
            // 
            // cmbClassCount
            // 
            this.cmbClassCount.DisplayMember = "2";
            this.cmbClassCount.FormattingEnabled = true;
            this.cmbClassCount.Items.AddRange(new object[] {
            "2",
            "3"});
            this.cmbClassCount.Location = new System.Drawing.Point(74, 329);
            this.cmbClassCount.Name = "cmbClassCount";
            this.cmbClassCount.Size = new System.Drawing.Size(121, 21);
            this.cmbClassCount.TabIndex = 0;
            this.cmbClassCount.ValueMember = "0";
            // 
            // inferans
            // 
            this.inferans.Controls.Add(this.listBoxResults);
            this.inferans.Controls.Add(this.btnInfer);
            this.inferans.Controls.Add(this.pictureBoxInput);
            this.inferans.Location = new System.Drawing.Point(4, 22);
            this.inferans.Name = "inferans";
            this.inferans.Padding = new System.Windows.Forms.Padding(3);
            this.inferans.Size = new System.Drawing.Size(976, 635);
            this.inferans.TabIndex = 1;
            this.inferans.Text = "İnferans";
            this.inferans.UseVisualStyleBackColor = true;
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(420, 50);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(550, 251);
            this.listBoxResults.TabIndex = 2;
            // 
            // btnInfer
            // 
            this.btnInfer.Location = new System.Drawing.Point(420, 10);
            this.btnInfer.Name = "btnInfer";
            this.btnInfer.Size = new System.Drawing.Size(95, 35);
            this.btnInfer.TabIndex = 1;
            this.btnInfer.Text = "Tahmin Et";
            this.btnInfer.UseVisualStyleBackColor = true;
            // 
            // pictureBoxInput
            // 
            this.pictureBoxInput.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxInput.Name = "pictureBoxInput";
            this.pictureBoxInput.Size = new System.Drawing.Size(400, 300);
            this.pictureBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxInput.TabIndex = 0;
            this.pictureBoxInput.TabStop = false;
            // 
            // plc_ayar
            // 
            this.plc_ayar.Controls.Add(this.lblPlcStatus);
            this.plc_ayar.Controls.Add(this.btnPlcConnect);
            this.plc_ayar.Controls.Add(this.nudPlcUnit);
            this.plc_ayar.Controls.Add(this.nudPlcPort);
            this.plc_ayar.Controls.Add(this.label9);
            this.plc_ayar.Controls.Add(this.label8);
            this.plc_ayar.Controls.Add(this.txtPlcIp);
            this.plc_ayar.Controls.Add(this.label7);
            this.plc_ayar.Location = new System.Drawing.Point(4, 22);
            this.plc_ayar.Name = "plc_ayar";
            this.plc_ayar.Padding = new System.Windows.Forms.Padding(3);
            this.plc_ayar.Size = new System.Drawing.Size(976, 635);
            this.plc_ayar.TabIndex = 2;
            this.plc_ayar.Text = "PLC Ayarları";
            this.plc_ayar.UseVisualStyleBackColor = true;
            // 
            // lblPlcStatus
            // 
            this.lblPlcStatus.AutoSize = true;
            this.lblPlcStatus.Location = new System.Drawing.Point(120, 125);
            this.lblPlcStatus.Name = "lblPlcStatus";
            this.lblPlcStatus.Size = new System.Drawing.Size(97, 13);
            this.lblPlcStatus.TabIndex = 7;
            this.lblPlcStatus.Text = "Durum: Beklemede";
            // 
            // btnPlcConnect
            // 
            this.btnPlcConnect.Location = new System.Drawing.Point(10, 120);
            this.btnPlcConnect.Name = "btnPlcConnect";
            this.btnPlcConnect.Size = new System.Drawing.Size(75, 23);
            this.btnPlcConnect.TabIndex = 6;
            this.btnPlcConnect.Text = "Bağlan";
            this.btnPlcConnect.UseVisualStyleBackColor = true;
            // 
            // nudPlcUnit
            // 
            this.nudPlcUnit.Location = new System.Drawing.Point(57, 92);
            this.nudPlcUnit.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.nudPlcUnit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlcUnit.Name = "nudPlcUnit";
            this.nudPlcUnit.Size = new System.Drawing.Size(120, 20);
            this.nudPlcUnit.TabIndex = 5;
            this.nudPlcUnit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPlcPort
            // 
            this.nudPlcPort.Location = new System.Drawing.Point(57, 61);
            this.nudPlcPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPlcPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlcPort.Name = "nudPlcPort";
            this.nudPlcPort.Size = new System.Drawing.Size(120, 20);
            this.nudPlcPort.TabIndex = 4;
            this.nudPlcPort.Value = new decimal(new int[] {
            502,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Unit ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Port:";
            // 
            // txtPlcIp
            // 
            this.txtPlcIp.Location = new System.Drawing.Point(57, 35);
            this.txtPlcIp.Name = "txtPlcIp";
            this.txtPlcIp.Size = new System.Drawing.Size(120, 20);
            this.txtPlcIp.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "PLC IP:";
            // 
            // kamera_ayar
            // 
            this.kamera_ayar.Controls.Add(this.pictureBoxCamera);
            this.kamera_ayar.Controls.Add(this.btnApplyCam);
            this.kamera_ayar.Controls.Add(this.btnCapture);
            this.kamera_ayar.Controls.Add(this.cmbCameras);
            this.kamera_ayar.Location = new System.Drawing.Point(4, 22);
            this.kamera_ayar.Name = "kamera_ayar";
            this.kamera_ayar.Padding = new System.Windows.Forms.Padding(3);
            this.kamera_ayar.Size = new System.Drawing.Size(976, 635);
            this.kamera_ayar.TabIndex = 3;
            this.kamera_ayar.Text = "Kamera Ayarları";
            this.kamera_ayar.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Location = new System.Drawing.Point(10, 50);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(960, 540);
            this.pictureBoxCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCamera.TabIndex = 3;
            this.pictureBoxCamera.TabStop = false;
            // 
            // btnApplyCam
            // 
            this.btnApplyCam.Location = new System.Drawing.Point(320, 10);
            this.btnApplyCam.Name = "btnApplyCam";
            this.btnApplyCam.Size = new System.Drawing.Size(101, 23);
            this.btnApplyCam.TabIndex = 2;
            this.btnApplyCam.Text = "Ayarları Uygula";
            this.btnApplyCam.UseVisualStyleBackColor = true;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(450, 10);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Görüntü Al";
            this.btnCapture.UseVisualStyleBackColor = true;
            // 
            // cmbCameras
            // 
            this.cmbCameras.FormattingEnabled = true;
            this.cmbCameras.Location = new System.Drawing.Point(10, 10);
            this.cmbCameras.Name = "cmbCameras";
            this.cmbCameras.Size = new System.Drawing.Size(300, 21);
            this.cmbCameras.TabIndex = 0;
            // 
            // FrameTimer
            // 
            this.FrameTimer.Interval = 33;
            this.FrameTimer.Tick += new System.EventHandler(this.FrameTimer_Tick);
            // 
            // MaİnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tabMain);
            this.Name = "MaİnForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MaİnForm_Load);
            this.tabMain.ResumeLayout(false);
            this.tabTraining.ResumeLayout(false);
            this.tabTraining.PerformLayout();
            this.flowLayoutClasses.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEpoch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBatchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.inferans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).EndInit();
            this.plc_ayar.ResumeLayout(false);
            this.plc_ayar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlcUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlcPort)).EndInit();
            this.kamera_ayar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage inferans;
        private System.Windows.Forms.TabPage plc_ayar;
        private System.Windows.Forms.TabPage kamera_ayar;
        private System.Windows.Forms.Button btnInfer;
        private System.Windows.Forms.PictureBox pictureBoxInput;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.TextBox txtPlcIp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPlcUnit;
        private System.Windows.Forms.NumericUpDown nudPlcPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPlcStatus;
        private System.Windows.Forms.Button btnPlcConnect;
        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.Button btnApplyCam;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.ComboBox cmbCameras;
        private System.Windows.Forms.ComboBox cmbClassCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartCam;
        private System.Windows.Forms.Button btnStopCam;
        private System.Windows.Forms.TabPage tabTraining;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Panel panelSampleControls;
        private System.Windows.Forms.Timer FrameTimer;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.ProgressBar progressBarTrain;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutClasses;
        private System.Windows.Forms.NumericUpDown nudMax;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudScale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudLr;
        private System.Windows.Forms.NumericUpDown nudEpoch;
        private System.Windows.Forms.NumericUpDown nudBatchSize;
    }
}

