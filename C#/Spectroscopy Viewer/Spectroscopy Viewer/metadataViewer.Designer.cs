namespace Spectroscopy_Viewer
{
    partial class metadataViewer
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
            this.components = new System.ComponentModel.Container();
            this.metadataGrid = new System.Windows.Forms.DataGridView();
            this.spectrumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.metadataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spectrumBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metadataGrid
            // 
            this.metadataGrid.AllowUserToAddRows = false;
            this.metadataGrid.AllowUserToDeleteRows = false;
            this.metadataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.metadataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metadataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Field,
            this.Value});
            this.metadataGrid.Location = new System.Drawing.Point(12, 12);
            this.metadataGrid.Name = "metadataGrid";
            this.metadataGrid.ReadOnly = true;
            this.metadataGrid.Size = new System.Drawing.Size(363, 443);
            this.metadataGrid.TabIndex = 0;
            // 
            // spectrumBindingSource
            // 
            this.spectrumBindingSource.DataSource = typeof(Spectroscopy_Viewer.spectrum);
            // 
            // Field
            // 
            this.Field.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Field.HeaderText = "Field";
            this.Field.Name = "Field";
            this.Field.ReadOnly = true;
            this.Field.Width = 180;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 140;
            // 
            // metadataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 467);
            this.Controls.Add(this.metadataGrid);
            this.Name = "metadataViewer";
            this.Text = "metadataViewer";
            ((System.ComponentModel.ISupportInitialize)(this.metadataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spectrumBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView metadataGrid;
        private System.Windows.Forms.BindingSource spectrumBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}