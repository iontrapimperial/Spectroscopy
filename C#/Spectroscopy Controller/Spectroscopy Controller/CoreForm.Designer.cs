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
            this.components = new System.ComponentModel.Container();
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
            this.COM12 = new System.IO.Ports.SerialPort(this.components);
            this.NameBox = new System.Windows.Forms.TextBox();
            this.CreateFromTemplateButton = new System.Windows.Forms.Button();
            this.OpenXMLButton = new System.Windows.Forms.Button();
            this.SaveXMLButton = new System.Windows.Forms.Button();
            this.BinaryCompileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DesignerGroup = new System.Windows.Forms.GroupBox();
            this.SpectroGroup = new System.Windows.Forms.GroupBox();
            this.mleCheckBox = new System.Windows.Forms.CheckBox();
            this.cameraCheck = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.phaseStep = new System.Windows.Forms.NumericUpDown();
            this.carrierCheck = new System.Windows.Forms.CheckBox();
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
            this.powerNorm = new System.Windows.Forms.CheckBox();
            this.SetDDSProfiles = new System.Windows.Forms.Button();
            this.resetProfiles = new System.Windows.Forms.Button();
            this.resetDDS = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.profile7radioButton = new System.Windows.Forms.RadioButton();
            this.label46 = new System.Windows.Forms.Label();
            this.phase7 = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.amp7 = new System.Windows.Forms.NumericUpDown();
            this.freq7 = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.profile6radioButton = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
            this.phase6 = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.amp6 = new System.Windows.Forms.NumericUpDown();
            this.freq6 = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.profile5radioButton = new System.Windows.Forms.RadioButton();
            this.label45 = new System.Windows.Forms.Label();
            this.phase5 = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.amp5 = new System.Windows.Forms.NumericUpDown();
            this.freq5 = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.profile4radioButton = new System.Windows.Forms.RadioButton();
            this.label41 = new System.Windows.Forms.Label();
            this.phase4 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.amp4 = new System.Windows.Forms.NumericUpDown();
            this.freq4 = new System.Windows.Forms.NumericUpDown();
            this.label36 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.profile3radioButton = new System.Windows.Forms.RadioButton();
            this.label44 = new System.Windows.Forms.Label();
            this.phase3 = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.amp3 = new System.Windows.Forms.NumericUpDown();
            this.freq3 = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.profile2radioButton = new System.Windows.Forms.RadioButton();
            this.label40 = new System.Windows.Forms.Label();
            this.phase2 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.amp2 = new System.Windows.Forms.NumericUpDown();
            this.freq2 = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.profile1radioButton = new System.Windows.Forms.RadioButton();
            this.label43 = new System.Windows.Forms.Label();
            this.phase1 = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.amp1 = new System.Windows.Forms.NumericUpDown();
            this.freq1 = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.profile0radioButton = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.phase0 = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.amp0 = new System.Windows.Forms.NumericUpDown();
            this.freq0 = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.LiveLaserBoxAux1 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox854FREQ = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox854POWER = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox854 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox729 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox397B2 = new System.Windows.Forms.CheckBox();
            this.LiveLaserBox397B1 = new System.Windows.Forms.CheckBox();
            this.debugmessagebox = new System.Windows.Forms.GroupBox();
            this.MessagesBox = new System.Windows.Forms.ListView();
            this.Messages = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveXMLFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openXMLFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openHexFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveHexFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenViewerButton = new System.Windows.Forms.Button();
            this.ClearBoxButton = new System.Windows.Forms.Button();
            this.OpenCamera = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.phaseStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modcycFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbToScanBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axFreqBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trapVBox)).BeginInit();
            this.LaserControl.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq7)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq6)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq5)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq4)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq2)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq0)).BeginInit();
            this.debugmessagebox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileSendBox
            // 
            FileSendBox.AutoSize = true;
            FileSendBox.Controls.Add(this.ProgressLabel);
            FileSendBox.Location = new System.Drawing.Point(131, 363);
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
            this.PulseTree.Size = new System.Drawing.Size(254, 435);
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
            this.SaveStateButton.Location = new System.Drawing.Point(272, 315);
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
            this.PulseTypeTabs.Size = new System.Drawing.Size(216, 259);
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
            this.LoopTabPage.Size = new System.Drawing.Size(208, 233);
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
            this.PulseTabPage.Size = new System.Drawing.Size(208, 233);
            this.PulseTabPage.TabIndex = 1;
            this.PulseTabPage.Text = "Create Laser Pulse";
            this.PulseTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "DDS Profile";
            // 
            // SourceSelect729
            // 
            this.SourceSelect729.Location = new System.Drawing.Point(8, 191);
            this.SourceSelect729.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.SourceSelect729.Name = "SourceSelect729";
            this.SourceSelect729.Size = new System.Drawing.Size(44, 20);
            this.SourceSelect729.TabIndex = 44;
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
            this.TimeLabel.Location = new System.Drawing.Point(88, 86);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(93, 13);
            this.TimeLabel.TabIndex = 40;
            this.TimeLabel.Text = "Exact Length: 0us";
            // 
            // TicksBox
            // 
            this.TicksBox.DecimalPlaces = 2;
            this.TicksBox.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.TicksBox.Location = new System.Drawing.Point(87, 63);
            this.TicksBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TicksBox.Name = "TicksBox";
            this.TicksBox.Size = new System.Drawing.Size(117, 20);
            this.TicksBox.TabIndex = 37;
            this.TicksBox.Value = new decimal(new int[] {
            72,
            0,
            0,
            131072});
            this.TicksBox.ValueChanged += new System.EventHandler(this.TicksBox_ValueChanged);
            // 
            // PulseTypeBox
            // 
            this.PulseTypeBox.FormattingEnabled = true;
            this.PulseTypeBox.Items.AddRange(new object[] {
            "Other",
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
            // COM12
            // 
            this.COM12.PortName = "COM12";
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
            this.CreateFromTemplateButton.Location = new System.Drawing.Point(272, 363);
            this.CreateFromTemplateButton.Name = "CreateFromTemplateButton";
            this.CreateFromTemplateButton.Size = new System.Drawing.Size(105, 58);
            this.CreateFromTemplateButton.TabIndex = 50;
            this.CreateFromTemplateButton.UseVisualStyleBackColor = true;
            this.CreateFromTemplateButton.Click += new System.EventHandler(this.CreateFromTemplateButton_Click);
            // 
            // OpenXMLButton
            // 
            this.OpenXMLButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenXMLButton.Image")));
            this.OpenXMLButton.Location = new System.Drawing.Point(383, 363);
            this.OpenXMLButton.Name = "OpenXMLButton";
            this.OpenXMLButton.Size = new System.Drawing.Size(105, 58);
            this.OpenXMLButton.TabIndex = 51;
            this.OpenXMLButton.UseVisualStyleBackColor = true;
            this.OpenXMLButton.Click += new System.EventHandler(this.OpenXMLButton_Click);
            // 
            // SaveXMLButton
            // 
            this.SaveXMLButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveXMLButton.Image")));
            this.SaveXMLButton.Location = new System.Drawing.Point(272, 427);
            this.SaveXMLButton.Name = "SaveXMLButton";
            this.SaveXMLButton.Size = new System.Drawing.Size(105, 58);
            this.SaveXMLButton.TabIndex = 52;
            this.SaveXMLButton.UseVisualStyleBackColor = true;
            this.SaveXMLButton.Click += new System.EventHandler(this.SaveXMLButton_Click);
            // 
            // BinaryCompileButton
            // 
            this.BinaryCompileButton.Image = ((System.Drawing.Image)(resources.GetObject("BinaryCompileButton.Image")));
            this.BinaryCompileButton.Location = new System.Drawing.Point(383, 427);
            this.BinaryCompileButton.Name = "BinaryCompileButton";
            this.BinaryCompileButton.Size = new System.Drawing.Size(105, 58);
            this.BinaryCompileButton.TabIndex = 53;
            this.BinaryCompileButton.UseVisualStyleBackColor = true;
            this.BinaryCompileButton.Click += new System.EventHandler(this.BinaryCompileButton_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(272, 351);
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
            this.DesignerGroup.Size = new System.Drawing.Size(497, 499);
            this.DesignerGroup.TabIndex = 55;
            this.DesignerGroup.TabStop = false;
            this.DesignerGroup.Text = "Pulse Sequence Designer";
            // 
            // SpectroGroup
            // 
            this.SpectroGroup.Controls.Add(this.mleCheckBox);
            this.SpectroGroup.Controls.Add(this.cameraCheck);
            this.SpectroGroup.Controls.Add(this.label25);
            this.SpectroGroup.Controls.Add(this.phaseStep);
            this.SpectroGroup.Controls.Add(this.carrierCheck);
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
            this.SpectroGroup.Size = new System.Drawing.Size(262, 499);
            this.SpectroGroup.TabIndex = 56;
            this.SpectroGroup.TabStop = false;
            this.SpectroGroup.Text = "Spectroscopy Sweep Control";
            // 
            // mleCheckBox
            // 
            this.mleCheckBox.AutoSize = true;
            this.mleCheckBox.Location = new System.Drawing.Point(200, 339);
            this.mleCheckBox.Name = "mleCheckBox";
            this.mleCheckBox.Size = new System.Drawing.Size(48, 17);
            this.mleCheckBox.TabIndex = 63;
            this.mleCheckBox.Text = "MLE";
            this.mleCheckBox.UseVisualStyleBackColor = true;
            // 
            // cameraCheck
            // 
            this.cameraCheck.AutoSize = true;
            this.cameraCheck.Location = new System.Drawing.Point(18, 339);
            this.cameraCheck.Name = "cameraCheck";
            this.cameraCheck.Size = new System.Drawing.Size(110, 17);
            this.cameraCheck.TabIndex = 65;
            this.cameraCheck.Text = "Camera Spectrum";
            this.cameraCheck.UseVisualStyleBackColor = true;
            this.cameraCheck.CheckedChanged += new System.EventHandler(this.cameraCheck_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(15, 311);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(75, 13);
            this.label25.TabIndex = 64;
            this.label25.Text = "Phase Step (°)";
            // 
            // phaseStep
            // 
            this.phaseStep.DecimalPlaces = 2;
            this.phaseStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phaseStep.Location = new System.Drawing.Point(150, 309);
            this.phaseStep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.phaseStep.Name = "phaseStep";
            this.phaseStep.Size = new System.Drawing.Size(104, 20);
            this.phaseStep.TabIndex = 63;
            // 
            // carrierCheck
            // 
            this.carrierCheck.AutoSize = true;
            this.carrierCheck.Location = new System.Drawing.Point(134, 339);
            this.carrierCheck.Name = "carrierCheck";
            this.carrierCheck.Size = new System.Drawing.Size(56, 17);
            this.carrierCheck.TabIndex = 62;
            this.carrierCheck.Text = "Carrier";
            this.carrierCheck.UseVisualStyleBackColor = true;
            this.carrierCheck.CheckedChanged += new System.EventHandler(this.carrierCheck_CheckedChanged);
            // 
            // StopButton
            // 
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.Location = new System.Drawing.Point(193, 427);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(58, 58);
            this.StopButton.TabIndex = 61;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(131, 427);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(58, 58);
            this.PauseButton.TabIndex = 58;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.Location = new System.Drawing.Point(67, 427);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(58, 58);
            this.StartButton.TabIndex = 59;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetButton.Image")));
            this.ResetButton.Location = new System.Drawing.Point(3, 427);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(58, 58);
            this.ResetButton.TabIndex = 57;
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // OpenUSBButton
            // 
            this.OpenUSBButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenUSBButton.Image")));
            this.OpenUSBButton.Location = new System.Drawing.Point(3, 363);
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
            this.UploadButton.Location = new System.Drawing.Point(67, 363);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(58, 58);
            this.UploadButton.TabIndex = 55;
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
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
            this.label10.Size = new System.Drawing.Size(122, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Step Size (kHz on AOM)";
            // 
            // stepSizeBox
            // 
            this.stepSizeBox.DecimalPlaces = 3;
            this.stepSizeBox.Location = new System.Drawing.Point(150, 231);
            this.stepSizeBox.Maximum = new decimal(new int[] {
            10000,
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
            this.stepSizeBox.ValueChanged += new System.EventHandler(this.stepSizeBox_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Carrier Freq (MHz AOM)";
            // 
            // carFreqBox
            // 
            this.carFreqBox.DecimalPlaces = 5;
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
            178000000,
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
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Start Freq (MHz AOM)";
            // 
            // startFreqBox
            // 
            this.startFreqBox.DecimalPlaces = 5;
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
            178000000,
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
            this.LaserControl.Controls.Add(this.powerNorm);
            this.LaserControl.Controls.Add(this.SetDDSProfiles);
            this.LaserControl.Controls.Add(this.resetProfiles);
            this.LaserControl.Controls.Add(this.resetDDS);
            this.LaserControl.Controls.Add(this.panel8);
            this.LaserControl.Controls.Add(this.panel4);
            this.LaserControl.Controls.Add(this.panel7);
            this.LaserControl.Controls.Add(this.panel3);
            this.LaserControl.Controls.Add(this.panel6);
            this.LaserControl.Controls.Add(this.panel2);
            this.LaserControl.Controls.Add(this.panel5);
            this.LaserControl.Controls.Add(this.panel1);
            this.LaserControl.Controls.Add(this.LiveLaserBoxAux1);
            this.LaserControl.Controls.Add(this.LiveLaserBox854FREQ);
            this.LaserControl.Controls.Add(this.LiveLaserBox854POWER);
            this.LaserControl.Controls.Add(this.LiveLaserBox854);
            this.LaserControl.Controls.Add(this.LiveLaserBox729);
            this.LaserControl.Controls.Add(this.LiveLaserBox397B2);
            this.LaserControl.Controls.Add(this.LiveLaserBox397B1);
            this.LaserControl.Location = new System.Drawing.Point(793, 5);
            this.LaserControl.Name = "LaserControl";
            this.LaserControl.Size = new System.Drawing.Size(459, 609);
            this.LaserControl.TabIndex = 57;
            this.LaserControl.TabStop = false;
            this.LaserControl.Text = "Laser Control";
            // 
            // powerNorm
            // 
            this.powerNorm.AutoSize = true;
            this.powerNorm.Location = new System.Drawing.Point(366, 48);
            this.powerNorm.Name = "powerNorm";
            this.powerNorm.Size = new System.Drawing.Size(84, 17);
            this.powerNorm.TabIndex = 70;
            this.powerNorm.Text = "Power Norm";
            this.powerNorm.UseVisualStyleBackColor = true;
            // 
            // SetDDSProfiles
            // 
            this.SetDDSProfiles.Location = new System.Drawing.Point(299, 561);
            this.SetDDSProfiles.Name = "SetDDSProfiles";
            this.SetDDSProfiles.Size = new System.Drawing.Size(83, 40);
            this.SetDDSProfiles.TabIndex = 69;
            this.SetDDSProfiles.Text = "Set Profiles";
            this.SetDDSProfiles.UseVisualStyleBackColor = true;
            this.SetDDSProfiles.Click += new System.EventHandler(this.SetDDSProfiles_Click);
            // 
            // resetProfiles
            // 
            this.resetProfiles.Location = new System.Drawing.Point(179, 561);
            this.resetProfiles.Name = "resetProfiles";
            this.resetProfiles.Size = new System.Drawing.Size(92, 40);
            this.resetProfiles.TabIndex = 68;
            this.resetProfiles.Text = "Reset Profiles";
            this.resetProfiles.UseVisualStyleBackColor = true;
            this.resetProfiles.Click += new System.EventHandler(this.resetProfiles_Click);
            // 
            // resetDDS
            // 
            this.resetDDS.ForeColor = System.Drawing.Color.Black;
            this.resetDDS.Location = new System.Drawing.Point(58, 561);
            this.resetDDS.Name = "resetDDS";
            this.resetDDS.Size = new System.Drawing.Size(92, 40);
            this.resetDDS.TabIndex = 67;
            this.resetDDS.Text = "Reset DDS";
            this.resetDDS.UseVisualStyleBackColor = true;
            this.resetDDS.Click += new System.EventHandler(this.resetDDS_Click);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.profile7radioButton);
            this.panel8.Controls.Add(this.label46);
            this.panel8.Controls.Add(this.phase7);
            this.panel8.Controls.Add(this.label23);
            this.panel8.Controls.Add(this.amp7);
            this.panel8.Controls.Add(this.freq7);
            this.panel8.Controls.Add(this.label39);
            this.panel8.Location = new System.Drawing.Point(230, 446);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 110);
            this.panel8.TabIndex = 66;
            // 
            // profile7radioButton
            // 
            this.profile7radioButton.AutoSize = true;
            this.profile7radioButton.Location = new System.Drawing.Point(4, 2);
            this.profile7radioButton.Name = "profile7radioButton";
            this.profile7radioButton.Size = new System.Drawing.Size(89, 17);
            this.profile7radioButton.TabIndex = 73;
            this.profile7radioButton.Tag = "profile7";
            this.profile7radioButton.Text = "DDS Profile 7";
            this.profile7radioButton.UseVisualStyleBackColor = true;
            this.profile7radioButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(100, 78);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(50, 13);
            this.label46.TabIndex = 71;
            this.label46.Text = "Phase (°)";
            // 
            // phase7
            // 
            this.phase7.DecimalPlaces = 2;
            this.phase7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phase7.Location = new System.Drawing.Point(29, 75);
            this.phase7.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.phase7.Name = "phase7";
            this.phase7.Size = new System.Drawing.Size(65, 20);
            this.phase7.TabIndex = 70;
            this.phase7.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(100, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 13);
            this.label23.TabIndex = 22;
            this.label23.Text = "Amplitude (%)";
            // 
            // amp7
            // 
            this.amp7.DecimalPlaces = 1;
            this.amp7.Location = new System.Drawing.Point(44, 50);
            this.amp7.Name = "amp7";
            this.amp7.Size = new System.Drawing.Size(50, 20);
            this.amp7.TabIndex = 21;
            this.amp7.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.amp7.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // freq7
            // 
            this.freq7.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freq7.Location = new System.Drawing.Point(4, 25);
            this.freq7.Maximum = new decimal(new int[] {
            300000000,
            0,
            0,
            0});
            this.freq7.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.freq7.Name = "freq7";
            this.freq7.Size = new System.Drawing.Size(90, 20);
            this.freq7.TabIndex = 62;
            this.freq7.ThousandsSeparator = true;
            this.freq7.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            0});
            this.freq7.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(100, 28);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(79, 13);
            this.label39.TabIndex = 64;
            this.label39.Text = "Frequency (Hz)";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.profile6radioButton);
            this.panel4.Controls.Add(this.label42);
            this.panel4.Controls.Add(this.phase6);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.amp6);
            this.panel4.Controls.Add(this.freq6);
            this.panel4.Controls.Add(this.label38);
            this.panel4.Location = new System.Drawing.Point(12, 446);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 110);
            this.panel4.TabIndex = 66;
            // 
            // profile6radioButton
            // 
            this.profile6radioButton.AutoSize = true;
            this.profile6radioButton.Location = new System.Drawing.Point(4, 2);
            this.profile6radioButton.Name = "profile6radioButton";
            this.profile6radioButton.Size = new System.Drawing.Size(89, 17);
            this.profile6radioButton.TabIndex = 73;
            this.profile6radioButton.Tag = "profile6";
            this.profile6radioButton.Text = "DDS Profile 6";
            this.profile6radioButton.UseVisualStyleBackColor = true;
            this.profile6radioButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(100, 78);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(50, 13);
            this.label42.TabIndex = 70;
            this.label42.Text = "Phase (°)";
            // 
            // phase6
            // 
            this.phase6.DecimalPlaces = 2;
            this.phase6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phase6.Location = new System.Drawing.Point(29, 75);
            this.phase6.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.phase6.Name = "phase6";
            this.phase6.Size = new System.Drawing.Size(65, 20);
            this.phase6.TabIndex = 69;
            this.phase6.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(100, 53);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Amplitude (%)";
            // 
            // amp6
            // 
            this.amp6.DecimalPlaces = 1;
            this.amp6.Location = new System.Drawing.Point(44, 50);
            this.amp6.Name = "amp6";
            this.amp6.Size = new System.Drawing.Size(50, 20);
            this.amp6.TabIndex = 21;
            this.amp6.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.amp6.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // freq6
            // 
            this.freq6.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freq6.Location = new System.Drawing.Point(4, 25);
            this.freq6.Maximum = new decimal(new int[] {
            300000000,
            0,
            0,
            0});
            this.freq6.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.freq6.Name = "freq6";
            this.freq6.Size = new System.Drawing.Size(90, 20);
            this.freq6.TabIndex = 62;
            this.freq6.ThousandsSeparator = true;
            this.freq6.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            0});
            this.freq6.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(100, 28);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(79, 13);
            this.label38.TabIndex = 64;
            this.label38.Text = "Frequency (Hz)";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.profile5radioButton);
            this.panel7.Controls.Add(this.label45);
            this.panel7.Controls.Add(this.phase5);
            this.panel7.Controls.Add(this.label22);
            this.panel7.Controls.Add(this.amp5);
            this.panel7.Controls.Add(this.freq5);
            this.panel7.Controls.Add(this.label37);
            this.panel7.Location = new System.Drawing.Point(230, 324);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 110);
            this.panel7.TabIndex = 66;
            // 
            // profile5radioButton
            // 
            this.profile5radioButton.AutoSize = true;
            this.profile5radioButton.Location = new System.Drawing.Point(4, 2);
            this.profile5radioButton.Name = "profile5radioButton";
            this.profile5radioButton.Size = new System.Drawing.Size(89, 17);
            this.profile5radioButton.TabIndex = 72;
            this.profile5radioButton.Tag = "profile5";
            this.profile5radioButton.Text = "DDS Profile 5";
            this.profile5radioButton.UseVisualStyleBackColor = true;
            this.profile5radioButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(100, 78);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(50, 13);
            this.label45.TabIndex = 70;
            this.label45.Text = "Phase (°)";
            // 
            // phase5
            // 
            this.phase5.DecimalPlaces = 2;
            this.phase5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phase5.Location = new System.Drawing.Point(29, 75);
            this.phase5.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.phase5.Name = "phase5";
            this.phase5.Size = new System.Drawing.Size(65, 20);
            this.phase5.TabIndex = 69;
            this.phase5.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(100, 53);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 13);
            this.label22.TabIndex = 22;
            this.label22.Text = "Amplitude (%)";
            // 
            // amp5
            // 
            this.amp5.DecimalPlaces = 1;
            this.amp5.Location = new System.Drawing.Point(44, 50);
            this.amp5.Name = "amp5";
            this.amp5.Size = new System.Drawing.Size(50, 20);
            this.amp5.TabIndex = 21;
            this.amp5.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.amp5.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // freq5
            // 
            this.freq5.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freq5.Location = new System.Drawing.Point(4, 25);
            this.freq5.Maximum = new decimal(new int[] {
            300000000,
            0,
            0,
            0});
            this.freq5.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.freq5.Name = "freq5";
            this.freq5.Size = new System.Drawing.Size(90, 20);
            this.freq5.TabIndex = 62;
            this.freq5.ThousandsSeparator = true;
            this.freq5.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            0});
            this.freq5.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(100, 28);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(79, 13);
            this.label37.TabIndex = 64;
            this.label37.Text = "Frequency (Hz)";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.profile4radioButton);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.phase4);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.amp4);
            this.panel3.Controls.Add(this.freq4);
            this.panel3.Controls.Add(this.label36);
            this.panel3.Location = new System.Drawing.Point(12, 324);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 110);
            this.panel3.TabIndex = 66;
            // 
            // profile4radioButton
            // 
            this.profile4radioButton.AutoSize = true;
            this.profile4radioButton.Location = new System.Drawing.Point(4, 2);
            this.profile4radioButton.Name = "profile4radioButton";
            this.profile4radioButton.Size = new System.Drawing.Size(89, 17);
            this.profile4radioButton.TabIndex = 71;
            this.profile4radioButton.Tag = "profile4";
            this.profile4radioButton.Text = "DDS Profile 4";
            this.profile4radioButton.UseVisualStyleBackColor = true;
            this.profile4radioButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(100, 78);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(50, 13);
            this.label41.TabIndex = 69;
            this.label41.Text = "Phase (°)";
            // 
            // phase4
            // 
            this.phase4.DecimalPlaces = 2;
            this.phase4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phase4.Location = new System.Drawing.Point(29, 75);
            this.phase4.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.phase4.Name = "phase4";
            this.phase4.Size = new System.Drawing.Size(65, 20);
            this.phase4.TabIndex = 68;
            this.phase4.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(100, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Amplitude (%)";
            // 
            // amp4
            // 
            this.amp4.DecimalPlaces = 1;
            this.amp4.Location = new System.Drawing.Point(44, 50);
            this.amp4.Name = "amp4";
            this.amp4.Size = new System.Drawing.Size(50, 20);
            this.amp4.TabIndex = 21;
            this.amp4.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.amp4.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // freq4
            // 
            this.freq4.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freq4.Location = new System.Drawing.Point(4, 25);
            this.freq4.Maximum = new decimal(new int[] {
            300000000,
            0,
            0,
            0});
            this.freq4.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.freq4.Name = "freq4";
            this.freq4.Size = new System.Drawing.Size(90, 20);
            this.freq4.TabIndex = 62;
            this.freq4.ThousandsSeparator = true;
            this.freq4.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            0});
            this.freq4.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(100, 28);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(79, 13);
            this.label36.TabIndex = 64;
            this.label36.Text = "Frequency (Hz)";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.profile3radioButton);
            this.panel6.Controls.Add(this.label44);
            this.panel6.Controls.Add(this.phase3);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.amp3);
            this.panel6.Controls.Add(this.freq3);
            this.panel6.Controls.Add(this.label35);
            this.panel6.Location = new System.Drawing.Point(230, 202);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 110);
            this.panel6.TabIndex = 66;
            // 
            // profile3radioButton
            // 
            this.profile3radioButton.AutoSize = true;
            this.profile3radioButton.Location = new System.Drawing.Point(4, 2);
            this.profile3radioButton.Name = "profile3radioButton";
            this.profile3radioButton.Size = new System.Drawing.Size(89, 17);
            this.profile3radioButton.TabIndex = 70;
            this.profile3radioButton.Tag = "profile3";
            this.profile3radioButton.Text = "DDS Profile 3";
            this.profile3radioButton.UseVisualStyleBackColor = true;
            this.profile3radioButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(122, 78);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(50, 13);
            this.label44.TabIndex = 69;
            this.label44.Text = "Phase (°)";
            // 
            // phase3
            // 
            this.phase3.DecimalPlaces = 2;
            this.phase3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phase3.Location = new System.Drawing.Point(29, 75);
            this.phase3.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.phase3.Name = "phase3";
            this.phase3.Size = new System.Drawing.Size(65, 20);
            this.phase3.TabIndex = 68;
            this.phase3.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(100, 53);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "Amplitude (%)";
            // 
            // amp3
            // 
            this.amp3.DecimalPlaces = 1;
            this.amp3.Location = new System.Drawing.Point(44, 50);
            this.amp3.Name = "amp3";
            this.amp3.Size = new System.Drawing.Size(50, 20);
            this.amp3.TabIndex = 21;
            this.amp3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.amp3.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // freq3
            // 
            this.freq3.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freq3.Location = new System.Drawing.Point(4, 25);
            this.freq3.Maximum = new decimal(new int[] {
            300000000,
            0,
            0,
            0});
            this.freq3.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.freq3.Name = "freq3";
            this.freq3.Size = new System.Drawing.Size(90, 20);
            this.freq3.TabIndex = 62;
            this.freq3.ThousandsSeparator = true;
            this.freq3.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            0});
            this.freq3.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(100, 28);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(79, 13);
            this.label35.TabIndex = 64;
            this.label35.Text = "Frequency (Hz)";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.profile2radioButton);
            this.panel2.Controls.Add(this.label40);
            this.panel2.Controls.Add(this.phase2);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.amp2);
            this.panel2.Controls.Add(this.freq2);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Location = new System.Drawing.Point(12, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 110);
            this.panel2.TabIndex = 66;
            // 
            // profile2radioButton
            // 
            this.profile2radioButton.AutoSize = true;
            this.profile2radioButton.Location = new System.Drawing.Point(4, 2);
            this.profile2radioButton.Name = "profile2radioButton";
            this.profile2radioButton.Size = new System.Drawing.Size(89, 17);
            this.profile2radioButton.TabIndex = 70;
            this.profile2radioButton.Tag = "profile2";
            this.profile2radioButton.Text = "DDS Profile 2";
            this.profile2radioButton.UseVisualStyleBackColor = true;
            this.profile2radioButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(100, 78);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(50, 13);
            this.label40.TabIndex = 68;
            this.label40.Text = "Phase (°)";
            // 
            // phase2
            // 
            this.phase2.DecimalPlaces = 2;
            this.phase2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phase2.Location = new System.Drawing.Point(29, 75);
            this.phase2.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.phase2.Name = "phase2";
            this.phase2.Size = new System.Drawing.Size(65, 20);
            this.phase2.TabIndex = 67;
            this.phase2.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(100, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Amplitude (%)";
            // 
            // amp2
            // 
            this.amp2.DecimalPlaces = 1;
            this.amp2.Location = new System.Drawing.Point(44, 50);
            this.amp2.Name = "amp2";
            this.amp2.Size = new System.Drawing.Size(50, 20);
            this.amp2.TabIndex = 21;
            this.amp2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.amp2.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // freq2
            // 
            this.freq2.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freq2.Location = new System.Drawing.Point(4, 25);
            this.freq2.Maximum = new decimal(new int[] {
            300000000,
            0,
            0,
            0});
            this.freq2.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.freq2.Name = "freq2";
            this.freq2.Size = new System.Drawing.Size(90, 20);
            this.freq2.TabIndex = 62;
            this.freq2.ThousandsSeparator = true;
            this.freq2.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            0});
            this.freq2.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(100, 28);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(79, 13);
            this.label34.TabIndex = 64;
            this.label34.Text = "Frequency (Hz)";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.profile1radioButton);
            this.panel5.Controls.Add(this.label43);
            this.panel5.Controls.Add(this.phase1);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.amp1);
            this.panel5.Controls.Add(this.freq1);
            this.panel5.Controls.Add(this.label33);
            this.panel5.Location = new System.Drawing.Point(230, 80);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 110);
            this.panel5.TabIndex = 66;
            // 
            // profile1radioButton
            // 
            this.profile1radioButton.AutoSize = true;
            this.profile1radioButton.Location = new System.Drawing.Point(4, 2);
            this.profile1radioButton.Name = "profile1radioButton";
            this.profile1radioButton.Size = new System.Drawing.Size(89, 17);
            this.profile1radioButton.TabIndex = 69;
            this.profile1radioButton.Tag = "profile1";
            this.profile1radioButton.Text = "DDS Profile 1";
            this.profile1radioButton.UseVisualStyleBackColor = true;
            this.profile1radioButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(100, 78);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(50, 13);
            this.label43.TabIndex = 68;
            this.label43.Text = "Phase (°)";
            // 
            // phase1
            // 
            this.phase1.DecimalPlaces = 2;
            this.phase1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phase1.Location = new System.Drawing.Point(29, 75);
            this.phase1.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.phase1.Name = "phase1";
            this.phase1.Size = new System.Drawing.Size(65, 20);
            this.phase1.TabIndex = 67;
            this.phase1.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(100, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "Amplitude (%)";
            // 
            // amp1
            // 
            this.amp1.DecimalPlaces = 1;
            this.amp1.Location = new System.Drawing.Point(44, 50);
            this.amp1.Name = "amp1";
            this.amp1.Size = new System.Drawing.Size(50, 20);
            this.amp1.TabIndex = 21;
            this.amp1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.amp1.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // freq1
            // 
            this.freq1.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.freq1.Location = new System.Drawing.Point(4, 25);
            this.freq1.Maximum = new decimal(new int[] {
            300000000,
            0,
            0,
            0});
            this.freq1.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.freq1.Name = "freq1";
            this.freq1.Size = new System.Drawing.Size(90, 20);
            this.freq1.TabIndex = 62;
            this.freq1.ThousandsSeparator = true;
            this.freq1.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            0});
            this.freq1.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(100, 28);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(79, 13);
            this.label33.TabIndex = 64;
            this.label33.Text = "Frequency (Hz)";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.profile0radioButton);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.phase0);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.amp0);
            this.panel1.Controls.Add(this.freq0);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(12, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 110);
            this.panel1.TabIndex = 12;
            // 
            // profile0radioButton
            // 
            this.profile0radioButton.AutoSize = true;
            this.profile0radioButton.Checked = true;
            this.profile0radioButton.Location = new System.Drawing.Point(4, 2);
            this.profile0radioButton.Name = "profile0radioButton";
            this.profile0radioButton.Size = new System.Drawing.Size(89, 17);
            this.profile0radioButton.TabIndex = 68;
            this.profile0radioButton.TabStop = true;
            this.profile0radioButton.Tag = "profile0";
            this.profile0radioButton.Text = "DDS Profile 0";
            this.profile0radioButton.UseVisualStyleBackColor = true;
            this.profile0radioButton.Click += new System.EventHandler(this.LaserBoxChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(100, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 67;
            this.label13.Text = "Phase (°)";
            // 
            // phase0
            // 
            this.phase0.DecimalPlaces = 2;
            this.phase0.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.phase0.Location = new System.Drawing.Point(29, 75);
            this.phase0.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.phase0.Name = "phase0";
            this.phase0.Size = new System.Drawing.Size(65, 20);
            this.phase0.TabIndex = 66;
            this.phase0.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(100, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "Amplitude (%)";
            // 
            // amp0
            // 
            this.amp0.DecimalPlaces = 1;
            this.amp0.Location = new System.Drawing.Point(44, 50);
            this.amp0.Name = "amp0";
            this.amp0.Size = new System.Drawing.Size(50, 20);
            this.amp0.TabIndex = 21;
            this.amp0.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.amp0.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // freq0
            // 
            this.freq0.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.freq0.Location = new System.Drawing.Point(4, 25);
            this.freq0.Maximum = new decimal(new int[] {
            300000000,
            0,
            0,
            0});
            this.freq0.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.freq0.Name = "freq0";
            this.freq0.Size = new System.Drawing.Size(90, 20);
            this.freq0.TabIndex = 62;
            this.freq0.ThousandsSeparator = true;
            this.freq0.Value = new decimal(new int[] {
            178000000,
            0,
            0,
            0});
            this.freq0.ValueChanged += new System.EventHandler(this.DDSBoxChange);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(100, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 64;
            this.label17.Text = "Frequency (Hz)";
            // 
            // LiveLaserBoxAux1
            // 
            this.LiveLaserBoxAux1.AutoSize = true;
            this.LiveLaserBoxAux1.Checked = true;
            this.LiveLaserBoxAux1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LiveLaserBoxAux1.Location = new System.Drawing.Point(366, 23);
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
            this.LiveLaserBox854FREQ.Checked = true;
            this.LiveLaserBox854FREQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LiveLaserBox854FREQ.Location = new System.Drawing.Point(248, 46);
            this.LiveLaserBox854FREQ.Name = "LiveLaserBox854FREQ";
            this.LiveLaserBox854FREQ.Size = new System.Drawing.Size(75, 17);
            this.LiveLaserBox854FREQ.TabIndex = 5;
            this.LiveLaserBox854FREQ.Text = "Axial AOM";
            this.LiveLaserBox854FREQ.UseVisualStyleBackColor = true;
            this.LiveLaserBox854FREQ.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBox854POWER
            // 
            this.LiveLaserBox854POWER.AutoSize = true;
            this.LiveLaserBox854POWER.Location = new System.Drawing.Point(248, 23);
            this.LiveLaserBox854POWER.Name = "LiveLaserBox854POWER";
            this.LiveLaserBox854POWER.Size = new System.Drawing.Size(57, 17);
            this.LiveLaserBox854POWER.TabIndex = 4;
            this.LiveLaserBox854POWER.Text = "Axi Off";
            this.LiveLaserBox854POWER.UseVisualStyleBackColor = true;
            this.LiveLaserBox854POWER.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            // 
            // LiveLaserBox854
            // 
            this.LiveLaserBox854.AutoSize = true;
            this.LiveLaserBox854.Checked = true;
            this.LiveLaserBox854.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LiveLaserBox854.Location = new System.Drawing.Point(130, 46);
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
            this.LiveLaserBox729.Location = new System.Drawing.Point(130, 23);
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
            this.LiveLaserBox397B2.Checked = true;
            this.LiveLaserBox397B2.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.LiveLaserBox397B1.Checked = true;
            this.LiveLaserBox397B1.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.debugmessagebox.Location = new System.Drawing.Point(12, 510);
            this.debugmessagebox.Name = "debugmessagebox";
            this.debugmessagebox.Size = new System.Drawing.Size(770, 186);
            this.debugmessagebox.TabIndex = 58;
            this.debugmessagebox.TabStop = false;
            this.debugmessagebox.Text = "Debug Messages";
            // 
            // MessagesBox
            // 
            this.MessagesBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Messages});
            this.MessagesBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.MessagesBox.Location = new System.Drawing.Point(12, 19);
            this.MessagesBox.Name = "MessagesBox";
            this.MessagesBox.Size = new System.Drawing.Size(747, 156);
            this.MessagesBox.TabIndex = 0;
            this.MessagesBox.UseCompatibleStateImageBehavior = false;
            this.MessagesBox.View = System.Windows.Forms.View.Details;
            // 
            // Messages
            // 
            this.Messages.Text = "";
            this.Messages.Width = 707;
            // 
            // saveXMLFileDialog
            // 
            this.saveXMLFileDialog.Filter = "Xml File|*.xml";
            this.saveXMLFileDialog.InitialDirectory = "C:\\Users\\IonTrap\\Box Sync\\Ion Trapping\\Current Data\\xml";
            this.saveXMLFileDialog.RestoreDirectory = true;
            this.saveXMLFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveXMLFileDialog_FileOk);
            // 
            // openXMLFileDialog
            // 
            this.openXMLFileDialog.Filter = "Xml File|*.xml";
            this.openXMLFileDialog.InitialDirectory = "C:\\Users\\IonTrap\\Box Sync\\Ion Trapping\\Current Data\\xml";
            this.openXMLFileDialog.RestoreDirectory = true;
            this.openXMLFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openXMLFileDialog_FileOk);
            // 
            // openHexFileDialog
            // 
            this.openHexFileDialog.Filter = "Hex File|*.hex";
            this.openHexFileDialog.InitialDirectory = "C:\\Users\\IonTrap\\Box Sync\\Ion Trapping\\Current Data\\Hex";
            this.openHexFileDialog.RestoreDirectory = true;
            this.openHexFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openHexFileDialog_FileOk);
            // 
            // saveHexFileDialog
            // 
            this.saveHexFileDialog.Filter = "Hex File|*.hex";
            this.saveHexFileDialog.InitialDirectory = "C:\\Users\\IonTrap\\Box Sync\\Ion Trapping\\Current Data\\Hex";
            this.saveHexFileDialog.RestoreDirectory = true;
            this.saveHexFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveHexFileDialog_FileOk);
            // 
            // OpenViewerButton
            // 
            this.OpenViewerButton.Location = new System.Drawing.Point(1152, 623);
            this.OpenViewerButton.Name = "OpenViewerButton";
            this.OpenViewerButton.Size = new System.Drawing.Size(91, 37);
            this.OpenViewerButton.TabIndex = 59;
            this.OpenViewerButton.Text = "Open Viewer";
            this.OpenViewerButton.UseVisualStyleBackColor = true;
            this.OpenViewerButton.Click += new System.EventHandler(this.OpenViewerButton_Click);
            // 
            // ClearBoxButton
            // 
            this.ClearBoxButton.AutoSize = true;
            this.ClearBoxButton.Location = new System.Drawing.Point(793, 620);
            this.ClearBoxButton.Name = "ClearBoxButton";
            this.ClearBoxButton.Size = new System.Drawing.Size(92, 40);
            this.ClearBoxButton.TabIndex = 60;
            this.ClearBoxButton.Text = "Clear Messages";
            this.ClearBoxButton.UseVisualStyleBackColor = true;
            this.ClearBoxButton.Click += new System.EventHandler(this.ClearBoxButton_Click);
            // 
            // OpenCamera
            // 
            this.OpenCamera.Location = new System.Drawing.Point(972, 621);
            this.OpenCamera.Name = "OpenCamera";
            this.OpenCamera.Size = new System.Drawing.Size(91, 40);
            this.OpenCamera.TabIndex = 61;
            this.OpenCamera.Text = "Start Camera";
            this.OpenCamera.UseVisualStyleBackColor = true;
            this.OpenCamera.Click += new System.EventHandler(this.OpenCamera_Click);
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 712);
            this.Controls.Add(this.OpenCamera);
            this.Controls.Add(this.ClearBoxButton);
            this.Controls.Add(this.OpenViewerButton);
            this.Controls.Add(this.debugmessagebox);
            this.Controls.Add(this.LaserControl);
            this.Controls.Add(this.SpectroGroup);
            this.Controls.Add(this.DesignerGroup);
            this.KeyPreview = true;
            this.Name = "CoreForm";
            this.Text = "Spectroscopy Controller";
            this.Load += new System.EventHandler(this.CoreForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoreForm_KeyDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.phaseStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modcycFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbToScanBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axFreqBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trapVBox)).EndInit();
            this.LaserControl.ResumeLayout(false);
            this.LaserControl.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq7)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq6)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq5)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq4)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phase0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amp0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq0)).EndInit();
            this.debugmessagebox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox LiveLaserBoxAux1;
        private System.Windows.Forms.CheckBox LiveLaserBox854FREQ;
        private System.Windows.Forms.CheckBox LiveLaserBox854POWER;
        private System.Windows.Forms.CheckBox LiveLaserBox854;
        private System.Windows.Forms.CheckBox LiveLaserBox729;
        private System.Windows.Forms.CheckBox LiveLaserBox397B2;
        private System.Windows.Forms.CheckBox LiveLaserBox397B1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown freq0;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox debugmessagebox;
        private System.Windows.Forms.ListView MessagesBox;
        private System.Windows.Forms.SaveFileDialog saveXMLFileDialog;
        private System.Windows.Forms.OpenFileDialog openXMLFileDialog;
        private System.Windows.Forms.OpenFileDialog openHexFileDialog;
        private System.Windows.Forms.SaveFileDialog saveHexFileDialog;
        private System.Windows.Forms.Button OpenViewerButton;
        private System.Windows.Forms.Button ClearBoxButton;
        private System.IO.Ports.SerialPort COM12;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown amp0;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown amp1;
        private System.Windows.Forms.NumericUpDown freq1;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown amp7;
        private System.Windows.Forms.NumericUpDown freq7;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown amp6;
        private System.Windows.Forms.NumericUpDown freq6;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown amp5;
        private System.Windows.Forms.NumericUpDown freq5;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown amp4;
        private System.Windows.Forms.NumericUpDown freq4;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown amp3;
        private System.Windows.Forms.NumericUpDown freq3;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown amp2;
        private System.Windows.Forms.NumericUpDown freq2;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button resetDDS;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.NumericUpDown phase2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown phase0;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.NumericUpDown phase4;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.NumericUpDown phase6;
        private System.Windows.Forms.NumericUpDown phase1;
        private System.Windows.Forms.NumericUpDown phase3;
        private System.Windows.Forms.NumericUpDown phase5;
        private System.Windows.Forms.NumericUpDown phase7;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button resetProfiles;
        private System.Windows.Forms.RadioButton profile3radioButton;
        private System.Windows.Forms.RadioButton profile2radioButton;
        private System.Windows.Forms.RadioButton profile1radioButton;
        private System.Windows.Forms.RadioButton profile0radioButton;
        private System.Windows.Forms.RadioButton profile5radioButton;
        private System.Windows.Forms.RadioButton profile4radioButton;
        private System.Windows.Forms.RadioButton profile7radioButton;
        private System.Windows.Forms.RadioButton profile6radioButton;
        private System.Windows.Forms.Button SetDDSProfiles;
        private System.Windows.Forms.ColumnHeader Messages;
        private System.Windows.Forms.CheckBox carrierCheck;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown phaseStep;
        private System.Windows.Forms.Button OpenCamera;
        private System.Windows.Forms.CheckBox cameraCheck;
        private System.Windows.Forms.CheckBox mleCheckBox;
        private System.Windows.Forms.CheckBox powerNorm;
    }
}

