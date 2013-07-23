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
            this.spectrumSelectDataGrid = new System.Windows.Forms.DataGridView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.addNewSpectrumButton = new System.Windows.Forms.Button();
            this.SourceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spectrumSelectDataGrid)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter name of new spectrum:";
            // 
            // spectrumSelectDataGrid
            // 
            this.spectrumSelectDataGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.spectrumSelectDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spectrumSelectDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceColumn,
            this.DestinationColumn});
            this.spectrumSelectDataGrid.Location = new System.Drawing.Point(12, 12);
            this.spectrumSelectDataGrid.Name = "spectrumSelectDataGrid";
            this.spectrumSelectDataGrid.Size = new System.Drawing.Size(491, 180);
            this.spectrumSelectDataGrid.TabIndex = 5;
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
            // SourceColumn
            // 
            this.SourceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SourceColumn.FillWeight = 200F;
            this.SourceColumn.HeaderText = "Source";
            this.SourceColumn.Name = "SourceColumn";
            this.SourceColumn.ReadOnly = true;
            // 
            // DestinationColumn
            // 
            this.DestinationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DestinationColumn.FillWeight = 250F;
            this.DestinationColumn.HeaderText = "Destination";
            this.DestinationColumn.Name = "DestinationColumn";
            // 
            // spectrumSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 278);
            this.Controls.Add(this.addNewSpectrumButton);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.spectrumSelectDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newSpectrumNameBox);
            this.Name = "spectrumSelect";
            this.Text = "Choose spectrum";
            ((System.ComponentModel.ISupportInitialize)(this.spectrumSelectDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newSpectrumNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView spectrumSelectDataGrid;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button addNewSpectrumButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DestinationColumn;
    }
}