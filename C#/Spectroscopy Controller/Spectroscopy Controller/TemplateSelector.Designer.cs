using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectroscopy_Controller
{
    partial class TemplateSelector
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SideBandsAcceptButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SidebandNumRepeats = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.NumFrequencies = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.StepLength = new System.Windows.Forms.Label();
            this.MaxPulseLength = new System.Windows.Forms.Label();
            this.MinPulseLength = new System.Windows.Forms.Label();
            this.RabiAcceptButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.RabiNumRepeats = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.RabiPulseStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.RabiMaxLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.RabiMinLength = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SidebandNumRepeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumFrequencies)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RabiNumRepeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RabiPulseStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RabiMaxLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RabiMinLength)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(303, 173);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SideBandsAcceptButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SidebandNumRepeats);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.NumFrequencies);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(295, 147);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sidebands";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // SideBandsAcceptButton
            // 
            this.SideBandsAcceptButton.Location = new System.Drawing.Point(110, 104);
            this.SideBandsAcceptButton.Name = "SideBandsAcceptButton";
            this.SideBandsAcceptButton.Size = new System.Drawing.Size(75, 23);
            this.SideBandsAcceptButton.TabIndex = 4;
            this.SideBandsAcceptButton.Text = "OK";
            this.SideBandsAcceptButton.UseVisualStyleBackColor = true;
            this.SideBandsAcceptButton.Click += new System.EventHandler(this.SideBandsAcceptButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Runs at Each Frequency:";
            // 
            // SidebandNumRepeats
            // 
            this.SidebandNumRepeats.Location = new System.Drawing.Point(208, 65);
            this.SidebandNumRepeats.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SidebandNumRepeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SidebandNumRepeats.Name = "SidebandNumRepeats";
            this.SidebandNumRepeats.Size = new System.Drawing.Size(54, 20);
            this.SidebandNumRepeats.TabIndex = 2;
            this.SidebandNumRepeats.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Frequencies:";
            // 
            // NumFrequencies
            // 
            this.NumFrequencies.Location = new System.Drawing.Point(208, 25);
            this.NumFrequencies.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumFrequencies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumFrequencies.Name = "NumFrequencies";
            this.NumFrequencies.Size = new System.Drawing.Size(54, 20);
            this.NumFrequencies.TabIndex = 0;
            this.NumFrequencies.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.StepLength);
            this.tabPage2.Controls.Add(this.MaxPulseLength);
            this.tabPage2.Controls.Add(this.MinPulseLength);
            this.tabPage2.Controls.Add(this.RabiAcceptButton);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.RabiNumRepeats);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.RabiPulseStep);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.RabiMaxLength);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.RabiMinLength);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(295, 147);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rabi Frequency";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StepLength
            // 
            this.StepLength.AutoSize = true;
            this.StepLength.Location = new System.Drawing.Point(217, 66);
            this.StepLength.Name = "StepLength";
            this.StepLength.Size = new System.Drawing.Size(35, 13);
            this.StepLength.TabIndex = 11;
            this.StepLength.Text = "(0 ms)";
            // 
            // MaxPulseLength
            // 
            this.MaxPulseLength.AutoSize = true;
            this.MaxPulseLength.Location = new System.Drawing.Point(182, 40);
            this.MaxPulseLength.Name = "MaxPulseLength";
            this.MaxPulseLength.Size = new System.Drawing.Size(35, 13);
            this.MaxPulseLength.TabIndex = 10;
            this.MaxPulseLength.Text = "(0 ms)";
            // 
            // MinPulseLength
            // 
            this.MinPulseLength.AutoSize = true;
            this.MinPulseLength.Location = new System.Drawing.Point(182, 13);
            this.MinPulseLength.Name = "MinPulseLength";
            this.MinPulseLength.Size = new System.Drawing.Size(35, 13);
            this.MinPulseLength.TabIndex = 9;
            this.MinPulseLength.Text = "(0 ms)";
            // 
            // RabiAcceptButton
            // 
            this.RabiAcceptButton.Location = new System.Drawing.Point(110, 114);
            this.RabiAcceptButton.Name = "RabiAcceptButton";
            this.RabiAcceptButton.Size = new System.Drawing.Size(75, 23);
            this.RabiAcceptButton.TabIndex = 8;
            this.RabiAcceptButton.Text = "OK";
            this.RabiAcceptButton.UseVisualStyleBackColor = true;
            this.RabiAcceptButton.Click += new System.EventHandler(this.RabiAcceptButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Number of Runs at Each Length:";
            // 
            // RabiNumRepeats
            // 
            this.RabiNumRepeats.Location = new System.Drawing.Point(197, 88);
            this.RabiNumRepeats.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.RabiNumRepeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RabiNumRepeats.Name = "RabiNumRepeats";
            this.RabiNumRepeats.Size = new System.Drawing.Size(78, 20);
            this.RabiNumRepeats.TabIndex = 6;
            this.RabiNumRepeats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Step Between Pulse Lengths:";
            // 
            // RabiPulseStep
            // 
            this.RabiPulseStep.Location = new System.Drawing.Point(156, 62);
            this.RabiPulseStep.Maximum = new decimal(new int[] {
            16777215,
            0,
            0,
            0});
            this.RabiPulseStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RabiPulseStep.Name = "RabiPulseStep";
            this.RabiPulseStep.Size = new System.Drawing.Size(61, 20);
            this.RabiPulseStep.TabIndex = 4;
            this.RabiPulseStep.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RabiPulseStep.ValueChanged += new System.EventHandler(this.RabiPulseStep_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Maximum Length:";
            // 
            // RabiMaxLength
            // 
            this.RabiMaxLength.Location = new System.Drawing.Point(98, 36);
            this.RabiMaxLength.Maximum = new decimal(new int[] {
            16777215,
            0,
            0,
            0});
            this.RabiMaxLength.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.RabiMaxLength.Name = "RabiMaxLength";
            this.RabiMaxLength.Size = new System.Drawing.Size(78, 20);
            this.RabiMaxLength.TabIndex = 2;
            this.RabiMaxLength.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RabiMaxLength.ValueChanged += new System.EventHandler(this.RabiMaxLength_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Starting Length:";
            // 
            // RabiMinLength
            // 
            this.RabiMinLength.Location = new System.Drawing.Point(98, 10);
            this.RabiMinLength.Maximum = new decimal(new int[] {
            16777214,
            0,
            0,
            0});
            this.RabiMinLength.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.RabiMinLength.Name = "RabiMinLength";
            this.RabiMinLength.Size = new System.Drawing.Size(78, 20);
            this.RabiMinLength.TabIndex = 0;
            this.RabiMinLength.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.RabiMinLength.ValueChanged += new System.EventHandler(this.RabiMinLength_ValueChanged);
            // 
            // TemplateSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 197);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(343, 235);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(343, 235);
            this.Name = "TemplateSelector";
            this.Text = "TemplateSelector";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SidebandNumRepeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumFrequencies)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RabiNumRepeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RabiPulseStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RabiMaxLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RabiMinLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SidebandNumRepeats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumFrequencies;
        private System.Windows.Forms.Button SideBandsAcceptButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RabiMaxLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RabiMinLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown RabiPulseStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown RabiNumRepeats;
        private System.Windows.Forms.Button RabiAcceptButton;
        private System.Windows.Forms.Label MinPulseLength;
        private System.Windows.Forms.Label MaxPulseLength;
        private System.Windows.Forms.Label StepLength;
    }
}
