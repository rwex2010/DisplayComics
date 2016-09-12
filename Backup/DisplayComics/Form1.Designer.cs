namespace DisplayComics
{
    partial class formControlPanel
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
           this.tbxComicPath = new System.Windows.Forms.TextBox();
           this.fbDiaDisplay = new System.Windows.Forms.FolderBrowserDialog();
           this.btnClose = new System.Windows.Forms.Button();
           this.btnSelectSeries = new System.Windows.Forms.Button();
           this.pnlDisplayComics = new System.Windows.Forms.Panel();
           this.pnlMoveRename = new System.Windows.Forms.Panel();
           this.panel3 = new System.Windows.Forms.Panel();
           this.pnlArchiveDate = new System.Windows.Forms.Panel();
           this.lblArchiveCnt = new System.Windows.Forms.Label();
           this.lblKeepCnt = new System.Windows.Forms.Label();
           this.btnSelectArchive = new System.Windows.Forms.Button();
           this.cmbxFilesToArchive = new System.Windows.Forms.ComboBox();
           this.cmbxFilesWeKeep = new System.Windows.Forms.ComboBox();
           this.lblFilesToArchive = new System.Windows.Forms.Label();
           this.lblFilesWeKeep = new System.Windows.Forms.Label();
           this.radMoveAll = new System.Windows.Forms.RadioButton();
           this.radLimitMove = new System.Windows.Forms.RadioButton();
           this.chbxOverWrite = new System.Windows.Forms.CheckBox();
           this.label2 = new System.Windows.Forms.Label();
           this.lbxArchiveComics = new System.Windows.Forms.ListBox();
           this.dtpArchiveDate = new System.Windows.Forms.DateTimePicker();
           this.radArchive = new System.Windows.Forms.RadioButton();
           this.radNewComic = new System.Windows.Forms.RadioButton();
           this.panel2 = new System.Windows.Forms.Panel();
           this.chkbxScrollThrough = new System.Windows.Forms.CheckBox();
           this.btnMoveGo = new System.Windows.Forms.Button();
           this.tbxPathMoveTo = new System.Windows.Forms.TextBox();
           this.lblTo = new System.Windows.Forms.Label();
           this.lblFrom = new System.Windows.Forms.Label();
           this.tbxPathMoveFrom = new System.Windows.Forms.TextBox();
           this.fbDiaMoveFrom = new System.Windows.Forms.FolderBrowserDialog();
           this.fbDiaMoveTo = new System.Windows.Forms.FolderBrowserDialog();
           this.lblFileCount = new System.Windows.Forms.Label();
           this.lblCompleteCnt = new System.Windows.Forms.Label();
           this.tabControl1 = new System.Windows.Forms.TabControl();
           this.tabSelectSeries = new System.Windows.Forms.TabPage();
           this.tabMoveRename = new System.Windows.Forms.TabPage();
           this.listBox1 = new System.Windows.Forms.ListBox();
           this.textBox2 = new System.Windows.Forms.TextBox();
           this.textBox1 = new System.Windows.Forms.TextBox();
           this.lblDirectoryCnt = new System.Windows.Forms.Label();
           this.panel1 = new System.Windows.Forms.Panel();
           this.statusStrip1 = new System.Windows.Forms.StatusStrip();
           this.tsprogFileCount = new System.Windows.Forms.ToolStripProgressBar();
           this.statusStrip2 = new System.Windows.Forms.StatusStrip();
           this.tsprogFolderCount = new System.Windows.Forms.ToolStripProgressBar();
           this.pnlDisplayComics.SuspendLayout();
           this.pnlMoveRename.SuspendLayout();
           this.panel3.SuspendLayout();
           this.pnlArchiveDate.SuspendLayout();
           this.panel2.SuspendLayout();
           this.tabControl1.SuspendLayout();
           this.tabSelectSeries.SuspendLayout();
           this.tabMoveRename.SuspendLayout();
           this.panel1.SuspendLayout();
           this.statusStrip1.SuspendLayout();
           this.statusStrip2.SuspendLayout();
           this.SuspendLayout();
           // 
           // tbxComicPath
           // 
           this.tbxComicPath.Location = new System.Drawing.Point(3, 13);
           this.tbxComicPath.Name = "tbxComicPath";
           this.tbxComicPath.Size = new System.Drawing.Size(288, 20);
           this.tbxComicPath.TabIndex = 5;
           this.tbxComicPath.Text = "tbxComicPath";
           this.tbxComicPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbxComicPath_MouseClick);
           // 
           // btnClose
           // 
           this.btnClose.Location = new System.Drawing.Point(3, 15);
           this.btnClose.Name = "btnClose";
           this.btnClose.Size = new System.Drawing.Size(76, 45);
           this.btnClose.TabIndex = 2;
           this.btnClose.Text = "Close";
           this.btnClose.UseVisualStyleBackColor = true;
           this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
           // 
           // btnSelectSeries
           // 
           this.btnSelectSeries.Location = new System.Drawing.Point(3, 39);
           this.btnSelectSeries.Name = "btnSelectSeries";
           this.btnSelectSeries.Size = new System.Drawing.Size(88, 23);
           this.btnSelectSeries.TabIndex = 0;
           this.btnSelectSeries.Text = "Select Series";
           this.btnSelectSeries.UseVisualStyleBackColor = true;
           this.btnSelectSeries.Click += new System.EventHandler(this.btnSelectSeries_Click);
           // 
           // pnlDisplayComics
           // 
           this.pnlDisplayComics.BackColor = System.Drawing.Color.Transparent;
           this.pnlDisplayComics.Controls.Add(this.pnlMoveRename);
           this.pnlDisplayComics.Controls.Add(this.tbxComicPath);
           this.pnlDisplayComics.Controls.Add(this.btnSelectSeries);
           this.pnlDisplayComics.Dock = System.Windows.Forms.DockStyle.Fill;
           this.pnlDisplayComics.Location = new System.Drawing.Point(3, 3);
           this.pnlDisplayComics.Name = "pnlDisplayComics";
           this.pnlDisplayComics.Size = new System.Drawing.Size(478, 388);
           this.pnlDisplayComics.TabIndex = 9;
           this.pnlDisplayComics.MouseEnter += new System.EventHandler(this.formControlPanel_MouseEnter);
           // 
           // pnlMoveRename
           // 
           this.pnlMoveRename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           this.pnlMoveRename.Controls.Add(this.panel3);
           this.pnlMoveRename.Controls.Add(this.panel2);
           this.pnlMoveRename.Dock = System.Windows.Forms.DockStyle.Bottom;
           this.pnlMoveRename.Location = new System.Drawing.Point(0, 68);
           this.pnlMoveRename.Name = "pnlMoveRename";
           this.pnlMoveRename.Size = new System.Drawing.Size(478, 320);
           this.pnlMoveRename.TabIndex = 11;
           // 
           // panel3
           // 
           this.panel3.Controls.Add(this.pnlArchiveDate);
           this.panel3.Controls.Add(this.radArchive);
           this.panel3.Controls.Add(this.radNewComic);
           this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
           this.panel3.Location = new System.Drawing.Point(0, 0);
           this.panel3.Name = "panel3";
           this.panel3.Size = new System.Drawing.Size(476, 169);
           this.panel3.TabIndex = 16;
           // 
           // pnlArchiveDate
           // 
           this.pnlArchiveDate.Controls.Add(this.lblArchiveCnt);
           this.pnlArchiveDate.Controls.Add(this.lblKeepCnt);
           this.pnlArchiveDate.Controls.Add(this.btnSelectArchive);
           this.pnlArchiveDate.Controls.Add(this.cmbxFilesToArchive);
           this.pnlArchiveDate.Controls.Add(this.cmbxFilesWeKeep);
           this.pnlArchiveDate.Controls.Add(this.lblFilesToArchive);
           this.pnlArchiveDate.Controls.Add(this.lblFilesWeKeep);
           this.pnlArchiveDate.Controls.Add(this.radMoveAll);
           this.pnlArchiveDate.Controls.Add(this.radLimitMove);
           this.pnlArchiveDate.Controls.Add(this.chbxOverWrite);
           this.pnlArchiveDate.Controls.Add(this.label2);
           this.pnlArchiveDate.Controls.Add(this.lbxArchiveComics);
           this.pnlArchiveDate.Controls.Add(this.dtpArchiveDate);
           this.pnlArchiveDate.Dock = System.Windows.Forms.DockStyle.Right;
           this.pnlArchiveDate.Location = new System.Drawing.Point(101, 0);
           this.pnlArchiveDate.Name = "pnlArchiveDate";
           this.pnlArchiveDate.Size = new System.Drawing.Size(375, 169);
           this.pnlArchiveDate.TabIndex = 14;
           this.pnlArchiveDate.Visible = false;
           // 
           // lblArchiveCnt
           // 
           this.lblArchiveCnt.AutoSize = true;
           this.lblArchiveCnt.Location = new System.Drawing.Point(280, 121);
           this.lblArchiveCnt.Name = "lblArchiveCnt";
           this.lblArchiveCnt.Size = new System.Drawing.Size(30, 13);
           this.lblArchiveCnt.TabIndex = 26;
           this.lblArchiveCnt.Text = "{cnt}";
           // 
           // lblKeepCnt
           // 
           this.lblKeepCnt.AutoSize = true;
           this.lblKeepCnt.Location = new System.Drawing.Point(84, 125);
           this.lblKeepCnt.Name = "lblKeepCnt";
           this.lblKeepCnt.Size = new System.Drawing.Size(30, 13);
           this.lblKeepCnt.TabIndex = 25;
           this.lblKeepCnt.Text = "{cnt}";
           // 
           // btnSelectArchive
           // 
           this.btnSelectArchive.Location = new System.Drawing.Point(66, 94);
           this.btnSelectArchive.Name = "btnSelectArchive";
           this.btnSelectArchive.Size = new System.Drawing.Size(114, 23);
           this.btnSelectArchive.TabIndex = 24;
           this.btnSelectArchive.Text = "Select files";
           this.btnSelectArchive.UseVisualStyleBackColor = true;
           this.btnSelectArchive.Click += new System.EventHandler(this.btnSelectArchive_Click);
           // 
           // cmbxFilesToArchive
           // 
           this.cmbxFilesToArchive.FormattingEnabled = true;
           this.cmbxFilesToArchive.Location = new System.Drawing.Point(191, 137);
           this.cmbxFilesToArchive.Name = "cmbxFilesToArchive";
           this.cmbxFilesToArchive.Size = new System.Drawing.Size(180, 23);
           this.cmbxFilesToArchive.TabIndex = 23;
           this.cmbxFilesToArchive.Text = "cmbxFilesToArchive";
           // 
           // cmbxFilesWeKeep
           // 
           this.cmbxFilesWeKeep.FormattingEnabled = true;
           this.cmbxFilesWeKeep.Location = new System.Drawing.Point(7, 138);
           this.cmbxFilesWeKeep.Name = "cmbxFilesWeKeep";
           this.cmbxFilesWeKeep.Size = new System.Drawing.Size(173, 23);
           this.cmbxFilesWeKeep.TabIndex = 22;
           this.cmbxFilesWeKeep.Text = "cmbxFilesWeKeep";
           // 
           // lblFilesToArchive
           // 
           this.lblFilesToArchive.AutoSize = true;
           this.lblFilesToArchive.Location = new System.Drawing.Point(188, 121);
           this.lblFilesToArchive.Name = "lblFilesToArchive";
           this.lblFilesToArchive.Size = new System.Drawing.Size(86, 13);
           this.lblFilesToArchive.TabIndex = 21;
           this.lblFilesToArchive.Text = "Files To Archive:";
           // 
           // lblFilesWeKeep
           // 
           this.lblFilesWeKeep.AutoSize = true;
           this.lblFilesWeKeep.Location = new System.Drawing.Point(4, 125);
           this.lblFilesWeKeep.Name = "lblFilesWeKeep";
           this.lblFilesWeKeep.Size = new System.Drawing.Size(78, 13);
           this.lblFilesWeKeep.TabIndex = 20;
           this.lblFilesWeKeep.Text = "Files we keep: ";
           // 
           // radMoveAll
           // 
           this.radMoveAll.AutoSize = true;
           this.radMoveAll.Location = new System.Drawing.Point(148, 46);
           this.radMoveAll.Name = "radMoveAll";
           this.radMoveAll.Size = new System.Drawing.Size(170, 17);
           this.radMoveAll.TabIndex = 17;
           this.radMoveAll.TabStop = true;
           this.radMoveAll.Text = "Move ALL start with this Comic\r\n";
           this.radMoveAll.UseVisualStyleBackColor = true;
           this.radMoveAll.CheckedChanged += new System.EventHandler(this.radMoveAll_CheckedChanged);
           // 
           // radLimitMove
           // 
           this.radLimitMove.AutoSize = true;
           this.radLimitMove.Checked = true;
           this.radLimitMove.Location = new System.Drawing.Point(7, 46);
           this.radLimitMove.Name = "radLimitMove";
           this.radLimitMove.Size = new System.Drawing.Size(135, 17);
           this.radLimitMove.TabIndex = 16;
           this.radLimitMove.TabStop = true;
           this.radLimitMove.Text = "Limit to Comic Selected";
           this.radLimitMove.UseVisualStyleBackColor = true;
           // 
           // chbxOverWrite
           // 
           this.chbxOverWrite.AutoSize = true;
           this.chbxOverWrite.Location = new System.Drawing.Point(248, 23);
           this.chbxOverWrite.Name = "chbxOverWrite";
           this.chbxOverWrite.Size = new System.Drawing.Size(109, 17);
           this.chbxOverWrite.TabIndex = 13;
           this.chbxOverWrite.Text = "Overwrite existing";
           this.chbxOverWrite.UseVisualStyleBackColor = true;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(29, 4);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(109, 13);
           this.label2.TabIndex = 15;
           this.label2.Text = "Archive all older than:";
           // 
           // lbxArchiveComics
           // 
           this.lbxArchiveComics.FormattingEnabled = true;
           this.lbxArchiveComics.ItemHeight = 15;
           this.lbxArchiveComics.Location = new System.Drawing.Point(7, 69);
           this.lbxArchiveComics.Name = "lbxArchiveComics";
           this.lbxArchiveComics.Size = new System.Drawing.Size(311, 19);
           this.lbxArchiveComics.Sorted = true;
           this.lbxArchiveComics.TabIndex = 15;
           // 
           // dtpArchiveDate
           // 
           this.dtpArchiveDate.CustomFormat = "ddd, M/d/yyyy";
           this.dtpArchiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
           this.dtpArchiveDate.Location = new System.Drawing.Point(7, 20);
           this.dtpArchiveDate.Name = "dtpArchiveDate";
           this.dtpArchiveDate.Size = new System.Drawing.Size(232, 20);
           this.dtpArchiveDate.TabIndex = 14;
           // 
           // radArchive
           // 
           this.radArchive.AutoSize = true;
           this.radArchive.Location = new System.Drawing.Point(6, 7);
           this.radArchive.Name = "radArchive";
           this.radArchive.Size = new System.Drawing.Size(98, 17);
           this.radArchive.TabIndex = 9;
           this.radArchive.Text = "Archive Comics";
           this.radArchive.UseVisualStyleBackColor = true;
           this.radArchive.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
           // 
           // radNewComic
           // 
           this.radNewComic.AutoSize = true;
           this.radNewComic.Checked = true;
           this.radNewComic.Location = new System.Drawing.Point(6, 30);
           this.radNewComic.Name = "radNewComic";
           this.radNewComic.Size = new System.Drawing.Size(79, 17);
           this.radNewComic.TabIndex = 8;
           this.radNewComic.TabStop = true;
           this.radNewComic.Text = "New Comic";
           this.radNewComic.UseVisualStyleBackColor = true;
           this.radNewComic.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
           // 
           // panel2
           // 
           this.panel2.Controls.Add(this.chkbxScrollThrough);
           this.panel2.Controls.Add(this.btnMoveGo);
           this.panel2.Controls.Add(this.tbxPathMoveTo);
           this.panel2.Controls.Add(this.lblTo);
           this.panel2.Controls.Add(this.lblFrom);
           this.panel2.Controls.Add(this.tbxPathMoveFrom);
           this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
           this.panel2.Location = new System.Drawing.Point(0, 172);
           this.panel2.Name = "panel2";
           this.panel2.Size = new System.Drawing.Size(476, 146);
           this.panel2.TabIndex = 15;
           // 
           // chkbxScrollThrough
           // 
           this.chkbxScrollThrough.AutoSize = true;
           this.chkbxScrollThrough.Location = new System.Drawing.Point(101, 113);
           this.chkbxScrollThrough.Name = "chkbxScrollThrough";
           this.chkbxScrollThrough.Size = new System.Drawing.Size(173, 17);
           this.chkbxScrollThrough.TabIndex = 8;
           this.chkbxScrollThrough.Text = "Scroll through without Stopping";
           this.chkbxScrollThrough.UseVisualStyleBackColor = true;
           // 
           // btnMoveGo
           // 
           this.btnMoveGo.Location = new System.Drawing.Point(6, 107);
           this.btnMoveGo.Name = "btnMoveGo";
           this.btnMoveGo.Size = new System.Drawing.Size(75, 23);
           this.btnMoveGo.TabIndex = 1;
           this.btnMoveGo.Text = "Move \'em";
           this.btnMoveGo.UseVisualStyleBackColor = true;
           this.btnMoveGo.Click += new System.EventHandler(this.btnMoveGo_Click);
           // 
           // tbxPathMoveTo
           // 
           this.tbxPathMoveTo.Location = new System.Drawing.Point(6, 81);
           this.tbxPathMoveTo.Name = "tbxPathMoveTo";
           this.tbxPathMoveTo.Size = new System.Drawing.Size(461, 20);
           this.tbxPathMoveTo.TabIndex = 7;
           this.tbxPathMoveTo.Text = "tbxPathMoveTo";
           this.tbxPathMoveTo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbxPathMoveTo_MouseClick);
           // 
           // lblTo
           // 
           this.lblTo.AutoSize = true;
           this.lblTo.Location = new System.Drawing.Point(3, 65);
           this.lblTo.Name = "lblTo";
           this.lblTo.Size = new System.Drawing.Size(53, 13);
           this.lblTo.TabIndex = 6;
           this.lblTo.Text = "Move To:";
           // 
           // lblFrom
           // 
           this.lblFrom.AutoSize = true;
           this.lblFrom.Location = new System.Drawing.Point(3, 13);
           this.lblFrom.Name = "lblFrom";
           this.lblFrom.Size = new System.Drawing.Size(63, 13);
           this.lblFrom.TabIndex = 3;
           this.lblFrom.Text = "Move From:";
           // 
           // tbxPathMoveFrom
           // 
           this.tbxPathMoveFrom.Location = new System.Drawing.Point(6, 29);
           this.tbxPathMoveFrom.Name = "tbxPathMoveFrom";
           this.tbxPathMoveFrom.Size = new System.Drawing.Size(461, 20);
           this.tbxPathMoveFrom.TabIndex = 0;
           this.tbxPathMoveFrom.Text = "tbxPathMoveFrom";
           this.tbxPathMoveFrom.TextChanged += new System.EventHandler(this.tbxPathMoveFrom_TextChanged);
           this.tbxPathMoveFrom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbxPathMoveFrom_MouseClick);
           // 
           // lblFileCount
           // 
           this.lblFileCount.AutoSize = true;
           this.lblFileCount.Location = new System.Drawing.Point(147, 35);
           this.lblFileCount.Name = "lblFileCount";
           this.lblFileCount.Size = new System.Drawing.Size(67, 13);
           this.lblFileCount.TabIndex = 12;
           this.lblFileCount.Text = "Total Files: 0";
           this.lblFileCount.Visible = false;
           // 
           // lblCompleteCnt
           // 
           this.lblCompleteCnt.AutoSize = true;
           this.lblCompleteCnt.Location = new System.Drawing.Point(273, 35);
           this.lblCompleteCnt.Name = "lblCompleteCnt";
           this.lblCompleteCnt.Size = new System.Drawing.Size(13, 13);
           this.lblCompleteCnt.TabIndex = 13;
           this.lblCompleteCnt.Text = "0";
           this.lblCompleteCnt.Visible = false;
           // 
           // tabControl1
           // 
           this.tabControl1.Controls.Add(this.tabSelectSeries);
           this.tabControl1.Controls.Add(this.tabMoveRename);
           this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
           this.tabControl1.Location = new System.Drawing.Point(0, 0);
           this.tabControl1.Multiline = true;
           this.tabControl1.Name = "tabControl1";
           this.tabControl1.SelectedIndex = 0;
           this.tabControl1.Size = new System.Drawing.Size(492, 420);
           this.tabControl1.TabIndex = 16;
           this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
           // 
           // tabSelectSeries
           // 
           this.tabSelectSeries.BackColor = System.Drawing.Color.White;
           this.tabSelectSeries.Controls.Add(this.pnlDisplayComics);
           this.tabSelectSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
           this.tabSelectSeries.Location = new System.Drawing.Point(4, 22);
           this.tabSelectSeries.Name = "tabSelectSeries";
           this.tabSelectSeries.Padding = new System.Windows.Forms.Padding(3);
           this.tabSelectSeries.Size = new System.Drawing.Size(484, 394);
           this.tabSelectSeries.TabIndex = 0;
           this.tabSelectSeries.Text = "Select Series";
           // 
           // tabMoveRename
           // 
           this.tabMoveRename.Controls.Add(this.listBox1);
           this.tabMoveRename.Controls.Add(this.textBox2);
           this.tabMoveRename.Controls.Add(this.textBox1);
           this.tabMoveRename.Location = new System.Drawing.Point(4, 22);
           this.tabMoveRename.Name = "tabMoveRename";
           this.tabMoveRename.Padding = new System.Windows.Forms.Padding(3);
           this.tabMoveRename.Size = new System.Drawing.Size(484, 394);
           this.tabMoveRename.TabIndex = 1;
           this.tabMoveRename.Text = "Move and Rename";
           this.tabMoveRename.UseVisualStyleBackColor = true;
           // 
           // listBox1
           // 
           this.listBox1.FormattingEnabled = true;
           this.listBox1.Location = new System.Drawing.Point(154, 79);
           this.listBox1.Name = "listBox1";
           this.listBox1.Size = new System.Drawing.Size(133, 17);
           this.listBox1.Sorted = true;
           this.listBox1.TabIndex = 2;
           // 
           // textBox2
           // 
           this.textBox2.Location = new System.Drawing.Point(18, 122);
           this.textBox2.Name = "textBox2";
           this.textBox2.Size = new System.Drawing.Size(269, 20);
           this.textBox2.TabIndex = 1;
           // 
           // textBox1
           // 
           this.textBox1.Location = new System.Drawing.Point(18, 37);
           this.textBox1.Name = "textBox1";
           this.textBox1.Size = new System.Drawing.Size(269, 20);
           this.textBox1.TabIndex = 0;
           // 
           // lblDirectoryCnt
           // 
           this.lblDirectoryCnt.AutoSize = true;
           this.lblDirectoryCnt.Location = new System.Drawing.Point(145, 18);
           this.lblDirectoryCnt.Name = "lblDirectoryCnt";
           this.lblDirectoryCnt.Size = new System.Drawing.Size(69, 13);
           this.lblDirectoryCnt.TabIndex = 17;
           this.lblDirectoryCnt.Text = "Directories: 0";
           this.lblDirectoryCnt.Visible = false;
           // 
           // panel1
           // 
           this.panel1.Controls.Add(this.lblFileCount);
           this.panel1.Controls.Add(this.lblDirectoryCnt);
           this.panel1.Controls.Add(this.btnClose);
           this.panel1.Controls.Add(this.lblCompleteCnt);
           this.panel1.Location = new System.Drawing.Point(0, 419);
           this.panel1.Name = "panel1";
           this.panel1.Size = new System.Drawing.Size(492, 63);
           this.panel1.TabIndex = 18;
           // 
           // statusStrip1
           // 
           this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsprogFileCount});
           this.statusStrip1.Location = new System.Drawing.Point(0, 513);
           this.statusStrip1.Name = "statusStrip1";
           this.statusStrip1.Size = new System.Drawing.Size(492, 22);
           this.statusStrip1.TabIndex = 18;
           this.statusStrip1.Text = "statusStrip1";
           // 
           // tsprogFileCount
           // 
           this.tsprogFileCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
           this.tsprogFileCount.Name = "tsprogFileCount";
           this.tsprogFileCount.Size = new System.Drawing.Size(475, 16);
           this.tsprogFileCount.Step = 1;
           // 
           // statusStrip2
           // 
           this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsprogFolderCount});
           this.statusStrip2.Location = new System.Drawing.Point(0, 491);
           this.statusStrip2.Name = "statusStrip2";
           this.statusStrip2.Size = new System.Drawing.Size(492, 22);
           this.statusStrip2.TabIndex = 19;
           this.statusStrip2.Text = "statusStrip2";
           // 
           // tsprogFolderCount
           // 
           this.tsprogFolderCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
           this.tsprogFolderCount.Name = "tsprogFolderCount";
           this.tsprogFolderCount.Size = new System.Drawing.Size(475, 16);
           this.tsprogFolderCount.Step = 1;
           // 
           // formControlPanel
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(492, 535);
           this.Controls.Add(this.statusStrip2);
           this.Controls.Add(this.statusStrip1);
           this.Controls.Add(this.panel1);
           this.Controls.Add(this.tabControl1);
           this.Name = "formControlPanel";
           this.Text = "Comic Control Panel";
           this.MouseEnter += new System.EventHandler(this.formControlPanel_MouseEnter);
           this.pnlDisplayComics.ResumeLayout(false);
           this.pnlDisplayComics.PerformLayout();
           this.pnlMoveRename.ResumeLayout(false);
           this.panel3.ResumeLayout(false);
           this.panel3.PerformLayout();
           this.pnlArchiveDate.ResumeLayout(false);
           this.pnlArchiveDate.PerformLayout();
           this.panel2.ResumeLayout(false);
           this.panel2.PerformLayout();
           this.tabControl1.ResumeLayout(false);
           this.tabSelectSeries.ResumeLayout(false);
           this.tabMoveRename.ResumeLayout(false);
           this.tabMoveRename.PerformLayout();
           this.panel1.ResumeLayout(false);
           this.panel1.PerformLayout();
           this.statusStrip1.ResumeLayout(false);
           this.statusStrip1.PerformLayout();
           this.statusStrip2.ResumeLayout(false);
           this.statusStrip2.PerformLayout();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxComicPath;
       private System.Windows.Forms.FolderBrowserDialog fbDiaDisplay;
       private System.Windows.Forms.Button btnClose;
       private System.Windows.Forms.Button btnSelectSeries;
       private System.Windows.Forms.Panel pnlDisplayComics;
       private System.Windows.Forms.FolderBrowserDialog fbDiaMoveFrom;
        private System.Windows.Forms.FolderBrowserDialog fbDiaMoveTo;
        private System.Windows.Forms.Label lblFileCount;
       private System.Windows.Forms.Label lblCompleteCnt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSelectSeries;
       private System.Windows.Forms.TabPage tabMoveRename;
       private System.Windows.Forms.Panel pnlMoveRename;
       private System.Windows.Forms.TextBox tbxPathMoveTo;
       private System.Windows.Forms.Label lblTo;
       private System.Windows.Forms.Label lblFrom;
       private System.Windows.Forms.Button btnMoveGo;
       private System.Windows.Forms.TextBox tbxPathMoveFrom;
       private System.Windows.Forms.CheckBox chbxOverWrite;
       private System.Windows.Forms.RadioButton radArchive;
       private System.Windows.Forms.RadioButton radNewComic;
       private System.Windows.Forms.DateTimePicker dtpArchiveDate;
       private System.Windows.Forms.Label label2;
       private System.Windows.Forms.Panel pnlArchiveDate;
       private System.Windows.Forms.TextBox textBox2;
       private System.Windows.Forms.TextBox textBox1;
       private System.Windows.Forms.ListBox listBox1;
       private System.Windows.Forms.ListBox lbxArchiveComics;
       private System.Windows.Forms.Label lblDirectoryCnt;
       private System.Windows.Forms.Panel panel1;
       private System.Windows.Forms.Panel panel2;
       private System.Windows.Forms.Panel panel3;
       private System.Windows.Forms.RadioButton radMoveAll;
       private System.Windows.Forms.RadioButton radLimitMove;
       private System.Windows.Forms.Label lblFilesToArchive;
       private System.Windows.Forms.Label lblFilesWeKeep;
       private System.Windows.Forms.ComboBox cmbxFilesToArchive;
       private System.Windows.Forms.ComboBox cmbxFilesWeKeep;
       private System.Windows.Forms.Button btnSelectArchive;
       private System.Windows.Forms.StatusStrip statusStrip1;
       private System.Windows.Forms.ToolStripProgressBar tsprogFileCount;
       private System.Windows.Forms.Label lblKeepCnt;
       private System.Windows.Forms.Label lblArchiveCnt;
       private System.Windows.Forms.CheckBox chkbxScrollThrough;
       private System.Windows.Forms.StatusStrip statusStrip2;
       private System.Windows.Forms.ToolStripProgressBar tsprogFolderCount;
    }
}

