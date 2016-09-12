namespace DisplayComics
{
    partial class DisplayComicSeries
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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.chbxFixedSize = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.ckbxLimitSize = new System.Windows.Forms.CheckBox();
            this.cmboxDates = new System.Windows.Forms.ComboBox();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.btnForwardDays = new System.Windows.Forms.Button();
            this.btnBackDays = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.lblComicTitle = new System.Windows.Forms.Label();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.pnlFooting = new System.Windows.Forms.Panel();
            this.cmboxMissingDates = new System.Windows.Forms.ComboBox();
            this.cbxShowMissing = new System.Windows.Forms.CheckBox();
            this.cboxComicList = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flpComics = new System.Windows.Forms.FlowLayoutPanel();
            this.PictBoxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.pnlFooting.SuspendLayout();
            this.PictBoxContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.Transparent;
            this.pnlControl.Controls.Add(this.label1);
            this.pnlControl.Controls.Add(this.flowLayoutPanel1);
            this.pnlControl.Controls.Add(this.btnLoad);
            this.pnlControl.Controls.Add(this.chbxFixedSize);
            this.pnlControl.Controls.Add(this.dtpEndDate);
            this.pnlControl.Controls.Add(this.trackBar1);
            this.pnlControl.Controls.Add(this.ckbxLimitSize);
            this.pnlControl.Controls.Add(this.cmboxDates);
            this.pnlControl.Controls.Add(this.nudDays);
            this.pnlControl.Controls.Add(this.btnForwardDays);
            this.pnlControl.Controls.Add(this.btnBackDays);
            this.pnlControl.Controls.Add(this.btnFirst);
            this.pnlControl.Controls.Add(this.btnLast);
            this.pnlControl.Controls.Add(this.lblCounter);
            this.pnlControl.Controls.Add(this.lblComicTitle);
            this.pnlControl.Controls.Add(this.nudSize);
            this.pnlControl.Controls.Add(this.dtpStartDate);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(723, 102);
            this.pnlControl.TabIndex = 0;
            this.pnlControl.TabStop = true;
            this.pnlControl.Click += new System.EventHandler(this.pnlControl_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(390, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(100, 39);
            this.flowLayoutPanel1.TabIndex = 14;
            this.flowLayoutPanel1.MouseLeave += new System.EventHandler(this.flpComics_MouseLeave);
            this.flowLayoutPanel1.MouseEnter += new System.EventHandler(this.flpComics_MouseEnter);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(133, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(43, 23);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chbxFixedSize
            // 
            this.chbxFixedSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbxFixedSize.AutoSize = true;
            this.chbxFixedSize.ForeColor = System.Drawing.Color.Gold;
            this.chbxFixedSize.Location = new System.Drawing.Point(560, 5);
            this.chbxFixedSize.Name = "chbxFixedSize";
            this.chbxFixedSize.Size = new System.Drawing.Size(94, 17);
            this.chbxFixedSize.TabIndex = 12;
            this.chbxFixedSize.Text = "Fixed 2 across";
            this.chbxFixedSize.UseVisualStyleBackColor = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "ddd, M/d/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(3, 28);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 4;
            this.dtpEndDate.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(616, 54);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // ckbxLimitSize
            // 
            this.ckbxLimitSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbxLimitSize.AutoSize = true;
            this.ckbxLimitSize.Checked = true;
            this.ckbxLimitSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbxLimitSize.ForeColor = System.Drawing.Color.Gold;
            this.ckbxLimitSize.Location = new System.Drawing.Point(556, 31);
            this.ckbxLimitSize.Name = "ckbxLimitSize";
            this.ckbxLimitSize.Size = new System.Drawing.Size(157, 17);
            this.ckbxLimitSize.TabIndex = 6;
            this.ckbxLimitSize.TabStop = false;
            this.ckbxLimitSize.Text = "Do not Exceed Screen Size";
            this.ckbxLimitSize.UseVisualStyleBackColor = true;
            // 
            // cmboxDates
            // 
            this.cmboxDates.FormattingEnabled = true;
            this.cmboxDates.Location = new System.Drawing.Point(218, 31);
            this.cmboxDates.Name = "cmboxDates";
            this.cmboxDates.Size = new System.Drawing.Size(121, 21);
            this.cmboxDates.TabIndex = 2;
            this.cmboxDates.SelectedIndexChanged += new System.EventHandler(this.cmboxDates_SelectedIndexChanged);
            // 
            // nudDays
            // 
            this.nudDays.Location = new System.Drawing.Point(280, 5);
            this.nudDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDays.Name = "nudDays";
            this.nudDays.Size = new System.Drawing.Size(42, 20);
            this.nudDays.TabIndex = 0;
            this.nudDays.TabStop = false;
            this.nudDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDays.ValueChanged += new System.EventHandler(this.nudDays_ValueChanged);
            // 
            // btnForwardDays
            // 
            this.btnForwardDays.Location = new System.Drawing.Point(328, 3);
            this.btnForwardDays.Name = "btnForwardDays";
            this.btnForwardDays.Size = new System.Drawing.Size(23, 23);
            this.btnForwardDays.TabIndex = 7;
            this.btnForwardDays.TabStop = false;
            this.btnForwardDays.Text = ">";
            this.btnForwardDays.UseVisualStyleBackColor = true;
            this.btnForwardDays.Click += new System.EventHandler(this.btnForwardDays_Click);
            // 
            // btnBackDays
            // 
            this.btnBackDays.Location = new System.Drawing.Point(251, 3);
            this.btnBackDays.Name = "btnBackDays";
            this.btnBackDays.Size = new System.Drawing.Size(23, 23);
            this.btnBackDays.TabIndex = 1;
            this.btnBackDays.Text = "<";
            this.btnBackDays.UseVisualStyleBackColor = true;
            this.btnBackDays.Click += new System.EventHandler(this.btnBackDays_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(218, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(27, 23);
            this.btnFirst.TabIndex = 4;
            this.btnFirst.TabStop = false;
            this.btnFirst.Text = "|<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(357, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(27, 23);
            this.btnLast.TabIndex = 5;
            this.btnLast.TabStop = false;
            this.btnLast.Text = ">|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.ForeColor = System.Drawing.Color.Gold;
            this.lblCounter.Location = new System.Drawing.Point(130, 8);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(46, 13);
            this.lblCounter.TabIndex = 11;
            this.lblCounter.Text = "1 of 200";
            // 
            // lblComicTitle
            // 
            this.lblComicTitle.AutoSize = true;
            this.lblComicTitle.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComicTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblComicTitle.Location = new System.Drawing.Point(3, 38);
            this.lblComicTitle.Name = "lblComicTitle";
            this.lblComicTitle.Size = new System.Drawing.Size(285, 55);
            this.lblComicTitle.TabIndex = 1;
            this.lblComicTitle.Text = "Select Series";
            // 
            // nudSize
            // 
            this.nudSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSize.DecimalPlaces = 2;
            this.nudSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSize.Location = new System.Drawing.Point(666, 3);
            this.nudSize.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(45, 20);
            this.nudSize.TabIndex = 2;
            this.nudSize.TabStop = false;
            this.nudSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.nudSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "ddd, M/d/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(3, 3);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.TabStop = false;
            // 
            // pnlFooting
            // 
            this.pnlFooting.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooting.Controls.Add(this.cmboxMissingDates);
            this.pnlFooting.Controls.Add(this.cbxShowMissing);
            this.pnlFooting.Controls.Add(this.cboxComicList);
            this.pnlFooting.Controls.Add(this.btnClose);
            this.pnlFooting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooting.Location = new System.Drawing.Point(0, 140);
            this.pnlFooting.Name = "pnlFooting";
            this.pnlFooting.Size = new System.Drawing.Size(723, 33);
            this.pnlFooting.TabIndex = 1;
            this.pnlFooting.TabStop = true;
            // 
            // cmboxMissingDates
            // 
            this.cmboxMissingDates.FormattingEnabled = true;
            this.cmboxMissingDates.Location = new System.Drawing.Point(265, 7);
            this.cmboxMissingDates.Name = "cmboxMissingDates";
            this.cmboxMissingDates.Size = new System.Drawing.Size(135, 21);
            this.cmboxMissingDates.TabIndex = 3;
            this.cmboxMissingDates.TabStop = false;
            // 
            // cbxShowMissing
            // 
            this.cbxShowMissing.AutoSize = true;
            this.cbxShowMissing.Checked = true;
            this.cbxShowMissing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxShowMissing.Location = new System.Drawing.Point(244, 7);
            this.cbxShowMissing.Name = "cbxShowMissing";
            this.cbxShowMissing.Size = new System.Drawing.Size(15, 14);
            this.cbxShowMissing.TabIndex = 2;
            this.cbxShowMissing.TabStop = false;
            this.cbxShowMissing.Tag = "";
            this.toolTip1.SetToolTip(this.cbxShowMissing, "Display Missing Dates");
            this.cbxShowMissing.UseVisualStyleBackColor = true;
            this.cbxShowMissing.CheckedChanged += new System.EventHandler(this.cbxShowMissing_CheckedChanged);
            // 
            // cboxComicList
            // 
            this.cboxComicList.FormattingEnabled = true;
            this.cboxComicList.Location = new System.Drawing.Point(3, 5);
            this.cboxComicList.Name = "cboxComicList";
            this.cboxComicList.Size = new System.Drawing.Size(143, 21);
            this.cboxComicList.TabIndex = 3;
            this.cboxComicList.SelectedIndexChanged += new System.EventHandler(this.cboxComicList_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(163, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flpComics
            // 
            this.flpComics.AutoScroll = true;
            this.flpComics.AutoSize = true;
            this.flpComics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpComics.Location = new System.Drawing.Point(0, 102);
            this.flpComics.Name = "flpComics";
            this.flpComics.Size = new System.Drawing.Size(723, 38);
            this.flpComics.TabIndex = 2;
            this.flpComics.MouseLeave += new System.EventHandler(this.flpComics_MouseLeave);
            this.flpComics.MouseEnter += new System.EventHandler(this.flpComics_MouseEnter);
            // 
            // PictBoxContextMenu
            // 
            this.PictBoxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.PictBoxContextMenu.Name = "PictBoxContextMenu";
            this.PictBoxContextMenu.Size = new System.Drawing.Size(103, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem2.Text = "TryIt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(391, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Scroll current series";
            // 
            // DisplayComicSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(723, 173);
            this.Controls.Add(this.flpComics);
            this.Controls.Add(this.pnlFooting);
            this.Controls.Add(this.pnlControl);
            this.Name = "DisplayComicSeries";
            this.Text = "1";
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.pnlFooting.ResumeLayout(false);
            this.pnlFooting.PerformLayout();
            this.PictBoxContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Label lblComicTitle;
       private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Panel pnlFooting;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.ComboBox cboxComicList;
        private System.Windows.Forms.Button btnForwardDays;
        private System.Windows.Forms.Button btnBackDays;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.CheckBox cbxShowMissing;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmboxMissingDates;
        private System.Windows.Forms.ComboBox cmboxDates;
       private System.Windows.Forms.CheckBox ckbxLimitSize;
       private System.Windows.Forms.TrackBar trackBar1;
       private System.Windows.Forms.DateTimePicker dtpEndDate;
       private System.Windows.Forms.FlowLayoutPanel flpComics;
       private System.Windows.Forms.CheckBox chbxFixedSize;
       private System.Windows.Forms.Button btnLoad;
       private System.Windows.Forms.ContextMenuStrip PictBoxContextMenu;
       private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
       private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}