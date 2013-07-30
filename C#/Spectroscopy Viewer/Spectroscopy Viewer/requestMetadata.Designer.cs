namespace Spectroscopy_Viewer
{
    partial class requestMetadata
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
            this.label1 = new System.Windows.Forms.Label();
            this.startFreqBox = new System.Windows.Forms.TextBox();
            this.stepSizeBox = new System.Windows.Forms.TextBox();
            this.repeatsBox = new System.Windows.Forms.TextBox();
            this.numberInterleavedBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openingFileText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(90, 213);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(76, 24);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "AOM start frequency:";
            // 
            // startFreqBox
            // 
            this.startFreqBox.Location = new System.Drawing.Point(139, 109);
            this.startFreqBox.Name = "startFreqBox";
            this.startFreqBox.Size = new System.Drawing.Size(100, 20);
            this.startFreqBox.TabIndex = 2;
            this.startFreqBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
            // 
            // stepSizeBox
            // 
            this.stepSizeBox.Location = new System.Drawing.Point(139, 135);
            this.stepSizeBox.Name = "stepSizeBox";
            this.stepSizeBox.Size = new System.Drawing.Size(100, 20);
            this.stepSizeBox.TabIndex = 3;
            this.stepSizeBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
            // 
            // repeatsBox
            // 
            this.repeatsBox.Location = new System.Drawing.Point(139, 161);
            this.repeatsBox.Name = "repeatsBox";
            this.repeatsBox.Size = new System.Drawing.Size(100, 20);
            this.repeatsBox.TabIndex = 4;
            this.repeatsBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
            // 
            // numberInterleavedBox
            // 
            this.numberInterleavedBox.Location = new System.Drawing.Point(139, 187);
            this.numberInterleavedBox.Name = "numberInterleavedBox";
            this.numberInterleavedBox.Size = new System.Drawing.Size(100, 20);
            this.numberInterleavedBox.TabIndex = 5;
            this.numberInterleavedBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Step size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of repeats:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of spectra in file:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "! WARNING !";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 57);
            this.label6.MaximumSize = new System.Drawing.Size(250, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 39);
            this.label6.TabIndex = 10;
            this.label6.Text = "The file you are about to open contains no metadata. Beware of opening windowed f" +
                "iles! Please enter the following information:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // openingFileText
            // 
            this.openingFileText.AutoSize = true;
            this.openingFileText.Location = new System.Drawing.Point(21, 35);
            this.openingFileText.Name = "openingFileText";
            this.openingFileText.Size = new System.Drawing.Size(69, 13);
            this.openingFileText.TabIndex = 12;
            this.openingFileText.Text = "Opening file: ";
            // 
            // requestMetadata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 243);
            this.Controls.Add(this.openingFileText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberInterleavedBox);
            this.Controls.Add(this.repeatsBox);
            this.Controls.Add(this.stepSizeBox);
            this.Controls.Add(this.startFreqBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Name = "requestMetadata";
            this.Text = "Spectrum metadata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox startFreqBox;
        private System.Windows.Forms.TextBox stepSizeBox;
        private System.Windows.Forms.TextBox repeatsBox;
        private System.Windows.Forms.TextBox numberInterleavedBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label openingFileText;
    }
}