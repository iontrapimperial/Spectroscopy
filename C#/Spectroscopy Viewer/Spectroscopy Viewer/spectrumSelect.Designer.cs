namespace Spectroscopy_Viewer
{
    partial class spectrumSelect
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
            this.newSpectrumNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.addNewSpectrumButton = new System.Windows.Forms.Button();
            this.detectedSpectraText = new System.Windows.Forms.Label();
            this.detectedFilesText = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newSpectrumNameBox
            // 
            this.newSpectrumNameBox.Location = new System.Drawing.Point(12, 173);
            this.newSpectrumNameBox.Name = "newSpectrumNameBox";
            this.newSpectrumNameBox.Size = new System.Drawing.Size(186, 20);
            this.newSpectrumNameBox.TabIndex = 3;
            this.newSpectrumNameBox.Text = "Enter spectrum name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please enter name of new spectrum:";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(292, 151);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(178, 63);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // addNewSpectrumButton
            // 
            this.addNewSpectrumButton.Location = new System.Drawing.Point(12, 199);
            this.addNewSpectrumButton.Name = "addNewSpectrumButton";
            this.addNewSpectrumButton.Size = new System.Drawing.Size(116, 23);
            this.addNewSpectrumButton.TabIndex = 4;
            this.addNewSpectrumButton.Text = "Add new spectrum";
            this.addNewSpectrumButton.UseVisualStyleBackColor = true;
            this.addNewSpectrumButton.Click += new System.EventHandler(this.addNewSpectrumButton_Click);
            // 
            // detectedSpectraText
            // 
            this.detectedSpectraText.AutoSize = true;
            this.detectedSpectraText.Location = new System.Drawing.Point(12, 53);
            this.detectedSpectraText.Name = "detectedSpectraText";
            this.detectedSpectraText.Size = new System.Drawing.Size(126, 13);
            this.detectedSpectraText.TabIndex = 1;
            this.detectedSpectraText.Text = "Text for detected spectra";
            // 
            // detectedFilesText
            // 
            this.detectedFilesText.AutoSize = true;
            this.detectedFilesText.Location = new System.Drawing.Point(12, 13);
            this.detectedFilesText.Name = "detectedFilesText";
            this.detectedFilesText.Size = new System.Drawing.Size(109, 13);
            this.detectedFilesText.TabIndex = 11;
            this.detectedFilesText.Text = "Text for detected files";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(485, 151);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 63);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // spectrumSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 229);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.detectedFilesText);
            this.Controls.Add(this.detectedSpectraText);
            this.Controls.Add(this.addNewSpectrumButton);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newSpectrumNameBox);
            this.Name = "spectrumSelect";
            this.Text = "Choose spectrum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newSpectrumNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button addNewSpectrumButton;
        private System.Windows.Forms.Label detectedSpectraText;
        private System.Windows.Forms.Label detectedFilesText;
        private System.Windows.Forms.Button buttonCancel;
    }
}