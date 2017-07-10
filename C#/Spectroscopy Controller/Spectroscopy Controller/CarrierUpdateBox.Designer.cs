namespace Spectroscopy_Viewer
{
    partial class carrierSpectrumDialog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.oldCarrierBox = new System.Windows.Forms.NumericUpDown();
            this.newCarrierBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.oldCarrierBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newCarrierBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.Location = new System.Drawing.Point(177, 39);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Set Carrier";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.buttonCancel.Location = new System.Drawing.Point(53, 39);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(312, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Set Carrier/Profiles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 15);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(118, 13);
            this.label26.TabIndex = 68;
            this.label26.Text = "Old Car Frq (MHz AOM)";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "New Car Frq (MHz AOM)";
            // 
            // oldCarrierBox
            // 
            this.oldCarrierBox.DecimalPlaces = 5;
            this.oldCarrierBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.oldCarrierBox.Location = new System.Drawing.Point(134, 12);
            this.oldCarrierBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.oldCarrierBox.Name = "oldCarrierBox";
            this.oldCarrierBox.Size = new System.Drawing.Size(87, 20);
            this.oldCarrierBox.TabIndex = 70;
            this.oldCarrierBox.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            393216});
            this.oldCarrierBox.ValueChanged += new System.EventHandler(this.oldCarrierBox_ValueChanged);
            // 
            // newCarrierBox
            // 
            this.newCarrierBox.DecimalPlaces = 5;
            this.newCarrierBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.newCarrierBox.Location = new System.Drawing.Point(357, 13);
            this.newCarrierBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.newCarrierBox.Name = "newCarrierBox";
            this.newCarrierBox.Size = new System.Drawing.Size(87, 20);
            this.newCarrierBox.TabIndex = 71;
            this.newCarrierBox.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            393216});
            // 
            // carrierSpectrumDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 70);
            this.Controls.Add(this.newCarrierBox);
            this.Controls.Add(this.oldCarrierBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "carrierSpectrumDialog";
            this.Text = "Enter new carrier";
            ((System.ComponentModel.ISupportInitialize)(this.oldCarrierBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newCarrierBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown oldCarrierBox;
        public System.Windows.Forms.NumericUpDown newCarrierBox;
    }
}