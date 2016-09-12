using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisplayComics
{
    public partial class PictureDisplay : Form
    {
        //System.Drawing.Size strOrigPictSize;
        private System.Drawing.Size strOrigFrameSize;
        private Size strAddForScroll = new Size(30, 40);
        private bool blnFirstOne = true;
        private Bitmap btmPicture;
        private string strLocation;
        private FlowDirection fldDirection = FlowDirection.TopDown;
        private double dblSizeMultiplier = 1;
        private GroupBox gbxFirstOne = new GroupBox ();
        private int intCurrentImage = 0;

        public PictureDisplay()
        {
            InitializeComponent();

            strOrigFrameSize = this.ClientSize;
            SetControlSizes();
        }

        public void ClearImages()
        {
            this.flpDisplayArea.Controls.Clear();
        }

        public void SetPictureLocation (string strLocation, string strPictureName, string strDateDetails) {
            //if (blnFullSize)
            //{
                btmPicture = new Bitmap(strLocation);
                //this.Size = btmPicture.Size;
                //this.Size = Size.Add(btmPicture.Size, strAddForScroll);
            //}
            GroupBox gbxNewOne = new GroupBox();
            //this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
            gbxNewOne.Font = new Font("Comic Sans MS", 12F);
            gbxNewOne.Text = strDateDetails;
            gbxNewOne.Width = (Int32)(btmPicture.Width * this.dblSizeMultiplier+10);
            gbxNewOne.Height = (Int32) (btmPicture.Height * this.dblSizeMultiplier+25);
            PictureBox pbxNewOne = new PictureBox();
            pbxNewOne.Width = (Int32)(btmPicture.Width * this.dblSizeMultiplier);
            pbxNewOne.Height =  (Int32) (btmPicture.Height * this.dblSizeMultiplier);
            pbxNewOne.SizeMode = PictureBoxSizeMode.Zoom;
            //pbxNewOne.Size = Size.Add(btmPicture.Size,strAddForScroll);
            if (blnFirstOne)
            {
                gbxFirstOne = gbxNewOne;
                blnFirstOne = false;
            }

            pbxNewOne.Load(strLocation);
            gbxNewOne.Controls.Add(pbxNewOne);
            pbxNewOne.Location = new Point(5, 20);
            flpDisplayArea.FlowDirection = this.fldDirection;
            flpDisplayArea.Controls.Add(gbxNewOne);
            flpDisplayArea.Size = new Size(gbxNewOne.Width + 40, gbxNewOne.Height);
            //flpDisplayArea.Size = gbxNewOne.Size;
            //flowLayoutPanel1.Controls.Add(pbxNewOne);
            this.strLocation = strLocation;

            flpDisplayArea.ScrollControlIntoView(gbxFirstOne);
            this.intCurrentImage = flpDisplayArea.Controls.Count - 1;
            this.btnNext.Enabled = false;
            if (flpDisplayArea.Controls.Count <= 1) 
            {
                this.btnPrevious.Enabled = false;
            }
            else
            {
                this.btnPrevious.Enabled = true;
            }
            int intScrollmax = flpDisplayArea.VerticalScroll.Maximum;
            tbxImageInfo.Text += strPictureName + " " + gbxNewOne.Size.ToString() + " " + intScrollmax.ToString() + Environment.NewLine;
            lblScrollPosition.Text = flpDisplayArea.VerticalScroll.Value.ToString();
            //this.lblPictTitle.Text = strPictureName;
        }

        public void SetPictureTitle(string strPicTitle)
        {
            this.lblPictTitle.Text = strPicTitle;
            this.lblPictTitle.Location = new Point((this.pnlHeading.Width - this.lblPictTitle.Width) / 2, 0);
            //MessageBox.Show("title Size: "+lblPictTitle.Size.ToString());
        }

        public void SetFlowDirection(FlowDirection fldDirection)
        {
            this.fldDirection = fldDirection;
            this.flpDisplayArea.FlowDirection = fldDirection;
        }

        public void SetSizeMultiplier(double dblMultiplier)
        {
            this.dblSizeMultiplier = dblMultiplier;
        }

        private void PictureDisplay_Resize(object sender, EventArgs e)
        {
            SetControlSizes();
            //this.flpDisplayArea.Size = Size.Subtract(this.Size, strAddForScroll);
        }

        private void SetControlSizes()
        {
             int intHeadingHeight = pnlHeading.Height;
            int intFootingHeight = pnlButtons.Height;
            int intFormHeight = this.Height;
            int intDisplayHeight = intFormHeight - (intHeadingHeight + intFootingHeight);

            int intFormWidth = this.Width;
            int intDisplayWidth = intFormWidth-10;
            flpDisplayArea.Size = new Size(intDisplayWidth, intDisplayHeight);

            pnlButtons.Size = new Size(intFormWidth-10, intFootingHeight);
            pnlButtons.Location = new Point(0, intFormHeight - (intFootingHeight+35));
            pnlHeading.Size = new Size(intFormWidth-10, intHeadingHeight);
       }

        private void flpDisplayArea_Scroll(object sender, ScrollEventArgs e)
        {
            lblScrollPosition.Text = flpDisplayArea.VerticalScroll.Value.ToString();
        }

        public void DisplayFirstImage()
        {
            this.intCurrentImage = 0;
            flpDisplayArea.ScrollControlIntoView(flpDisplayArea.Controls[intCurrentImage]);
            flpDisplayArea.Size = new Size(flpDisplayArea.Controls[intCurrentImage].Width + 40, flpDisplayArea.Controls[intCurrentImage].Height + 15);
            this.btnPrevious.Enabled = false;
            this.btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ++intCurrentImage;
            if (this.intCurrentImage < this.flpDisplayArea.Controls.Count )
            {
                this.SetFormSizeToImage(intCurrentImage);
                flpDisplayArea.ScrollControlIntoView(flpDisplayArea.Controls[intCurrentImage]);
                flpDisplayArea.Size = new Size(flpDisplayArea.Controls[intCurrentImage].Width + 40, flpDisplayArea.Controls[intCurrentImage].Height + 15);
                if (intCurrentImage+1 >= this.flpDisplayArea.Controls.Count )
                {
                    this.btnNext.Enabled = false;
                }
                if (intCurrentImage > 0)
                {
                    this.btnPrevious.Enabled = true;
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            --intCurrentImage;
            if (this.intCurrentImage >= 0)
            {
                this.SetFormSizeToImage(intCurrentImage);
                flpDisplayArea.ScrollControlIntoView(flpDisplayArea.Controls[intCurrentImage]);
                flpDisplayArea.Size = new Size(flpDisplayArea.Controls[intCurrentImage].Width + 40, flpDisplayArea.Controls[intCurrentImage].Height + 15);
                if (intCurrentImage < 1)
                {
                    this.btnPrevious.Enabled = false;
                }
                if (intCurrentImage < flpDisplayArea.Controls.Count)
                {
                    this.btnNext.Enabled = true;
                }
            }
        }

        private void SetFormSizeToImage(int intImage)
        {
            this.Size = new Size(flpDisplayArea.Controls[intImage].Width + 40, flpDisplayArea.Controls[intImage].Height + pnlButtons.Height + pnlHeading.Height + 40);
        }
    }
}