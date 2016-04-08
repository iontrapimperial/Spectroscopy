namespace Spectroscopy_Viewer
{
    partial class SpectroscopyViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        } */

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.zedGraphSpectra = new ZedGraph.ZedGraphControl();
            this.openDataFile = new System.Windows.Forms.OpenFileDialog();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.coolingThresholdSelect = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.countThresholdSelect = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.plotDataButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSpectra = new System.Windows.Forms.TabPage();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.userDisplayText = new System.Windows.Forms.TextBox();
            this.spectrumExportDataButton = new System.Windows.Forms.Button();
            this.tabPageHistogram = new System.Windows.Forms.TabPage();
            this.histogramExportDataButton = new System.Windows.Forms.Button();
            this.groupBoxMaxBin = new System.Windows.Forms.GroupBox();
            this.histogramMaxBinSelect = new System.Windows.Forms.NumericUpDown();
            this.histogramCheckBoxAuto = new System.Windows.Forms.CheckBox();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.histogramDisplayAll = new System.Windows.Forms.RadioButton();
            this.histogramDisplayCount = new System.Windows.Forms.RadioButton();
            this.histogramDisplayCool = new System.Windows.Forms.RadioButton();
            this.histogramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.updateHistogramButton = new System.Windows.Forms.Button();
            this.spectrumCamTab = new System.Windows.Forms.TabPage();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.Ion = new System.Windows.Forms.Label();
            this.ionBox = new System.Windows.Forms.ComboBox();
            this.userDisplayTextCAM = new System.Windows.Forms.TextBox();
            this.loadDataButtonCAM = new System.Windows.Forms.Button();
            this.spectrumExportDataButtonCAM = new System.Windows.Forms.Button();
            this.zedGraphSpectraCAM = new ZedGraph.ZedGraphControl();
            this.updateThresholdsButtonCAM = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.coolingThresholdSelectCAM = new System.Windows.Forms.NumericUpDown();
            this.countThresholdSelectCAM = new System.Windows.Forms.NumericUpDown();
            this.histogramCamTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.ionBox1 = new System.Windows.Forms.ComboBox();
            this.histogramExportDataButtonCAM = new System.Windows.Forms.Button();
            this.groupBoxMaxBinCAM = new System.Windows.Forms.GroupBox();
            this.histogramMaxBinSelectCAM = new System.Windows.Forms.NumericUpDown();
            this.histogramCheckBoxAutoCAM = new System.Windows.Forms.CheckBox();
            this.groupBoxDisplayCAM = new System.Windows.Forms.GroupBox();
            this.histogramDisplayAllCAM = new System.Windows.Forms.RadioButton();
            this.histogramDisplayCountCAM = new System.Windows.Forms.RadioButton();
            this.histogramDisplayCoolCAM = new System.Windows.Forms.RadioButton();
            this.histogramChartCAM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.updateHistogramButtonCAM = new System.Windows.Forms.Button();
            this.derivedCamTab = new System.Windows.Forms.TabPage();
            this.pauseButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.restartViewerButton = new System.Windows.Forms.Button();
            this.zedGraphSpectraDER = new ZedGraph.ZedGraphControl();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.coolingThresholdSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countThresholdSelect)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageSpectra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabPageHistogram.SuspendLayout();
            this.groupBoxMaxBin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramMaxBinSelect)).BeginInit();
            this.groupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramChart)).BeginInit();
            this.spectrumCamTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coolingThresholdSelectCAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countThresholdSelectCAM)).BeginInit();
            this.histogramCamTab.SuspendLayout();
            this.groupBoxMaxBinCAM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramMaxBinSelectCAM)).BeginInit();
            this.groupBoxDisplayCAM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramChartCAM)).BeginInit();
            this.derivedCamTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphSpectra
            // 
            this.zedGraphSpectra.Location = new System.Drawing.Point(49, 49);
            this.zedGraphSpectra.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphSpectra.Name = "zedGraphSpectra";
            this.zedGraphSpectra.ScrollGrace = 0D;
            this.zedGraphSpectra.ScrollMaxX = 0D;
            this.zedGraphSpectra.ScrollMaxY = 0D;
            this.zedGraphSpectra.ScrollMaxY2 = 0D;
            this.zedGraphSpectra.ScrollMinX = 0D;
            this.zedGraphSpectra.ScrollMinY = 0D;
            this.zedGraphSpectra.ScrollMinY2 = 0D;
            this.zedGraphSpectra.Size = new System.Drawing.Size(775, 456);
            this.zedGraphSpectra.TabIndex = 0;
            this.zedGraphSpectra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewerForm_KeyDown);
            // 
            // openDataFile
            // 
            this.openDataFile.FileName = "openFileDialog1";
            this.openDataFile.Title = "Insert data file";
            // 
            // loadDataButton
            // 
            this.loadDataButton.Location = new System.Drawing.Point(8, 5);
            this.loadDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(163, 36);
            this.loadDataButton.TabIndex = 2;
            this.loadDataButton.Text = "Load file...";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // coolingThresholdSelect
            // 
            this.coolingThresholdSelect.Location = new System.Drawing.Point(210, 22);
            this.coolingThresholdSelect.Margin = new System.Windows.Forms.Padding(2);
            this.coolingThresholdSelect.Name = "coolingThresholdSelect";
            this.coolingThresholdSelect.Size = new System.Drawing.Size(90, 20);
            this.coolingThresholdSelect.TabIndex = 3;
            this.coolingThresholdSelect.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cooling threshold";
            // 
            // countThresholdSelect
            // 
            this.countThresholdSelect.Location = new System.Drawing.Point(316, 22);
            this.countThresholdSelect.Margin = new System.Windows.Forms.Padding(2);
            this.countThresholdSelect.Name = "countThresholdSelect";
            this.countThresholdSelect.Size = new System.Drawing.Size(90, 20);
            this.countThresholdSelect.TabIndex = 5;
            this.countThresholdSelect.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Count threshold";
            // 
            // plotDataButton
            // 
            this.plotDataButton.Location = new System.Drawing.Point(426, 5);
            this.plotDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.plotDataButton.Name = "plotDataButton";
            this.plotDataButton.Size = new System.Drawing.Size(116, 37);
            this.plotDataButton.TabIndex = 7;
            this.plotDataButton.Text = "Update thresholds";
            this.plotDataButton.UseVisualStyleBackColor = true;
            this.plotDataButton.Click += new System.EventHandler(this.updateThresholdsButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSpectra);
            this.tabControl1.Controls.Add(this.tabPageHistogram);
            this.tabControl1.Controls.Add(this.spectrumCamTab);
            this.tabControl1.Controls.Add(this.histogramCamTab);
            this.tabControl1.Controls.Add(this.derivedCamTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1033, 644);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewerForm_KeyDown);
            // 
            // tabPageSpectra
            // 
            this.tabPageSpectra.Controls.Add(this.trackBar1);
            this.tabPageSpectra.Controls.Add(this.userDisplayText);
            this.tabPageSpectra.Controls.Add(this.loadDataButton);
            this.tabPageSpectra.Controls.Add(this.spectrumExportDataButton);
            this.tabPageSpectra.Controls.Add(this.zedGraphSpectra);
            this.tabPageSpectra.Controls.Add(this.plotDataButton);
            this.tabPageSpectra.Controls.Add(this.label1);
            this.tabPageSpectra.Controls.Add(this.label2);
            this.tabPageSpectra.Controls.Add(this.coolingThresholdSelect);
            this.tabPageSpectra.Controls.Add(this.countThresholdSelect);
            this.tabPageSpectra.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpectra.Name = "tabPageSpectra";
            this.tabPageSpectra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpectra.Size = new System.Drawing.Size(1025, 618);
            this.tabPageSpectra.TabIndex = 0;
            this.tabPageSpectra.Text = "Spectra PMT";
            this.tabPageSpectra.UseVisualStyleBackColor = true;
            this.tabPageSpectra.Click += new System.EventHandler(this.tabPageSpectra_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(3, 229);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 104);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.TickFrequency = 25;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // userDisplayText
            // 
            this.userDisplayText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userDisplayText.Location = new System.Drawing.Point(3, 547);
            this.userDisplayText.Multiline = true;
            this.userDisplayText.Name = "userDisplayText";
            this.userDisplayText.ReadOnly = true;
            this.userDisplayText.Size = new System.Drawing.Size(1019, 68);
            this.userDisplayText.TabIndex = 9;
            // 
            // spectrumExportDataButton
            // 
            this.spectrumExportDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spectrumExportDataButton.Location = new System.Drawing.Point(687, 5);
            this.spectrumExportDataButton.Name = "spectrumExportDataButton";
            this.spectrumExportDataButton.Size = new System.Drawing.Size(137, 36);
            this.spectrumExportDataButton.TabIndex = 8;
            this.spectrumExportDataButton.Text = "Export spectrum data...";
            this.spectrumExportDataButton.UseVisualStyleBackColor = true;
            this.spectrumExportDataButton.Click += new System.EventHandler(this.spectrumExportDataButton_Click);
            // 
            // tabPageHistogram
            // 
            this.tabPageHistogram.Controls.Add(this.histogramExportDataButton);
            this.tabPageHistogram.Controls.Add(this.groupBoxMaxBin);
            this.tabPageHistogram.Controls.Add(this.groupBoxDisplay);
            this.tabPageHistogram.Controls.Add(this.histogramChart);
            this.tabPageHistogram.Controls.Add(this.updateHistogramButton);
            this.tabPageHistogram.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistogram.Name = "tabPageHistogram";
            this.tabPageHistogram.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistogram.Size = new System.Drawing.Size(1025, 618);
            this.tabPageHistogram.TabIndex = 1;
            this.tabPageHistogram.Text = "Histogram PMT";
            this.tabPageHistogram.UseVisualStyleBackColor = true;
            // 
            // histogramExportDataButton
            // 
            this.histogramExportDataButton.Location = new System.Drawing.Point(7, 55);
            this.histogramExportDataButton.Name = "histogramExportDataButton";
            this.histogramExportDataButton.Size = new System.Drawing.Size(136, 36);
            this.histogramExportDataButton.TabIndex = 9;
            this.histogramExportDataButton.Text = "Export histogram data...";
            this.histogramExportDataButton.UseVisualStyleBackColor = true;
            this.histogramExportDataButton.Click += new System.EventHandler(this.histogramExportDataButton_Click);
            // 
            // groupBoxMaxBin
            // 
            this.groupBoxMaxBin.Controls.Add(this.histogramMaxBinSelect);
            this.groupBoxMaxBin.Controls.Add(this.histogramCheckBoxAuto);
            this.groupBoxMaxBin.Location = new System.Drawing.Point(613, 7);
            this.groupBoxMaxBin.Name = "groupBoxMaxBin";
            this.groupBoxMaxBin.Size = new System.Drawing.Size(130, 100);
            this.groupBoxMaxBin.TabIndex = 8;
            this.groupBoxMaxBin.TabStop = false;
            this.groupBoxMaxBin.Text = "Maximum bin";
            // 
            // histogramMaxBinSelect
            // 
            this.histogramMaxBinSelect.Location = new System.Drawing.Point(11, 64);
            this.histogramMaxBinSelect.Name = "histogramMaxBinSelect";
            this.histogramMaxBinSelect.Size = new System.Drawing.Size(98, 20);
            this.histogramMaxBinSelect.TabIndex = 8;
            this.histogramMaxBinSelect.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.histogramMaxBinSelect.ValueChanged += new System.EventHandler(this.histogramMaxBinSelect_ValueChanged);
            // 
            // histogramCheckBoxAuto
            // 
            this.histogramCheckBoxAuto.AutoSize = true;
            this.histogramCheckBoxAuto.Checked = true;
            this.histogramCheckBoxAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.histogramCheckBoxAuto.Location = new System.Drawing.Point(11, 31);
            this.histogramCheckBoxAuto.Name = "histogramCheckBoxAuto";
            this.histogramCheckBoxAuto.Size = new System.Drawing.Size(48, 17);
            this.histogramCheckBoxAuto.TabIndex = 7;
            this.histogramCheckBoxAuto.Text = "Auto";
            this.histogramCheckBoxAuto.UseVisualStyleBackColor = true;
            this.histogramCheckBoxAuto.CheckedChanged += new System.EventHandler(this.histogramCheckBoxAuto_CheckedChanged);
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.histogramDisplayAll);
            this.groupBoxDisplay.Controls.Add(this.histogramDisplayCount);
            this.groupBoxDisplay.Controls.Add(this.histogramDisplayCool);
            this.groupBoxDisplay.Location = new System.Drawing.Point(450, 7);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(157, 100);
            this.groupBoxDisplay.TabIndex = 6;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Display";
            // 
            // histogramDisplayAll
            // 
            this.histogramDisplayAll.AutoSize = true;
            this.histogramDisplayAll.Checked = true;
            this.histogramDisplayAll.Location = new System.Drawing.Point(6, 19);
            this.histogramDisplayAll.Name = "histogramDisplayAll";
            this.histogramDisplayAll.Size = new System.Drawing.Size(60, 17);
            this.histogramDisplayAll.TabIndex = 3;
            this.histogramDisplayAll.TabStop = true;
            this.histogramDisplayAll.Text = "All data";
            this.histogramDisplayAll.UseVisualStyleBackColor = true;
            this.histogramDisplayAll.CheckedChanged += new System.EventHandler(this.radioButtonDisplay_CheckedChanged);
            // 
            // histogramDisplayCount
            // 
            this.histogramDisplayCount.AutoSize = true;
            this.histogramDisplayCount.Location = new System.Drawing.Point(6, 67);
            this.histogramDisplayCount.Name = "histogramDisplayCount";
            this.histogramDisplayCount.Size = new System.Drawing.Size(107, 17);
            this.histogramDisplayCount.TabIndex = 5;
            this.histogramDisplayCount.Text = "Count period only";
            this.histogramDisplayCount.UseVisualStyleBackColor = true;
            this.histogramDisplayCount.CheckedChanged += new System.EventHandler(this.radioButtonDisplay_CheckedChanged);
            // 
            // histogramDisplayCool
            // 
            this.histogramDisplayCool.AutoSize = true;
            this.histogramDisplayCool.Location = new System.Drawing.Point(6, 42);
            this.histogramDisplayCool.Name = "histogramDisplayCool";
            this.histogramDisplayCool.Size = new System.Drawing.Size(114, 17);
            this.histogramDisplayCool.TabIndex = 4;
            this.histogramDisplayCool.Text = "Cooling period only";
            this.histogramDisplayCool.UseVisualStyleBackColor = true;
            this.histogramDisplayCool.CheckedChanged += new System.EventHandler(this.radioButtonDisplay_CheckedChanged);
            // 
            // histogramChart
            // 
            chartArea1.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.Name = "ChartArea1";
            this.histogramChart.ChartAreas.Add(chartArea1);
            this.histogramChart.Location = new System.Drawing.Point(6, 97);
            this.histogramChart.Name = "histogramChart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "seriesHistogram";
            this.histogramChart.Series.Add(series1);
            this.histogramChart.Size = new System.Drawing.Size(960, 397);
            this.histogramChart.TabIndex = 2;
            this.histogramChart.Text = "chart1";
            // 
            // updateHistogramButton
            // 
            this.updateHistogramButton.Location = new System.Drawing.Point(7, 7);
            this.updateHistogramButton.Name = "updateHistogramButton";
            this.updateHistogramButton.Size = new System.Drawing.Size(136, 36);
            this.updateHistogramButton.TabIndex = 1;
            this.updateHistogramButton.Text = "Update histogram";
            this.updateHistogramButton.UseVisualStyleBackColor = true;
            this.updateHistogramButton.Click += new System.EventHandler(this.updateHistogramButton_Click);
            // 
            // spectrumCamTab
            // 
            this.spectrumCamTab.Controls.Add(this.trackBar2);
            this.spectrumCamTab.Controls.Add(this.Ion);
            this.spectrumCamTab.Controls.Add(this.ionBox);
            this.spectrumCamTab.Controls.Add(this.userDisplayTextCAM);
            this.spectrumCamTab.Controls.Add(this.loadDataButtonCAM);
            this.spectrumCamTab.Controls.Add(this.spectrumExportDataButtonCAM);
            this.spectrumCamTab.Controls.Add(this.zedGraphSpectraCAM);
            this.spectrumCamTab.Controls.Add(this.updateThresholdsButtonCAM);
            this.spectrumCamTab.Controls.Add(this.label3);
            this.spectrumCamTab.Controls.Add(this.label4);
            this.spectrumCamTab.Controls.Add(this.coolingThresholdSelectCAM);
            this.spectrumCamTab.Controls.Add(this.countThresholdSelectCAM);
            this.spectrumCamTab.Location = new System.Drawing.Point(4, 22);
            this.spectrumCamTab.Name = "spectrumCamTab";
            this.spectrumCamTab.Padding = new System.Windows.Forms.Padding(3);
            this.spectrumCamTab.Size = new System.Drawing.Size(1025, 618);
            this.spectrumCamTab.TabIndex = 2;
            this.spectrumCamTab.Text = "Spectra Cam";
            this.spectrumCamTab.UseVisualStyleBackColor = true;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(3, 229);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 104);
            this.trackBar2.TabIndex = 20;
            this.trackBar2.TickFrequency = 25;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // Ion
            // 
            this.Ion.AutoSize = true;
            this.Ion.Location = new System.Drawing.Point(408, 3);
            this.Ion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Ion.Name = "Ion";
            this.Ion.Size = new System.Drawing.Size(22, 13);
            this.Ion.TabIndex = 19;
            this.Ion.Text = "Ion";
            // 
            // ionBox
            // 
            this.ionBox.FormattingEnabled = true;
            this.ionBox.Location = new System.Drawing.Point(411, 23);
            this.ionBox.Name = "ionBox";
            this.ionBox.Size = new System.Drawing.Size(109, 21);
            this.ionBox.TabIndex = 18;
            this.ionBox.SelectedIndexChanged += new System.EventHandler(this.ionBox_SelectedIndexChanged);
            // 
            // userDisplayTextCAM
            // 
            this.userDisplayTextCAM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userDisplayTextCAM.Location = new System.Drawing.Point(3, 554);
            this.userDisplayTextCAM.Multiline = true;
            this.userDisplayTextCAM.Name = "userDisplayTextCAM";
            this.userDisplayTextCAM.ReadOnly = true;
            this.userDisplayTextCAM.Size = new System.Drawing.Size(1019, 61);
            this.userDisplayTextCAM.TabIndex = 17;
            // 
            // loadDataButtonCAM
            // 
            this.loadDataButtonCAM.Location = new System.Drawing.Point(8, 6);
            this.loadDataButtonCAM.Margin = new System.Windows.Forms.Padding(2);
            this.loadDataButtonCAM.Name = "loadDataButtonCAM";
            this.loadDataButtonCAM.Size = new System.Drawing.Size(163, 36);
            this.loadDataButtonCAM.TabIndex = 10;
            this.loadDataButtonCAM.Text = "Load file...";
            this.loadDataButtonCAM.UseVisualStyleBackColor = true;
            // 
            // spectrumExportDataButtonCAM
            // 
            this.spectrumExportDataButtonCAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spectrumExportDataButtonCAM.Location = new System.Drawing.Point(687, 8);
            this.spectrumExportDataButtonCAM.Name = "spectrumExportDataButtonCAM";
            this.spectrumExportDataButtonCAM.Size = new System.Drawing.Size(137, 36);
            this.spectrumExportDataButtonCAM.TabIndex = 16;
            this.spectrumExportDataButtonCAM.Text = "Export spectrum data...";
            this.spectrumExportDataButtonCAM.UseVisualStyleBackColor = true;
            // 
            // zedGraphSpectraCAM
            // 
            this.zedGraphSpectraCAM.Location = new System.Drawing.Point(49, 49);
            this.zedGraphSpectraCAM.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphSpectraCAM.Name = "zedGraphSpectraCAM";
            this.zedGraphSpectraCAM.ScrollGrace = 0D;
            this.zedGraphSpectraCAM.ScrollMaxX = 0D;
            this.zedGraphSpectraCAM.ScrollMaxY = 0D;
            this.zedGraphSpectraCAM.ScrollMaxY2 = 0D;
            this.zedGraphSpectraCAM.ScrollMinX = 0D;
            this.zedGraphSpectraCAM.ScrollMinY = 0D;
            this.zedGraphSpectraCAM.ScrollMinY2 = 0D;
            this.zedGraphSpectraCAM.Size = new System.Drawing.Size(775, 456);
            this.zedGraphSpectraCAM.TabIndex = 9;
            // 
            // updateThresholdsButtonCAM
            // 
            this.updateThresholdsButtonCAM.Location = new System.Drawing.Point(525, 6);
            this.updateThresholdsButtonCAM.Margin = new System.Windows.Forms.Padding(2);
            this.updateThresholdsButtonCAM.Name = "updateThresholdsButtonCAM";
            this.updateThresholdsButtonCAM.Size = new System.Drawing.Size(116, 37);
            this.updateThresholdsButtonCAM.TabIndex = 15;
            this.updateThresholdsButtonCAM.Text = "Update thresholds";
            this.updateThresholdsButtonCAM.UseVisualStyleBackColor = true;
            this.updateThresholdsButtonCAM.Click += new System.EventHandler(this.updateThresholdsButtonCAM_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cooling threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Count threshold";
            // 
            // coolingThresholdSelectCAM
            // 
            this.coolingThresholdSelectCAM.Location = new System.Drawing.Point(192, 23);
            this.coolingThresholdSelectCAM.Margin = new System.Windows.Forms.Padding(2);
            this.coolingThresholdSelectCAM.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.coolingThresholdSelectCAM.Name = "coolingThresholdSelectCAM";
            this.coolingThresholdSelectCAM.Size = new System.Drawing.Size(90, 20);
            this.coolingThresholdSelectCAM.TabIndex = 11;
            this.coolingThresholdSelectCAM.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // countThresholdSelectCAM
            // 
            this.countThresholdSelectCAM.Location = new System.Drawing.Point(305, 23);
            this.countThresholdSelectCAM.Margin = new System.Windows.Forms.Padding(2);
            this.countThresholdSelectCAM.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.countThresholdSelectCAM.Name = "countThresholdSelectCAM";
            this.countThresholdSelectCAM.Size = new System.Drawing.Size(90, 20);
            this.countThresholdSelectCAM.TabIndex = 13;
            this.countThresholdSelectCAM.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // histogramCamTab
            // 
            this.histogramCamTab.Controls.Add(this.label5);
            this.histogramCamTab.Controls.Add(this.ionBox1);
            this.histogramCamTab.Controls.Add(this.histogramExportDataButtonCAM);
            this.histogramCamTab.Controls.Add(this.groupBoxMaxBinCAM);
            this.histogramCamTab.Controls.Add(this.groupBoxDisplayCAM);
            this.histogramCamTab.Controls.Add(this.histogramChartCAM);
            this.histogramCamTab.Controls.Add(this.updateHistogramButtonCAM);
            this.histogramCamTab.Location = new System.Drawing.Point(4, 22);
            this.histogramCamTab.Name = "histogramCamTab";
            this.histogramCamTab.Padding = new System.Windows.Forms.Padding(3);
            this.histogramCamTab.Size = new System.Drawing.Size(1025, 618);
            this.histogramCamTab.TabIndex = 3;
            this.histogramCamTab.Text = "Histogram Cam";
            this.histogramCamTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Ion";
            // 
            // ionBox1
            // 
            this.ionBox1.FormattingEnabled = true;
            this.ionBox1.Location = new System.Drawing.Point(158, 21);
            this.ionBox1.Name = "ionBox1";
            this.ionBox1.Size = new System.Drawing.Size(109, 21);
            this.ionBox1.TabIndex = 19;
            this.ionBox1.SelectedIndexChanged += new System.EventHandler(this.ionBox1_SelectedIndexChanged);
            // 
            // histogramExportDataButtonCAM
            // 
            this.histogramExportDataButtonCAM.Location = new System.Drawing.Point(6, 54);
            this.histogramExportDataButtonCAM.Name = "histogramExportDataButtonCAM";
            this.histogramExportDataButtonCAM.Size = new System.Drawing.Size(136, 36);
            this.histogramExportDataButtonCAM.TabIndex = 14;
            this.histogramExportDataButtonCAM.Text = "Export histogram data...";
            this.histogramExportDataButtonCAM.UseVisualStyleBackColor = true;
            // 
            // groupBoxMaxBinCAM
            // 
            this.groupBoxMaxBinCAM.Controls.Add(this.histogramMaxBinSelectCAM);
            this.groupBoxMaxBinCAM.Controls.Add(this.histogramCheckBoxAutoCAM);
            this.groupBoxMaxBinCAM.Location = new System.Drawing.Point(612, 6);
            this.groupBoxMaxBinCAM.Name = "groupBoxMaxBinCAM";
            this.groupBoxMaxBinCAM.Size = new System.Drawing.Size(130, 100);
            this.groupBoxMaxBinCAM.TabIndex = 13;
            this.groupBoxMaxBinCAM.TabStop = false;
            this.groupBoxMaxBinCAM.Text = "Maximum bin";
            // 
            // histogramMaxBinSelectCAM
            // 
            this.histogramMaxBinSelectCAM.Location = new System.Drawing.Point(11, 64);
            this.histogramMaxBinSelectCAM.Name = "histogramMaxBinSelectCAM";
            this.histogramMaxBinSelectCAM.Size = new System.Drawing.Size(98, 20);
            this.histogramMaxBinSelectCAM.TabIndex = 8;
            this.histogramMaxBinSelectCAM.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // histogramCheckBoxAutoCAM
            // 
            this.histogramCheckBoxAutoCAM.AutoSize = true;
            this.histogramCheckBoxAutoCAM.Checked = true;
            this.histogramCheckBoxAutoCAM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.histogramCheckBoxAutoCAM.Location = new System.Drawing.Point(11, 31);
            this.histogramCheckBoxAutoCAM.Name = "histogramCheckBoxAutoCAM";
            this.histogramCheckBoxAutoCAM.Size = new System.Drawing.Size(48, 17);
            this.histogramCheckBoxAutoCAM.TabIndex = 7;
            this.histogramCheckBoxAutoCAM.Text = "Auto";
            this.histogramCheckBoxAutoCAM.UseVisualStyleBackColor = true;
            this.histogramCheckBoxAutoCAM.CheckedChanged += new System.EventHandler(this.histogramCheckBoxAutoCAM_CheckedChanged_1);
            // 
            // groupBoxDisplayCAM
            // 
            this.groupBoxDisplayCAM.Controls.Add(this.histogramDisplayAllCAM);
            this.groupBoxDisplayCAM.Controls.Add(this.histogramDisplayCountCAM);
            this.groupBoxDisplayCAM.Controls.Add(this.histogramDisplayCoolCAM);
            this.groupBoxDisplayCAM.Location = new System.Drawing.Point(449, 6);
            this.groupBoxDisplayCAM.Name = "groupBoxDisplayCAM";
            this.groupBoxDisplayCAM.Size = new System.Drawing.Size(157, 100);
            this.groupBoxDisplayCAM.TabIndex = 12;
            this.groupBoxDisplayCAM.TabStop = false;
            this.groupBoxDisplayCAM.Text = "Display";
            // 
            // histogramDisplayAllCAM
            // 
            this.histogramDisplayAllCAM.AutoSize = true;
            this.histogramDisplayAllCAM.Checked = true;
            this.histogramDisplayAllCAM.Location = new System.Drawing.Point(6, 19);
            this.histogramDisplayAllCAM.Name = "histogramDisplayAllCAM";
            this.histogramDisplayAllCAM.Size = new System.Drawing.Size(60, 17);
            this.histogramDisplayAllCAM.TabIndex = 3;
            this.histogramDisplayAllCAM.TabStop = true;
            this.histogramDisplayAllCAM.Text = "All data";
            this.histogramDisplayAllCAM.UseVisualStyleBackColor = true;
            // 
            // histogramDisplayCountCAM
            // 
            this.histogramDisplayCountCAM.AutoSize = true;
            this.histogramDisplayCountCAM.Location = new System.Drawing.Point(6, 67);
            this.histogramDisplayCountCAM.Name = "histogramDisplayCountCAM";
            this.histogramDisplayCountCAM.Size = new System.Drawing.Size(107, 17);
            this.histogramDisplayCountCAM.TabIndex = 5;
            this.histogramDisplayCountCAM.Text = "Count period only";
            this.histogramDisplayCountCAM.UseVisualStyleBackColor = true;
            // 
            // histogramDisplayCoolCAM
            // 
            this.histogramDisplayCoolCAM.AutoSize = true;
            this.histogramDisplayCoolCAM.Location = new System.Drawing.Point(6, 42);
            this.histogramDisplayCoolCAM.Name = "histogramDisplayCoolCAM";
            this.histogramDisplayCoolCAM.Size = new System.Drawing.Size(114, 17);
            this.histogramDisplayCoolCAM.TabIndex = 4;
            this.histogramDisplayCoolCAM.Text = "Cooling period only";
            this.histogramDisplayCoolCAM.UseVisualStyleBackColor = true;
            this.histogramDisplayCoolCAM.CheckedChanged += new System.EventHandler(this.histogramDisplayCoolCAM_CheckedChanged);
            // 
            // histogramChartCAM
            // 
            chartArea2.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.Name = "ChartArea1";
            this.histogramChartCAM.ChartAreas.Add(chartArea2);
            this.histogramChartCAM.Location = new System.Drawing.Point(5, 96);
            this.histogramChartCAM.Name = "histogramChartCAM";
            series2.ChartArea = "ChartArea1";
            series2.Name = "seriesHistogram";
            this.histogramChartCAM.Series.Add(series2);
            this.histogramChartCAM.Size = new System.Drawing.Size(960, 397);
            this.histogramChartCAM.TabIndex = 11;
            this.histogramChartCAM.Text = "chart1";
            // 
            // updateHistogramButtonCAM
            // 
            this.updateHistogramButtonCAM.Location = new System.Drawing.Point(6, 6);
            this.updateHistogramButtonCAM.Name = "updateHistogramButtonCAM";
            this.updateHistogramButtonCAM.Size = new System.Drawing.Size(136, 36);
            this.updateHistogramButtonCAM.TabIndex = 10;
            this.updateHistogramButtonCAM.Text = "Update histogram";
            this.updateHistogramButtonCAM.UseVisualStyleBackColor = true;
            this.updateHistogramButtonCAM.Click += new System.EventHandler(this.updateHistogramButtonCAM_Click);
            // 
            // derivedCamTab
            // 
            this.derivedCamTab.Controls.Add(this.trackBar3);
            this.derivedCamTab.Controls.Add(this.zedGraphSpectraDER);
            this.derivedCamTab.Location = new System.Drawing.Point(4, 22);
            this.derivedCamTab.Name = "derivedCamTab";
            this.derivedCamTab.Padding = new System.Windows.Forms.Padding(3);
            this.derivedCamTab.Size = new System.Drawing.Size(1025, 618);
            this.derivedCamTab.TabIndex = 4;
            this.derivedCamTab.Text = "Derived Plots";
            this.derivedCamTab.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.Location = new System.Drawing.Point(693, 2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(147, 26);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // restartViewerButton
            // 
            this.restartViewerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restartViewerButton.Location = new System.Drawing.Point(875, 2);
            this.restartViewerButton.Name = "restartViewerButton";
            this.restartViewerButton.Size = new System.Drawing.Size(158, 26);
            this.restartViewerButton.TabIndex = 9;
            this.restartViewerButton.Text = "Restart viewer";
            this.restartViewerButton.UseVisualStyleBackColor = true;
            this.restartViewerButton.Click += new System.EventHandler(this.restartViewerButton_Click);
            // 
            // zedGraphSpectraDER
            // 
            this.zedGraphSpectraDER.Location = new System.Drawing.Point(49, 49);
            this.zedGraphSpectraDER.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphSpectraDER.Name = "zedGraphSpectraDER";
            this.zedGraphSpectraDER.ScrollGrace = 0D;
            this.zedGraphSpectraDER.ScrollMaxX = 0D;
            this.zedGraphSpectraDER.ScrollMaxY = 0D;
            this.zedGraphSpectraDER.ScrollMaxY2 = 0D;
            this.zedGraphSpectraDER.ScrollMinX = 0D;
            this.zedGraphSpectraDER.ScrollMinY = 0D;
            this.zedGraphSpectraDER.ScrollMinY2 = 0D;
            this.zedGraphSpectraDER.Size = new System.Drawing.Size(775, 456);
            this.zedGraphSpectraDER.TabIndex = 1;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(3, 229);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3.Size = new System.Drawing.Size(45, 104);
            this.trackBar3.TabIndex = 21;
            this.trackBar3.TickFrequency = 25;
            // 
            // SpectroscopyViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 668);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.restartViewerButton);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "SpectroscopyViewerForm";
            this.Text = "Spectroscopy Viewer";
            this.Load += new System.EventHandler(this.SpectroscopyViewerForm_Load);
            this.SizeChanged += new System.EventHandler(this.SpectroscopyViewerForm_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.coolingThresholdSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countThresholdSelect)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSpectra.ResumeLayout(false);
            this.tabPageSpectra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabPageHistogram.ResumeLayout(false);
            this.groupBoxMaxBin.ResumeLayout(false);
            this.groupBoxMaxBin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramMaxBinSelect)).EndInit();
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramChart)).EndInit();
            this.spectrumCamTab.ResumeLayout(false);
            this.spectrumCamTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coolingThresholdSelectCAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countThresholdSelectCAM)).EndInit();
            this.histogramCamTab.ResumeLayout(false);
            this.histogramCamTab.PerformLayout();
            this.groupBoxMaxBinCAM.ResumeLayout(false);
            this.groupBoxMaxBinCAM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramMaxBinSelectCAM)).EndInit();
            this.groupBoxDisplayCAM.ResumeLayout(false);
            this.groupBoxDisplayCAM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramChartCAM)).EndInit();
            this.derivedCamTab.ResumeLayout(false);
            this.derivedCamTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphSpectra;
        private System.Windows.Forms.OpenFileDialog openDataFile;
        private System.Windows.Forms.Button loadDataButton;
        private System.Windows.Forms.NumericUpDown coolingThresholdSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown countThresholdSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button plotDataButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSpectra;
        private System.Windows.Forms.TabPage tabPageHistogram;
        private System.Windows.Forms.Button updateHistogramButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramChart;
        private System.Windows.Forms.RadioButton histogramDisplayCount;
        private System.Windows.Forms.RadioButton histogramDisplayCool;
        private System.Windows.Forms.RadioButton histogramDisplayAll;
        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.GroupBox groupBoxMaxBin;
        private System.Windows.Forms.NumericUpDown histogramMaxBinSelect;
        private System.Windows.Forms.CheckBox histogramCheckBoxAuto;
        private System.Windows.Forms.Button histogramExportDataButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button spectrumExportDataButton;
        public System.Windows.Forms.TextBox userDisplayText;
        private System.Windows.Forms.Button restartViewerButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.TabPage spectrumCamTab;
        private System.Windows.Forms.TabPage histogramCamTab;
        public System.Windows.Forms.TextBox userDisplayTextCAM;
        private System.Windows.Forms.Button loadDataButtonCAM;
        private System.Windows.Forms.Button spectrumExportDataButtonCAM;
        private ZedGraph.ZedGraphControl zedGraphSpectraCAM;
        private System.Windows.Forms.Button updateThresholdsButtonCAM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown coolingThresholdSelectCAM;
        private System.Windows.Forms.NumericUpDown countThresholdSelectCAM;
        private System.Windows.Forms.Button histogramExportDataButtonCAM;
        private System.Windows.Forms.GroupBox groupBoxMaxBinCAM;
        private System.Windows.Forms.NumericUpDown histogramMaxBinSelectCAM;
        private System.Windows.Forms.CheckBox histogramCheckBoxAutoCAM;
        private System.Windows.Forms.GroupBox groupBoxDisplayCAM;
        private System.Windows.Forms.RadioButton histogramDisplayAllCAM;
        private System.Windows.Forms.RadioButton histogramDisplayCountCAM;
        private System.Windows.Forms.RadioButton histogramDisplayCoolCAM;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramChartCAM;
        private System.Windows.Forms.Button updateHistogramButtonCAM;
        private System.Windows.Forms.Label Ion;
        private System.Windows.Forms.ComboBox ionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ionBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TabPage derivedCamTab;
        private System.Windows.Forms.TrackBar trackBar3;
        private ZedGraph.ZedGraphControl zedGraphSpectraDER;
    }
}

