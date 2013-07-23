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

        

        // Code modified by SW - create combo boxes depending on number of interleaved spectra
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newSpectrumNameBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.addNewSpectrumButton = new System.Windows.Forms.Button();
            this.detectedSpectraText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newSpectrumNameBox
            // 
            this.newSpectrumNameBox.Location = new System.Drawing.Point(12, 214);
            this.newSpectrumNameBox.Name = "newSpectrumNameBox";
            this.newSpectrumNameBox.Size = new System.Drawing.Size(186, 20);
            this.newSpectrumNameBox.TabIndex = 2;
            this.newSpectrumNameBox.Text = "Enter spectrum name";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(295, 201);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(206, 62);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // addNewSpectrumButton
            // 
            this.addNewSpectrumButton.Location = new System.Drawing.Point(12, 240);
            this.addNewSpectrumButton.Name = "addNewSpectrumButton";
            this.addNewSpectrumButton.Size = new System.Drawing.Size(116, 23);
            this.addNewSpectrumButton.TabIndex = 7;
            this.addNewSpectrumButton.Text = "Add new spectrum";
            this.addNewSpectrumButton.UseVisualStyleBackColor = true;
            this.addNewSpectrumButton.Click += new System.EventHandler(this.addNewSpectrumButton_Click);
            // 
            // detectedSpectraText
            // 
            this.detectedSpectraText.AutoSize = true;
            this.detectedSpectraText.Location = new System.Drawing.Point(12, 9);
            this.detectedSpectraText.Name = "detectedSpectraText";
            this.detectedSpectraText.Size = new System.Drawing.Size(35, 13);
            this.detectedSpectraText.TabIndex = 8;
            this.detectedSpectraText.Text = "label2";
            // 
            // spectrumSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 278);
            this.Controls.Add(this.detectedSpectraText);
            this.Controls.Add(this.addNewSpectrumButton);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.newSpectrumNameBox);
            this.Name = "spectrumSelect";
            this.Text = "Choose spectrum";
            this.ResumeLayout(false);
            this.PerformLayout();
            


        }

        #endregion



        private System.Windows.Forms.TextBox newSpectrumNameBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button addNewSpectrumButton;
        private System.Windows.Forms.Label detectedSpectraText;
    }
}