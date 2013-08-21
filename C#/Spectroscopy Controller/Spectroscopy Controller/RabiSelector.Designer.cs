namespace Spectroscopy_Controller
{
    partial class RabiSelector
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
            this.pulseSelectBox = new System.Windows.Forms.CheckedListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.startLengthTicksLabel = new System.Windows.Forms.Label();
            this.stepSizeTicksLabel = new System.Windows.Forms.Label();
            this.repeatsLabel = new System.Windows.Forms.Label();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.startLengthSelect = new System.Windows.Forms.NumericUpDown();
            this.stepSizeSelect = new System.Windows.Forms.NumericUpDown();
            this.repeatsSelect = new System.Windows.Forms.NumericUpDown();
            this.stepsSelect = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endLengthLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.startLengthLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.startLengthSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatsSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsSelect)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pulseSelectBox
            // 
            this.pulseSelectBox.FormattingEnabled = true;
            this.pulseSelectBox.Location = new System.Drawing.Point(6, 16);
            this.pulseSelectBox.Name = "pulseSelectBox";
            this.pulseSelectBox.Size = new System.Drawing.Size(167, 169);
            this.pulseSelectBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(258, 165);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(385, 165);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // startLengthTicksLabel
            // 
            this.startLengthTicksLabel.AutoSize = true;
            this.startLengthTicksLabel.Location = new System.Drawing.Point(65, 16);
            this.startLengthTicksLabel.Name = "startLengthTicksLabel";
            this.startLengthTicksLabel.Size = new System.Drawing.Size(95, 13);
            this.startLengthTicksLabel.TabIndex = 3;
            this.startLengthTicksLabel.Text = "Start length (ticks):";
            // 
            // stepSizeTicksLabel
            // 
            this.stepSizeTicksLabel.AutoSize = true;
            this.stepSizeTicksLabel.Location = new System.Drawing.Point(76, 43);
            this.stepSizeTicksLabel.Name = "stepSizeTicksLabel";
            this.stepSizeTicksLabel.Size = new System.Drawing.Size(84, 13);
            this.stepSizeTicksLabel.TabIndex = 4;
            this.stepSizeTicksLabel.Text = "Step size (ticks):";
            // 
            // repeatsLabel
            // 
            this.repeatsLabel.AutoSize = true;
            this.repeatsLabel.Location = new System.Drawing.Point(32, 70);
            this.repeatsLabel.Name = "repeatsLabel";
            this.repeatsLabel.Size = new System.Drawing.Size(128, 13);
            this.repeatsLabel.TabIndex = 5;
            this.repeatsLabel.Text = "Number of repeats / step:";
            // 
            // stepsLabel
            // 
            this.stepsLabel.AutoSize = true;
            this.stepsLabel.Location = new System.Drawing.Point(8, 96);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(152, 13);
            this.stepsLabel.TabIndex = 6;
            this.stepsLabel.Text = "Number of steps in experiment:";
            // 
            // startLengthSelect
            // 
            this.startLengthSelect.Location = new System.Drawing.Point(166, 14);
            this.startLengthSelect.Name = "startLengthSelect";
            this.startLengthSelect.Size = new System.Drawing.Size(81, 20);
            this.startLengthSelect.TabIndex = 7;
            this.startLengthSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // stepSizeSelect
            // 
            this.stepSizeSelect.Location = new System.Drawing.Point(166, 41);
            this.stepSizeSelect.Name = "stepSizeSelect";
            this.stepSizeSelect.Size = new System.Drawing.Size(81, 20);
            this.stepSizeSelect.TabIndex = 8;
            this.stepSizeSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // repeatsSelect
            // 
            this.repeatsSelect.Location = new System.Drawing.Point(166, 68);
            this.repeatsSelect.Name = "repeatsSelect";
            this.repeatsSelect.Size = new System.Drawing.Size(81, 20);
            this.repeatsSelect.TabIndex = 9;
            this.repeatsSelect.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // stepsSelect
            // 
            this.stepsSelect.Location = new System.Drawing.Point(166, 94);
            this.stepsSelect.Name = "stepsSelect";
            this.stepsSelect.Size = new System.Drawing.Size(81, 20);
            this.stepsSelect.TabIndex = 10;
            this.stepsSelect.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endLengthLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.startLengthLabel);
            this.groupBox1.Controls.Add(this.startLengthTicksLabel);
            this.groupBox1.Controls.Add(this.stepsSelect);
            this.groupBox1.Controls.Add(this.stepSizeTicksLabel);
            this.groupBox1.Controls.Add(this.repeatsSelect);
            this.groupBox1.Controls.Add(this.repeatsLabel);
            this.groupBox1.Controls.Add(this.stepSizeSelect);
            this.groupBox1.Controls.Add(this.stepsLabel);
            this.groupBox1.Controls.Add(this.startLengthSelect);
            this.groupBox1.Location = new System.Drawing.Point(199, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 125);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sweep parameters";
            // 
            // endLengthLabel
            // 
            this.endLengthLabel.AutoSize = true;
            this.endLengthLabel.Location = new System.Drawing.Point(254, 95);
            this.endLengthLabel.Name = "endLengthLabel";
            this.endLengthLabel.Size = new System.Drawing.Size(58, 13);
            this.endLengthLabel.TabIndex = 13;
            this.endLengthLabel.Text = "End length";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "stepSize";
            // 
            // startLengthLabel
            // 
            this.startLengthLabel.AutoSize = true;
            this.startLengthLabel.Location = new System.Drawing.Point(253, 16);
            this.startLengthLabel.Name = "startLengthLabel";
            this.startLengthLabel.Size = new System.Drawing.Size(60, 13);
            this.startLengthLabel.TabIndex = 11;
            this.startLengthLabel.Text = "startLength";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pulseSelectBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 193);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pulses to sweep";
            // 
            // RabiSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 216);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "RabiSelector";
            this.Text = "Select sequence options";
            ((System.ComponentModel.ISupportInitialize)(this.startLengthSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatsSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsSelect)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox pulseSelectBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label startLengthTicksLabel;
        private System.Windows.Forms.Label stepSizeTicksLabel;
        private System.Windows.Forms.Label repeatsLabel;
        private System.Windows.Forms.Label stepsLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label startLengthLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label endLengthLabel;
        public System.Windows.Forms.NumericUpDown startLengthSelect;
        public System.Windows.Forms.NumericUpDown stepSizeSelect;
        public System.Windows.Forms.NumericUpDown repeatsSelect;
        public System.Windows.Forms.NumericUpDown stepsSelect;
    }
}