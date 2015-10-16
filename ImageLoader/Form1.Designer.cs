namespace ImageLoader
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.morphOtsuRadioButton = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.upDownBinarGlobalRadius = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.upDownBinarLocalRadius = new System.Windows.Forms.NumericUpDown();
            this.morphNiblackRadioButton = new System.Windows.Forms.RadioButton();
            this.simpleBinRadioButton = new System.Windows.Forms.RadioButton();
            this.wolfRadioButton = new System.Windows.Forms.RadioButton();
            this.sauvolaRadioButton = new System.Windows.Forms.RadioButton();
            this.niblackRadioButton = new System.Windows.Forms.RadioButton();
            this.upDownBinarizationK = new System.Windows.Forms.NumericUpDown();
            this.upDownBinarThreshold = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.upDownRansacIterations = new System.Windows.Forms.NumericUpDown();
            this.upDownRansacOutliers = new System.Windows.Forms.NumericUpDown();
            this.upDownRansacSample = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.upDownCropDistance = new System.Windows.Forms.NumericUpDown();
            this.upDownCropStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.upDownLimitUsBrightness = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.upDownRelativeEstimationLimit = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.upDownBrightLinesLimit = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.upDownUsDeviationStreak = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.upDownBrightPixelLimit = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.kuwaharaPicture = new System.Windows.Forms.PictureBox();
            this.sourcePicture = new System.Windows.Forms.PictureBox();
            this.elastoPicture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.binarizationPicture = new System.Windows.Forms.PictureBox();
            this.edgePicture = new System.Windows.Forms.PictureBox();
            this.morphologyPicture = new System.Windows.Forms.PictureBox();
            this.choosingPicture = new System.Windows.Forms.PictureBox();
            this.approximationPicture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.upDownEdgeRightCentral = new System.Windows.Forms.NumericUpDown();
            this.upDownEdgeRight = new System.Windows.Forms.NumericUpDown();
            this.upDownEdgeLeft2Central = new System.Windows.Forms.NumericUpDown();
            this.upDownEdgeLeft2 = new System.Windows.Forms.NumericUpDown();
            this.upDownEdgeLeft1Central = new System.Windows.Forms.NumericUpDown();
            this.upDownEdgeLeft1 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxLog2 = new System.Windows.Forms.GroupBox();
            this.signatureBox = new System.Windows.Forms.ListBox();
            this.groupBoxLog1 = new System.Windows.Forms.GroupBox();
            this.resultBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadButton = new System.Windows.Forms.Button();
            this.buttonNextImage = new System.Windows.Forms.Button();
            this.buttonPrevImage = new System.Windows.Forms.Button();
            this.groupBoxStat = new System.Windows.Forms.GroupBox();
            this.commonStatBox = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.savingStepsCheckBox = new System.Windows.Forms.CheckBox();
            this.saveClassificationCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.timeDelayCheckBox = new System.Windows.Forms.CheckBox();
            this.upDownTimeDelay = new System.Windows.Forms.NumericUpDown();
            this.upDownFilesNumber = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.groupProcessingButton = new System.Windows.Forms.Button();
            this.teachFileLoadButton = new System.Windows.Forms.Button();
            this.processingButton = new System.Windows.Forms.Button();
            this.productionCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.sourceModMPicture = new System.Windows.Forms.PictureBox();
            this.outModMPicture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.sourceModAPicture = new System.Windows.Forms.PictureBox();
            this.outModAPicture = new System.Windows.Forms.PictureBox();
            this.cropPicture = new System.Windows.Forms.PictureBox();
            this.productionPicture = new System.Windows.Forms.PictureBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.leftToolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBinarGlobalRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBinarLocalRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBinarizationK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBinarThreshold)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRansacIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRansacOutliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRansacSample)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCropDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCropStep)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLimitUsBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRelativeEstimationLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBrightLinesLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownUsDeviationStreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBrightPixelLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kuwaharaPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elastoPicture)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binarizationPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.morphologyPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.choosingPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.approximationPicture)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeRightCentral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeLeft2Central)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeLeft2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeLeft1Central)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeLeft1)).BeginInit();
            this.groupBoxLog2.SuspendLayout();
            this.groupBoxLog1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxStat.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownTimeDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownFilesNumber)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceModMPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outModMPicture)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceModAPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outModAPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cropPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processingToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1173, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.processingToolStripMenuItem.Text = "Processing";
            this.processingToolStripMenuItem.Click += new System.EventHandler(this.processingToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // leftToolStrip
            // 
            this.leftToolStrip.AutoSize = false;
            this.leftToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton1,
            this.toolStripButton2});
            this.leftToolStrip.Location = new System.Drawing.Point(0, 24);
            this.leftToolStrip.Name = "leftToolStrip";
            this.leftToolStrip.Size = new System.Drawing.Size(46, 688);
            this.leftToolStrip.TabIndex = 5;
            this.leftToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(42, 42);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(42, 42);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(42, 42);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 69);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elastogram settings";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(134, 45);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.ReadOnly = true;
            this.numericUpDown3.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown3.TabIndex = 5;
            this.numericUpDown3.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Morphology";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kuwahara\'s kernel";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(134, 20);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            29,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.morphOtsuRadioButton);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.upDownBinarGlobalRadius);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.upDownBinarLocalRadius);
            this.groupBox5.Controls.Add(this.morphNiblackRadioButton);
            this.groupBox5.Controls.Add(this.simpleBinRadioButton);
            this.groupBox5.Controls.Add(this.wolfRadioButton);
            this.groupBox5.Controls.Add(this.sauvolaRadioButton);
            this.groupBox5.Controls.Add(this.niblackRadioButton);
            this.groupBox5.Controls.Add(this.upDownBinarizationK);
            this.groupBox5.Controls.Add(this.upDownBinarThreshold);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(218, 214);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Binarizations";
            // 
            // morphOtsuRadioButton
            // 
            this.morphOtsuRadioButton.AutoSize = true;
            this.morphOtsuRadioButton.Location = new System.Drawing.Point(9, 65);
            this.morphOtsuRadioButton.Name = "morphOtsuRadioButton";
            this.morphOtsuRadioButton.Size = new System.Drawing.Size(162, 17);
            this.morphOtsuRadioButton.TabIndex = 19;
            this.morphOtsuRadioButton.TabStop = true;
            this.morphOtsuRadioButton.Text = "Otsu Morphology Binarization";
            this.morphOtsuRadioButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Local Radius";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Global Radius";
            // 
            // upDownBinarGlobalRadius
            // 
            this.upDownBinarGlobalRadius.Location = new System.Drawing.Point(125, 189);
            this.upDownBinarGlobalRadius.Name = "upDownBinarGlobalRadius";
            this.upDownBinarGlobalRadius.ReadOnly = true;
            this.upDownBinarGlobalRadius.Size = new System.Drawing.Size(53, 20);
            this.upDownBinarGlobalRadius.TabIndex = 16;
            this.upDownBinarGlobalRadius.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "k";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Global threshold";
            // 
            // upDownBinarLocalRadius
            // 
            this.upDownBinarLocalRadius.Location = new System.Drawing.Point(125, 163);
            this.upDownBinarLocalRadius.Name = "upDownBinarLocalRadius";
            this.upDownBinarLocalRadius.ReadOnly = true;
            this.upDownBinarLocalRadius.Size = new System.Drawing.Size(53, 20);
            this.upDownBinarLocalRadius.TabIndex = 13;
            this.upDownBinarLocalRadius.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // morphNiblackRadioButton
            // 
            this.morphNiblackRadioButton.AutoSize = true;
            this.morphNiblackRadioButton.Checked = true;
            this.morphNiblackRadioButton.Location = new System.Drawing.Point(6, 88);
            this.morphNiblackRadioButton.Name = "morphNiblackRadioButton";
            this.morphNiblackRadioButton.Size = new System.Drawing.Size(176, 17);
            this.morphNiblackRadioButton.TabIndex = 12;
            this.morphNiblackRadioButton.TabStop = true;
            this.morphNiblackRadioButton.Text = "Niblack Morphology Binarization";
            this.morphNiblackRadioButton.UseVisualStyleBackColor = true;
            // 
            // simpleBinRadioButton
            // 
            this.simpleBinRadioButton.AutoSize = true;
            this.simpleBinRadioButton.Location = new System.Drawing.Point(9, 19);
            this.simpleBinRadioButton.Name = "simpleBinRadioButton";
            this.simpleBinRadioButton.Size = new System.Drawing.Size(112, 17);
            this.simpleBinRadioButton.TabIndex = 11;
            this.simpleBinRadioButton.Text = "Simple binarization";
            this.simpleBinRadioButton.UseVisualStyleBackColor = true;
            // 
            // wolfRadioButton
            // 
            this.wolfRadioButton.AutoSize = true;
            this.wolfRadioButton.Location = new System.Drawing.Point(125, 42);
            this.wolfRadioButton.Name = "wolfRadioButton";
            this.wolfRadioButton.Size = new System.Drawing.Size(80, 17);
            this.wolfRadioButton.TabIndex = 10;
            this.wolfRadioButton.TabStop = true;
            this.wolfRadioButton.Text = "WolfJoulion";
            this.wolfRadioButton.UseVisualStyleBackColor = true;
            // 
            // sauvolaRadioButton
            // 
            this.sauvolaRadioButton.AutoSize = true;
            this.sauvolaRadioButton.Location = new System.Drawing.Point(9, 42);
            this.sauvolaRadioButton.Name = "sauvolaRadioButton";
            this.sauvolaRadioButton.Size = new System.Drawing.Size(64, 17);
            this.sauvolaRadioButton.TabIndex = 9;
            this.sauvolaRadioButton.TabStop = true;
            this.sauvolaRadioButton.Text = "Sauvola";
            this.sauvolaRadioButton.UseVisualStyleBackColor = true;
            // 
            // niblackRadioButton
            // 
            this.niblackRadioButton.AutoSize = true;
            this.niblackRadioButton.Location = new System.Drawing.Point(125, 19);
            this.niblackRadioButton.Name = "niblackRadioButton";
            this.niblackRadioButton.Size = new System.Drawing.Size(61, 17);
            this.niblackRadioButton.TabIndex = 0;
            this.niblackRadioButton.TabStop = true;
            this.niblackRadioButton.Text = "Niblack";
            this.niblackRadioButton.UseVisualStyleBackColor = true;
            // 
            // upDownBinarizationK
            // 
            this.upDownBinarizationK.DecimalPlaces = 2;
            this.upDownBinarizationK.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upDownBinarizationK.Location = new System.Drawing.Point(125, 137);
            this.upDownBinarizationK.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownBinarizationK.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.upDownBinarizationK.Name = "upDownBinarizationK";
            this.upDownBinarizationK.ReadOnly = true;
            this.upDownBinarizationK.Size = new System.Drawing.Size(53, 20);
            this.upDownBinarizationK.TabIndex = 8;
            this.upDownBinarizationK.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // upDownBinarThreshold
            // 
            this.upDownBinarThreshold.Location = new System.Drawing.Point(125, 111);
            this.upDownBinarThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upDownBinarThreshold.Name = "upDownBinarThreshold";
            this.upDownBinarThreshold.ReadOnly = true;
            this.upDownBinarThreshold.Size = new System.Drawing.Size(53, 20);
            this.upDownBinarThreshold.TabIndex = 7;
            this.upDownBinarThreshold.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.upDownRansacIterations);
            this.groupBox4.Controls.Add(this.upDownRansacOutliers);
            this.groupBox4.Controls.Add(this.upDownRansacSample);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 458);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(218, 74);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ransac";
            // 
            // upDownRansacIterations
            // 
            this.upDownRansacIterations.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.upDownRansacIterations.Location = new System.Drawing.Point(111, 47);
            this.upDownRansacIterations.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.upDownRansacIterations.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.upDownRansacIterations.Name = "upDownRansacIterations";
            this.upDownRansacIterations.Size = new System.Drawing.Size(70, 20);
            this.upDownRansacIterations.TabIndex = 9;
            this.upDownRansacIterations.Value = new decimal(new int[] {
            12000,
            0,
            0,
            0});
            // 
            // upDownRansacOutliers
            // 
            this.upDownRansacOutliers.DecimalPlaces = 2;
            this.upDownRansacOutliers.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.upDownRansacOutliers.Location = new System.Drawing.Point(167, 18);
            this.upDownRansacOutliers.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownRansacOutliers.Name = "upDownRansacOutliers";
            this.upDownRansacOutliers.Size = new System.Drawing.Size(46, 20);
            this.upDownRansacOutliers.TabIndex = 10;
            this.upDownRansacOutliers.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // upDownRansacSample
            // 
            this.upDownRansacSample.DecimalPlaces = 2;
            this.upDownRansacSample.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upDownRansacSample.Location = new System.Drawing.Point(55, 18);
            this.upDownRansacSample.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownRansacSample.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upDownRansacSample.Name = "upDownRansacSample";
            this.upDownRansacSample.Size = new System.Drawing.Size(46, 20);
            this.upDownRansacSample.TabIndex = 9;
            this.upDownRansacSample.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(50, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Iterations";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(117, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Outliers";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Sample";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.upDownCropDistance);
            this.groupBox3.Controls.Add(this.upDownCropStep);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 408);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 44);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Crop";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Distance";
            // 
            // upDownCropDistance
            // 
            this.upDownCropDistance.Location = new System.Drawing.Point(164, 19);
            this.upDownCropDistance.Name = "upDownCropDistance";
            this.upDownCropDistance.ReadOnly = true;
            this.upDownCropDistance.Size = new System.Drawing.Size(49, 20);
            this.upDownCropDistance.TabIndex = 7;
            this.upDownCropDistance.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // upDownCropStep
            // 
            this.upDownCropStep.Location = new System.Drawing.Point(42, 18);
            this.upDownCropStep.Name = "upDownCropStep";
            this.upDownCropStep.ReadOnly = true;
            this.upDownCropStep.Size = new System.Drawing.Size(49, 20);
            this.upDownCropStep.TabIndex = 1;
            this.upDownCropStep.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Step";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.upDownLimitUsBrightness);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.upDownRelativeEstimationLimit);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.upDownBrightLinesLimit);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.upDownUsDeviationStreak);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.upDownBrightPixelLimit);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 538);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 141);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ultrasound Settings";
            // 
            // upDownLimitUsBrightness
            // 
            this.upDownLimitUsBrightness.Location = new System.Drawing.Point(134, 111);
            this.upDownLimitUsBrightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upDownLimitUsBrightness.Name = "upDownLimitUsBrightness";
            this.upDownLimitUsBrightness.Size = new System.Drawing.Size(57, 20);
            this.upDownLimitUsBrightness.TabIndex = 17;
            this.upDownLimitUsBrightness.Value = new decimal(new int[] {
            246,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 16;
            this.label21.Text = "Limit brightness";
            // 
            // upDownRelativeEstimationLimit
            // 
            this.upDownRelativeEstimationLimit.Location = new System.Drawing.Point(134, 88);
            this.upDownRelativeEstimationLimit.Name = "upDownRelativeEstimationLimit";
            this.upDownRelativeEstimationLimit.Size = new System.Drawing.Size(57, 20);
            this.upDownRelativeEstimationLimit.TabIndex = 15;
            this.upDownRelativeEstimationLimit.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 91);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(115, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "LimitRelativeEstimation";
            // 
            // upDownBrightLinesLimit
            // 
            this.upDownBrightLinesLimit.Location = new System.Drawing.Point(134, 64);
            this.upDownBrightLinesLimit.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.upDownBrightLinesLimit.Name = "upDownBrightLinesLimit";
            this.upDownBrightLinesLimit.Size = new System.Drawing.Size(57, 20);
            this.upDownBrightLinesLimit.TabIndex = 13;
            this.upDownBrightLinesLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "LimitBrightLines";
            // 
            // upDownUsDeviationStreak
            // 
            this.upDownUsDeviationStreak.Location = new System.Drawing.Point(134, 42);
            this.upDownUsDeviationStreak.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.upDownUsDeviationStreak.Name = "upDownUsDeviationStreak";
            this.upDownUsDeviationStreak.Size = new System.Drawing.Size(57, 20);
            this.upDownUsDeviationStreak.TabIndex = 11;
            this.upDownUsDeviationStreak.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "LimitStreakCount";
            // 
            // upDownBrightPixelLimit
            // 
            this.upDownBrightPixelLimit.Location = new System.Drawing.Point(134, 19);
            this.upDownBrightPixelLimit.Name = "upDownBrightPixelLimit";
            this.upDownBrightPixelLimit.Size = new System.Drawing.Size(57, 20);
            this.upDownBrightPixelLimit.TabIndex = 9;
            this.upDownBrightPixelLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "LimitBrightPixels";
            // 
            // kuwaharaPicture
            // 
            this.kuwaharaPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kuwaharaPicture.Location = new System.Drawing.Point(349, 173);
            this.kuwaharaPicture.Name = "kuwaharaPicture";
            this.kuwaharaPicture.Size = new System.Drawing.Size(167, 167);
            this.kuwaharaPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.kuwaharaPicture.TabIndex = 5;
            this.kuwaharaPicture.TabStop = false;
            this.kuwaharaPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // sourcePicture
            // 
            this.sourcePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcePicture.Location = new System.Drawing.Point(3, 173);
            this.sourcePicture.Name = "sourcePicture";
            this.sourcePicture.Size = new System.Drawing.Size(167, 167);
            this.sourcePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourcePicture.TabIndex = 3;
            this.sourcePicture.TabStop = false;
            this.sourcePicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // elastoPicture
            // 
            this.elastoPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elastoPicture.Location = new System.Drawing.Point(176, 173);
            this.elastoPicture.Name = "elastoPicture";
            this.elastoPicture.Size = new System.Drawing.Size(167, 167);
            this.elastoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.elastoPicture.TabIndex = 4;
            this.elastoPicture.TabStop = false;
            this.elastoPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.Controls.Add(this.elastoPicture, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.sourcePicture, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.kuwaharaPicture, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.binarizationPicture, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.edgePicture, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.morphologyPicture, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.choosingPicture, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.approximationPicture, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxLog2, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxLog1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cropPicture, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.productionPicture, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.20079F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1127, 688);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // binarizationPicture
            // 
            this.binarizationPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binarizationPicture.Location = new System.Drawing.Point(522, 173);
            this.binarizationPicture.Name = "binarizationPicture";
            this.binarizationPicture.Size = new System.Drawing.Size(167, 167);
            this.binarizationPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.binarizationPicture.TabIndex = 6;
            this.binarizationPicture.TabStop = false;
            this.binarizationPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // edgePicture
            // 
            this.edgePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edgePicture.Location = new System.Drawing.Point(3, 346);
            this.edgePicture.Name = "edgePicture";
            this.edgePicture.Size = new System.Drawing.Size(167, 167);
            this.edgePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.edgePicture.TabIndex = 7;
            this.edgePicture.TabStop = false;
            this.edgePicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // morphologyPicture
            // 
            this.morphologyPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.morphologyPicture.Location = new System.Drawing.Point(176, 346);
            this.morphologyPicture.Name = "morphologyPicture";
            this.morphologyPicture.Size = new System.Drawing.Size(167, 167);
            this.morphologyPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.morphologyPicture.TabIndex = 8;
            this.morphologyPicture.TabStop = false;
            this.morphologyPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // choosingPicture
            // 
            this.choosingPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choosingPicture.Location = new System.Drawing.Point(522, 346);
            this.choosingPicture.Name = "choosingPicture";
            this.choosingPicture.Size = new System.Drawing.Size(167, 167);
            this.choosingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.choosingPicture.TabIndex = 9;
            this.choosingPicture.TabStop = false;
            this.choosingPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // approximationPicture
            // 
            this.approximationPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.approximationPicture.Location = new System.Drawing.Point(3, 519);
            this.approximationPicture.Name = "approximationPicture";
            this.approximationPicture.Size = new System.Drawing.Size(167, 166);
            this.approximationPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.approximationPicture.TabIndex = 10;
            this.approximationPicture.TabStop = false;
            this.approximationPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox6, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(900, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(224, 682);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.upDownEdgeRightCentral);
            this.groupBox6.Controls.Add(this.upDownEdgeRight);
            this.groupBox6.Controls.Add(this.upDownEdgeLeft2Central);
            this.groupBox6.Controls.Add(this.upDownEdgeLeft2);
            this.groupBox6.Controls.Add(this.upDownEdgeLeft1Central);
            this.groupBox6.Controls.Add(this.upDownEdgeLeft1);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 298);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(218, 104);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "EdgeObjects";
            // 
            // upDownEdgeRightCentral
            // 
            this.upDownEdgeRightCentral.Location = new System.Drawing.Point(155, 76);
            this.upDownEdgeRightCentral.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.upDownEdgeRightCentral.Name = "upDownEdgeRightCentral";
            this.upDownEdgeRightCentral.Size = new System.Drawing.Size(57, 20);
            this.upDownEdgeRightCentral.TabIndex = 8;
            this.upDownEdgeRightCentral.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // upDownEdgeRight
            // 
            this.upDownEdgeRight.Location = new System.Drawing.Point(58, 76);
            this.upDownEdgeRight.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.upDownEdgeRight.Name = "upDownEdgeRight";
            this.upDownEdgeRight.Size = new System.Drawing.Size(57, 20);
            this.upDownEdgeRight.TabIndex = 7;
            this.upDownEdgeRight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // upDownEdgeLeft2Central
            // 
            this.upDownEdgeLeft2Central.Location = new System.Drawing.Point(155, 50);
            this.upDownEdgeLeft2Central.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.upDownEdgeLeft2Central.Name = "upDownEdgeLeft2Central";
            this.upDownEdgeLeft2Central.Size = new System.Drawing.Size(57, 20);
            this.upDownEdgeLeft2Central.TabIndex = 6;
            this.upDownEdgeLeft2Central.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // upDownEdgeLeft2
            // 
            this.upDownEdgeLeft2.Location = new System.Drawing.Point(58, 50);
            this.upDownEdgeLeft2.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.upDownEdgeLeft2.Name = "upDownEdgeLeft2";
            this.upDownEdgeLeft2.Size = new System.Drawing.Size(57, 20);
            this.upDownEdgeLeft2.TabIndex = 5;
            this.upDownEdgeLeft2.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // upDownEdgeLeft1Central
            // 
            this.upDownEdgeLeft1Central.Location = new System.Drawing.Point(155, 21);
            this.upDownEdgeLeft1Central.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.upDownEdgeLeft1Central.Name = "upDownEdgeLeft1Central";
            this.upDownEdgeLeft1Central.Size = new System.Drawing.Size(57, 20);
            this.upDownEdgeLeft1Central.TabIndex = 4;
            this.upDownEdgeLeft1Central.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // upDownEdgeLeft1
            // 
            this.upDownEdgeLeft1.Location = new System.Drawing.Point(58, 21);
            this.upDownEdgeLeft1.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.upDownEdgeLeft1.Name = "upDownEdgeLeft1";
            this.upDownEdgeLeft1.Size = new System.Drawing.Size(57, 20);
            this.upDownEdgeLeft1.TabIndex = 3;
            this.upDownEdgeLeft1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Right";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Left2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Left1";
            // 
            // groupBoxLog2
            // 
            this.groupBoxLog2.Controls.Add(this.signatureBox);
            this.groupBoxLog2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLog2.Location = new System.Drawing.Point(695, 173);
            this.groupBoxLog2.Name = "groupBoxLog2";
            this.tableLayoutPanel1.SetRowSpan(this.groupBoxLog2, 3);
            this.groupBoxLog2.Size = new System.Drawing.Size(199, 512);
            this.groupBoxLog2.TabIndex = 20;
            this.groupBoxLog2.TabStop = false;
            this.groupBoxLog2.Text = "Signatura";
            // 
            // signatureBox
            // 
            this.signatureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signatureBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signatureBox.FormattingEnabled = true;
            this.signatureBox.ItemHeight = 19;
            this.signatureBox.Location = new System.Drawing.Point(3, 16);
            this.signatureBox.Name = "signatureBox";
            this.signatureBox.Size = new System.Drawing.Size(193, 493);
            this.signatureBox.TabIndex = 0;
            // 
            // groupBoxLog1
            // 
            this.groupBoxLog1.Controls.Add(this.resultBox);
            this.groupBoxLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLog1.Location = new System.Drawing.Point(695, 3);
            this.groupBoxLog1.Name = "groupBoxLog1";
            this.groupBoxLog1.Size = new System.Drawing.Size(199, 164);
            this.groupBoxLog1.TabIndex = 21;
            this.groupBoxLog1.TabStop = false;
            this.groupBoxLog1.Text = "Verification Result";
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.Window;
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultBox.FormattingEnabled = true;
            this.resultBox.ItemHeight = 19;
            this.resultBox.Location = new System.Drawing.Point(3, 16);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(193, 145);
            this.resultBox.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 4);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.91988F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.93175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.03715F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.03715F));
            this.tableLayoutPanel3.Controls.Add(this.imagePath, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBoxStat, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox7, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.groupBox8, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.groupProcessingButton, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.teachFileLoadButton, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.processingButton, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.productionCheckBox, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(686, 164);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // imagePath
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.imagePath, 3);
            this.imagePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePath.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.imagePath.Location = new System.Drawing.Point(3, 3);
            this.imagePath.Multiline = true;
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(506, 30);
            this.imagePath.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.loadButton);
            this.panel1.Controls.Add(this.buttonNextImage);
            this.panel1.Controls.Add(this.buttonPrevImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 30);
            this.panel1.TabIndex = 1;
            // 
            // loadButton
            // 
            this.loadButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.loadButton.Location = new System.Drawing.Point(260, 0);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 30);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonNextImage
            // 
            this.buttonNextImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonNextImage.Location = new System.Drawing.Point(75, 0);
            this.buttonNextImage.Name = "buttonNextImage";
            this.buttonNextImage.Size = new System.Drawing.Size(75, 30);
            this.buttonNextImage.TabIndex = 1;
            this.buttonNextImage.Text = "next";
            this.buttonNextImage.UseVisualStyleBackColor = true;
            this.buttonNextImage.Click += new System.EventHandler(this.buttonNextImage_Click);
            // 
            // buttonPrevImage
            // 
            this.buttonPrevImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPrevImage.Location = new System.Drawing.Point(0, 0);
            this.buttonPrevImage.Name = "buttonPrevImage";
            this.buttonPrevImage.Size = new System.Drawing.Size(75, 30);
            this.buttonPrevImage.TabIndex = 0;
            this.buttonPrevImage.Text = "prev";
            this.buttonPrevImage.UseVisualStyleBackColor = true;
            this.buttonPrevImage.Click += new System.EventHandler(this.buttonPrevImage_Click);
            // 
            // groupBoxStat
            // 
            this.groupBoxStat.Controls.Add(this.commonStatBox);
            this.groupBoxStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStat.Location = new System.Drawing.Point(515, 3);
            this.groupBoxStat.Name = "groupBoxStat";
            this.tableLayoutPanel3.SetRowSpan(this.groupBoxStat, 5);
            this.groupBoxStat.Size = new System.Drawing.Size(168, 158);
            this.groupBoxStat.TabIndex = 2;
            this.groupBoxStat.TabStop = false;
            this.groupBoxStat.Text = "CommonStat";
            // 
            // commonStatBox
            // 
            this.commonStatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonStatBox.FormattingEnabled = true;
            this.commonStatBox.Location = new System.Drawing.Point(3, 16);
            this.commonStatBox.Name = "commonStatBox";
            this.commonStatBox.Size = new System.Drawing.Size(162, 139);
            this.commonStatBox.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.savingStepsCheckBox);
            this.groupBox7.Controls.Add(this.saveClassificationCheckBox);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 111);
            this.groupBox7.Name = "groupBox7";
            this.tableLayoutPanel3.SetRowSpan(this.groupBox7, 2);
            this.groupBox7.Size = new System.Drawing.Size(137, 50);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            // 
            // savingStepsCheckBox
            // 
            this.savingStepsCheckBox.AutoSize = true;
            this.savingStepsCheckBox.Location = new System.Drawing.Point(6, 5);
            this.savingStepsCheckBox.Name = "savingStepsCheckBox";
            this.savingStepsCheckBox.Size = new System.Drawing.Size(89, 17);
            this.savingStepsCheckBox.TabIndex = 4;
            this.savingStepsCheckBox.Text = "Saving Steps";
            this.savingStepsCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveClassificationCheckBox
            // 
            this.saveClassificationCheckBox.AutoSize = true;
            this.saveClassificationCheckBox.Location = new System.Drawing.Point(6, 27);
            this.saveClassificationCheckBox.Name = "saveClassificationCheckBox";
            this.saveClassificationCheckBox.Size = new System.Drawing.Size(123, 17);
            this.saveClassificationCheckBox.TabIndex = 3;
            this.saveClassificationCheckBox.Text = "Saving Classification";
            this.saveClassificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.timeDelayCheckBox);
            this.groupBox8.Controls.Add(this.upDownTimeDelay);
            this.groupBox8.Controls.Add(this.upDownFilesNumber);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(146, 111);
            this.groupBox8.Name = "groupBox8";
            this.tableLayoutPanel3.SetRowSpan(this.groupBox8, 2);
            this.groupBox8.Size = new System.Drawing.Size(192, 50);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            // 
            // timeDelayCheckBox
            // 
            this.timeDelayCheckBox.AutoSize = true;
            this.timeDelayCheckBox.Location = new System.Drawing.Point(6, 25);
            this.timeDelayCheckBox.Name = "timeDelayCheckBox";
            this.timeDelayCheckBox.Size = new System.Drawing.Size(79, 17);
            this.timeDelayCheckBox.TabIndex = 9;
            this.timeDelayCheckBox.Text = "Time Delay";
            this.timeDelayCheckBox.UseVisualStyleBackColor = true;
            // 
            // upDownTimeDelay
            // 
            this.upDownTimeDelay.Location = new System.Drawing.Point(113, 25);
            this.upDownTimeDelay.Name = "upDownTimeDelay";
            this.upDownTimeDelay.Size = new System.Drawing.Size(70, 20);
            this.upDownTimeDelay.TabIndex = 8;
            this.upDownTimeDelay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // upDownFilesNumber
            // 
            this.upDownFilesNumber.Location = new System.Drawing.Point(113, 0);
            this.upDownFilesNumber.Name = "upDownFilesNumber";
            this.upDownFilesNumber.Size = new System.Drawing.Size(70, 20);
            this.upDownFilesNumber.TabIndex = 7;
            this.upDownFilesNumber.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Number of images";
            // 
            // groupProcessingButton
            // 
            this.groupProcessingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupProcessingButton.Location = new System.Drawing.Point(344, 111);
            this.groupProcessingButton.Name = "groupProcessingButton";
            this.groupProcessingButton.Size = new System.Drawing.Size(165, 30);
            this.groupProcessingButton.TabIndex = 7;
            this.groupProcessingButton.Text = "Group Processing";
            this.groupProcessingButton.UseVisualStyleBackColor = true;
            this.groupProcessingButton.Click += new System.EventHandler(this.groupProcessingButton_Click);
            // 
            // teachFileLoadButton
            // 
            this.teachFileLoadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teachFileLoadButton.Location = new System.Drawing.Point(3, 75);
            this.teachFileLoadButton.Name = "teachFileLoadButton";
            this.teachFileLoadButton.Size = new System.Drawing.Size(137, 30);
            this.teachFileLoadButton.TabIndex = 8;
            this.teachFileLoadButton.Text = "Load TeachFile";
            this.teachFileLoadButton.UseVisualStyleBackColor = true;
            // 
            // processingButton
            // 
            this.processingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processingButton.Location = new System.Drawing.Point(344, 39);
            this.processingButton.Name = "processingButton";
            this.processingButton.Size = new System.Drawing.Size(165, 30);
            this.processingButton.TabIndex = 9;
            this.processingButton.Text = "Processing";
            this.processingButton.UseVisualStyleBackColor = true;
            this.processingButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // productionCheckBox
            // 
            this.productionCheckBox.AutoSize = true;
            this.productionCheckBox.Location = new System.Drawing.Point(146, 75);
            this.productionCheckBox.Name = "productionCheckBox";
            this.productionCheckBox.Size = new System.Drawing.Size(123, 17);
            this.productionCheckBox.TabIndex = 10;
            this.productionCheckBox.Text = "productionExecution";
            this.productionCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.sourceModMPicture, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.outModMPicture, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(176, 519);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(167, 166);
            this.tableLayoutPanel4.TabIndex = 23;
            // 
            // sourceModMPicture
            // 
            this.sourceModMPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceModMPicture.Location = new System.Drawing.Point(3, 3);
            this.sourceModMPicture.Name = "sourceModMPicture";
            this.sourceModMPicture.Size = new System.Drawing.Size(77, 160);
            this.sourceModMPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourceModMPicture.TabIndex = 0;
            this.sourceModMPicture.TabStop = false;
            this.sourceModMPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // outModMPicture
            // 
            this.outModMPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outModMPicture.Location = new System.Drawing.Point(86, 3);
            this.outModMPicture.Name = "outModMPicture";
            this.outModMPicture.Size = new System.Drawing.Size(78, 160);
            this.outModMPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outModMPicture.TabIndex = 1;
            this.outModMPicture.TabStop = false;
            this.outModMPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.sourceModAPicture, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.outModAPicture, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(349, 519);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(167, 166);
            this.tableLayoutPanel5.TabIndex = 24;
            // 
            // sourceModAPicture
            // 
            this.sourceModAPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceModAPicture.Location = new System.Drawing.Point(3, 3);
            this.sourceModAPicture.Name = "sourceModAPicture";
            this.sourceModAPicture.Size = new System.Drawing.Size(77, 160);
            this.sourceModAPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourceModAPicture.TabIndex = 0;
            this.sourceModAPicture.TabStop = false;
            this.sourceModAPicture.DoubleClick += new System.EventHandler(this.pictureBox_Saving);
            // 
            // outModAPicture
            // 
            this.outModAPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outModAPicture.Location = new System.Drawing.Point(86, 3);
            this.outModAPicture.Name = "outModAPicture";
            this.outModAPicture.Size = new System.Drawing.Size(78, 160);
            this.outModAPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outModAPicture.TabIndex = 1;
            this.outModAPicture.TabStop = false;
            this.outModAPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // cropPicture
            // 
            this.cropPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cropPicture.Location = new System.Drawing.Point(349, 346);
            this.cropPicture.Name = "cropPicture";
            this.cropPicture.Size = new System.Drawing.Size(167, 167);
            this.cropPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cropPicture.TabIndex = 26;
            this.cropPicture.TabStop = false;
            this.cropPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // productionPicture
            // 
            this.productionPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productionPicture.Location = new System.Drawing.Point(522, 519);
            this.productionPicture.Name = "productionPicture";
            this.productionPicture.Size = new System.Drawing.Size(167, 166);
            this.productionPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productionPicture.TabIndex = 27;
            this.productionPicture.TabStop = false;
            this.productionPicture.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.leftToolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Fibroscan Verification";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.leftToolStrip.ResumeLayout(false);
            this.leftToolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBinarGlobalRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBinarLocalRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBinarizationK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBinarThreshold)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRansacIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRansacOutliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRansacSample)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCropDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCropStep)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLimitUsBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRelativeEstimationLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBrightLinesLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownUsDeviationStreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBrightPixelLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kuwaharaPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elastoPicture)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binarizationPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.morphologyPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.choosingPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.approximationPicture)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeRightCentral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeLeft2Central)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeLeft2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeLeft1Central)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEdgeLeft1)).EndInit();
            this.groupBoxLog2.ResumeLayout(false);
            this.groupBoxLog1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxStat.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownTimeDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownFilesNumber)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourceModMPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outModMPicture)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourceModAPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outModAPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cropPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip leftToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown upDownCropDistance;
        private System.Windows.Forms.NumericUpDown upDownCropStep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox kuwaharaPicture;
        private System.Windows.Forms.PictureBox sourcePicture;
        private System.Windows.Forms.PictureBox elastoPicture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox binarizationPicture;
        private System.Windows.Forms.PictureBox edgePicture;
        private System.Windows.Forms.PictureBox morphologyPicture;
        private System.Windows.Forms.PictureBox choosingPicture;
        private System.Windows.Forms.PictureBox approximationPicture;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown upDownBinarizationK;
        private System.Windows.Forms.NumericUpDown upDownBinarThreshold;
        private System.Windows.Forms.RadioButton niblackRadioButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown upDownBinarLocalRadius;
        private System.Windows.Forms.RadioButton morphNiblackRadioButton;
        private System.Windows.Forms.RadioButton simpleBinRadioButton;
        private System.Windows.Forms.RadioButton wolfRadioButton;
        private System.Windows.Forms.RadioButton sauvolaRadioButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown upDownBinarGlobalRadius;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBoxLog2;
        private System.Windows.Forms.ListBox signatureBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown upDownEdgeRightCentral;
        private System.Windows.Forms.NumericUpDown upDownEdgeRight;
        private System.Windows.Forms.NumericUpDown upDownEdgeLeft2Central;
        private System.Windows.Forms.NumericUpDown upDownEdgeLeft2;
        private System.Windows.Forms.NumericUpDown upDownEdgeLeft1Central;
        private System.Windows.Forms.NumericUpDown upDownEdgeLeft1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton morphOtsuRadioButton;
        private System.Windows.Forms.GroupBox groupBoxLog1;
        private System.Windows.Forms.ListBox resultBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.NumericUpDown upDownRansacSample;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown upDownRansacIterations;
        private System.Windows.Forms.NumericUpDown upDownRansacOutliers;
        private System.Windows.Forms.NumericUpDown upDownUsDeviationStreak;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown upDownBrightPixelLimit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown upDownBrightLinesLimit;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown upDownRelativeEstimationLimit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox sourceModMPicture;
        private System.Windows.Forms.PictureBox outModMPicture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox sourceModAPicture;
        private System.Windows.Forms.PictureBox outModAPicture;
        private System.Windows.Forms.GroupBox groupBoxStat;
        private System.Windows.Forms.ListBox commonStatBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox savingStepsCheckBox;
        private System.Windows.Forms.CheckBox saveClassificationCheckBox;
        private System.Windows.Forms.Button buttonNextImage;
        private System.Windows.Forms.Button buttonPrevImage;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown upDownFilesNumber;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox timeDelayCheckBox;
        private System.Windows.Forms.NumericUpDown upDownTimeDelay;
        private System.Windows.Forms.Button groupProcessingButton;
        private System.Windows.Forms.Button teachFileLoadButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button processingButton;
        private System.Windows.Forms.PictureBox cropPicture;
        private System.Windows.Forms.PictureBox productionPicture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.NumericUpDown upDownLimitUsBrightness;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox productionCheckBox;
    }
}

