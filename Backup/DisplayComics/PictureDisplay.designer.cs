namespace DisplayComics
{
    partial class PictureDisplay
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
            this.lblPictTitle = new System.Windows.Forms.Label();
            this.flpDisplayArea = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlHeading = new System.Windows.Forms.Panel();
            this.lblScrollPosition = new System.Windows.Forms.Label();
            this.tbxImageInfo = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.pnlHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPictTitle
            // 
            this.lblPictTitle.AutoSize = true;
            this.lblPictTitle.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPictTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblPictTitle.Location = new System.Drawing.Point(185, 0);
            this.lblPictTitle.Name = "lblPictTitle";
            this.lblPictTitle.Size = new System.Drawing.Size(112, 55);
            this.lblPictTitle.TabIndex = 1;
            this.lblPictTitle.Text = "hello";
            this.lblPictTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpDisplayArea
            // 
            this.flpDisplayArea.AutoScroll = true;
            this.flpDisplayArea.BackColor = System.Drawing.SystemColors.Control;
            this.flpDisplayArea.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDisplayArea.Location = new System.Drawing.Point(0, 55);
            this.flpDisplayArea.Name = "flpDisplayArea";
            this.flpDisplayArea.Size = new System.Drawing.Size(643, 381);
            this.flpDisplayArea.TabIndex = 2;
            this.flpDisplayArea.WrapContents = false;
            this.flpDisplayArea.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flpDisplayArea_Scroll);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Location = new System.Drawing.Point(0, 442);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(643, 43);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(3, 12);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(36, 23);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(249, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(45, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlHeading
            // 
            this.pnlHeading.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeading.Controls.Add(this.btnPrevious);
            this.pnlHeading.Controls.Add(this.btnNext);
            this.pnlHeading.Controls.Add(this.lblScrollPosition);
            this.pnlHeading.Controls.Add(this.tbxImageInfo);
            this.pnlHeading.Controls.Add(this.lblPictTitle);
            this.pnlHeading.Location = new System.Drawing.Point(0, 0);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(656, 58);
            this.pnlHeading.TabIndex = 4;
            // 
            // lblScrollPosition
            // 
            this.lblScrollPosition.AutoSize = true;
            this.lblScrollPosition.Location = new System.Drawing.Point(317, 36);
            this.lblScrollPosition.Name = "lblScrollPosition";
            this.lblScrollPosition.Size = new System.Drawing.Size(35, 13);
            this.lblScrollPosition.TabIndex = 3;
            this.lblScrollPosition.Text = "label1";
            this.lblScrollPosition.Visible = false;
            // 
            // tbxImageInfo
            // 
            this.tbxImageInfo.Location = new System.Drawing.Point(303, 12);
            this.tbxImageInfo.Multiline = true;
            this.tbxImageInfo.Name = "tbxImageInfo";
            this.tbxImageInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxImageInfo.Size = new System.Drawing.Size(261, 20);
            this.tbxImageInfo.TabIndex = 2;
            this.tbxImageInfo.Visible = false;
            // 
            // PictureDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(722, 486);
            this.Controls.Add(this.pnlHeading);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.flpDisplayArea);
            this.Name = "PictureDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PictureDisplay";
            this.Resize += new System.EventHandler(this.PictureDisplay_Resize);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeading.ResumeLayout(false);
            this.pnlHeading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPictTitle;
        private System.Windows.Forms.FlowLayoutPanel flpDisplayArea;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlHeading;
        private System.Windows.Forms.Label lblScrollPosition;
        private System.Windows.Forms.TextBox tbxImageInfo;

    }
}