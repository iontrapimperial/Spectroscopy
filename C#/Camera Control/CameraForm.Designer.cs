namespace Camera_Control
{
    partial class CameraForm
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
            this.Shutter = new System.Windows.Forms.Button();
            this.ShutDown = new System.Windows.Forms.Button();
            this.numIonsUpDown = new System.Windows.Forms.NumericUpDown();
            this.NumberOfIons = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTrigger = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subImaging = new System.Windows.Forms.Panel();
            this.verticalEndLabel = new System.Windows.Forms.Label();
            this.vertEndLabel = new System.Windows.Forms.Label();
            this.horizEndLabel = new System.Windows.Forms.Label();
            this.horizStartLabel = new System.Windows.Forms.Label();
            this.vertEndUpDown = new System.Windows.Forms.NumericUpDown();
            this.verStartUpDown = new System.Windows.Forms.NumericUpDown();
            this.horEndUpDown = new System.Windows.Forms.NumericUpDown();
            this.horStartUpDown = new System.Windows.Forms.NumericUpDown();
            this.threshUpDown = new System.Windows.Forms.NumericUpDown();
            this.numRepeatsUpDown = new System.Windows.Forms.NumericUpDown();
            this.numLoopsUpDown = new System.Windows.Forms.NumericUpDown();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.loopNumLabel = new System.Windows.Forms.Label();
            this.acqTypeComboBox = new System.Windows.Forms.ComboBox();
            this.startAcqButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numIonsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.subImaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vertEndUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verStartUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horEndUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horStartUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoopsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Shutter
            // 
            this.Shutter.Location = new System.Drawing.Point(730, 12);
            this.Shutter.Name = "Shutter";
            this.Shutter.Size = new System.Drawing.Size(127, 72);
            this.Shutter.TabIndex = 0;
            this.Shutter.Text = "Shutter";
            this.Shutter.UseVisualStyleBackColor = true;
            this.Shutter.Click += new System.EventHandler(this.Shutter_Click);
            // 
            // ShutDown
            // 
            this.ShutDown.Location = new System.Drawing.Point(730, 184);
            this.ShutDown.Name = "ShutDown";
            this.ShutDown.Size = new System.Drawing.Size(127, 65);
            this.ShutDown.TabIndex = 1;
            this.ShutDown.Text = "Shut Down";
            this.ShutDown.UseVisualStyleBackColor = true;
            this.ShutDown.Click += new System.EventHandler(this.ShutDown_Click);
            // 
            // numIonsUpDown
            // 
            this.numIonsUpDown.Location = new System.Drawing.Point(16, 46);
            this.numIonsUpDown.Name = "numIonsUpDown";
            this.numIonsUpDown.Size = new System.Drawing.Size(85, 20);
            this.numIonsUpDown.TabIndex = 2;
            this.numIonsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIonsUpDown.ValueChanged += new System.EventHandler(this.numIonsUpDown_ValueChanged);
            // 
            // NumberOfIons
            // 
            this.NumberOfIons.AutoSize = true;
            this.NumberOfIons.Location = new System.Drawing.Point(13, 30);
            this.NumberOfIons.Name = "NumberOfIons";
            this.NumberOfIons.Size = new System.Drawing.Size(79, 13);
            this.NumberOfIons.TabIndex = 3;
            this.NumberOfIons.Text = "Number of Ions";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(16, 89);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(84, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Size of Ion Box";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 4;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown2.Location = new System.Drawing.Point(16, 137);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Exposure Time (s)";
            // 
            // comboTrigger
            // 
            this.comboTrigger.FormattingEnabled = true;
            this.comboTrigger.Items.AddRange(new object[] {
            "Software",
            "External"});
            this.comboTrigger.Location = new System.Drawing.Point(16, 184);
            this.comboTrigger.Name = "comboTrigger";
            this.comboTrigger.Size = new System.Drawing.Size(85, 21);
            this.comboTrigger.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Trigger";
            // 
            // subImaging
            // 
            this.subImaging.Controls.Add(this.verticalEndLabel);
            this.subImaging.Controls.Add(this.vertEndLabel);
            this.subImaging.Controls.Add(this.horizEndLabel);
            this.subImaging.Controls.Add(this.horizStartLabel);
            this.subImaging.Controls.Add(this.vertEndUpDown);
            this.subImaging.Controls.Add(this.verStartUpDown);
            this.subImaging.Controls.Add(this.horEndUpDown);
            this.subImaging.Controls.Add(this.horStartUpDown);
            this.subImaging.Location = new System.Drawing.Point(16, 224);
            this.subImaging.Name = "subImaging";
            this.subImaging.Size = new System.Drawing.Size(155, 163);
            this.subImaging.TabIndex = 10;
            // 
            // verticalEndLabel
            // 
            this.verticalEndLabel.AutoSize = true;
            this.verticalEndLabel.Location = new System.Drawing.Point(77, 84);
            this.verticalEndLabel.Name = "verticalEndLabel";
            this.verticalEndLabel.Size = new System.Drawing.Size(51, 13);
            this.verticalEndLabel.TabIndex = 13;
            this.verticalEndLabel.Text = "Vert. End";
            // 
            // vertEndLabel
            // 
            this.vertEndLabel.AutoSize = true;
            this.vertEndLabel.Location = new System.Drawing.Point(3, 84);
            this.vertEndLabel.Name = "vertEndLabel";
            this.vertEndLabel.Size = new System.Drawing.Size(54, 13);
            this.vertEndLabel.TabIndex = 12;
            this.vertEndLabel.Text = "Vert. Start";
            // 
            // horizEndLabel
            // 
            this.horizEndLabel.AutoSize = true;
            this.horizEndLabel.Location = new System.Drawing.Point(77, 23);
            this.horizEndLabel.Name = "horizEndLabel";
            this.horizEndLabel.Size = new System.Drawing.Size(56, 13);
            this.horizEndLabel.TabIndex = 12;
            this.horizEndLabel.Text = "Horiz. End";
            // 
            // horizStartLabel
            // 
            this.horizStartLabel.AutoSize = true;
            this.horizStartLabel.Location = new System.Drawing.Point(3, 23);
            this.horizStartLabel.Name = "horizStartLabel";
            this.horizStartLabel.Size = new System.Drawing.Size(59, 13);
            this.horizStartLabel.TabIndex = 11;
            this.horizStartLabel.Text = "Horiz. Start";
            // 
            // vertEndUpDown
            // 
            this.vertEndUpDown.Location = new System.Drawing.Point(80, 100);
            this.vertEndUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.vertEndUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.vertEndUpDown.Name = "vertEndUpDown";
            this.vertEndUpDown.Size = new System.Drawing.Size(72, 20);
            this.vertEndUpDown.TabIndex = 3;
            this.vertEndUpDown.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // verStartUpDown
            // 
            this.verStartUpDown.Location = new System.Drawing.Point(3, 100);
            this.verStartUpDown.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.verStartUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.verStartUpDown.Name = "verStartUpDown";
            this.verStartUpDown.Size = new System.Drawing.Size(72, 20);
            this.verStartUpDown.TabIndex = 2;
            this.verStartUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // horEndUpDown
            // 
            this.horEndUpDown.Location = new System.Drawing.Point(80, 39);
            this.horEndUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.horEndUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.horEndUpDown.Name = "horEndUpDown";
            this.horEndUpDown.Size = new System.Drawing.Size(72, 20);
            this.horEndUpDown.TabIndex = 1;
            this.horEndUpDown.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // horStartUpDown
            // 
            this.horStartUpDown.Location = new System.Drawing.Point(3, 39);
            this.horStartUpDown.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.horStartUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.horStartUpDown.Name = "horStartUpDown";
            this.horStartUpDown.Size = new System.Drawing.Size(72, 20);
            this.horStartUpDown.TabIndex = 0;
            this.horStartUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // threshUpDown
            // 
            this.threshUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.threshUpDown.Location = new System.Drawing.Point(19, 414);
            this.threshUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.threshUpDown.Name = "threshUpDown";
            this.threshUpDown.Size = new System.Drawing.Size(72, 20);
            this.threshUpDown.TabIndex = 11;
            this.threshUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numRepeatsUpDown
            // 
            this.numRepeatsUpDown.Location = new System.Drawing.Point(99, 414);
            this.numRepeatsUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRepeatsUpDown.Name = "numRepeatsUpDown";
            this.numRepeatsUpDown.Size = new System.Drawing.Size(72, 20);
            this.numRepeatsUpDown.TabIndex = 12;
            this.numRepeatsUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numLoopsUpDown
            // 
            this.numLoopsUpDown.Location = new System.Drawing.Point(19, 462);
            this.numLoopsUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLoopsUpDown.Name = "numLoopsUpDown";
            this.numLoopsUpDown.Size = new System.Drawing.Size(72, 20);
            this.numLoopsUpDown.TabIndex = 13;
            this.numLoopsUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(23, 398);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.thresholdLabel.TabIndex = 14;
            this.thresholdLabel.Text = "Threshold";
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(96, 398);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(47, 13);
            this.repeatLabel.TabIndex = 15;
            this.repeatLabel.Text = "Repeats";
            // 
            // loopNumLabel
            // 
            this.loopNumLabel.AutoSize = true;
            this.loopNumLabel.Location = new System.Drawing.Point(16, 446);
            this.loopNumLabel.Name = "loopNumLabel";
            this.loopNumLabel.Size = new System.Drawing.Size(73, 13);
            this.loopNumLabel.TabIndex = 16;
            this.loopNumLabel.Text = "Num of Loops";
            // 
            // acqTypeComboBox
            // 
            this.acqTypeComboBox.FormattingEnabled = true;
            this.acqTypeComboBox.Items.AddRange(new object[] {
            "Single",
            "Multi"});
            this.acqTypeComboBox.Location = new System.Drawing.Point(19, 509);
            this.acqTypeComboBox.Name = "acqTypeComboBox";
            this.acqTypeComboBox.Size = new System.Drawing.Size(85, 21);
            this.acqTypeComboBox.TabIndex = 17;
            // 
            // startAcqButton
            // 
            this.startAcqButton.Location = new System.Drawing.Point(731, 109);
            this.startAcqButton.Name = "startAcqButton";
            this.startAcqButton.Size = new System.Drawing.Size(125, 59);
            this.startAcqButton.TabIndex = 18;
            this.startAcqButton.Text = "Start Acquisition";
            this.startAcqButton.UseVisualStyleBackColor = true;
            this.startAcqButton.Click += new System.EventHandler(this.startAcqButton_Click);
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 558);
            this.Controls.Add(this.startAcqButton);
            this.Controls.Add(this.acqTypeComboBox);
            this.Controls.Add(this.loopNumLabel);
            this.Controls.Add(this.repeatLabel);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.numLoopsUpDown);
            this.Controls.Add(this.numRepeatsUpDown);
            this.Controls.Add(this.threshUpDown);
            this.Controls.Add(this.subImaging);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTrigger);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.NumberOfIons);
            this.Controls.Add(this.numIonsUpDown);
            this.Controls.Add(this.ShutDown);
            this.Controls.Add(this.Shutter);
            this.Name = "CameraForm";
            this.Text = "Camera Controller";
            this.Load += new System.EventHandler(this.CameraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numIonsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.subImaging.ResumeLayout(false);
            this.subImaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vertEndUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verStartUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horEndUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horStartUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoopsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Shutter;
        private System.Windows.Forms.Button ShutDown;
        private System.Windows.Forms.NumericUpDown numIonsUpDown;
        private System.Windows.Forms.Label NumberOfIons;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTrigger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel subImaging;
        private System.Windows.Forms.Label verticalEndLabel;
        private System.Windows.Forms.Label vertEndLabel;
        private System.Windows.Forms.Label horizEndLabel;
        private System.Windows.Forms.Label horizStartLabel;
        private System.Windows.Forms.NumericUpDown vertEndUpDown;
        private System.Windows.Forms.NumericUpDown verStartUpDown;
        private System.Windows.Forms.NumericUpDown horEndUpDown;
        private System.Windows.Forms.NumericUpDown horStartUpDown;
        private System.Windows.Forms.NumericUpDown threshUpDown;
        private System.Windows.Forms.NumericUpDown numRepeatsUpDown;
        private System.Windows.Forms.NumericUpDown numLoopsUpDown;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.Label loopNumLabel;
        private System.Windows.Forms.ComboBox acqTypeComboBox;
        private System.Windows.Forms.Button startAcqButton;
    }
}

