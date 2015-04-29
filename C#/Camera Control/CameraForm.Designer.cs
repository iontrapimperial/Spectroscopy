namespace Camera_Control
{
    partial class CameraForm
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
            this.Shutter = new System.Windows.Forms.Button();
            this.ShutDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Shutter
            // 
            this.Shutter.Location = new System.Drawing.Point(730, 12);
            this.Shutter.Name = "Shutter";
            this.Shutter.Size = new System.Drawing.Size(127, 72);
            this.Shutter.TabIndex = 0;
            this.Shutter.Text = "Shutter";
            this.Shutter.UseVisualStyleBackColor = true;
            this.Shutter.Click += new System.EventHandler(this.Shutter_Click);
            // 
            // ShutDown
            // 
            this.ShutDown.Location = new System.Drawing.Point(737, 113);
            this.ShutDown.Name = "ShutDown";
            this.ShutDown.Size = new System.Drawing.Size(119, 72);
            this.ShutDown.TabIndex = 1;
            this.ShutDown.Text = "Shut Down";
            this.ShutDown.UseVisualStyleBackColor = true;
            this.ShutDown.Click += new System.EventHandler(this.ShutDown_Click);
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 558);
            this.Controls.Add(this.ShutDown);
            this.Controls.Add(this.Shutter);
            this.Name = "CameraForm";
            this.Text = "Camera Controller";
            this.Load += new System.EventHandler(this.CameraForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Shutter;
        private System.Windows.Forms.Button ShutDown;
    }
}

