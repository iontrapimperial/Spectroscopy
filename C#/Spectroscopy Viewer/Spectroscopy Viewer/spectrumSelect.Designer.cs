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
            this.addToSpectrumButton = new System.Windows.Forms.Button();
            this.newSpectrumNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addNewSpectrumButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spectrumSelectList
            // 
            this.spectrumSelectList.FormattingEnabled = true;
            this.spectrumSelectList.Location = new System.Drawing.Point(12, 12);
            this.spectrumSelectList.Name = "spectrumSelectList";
            this.spectrumSelectList.Size = new System.Drawing.Size(187, 134);
            this.spectrumSelectList.TabIndex = 0;
            // 
            // addToSpectrumButton
            // 
            this.addToSpectrumButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addToSpectrumButton.Location = new System.Drawing.Point(12, 170);
            this.addToSpectrumButton.Name = "addToSpectrumButton";
            this.addToSpectrumButton.Size = new System.Drawing.Size(187, 36);
            this.addToSpectrumButton.TabIndex = 1;
            this.addToSpectrumButton.Text = "Add to spectrum";
            this.addToSpectrumButton.UseVisualStyleBackColor = true;
            this.addToSpectrumButton.Click += new System.EventHandler(this.addToSpectrumButton_Click);
            // 
            // newSpectrumNameBox
            // 
            this.newSpectrumNameBox.Location = new System.Drawing.Point(234, 31);
            this.newSpectrumNameBox.Name = "newSpectrumNameBox";
            this.newSpectrumNameBox.Size = new System.Drawing.Size(186, 20);
            this.newSpectrumNameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter name of new spectrum:";
            // 
            // addNewSpectrumButton
            // 
            this.addNewSpectrumButton.Location = new System.Drawing.Point(234, 58);
            this.addNewSpectrumButton.Name = "addNewSpectrumButton";
            this.addNewSpectrumButton.Size = new System.Drawing.Size(75, 23);
            this.addNewSpectrumButton.TabIndex = 4;
            this.addNewSpectrumButton.Text = "Add to list";
            this.addNewSpectrumButton.UseVisualStyleBackColor = true;
            this.addNewSpectrumButton.Click += new System.EventHandler(this.addNewSpectrumButton_Click);
            // 
            // spectrumSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 420);
            this.Controls.Add(this.addNewSpectrumButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newSpectrumNameBox);
            this.Controls.Add(this.addToSpectrumButton);
            this.Controls.Add(this.spectrumSelectList);
            this.Name = "spectrumSelect";
            this.Text = "Choose spectrum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox spectrumSelectList;
        private System.Windows.Forms.Button addToSpectrumButton;
        private System.Windows.Forms.TextBox newSpectrumNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addNewSpectrumButton;
    }
}