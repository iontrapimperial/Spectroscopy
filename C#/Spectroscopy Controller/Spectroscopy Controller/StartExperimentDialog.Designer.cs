namespace Spectroscopy_Controller
{
    partial class StartExperimentDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.ExperimentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberOfRepeats = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.NumberOfSpectra = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ChooseFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NotesBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfRepeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfSpectra)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please specify:";
            // 
            // ExperimentName
            // 
            this.ExperimentName.Location = new System.Drawing.Point(112, 37);
            this.ExperimentName.Name = "ExperimentName";
            this.ExperimentName.Size = new System.Drawing.Size(115, 20);
            this.ExperimentName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Experiment name:";
            // 
            // NumberOfRepeats
            // 
            this.NumberOfRepeats.Location = new System.Drawing.Point(112, 72);
            this.NumberOfRepeats.Name = "NumberOfRepeats";
            this.NumberOfRepeats.Size = new System.Drawing.Size(115, 20);
            this.NumberOfRepeats.TabIndex = 3;
            this.NumberOfRepeats.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Repeats:";
            // 
            // NumberOfSpectra
            // 
            this.NumberOfSpectra.Location = new System.Drawing.Point(112, 102);
            this.NumberOfSpectra.Name = "NumberOfSpectra";
            this.NumberOfSpectra.Size = new System.Drawing.Size(115, 20);
            this.NumberOfSpectra.TabIndex = 5;
            this.NumberOfSpectra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberOfSpectra.ValueChanged += new System.EventHandler(this.NumberOfSpectra_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Number of spectra:";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(233, 157);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(358, 157);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ChooseFolderDialog
            // 
            this.ChooseFolderDialog.Description = "Choose where to save readings file(s)";
            this.ChooseFolderDialog.SelectedPath = "Z:/Data";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(246, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(163, 138);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spectrum names";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NotesBox);
            this.groupBox2.Location = new System.Drawing.Point(417, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 138);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notes";
            // 
            // NotesBox
            // 
            this.NotesBox.Location = new System.Drawing.Point(7, 18);
            this.NotesBox.Multiline = true;
            this.NotesBox.Name = "NotesBox";
            this.NotesBox.Size = new System.Drawing.Size(187, 114);
            this.NotesBox.TabIndex = 0;
            // 
            // StartExperimentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 192);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumberOfSpectra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumberOfRepeats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExperimentName);
            this.Controls.Add(this.label1);
            this.Name = "StartExperimentDialog";
            this.Text = "Starting experiment...";
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfRepeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfSpectra)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.FolderBrowserDialog ChooseFolderDialog;
        public System.Windows.Forms.TextBox ExperimentName;
        public System.Windows.Forms.NumericUpDown NumberOfRepeats;
        public System.Windows.Forms.NumericUpDown NumberOfSpectra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox NotesBox;
    }
}