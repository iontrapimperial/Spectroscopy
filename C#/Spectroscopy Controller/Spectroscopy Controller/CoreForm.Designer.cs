namespace Spectroscopy_Controller
{
    partial class CoreForm
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
            System.Windows.Forms.GroupBox FileSendBox;
            System.Windows.Forms.Label LoopNumberLabel;
            System.Windows.Forms.Label DesiredLengthLabel;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label LoopNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoreForm));
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.PulseTree = new System.Windows.Forms.TreeView();
            this.AddChildButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.AddRootButton = new System.Windows.Forms.Button();
            this.SaveStateButton = new System.Windows.Forms.Button();
            this.PulseTypeTabs = new System.Windows.Forms.TabControl();
            this.LoopTabPage = new System.Windows.Forms.TabPage();
            this.FPGALoopSelect = new System.Windows.Forms.CheckBox();
            this.LoopNumberBox = new System.Windows.Forms.NumericUpDown();
            this.PulseTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceSelect729 = new System.Windows.Forms.NumericUpDown();
            this.LaserBoxAux2 = new System.Windows.Forms.CheckBox();
            this.LaserBoxAux1 = new System.Windows.Forms.CheckBox();
            this.LaserBox854FREQ = new System.Windows.Forms.CheckBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.TicksBox = new System.Windows.Forms.NumericUpDown();
            this.PulseTypeBox = new System.Windows.Forms.ComboBox();
            this.LaserBox854POWER = new System.Windows.Forms.CheckBox();
            this.LaserBox854 = new System.Windows.Forms.CheckBox();
            this.LaserBox729 = new System.Windows.Forms.CheckBox();
            this.LaserBox397B2 = new System.Windows.Forms.CheckBox();
            this.LaserBox397B1 = new System.Windows.Forms.CheckBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.CreateFromTemplateButton = new System.Windows.Forms.Button();
            this.OpenXMLButton = new System.Windows.Forms.Button();
            this.SaveXMLButton = new System.Windows.Forms.Button();
            this.BinaryCompileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DesignerGroup = new System.Windows.Forms.GroupBox();
            this.SpectroGroup = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.OpenUSBButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.magFreqBox = new System.Windows.Forms.NumericUpDown();
            this.UploadButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.modcycFreqBox = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.rfAmpBox = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.sbWidthBox = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.sbToScanBox = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.stepSizeBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.carFreqBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.startFreqBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.axFreqBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.specDirBox = new System.Windows.Forms.ComboBox();
            this.trapVBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.specTypeBox = new System.Windows.Forms.ComboBox();
            this.LaserControl = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SetRFSB3Button = new System.Windows.Forms.Button();
            this.SB3RFFreq = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.SB3RFAmp = new System.Windows.Forms.NumericUpDown();
            this.SB3RFSourceButton = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SetRFSB2Button = new System.Windows.Forms.Button();
            this.SB2RFFreq = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SB2RFAmp = new System.Windows.Forms.NumericUpDown();
            this.SB2RFSourceButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SetRFSB1Button = new System.Windows.Forms.Button();
            this.SB1RFFreq = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SB1RFAmp = new System.Windows.Forms.NumericUpDown();
            this.SB1RFSourceButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SetRFSpecButton = new System.Windows.Forms.Button();
            this.SpecRFFreq = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SpecRFAmp = new System.Windows.Forms.NumericUpDown();
            this.SpecRFSourceButton = new System.Windows.Forms.RadioButton();
            this.LiveLaserBoxAux2 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBoxAux1 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox854FREQ = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox854POWER = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox854 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox729 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox397B2 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox397B1 = new System.Windows.Forms.CheckBox();
            this.debugmessagebox = new System.Windows.Forms.GroupBox();
            this.MessagesBox = new System.Windows.Forms.ListView();
            this.saveXMLFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openXMLFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openHexFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveHexFileDialog = new System.Windows.Forms.SaveFileDialog();
            FileSendBox = new System.Windows.Forms.GroupBox();
            LoopNumberLabel = new System.Windows.Forms.Label();
            DesiredLengthLabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            LoopNameLabel = new System.Windows.Forms.Label();
            FileSendBox.SuspendLayout();
            this.PulseTypeTabs.SuspendLayout();
            this.LoopTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoopNumberBox)).BeginInit();
            this.PulseTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourceSelect729)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TicksBox)).BeginInit();
            this.DesignerGroup.SuspendLayout();
            this.SpectroGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.magFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modcycFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rfAmpBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbToScanBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trapVBox)).BeginInit();
            this.LaserControl.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SB3RFFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SB3RFAmp)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SB2RFFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SB2RFAmp)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SB1RFFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SB1RFAmp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpecRFFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecRFAmp)).BeginInit();
            this.debugmessagebox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileSendBox
            // 
            FileSendBox.AutoSize = true;
            FileSendBox.Controls.Add(this.ProgressLabel);
            FileSendBox.Location = new System.Drawing.Point(134, 343);
            FileSendBox.Name = "FileSendBox";
            FileSendBox.Size = new System.Drawing.Size(137, 58);
            FileSendBox.TabIndex = 49;
            FileSendBox.TabStop = false;
            FileSendBox.Text = "Binary File Upload";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(20, 23);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(85, 13);
            this.ProgressLabel.TabIndex = 43;
            this.ProgressLabel.Text = "No File Selected";
            // 
            // LoopNumberLabel
            // 
            LoopNumberLabel.AutoSize = true;
            LoopNumberLabel.Location = new System.Drawing.Point(37, 19);
            LoopNumberLabel.Name = "LoopNumberLabel";
            LoopNumberLabel.Size = new System.Drawing.Size(118, 13);
            LoopNumberLabel.TabIndex = 34;
            LoopNumberLabel.Text = "Number of times to loop";
            // 
            // DesiredLengthLabel
            // 
            DesiredLengthLabel.AutoSize = true;
            DesiredLengthLabel.Location = new System.Drawing.Point(84, 47);
            DesiredLengthLabel.Name = "DesiredLengthLabel";
            DesiredLengthLabel.Size = new System.Drawing.Size(123, 13);
            DesiredLengthLabel.TabIndex = 39;
            DesiredLengthLabel.Text = "Target Pulse Length (us)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(84, 8);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(31, 13);
            label4.TabIndex = 38;
            label4.Text = "Type";
            // 
            // LoopNameLabel
            // 
            LoopNameLabel.AutoSize = true;
            LoopNameLabel.Location = new System.Drawing.Point(269, 24);
            LoopNameLabel.Name = "LoopNameLabel";
            LoopNameLabel.Size = new System.Drawing.Size(38, 13);
            LoopNameLabel.TabIndex = 46;
            LoopNameLabel.Text = "Name:";
            // 
            // PulseTree
            // 
            this.PulseTree.Location = new System.Drawing.Point(12, 50);
            this.PulseTree.Name = "PulseTree";
            this.PulseTree.Size = new System.Drawing.Size(254, 415);
            this.PulseTree.TabIndex = 0;
            this.PulseTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PulseTree_AfterSelect);
            // 
            // AddChildButton
            // 
            this.AddChildButton.Location = new System.Drawing.Point(58, 21);
            this.AddChildButton.Name = "AddChildButton";
            this.AddChildButton.Size = new System.Drawing.Size(68, 23);
            this.AddChildButton.TabIndex = 44;
            this.AddChildButton.Text = "Add Child";
            this.AddChildButton.UseVisualStyleBackColor = true;
            this.AddChildButton.Click += new System.EventHandler(this.AddChildButton_Click);
            this.AddChildButton.MouseEnter += new System.EventHandler(this.AddChildButton_MouseEnter);
            this.AddChildButton.MouseLeave += new System.EventHandler(this.AddChildButton_MouseLeave);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(210, 21);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(56, 23);
            this.DeleteButton.TabIndex = 43;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(171, 21);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(33, 23);
            this.MoveDownButton.TabIndex = 42;
            this.MoveDownButton.Text = "↓";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(132, 21);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MoveUpButton.Size = new System.Drawing.Size(33, 23);
            this.MoveUpButton.TabIndex = 41;
            this.MoveUpButton.Text = "↑";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // AddRootButton
            // 
            this.AddRootButton.Location = new System.Drawing.Point(12, 21);
            this.AddRootButton.Name = "AddRootButton";
            this.AddRootButton.Size = new System.Drawing.Size(40, 23);
            this.AddRootButton.TabIndex = 40;
            this.AddRootButton.Text = "Add";
            this.AddRootButton.UseVisualStyleBackColor = true;
            this.AddRootButton.Click += new System.EventHandler(this.AddRootButton_Click);
            this.AddRootButton.MouseEnter += new System.EventHandler(this.AddRootButton_MouseEnter);
            this.AddRootButton.MouseLeave += new System.EventHandler(this.AddRootButton_MouseLeave);
            // 
            // SaveStateButton
            // 
            this.SaveStateButton.Location = new System.Drawing.Point(272, 297);
            this.SaveStateButton.Name = "SaveStateButton";
            this.SaveStateButton.Size = new System.Drawing.Size(216, 30);
            this.SaveStateButton.TabIndex = 48;
            this.SaveStateButton.Text = "Save Pulse";
            this.SaveStateButton.UseVisualStyleBackColor = true;
            this.SaveStateButton.Click += new System.EventHandler(this.SaveStateButton_Click);
            // 
            // PulseTypeTabs
            // 
            this.PulseTypeTabs.Controls.Add(this.LoopTabPage);
            this.PulseTypeTabs.Controls.Add(this.PulseTabPage);
            this.PulseTypeTabs.Location = new System.Drawing.Point(272, 50);
            this.PulseTypeTabs.Name = "PulseTypeTabs";
            this.PulseTypeTabs.SelectedIndex = 0;
            this.PulseTypeTabs.Size = new System.Drawing.Size(216, 245);
            this.PulseTypeTabs.TabIndex = 47;
            // 
            // LoopTabPage
            // 
            this.LoopTabPage.Controls.Add(this.FPGALoopSelect);
            this.LoopTabPage.Controls.Add(LoopNumberLabel);
            this.LoopTabPage.Controls.Add(this.LoopNumberBox);
            this.LoopTabPage.Location = new System.Drawing.Point(4, 22);
            this.LoopTabPage.Name = "LoopTabPage";
            this.LoopTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LoopTabPage.Size = new System.Drawing.Size(208, 219);
            this.LoopTabPage.TabIndex = 0;
            this.LoopTabPage.Text = "Create Loop";
            this.LoopTabPage.UseVisualStyleBackColor = true;
            // 
            // FPGALoopSelect
            // 
            this.FPGALoopSelect.AutoSize = true;
            this.FPGALoopSelect.Location = new System.Drawing.Point(40, 77);
            this.FPGALoopSelect.Name = "FPGALoopSelect";
            this.FPGALoopSelect.Size = new System.Drawing.Size(87, 17);
            this.FPGALoopSelect.TabIndex = 35;
            this.FPGALoopSelect.Text = "FPGA Loop?";
            this.FPGALoopSelect.UseVisualStyleBackColor = true;
            // 
            // LoopNumberBox
            // 
            this.LoopNumberBox.Location = new System.Drawing.Point(40, 37);
            this.LoopNumberBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.LoopNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LoopNumberBox.Name = "LoopNumberBox";
            this.LoopNumberBox.Size = new System.Drawing.Size(120, 20);
            this.LoopNumberBox.TabIndex = 34;
            this.LoopNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PulseTabPage
            // 
            this.PulseTabPage.Controls.Add(this.label1);
            this.PulseTabPage.Controls.Add(this.SourceSelect729);
            this.PulseTabPage.Controls.Add(this.LaserBoxAux2);
            this.PulseTabPage.Controls.Add(this.LaserBoxAux1);
            this.PulseTabPage.Controls.Add(this.LaserBox854FREQ);
            this.PulseTabPage.Controls.Add(this.TimeLabel);
            this.PulseTabPage.Controls.Add(DesiredLengthLabel);
            this.PulseTabPage.Controls.Add(label4);
            this.PulseTabPage.Controls.Add(this.TicksBox);
            this.PulseTabPage.Controls.Add(this.PulseTypeBox);
            this.PulseTabPage.Controls.Add(this.LaserBox854POWER);
            this.PulseTabPage.Controls.Add(this.LaserBox854);
            this.PulseTabPage.Controls.Add(this.LaserBox729);
            this.PulseTabPage.Controls.Add(this.LaserBox397B2);
            this.PulseTabPage.Controls.Add(this.LaserBox397B1);
            this.PulseTabPage.Location = new System.Drawing.Point(4, 22);
            this.PulseTabPage.Name = "PulseTabPage";
            this.PulseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PulseTabPage.Size = new System.Drawing.Size(208, 219);
            this.PulseTabPage.TabIndex = 1;
            this.PulseTabPage.Text = "Create Laser Pulse";
            this.PulseTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "729 RF Source Select";
            // 
            // SourceSelect729
            // 
            this.SourceSelect729.Location = new System.Drawing.Point(8, 191);
            this.SourceSelect729.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.SourceSelect729.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SourceSelect729.Name = "SourceSelect729";
            this.SourceSelect729.Size = new System.Drawing.Size(44, 20);
            this.SourceSelect729.TabIndex = 44;
            this.SourceSelect729.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LaserBoxAux2
            // 
            this.LaserBoxAux2.AutoSize = true;
            this.LaserBoxAux2.Location = new System.Drawing.Point(8, 168);
            this.LaserBoxAux2.Name = "LaserBoxAux2";
            this.LaserBoxAux2.Size = new System.Drawing.Size(75, 17);
            this.LaserBoxAux2.TabIndex = 43;
            this.LaserBoxAux2.Text = "Auxilliary 2";
            this.LaserBoxAux2.UseVisualStyleBackColor = true;
            // 
            // LaserBoxAux1
            // 
            this.LaserBoxAux1.AutoSize = true;
            this.LaserBoxAux1.Location = new System.Drawing.Point(8, 145);
            this.LaserBoxAux1.Name = "LaserBoxAux1";
            this.LaserBoxAux1.Size = new System.Drawing.Size(75, 17);
            this.LaserBoxAux1.TabIndex = 42;
            this.LaserBoxAux1.Text = "Auxilliary 1";
            this.LaserBoxAux1.UseVisualStyleBackColor = true;
            // 
            // LaserBox854FREQ
            // 
            this.LaserBox854FREQ.AutoSize = true;
            this.LaserBox854FREQ.Location = new System.Drawing.Point(8, 122);
            this.LaserBox854FREQ.Name = "LaserBox854FREQ";
            this.LaserBox854FREQ.Size = new System.Drawing.Size(68, 17);
            this.LaserBox854FREQ.TabIndex = 41;
            this.LaserBox854FREQ.Text = "854 Freq";
            this.LaserBox854FREQ.UseVisualStyleBackColor = true;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(112, 86);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(93, 13);
            this.TimeLabel.TabIndex = 40;
            this.TimeLabel.Text = "Exact Length: 0us";
            // 
            // TicksBox
            // 
            this.TicksBox.Location = new System.Drawing.Point(87, 63);
            this.TicksBox.Maximum = new decimal(new int[] {
            333334,
            0,
            0,
            0});
            this.TicksBox.Name = "TicksBox";
            this.TicksBox.Size = new System.Drawing.Size(117, 20);
            this.TicksBox.TabIndex = 37;
            this.TicksBox.ValueChanged += new System.EventHandler(this.TicksBox_ValueChanged);
            // 
            // PulseTypeBox
            // 
            this.PulseTypeBox.FormattingEnabled = true;
            this.PulseTypeBox.Items.AddRange(new object[] {
            "Frequency Wait",
            "Mains Phase Wait",
            "Normal",
            "Count",
            "Stop",
            "Send Data"});
            this.PulseTypeBox.Location = new System.Drawing.Point(87, 24);
            this.PulseTypeBox.Name = "PulseTypeBox";
            this.PulseTypeBox.Size = new System.Drawing.Size(117, 21);
            this.PulseTypeBox.TabIndex = 36;
            // 
            // LaserBox854POWER
            // 
            this.LaserBox854POWER.AutoSize = true;
            this.LaserBox854POWER.Location = new System.Drawing.Point(8, 99);
            this.LaserBox854POWER.Name = "LaserBox854POWER";
            this.LaserBox854POWER.Size = new System.Drawing.Size(77, 17);
            this.LaserBox854POWER.TabIndex = 35;
            this.LaserBox854POWER.Text = "854 Power";
            this.LaserBox854POWER.UseVisualStyleBackColor = true;
            // 
            // LaserBox854
            // 
            this.LaserBox854.AutoSize = true;
            this.LaserBox854.Location = new System.Drawing.Point(8, 76);
            this.LaserBox854.Name = "LaserBox854";
            this.LaserBox854.Size = new System.Drawing.Size(44, 17);
            this.LaserBox854.TabIndex = 34;
            this.LaserBox854.Text = "854";
            this.LaserBox854.UseVisualStyleBackColor = true;
            // 
            // LaserBox729
            // 
            this.LaserBox729.AutoSize = true;
            this.LaserBox729.Location = new System.Drawing.Point(8, 53);
            this.LaserBox729.Name = "LaserBox729";
            this.LaserBox729.Size = new System.Drawing.Size(44, 17);
            this.LaserBox729.TabIndex = 33;
            this.LaserBox729.Text = "729";
            this.LaserBox729.UseVisualStyleBackColor = true;
            // 
            // LaserBox397B2
            // 
            this.LaserBox397B2.AutoSize = true;
            this.LaserBox397B2.Location = new System.Drawing.Point(8, 30);
            this.LaserBox397B2.Name = "LaserBox397B2";
            this.LaserBox397B2.Size = new System.Drawing.Size(60, 17);
            this.LaserBox397B2.TabIndex = 32;
            this.LaserBox397B2.Text = "397 B2";
            this.LaserBox397B2.UseVisualStyleBackColor = true;
            // 
            // LaserBox397B1
            // 
            this.LaserBox397B1.AutoSize = true;
            this.LaserBox397B1.Location = new System.Drawing.Point(8, 7);
            this.LaserBox397B1.Name = "LaserBox397B1";
            this.LaserBox397B1.Size = new System.Drawing.Size(60, 17);
            this.LaserBox397B1.TabIndex = 31;
            this.LaserBox397B1.Text = "397 B1";
            this.LaserBox397B1.UseVisualStyleBackColor = true;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(310, 22);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(121, 20);
            this.NameBox.TabIndex = 45;
            this.NameBox.Text = "Default Name";
            // 
            // CreateFromTemplateButton
            // 
            this.CreateFromTemplateButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateFromTemplateButton.Image")));
            this.CreateFromTemplateButton.Location = new System.Drawing.Point(272, 343);
            this.CreateFromTemplateButton.Name = "CreateFromTemplateButton";
            this.CreateFromTemplateButton.Size = new System.Drawing.Size(105, 58);
            this.CreateFromTemplateButton.TabIndex = 50;
            this.CreateFromTemplateButton.UseVisualStyleBackColor = true;
            // 
            // OpenXMLButton
            // 
            this.OpenXMLButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenXMLButton.Image")));
            this.OpenXMLButton.Location = new System.Drawing.Point(383, 343);
            this.OpenXMLButton.Name = "OpenXMLButton";
            this.OpenXMLButton.Size = new System.Drawing.Size(105, 58);
            this.OpenXMLButton.TabIndex = 51;
            this.OpenXMLButton.UseVisualStyleBackColor = true;
            this.OpenXMLButton.Click += new System.EventHandler(this.OpenXMLButton_Click);
            // 
            // SaveXMLButton
            // 
            this.SaveXMLButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveXMLButton.Image")));
            this.SaveXMLButton.Location = new System.Drawing.Point(272, 407);
            this.SaveXMLButton.Name = "SaveXMLButton";
            this.SaveXMLButton.Size = new System.Drawing.Size(105, 58);
            this.SaveXMLButton.TabIndex = 52;
            this.SaveXMLButton.UseVisualStyleBackColor = true;
            this.SaveXMLButton.Click += new System.EventHandler(this.SaveXMLButton_Click);
            // 
            // BinaryCompileButton
            // 
            this.BinaryCompileButton.Image = ((System.Drawing.Image)(resources.GetObject("BinaryCompileButton.Image")));
            this.BinaryCompileButton.Location = new System.Drawing.Point(383, 407);
            this.BinaryCompileButton.Name = "BinaryCompileButton";
            this.BinaryCompileButton.Size = new System.Drawing.Size(105, 58);
            this.BinaryCompileButton.TabIndex = 53;
            this.BinaryCompileButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(272, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 5);
            this.label2.TabIndex = 54;
            // 
            // DesignerGroup
            // 
            this.DesignerGroup.Controls.Add(this.label2);
            this.DesignerGroup.Controls.Add(this.BinaryCompileButton);
            this.DesignerGroup.Controls.Add(this.SaveXMLButton);
            this.DesignerGroup.Controls.Add(this.OpenXMLButton);
            this.DesignerGroup.Controls.Add(this.CreateFromTemplateButton);
            this.DesignerGroup.Controls.Add(this.SaveStateButton);
            this.DesignerGroup.Controls.Add(this.PulseTypeTabs);
            this.DesignerGroup.Controls.Add(LoopNameLabel);
            this.DesignerGroup.Controls.Add(this.NameBox);
            this.DesignerGroup.Controls.Add(this.AddChildButton);
            this.DesignerGroup.Controls.Add(this.DeleteButton);
            this.DesignerGroup.Controls.Add(this.MoveDownButton);
            this.DesignerGroup.Controls.Add(this.MoveUpButton);
            this.DesignerGroup.Controls.Add(this.AddRootButton);
            this.DesignerGroup.Controls.Add(this.PulseTree);
            this.DesignerGroup.Location = new System.Drawing.Point(12, 5);
            this.DesignerGroup.Name = "DesignerGroup";
            this.DesignerGroup.Size = new System.Drawing.Size(497, 475);
            this.DesignerGroup.TabIndex = 55;
            this.DesignerGroup.TabStop = false;
            this.DesignerGroup.Text = "Pulse Sequence Designer";
            // 
            // SpectroGroup
            // 
            this.SpectroGroup.Controls.Add(this.StopButton);
            this.SpectroGroup.Controls.Add(this.PauseButton);
            this.SpectroGroup.Controls.Add(this.StartButton);
            this.SpectroGroup.Controls.Add(this.ResetButton);
            this.SpectroGroup.Controls.Add(this.OpenUSBButton);
            this.SpectroGroup.Controls.Add(this.label15);
            this.SpectroGroup.Controls.Add(this.magFreqBox);
            this.SpectroGroup.Controls.Add(FileSendBox);
            this.SpectroGroup.Controls.Add(this.UploadButton);
            this.SpectroGroup.Controls.Add(this.label14);
            this.SpectroGroup.Controls.Add(this.modcycFreqBox);
            this.SpectroGroup.Controls.Add(this.label13);
            this.SpectroGroup.Controls.Add(this.rfAmpBox);
            this.SpectroGroup.Controls.Add(this.label12);
            this.SpectroGroup.Controls.Add(this.sbWidthBox);
            this.SpectroGroup.Controls.Add(this.label11);
            this.SpectroGroup.Controls.Add(this.sbToScanBox);
            this.SpectroGroup.Controls.Add(this.label10);
            this.SpectroGroup.Controls.Add(this.stepSizeBox);
            this.SpectroGroup.Controls.Add(this.label9);
            this.SpectroGroup.Controls.Add(this.carFreqBox);
            this.SpectroGroup.Controls.Add(this.label8);
            this.SpectroGroup.Controls.Add(this.startFreqBox);
            this.SpectroGroup.Controls.Add(this.label7);
            this.SpectroGroup.Controls.Add(this.axFreqBox);
            this.SpectroGroup.Controls.Add(this.label6);
            this.SpectroGroup.Controls.Add(this.label5);
            this.SpectroGroup.Controls.Add(this.specDirBox);
            this.SpectroGroup.Controls.Add(this.trapVBox);
            this.SpectroGroup.Controls.Add(this.label3);
            this.SpectroGroup.Controls.Add(this.specTypeBox);
            this.SpectroGroup.Location = new System.Drawing.Point(520, 5);
            this.SpectroGroup.Name = "SpectroGroup";
            this.SpectroGroup.Size = new System.Drawing.Size(262, 474);
            this.SpectroGroup.TabIndex = 56;
            this.SpectroGroup.TabStop = false;
            this.SpectroGroup.Text = "Spectroscopy Sweep Control";
            // 
            // StopButton
            // 
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.Location = new System.Drawing.Point(196, 407);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(58, 58);
            this.StopButton.TabIndex = 61;
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // PauseButton
            // 
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(134, 407);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(58, 58);
            this.PauseButton.TabIndex = 58;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.Location = new System.Drawing.Point(70, 407);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(58, 58);
            this.StartButton.TabIndex = 59;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetButton.Image")));
            this.ResetButton.Location = new System.Drawing.Point(6, 407);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(58, 58);
            this.ResetButton.TabIndex = 57;
            this.ResetButton.UseVisualStyleBackColor = true;
            // 
            // OpenUSBButton
            // 
            this.OpenUSBButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenUSBButton.Image")));
            this.OpenUSBButton.Location = new System.Drawing.Point(6, 343);
            this.OpenUSBButton.Name = "OpenUSBButton";
            this.OpenUSBButton.Size = new System.Drawing.Size(58, 58);
            this.OpenUSBButton.TabIndex = 60;
            this.OpenUSBButton.UseVisualStyleBackColor = true;
            this.OpenUSBButton.Click += new System.EventHandler(this.OpenUSBButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Magnetron Freq (kHz)";
            // 
            // magFreqBox
            // 
            this.magFreqBox.DecimalPlaces = 1;
            this.magFreqBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.magFreqBox.Location = new System.Drawing.Point(150, 153);
            this.magFreqBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.magFreqBox.Name = "magFreqBox";
            this.magFreqBox.Size = new System.Drawing.Size(104, 20);
            this.magFreqBox.TabIndex = 23;
            this.magFreqBox.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.magFreqBox.ValueChanged += new System.EventHandler(this.magFreqBox_ValueChanged);
            // 
            // UploadButton
            // 
            this.UploadButton.Image = ((System.Drawing.Image)(resources.GetObject("UploadButton.Image")));
            this.UploadButton.Location = new System.Drawing.Point(70, 343);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(58, 58);
            this.UploadButton.TabIndex = 55;
            this.UploadButton.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Modified Cyc Freq (kHz)";
            // 
            // modcycFreqBox
            // 
            this.modcycFreqBox.DecimalPlaces = 1;
            this.modcycFreqBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.modcycFreqBox.Location = new System.Drawing.Point(150, 127);
            this.modcycFreqBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.modcycFreqBox.Name = "modcycFreqBox";
            this.modcycFreqBox.Size = new System.Drawing.Size(104, 20);
            this.modcycFreqBox.TabIndex = 21;
            this.modcycFreqBox.Value = new decimal(new int[] {
            670,
            0,
            0,
            0});
            this.modcycFreqBox.ValueChanged += new System.EventHandler(this.modcycFreqBox_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "729 RF Amplitude (dBm)";
            // 
            // rfAmpBox
            // 
            this.rfAmpBox.DecimalPlaces = 1;
            this.rfAmpBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rfAmpBox.Location = new System.Drawing.Point(150, 309);
            this.rfAmpBox.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.rfAmpBox.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.rfAmpBox.Name = "rfAmpBox";
            this.rfAmpBox.Size = new System.Drawing.Size(104, 20);
            this.rfAmpBox.TabIndex = 19;
            this.rfAmpBox.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Sideband Width (Steps)";
            // 
            // sbWidthBox
            // 
            this.sbWidthBox.Location = new System.Drawing.Point(150, 283);
            this.sbWidthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sbWidthBox.Name = "sbWidthBox";
            this.sbWidthBox.Size = new System.Drawing.Size(104, 20);
            this.sbWidthBox.TabIndex = 17;
            this.sbWidthBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sbWidthBox.ValueChanged += new System.EventHandler(this.sbWidthBox_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Sidebands to scan/side";
            // 
            // sbToScanBox
            // 
            this.sbToScanBox.Location = new System.Drawing.Point(150, 257);
            this.sbToScanBox.Name = "sbToScanBox";
            this.sbToScanBox.Size = new System.Drawing.Size(104, 20);
            this.sbToScanBox.TabIndex = 15;
            this.sbToScanBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sbToScanBox.ValueChanged += new System.EventHandler(this.sbToScanBox_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 233);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Step Size (kHz)";
            // 
            // stepSizeBox
            // 
            this.stepSizeBox.DecimalPlaces = 1;
            this.stepSizeBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.stepSizeBox.Location = new System.Drawing.Point(150, 231);
            this.stepSizeBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.stepSizeBox.Name = "stepSizeBox";
            this.stepSizeBox.Size = new System.Drawing.Size(104, 20);
            this.stepSizeBox.TabIndex = 13;
            this.stepSizeBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Carrier Frequency (MHz)";
            // 
            // carFreqBox
            // 
            this.carFreqBox.DecimalPlaces = 3;
            this.carFreqBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.carFreqBox.Location = new System.Drawing.Point(150, 205);
            this.carFreqBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.carFreqBox.Name = "carFreqBox";
            this.carFreqBox.Size = new System.Drawing.Size(104, 20);
            this.carFreqBox.TabIndex = 11;
            this.carFreqBox.Value = new decimal(new int[] {
            230000000,
            0,
            0,
            393216});
            this.carFreqBox.ValueChanged += new System.EventHandler(this.carFreqBox_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Start Frequency (MHz)";
            // 
            // startFreqBox
            // 
            this.startFreqBox.DecimalPlaces = 3;
            this.startFreqBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.startFreqBox.Location = new System.Drawing.Point(150, 179);
            this.startFreqBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.startFreqBox.Name = "startFreqBox";
            this.startFreqBox.Size = new System.Drawing.Size(104, 20);
            this.startFreqBox.TabIndex = 9;
            this.startFreqBox.Value = new decimal(new int[] {
            230000000,
            0,
            0,
            393216});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Axial Freq (kHz)";
            // 
            // axFreqBox
            // 
            this.axFreqBox.DecimalPlaces = 1;
            this.axFreqBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.axFreqBox.Location = new System.Drawing.Point(150, 101);
            this.axFreqBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.axFreqBox.Name = "axFreqBox";
            this.axFreqBox.Size = new System.Drawing.Size(104, 20);
            this.axFreqBox.TabIndex = 7;
            this.axFreqBox.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.axFreqBox.ValueChanged += new System.EventHandler(this.axFreqBox_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Trap Voltage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "729 Direction";
            // 
            // specDirBox
            // 
            this.specDirBox.FormattingEnabled = true;
            this.specDirBox.Items.AddRange(new object[] {
            "Axial",
            "Radial"});
            this.specDirBox.Location = new System.Drawing.Point(150, 48);
            this.specDirBox.Name = "specDirBox";
            this.specDirBox.Size = new System.Drawing.Size(104, 21);
            this.specDirBox.TabIndex = 4;
            this.specDirBox.Text = "Select";
            this.specDirBox.SelectedIndexChanged += new System.EventHandler(this.specDirBox_SelectedIndexChanged);
            // 
            // trapVBox
            // 
            this.trapVBox.DecimalPlaces = 3;
            this.trapVBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.trapVBox.Location = new System.Drawing.Point(150, 75);
            this.trapVBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.trapVBox.Name = "trapVBox";
            this.trapVBox.Size = new System.Drawing.Size(104, 20);
            this.trapVBox.TabIndex = 3;
            this.trapVBox.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.trapVBox.ValueChanged += new System.EventHandler(this.trapVBox_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Spectrum Type";
            // 
            // specTypeBox
            // 
            this.specTypeBox.FormattingEnabled = true;
            this.specTypeBox.Items.AddRange(new object[] {
            "Continuous",
            "Windowed",
            "Fixed"});
            this.specTypeBox.Location = new System.Drawing.Point(150, 21);
            this.specTypeBox.Name = "specTypeBox";
            this.specTypeBox.Size = new System.Drawing.Size(104, 21);
            this.specTypeBox.TabIndex = 1;
            this.specTypeBox.Text = "Select";
            this.specTypeBox.SelectedIndexChanged += new System.EventHandler(this.specTypeBox_SelectedIndexChanged);
            // 
            // LaserControl
            // 
            this.LaserControl.Controls.Add(this.panel4);
            this.LaserControl.Controls.Add(this.panel3);
            this.LaserControl.Controls.Add(this.panel2);
            this.LaserControl.Controls.Add(this.panel1);
            this.LaserControl.Controls.Add(this.LiveLaserBoxAux2);
            this.LaserControl.Controls.Add(this.LiveLaserBoxAux1);
            this.LaserControl.Controls.Add(this.LiveLaserBox854FREQ);
            this.LaserControl.Controls.Add(this.LiveLaserBox854POWER);
            this.LaserControl.Controls.Add(this.LiveLaserBox854);
            this.LaserControl.Controls.Add(this.LiveLaserBox729);
            this.LaserControl.Controls.Add(this.LiveLaserBox397B2);
            this.LaserControl.Controls.Add(this.LiveLaserBox397B1);
            this.LaserControl.Location = new System.Drawing.Point(793, 5);
            this.LaserControl.Name = "LaserControl";
            this.LaserControl.Size = new System.Drawing.Size(255, 474);
            this.LaserControl.TabIndex = 57;
            this.LaserControl.TabStop = false;
            this.LaserControl.Text = "Laser Control";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.SetRFSB3Button);
            this.panel4.Controls.Add(this.SB3RFFreq);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.SB3RFAmp);
            this.panel4.Controls.Add(this.SB3RFSourceButton);
            this.panel4.Location = new System.Drawing.Point(12, 384);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 81);
            this.panel4.TabIndex = 67;
            // 
            // SetRFSB3Button
            // 
            this.SetRFSB3Button.Location = new System.Drawing.Point(138, 47);
            this.SetRFSB3Button.Name = "SetRFSB3Button";
            this.SetRFSB3Button.Size = new System.Drawing.Size(86, 27);
            this.SetRFSB3Button.TabIndex = 68;
            this.SetRFSB3Button.Text = "Set";
            this.SetRFSB3Button.UseVisualStyleBackColor = true;
            this.SetRFSB3Button.Click += new System.EventHandler(this.SetRFSB3Button_Click);
            // 
            // SB3RFFreq
            // 
            this.SB3RFFreq.Location = new System.Drawing.Point(3, 26);
            this.SB3RFFreq.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SB3RFFreq.Name = "SB3RFFreq";
            this.SB3RFFreq.Size = new System.Drawing.Size(113, 20);
            this.SB3RFFreq.TabIndex = 62;
            this.SB3RFFreq.Value = new decimal(new int[] {
            230000000,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(122, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 13);
            this.label22.TabIndex = 64;
            this.label22.Text = "Frequency (Hz)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(51, 54);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 13);
            this.label23.TabIndex = 62;
            this.label23.Text = "Amplitude (dBm)";
            // 
            // SB3RFAmp
            // 
            this.SB3RFAmp.DecimalPlaces = 1;
            this.SB3RFAmp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SB3RFAmp.Location = new System.Drawing.Point(3, 52);
            this.SB3RFAmp.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.SB3RFAmp.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.SB3RFAmp.Name = "SB3RFAmp";
            this.SB3RFAmp.Size = new System.Drawing.Size(46, 20);
            this.SB3RFAmp.TabIndex = 62;
            this.SB3RFAmp.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // SB3RFSourceButton
            // 
            this.SB3RFSourceButton.AutoSize = true;
            this.SB3RFSourceButton.Location = new System.Drawing.Point(3, 3);
            this.SB3RFSourceButton.Name = "SB3RFSourceButton";
            this.SB3RFSourceButton.Size = new System.Drawing.Size(168, 17);
            this.SB3RFSourceButton.TabIndex = 8;
            this.SB3RFSourceButton.TabStop = true;
            this.SB3RFSourceButton.Tag = "SB3";
            this.SB3RFSourceButton.Text = "729nm Sideband RF Source 3";
            this.SB3RFSourceButton.UseVisualStyleBackColor = true;
            this.SB3RFSourceButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.SetRFSB2Button);
            this.panel3.Controls.Add(this.SB2RFFreq);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.SB2RFAmp);
            this.panel3.Controls.Add(this.SB2RFSourceButton);
            this.panel3.Location = new System.Drawing.Point(12, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 81);
            this.panel3.TabIndex = 66;
            // 
            // SetRFSB2Button
            // 
            this.SetRFSB2Button.Location = new System.Drawing.Point(138, 47);
            this.SetRFSB2Button.Name = "SetRFSB2Button";
            this.SetRFSB2Button.Size = new System.Drawing.Size(86, 27);
            this.SetRFSB2Button.TabIndex = 67;
            this.SetRFSB2Button.Text = "Set";
            this.SetRFSB2Button.UseVisualStyleBackColor = true;
            this.SetRFSB2Button.Click += new System.EventHandler(this.SetRFSB2Button_Click);
            // 
            // SB2RFFreq
            // 
            this.SB2RFFreq.Location = new System.Drawing.Point(3, 26);
            this.SB2RFFreq.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SB2RFFreq.Name = "SB2RFFreq";
            this.SB2RFFreq.Size = new System.Drawing.Size(113, 20);
            this.SB2RFFreq.TabIndex = 62;
            this.SB2RFFreq.Value = new decimal(new int[] {
            230000000,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(122, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 13);
            this.label20.TabIndex = 64;
            this.label20.Text = "Frequency (Hz)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(52, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 13);
            this.label21.TabIndex = 62;
            this.label21.Text = "Amplitude (dBm)";
            // 
            // SB2RFAmp
            // 
            this.SB2RFAmp.DecimalPlaces = 1;
            this.SB2RFAmp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SB2RFAmp.Location = new System.Drawing.Point(3, 52);
            this.SB2RFAmp.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.SB2RFAmp.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.SB2RFAmp.Name = "SB2RFAmp";
            this.SB2RFAmp.Size = new System.Drawing.Size(46, 20);
            this.SB2RFAmp.TabIndex = 62;
            this.SB2RFAmp.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // SB2RFSourceButton
            // 
            this.SB2RFSourceButton.AutoSize = true;
            this.SB2RFSourceButton.Location = new System.Drawing.Point(3, 3);
            this.SB2RFSourceButton.Name = "SB2RFSourceButton";
            this.SB2RFSourceButton.Size = new System.Drawing.Size(168, 17);
            this.SB2RFSourceButton.TabIndex = 8;
            this.SB2RFSourceButton.TabStop = true;
            this.SB2RFSourceButton.Tag = "SB2";
            this.SB2RFSourceButton.Text = "729nm Sideband RF Source 2";
            this.SB2RFSourceButton.UseVisualStyleBackColor = true;
            this.SB2RFSourceButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.SetRFSB1Button);
            this.panel2.Controls.Add(this.SB1RFFreq);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.SB1RFAmp);
            this.panel2.Controls.Add(this.SB1RFSourceButton);
            this.panel2.Location = new System.Drawing.Point(12, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 81);
            this.panel2.TabIndex = 65;
            // 
            // SetRFSB1Button
            // 
            this.SetRFSB1Button.Location = new System.Drawing.Point(138, 47);
            this.SetRFSB1Button.Name = "SetRFSB1Button";
            this.SetRFSB1Button.Size = new System.Drawing.Size(86, 27);
            this.SetRFSB1Button.TabIndex = 66;
            this.SetRFSB1Button.Text = "Set";
            this.SetRFSB1Button.UseVisualStyleBackColor = true;
            this.SetRFSB1Button.Click += new System.EventHandler(this.SetRFSB1Button_Click);
            // 
            // SB1RFFreq
            // 
            this.SB1RFFreq.Location = new System.Drawing.Point(3, 26);
            this.SB1RFFreq.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SB1RFFreq.Name = "SB1RFFreq";
            this.SB1RFFreq.Size = new System.Drawing.Size(113, 20);
            this.SB1RFFreq.TabIndex = 62;
            this.SB1RFFreq.Value = new decimal(new int[] {
            230000000,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(122, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 13);
            this.label18.TabIndex = 64;
            this.label18.Text = "Frequency (Hz)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(51, 54);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 13);
            this.label19.TabIndex = 62;
            this.label19.Text = "Amplitude (dBm)";
            // 
            // SB1RFAmp
            // 
            this.SB1RFAmp.DecimalPlaces = 1;
            this.SB1RFAmp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SB1RFAmp.Location = new System.Drawing.Point(3, 52);
            this.SB1RFAmp.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.SB1RFAmp.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.SB1RFAmp.Name = "SB1RFAmp";
            this.SB1RFAmp.Size = new System.Drawing.Size(46, 20);
            this.SB1RFAmp.TabIndex = 62;
            this.SB1RFAmp.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // SB1RFSourceButton
            // 
            this.SB1RFSourceButton.AutoSize = true;
            this.SB1RFSourceButton.Location = new System.Drawing.Point(3, 3);
            this.SB1RFSourceButton.Name = "SB1RFSourceButton";
            this.SB1RFSourceButton.Size = new System.Drawing.Size(168, 17);
            this.SB1RFSourceButton.TabIndex = 8;
            this.SB1RFSourceButton.TabStop = true;
            this.SB1RFSourceButton.Tag = "SB1";
            this.SB1RFSourceButton.Text = "729nm Sideband RF Source 1";
            this.SB1RFSourceButton.UseVisualStyleBackColor = true;
            this.SB1RFSourceButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.SetRFSpecButton);
            this.panel1.Controls.Add(this.SpecRFFreq);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.SpecRFAmp);
            this.panel1.Controls.Add(this.SpecRFSourceButton);
            this.panel1.Location = new System.Drawing.Point(12, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 81);
            this.panel1.TabIndex = 12;
            // 
            // SetRFSpecButton
            // 
            this.SetRFSpecButton.Location = new System.Drawing.Point(138, 47);
            this.SetRFSpecButton.Name = "SetRFSpecButton";
            this.SetRFSpecButton.Size = new System.Drawing.Size(86, 27);
            this.SetRFSpecButton.TabIndex = 65;
            this.SetRFSpecButton.Text = "Set";
            this.SetRFSpecButton.UseVisualStyleBackColor = true;
            this.SetRFSpecButton.Click += new System.EventHandler(this.SetRFSpecButton_Click);
            // 
            // SpecRFFreq
            // 
            this.SpecRFFreq.Location = new System.Drawing.Point(3, 26);
            this.SpecRFFreq.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SpecRFFreq.Name = "SpecRFFreq";
            this.SpecRFFreq.Size = new System.Drawing.Size(113, 20);
            this.SpecRFFreq.TabIndex = 62;
            this.SpecRFFreq.Value = new decimal(new int[] {
            230000000,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(122, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 64;
            this.label17.Text = "Frequency (Hz)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(51, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "Amplitude (dBm)";
            // 
            // SpecRFAmp
            // 
            this.SpecRFAmp.DecimalPlaces = 1;
            this.SpecRFAmp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SpecRFAmp.Location = new System.Drawing.Point(3, 52);
            this.SpecRFAmp.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.SpecRFAmp.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.SpecRFAmp.Name = "SpecRFAmp";
            this.SpecRFAmp.Size = new System.Drawing.Size(46, 20);
            this.SpecRFAmp.TabIndex = 62;
            this.SpecRFAmp.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // SpecRFSourceButton
            // 
            this.SpecRFSourceButton.AutoSize = true;
            this.SpecRFSourceButton.Checked = true;
            this.SpecRFSourceButton.Location = new System.Drawing.Point(3, 3);
            this.SpecRFSourceButton.Name = "SpecRFSourceButton";
            this.SpecRFSourceButton.Size = new System.Drawing.Size(179, 17);
            this.SpecRFSourceButton.TabIndex = 8;
            this.SpecRFSourceButton.TabStop = true;
            this.SpecRFSourceButton.Tag = "Spec";
            this.SpecRFSourceButton.Text = "729nm Spectroscopy RF Source";
            this.SpecRFSourceButton.UseVisualStyleBackColor = true;
            this.SpecRFSourceButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBoxAux2
            // 
            this.LiveLaserBoxAux2.AutoSize = true;
            this.LiveLaserBoxAux2.Location = new System.Drawing.Point(133, 92);
            this.LiveLaserBoxAux2.Name = "LiveLaserBoxAux2";
            this.LiveLaserBoxAux2.Size = new System.Drawing.Size(75, 17);
            this.LiveLaserBoxAux2.TabIndex = 7;
            this.LiveLaserBoxAux2.Text = "Auxilliary 2";
            this.LiveLaserBoxAux2.UseVisualStyleBackColor = true;
            this.LiveLaserBoxAux2.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBoxAux1
            // 
            this.LiveLaserBoxAux1.AutoSize = true;
            this.LiveLaserBoxAux1.Location = new System.Drawing.Point(133, 69);
            this.LiveLaserBoxAux1.Name = "LiveLaserBoxAux1";
            this.LiveLaserBoxAux1.Size = new System.Drawing.Size(75, 17);
            this.LiveLaserBoxAux1.TabIndex = 6;
            this.LiveLaserBoxAux1.Text = "Auxilliary 1";
            this.LiveLaserBoxAux1.UseVisualStyleBackColor = true;
            this.LiveLaserBoxAux1.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBox854FREQ
            // 
            this.LiveLaserBox854FREQ.AutoSize = true;
            this.LiveLaserBox854FREQ.Location = new System.Drawing.Point(133, 46);
            this.LiveLaserBox854FREQ.Name = "LiveLaserBox854FREQ";
            this.LiveLaserBox854FREQ.Size = new System.Drawing.Size(111, 17);
            this.LiveLaserBox854FREQ.TabIndex = 5;
            this.LiveLaserBox854FREQ.Text = "854nm Frequency";
            this.LiveLaserBox854FREQ.UseVisualStyleBackColor = true;
            this.LiveLaserBox854FREQ.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBox854POWER
            // 
            this.LiveLaserBox854POWER.AutoSize = true;
            this.LiveLaserBox854POWER.Location = new System.Drawing.Point(133, 23);
            this.LiveLaserBox854POWER.Name = "LiveLaserBox854POWER";
            this.LiveLaserBox854POWER.Size = new System.Drawing.Size(91, 17);
            this.LiveLaserBox854POWER.TabIndex = 4;
            this.LiveLaserBox854POWER.Text = "854nm Power";
            this.LiveLaserBox854POWER.UseVisualStyleBackColor = true;
            this.LiveLaserBox854POWER.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBox854
            // 
            this.LiveLaserBox854.AutoSize = true;
            this.LiveLaserBox854.Location = new System.Drawing.Point(12, 92);
            this.LiveLaserBox854.Name = "LiveLaserBox854";
            this.LiveLaserBox854.Size = new System.Drawing.Size(58, 17);
            this.LiveLaserBox854.TabIndex = 3;
            this.LiveLaserBox854.Text = "854nm";
            this.LiveLaserBox854.UseVisualStyleBackColor = true;
            this.LiveLaserBox854.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBox729
            // 
            this.LiveLaserBox729.AutoSize = true;
            this.LiveLaserBox729.Location = new System.Drawing.Point(12, 69);
            this.LiveLaserBox729.Name = "LiveLaserBox729";
            this.LiveLaserBox729.Size = new System.Drawing.Size(58, 17);
            this.LiveLaserBox729.TabIndex = 2;
            this.LiveLaserBox729.Text = "729nm";
            this.LiveLaserBox729.UseVisualStyleBackColor = true;
            this.LiveLaserBox729.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBox397B2
            // 
            this.LiveLaserBox397B2.AutoSize = true;
            this.LiveLaserBox397B2.Location = new System.Drawing.Point(12, 46);
            this.LiveLaserBox397B2.Name = "LiveLaserBox397B2";
            this.LiveLaserBox397B2.Size = new System.Drawing.Size(74, 17);
            this.LiveLaserBox397B2.TabIndex = 1;
            this.LiveLaserBox397B2.Text = "397nm B2";
            this.LiveLaserBox397B2.UseVisualStyleBackColor = true;
            this.LiveLaserBox397B2.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBox397B1
            // 
            this.LiveLaserBox397B1.AutoSize = true;
            this.LiveLaserBox397B1.Location = new System.Drawing.Point(12, 23);
            this.LiveLaserBox397B1.Name = "LiveLaserBox397B1";
            this.LiveLaserBox397B1.Size = new System.Drawing.Size(74, 17);
            this.LiveLaserBox397B1.TabIndex = 0;
            this.LiveLaserBox397B1.Text = "397nm B1";
            this.LiveLaserBox397B1.UseVisualStyleBackColor = true;
            this.LiveLaserBox397B1.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // debugmessagebox
            // 
            this.debugmessagebox.Controls.Add(this.MessagesBox);
            this.debugmessagebox.Location = new System.Drawing.Point(12, 485);
            this.debugmessagebox.Name = "debugmessagebox";
            this.debugmessagebox.Size = new System.Drawing.Size(1036, 165);
            this.debugmessagebox.TabIndex = 58;
            this.debugmessagebox.TabStop = false;
            this.debugmessagebox.Text = "Debug Messages";
            // 
            // MessagesBox
            // 
            this.MessagesBox.Location = new System.Drawing.Point(12, 19);
            this.MessagesBox.Name = "MessagesBox";
            this.MessagesBox.Size = new System.Drawing.Size(1013, 132);
            this.MessagesBox.TabIndex = 0;
            this.MessagesBox.UseCompatibleStateImageBehavior = false;
            // 
            // openXMLFileDialog
            // 
            this.openXMLFileDialog.FileName = "openFileDialog1";
            // 
            // openHexFileDialog
            // 
            this.openHexFileDialog.FileName = "openHexFileDialog";
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 662);
            this.Controls.Add(this.debugmessagebox);
            this.Controls.Add(this.LaserControl);
            this.Controls.Add(this.SpectroGroup);
            this.Controls.Add(this.DesignerGroup);
            this.Name = "CoreForm";
            this.Text = "Form1";
            FileSendBox.ResumeLayout(false);
            FileSendBox.PerformLayout();
            this.PulseTypeTabs.ResumeLayout(false);
            this.LoopTabPage.ResumeLayout(false);
            this.LoopTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoopNumberBox)).EndInit();
            this.PulseTabPage.ResumeLayout(false);
            this.PulseTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourceSelect729)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TicksBox)).EndInit();
            this.DesignerGroup.ResumeLayout(false);
            this.DesignerGroup.PerformLayout();
            this.SpectroGroup.ResumeLayout(false);
            this.SpectroGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.magFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modcycFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rfAmpBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbToScanBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trapVBox)).EndInit();
            this.LaserControl.ResumeLayout(false);
            this.LaserControl.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SB3RFFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SB3RFAmp)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SB2RFFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SB2RFAmp)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SB1RFFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SB1RFAmp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpecRFFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecRFAmp)).EndInit();
            this.debugmessagebox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView PulseTree;
        private System.Windows.Forms.Button AddChildButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button AddRootButton;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Button SaveStateButton;
        private System.Windows.Forms.TabControl PulseTypeTabs;
        private System.Windows.Forms.TabPage LoopTabPage;
        private System.Windows.Forms.CheckBox FPGALoopSelect;
        private System.Windows.Forms.NumericUpDown LoopNumberBox;
        private System.Windows.Forms.TabPage PulseTabPage;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.NumericUpDown TicksBox;
        private System.Windows.Forms.ComboBox PulseTypeBox;
        private System.Windows.Forms.CheckBox LaserBox854POWER;
        private System.Windows.Forms.CheckBox LaserBox854;
        private System.Windows.Forms.CheckBox LaserBox729;
        private System.Windows.Forms.CheckBox LaserBox397B2;
        private System.Windows.Forms.CheckBox LaserBox397B1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.CheckBox LaserBoxAux2;
        private System.Windows.Forms.CheckBox LaserBoxAux1;
        private System.Windows.Forms.CheckBox LaserBox854FREQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown SourceSelect729;
        private System.Windows.Forms.Button CreateFromTemplateButton;
        private System.Windows.Forms.Button OpenXMLButton;
        private System.Windows.Forms.Button SaveXMLButton;
        private System.Windows.Forms.Button BinaryCompileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox DesignerGroup;
        private System.Windows.Forms.GroupBox SpectroGroup;
        private System.Windows.Forms.ComboBox specTypeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox specDirBox;
        private System.Windows.Forms.NumericUpDown trapVBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown rfAmpBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown sbWidthBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown sbToScanBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown stepSizeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown carFreqBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown startFreqBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown axFreqBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.NumericUpDown magFreqBox;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown modcycFreqBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button OpenUSBButton;
        private System.Windows.Forms.GroupBox LaserControl;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.CheckBox LiveLaserBoxAux2;
        private System.Windows.Forms.CheckBox LiveLaserBoxAux1;
        private System.Windows.Forms.CheckBox LiveLaserBox854FREQ;
        private System.Windows.Forms.CheckBox LiveLaserBox854POWER;
        private System.Windows.Forms.CheckBox LiveLaserBox854;
        private System.Windows.Forms.CheckBox LiveLaserBox729;
        private System.Windows.Forms.CheckBox LiveLaserBox397B2;
        private System.Windows.Forms.CheckBox LiveLaserBox397B1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown SpecRFAmp;
        private System.Windows.Forms.RadioButton SpecRFSourceButton;
        private System.Windows.Forms.NumericUpDown SpecRFFreq;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown SB3RFFreq;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown SB3RFAmp;
        private System.Windows.Forms.RadioButton SB3RFSourceButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown SB2RFFreq;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown SB2RFAmp;
        private System.Windows.Forms.RadioButton SB2RFSourceButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown SB1RFFreq;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown SB1RFAmp;
        private System.Windows.Forms.RadioButton SB1RFSourceButton;
        private System.Windows.Forms.Button SetRFSB3Button;
        private System.Windows.Forms.Button SetRFSB2Button;
        private System.Windows.Forms.Button SetRFSB1Button;
        private System.Windows.Forms.Button SetRFSpecButton;
        private System.Windows.Forms.GroupBox debugmessagebox;
        private System.Windows.Forms.ListView MessagesBox;
        private System.Windows.Forms.SaveFileDialog saveXMLFileDialog;
        private System.Windows.Forms.OpenFileDialog openXMLFileDialog;
        private System.Windows.Forms.OpenFileDialog openHexFileDialog;
        private System.Windows.Forms.SaveFileDialog saveHexFileDialog;
    }
}

