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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.tabPageHistogram = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonCount = new System.Windows.Forms.RadioButton();
            this.radioButtonCool = new System.Windows.Forms.RadioButton();
            this.histogramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.updateHistogramButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.coolingThresholdSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countThresholdSelect)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageSpectra.SuspendLayout();
            this.tabPageHistogram.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramChart)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphSpectra
            // 
            this.zedGraphSpectra.Location = new System.Drawing.Point(8, 48);
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
            // 
            // openDataFile
            // 
            this.openDataFile.FileName = "openFileDialog1";
            this.openDataFile.Title = "Insert data file";
            // 
            // loadDataButton
            // 
            this.loadDataButton.Location = new System.Drawing.Point(640, 4);
            this.loadDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(159, 25);
            this.loadDataButton.TabIndex = 2;
            this.loadDataButton.Text = "Load data";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // coolingThresholdSelect
            // 
            this.coolingThresholdSelect.Location = new System.Drawing.Point(5, 22);
            this.coolingThresholdSelect.Margin = new System.Windows.Forms.Padding(2);
            this.coolingThresholdSelect.Name = "coolingThresholdSelect";
            this.coolingThresholdSelect.Size = new System.Drawing.Size(90, 20);
            this.coolingThresholdSelect.TabIndex = 3;
            this.coolingThresholdSelect.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cooling threshold";
            // 
            // countThresholdSelect
            // 
            this.countThresholdSelect.Location = new System.Drawing.Point(111, 22);
            this.countThresholdSelect.Margin = new System.Windows.Forms.Padding(2);
            this.countThresholdSelect.Name = "countThresholdSelect";
            this.countThresholdSelect.Size = new System.Drawing.Size(90, 20);
            this.countThresholdSelect.TabIndex = 5;
            this.countThresholdSelect.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Count threshold";
            // 
            // plotDataButton
            // 
            this.plotDataButton.Location = new System.Drawing.Point(221, 18);
            this.plotDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.plotDataButton.Name = "plotDataButton";
            this.plotDataButton.Size = new System.Drawing.Size(74, 24);
            this.plotDataButton.TabIndex = 7;
            this.plotDataButton.Text = "Plot data";
            this.plotDataButton.UseVisualStyleBackColor = true;
            this.plotDataButton.Click += new System.EventHandler(this.plotDataButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSpectra);
            this.tabControl1.Controls.Add(this.tabPageHistogram);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 526);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageSpectra
            // 
            this.tabPageSpectra.Controls.Add(this.zedGraphSpectra);
            this.tabPageSpectra.Controls.Add(this.plotDataButton);
            this.tabPageSpectra.Controls.Add(this.label1);
            this.tabPageSpectra.Controls.Add(this.label2);
            this.tabPageSpectra.Controls.Add(this.coolingThresholdSelect);
            this.tabPageSpectra.Controls.Add(this.countThresholdSelect);
            this.tabPageSpectra.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpectra.Name = "tabPageSpectra";
            this.tabPageSpectra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpectra.Size = new System.Drawing.Size(779, 500);
            this.tabPageSpectra.TabIndex = 0;
            this.tabPageSpectra.Text = "Spectra";
            this.tabPageSpectra.UseVisualStyleBackColor = true;
            // 
            // tabPageHistogram
            // 
            this.tabPageHistogram.Controls.Add(this.groupBox1);
            this.tabPageHistogram.Controls.Add(this.histogramChart);
            this.tabPageHistogram.Controls.Add(this.updateHistogramButton);
            this.tabPageHistogram.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistogram.Name = "tabPageHistogram";
            this.tabPageHistogram.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistogram.Size = new System.Drawing.Size(779, 500);
            this.tabPageHistogram.TabIndex = 1;
            this.tabPageHistogram.Text = "Histogram";
            this.tabPageHistogram.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Controls.Add(this.radioButtonCount);
            this.groupBox1.Controls.Add(this.radioButtonCool);
            this.groupBox1.Location = new System.Drawing.Point(585, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(60, 17);
            this.radioButtonAll.TabIndex = 3;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All data";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonDisplay_CheckedChanged);
            // 
            // radioButtonCount
            // 
            this.radioButtonCount.AutoSize = true;
            this.radioButtonCount.Location = new System.Drawing.Point(6, 67);
            this.radioButtonCount.Name = "radioButtonCount";
            this.radioButtonCount.Size = new System.Drawing.Size(107, 17);
            this.radioButtonCount.TabIndex = 5;
            this.radioButtonCount.TabStop = true;
            this.radioButtonCount.Text = "Count period only";
            this.radioButtonCount.UseVisualStyleBackColor = true;
            this.radioButtonCount.CheckedChanged += new System.EventHandler(this.radioButtonDisplay_CheckedChanged);
            // 
            // radioButtonCool
            // 
            this.radioButtonCool.AutoSize = true;
            this.radioButtonCool.Location = new System.Drawing.Point(6, 42);
            this.radioButtonCool.Name = "radioButtonCool";
            this.radioButtonCool.Size = new System.Drawing.Size(114, 17);
            this.radioButtonCool.TabIndex = 4;
            this.radioButtonCool.TabStop = true;
            this.radioButtonCool.Text = "Cooling period only";
            this.radioButtonCool.UseVisualStyleBackColor = true;
            this.radioButtonCool.CheckedChanged += new System.EventHandler(this.radioButtonDisplay_CheckedChanged);
            // 
            // histogramChart
            // 
            chartArea1.Name = "ChartArea1";
            this.histogramChart.ChartAreas.Add(chartArea1);
            this.histogramChart.Location = new System.Drawing.Point(6, 98);
            this.histogramChart.Name = "histogramChart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "seriesHistogram";
            this.histogramChart.Series.Add(series1);
            this.histogramChart.Size = new System.Drawing.Size(767, 396);
            this.histogramChart.TabIndex = 2;
            this.histogramChart.Text = "chart1";
            // 
            // updateHistogramButton
            // 
            this.updateHistogramButton.Location = new System.Drawing.Point(7, 7);
            this.updateHistogramButton.Name = "updateHistogramButton";
            this.updateHistogramButton.Size = new System.Drawing.Size(136, 23);
            this.updateHistogramButton.TabIndex = 1;
            this.updateHistogramButton.Text = "Update histogram";
            this.updateHistogramButton.UseVisualStyleBackColor = true;
            this.updateHistogramButton.Click += new System.EventHandler(this.updateHistogramButton_Click);
            // 
            // SpectroscopyViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 550);
            this.Controls.Add(this.loadDataButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "SpectroscopyViewerForm";
            this.Text = "Spectroscopy Viewer";
            this.Load += new System.EventHandler(this.SpectroscopyViewerForm_Load);
            this.SizeChanged += new System.EventHandler(this.SpectroscopyViewerForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.coolingThresholdSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countThresholdSelect)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSpectra.ResumeLayout(false);
            this.tabPageSpectra.PerformLayout();
            this.tabPageHistogram.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramChart)).EndInit();
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
        private System.Windows.Forms.RadioButton radioButtonCount;
        private System.Windows.Forms.RadioButton radioButtonCool;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}

