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
            this.LaserBox854POWER = new System.Windows.Forms.CheckBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.TicksBox = new System.Windows.Forms.NumericUpDown();
            this.PulseTypeBox = new System.Windows.Forms.ComboBox();
            this.LaserBox854FREQ = new System.Windows.Forms.CheckBox();
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
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.UploadButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.RFAmplitudeBox = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.SidebandWidthBox = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.SidebandNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.StepSizeBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.CarrierFrequencyBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.StartFrequencyBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.TrapFrequencyBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AxialRadialBox = new System.Windows.Forms.ComboBox();
            this.TrapVoltageBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SpecTypeBox = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RFAmplitudeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SidebandWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SidebandNumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarrierFrequencyBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartFrequencyBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrapFrequencyBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrapVoltageBox)).BeginInit();
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
            FileSendBox.Location = new System.Drawing.Point(179, 422);
            FileSendBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            FileSendBox.Name = "FileSendBox";
            FileSendBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            FileSendBox.Size = new System.Drawing.Size(183, 71);
            FileSendBox.TabIndex = 49;
            FileSendBox.TabStop = false;
            FileSendBox.Text = "Binary File Upload";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(27, 28);
            this.ProgressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(111, 17);
            this.ProgressLabel.TabIndex = 43;
            this.ProgressLabel.Text = "No File Selected";
            // 
            // LoopNumberLabel
            // 
            LoopNumberLabel.AutoSize = true;
            LoopNumberLabel.Location = new System.Drawing.Point(49, 23);
            LoopNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LoopNumberLabel.Name = "LoopNumberLabel";
            LoopNumberLabel.Size = new System.Drawing.Size(158, 17);
            LoopNumberLabel.TabIndex = 34;
            LoopNumberLabel.Text = "Number of times to loop";
            // 
            // DesiredLengthLabel
            // 
            DesiredLengthLabel.AutoSize = true;
            DesiredLengthLabel.Location = new System.Drawing.Point(104, 63);
            DesiredLengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            DesiredLengthLabel.Name = "DesiredLengthLabel";
            DesiredLengthLabel.Size = new System.Drawing.Size(173, 17);
            DesiredLengthLabel.TabIndex = 39;
            DesiredLengthLabel.Text = "Desired Pulse Length (us)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(104, 12);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(40, 17);
            label4.TabIndex = 38;
            label4.Text = "Type";
            // 
            // LoopNameLabel
            // 
            LoopNameLabel.AutoSize = true;
            LoopNameLabel.Location = new System.Drawing.Point(359, 30);
            LoopNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LoopNameLabel.Name = "LoopNameLabel";
            LoopNameLabel.Size = new System.Drawing.Size(49, 17);
            LoopNameLabel.TabIndex = 46;
            LoopNameLabel.Text = "Name:";
            // 
            // PulseTree
            // 
            this.PulseTree.Location = new System.Drawing.Point(16, 62);
            this.PulseTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PulseTree.Name = "PulseTree";
            this.PulseTree.Size = new System.Drawing.Size(337, 510);
            this.PulseTree.TabIndex = 0;
            // 
            // AddChildButton
            // 
            this.AddChildButton.Location = new System.Drawing.Point(77, 26);
            this.AddChildButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddChildButton.Name = "AddChildButton";
            this.AddChildButton.Size = new System.Drawing.Size(91, 28);
            this.AddChildButton.TabIndex = 44;
            this.AddChildButton.Text = "Add Child";
            this.AddChildButton.UseVisualStyleBackColor = true;
            this.AddChildButton.Click += new System.EventHandler(this.AddChildButton_Click);
            this.AddChildButton.MouseEnter += new System.EventHandler(this.AddChildButton_MouseEnter);
            this.AddChildButton.MouseLeave += new System.EventHandler(this.AddChildButton_MouseLeave);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(280, 26);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 28);
            this.DeleteButton.TabIndex = 43;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(228, 26);
            this.MoveDownButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(44, 28);
            this.MoveDownButton.TabIndex = 42;
            this.MoveDownButton.Text = "↓";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(176, 26);
            this.MoveUpButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MoveUpButton.Size = new System.Drawing.Size(44, 28);
            this.MoveUpButton.TabIndex = 41;
            this.MoveUpButton.Text = "↑";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            // 
            // AddRootButton
            // 
            this.AddRootButton.Location = new System.Drawing.Point(16, 26);
            this.AddRootButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddRootButton.Name = "AddRootButton";
            this.AddRootButton.Size = new System.Drawing.Size(53, 28);
            this.AddRootButton.TabIndex = 40;
            this.AddRootButton.Text = "Add";
            this.AddRootButton.UseVisualStyleBackColor = true;
            this.AddRootButton.Click += new System.EventHandler(this.AddRootButton_Click);
            this.AddRootButton.MouseEnter += new System.EventHandler(this.AddRootButton_MouseEnter);
            this.AddRootButton.MouseLeave += new System.EventHandler(this.AddRootButton_MouseLeave);
            // 
            // SaveStateButton
            // 
            this.SaveStateButton.Location = new System.Drawing.Point(363, 366);
            this.SaveStateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveStateButton.Name = "SaveStateButton";
            this.SaveStateButton.Size = new System.Drawing.Size(288, 37);
            this.SaveStateButton.TabIndex = 48;
            this.SaveStateButton.Text = "Save Pulse";
            this.SaveStateButton.UseVisualStyleBackColor = true;
            // 
            // PulseTypeTabs
            // 
            this.PulseTypeTabs.Controls.Add(this.LoopTabPage);
            this.PulseTypeTabs.Controls.Add(this.PulseTabPage);
            this.PulseTypeTabs.Location = new System.Drawing.Point(363, 62);
            this.PulseTypeTabs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PulseTypeTabs.Name = "PulseTypeTabs";
            this.PulseTypeTabs.SelectedIndex = 0;
            this.PulseTypeTabs.Size = new System.Drawing.Size(288, 302);
            this.PulseTypeTabs.TabIndex = 47;
            // 
            // LoopTabPage
            // 
            this.LoopTabPage.Controls.Add(this.FPGALoopSelect);
            this.LoopTabPage.Controls.Add(LoopNumberLabel);
            this.LoopTabPage.Controls.Add(this.LoopNumberBox);
            this.LoopTabPage.Location = new System.Drawing.Point(4, 25);
            this.LoopTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoopTabPage.Name = "LoopTabPage";
            this.LoopTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoopTabPage.Size = new System.Drawing.Size(280, 273);
            this.LoopTabPage.TabIndex = 0;
            this.LoopTabPage.Text = "Create Loop";
            this.LoopTabPage.UseVisualStyleBackColor = true;
            // 
            // FPGALoopSelect
            // 
            this.FPGALoopSelect.AutoSize = true;
            this.FPGALoopSelect.Location = new System.Drawing.Point(53, 95);
            this.FPGALoopSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FPGALoopSelect.Name = "FPGALoopSelect";
            this.FPGALoopSelect.Size = new System.Drawing.Size(111, 21);
            this.FPGALoopSelect.TabIndex = 35;
            this.FPGALoopSelect.Text = "FPGA Loop?";
            this.FPGALoopSelect.UseVisualStyleBackColor = true;
            // 
            // LoopNumberBox
            // 
            this.LoopNumberBox.Location = new System.Drawing.Point(53, 46);
            this.LoopNumberBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.LoopNumberBox.Size = new System.Drawing.Size(160, 22);
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
            this.PulseTabPage.Controls.Add(this.LaserBox854POWER);
            this.PulseTabPage.Controls.Add(this.TimeLabel);
            this.PulseTabPage.Controls.Add(DesiredLengthLabel);
            this.PulseTabPage.Controls.Add(label4);
            this.PulseTabPage.Controls.Add(this.TicksBox);
            this.PulseTabPage.Controls.Add(this.PulseTypeBox);
            this.PulseTabPage.Controls.Add(this.LaserBox854FREQ);
            this.PulseTabPage.Controls.Add(this.LaserBox854);
            this.PulseTabPage.Controls.Add(this.LaserBox729);
            this.PulseTabPage.Controls.Add(this.LaserBox397B2);
            this.PulseTabPage.Controls.Add(this.LaserBox397B1);
            this.PulseTabPage.Location = new System.Drawing.Point(4, 25);
            this.PulseTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PulseTabPage.Name = "PulseTabPage";
            this.PulseTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PulseTabPage.Size = new System.Drawing.Size(280, 273);
            this.PulseTabPage.TabIndex = 1;
            this.PulseTabPage.Text = "Create Laser Pulse";
            this.PulseTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 238);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "729 RF Source Select";
            // 
            // SourceSelect729
            // 
            this.SourceSelect729.Location = new System.Drawing.Point(11, 235);
            this.SourceSelect729.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.SourceSelect729.Size = new System.Drawing.Size(59, 22);
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
            this.LaserBoxAux2.Location = new System.Drawing.Point(11, 207);
            this.LaserBoxAux2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserBoxAux2.Name = "LaserBoxAux2";
            this.LaserBoxAux2.Size = new System.Drawing.Size(88, 26);
            this.LaserBoxAux2.TabIndex = 43;
            this.LaserBoxAux2.Text = "Aux-2";
            this.LaserBoxAux2.UseVisualStyleBackColor = true;
            // 
            // LaserBoxAux1
            // 
            this.LaserBoxAux1.AutoSize = true;
            this.LaserBoxAux1.Location = new System.Drawing.Point(11, 178);
            this.LaserBoxAux1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserBoxAux1.Name = "LaserBoxAux1";
            this.LaserBoxAux1.Size = new System.Drawing.Size(88, 26);
            this.LaserBoxAux1.TabIndex = 42;
            this.LaserBoxAux1.Text = "Aux-1";
            this.LaserBoxAux1.UseVisualStyleBackColor = true;
            // 
            // LaserBox854POWER
            // 
            this.LaserBox854POWER.AutoSize = true;
            this.LaserBox854POWER.Location = new System.Drawing.Point(11, 150);
            this.LaserBox854POWER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserBox854POWER.Name = "LaserBox854POWER";
            this.LaserBox854POWER.Size = new System.Drawing.Size(129, 26);
            this.LaserBox854POWER.TabIndex = 41;
            this.LaserBox854POWER.Text = "854 Power";
            this.LaserBox854POWER.UseVisualStyleBackColor = true;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(107, 111);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(125, 17);
            this.TimeLabel.TabIndex = 40;
            this.TimeLabel.Text = "Exact Length: 0 us";
            // 
            // TicksBox
            // 
            this.TicksBox.Location = new System.Drawing.Point(108, 82);
            this.TicksBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TicksBox.Maximum = new decimal(new int[] {
            333334,
            0,
            0,
            0});
            this.TicksBox.Name = "TicksBox";
            this.TicksBox.Size = new System.Drawing.Size(160, 22);
            this.TicksBox.TabIndex = 37;
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
            this.PulseTypeBox.Location = new System.Drawing.Point(108, 32);
            this.PulseTypeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PulseTypeBox.Name = "PulseTypeBox";
            this.PulseTypeBox.Size = new System.Drawing.Size(160, 24);
            this.PulseTypeBox.TabIndex = 36;
            // 
            // LaserBox854FREQ
            // 
            this.LaserBox854FREQ.AutoSize = true;
            this.LaserBox854FREQ.Location = new System.Drawing.Point(11, 122);
            this.LaserBox854FREQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserBox854FREQ.Name = "LaserBox854FREQ";
            this.LaserBox854FREQ.Size = new System.Drawing.Size(116, 26);
            this.LaserBox854FREQ.TabIndex = 35;
            this.LaserBox854FREQ.Text = "854 Freq";
            this.LaserBox854FREQ.UseVisualStyleBackColor = true;
            // 
            // LaserBox854
            // 
            this.LaserBox854.AutoSize = true;
            this.LaserBox854.Location = new System.Drawing.Point(11, 94);
            this.LaserBox854.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserBox854.Name = "LaserBox854";
            this.LaserBox854.Size = new System.Drawing.Size(72, 26);
            this.LaserBox854.TabIndex = 34;
            this.LaserBox854.Text = "854";
            this.LaserBox854.UseVisualStyleBackColor = true;
            // 
            // LaserBox729
            // 
            this.LaserBox729.AutoSize = true;
            this.LaserBox729.Location = new System.Drawing.Point(11, 65);
            this.LaserBox729.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserBox729.Name = "LaserBox729";
            this.LaserBox729.Size = new System.Drawing.Size(72, 26);
            this.LaserBox729.TabIndex = 33;
            this.LaserBox729.Text = "729";
            this.LaserBox729.UseVisualStyleBackColor = true;
            // 
            // LaserBox397B2
            // 
            this.LaserBox397B2.AutoSize = true;
            this.LaserBox397B2.Location = new System.Drawing.Point(11, 37);
            this.LaserBox397B2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserBox397B2.Name = "LaserBox397B2";
            this.LaserBox397B2.Size = new System.Drawing.Size(100, 26);
            this.LaserBox397B2.TabIndex = 32;
            this.LaserBox397B2.Text = "397 B2";
            this.LaserBox397B2.UseVisualStyleBackColor = true;
            // 
            // LaserBox397B1
            // 
            this.LaserBox397B1.AutoSize = true;
            this.LaserBox397B1.Location = new System.Drawing.Point(11, 9);
            this.LaserBox397B1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserBox397B1.Name = "LaserBox397B1";
            this.LaserBox397B1.Size = new System.Drawing.Size(100, 26);
            this.LaserBox397B1.TabIndex = 31;
            this.LaserBox397B1.Text = "397 B1";
            this.LaserBox397B1.UseVisualStyleBackColor = true;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(413, 27);
            this.NameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(160, 22);
            this.NameBox.TabIndex = 45;
            this.NameBox.Text = "Default Name";
            // 
            // CreateFromTemplateButton
            // 
            this.CreateFromTemplateButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateFromTemplateButton.Image")));
            this.CreateFromTemplateButton.Location = new System.Drawing.Point(363, 422);
            this.CreateFromTemplateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CreateFromTemplateButton.Name = "CreateFromTemplateButton";
            this.CreateFromTemplateButton.Size = new System.Drawing.Size(140, 71);
            this.CreateFromTemplateButton.TabIndex = 50;
            this.CreateFromTemplateButton.UseVisualStyleBackColor = true;
            // 
            // OpenXMLButton
            // 
            this.OpenXMLButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenXMLButton.Image")));
            this.OpenXMLButton.Location = new System.Drawing.Point(511, 422);
            this.OpenXMLButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OpenXMLButton.Name = "OpenXMLButton";
            this.OpenXMLButton.Size = new System.Drawing.Size(140, 71);
            this.OpenXMLButton.TabIndex = 51;
            this.OpenXMLButton.UseVisualStyleBackColor = true;
            this.OpenXMLButton.Click += new System.EventHandler(this.OpenXMLButton_Click);
            // 
            // SaveXMLButton
            // 
            this.SaveXMLButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveXMLButton.Image")));
            this.SaveXMLButton.Location = new System.Drawing.Point(363, 501);
            this.SaveXMLButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveXMLButton.Name = "SaveXMLButton";
            this.SaveXMLButton.Size = new System.Drawing.Size(140, 71);
            this.SaveXMLButton.TabIndex = 52;
            this.SaveXMLButton.UseVisualStyleBackColor = true;
            this.SaveXMLButton.Click += new System.EventHandler(this.SaveXMLButton_Click);
            // 
            // BinaryCompileButton
            // 
            this.BinaryCompileButton.Image = ((System.Drawing.Image)(resources.GetObject("BinaryCompileButton.Image")));
            this.BinaryCompileButton.Location = new System.Drawing.Point(511, 501);
            this.BinaryCompileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BinaryCompileButton.Name = "BinaryCompileButton";
            this.BinaryCompileButton.Size = new System.Drawing.Size(140, 71);
            this.BinaryCompileButton.TabIndex = 53;
            this.BinaryCompileButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(363, 410);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 6);
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
            this.DesignerGroup.Location = new System.Drawing.Point(16, 6);
            this.DesignerGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DesignerGroup.Name = "DesignerGroup";
            this.DesignerGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DesignerGroup.Size = new System.Drawing.Size(663, 585);
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
            this.SpectroGroup.Controls.Add(this.numericUpDown2);
            this.SpectroGroup.Controls.Add(FileSendBox);
            this.SpectroGroup.Controls.Add(this.UploadButton);
            this.SpectroGroup.Controls.Add(this.label14);
            this.SpectroGroup.Controls.Add(this.numericUpDown1);
            this.SpectroGroup.Controls.Add(this.label13);
            this.SpectroGroup.Controls.Add(this.RFAmplitudeBox);
            this.SpectroGroup.Controls.Add(this.label12);
            this.SpectroGroup.Controls.Add(this.SidebandWidthBox);
            this.SpectroGroup.Controls.Add(this.label11);
            this.SpectroGroup.Controls.Add(this.SidebandNumberBox);
            this.SpectroGroup.Controls.Add(this.label10);
            this.SpectroGroup.Controls.Add(this.StepSizeBox);
            this.SpectroGroup.Controls.Add(this.label9);
            this.SpectroGroup.Controls.Add(this.CarrierFrequencyBox);
            this.SpectroGroup.Controls.Add(this.label8);
            this.SpectroGroup.Controls.Add(this.StartFrequencyBox);
            this.SpectroGroup.Controls.Add(this.label7);
            this.SpectroGroup.Controls.Add(this.TrapFrequencyBox);
            this.SpectroGroup.Controls.Add(this.label6);
            this.SpectroGroup.Controls.Add(this.label5);
            this.SpectroGroup.Controls.Add(this.AxialRadialBox);
            this.SpectroGroup.Controls.Add(this.TrapVoltageBox);
            this.SpectroGroup.Controls.Add(this.label3);
            this.SpectroGroup.Controls.Add(this.SpecTypeBox);
            this.SpectroGroup.Location = new System.Drawing.Point(693, 6);
            this.SpectroGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpectroGroup.Name = "SpectroGroup";
            this.SpectroGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpectroGroup.Size = new System.Drawing.Size(349, 583);
            this.SpectroGroup.TabIndex = 56;
            this.SpectroGroup.TabStop = false;
            this.SpectroGroup.Text = "Spectroscopy Sweep Control";
            // 
            // StopButton
            // 
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.Location = new System.Drawing.Point(261, 501);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(77, 71);
            this.StopButton.TabIndex = 61;
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // PauseButton
            // 
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(179, 501);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(77, 71);
            this.PauseButton.TabIndex = 58;
            this.PauseButton.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.Location = new System.Drawing.Point(93, 501);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(77, 71);
            this.StartButton.TabIndex = 59;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetButton.Image")));
            this.ResetButton.Location = new System.Drawing.Point(8, 501);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(77, 71);
            this.ResetButton.TabIndex = 57;
            this.ResetButton.UseVisualStyleBackColor = true;
            // 
            // OpenUSBButton
            // 
            this.OpenUSBButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenUSBButton.Image")));
            this.OpenUSBButton.Location = new System.Drawing.Point(8, 422);
            this.OpenUSBButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OpenUSBButton.Name = "OpenUSBButton";
            this.OpenUSBButton.Size = new System.Drawing.Size(77, 71);
            this.OpenUSBButton.TabIndex = 60;
            this.OpenUSBButton.UseVisualStyleBackColor = true;
            this.OpenUSBButton.Click += new System.EventHandler(this.OpenUSBButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 191);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 17);
            this.label15.TabIndex = 24;
            this.label15.Text = "Magnetron Freq (kHz)";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown2.Location = new System.Drawing.Point(200, 188);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(139, 22);
            this.numericUpDown2.TabIndex = 23;
            this.numericUpDown2.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // UploadButton
            // 
            this.UploadButton.Image = ((System.Drawing.Image)(resources.GetObject("UploadButton.Image")));
            this.UploadButton.Location = new System.Drawing.Point(93, 422);
            this.UploadButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(77, 71);
            this.UploadButton.TabIndex = 55;
            this.UploadButton.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 159);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 17);
            this.label14.TabIndex = 22;
            this.label14.Text = "Modified Cyc Freq (kHz)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(200, 156);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(139, 22);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            670,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 383);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "729 RF Amplitude (dBm)";
            // 
            // RFAmplitudeBox
            // 
            this.RFAmplitudeBox.DecimalPlaces = 1;
            this.RFAmplitudeBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RFAmplitudeBox.Location = new System.Drawing.Point(200, 380);
            this.RFAmplitudeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RFAmplitudeBox.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.RFAmplitudeBox.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.RFAmplitudeBox.Name = "RFAmplitudeBox";
            this.RFAmplitudeBox.Size = new System.Drawing.Size(139, 22);
            this.RFAmplitudeBox.TabIndex = 19;
            this.RFAmplitudeBox.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 351);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Sideband Width (Steps)";
            // 
            // SidebandWidthBox
            // 
            this.SidebandWidthBox.Location = new System.Drawing.Point(200, 348);
            this.SidebandWidthBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SidebandWidthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SidebandWidthBox.Name = "SidebandWidthBox";
            this.SidebandWidthBox.Size = new System.Drawing.Size(139, 22);
            this.SidebandWidthBox.TabIndex = 17;
            this.SidebandWidthBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 319);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "Sidebands to scan/side";
            // 
            // SidebandNumberBox
            // 
            this.SidebandNumberBox.Location = new System.Drawing.Point(200, 316);
            this.SidebandNumberBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SidebandNumberBox.Name = "SidebandNumberBox";
            this.SidebandNumberBox.Size = new System.Drawing.Size(139, 22);
            this.SidebandNumberBox.TabIndex = 15;
            this.SidebandNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 287);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Step Size (kHz)";
            // 
            // StepSizeBox
            // 
            this.StepSizeBox.DecimalPlaces = 1;
            this.StepSizeBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.StepSizeBox.Location = new System.Drawing.Point(200, 284);
            this.StepSizeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StepSizeBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.StepSizeBox.Name = "StepSizeBox";
            this.StepSizeBox.Size = new System.Drawing.Size(139, 22);
            this.StepSizeBox.TabIndex = 13;
            this.StepSizeBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 255);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Carrier Frequency (MHz)";
            // 
            // CarrierFrequencyBox
            // 
            this.CarrierFrequencyBox.DecimalPlaces = 3;
            this.CarrierFrequencyBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.CarrierFrequencyBox.Location = new System.Drawing.Point(200, 252);
            this.CarrierFrequencyBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CarrierFrequencyBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CarrierFrequencyBox.Name = "CarrierFrequencyBox";
            this.CarrierFrequencyBox.Size = new System.Drawing.Size(139, 22);
            this.CarrierFrequencyBox.TabIndex = 11;
            this.CarrierFrequencyBox.Value = new decimal(new int[] {
            230000000,
            0,
            0,
            393216});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Start Frequency (MHz)";
            // 
            // StartFrequencyBox
            // 
            this.StartFrequencyBox.DecimalPlaces = 3;
            this.StartFrequencyBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.StartFrequencyBox.Location = new System.Drawing.Point(200, 220);
            this.StartFrequencyBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartFrequencyBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.StartFrequencyBox.Name = "StartFrequencyBox";
            this.StartFrequencyBox.Size = new System.Drawing.Size(139, 22);
            this.StartFrequencyBox.TabIndex = 9;
            this.StartFrequencyBox.Value = new decimal(new int[] {
            230000000,
            0,
            0,
            393216});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 127);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Axial Freq (kHz)";
            // 
            // TrapFrequencyBox
            // 
            this.TrapFrequencyBox.DecimalPlaces = 1;
            this.TrapFrequencyBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TrapFrequencyBox.Location = new System.Drawing.Point(200, 124);
            this.TrapFrequencyBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TrapFrequencyBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TrapFrequencyBox.Name = "TrapFrequencyBox";
            this.TrapFrequencyBox.Size = new System.Drawing.Size(139, 22);
            this.TrapFrequencyBox.TabIndex = 7;
            this.TrapFrequencyBox.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Trap Voltage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "729 Direction";
            // 
            // AxialRadialBox
            // 
            this.AxialRadialBox.FormattingEnabled = true;
            this.AxialRadialBox.Items.AddRange(new object[] {
            "Axial",
            "Radial"});
            this.AxialRadialBox.Location = new System.Drawing.Point(200, 59);
            this.AxialRadialBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AxialRadialBox.Name = "AxialRadialBox";
            this.AxialRadialBox.Size = new System.Drawing.Size(137, 24);
            this.AxialRadialBox.TabIndex = 4;
            this.AxialRadialBox.Text = "Select";
            // 
            // TrapVoltageBox
            // 
            this.TrapVoltageBox.DecimalPlaces = 3;
            this.TrapVoltageBox.Location = new System.Drawing.Point(200, 92);
            this.TrapVoltageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TrapVoltageBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TrapVoltageBox.Name = "TrapVoltageBox";
            this.TrapVoltageBox.Size = new System.Drawing.Size(139, 22);
            this.TrapVoltageBox.TabIndex = 3;
            this.TrapVoltageBox.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Spectrum Type";
            // 
            // SpecTypeBox
            // 
            this.SpecTypeBox.FormattingEnabled = true;
            this.SpecTypeBox.Items.AddRange(new object[] {
            "Continuous",
            "Windowed"});
            this.SpecTypeBox.Location = new System.Drawing.Point(200, 26);
            this.SpecTypeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpecTypeBox.Name = "SpecTypeBox";
            this.SpecTypeBox.Size = new System.Drawing.Size(137, 24);
            this.SpecTypeBox.TabIndex = 1;
            this.SpecTypeBox.Text = "Select";
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
            this.LaserControl.Location = new System.Drawing.Point(1057, 6);
            this.LaserControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserControl.Name = "LaserControl";
            this.LaserControl.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LaserControl.Size = new System.Drawing.Size(340, 583);
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
            this.panel4.Location = new System.Drawing.Point(16, 473);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(307, 99);
            this.panel4.TabIndex = 67;
            // 
            // SetRFSB3Button
            // 
            this.SetRFSB3Button.Location = new System.Drawing.Point(184, 58);
            this.SetRFSB3Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetRFSB3Button.Name = "SetRFSB3Button";
            this.SetRFSB3Button.Size = new System.Drawing.Size(115, 33);
            this.SetRFSB3Button.TabIndex = 68;
            this.SetRFSB3Button.Text = "Set";
            this.SetRFSB3Button.UseVisualStyleBackColor = true;
            this.SetRFSB3Button.Click += new System.EventHandler(this.SetRFSB3Button_Click);
            // 
            // SB3RFFreq
            // 
            this.SB3RFFreq.Location = new System.Drawing.Point(4, 32);
            this.SB3RFFreq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SB3RFFreq.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SB3RFFreq.Name = "SB3RFFreq";
            this.SB3RFFreq.Size = new System.Drawing.Size(151, 22);
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
            this.label22.Location = new System.Drawing.Point(163, 34);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(106, 17);
            this.label22.TabIndex = 64;
            this.label22.Text = "Frequency (Hz)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(68, 66);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(112, 17);
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
            this.SB3RFAmp.Location = new System.Drawing.Point(4, 64);
            this.SB3RFAmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.SB3RFAmp.Size = new System.Drawing.Size(61, 22);
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
            this.SB3RFSourceButton.Location = new System.Drawing.Point(4, 4);
            this.SB3RFSourceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SB3RFSourceButton.Name = "SB3RFSourceButton";
            this.SB3RFSourceButton.Size = new System.Drawing.Size(219, 21);
            this.SB3RFSourceButton.TabIndex = 8;
            this.SB3RFSourceButton.TabStop = true;
            this.SB3RFSourceButton.Tag = "SB3";
            this.SB3RFSourceButton.Text = "729nm Sideband RF Source 3";
            this.SB3RFSourceButton.UseVisualStyleBackColor = true;
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
            this.panel3.Location = new System.Drawing.Point(16, 366);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 99);
            this.panel3.TabIndex = 66;
            // 
            // SetRFSB2Button
            // 
            this.SetRFSB2Button.Location = new System.Drawing.Point(184, 58);
            this.SetRFSB2Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetRFSB2Button.Name = "SetRFSB2Button";
            this.SetRFSB2Button.Size = new System.Drawing.Size(115, 33);
            this.SetRFSB2Button.TabIndex = 67;
            this.SetRFSB2Button.Text = "Set";
            this.SetRFSB2Button.UseVisualStyleBackColor = true;
            this.SetRFSB2Button.Click += new System.EventHandler(this.SetRFSB2Button_Click);
            // 
            // SB2RFFreq
            // 
            this.SB2RFFreq.Location = new System.Drawing.Point(4, 32);
            this.SB2RFFreq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SB2RFFreq.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SB2RFFreq.Name = "SB2RFFreq";
            this.SB2RFFreq.Size = new System.Drawing.Size(151, 22);
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
            this.label20.Location = new System.Drawing.Point(163, 34);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 17);
            this.label20.TabIndex = 64;
            this.label20.Text = "Frequency (Hz)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(69, 66);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 17);
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
            this.SB2RFAmp.Location = new System.Drawing.Point(4, 64);
            this.SB2RFAmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.SB2RFAmp.Size = new System.Drawing.Size(61, 22);
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
            this.SB2RFSourceButton.Location = new System.Drawing.Point(4, 4);
            this.SB2RFSourceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SB2RFSourceButton.Name = "SB2RFSourceButton";
            this.SB2RFSourceButton.Size = new System.Drawing.Size(219, 21);
            this.SB2RFSourceButton.TabIndex = 8;
            this.SB2RFSourceButton.TabStop = true;
            this.SB2RFSourceButton.Tag = "SB2";
            this.SB2RFSourceButton.Text = "729nm Sideband RF Source 2";
            this.SB2RFSourceButton.UseVisualStyleBackColor = true;
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
            this.panel2.Location = new System.Drawing.Point(16, 258);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 99);
            this.panel2.TabIndex = 65;
            // 
            // SetRFSB1Button
            // 
            this.SetRFSB1Button.Location = new System.Drawing.Point(184, 58);
            this.SetRFSB1Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetRFSB1Button.Name = "SetRFSB1Button";
            this.SetRFSB1Button.Size = new System.Drawing.Size(115, 33);
            this.SetRFSB1Button.TabIndex = 66;
            this.SetRFSB1Button.Text = "Set";
            this.SetRFSB1Button.UseVisualStyleBackColor = true;
            this.SetRFSB1Button.Click += new System.EventHandler(this.SetRFSB1Button_Click);
            // 
            // SB1RFFreq
            // 
            this.SB1RFFreq.Location = new System.Drawing.Point(4, 32);
            this.SB1RFFreq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SB1RFFreq.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SB1RFFreq.Name = "SB1RFFreq";
            this.SB1RFFreq.Size = new System.Drawing.Size(151, 22);
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
            this.label18.Location = new System.Drawing.Point(163, 34);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 17);
            this.label18.TabIndex = 64;
            this.label18.Text = "Frequency (Hz)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(68, 66);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 17);
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
            this.SB1RFAmp.Location = new System.Drawing.Point(4, 64);
            this.SB1RFAmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.SB1RFAmp.Size = new System.Drawing.Size(61, 22);
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
            this.SB1RFSourceButton.Location = new System.Drawing.Point(4, 4);
            this.SB1RFSourceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SB1RFSourceButton.Name = "SB1RFSourceButton";
            this.SB1RFSourceButton.Size = new System.Drawing.Size(219, 21);
            this.SB1RFSourceButton.TabIndex = 8;
            this.SB1RFSourceButton.TabStop = true;
            this.SB1RFSourceButton.Tag = "SB1";
            this.SB1RFSourceButton.Text = "729nm Sideband RF Source 1";
            this.SB1RFSourceButton.UseVisualStyleBackColor = true;
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
            this.panel1.Location = new System.Drawing.Point(16, 151);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 99);
            this.panel1.TabIndex = 12;
            // 
            // SetRFSpecButton
            // 
            this.SetRFSpecButton.Location = new System.Drawing.Point(184, 58);
            this.SetRFSpecButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetRFSpecButton.Name = "SetRFSpecButton";
            this.SetRFSpecButton.Size = new System.Drawing.Size(115, 33);
            this.SetRFSpecButton.TabIndex = 65;
            this.SetRFSpecButton.Text = "Set";
            this.SetRFSpecButton.UseVisualStyleBackColor = true;
            this.SetRFSpecButton.Click += new System.EventHandler(this.SetRFSpecButton_Click);
            // 
            // SpecRFFreq
            // 
            this.SpecRFFreq.Location = new System.Drawing.Point(4, 32);
            this.SpecRFFreq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpecRFFreq.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.SpecRFFreq.Name = "SpecRFFreq";
            this.SpecRFFreq.Size = new System.Drawing.Size(151, 22);
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
            this.label17.Location = new System.Drawing.Point(163, 34);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 17);
            this.label17.TabIndex = 64;
            this.label17.Text = "Frequency (Hz)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(68, 66);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 17);
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
            this.SpecRFAmp.Location = new System.Drawing.Point(4, 64);
            this.SpecRFAmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.SpecRFAmp.Size = new System.Drawing.Size(61, 22);
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
            this.SpecRFSourceButton.Location = new System.Drawing.Point(4, 4);
            this.SpecRFSourceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpecRFSourceButton.Name = "SpecRFSourceButton";
            this.SpecRFSourceButton.Size = new System.Drawing.Size(233, 21);
            this.SpecRFSourceButton.TabIndex = 8;
            this.SpecRFSourceButton.TabStop = true;
            this.SpecRFSourceButton.Tag = "Spec";
            this.SpecRFSourceButton.Text = "729nm Spectroscopy RF Source";
            this.SpecRFSourceButton.UseVisualStyleBackColor = true;
            // 
            // LiveLaserBoxAux2
            // 
            this.LiveLaserBoxAux2.AutoSize = true;
            this.LiveLaserBoxAux2.Location = new System.Drawing.Point(177, 113);
            this.LiveLaserBoxAux2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LiveLaserBoxAux2.Name = "LiveLaserBoxAux2";
            this.LiveLaserBoxAux2.Size = new System.Drawing.Size(97, 21);
            this.LiveLaserBoxAux2.TabIndex = 7;
            this.LiveLaserBoxAux2.Text = "Auxilliary 2";
            this.LiveLaserBoxAux2.UseVisualStyleBackColor = true;
            // 
            // LiveLaserBoxAux1
            // 
            this.LiveLaserBoxAux1.AutoSize = true;
            this.LiveLaserBoxAux1.Location = new System.Drawing.Point(177, 85);
            this.LiveLaserBoxAux1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LiveLaserBoxAux1.Name = "LiveLaserBoxAux1";
            this.LiveLaserBoxAux1.Size = new System.Drawing.Size(97, 21);
            this.LiveLaserBoxAux1.TabIndex = 6;
            this.LiveLaserBoxAux1.Text = "Auxilliary 1";
            this.LiveLaserBoxAux1.UseVisualStyleBackColor = true;
            // 
            // LiveLaserBox854FREQ
            // 
            this.LiveLaserBox854FREQ.AutoSize = true;
            this.LiveLaserBox854FREQ.Location = new System.Drawing.Point(177, 57);
            this.LiveLaserBox854FREQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LiveLaserBox854FREQ.Name = "LiveLaserBox854FREQ";
            this.LiveLaserBox854FREQ.Size = new System.Drawing.Size(144, 21);
            this.LiveLaserBox854FREQ.TabIndex = 5;
            this.LiveLaserBox854FREQ.Text = "854nm Frequency";
            this.LiveLaserBox854FREQ.UseVisualStyleBackColor = true;
            // 
            // LiveLaserBox854POWER
            // 
            this.LiveLaserBox854POWER.AutoSize = true;
            this.LiveLaserBox854POWER.Location = new System.Drawing.Point(177, 28);
            this.LiveLaserBox854POWER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LiveLaserBox854POWER.Name = "LiveLaserBox854POWER";
            this.LiveLaserBox854POWER.Size = new System.Drawing.Size(116, 21);
            this.LiveLaserBox854POWER.TabIndex = 4;
            this.LiveLaserBox854POWER.Text = "854nm Power";
            this.LiveLaserBox854POWER.UseVisualStyleBackColor = true;
            // 
            // LiveLaserBox854
            // 
            this.LiveLaserBox854.AutoSize = true;
            this.LiveLaserBox854.Location = new System.Drawing.Point(16, 113);
            this.LiveLaserBox854.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LiveLaserBox854.Name = "LiveLaserBox854";
            this.LiveLaserBox854.Size = new System.Drawing.Size(73, 21);
            this.LiveLaserBox854.TabIndex = 3;
            this.LiveLaserBox854.Text = "854nm";
            this.LiveLaserBox854.UseVisualStyleBackColor = true;
            // 
            // LiveLaserBox729
            // 
            this.LiveLaserBox729.AutoSize = true;
            this.LiveLaserBox729.Location = new System.Drawing.Point(16, 85);
            this.LiveLaserBox729.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LiveLaserBox729.Name = "LiveLaserBox729";
            this.LiveLaserBox729.Size = new System.Drawing.Size(73, 21);
            this.LiveLaserBox729.TabIndex = 2;
            this.LiveLaserBox729.Text = "729nm";
            this.LiveLaserBox729.UseVisualStyleBackColor = true;
            // 
            // LiveLaserBox397B2
            // 
            this.LiveLaserBox397B2.AutoSize = true;
            this.LiveLaserBox397B2.Location = new System.Drawing.Point(16, 57);
            this.LiveLaserBox397B2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LiveLaserBox397B2.Name = "LiveLaserBox397B2";
            this.LiveLaserBox397B2.Size = new System.Drawing.Size(94, 21);
            this.LiveLaserBox397B2.TabIndex = 1;
            this.LiveLaserBox397B2.Text = "397nm B2";
            this.LiveLaserBox397B2.UseVisualStyleBackColor = true;
            // 
            // LiveLaserBox397B1
            // 
            this.LiveLaserBox397B1.AutoSize = true;
            this.LiveLaserBox397B1.Location = new System.Drawing.Point(16, 28);
            this.LiveLaserBox397B1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LiveLaserBox397B1.Name = "LiveLaserBox397B1";
            this.LiveLaserBox397B1.Size = new System.Drawing.Size(94, 21);
            this.LiveLaserBox397B1.TabIndex = 0;
            this.LiveLaserBox397B1.Text = "397nm B1";
            this.LiveLaserBox397B1.UseVisualStyleBackColor = true;
            // 
            // debugmessagebox
            // 
            this.debugmessagebox.Controls.Add(this.MessagesBox);
            this.debugmessagebox.Location = new System.Drawing.Point(16, 597);
            this.debugmessagebox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.debugmessagebox.Name = "debugmessagebox";
            this.debugmessagebox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.debugmessagebox.Size = new System.Drawing.Size(1381, 203);
            this.debugmessagebox.TabIndex = 58;
            this.debugmessagebox.TabStop = false;
            this.debugmessagebox.Text = "Debug Messages";
            // 
            // MessagesBox
            // 
            this.MessagesBox.Location = new System.Drawing.Point(16, 23);
            this.MessagesBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MessagesBox.Name = "MessagesBox";
            this.MessagesBox.Size = new System.Drawing.Size(1349, 162);
            this.MessagesBox.TabIndex = 0;
            this.MessagesBox.UseCompatibleStateImageBehavior = false;
            // 
            // openXMLFileDialog
            // 
            this.openXMLFileDialog.FileName = "openFileDialog1";
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 815);
            this.Controls.Add(this.debugmessagebox);
            this.Controls.Add(this.LaserControl);
            this.Controls.Add(this.SpectroGroup);
            this.Controls.Add(this.DesignerGroup);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RFAmplitudeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SidebandWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SidebandNumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarrierFrequencyBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartFrequencyBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrapFrequencyBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrapVoltageBox)).EndInit();
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
        private System.Windows.Forms.CheckBox LaserBox854FREQ;
        private System.Windows.Forms.CheckBox LaserBox854;
        private System.Windows.Forms.CheckBox LaserBox729;
        private System.Windows.Forms.CheckBox LaserBox397B2;
        private System.Windows.Forms.CheckBox LaserBox397B1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.CheckBox LaserBoxAux2;
        private System.Windows.Forms.CheckBox LaserBoxAux1;
        private System.Windows.Forms.CheckBox LaserBox854POWER;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown SourceSelect729;
        private System.Windows.Forms.Button CreateFromTemplateButton;
        private System.Windows.Forms.Button OpenXMLButton;
        private System.Windows.Forms.Button SaveXMLButton;
        private System.Windows.Forms.Button BinaryCompileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox DesignerGroup;
        private System.Windows.Forms.GroupBox SpectroGroup;
        private System.Windows.Forms.ComboBox SpecTypeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox AxialRadialBox;
        private System.Windows.Forms.NumericUpDown TrapVoltageBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown RFAmplitudeBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown SidebandWidthBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown SidebandNumberBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown StepSizeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown CarrierFrequencyBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown StartFrequencyBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown TrapFrequencyBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
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
    }
}

