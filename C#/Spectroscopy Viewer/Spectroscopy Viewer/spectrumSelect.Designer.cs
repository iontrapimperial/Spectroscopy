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
            this.spectrumSelectList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spectrumSelectList
            // 
            this.spectrumSelectList.FormattingEnabled = true;
            this.spectrumSelectList.Location = new System.Drawing.Point(12, 12);
            this.spectrumSelectList.Name = "spectrumSelectList";
            this.spectrumSelectList.Size = new System.Drawing.Size(187, 186);
            this.spectrumSelectList.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add to spectrum";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // spectrumSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 252);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spectrumSelectList);
            this.Name = "spectrumSelect";
            this.Text = "Choose spectrum";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox spectrumSelectList;
        private System.Windows.Forms.Button button1;
    }
}