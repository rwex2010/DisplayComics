using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Threading;
//using System.Collections;
using System.IO;


namespace DisplayComics
{
   public partial class DisplayComicSeries : Form
   {
      // class variables
      //private System.Drawing.Size strOrigFrameSize;
      private Size strAddForScroll = new Size(30, 40);
      private ListOfFiles lofFileListObject;
      private FileInfo[] aryFileInfo;
      private DateTime[] aryDateTime;
      private int intTotalCount = 0;
      //private bool blnFirstOne = true;
      private Bitmap btmPicture;
      //private string strLocation;
      private double dblSizeMultiplier = 1;
      private int intCurrentImage = 0;
      private int intMaxWidth = 0;
      private int intMaxHeight = 0;
      private int intMinWidth = 0;
      private int intMinHeight = 0;
      private int intHalfWidth = 0;
      private int intHalfHeight = 0;
      private Form frmCallinForm;
      //private Color NoneMissing = Color.LightGoldenrodYellow;
      private Color NoneMissing = Color.Black;
      private Color SomeMissing = Color.Red;
      private System.Windows.Forms.PictureBox[] picBoxArray;
      private SaveFileDialog saveImageDialog;
      private string strSavePath = "";
      private DialogResult dResult;
      private Point pntZeroZero = new Point(0, 0);
      private Rectangle rectWorkingArea = new Rectangle();

       //following for creating a master dataset to determine valid missing dates;
      private string ComicFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\comics\";
      // private string ComicFilePath = @"P:\Misc\";
      private MyComics dsMaster = new MyComics();
      private DataSet dsMyComics = new DataSet();
      private DataSet dsComic = new DataSet();
      private DataTable dtMasterTable = new DataTable("MyComic");
       private DataRowCollection drcMasterRow;

      private string[] aryComicName = new string[100];
      private string[] aryComicCode = new string[100];
      private string[] aryDomain = new string[100];
      private string[] aryDateFormat = new string[100];
      private string[] arySundayExt = new string[100];
      private string[] aryDailyExt = new string[100];
      private string[] aryUrlFormat = new string[100];
      private bool[] arySundayAvail = new bool[100];
      private bool[] aryOneOfMyComics = new bool[100];
      private int[] aryDaysAvailable = new int[100];

      //private object[] picBoxArray = new object[2];


      public DisplayComicSeries()
      {
         InitializeComponent();

         BuildMasterDataset();

         //this.InitializePictureBox();
         SetWorkingArea();
         this.intMaxWidth = Screen.GetWorkingArea(this).Width;
         this.intMaxHeight = Screen.GetWorkingArea(this).Height;
         this.intMinHeight = this.Height;
         this.intMinWidth = this.Width;
         this.intHalfHeight = Screen.GetWorkingArea(this).Height / 2;
         this.intHalfWidth = Screen.GetWorkingArea(this).Width / 2;

         this.Top = 0;
         this.Left = 0;
         this.dtpStartDate.MaxDate = DateTime.Today;
         this.Location = pntZeroZero;
         //this.dtpStartDate.Value = DateTime.Today;
      }

       private void SetWorkingArea()
       {
           Point pntZerio = new Point(0, 0);
           Screen[] aryScreens = Screen.AllScreens;
           int intZeroX = 0;
           int intWorkingAreaWidth = 0;
           int intZeroY = 0;
           int intWorkingAreaHeight = 0;
           Size szWorkingArea = new Size();

           for (int ix = 0; ix < aryScreens.Length; ix++)
           {
               intZeroX += aryScreens[ix].Bounds.X;
               intWorkingAreaWidth += aryScreens[ix].Bounds.Width;

               intZeroY += aryScreens[ix].Bounds.Y;
               intWorkingAreaHeight += aryScreens[ix].Bounds.Height;
           }
           if (intZeroX >= 0)
           {
               if (intZeroY >= 0)
               {
                   pntZeroZero = new Point(0, 0);
               }
               else
               {
                   pntZeroZero = new Point(0, intZeroY);
               }
               if (intZeroX == 0)
               {
                   szWorkingArea = new Size(aryScreens[0].Bounds.Width, intWorkingAreaHeight);
               }
               else
               {
                   szWorkingArea = new Size(intWorkingAreaWidth, aryScreens[0].Bounds.Height);
               }
           }
           else
           {
               if (intZeroY >= 0)
               {
                   pntZeroZero = new Point(intZeroX, 0);
               }
               else
               {
                   pntZeroZero = new Point(intZeroX, intZeroY);
               }
               szWorkingArea = new Size(intWorkingAreaWidth, aryScreens[0].Bounds.Height);
           }
           rectWorkingArea = new Rectangle(pntZeroZero, szWorkingArea);
       }


      private void InitializePictureBox()
      {
         //System.Windows.Forms.PictureBox myPic = new System.Windows.Forms.PictureBox();
         this.picBoxArray = new PictureBox[2];
         //this.picBoxArray[0] = myPic;
         this.picBoxArray[0] = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.picBoxArray[0])).BeginInit();
         // 
         // picBox
         // 
         this.picBoxArray[0].BackColor = System.Drawing.Color.Transparent;
         this.picBoxArray[0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.picBoxArray[0].Location = new System.Drawing.Point(13, 121);
         this.picBoxArray[0].Name = "picBox1";
         this.picBoxArray[0].Size = new System.Drawing.Size(403, 31);
         this.picBoxArray[0].TabIndex = 1;
         this.picBoxArray[0].TabStop = false;

         // 
         // DisplayComicSeries
         // 
         this.Controls.Add(this.picBoxArray[0]);
         //this.flpComics.Controls.Add(this.picBoxArray[0]);

         ((System.ComponentModel.ISupportInitialize)(this.picBoxArray[0])).EndInit();
      }

      public void SetThisCallingForm(Form callingForm)
      {
         this.frmCallinForm = callingForm;
         this.cboxComicList.Focus();
      }

      public void SetThisDisplay(ListOfFiles FileList, decimal sizeMultiplier)
      {
         this.lofFileListObject = FileList;
         this.dblSizeMultiplier = (double)sizeMultiplier;
         this.nudSize.Value = sizeMultiplier;
         this.aryFileInfo = lofFileListObject.GetFileList();
         if (this.aryFileInfo.Length > 0)
         {
            this.aryDateTime = lofFileListObject.GetDateTimeList();
            this.intTotalCount = aryDateTime.Length;
            this.intCurrentImage = this.intTotalCount - 1;
            this.cmboxDates.Items.Clear();
            for (int ix = 0; ix < intTotalCount; ix++)
            {
               this.cmboxDates.Items.Add(this.aryDateTime[ix].ToString("ddd. MM/dd/yyyy"));
            }
            //this. cmboxDates.SelectedIndex = this.intCurrentImage;
            //strOrigFrameSize = this.ClientSize;
            this.CheckForActiveButtons();

            this.dtpStartDate.MaxDate = DateTime.Today;
            try
            {
               this.dtpStartDate.MinDate = aryDateTime[0];

            }
            catch (Exception)
            {
               aryDateTime[0] = DateTime.Today;
               if (this.dtpStartDate.Value.CompareTo(DateTime.Today) == 0)
               {
                   this.dtpStartDate.MinDate = DateTime.Today;
               }
               else
               {
                   this.dtpStartDate.MinDate = this.dtpStartDate.Value;
               }
            }
            //if (DateTime.Compare(aryDateTime[0], aryDateTime[intTotalCount - 1]) <= 0)
            //{
            //   this.dtpStartDate.MaxDate = aryDateTime[intTotalCount - 1];
            //}
            //else
            //{
            //   this.dtpStartDate.MinDate = this.dtpStartDate.MaxDate.AddDays(-60.0);
            //}
            this.cmboxDates.SelectedIndex = this.intCurrentImage;

            this.dblSizeMultiplier = (double)this.nudSize.Value;

            this.intCurrentImage = this.intTotalCount - 1;
            this.flpComics.Controls.Clear();
            DisplayRangeOfImages();
            //SetupImageDisplay();
         }
      }

      public void SetThisDisplay(DirectoryInfo[] dinfoListofFolders)
      {
         this.cboxComicList.Items.AddRange(dinfoListofFolders);

      }

      private void SetControlSizes()
      {
         int intContrlHeight = pnlControl.Height;
         int intFootingHeight = pnlFooting.Height;
         int intFormHeight = this.Height;
         //int intDisplayHeight = intFormHeight - (intContrlHeight + intFootingHeight);

         int intFormWidth = this.Width;
         //int intDisplayWidth = intFormWidth - 26;
         //picBox.Size = new Size(intDisplayWidth, intDisplayHeight);

         pnlFooting.Size = new Size(intFormWidth - 30, intFootingHeight);
         //pnlFooting.Location = new Point(0, intFormHeight - (intFootingHeight + 35));
         //pnlFooting.Location = new Point(0, intContrlHeight + this.picBoxFirst.Height+20);
         pnlControl.Size = new Size(intFormWidth - 30, intContrlHeight);
         pnlControl.Location = new Point(0, 0);
         //picBoxFirst.Location = new Point(0, intContrlHeight);
      }

      private void nudSize_ValueChanged(object sender, EventArgs e)
      {
         this.dblSizeMultiplier = (double)this.nudSize.Value;
         this.flpComics.Controls.Clear();
         DisplayRangeOfImages();
         //SetupImageDisplay();
      }

      private void SetFormSizeToImage()
      {
         this.AutoScroll = false;
         this.Size = new Size(0, 0);
         this.flpComics.Size = new Size(0, 0);
         this.flpComics.Size = new Size(1280, 965);
         this.flpComics.Width = intMaxWidth;
         this.flpComics.Height = intMaxHeight;
         //int intFormHeight = this.picBoxFirst.Height + this.pnlFooting.Height + this.pnlControl.Height + 75;
         //int intFormWidth = this.picBoxFirst.Width + 45;
         int intFormHeight = this.flpComics.Height + this.pnlFooting.Height + this.pnlControl.Height + 75;
         int intFormWidth = this.flpComics.Width + 45;
         if (intFormHeight > intMaxHeight)
         {
            intFormHeight = intMaxHeight;
            this.AutoScroll = true;
         }
         if (intFormWidth > intMaxWidth)
         {
            intFormWidth = intMaxWidth;
         }
         if (intFormHeight < intMinHeight)
         {
            intFormHeight = intMinHeight;
         }
         if (intFormWidth < intMinWidth)
         {
            intFormWidth = intMinWidth;
         }
         //this.Size = new Size(this.picBox.Width + 26, this.picBox.Height + this.pnlFooting.Height + this.pnlControl.Height + 60);
         //this.Size = new Size(intFormWidth, intFormHeight);
         this.Size = new Size(intMaxWidth, intMaxHeight);
      }

      private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
      {
         this.flpComics.Controls.Clear();
         DisplayRangeOfImages();
      }

      private void DisplayRangeOfImages()
      {
         try
         {
            
            DateTime current = dtpStartDate.Value;
            if (current.CompareTo(this.aryDateTime[this.cmboxDates.SelectedIndex]) > 0)
            {
               current = this.aryDateTime[this.cmboxDates.SelectedIndex];
            }
            while ((current.CompareTo(dtpEndDate.Value) <= 0))
            {
               intCurrentImage = Array.IndexOf(aryDateTime, current);
               if (intCurrentImage >= 0)
               {
                  //this.flpComics.Controls.Clear();
                  //this.cmboxDates.SelectedIndex = intCurrentImage;
                  this.CheckForActiveButtons();
                  SetupImageDisplay();
               }
               current = current.AddDays(1);
            }
         }
         catch (Exception e)
         {
            DateTime current = dtpStartDate.Value;
         }
      }

      private void SetupImageDisplay()
      {
         //this.flpComics.Controls.Clear();
         string strPictLocation = aryFileInfo[intCurrentImage].FullName;
         //try
         //{
         //   this.dtpStartDate.Value = aryDateTime[intCurrentImage];

         //}
         //catch (Exception)
         //{
         //   this.dtpStartDate.Value = DateTime.Today;
         //}
         this.lblComicTitle.Text = aryFileInfo[intCurrentImage].Directory.Name;
         //SetPictureLocation(strPictLocation);
         //this.picBoxFirst = GetFilledPictureBox(strPictLocation);
         //this.flpComics.Controls.Add(GetFilledPictureBox(strPictLocation));
         PictureBox imgPicBox = new PictureBox();
         imgPicBox = GetFilledPictureBox(strPictLocation);
         GroupBox gbox = new GroupBox();
         gbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         gbox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         gbox.ForeColor = System.Drawing.Color.White;
         //gbox.ForeColor = System.Drawing.Color.Black;
         //gbox.Location = new System.Drawing.Point(295, 54);
         //gbox.Name = "groupBox1";
         gbox.Name = "gbx_" + intCurrentImage.ToString();
         gbox.Size = new System.Drawing.Size(imgPicBox.Width + 3, imgPicBox.Height + 3);
         gbox.TabIndex = 13;
         gbox.TabStop = false;
         string strImageDate = this.aryDateTime[intCurrentImage].DayOfWeek + " " + this.aryDateTime[intCurrentImage].GetDateTimeFormats('d')[3];
         gbox.Text = strImageDate;
         //gbox.Width = imgPicBox.Width + 3;
         //gbox.Height = imgPicBox.Height + 3;
         //gbox.ForeColor = System.Drawing.Color.White;
         //gbox.Text = "hello";
         gbox.Controls.Add(imgPicBox);
         imgPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.flpComics.Controls.Add(gbox);
         this.Size = new Size(intMaxWidth, intMaxHeight);
         //SetFormSizeToImage();
         //SetControlSizes();                
      }

      private void btnFirst_Click(object sender, EventArgs e)
      {
         intCurrentImage = 0;
         this.CheckForActiveButtons();
         this.flpComics.Controls.Clear();
         SetupImageDisplay();
      }

      private void btnLast_Click(object sender, EventArgs e)
      {
         intCurrentImage = aryDateTime.Length - 1;
         this.CheckForActiveButtons();
         this.flpComics.Controls.Clear();
         SetupImageDisplay();
      }

      private void cboxComicList_SelectedIndexChanged(object sender, EventArgs e)
      {
         this.flpComics.Controls.Clear();
         this.cmboxMissingDates.Items.Clear();
         this.Text = this.cboxComicList.Text;
         DirectoryInfo dinfoSelected = (DirectoryInfo)cboxComicList.SelectedItem;
         this.lofFileListObject = new ListOfFiles(dinfoSelected.FullName, true);
         SetThisDisplay(lofFileListObject, this.nudSize.Value);
         if (this.cbxShowMissing.Checked)
         {
            if (dinfoSelected.Name != "Hold" && dinfoSelected.Name != "Misc")
            {
                //FindRowInTable(dinfoSelected.Name);

               fillMissingDatesCombo();
            }
         }
      }

      private void btnBackDays_Click(object sender, EventArgs e)
      {
         double daysToSubtract = (double)nudDays.Value;
         DateTime current = dtpStartDate.Value;
         DateTime newtime = current.AddDays(-daysToSubtract);
         bool blnNotFound = true;
         //MessageBox.Show(newtime.CompareTo(dateTimePicker1.MinDate).ToString());
         while ((newtime.CompareTo(dtpStartDate.MinDate) >= 0) && blnNotFound)
         {
            try
            {
               int intAryLoc = Array.IndexOf(aryDateTime, newtime);
               if (intAryLoc >= 0)
               {
                  dtpStartDate.Value = newtime;
                  blnNotFound = false;
               }
               else
               {
                  newtime = newtime.AddDays(-1);
               }
            }
            catch (Exception notInArray)
            {
               newtime = newtime.AddDays(-1);
            }
         }
      }

      private void btnForwardDays_Click(object sender, EventArgs e)
      {
         double daysToAdd = (double)nudDays.Value;


         DateTime current = dtpStartDate.Value;
         DateTime newtime = current.AddDays(daysToAdd);
         bool blnNotFound = true;
         while ((newtime.CompareTo(dtpStartDate.MaxDate) <= 0) && blnNotFound)
         {
            try
            {
               Array.IndexOf(aryDateTime, newtime);
               dtpStartDate.Value = newtime;
               blnNotFound = false;
            }
            catch (Exception notInArray)
            {
               newtime = newtime.AddDays(1);
            }
         }
      }

      private void CheckForActiveButtons()
      {
         if (nudDays.Value + intCurrentImage >= aryDateTime.Length)
         {
            if (intCurrentImage >= aryDateTime.Length - 1)
            {
               btnLast.Enabled = false;
            }
            else
            {
               btnLast.Enabled = true;
            }
            btnForwardDays.Enabled = false;
         }
         else
         {
            btnForwardDays.Enabled = true;
            btnLast.Enabled = true;
         }
         if (intCurrentImage - nudDays.Value < 0)
         {
            if (intCurrentImage <= 0)
            {
               btnFirst.Enabled = false;
            }
            else
            {
               btnFirst.Enabled = true;
            }
            this.btnBackDays.Enabled = false;
         }
         else
         {
            this.btnBackDays.Enabled = true;
            btnFirst.Enabled = true;
         }
      }

      private void nudDays_ValueChanged(object sender, EventArgs e)
      {
         this.CheckForActiveButtons();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.frmCallinForm.Close();
      }

      private void cbxShowMissing_CheckedChanged(object sender, EventArgs e)
      {
         if (this.cbxShowMissing.Checked)
         {
            fillMissingDatesCombo();
         }
         else
         {
            this.cmboxMissingDates.Items.Clear();
         }
      }

      private void fillMissingDatesCombo()
      {
         if (this.aryDateTime.Length > 0)
         {
                  Boolean blnOkayToAdd = true;
            Boolean blnMissingCurrent = false;
            for (int ix = 1; ix < this.aryDateTime.Length; ix++)
            {
               DateTime nextDate = this.aryDateTime[ix - 1];
               nextDate = nextDate.AddDays(1.0);
               while (!nextDate.Equals(aryDateTime[ix]))
               {
                  blnOkayToAdd = true;
                  blnOkayToAdd = isThisDateIncluded(this.cboxComicList.SelectedItem.ToString(), nextDate);
                  //if (blnOkayToAdd)
                  //{
                  //    switch (this.cboxComicList.SelectedItem.ToString())
                  //    {
                  //        case "9 to 5":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "Ben":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "Bottom Liners":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "Hector":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "Working Daze":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "Compu-toon":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "Safe Havens":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "Shirleynson":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "The Grizzwells":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            break;
                  //        case "Yenny":
                  //            blnOkayToAdd = DontShowSunday(nextDate.DayOfWeek.ToString());
                  //            if (blnOkayToAdd)
                  //            {
                  //                blnOkayToAdd = DontShowSaturday(nextDate.DayOfWeek.ToString());
                  //            }
                  //            break;
                  //        default:
                  //            blnOkayToAdd = true;
                  //            break;
                  //    }
                     
                  //}
                  if (blnOkayToAdd)
                  {
                     TimeSpan interval = DateTime.Today.Subtract(nextDate);
                     int intDaysBehind = interval.Days;
                     if (intDaysBehind < 30)
                     {
                        blnMissingCurrent = true;
                     }
                     this.cmboxMissingDates.Items.Add(nextDate.ToString("ddd, MM/dd/yy"));
                  }
                  nextDate = nextDate.AddDays(1.0);
               }
            }
            DateTime lastDate = this.aryDateTime[aryDateTime.Length - 1];
            lastDate = lastDate.AddDays(1.0);
            while (DateTime.Compare(lastDate, DateTime.Today) <= 0)
            {
                blnOkayToAdd = isThisDateIncluded(this.cboxComicList.SelectedItem.ToString(), lastDate);
                if (blnOkayToAdd)
                {
                    blnMissingCurrent = true;
                    this.cmboxMissingDates.Items.Add(lastDate.ToString("ddd, MM/dd/yy"));
                }
                lastDate = lastDate.AddDays(1.0);
            }
            if (this.cmboxMissingDates.Items.Count == 0)
            {
               this.cmboxMissingDates.Items.Add("NONE");
               this.BackColor = NoneMissing;
            }
            else
            {
               if (blnMissingCurrent)
               {
                  this.BackColor = SomeMissing;
              }
              else
              {
                  this.BackColor = NoneMissing;
              }
            }
            this.cmboxMissingDates.SelectedIndex = this.cmboxMissingDates.Items.Count - 1;
         }
      }

      //private Boolean DontShowSunday(string dayOfWeek)
      //{
      //   Boolean blnReturnValue = true;
      //   if (dayOfWeek == "Sunday")
      //   {
      //      blnReturnValue = false;
      //   }
      //   return blnReturnValue;
      //}

      //private Boolean DontShowSaturday(string dayOfWeek)
      //{
      //   Boolean blnReturnValue = true;
      //   if (dayOfWeek == "Saturday")
      //   {
      //      blnReturnValue = false;
      //   }
      //   return blnReturnValue;
      //}

      private void cmboxDates_SelectedIndexChanged(object sender, EventArgs e)
      {
         this.flpComics.Controls.Clear();
         //this.cmboxDates.SelectedIndex = intCurrentImage;
         intCurrentImage = this.cmboxDates.SelectedIndex;
         this.CheckForActiveButtons();
         this.flpComics.Controls.Clear();
         SetupImageDisplay();

         //this.flpComics.Controls.Clear();
         //try
         //{
         // this.dtpStartDate.Value = this.aryDateTime[this. cmboxDates.SelectedIndex];

         //}
         //catch (Exception)
         //{

         //   this.dtpStartDate.Value = DateTime.Today;
         //}
      }

      private PictureBox GetFilledPictureBox(string ImageLocation)
      {
         this.lblCounter.Text = (intCurrentImage + 1) + " of " + intTotalCount;
         //this.btmPicture = new Bitmap(strLocation);

         Bitmap btmImage = new Bitmap(ImageLocation);
         int intImageHeight = btmImage.Height;
         int intImageWidth = btmImage.Width;

         PictureBox pbxImage = new PictureBox();
         pbxImage.Name = "pbx_" + intCurrentImage.ToString();
         pbxImage.ContextMenuStrip = this.PictBoxContextMenu;

         if (this.chbxFixedSize.Checked)
         {
            pbxImage.Width = (Int32)btmImage.Width;
            pbxImage.Height = (Int32)btmImage.Height;

            decimal dblAdjWidth = (decimal)(this.intHalfWidth -45)/ (decimal)pbxImage.Width;
            decimal dblAdjHeight = (decimal)(this.intHalfHeight-90) / (decimal)pbxImage.Height;
            if (dblAdjHeight <= dblAdjWidth)
            {
               //pbxImage.Width = (int)(pbxImage.Width * dblAdjWidth);
               //pbxImage.Height = (int)(pbxImage.Height * dblAdjWidth);
                pbxImage.Width = (int)(pbxImage.Width * dblAdjHeight);
                pbxImage.Height = (int)(pbxImage.Height * dblAdjHeight);
            }
            else
            {
               //pbxImage.Width = (int)(pbxImage.Width * dblAdjHeight);
               //pbxImage.Height = (int)(pbxImage.Height * dblAdjHeight);
                pbxImage.Width = (int)(pbxImage.Width * dblAdjWidth);
                pbxImage.Height = (int)(pbxImage.Height * dblAdjWidth);
            }

         }
         else
         {


            pbxImage.Width = (Int32)(btmImage.Width * this.dblSizeMultiplier);
            pbxImage.Height = (Int32)(btmImage.Height * this.dblSizeMultiplier);

            if (this.ckbxLimitSize.Checked)
            {
               int intFixedHeight = this.pnlFooting.Height + this.pnlControl.Height + 75;
               int intFormHeight = pbxImage.Height + intFixedHeight;
               int intFormWidth = pbxImage.Width + 45;
               if ((intFormWidth > this.intMaxWidth) || (intFormHeight > this.intMaxHeight))
               {
                  int intNewWidth = pbxImage.Width - (intFormWidth - this.intMaxWidth);
                  decimal dblAdjustWidth = (decimal)intNewWidth / (decimal)pbxImage.Width;

                  int intNewHeight = pbxImage.Height - (intFormHeight - this.intMaxHeight);
                  decimal dblAdjustHeight = (decimal)intNewHeight / (decimal)pbxImage.Height;
                  if (dblAdjustHeight <= dblAdjustWidth)
                  {
                     //pbxImage.Width = (int)(pbxImage.Width * dblAdjustWidth);
                     //pbxImage.Height = (int)(pbxImage.Height * dblAdjustWidth);
                      pbxImage.Width = (int)(pbxImage.Width * dblAdjustHeight);
                      pbxImage.Height = (int)(pbxImage.Height * dblAdjustHeight);
                  }
                  else
                  {
                     //pbxImage.Width = (int)(pbxImage.Width * dblAdjustHeight);
                     //pbxImage.Height = (int)(pbxImage.Height * dblAdjustHeight);
                      pbxImage.Width = (int)(pbxImage.Width * dblAdjustWidth);
                      pbxImage.Height = (int)(pbxImage.Height * dblAdjustWidth);
                  }
               }
            }
         }

         pbxImage.BorderStyle = BorderStyle.Fixed3D;
         pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         pbxImage.ImageLocation = ImageLocation;
         //pbxImage.Image = imgThumbNail;
         pbxImage.Image = (Image)btmImage;
         pbxImage.Image.Tag = ImageLocation;
         pbxImage.Tag = intCurrentImage.ToString();
         pbxImage.Click += new EventHandler(pbxImage_Click); 

         return pbxImage;
      }


      void pbxImage_Click(object sender, EventArgs e)
      {

         //string senderName = ((System.Windows.Forms.Control)(sender)).Name;
         string imageLoc = ((System.Windows.Forms.PictureBox)(sender)).ImageLocation;
         //MessageBox.Show("senderName: " + senderName + "\nImageLoc: " + imageLoc);
         System.Drawing.Bitmap imageBitMap = new Bitmap(imageLoc);
         this.saveImageDialog = new SaveFileDialog();
         saveImageDialog.FileName = imageLoc;
         saveImageDialog.Title = "Save this Image";
         saveImageDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
         //saveImageDialog.Filter = "JPeg Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|All files (*.*)|*.*";
         saveImageDialog.InitialDirectory = this.strSavePath;
         saveImageDialog.RestoreDirectory = true;
         if (saveImageDialog.ShowDialog() != DialogResult.Cancel)
         {
            if (saveImageDialog.FileName != "")
            {
               string strDirPath = Path.GetDirectoryName(saveImageDialog.FileName);
               strSavePath = strDirPath;
               System.IO.FileStream fsImage = (FileStream)saveImageDialog.OpenFile();
               switch (saveImageDialog.FilterIndex)
               {
                  case 1:
                     imageBitMap.Save(fsImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                     break;

                  case 2:
                     imageBitMap.Save(fsImage, System.Drawing.Imaging.ImageFormat.Bmp);
                     break;

                  case 3:
                     imageBitMap.Save(fsImage, System.Drawing.Imaging.ImageFormat.Gif);
                     break;

                  default:
                     break;
               }
               fsImage.Close();
            }
         }

      }

      private void pnlControl_Click(object sender, EventArgs e)
      {
         string NL = Environment.NewLine;
         int intFormHeight = this.Size.Height;
         int intFormWidth = this.Size.Width;
             int index;
             int upperBound; 

             // Gets an array of all the screens connected to the system.

             Screen [] screens = Screen.AllScreens;
             upperBound = screens.GetUpperBound(0);



         //int intPicBoxHeight = this.picBoxFirst.Height;
         //int intPicBoxWidth = this.picBoxFirst.Width;
         int intPnlFootingHeight = this.pnlFooting.Height;
         int intPnlControlHeight = this.pnlControl.Height;


         //int intCalcHeight = this.picBoxFirst.Height + this.pnlFooting.Height + this.pnlControl.Height + 75;

         string msg = "";
         msg += "Form Height: " + intFormHeight + NL;
         msg += "Form Width: " + intFormWidth + NL;
         //msg += "PicBox Height: " + intPicBoxHeight + NL;
         //msg += "PicBox Width: " + intPicBoxWidth + NL;
         msg += "Footer Pannel: " + intPnlFootingHeight + NL;
         msg += "Control Panel: " + intPnlControlHeight + NL;
         msg += "Screen Width: " + Screen.GetWorkingArea(this).Width + NL;
         msg += "Top: " + this.Top + NL;
         msg += "Left: " + this.Left + NL;
         msg += "Length of screens Array: " + screens.Length.ToString() + NL;
         msg += "upperBound of screens Array: " + upperBound + NL;
             for(index = 0; index <= upperBound; index++)
             {
                 msg += "Device Name: " + screens[index].DeviceName + NL;
                 msg += "Bounds: " + screens[index].Bounds.ToString() + NL;
                 msg += "Type: " + screens[index].GetType().ToString() + NL;
                 msg += "Working Area: " + screens[index].WorkingArea.ToString() + NL;
                 msg += "Primary Screen: " + screens[index].Primary.ToString() + NL;

         /* 

                 // For each screen, add the screen properties to a list box.

                 listBox1.Items.Add("Device Name: " + screens[index].DeviceName);
                 listBox1.Items.Add("Bounds: " + screens[index].Bounds.ToString());
                 listBox1.Items.Add("Type: " + screens[index].GetType().ToString());
                 listBox1.Items.Add("Working Area: " + screens[index].WorkingArea.ToString());
                 listBox1.Items.Add("Primary Screen: " + screens[index].Primary.ToString());

         */
             }
         //msg += "Calculated: " + intCalcHeight + NL;
         //msg += ;
         //msg += ;
         //msg += ;
         MessageBox.Show(msg);
         //int intFormWidth = this.picBox.Width + 45;

      }

      private void trackBar1_Scroll(object sender, EventArgs e)
      {
         nudSize.Value = (decimal)trackBar1.Value / 100;
      }

      private void btnLoad_Click(object sender, EventArgs e)
      {
         this.flpComics.Controls.Clear();
         DisplayRangeOfImages();
      }

      private void toolStripMenuItem1_Click(object sender, EventArgs e)
      {
         MessageBox.Show("sender: "+sender.ToString()+"\nEventArgs: "+ e.ToString());
     }

     #region code entered in this 'region' is to build the dataset

       //private void FindRowInTable(string strComicName)
       //{
       //    DataRow drComicRow = drcMasterRow.Find(strComicName);
       //}
       private bool isThisDateIncluded(string strComicName, DateTime dtDateToUse)
       {
           bool blnReturnValue = true;
               if (DateTime.Today.ToShortDateString() == dtDateToUse.ToShortDateString())
               {
                   string dmy = "hold";
               }
           try
           {

               DataRow drComicRow = drcMasterRow.Find(strComicName);

               //int intValueTocompare = int.Parse(tbxCbxTotal.Text);
               int intValueTocompare = int.Parse(drComicRow["DaysAvailable"].ToString());
               string strDayOfWeek = dtDateToUse.DayOfWeek.ToString();
               int intValuePassed = 0;
               switch (strDayOfWeek)
               {
                   case "Sunday":
                       intValuePassed = 63;
                       break;
                   case "Monday":
                       intValuePassed = 95;
                       break;
                   case "Tuesday":
                       intValuePassed = 111;
                       break;
                   case "Wednesday":
                       intValuePassed = 119;
                       break;
                   case "Thursday":
                       intValuePassed = 123;
                       break;
                   case "Friday":
                       intValuePassed = 125;
                       break;
                   case "Saturday":
                       intValuePassed = 126;
                       break;
                   default:
                       break;
               }
               if ((intValueTocompare | intValuePassed) == 127)
               {
                   blnReturnValue = true;
               }
               else
               {
                   blnReturnValue = false;
               }

           }
           catch (Exception)
           {
               //foreach (DataRow drComicRow in drcMasterRow)
               //{
               //    int RowIndex = drcMasterRow.IndexOf(drComicRow);
               //    string ComicNme = drComicRow["ComicName"].ToString();
               //    MessageBox.Show("Comic: " + ComicNme + " Index: " + RowIndex.ToString());
               //}

               string dmy = "";
           }
           return blnReturnValue;
       }

     private void BuildMasterDataset()
       {
           InitializeDataSets();
           updateDataSetArray();
           CreateMasterDataSet();
           dtMasterTable = dsMaster.Tables[0];
           drcMasterRow = dtMasterTable.Rows;
       }

      private void InitializeDataSets()
      {
          string strFilePath = "";
          strFilePath = this.ComicFilePath + "MyComic.xml";
          this.dsMyComics = OpenDataSet(strFilePath);

          strFilePath = this.ComicFilePath + "Commic.xml";
          this.dsComic = OpenDataSet(strFilePath);
      }

      private DataSet OpenDataSet(string strFilePath)
      {
          DataSet dsReturnValue = new DataSet();

          if (File.Exists(strFilePath))
          {
              dsReturnValue.ReadXml(strFilePath, XmlReadMode.ReadSchema);
              dsReturnValue.EnforceConstraints = true;
          }

          return dsReturnValue;
      }

       private void updateDataSetArray()
       {
           DataTable dtMyComicId = dsMyComics.Tables["MyComic"];
           int iz = 0;
           foreach (DataRow drAddThis in dtMyComicId.Rows)
           {
               aryComicCode[iz] = (string)drAddThis["ComicCode"];
               aryComicName[iz] = (string)drAddThis["ComicName"];
               aryDomain[iz] = (string)drAddThis["Domain"];
               aryDateFormat[iz] = (string)drAddThis["DateFormat"];
               arySundayExt[iz] = (string)drAddThis["SundayExt"];
               aryDailyExt[iz] = (string)drAddThis["DailyExt"];
               aryUrlFormat[iz] = (string)drAddThis["UrlFormat"];
               arySundayAvail[iz] = (bool)drAddThis["SundayAvail"];
               aryOneOfMyComics[iz] = true;
               //if (arySundayAvail[iz])
               //{
               //    aryDaysAvailable[iz] = 127;
               //}
               //else
               //{
               //    aryDaysAvailable[iz] = 63;
               //}
               if (drAddThis["DaysAvailable"] == System.DBNull.Value)
               {
                   if (arySundayAvail[iz])
                   {
                       aryDaysAvailable[iz] = 127;
                   }
                   else
                   {
                       aryDaysAvailable[iz] = 63;
                   }
               }
               else
               {
                   aryDaysAvailable[iz] = int.Parse(drAddThis["DaysAvailable"].ToString());
               }


               iz++;
           }

           DataTable dtComicId = dsComic.Tables["ComicId"];

           foreach (DataRow drAddThis in dtComicId.Rows)
           {
               if ((bool)drAddThis["OneOfMyComics"])
               {
                   aryComicCode[iz] = (string)drAddThis["ComicCode"];
                   aryComicName[iz] = (string)drAddThis["ComicName"];
                   aryDomain[iz] = (string)drAddThis["Domain"];
                   aryDateFormat[iz] = (string)drAddThis["DateFormat"];
                   arySundayExt[iz] = (string)drAddThis["SundayExt"];
                   aryDailyExt[iz] = (string)drAddThis["DailyExt"];
                   aryUrlFormat[iz] = (string)drAddThis["UrlFormat"];
                   arySundayAvail[iz] = (bool)drAddThis["SundayAvail"];
                   aryOneOfMyComics[iz] = (bool)drAddThis["OneOfMyComics"];
                   if (drAddThis["DaysAvailable"] == System.DBNull.Value)
                   {
                       if (arySundayAvail[iz])
                       {
                           aryDaysAvailable[iz] = 127;
                       }
                       else
                       {
                           aryDaysAvailable[iz] = 63;
                       }
                   }
                   else
                   {
                       aryDaysAvailable[iz] = int.Parse(drAddThis["DaysAvailable"].ToString());
                   }

                   iz++;
               }
           }
       }

       private void CreateMasterDataSet()
       {
           foreach (DataTable dtMyComic in dsMaster.Tables)
           {
               DataRow drMyComic;
               for (int ix = 0; ix < aryComicName.Length; ix++)
               {
                   if (aryComicCode[ix] != null)
                   {
                       drMyComic = dtMyComic.NewRow();

                       drMyComic["ComicName"] = aryComicName[ix];
                       drMyComic["Domain"] = aryDomain[ix];
                       drMyComic["ComicCode"] = aryComicCode[ix];
                       drMyComic["DateFormat"] = aryDateFormat[ix];
                       drMyComic["SundayExt"] = arySundayExt[ix];
                       drMyComic["DailyExt"] = aryDailyExt[ix];
                       drMyComic["UrlFormat"] = aryUrlFormat[ix];
                       drMyComic["SundayAvail"] = arySundayAvail[ix];
                       drMyComic["OneOfMyComics"] = aryOneOfMyComics[ix];
                       drMyComic["DaysAvailable"] = aryDaysAvailable[ix];
                       
                       dtMyComic.Rows.Add(drMyComic);
                   }
               }
           }
       }
     #endregion

       private void flpComics_MouseEnter(object sender, EventArgs e)
       {
           this.flpComics.Focus();
       }

       private void flpComics_MouseLeave(object sender, EventArgs e)
       {
           this.cboxComicList.Focus();
       }
  }
}