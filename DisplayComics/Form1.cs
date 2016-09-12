using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using Find_Comics;

namespace DisplayComics
{
    public partial class formControlPanel : Form
    {
        private string strDirectoryDisplayFrom = @"C:\Documents and Settings\wecksr\My Documents\comics";
        // private string strDirectoryMoveFrom = @"C:\Users\wecksr\Documents\Hold";
        //private string strDirectoryMoveFrom = @"P:\Hold";
        private string strDirectoryMoveFrom = @"C:\Users\wecksr\Documents\ComicStripImages";
        private string strDirectoryMoveTo = @"C:\Documents and Settings\wecksr\My Documents\comics";
        private string strDirectoryArchiveFrom = @"C:\Documents and Settings\wecksr\My Documents\comics";
        private string strDirectoryArchiveTo = @"C:\Documents and Settings\wecksr\My Documents\comics_archive";
        private DisplayComicSeries frmComicSeries = new DisplayComicSeries();
        private int intFile = 0;
        private string strPictureSitting = "First";
        private string filePath = "";
        private FileInfo[] aryFinfoMoveFrom;
        private DirectoryInfo dinfoArchiveFrom;
        private DirectoryInfo[] aryDinfoArchiveFrom;
        private DirectoryInfo[] aryDinfoMoveTo;
        private DirectoryInfo dinfoMoveTo;
        DayOfWeek[] dowDay = new DayOfWeek[7];
        private Comics ComicFmComics = new Comics();

        /**
         * variables specific to archiving
         * 
         **/
        //private FileInfo[] aryFinfoFilesToArchive;
        //private FileInfo[] aryFinfoFilesToKeep;
        private ArrayList aryListFinfoFilestoArchive;
        private ArrayList aryListFinfoFilestoKeep;
        private int intFilesToArchive = 0;
        private int intFilesToKeep = 0;

        public formControlPanel()
        {
            InitializeComponent();
            //OpenComicDS();
            //frmSeries.Visible = true;
            //frmPict.Visible = true;
            this.tbxComicPath.Text = strDirectoryDisplayFrom;
            this.tbxPathMoveFrom.Text = strDirectoryMoveFrom;
            this.tbxPathMoveTo.Text = strDirectoryMoveTo;
            this.pnlMoveRename.Visible = true;
            //this.Size = new Size(366, this.Height);
            //this.SetFlowDirection();
            dowDay[0] = DayOfWeek.Monday;
            dowDay[1] = DayOfWeek.Tuesday;
            dowDay[2] = DayOfWeek.Wednesday;
            dowDay[3] = DayOfWeek.Thursday;
            dowDay[4] = DayOfWeek.Friday;
            dowDay[5] = DayOfWeek.Saturday;
            dowDay[6] = DayOfWeek.Sunday;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectSeries_Click(object sender, EventArgs e)
        {
            //this.fbDiaDisplay.SelectedPath = strDirectoryDisplayFrom;
            //this.fbDiaDisplay.ShowDialog();
            //this.tbxComicPath.Text = this.fbDiaDisplay.SelectedPath;
            //this.strDirectoryDisplayFrom = this.fbDiaDisplay.SelectedPath;
            this.strDirectoryDisplayFrom = this.tbxComicPath.Text;
            DirectoryInfo dinfoMyD = new DirectoryInfo(this.strDirectoryDisplayFrom);

            DirectoryInfo[] dinfoDirList = dinfoMyD.GetDirectories();

            frmComicSeries.SetThisDisplay(dinfoDirList);
            this.frmComicSeries.Visible = true;
            this.frmComicSeries.SetThisCallingForm(this);

            intFile = 1;

        }

        private void Update_lbxArchiveComics_List()
        {
            this.strDirectoryArchiveFrom = this.tbxPathMoveFrom.Text;
            dinfoArchiveFrom = new DirectoryInfo(this.strDirectoryArchiveFrom);
            aryDinfoArchiveFrom = dinfoArchiveFrom.GetDirectories();

            this.lbxArchiveComics.Items.Clear();

            this.lbxArchiveComics.Items.AddRange(aryDinfoArchiveFrom);
            this.lbxArchiveComics.SelectedIndex = 0;
        }

        private void btnMoveGo_Click(object sender, EventArgs e)
        {
            if (radArchive.Checked)
            {
                ArchiveComics();
                //this.tsprogFolderCount.Maximum = this.lbxArchiveComics.Items.Count;
                //this.tsprogFolderCount.Minimum = 0;
                //this.tsprogFolderCount.Value = 0;
                //bool blnLoopOkay = true;
                //while (blnLoopOkay)
                //{
                //    this.tsprogFolderCount.Value++;

                //    string strArchiveFromFolder = ((DirectoryInfo)this.lbxArchiveComics.Items[lbxArchiveComics.SelectedIndex]).Name;
                //    string strArchiveToFolderPath = this.tbxPathMoveTo.Text + @"\" + strArchiveFromFolder;
                //    //MessageBox.Show("folder: " + strArchiveToFolderPath);
                //    // check to see if directory exists and if not then create it
                //    DirectoryInfo di = new DirectoryInfo(strArchiveToFolderPath);

                //    try
                //    {
                //        // Determine whether the directory exists.
                //        if (!di.Exists)
                //        {
                //            // Try to create the directory.
                //            di.Create();
                //            //MessageBox.Show("The directory was created successfully.");
                //        }


                //    }
                //    catch (Exception err)
                //    {
                //        MessageBox.Show("The process failed: {0}", err.ToString());
                //    }

                //    DialogResult myResult = DialogResult.Cancel;
                //    this.tsprogFileCount.Maximum = this.cmbxFilesToArchive.Items.Count;
                //    this.tsprogFileCount.Minimum = 0;
                //    this.tsprogFileCount.Value = 0;
                //    for (int iy = 0; iy < this.cmbxFilesToArchive.Items.Count; iy++)
                //    {
                //        FileInfo finfoFile = (FileInfo)this.cmbxFilesToArchive.Items[iy];
                //        this.tsprogFileCount.Value++;

                //        //Insert move command here
                //        try
                //        {
                //            string strPathToWriteTo = strArchiveToFolderPath + @"\" + finfoFile.Name;
                //            finfoFile.MoveTo(strPathToWriteTo);
                //        }
                //        catch (Exception ex)
                //        {
                //            MessageBox.Show("could not move: " + finfoFile.Name + "\nerror: " + ex.Message);
                //        }
                //        //end of insert

                //    }
                //    if (this.radMoveAll.Checked && blnLoopOkay)
                //    {
                //        if (this.lbxArchiveComics.SelectedIndex < (this.lbxArchiveComics.Items.Count - 1))
                //        {
                //            this.lbxArchiveComics.SelectedIndex++;
                //            this.updateComboBoxes();
                //            if (!this.chkbxScrollThrough.Checked)
                //            {
                //                blnLoopOkay = false;
                //            }
                //        }
                //        else
                //        {
                //            blnLoopOkay = false;
                //            this.btnMoveGo.Enabled = false;
                //        }
                //    }
                //    else
                //    {
                //        blnLoopOkay = false;
                //        this.btnMoveGo.Enabled = false;
                //    }
                //}
            }
            else
            {
                if (radNewComic.Checked)
                {
                    dinfoMoveTo = new DirectoryInfo(this.tbxPathMoveTo.Text);

                    aryDinfoMoveTo = dinfoMoveTo.GetDirectories();

                    this.lblCompleteCnt.Text = "";

                    this.strDirectoryMoveFrom = this.tbxPathMoveFrom.Text;
                    if (!Directory.Exists(strDirectoryMoveFrom))
                    {
                        this.fbDiaMoveFrom.SelectedPath = strDirectoryMoveFrom;
                        this.fbDiaMoveFrom.ShowDialog();
                        this.tbxPathMoveFrom.Text = this.fbDiaMoveFrom.SelectedPath;
                        this.strDirectoryMoveFrom = this.tbxPathMoveFrom.Text;
                    }
                    DirectoryInfo dinfoMoveFrom = new DirectoryInfo(this.tbxPathMoveFrom.Text);
                    aryFinfoMoveFrom = dinfoMoveFrom.GetFiles();

                    if (aryFinfoMoveFrom.Length >= 1)
                    {
                        this.lblFileCount.Text = "Total File Count: " + (aryFinfoMoveFrom.Length).ToString();
                    }
                    MoveRenameFile();
                }
            }
        }

        private void ArchiveComics()
        {
                this.tsprogFolderCount.Maximum = this.lbxArchiveComics.Items.Count;
                this.tsprogFolderCount.Minimum = 0;
                this.tsprogFolderCount.Value = 0;
                bool blnLoopOkay = true;
                while (blnLoopOkay)
                {
                    this.tsprogFolderCount.Value++;

                    string strArchiveFromFolder = ((DirectoryInfo)this.lbxArchiveComics.Items[lbxArchiveComics.SelectedIndex]).Name;
                    string strArchiveToFolderPath = this.tbxPathMoveTo.Text + @"\" + strArchiveFromFolder;
                    //MessageBox.Show("folder: " + strArchiveToFolderPath);
                    // check to see if directory exists and if not then create it
                    DirectoryInfo di = new DirectoryInfo(strArchiveToFolderPath);

                    try
                    {
                        // Determine whether the directory exists.
                        if (!di.Exists)
                        {
                            // Try to create the directory.
                            di.Create();
                            //MessageBox.Show("The directory was created successfully.");
                        }


                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("The process failed: {0}", err.ToString());
                    }

                    DialogResult myResult = DialogResult.Cancel;
                    this.tsprogFileCount.Maximum = this.cmbxFilesToArchive.Items.Count;
                    this.tsprogFileCount.Minimum = 0;
                    this.tsprogFileCount.Value = 0;
                    for (int iy = 0; iy < this.cmbxFilesToArchive.Items.Count; iy++)
                    {
                        FileInfo finfoFile = (FileInfo)this.cmbxFilesToArchive.Items[iy];
                        this.tsprogFileCount.Value++;

                        //Insert move command here
                        try
                        {
                            string strPathToWriteTo = strArchiveToFolderPath + @"\" + finfoFile.Name;
                            finfoFile.MoveTo(strPathToWriteTo);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("could not move: " + finfoFile.Name + "\nerror: " + ex.Message);
                        }
                        //end of insert

                    }
                    if (this.radMoveAll.Checked && blnLoopOkay)
                    {
                        if (this.lbxArchiveComics.SelectedIndex < (this.lbxArchiveComics.Items.Count - 1))
                        {
                            this.lbxArchiveComics.SelectedIndex++;
                            this.updateComboBoxes();
                            if (!this.chkbxScrollThrough.Checked)
                            {
                                blnLoopOkay = false;
                            }
                        }
                        else
                        {
                            blnLoopOkay = false;
                            this.btnMoveGo.Enabled = false;
                        }
                    }
                    else
                    {
                        blnLoopOkay = false;
                        this.btnMoveGo.Enabled = false;
                    }
                }
        }

        private void MoveRenameFile()
        {
            int intFileCnt = 0;
            lblCompleteCnt.Text = "Moved: " + intFileCnt.ToString();
            foreach (FileInfo finfoOldFile in aryFinfoMoveFrom)
            {
                //++intFileCnt;
                //lblCompleteCnt.Text = intFileCnt.ToString();
                //lblCompleteCnt.Show();
                if (finfoOldFile.Extension == ".jpg" || finfoOldFile.Extension == ".gif")
                {
                    string[] strNewNameAndFile = new string[2];
                    strNewNameAndFile = SetNewNameAndNewFile(finfoOldFile);
                    string strNewFolderAndName = strNewNameAndFile[1] + @"\" + strNewNameAndFile[0] + finfoOldFile.Extension;
                    string strNewPath = dinfoMoveTo.FullName + @"\" + strNewFolderAndName;
                    string strNewFolderPath = dinfoMoveTo.FullName + @"\" + strNewNameAndFile[1];
                    bool blnFolderExists = Directory.Exists(strNewFolderPath);
                    int intAttempts = 0;
                    while (!blnFolderExists && intAttempts < 2)
                    {
                        try
                        {
                            Directory.CreateDirectory(strNewFolderPath);
                        }
                        catch (UnauthorizedAccessException uaeEX)
                        {
                            MessageBox.Show("Error trying to create folder: " + strNewFolderPath + Environment.NewLine + uaeEX.GetType().ToString() + Environment.NewLine + uaeEX.Message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while creating folder: " + strNewFolderPath + Environment.NewLine + ex.GetType().ToString() + Environment.NewLine + ex.Message);
                        }
                        blnFolderExists = Directory.Exists(strNewFolderPath);
                        intAttempts++;
                    }
                    try
                    {
                        finfoOldFile.MoveTo(strNewPath);
                        ++intFileCnt;
                        lblCompleteCnt.Text = "Moved: " + intFileCnt.ToString();
                    }
                    catch (DirectoryNotFoundException dnfe)
                    {
                        string strErrorMessage = dnfe.Message;
                        //MessageBox.Show("DirectoryNotFoundException: " + dnfe.Message + Environment.NewLine + strNewPath);
                    }
                    catch (PathTooLongException ptle)
                    {
                        string strErrorMessage = ptle.Message;
                        //MessageBox.Show("PathTooLongException: " + ptle + Environment.NewLine + strNewPath);
                    }
                    catch (IOException ioe)
                    {
                        string strErrorMessage = ioe.Message;
                        //MessageBox.Show("IOException: " + ioe.Message + Environment.NewLine + strNewPath);
                    }
                    catch (Exception e)
                    {
                        string strErrorMessage = e.Message;
                        //MessageBox.Show("Exception: " + e.Message + Environment.NewLine + strNewPath);
                    }
                    //MessageBox.Show("full path: " + strNewPath);
                }
            }
            lblCompleteCnt.Show();
        }

        private string[] SetNewNameAndNewFile(FileInfo finfoFile)
        {
            string[] aryStringReturnValue = new string[2];
            string strFileName = finfoFile.Name;
            string strYear = "";
            string strMonth = "";
            string strDay = "";
            string strAlpha = "";
            string strNumeric = "";
            int intYear;
            int intMonth;
            int intDay;
            string strAlphaCharsToHold = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_-.";
            char[] aryAlphaCharToEliminate = strAlphaCharsToHold.ToCharArray();
            string strNumericCharsToHold = "0123456789.";
            char[] aryNumericCharToEliminate = strNumericCharsToHold.ToCharArray();
            DateTime dtmReturnValue = new DateTime();
            string strSubStr = "";
            if (strFileName.Contains(".zoom"))
            {
                strSubStr = SetupComics(strFileName);
                //MessageBox.Show("Found it");
            }
            else
            {
                if (strFileName.Contains("_large"))
                {
                    strSubStr = SetupComicsLarge(strFileName);
                }
                else
                {
                    int intBracketPos = strFileName.IndexOf("[");
                    if (intBracketPos < 0)
                    {
                        intBracketPos = strFileName.IndexOf('.');
                    }
                    strSubStr = strFileName.Substring(0, intBracketPos);
                }
            }

            if (strSubStr.Substring(0, 3) == "9_c")
            {
                strSubStr = strSubStr.Substring(2);
            }
            else if (strSubStr.Substring(0, 3) == "9ch")
            {
                strSubStr = strSubStr.Substring(1);
            }
            if (strSubStr.Substring(0,4)=="9to5")
            {
                strSubStr=strSubStr.Substring(3);
            }

            strAlpha = strSubStr.Trim(aryNumericCharToEliminate);
            strNumeric = strSubStr.Trim(aryAlphaCharToEliminate);

            switch (strNumeric.Length)
            {
                case 8:
                    strYear = strNumeric.Substring(0, 4);
                    intYear = Int32.Parse(strYear);
                    strMonth = strNumeric.Substring(4, 2);
                    intMonth = Int32.Parse(strMonth);
                    strDay = strNumeric.Substring(6, 2);
                    intDay = Int32.Parse(strDay);
                    //DateTime dtmThisDate = new DateTime;
                    dtmReturnValue = new DateTime(intYear, intMonth, intDay);
                    //dtmThisDate.
                    //strReturnValue = "20"+strNumeric;
                    break;
                case 6:
                    strYear = "20" + strNumeric.Substring(0, 2);
                    intYear = Int32.Parse(strYear);
                    strMonth = strNumeric.Substring(2, 2);
                    intMonth = Int32.Parse(strMonth);
                    strDay = strNumeric.Substring(4, 2);
                    intDay = Int32.Parse(strDay);
                    //DateTime dtmThisDate = new DateTime;
                    dtmReturnValue = new DateTime(intYear, intMonth, intDay);
                    //dtmThisDate.
                    //strReturnValue = "20"+strNumeric;
                    break;
                case 4:
                    if (strAlpha == "")
                    {
                        strAlpha = "KevinKell";
                    }
                    strYear = "2008";
                    intYear = Int32.Parse(strYear);
                    strMonth = strNumeric.Substring(0, 2);
                    intMonth = Int32.Parse(strMonth);
                    strDay = strNumeric.Substring(2, 2);
                    intDay = Int32.Parse(strDay);
                    //DateTime dtmThisDate = new DateTime;
                    dtmReturnValue = new DateTime(intYear, intMonth, intDay);
                    //dtmThisDate.
                    //strReturnValue = "20"+strNumeric;
                    break;
                case 0:
                    dtmReturnValue = new DateTime();
                    break;
                default:
                    dtmReturnValue = PullOutDate(strNumeric);
                    break;
            }
            string strNewAlpha = "";
            string strNewFolder = "Misc";
            string strHoldAlpha = strAlpha;
            if (strAlpha.Length >= 15)
            {
                strHoldAlpha = strAlpha.Substring(0, 15);
            }

            switch (strHoldAlpha)
            {
                case "chickweedlane":
                case "chickweed":
                case "chickweed_lane":
                case "9_chickweed_lane":
                    strNewAlpha = "chickweed";
                    strNewFolder = "9 Chickweed";
                    break;
                case "tmntf":
                case "9to5":
                case "ninetofive":
                    strNewAlpha = "ninetofive";
                    strNewFolder = "9 to 5";
                    break;
                case "ad":
                case "adamathome":
                case "adam":
                    strNewAlpha = "adam";
                    strNewFolder = "Adam at Home";
                    break;
                case "cragn":
                case "agnes":
                    strNewAlpha = "agnes";
                    strNewFolder = "Agnes";
                    break;
                case "tas":
                case "argylesweater":
                case "theargylesweate":
                    strNewAlpha = "argylesweater";
                    strNewFolder = "Argyle Sweater";
                    break;
                case "arloandjanis":
                case "arlonjanis":
                case "arlo&janis":
                case "arlo_janis":
                    strNewAlpha = "arlonjanis";
                    strNewFolder = "Arlo and Janis";
                    break;
                case "Baby_Blues":
                case "babyblues":
                    strNewAlpha = "BabyBlues";
                    strNewFolder = "Baby Blues";
                    break;
                case "ba":
                case "baldo":
                    strNewAlpha = "baldo";
                    strNewFolder = "Baldo";
                    break;
                case "barneyandclyde":
                    strNewAlpha = "barneyandclyde";
                    strNewFolder = "Barney and Clyde";
                    break;
                case "bc":
                case "BC":
                    strNewAlpha = "BC";
                    strNewFolder = "BC";
                    break;
                case "Beetle_Bailey":
                case "Beetle_Bailey_":
                case "beetlebailey":
                    strNewAlpha = "BeetleBailey";
                    strNewFolder = "Beetle Bailey";
                    break;
                case "ben":
                    strNewAlpha = "ben";
                    strNewFolder = "Ben";
                    break;
                case "bewley":
                    strNewAlpha = "bewley";
                    strNewFolder = "Bewley";
                    break;
                case "Bizarro":
                case "bizarro":
                    strNewAlpha = "bizarro";
                    strNewFolder = "Bizarro";
                    break;
                case "bl":
                case "bleachers":
                case "inthebleachers":
                    strNewAlpha = "bleachers";
                    strNewFolder = "In the Bleachers";
                    break;
                case "bliss":
                    strNewAlpha = "bliss";
                    strNewFolder = "Bliss";
                    break;
                case "blondie":
                case "Blondie_":
                case "Blondie":
                    strNewAlpha = "blondie";
                    strNewFolder = "Blondie";
                    break;
                case "boomerangs":
                    strNewAlpha = "boomerangs";
                    strNewFolder = "Boomerangs";
                    break;
                case "tmbot":
                case "bottomliners":
                    strNewAlpha = "bottomliners";
                    strNewFolder = "Bottom Liners";
                    break;
                case "tmbou":
                case "boundandgagged":
                case "boundgagged":
                    strNewAlpha = "boundgagged";
                    strNewFolder = "Bound and Gagged";
                    break;
                case "Brewster":
                case "brewster-rocket":
                case "brewsterrockets":
                case "brewsterrockit":
                case "tmrkt":
                case "BrewsterRocket":
                    strNewAlpha = "BrewsterRocket";
                    strNewFolder = "Brewster Rocket";
                    break;
                case "tmbro":
                case "broomhilda":
                    strNewAlpha = "broomhilda";
                    strNewFolder = "Broom Hilda";
                    break;
                case "cafeconleche":
                    strNewAlpha = "cafe";
                    strNewFolder = "cafe' con leche";
                    break;
                case "ch":
                case "calvinandhobbes":
                case "CalvinHobbes":
                    strNewAlpha = "CalvinHobbes";
                    strNewFolder = "Calvin and Hobbes";
                    break;
                case "ca":
                case "cathy":
                    strNewAlpha = "cathy";
                    strNewFolder = "Cathy";
                    break;
                case "chucklebros":
                    strNewAlpha = "chucklebros";
                    strNewFolder = "Chuckle Bros";
                    break;
                case "cbw":
                    strNewAlpha = "clearbluewater";
                    strNewFolder = "Clear Blue Water";
                    break;
                case "cl":
                case "closetohome":
                    strNewAlpha = "closetohome";
                    strNewFolder = "Close To Home";
                    break;
                case "co":
                case "cornered":
                    strNewAlpha = "cornered";
                    strNewFolder = "Cornered";
                    break;
                case "tmcom":
                case "compu-toon":
                case "computoon":
                    strNewAlpha = "computoon";
                    strNewFolder = "Compu-toon";
                    break;
                case "Crock":
                case "Crock_":
                    strNewAlpha = "crock";
                    strNewFolder = "Crock";
                    break;
                case "dilbert":
                    strNewAlpha = "dilbert";
                    strNewFolder = "Dilbert";
                    break;
                case "db":
                case "doonesbury":
                    strNewAlpha = "doonesbury";
                    strNewFolder = "Doonesbury";
                    break;
                case "drabble":
                    strNewAlpha = "drabble";
                    strNewFolder = "Drabble";
                    break;
                case "dp":
                case "duplex":
                    strNewAlpha = "duplex";
                    strNewFolder = "Duplex";
                    break;
                case "Dustin":
                case "dustin":
                    strNewAlpha = "dustin";
                    strNewFolder = "Dustin";
                    break;
                case "Edison":
                case "edisonlee":
                case "brilliantmindof":
                case "brilliantmindofedisonlee":
                    strNewAlpha = "Edison";
                    strNewFolder = "Edison Lee";
                    break;
                case "farcus":
                case "far":
                    strNewAlpha = "farcus";
                    strNewFolder = "Farcus";
                    break;
                case "fb":
                case "forbetter":
                case "forbetterorforw":
                    strNewAlpha = "forbetter";
                    strNewFolder = "For Better or for Worse";
                    break;
                case "foxtrot":
                case "foxtrotclassics":
                    strNewAlpha = "foxtrot";
                    strNewFolder = "Fox Trot";
                    break;
                case "frazz":
                    strNewAlpha = "frazz";
                    strNewFolder = "Frazz";
                    break;
                case "ga":
                case "garfield":
                    strNewAlpha = "garfield";
                    strNewFolder = "Garfield";
                    break;
                case "getfuzzy":
                case "get_fuzzy":
                    strNewAlpha = "getfuzzy";
                    strNewFolder = "Get Fuzzy";
                    break;
                case "girls":
                case "girlsandsports":
                case "crgis":
                case "girls_sports":
                    strNewAlpha = "girls";
                    strNewFolder = "Girls and Sports";
                    break;
                case "grandave":
                case "grandavenue":
                case "grand_avenue":
                case "grand-avenue":
                    strNewAlpha = "grandave";
                    strNewFolder = "Grand Avenue";
                    break;
                case "Hagar_The_Horrible":
                case "hagarthehorrible":
                case "hagarthehorribl":
                case "Hagar_The_Horri":
                    strNewAlpha = "Hagar_The_Horrible";
                    strNewFolder = "Hagar The Horrible";
                    break;
                case "hc":
                case "heartofcity":
                case "heartofthecity":
                    strNewAlpha = "heartofcity";
                    strNewFolder = "Heart of the City";
                    break;
                case "cshec-a-p":
                case "cshec":
                case "cshecap":
                    strNewAlpha = "hector";
                    strNewFolder = "Hector";
                    break;
                case "herman":
                    strNewAlpha = "herman";
                    strNewFolder = "Herman";
                    break;
                case "tmhou":
                case "cshsb-a-p":
                case "cshsb-s-p":
                    strNewAlpha = "housebroken";
                    strNewFolder = "Housebroken";
                    break;
                case "ink":
                case "inkpen":
                    strNewAlpha = "inkpen";
                    strNewFolder = "Ink Pen";
                    break;
                case "itsallaboutyou":
                    strNewAlpha = "itsallaboutyou";
                    strNewFolder = "It's All About You";
                    break;
                case "jam":
                    strNewAlpha = "monkey";
                    strNewFolder = "Joe and Monkey";
                    break;
                case "KevinKell":
                case "kk":
                    strNewAlpha = "KevinKell";
                    strNewFolder = "Kevin and Kell";
                    break;
                case "tmkud":
                    strNewAlpha = "kudzu";
                    strNewFolder = "Kudzu";
                    break;
                case "lastkiss":
                    strNewAlpha = "lastkiss";
                    strNewFolder = "Last Kiss";
                    break;
                case "crlib":
                case "liberty_meadows":
                case "libertymeadows":
                case "liberty-meadows":
                    strNewAlpha = "libertymeadows";
                    strNewFolder = "Liberty Meadows";
                    break;
                case "luann":
                    strNewAlpha = "luann";
                    strNewFolder = "Luann";
                    break;
                case "main":
                    strNewAlpha = "maintaining";
                    strNewFolder = "Maintaining";
                    break;
                case "monty":
                    strNewAlpha = "monty";
                    strNewFolder = "Monty";
                    break;
                case "Mgoose":
                case "mothergoose":
                case "MGG":
                case "mothergooseandg":
                case "mothergooseandgrimm":
                    strNewAlpha = "mgoose";
                    strNewFolder = "Mother Goose and Grim";
                    break;
                case "nq":
                case "nonsequitur":
                    strNewAlpha = "nonsequitur";
                    strNewFolder = "Non Sequitur";
                    break;
                case "offthemark":
                case "off_the_mark":
                    strNewAlpha = "offthemark";
                    strNewFolder = "Off the Mark";
                    break;
                case "On_the_Fastrack":
                case "OnTheFastrack":
                case "onthefastrack":
                    strNewAlpha = "OnTheFastrack";
                    strNewFolder = "On The Fastrack";
                    break;
                case "ob":
                case "overboard":
                    strNewAlpha = "overboard";
                    strNewFolder = "Overboard";
                    break;
                case "hedge":
                case "overthehedge":
                case "over_the_hedge":
                case "overhedge":
                    strNewAlpha = "overhedge";
                    strNewFolder = "Over the Hedge";
                    break;
                case "Pardon_My_Plane":
                case "Pardon_My_Planet":
                    strNewAlpha = "Planet";
                    strNewFolder = "Pardon My Planet";
                    break;
                case "peanuts":
                case "pe":
                    strNewAlpha = "peanuts";
                    strNewFolder = "Peanuts";
                    break;
                case "pearls":
                case "pearlsbeforeswine":
                case "pearlsbeforeswi":
                case "pearls_before_s":
                case "pearls_before_swine":
                    strNewAlpha = "pearls";
                    strNewFolder = "Pearls Before Swine";
                    break;
                case "pibgorn":
                    strNewAlpha = "pibgorn";
                    strNewFolder = "Pibgorn";
                    break;
                case "pickles":
                case "wppic":
                    strNewAlpha = "pickles";
                    strNewFolder = "Pickles";
                    break;
                case "preteena":
                    strNewAlpha = "preteena";
                    strNewFolder = "PreTeena";
                    break;
                case "prc":
                case "pricklycity":
                case "prickly_city":
                    strNewAlpha = "prickly";
                    strNewFolder = "Prickly City";
                    break;
                case "rabbitsagainstmagic":
                case "rabbitsagainstm":
                    strNewAlpha = "rabbits";
                    strNewFolder = "Rabbits Against Magic";
                    break;
                case "replyall":
                    strNewAlpha = "replyall";
                    strNewFolder = "Reply All";
                    break;
                case "Retail":
                case "retail":
                    strNewAlpha = "Retail";
                    strNewFolder = "Retail";
                    break;
                case "roseisrose":
                case "rose_is_rose":
                    strNewAlpha = "roseisrose";
                    strNewFolder = "Rose is Rose";
                    break;
                case "rubes":
                    strNewAlpha = "rubes";
                    strNewFolder = "Rubes";
                    break;
                case "Safe_Havens":
                case "safehavenscomic":
                case "SafeHavens":
                    strNewAlpha = "SafeHavens";
                    strNewFolder = "Safe Havens";
                    break;
                case "Sally_Forth":
                    strNewAlpha = "SallyForth";
                    strNewFolder = "Sally Forth";
                    break;
                case "SL":
                case "sl":
                case "Shermans_Lagoon":
                    strNewAlpha = "shermanslagoon";
                    strNewFolder = @"Shermans Lagoon";
                    break;
                case "shirleynson":
                case "shirley_and_son_classics":
                case "shirley_and_son":
                    strNewAlpha = "shirleynson";
                    strNewFolder = "Shirleynson";
                    break;
                case "tmsho":
                case "shoe":
                    strNewAlpha = "shoe";
                    strNewFolder = "Shoe";
                    break;
                case "crspe":
                case "speedbump":
                case "speed_bump":
                    strNewAlpha = "speedbump";
                    strNewFolder = "Speed Bump";
                    break;
                case "ss":
                case "stonesoup":
                    strNewAlpha = "stonesoup";
                    strNewFolder = "Stone Soup";
                    break;
                case "strange-brew":
                case "strangebrew":
                case "strange":
                    strNewAlpha = "strange";
                    strNewFolder = "Strange Brew";
                    break;
                case "thebigpicture":
                    strNewAlpha = "thebigpicture";
                    strNewFolder = "The Big Picture";
                    break;
                case "eld":
                case "theelderberries":
                    strNewAlpha = "theelderberries";
                    strNewFolder = "The Elderberries";
                    break;
                case "theflyingmccoys":
                    strNewAlpha = "theflyingmccoys";
                    strNewFolder = "The Flying McCoys";
                    break;
                case "the_grizzwells":
                case "thegrizzwells":
                case "grizzwells":
                    strNewAlpha = "grizzwells";
                    strNewFolder = "The Grizzwells";
                    break;
                case "lila":
                case "crlil":
                case "the_meaning_of_lila":
                case "the_meaning_of_":
                case "meaning-of-lila":
                case "meaningoflila":
                    strNewAlpha = "lila";
                    strNewFolder = "The Meaning of Lila";
                    break;
                case "cpthk":
                    strNewAlpha = "thickandthin";
                    strNewFolder = "Through Thick and Thin";
                    break;
                case "Tinas_Groove":
                case "tinasgroove":
                case "TinasGroove":
                    strNewAlpha = "TinasGroove";
                    strNewFolder = "Tinas Groove";
                    break;
                case "crwiz":
                case "wizardofid":
                case "wizard_of_id":
                    strNewAlpha = "wizardofid";
                    strNewFolder = "Wizard of Id";
                    break;
                case "workingdaze":
                case "working_daze":
                case "working-daze":
                    strNewAlpha = "workingdaze";
                    strNewFolder = "Working Daze";
                    break;
                case "workingitout":
                case "crwio":
                case "working_it_out":
                case "working-it-out":
                    strNewAlpha = "workingitout";
                    strNewFolder = "Working it out";
                    break;
                case "yen":
                case "yenny":
                    strNewAlpha = "yenny";
                    strNewFolder = "Yenny";
                    break;
                case "crzhi":
                case "zack":
                case "zackhill":
                case "zack_hill":
                    strNewAlpha = "zackhill";
                    strNewFolder = "Zack Hill";
                    break;
                case "zi":
                case "ziggy":
                    strNewAlpha = "ziggy";
                    strNewFolder = "Ziggy";
                    break;
                case "Zits":
                case "zits":
                    strNewAlpha = "Zits";
                    strNewFolder = "Zits";
                    break;
                // alphbetized to this point
                default:
                    strNewAlpha = strAlpha;
                    strNewFolder = "Misc";
                    break;
            }
            aryStringReturnValue[0] = strNewAlpha + dtmReturnValue.Date.ToString("yyyyMMdd", null);
            aryStringReturnValue[1] = strNewFolder;
            return aryStringReturnValue;

        }

        private string SetupComics(string strSubStr)
        {
            string returnValue = strSubStr;

            int intZoomPos = strSubStr.IndexOf('.');
            string strComicId = strSubStr.Substring(0, intZoomPos);
            int intComicId = int.Parse(strComicId);
            string strComicCode = ComicFmComics.GetComicCode(intComicId);
            DateTime dtComicDate = ComicFmComics.GetComicDate(intComicId);
            //dtmReturnValue.Date.ToString("yyyyMMdd", null);
            returnValue = strComicCode + dtComicDate.Date.ToString("yyyyMMdd", null);
            return returnValue;
        }

        private string SetupComicsLarge(string strSubStr)
        {
            string returnValue = strSubStr;

            int intComicDatePos = strSubStr.IndexOf('.');
            string strComicCode = strSubStr.Substring(0, intComicDatePos);
            int intLargePos = strSubStr.IndexOf("_", intComicDatePos);
            string strComicDate = strSubStr.Substring(intComicDatePos + 1, (intLargePos - intComicDatePos - 1));
            //DateTime dtComicDate = ComicFmComics.GetComicDate(intComicId);
            //dtmReturnValue.Date.ToString("yyyyMMdd", null);
            returnValue = strComicCode + strComicDate;
            return returnValue;
        }

        private DateTime PullOutDate(string strNumeric)
        {

            //string strReturnValue=strNumeric;
            DateTime dtmToday = DateTime.Today;
            int curYear = dtmToday.Year;
            DateTime dtmReturnValue = new DateTime();
            string[] strDates = new string[7];
            bool[] aryBlnValidDates = new bool[7];
            for (int ix = 0; ix < strDates.Length; ix++)
            {
                strDates[ix] = strNumeric.Substring(0, ix + 1) + strNumeric.Substring(strNumeric.Length - (7 - ix));
            }
            string strMessage = "Numeric string: " + strNumeric;
            for (int ix = 0; ix < strDates.Length; ix++)
            {
                string strYear = strDates[ix].Substring(0, 4);
                string strMonth = strDates[ix].Substring(4, 2);
                string strDay = strDates[ix].Substring(6, 2);

                int intYear = Int32.Parse(strYear);
                int intMonth = Int32.Parse(strMonth);
                int intDay = Int32.Parse(strDay);

                aryBlnValidDates[ix] = true;

                strMessage += Environment.NewLine + ix + "] " + strDates[ix];

                //if ((intYear <= 2005 || intYear >= 2030) && aryBlnValidDates[ix])
                if ((intYear < (curYear - 1) || intYear > curYear) && aryBlnValidDates[ix])
                {
                    aryBlnValidDates[ix] = false;
                    strMessage += " year failed: " + strYear;
                }
                if (aryBlnValidDates[ix])
                {
                    try
                    {
                        DateTime dtmDate = new DateTime(intYear, intMonth, intDay);
                        strMessage += "VALID Date: " + dtmDate.DayOfWeek.ToString();

                        TimeSpan tsDiff = dtmToday.Subtract(dtmDate);

                        if (tsDiff.Days > 60 || tsDiff.Days < 0)
                        {
                            aryBlnValidDates[ix] = false;
                            strMessage += " date failed: " + strYear;
                        }

                    }
                    catch (Exception e)
                    {
                        string eMessage = e.Message;
                        aryBlnValidDates[ix] = false;
                    }
                }

                if (aryBlnValidDates[ix])
                {
                    try
                    {
                        DateTime dtmDate = new DateTime(intYear, intMonth, intDay);
                        if (dtmDate.DayOfWeek == this.dowDay[ix])
                        {
                            strMessage += "** found it **";
                            dtmReturnValue = dtmDate;
                        }
                        else
                        {
                            strMessage += "valid Date, but wrong day";
                            aryBlnValidDates[ix] = false;

                        }
                    }
                    catch (Exception e)
                    {
                        string eMessage = e.Message;
                        aryBlnValidDates[ix] = false;
                        //strMessage += "invalid date: "+ix+" error message: " + e.Message;
                    }
                }

            }
            //MessageBox.Show(strMessage);
            return dtmReturnValue;
        }

        private void tbxComicPath_MouseClick(object sender, MouseEventArgs e)
        {
            this.fbDiaDisplay.SelectedPath = this.tbxComicPath.Text;
            this.fbDiaDisplay.ShowDialog();
            this.tbxComicPath.Text = this.fbDiaDisplay.SelectedPath;

        }

        private void tbxPathMoveFrom_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.radNewComic.Checked)
            {
                this.fbDiaMoveFrom.SelectedPath = this.strDirectoryMoveFrom;
                this.fbDiaMoveFrom.ShowDialog();
                this.strDirectoryMoveFrom = this.fbDiaMoveFrom.SelectedPath;
                this.tbxPathMoveFrom.Text = this.strDirectoryMoveFrom;
                //tabControl1_SelectedIndexChanged(sender, e);
            }
            else
            {
                this.fbDiaMoveFrom.SelectedPath = strDirectoryArchiveFrom;
                this.fbDiaMoveFrom.ShowDialog();
                this.strDirectoryArchiveFrom = this.fbDiaMoveFrom.SelectedPath;
                this.tbxPathMoveFrom.Text = this.strDirectoryArchiveFrom;
            }
        }

        private void tbxPathMoveTo_MouseClick(object sender, MouseEventArgs e)
        {
            if (radNewComic.Checked)
            {
                this.fbDiaMoveTo.SelectedPath = this.strDirectoryMoveTo;
                this.fbDiaMoveTo.ShowDialog();

                this.strDirectoryMoveTo = this.fbDiaMoveTo.SelectedPath;
                this.tbxPathMoveTo.Text = this.strDirectoryMoveTo;
            }
            else
            {
                this.fbDiaMoveTo.SelectedPath = this.strDirectoryArchiveTo;
                this.fbDiaMoveTo.ShowDialog();

                this.strDirectoryArchiveTo = this.fbDiaMoveTo.SelectedPath;
                this.tbxPathMoveTo.Text = this.strDirectoryArchiveTo;

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strdmy = tabControl1.SelectedTab.Name;
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabSelectSeries":
                    //this.pnlDisplayComics.Visible = true;
                    //this.pnlMoveRename.Visible = true;
                    break;
                case "tabMoveRename":
                    //this.pnlDisplayComics.Visible = false;
                    //this.pnlMoveRename.Visible = true;
                    this.lblCompleteCnt.Text = "";

                    this.strDirectoryMoveFrom = this.tbxPathMoveFrom.Text;
                    if (!Directory.Exists(strDirectoryMoveFrom))
                    {
                        this.fbDiaMoveFrom.SelectedPath = strDirectoryMoveFrom;
                        this.fbDiaMoveFrom.ShowDialog();
                        this.tbxPathMoveFrom.Text = this.fbDiaMoveFrom.SelectedPath;
                        this.strDirectoryMoveFrom = this.tbxPathMoveFrom.Text;
                    }
                    DirectoryInfo dinfoMoveFrom = new DirectoryInfo(this.tbxPathMoveFrom.Text);
                    aryFinfoMoveFrom = dinfoMoveFrom.GetFiles();

                    if (aryFinfoMoveFrom.Length >= 1)
                    {
                        this.lblFileCount.Text = "Total File Count: " + (aryFinfoMoveFrom.Length).ToString();
                    }

                    break;
                default:
                    break;
            }
        }

        private void formControlPanel_MouseEnter(object sender, EventArgs e)
        {
            this.lblCompleteCnt.Text = "Moved: ";
            this.lblFileCount.Visible = true;
            this.lblCompleteCnt.Visible = true;
            this.lblDirectoryCnt.Visible = true;
            //this.strDirectoryMoveFrom = this.tbxPathMoveFrom.Text;
            if (!Directory.Exists(strDirectoryMoveFrom))
            {
                this.fbDiaMoveFrom.SelectedPath = strDirectoryMoveFrom;
                this.fbDiaMoveFrom.ShowDialog();
                this.tbxPathMoveFrom.Text = this.fbDiaMoveFrom.SelectedPath;
                this.strDirectoryMoveFrom = this.tbxPathMoveFrom.Text;
            }
            DirectoryInfo dinfoMoveFrom = new DirectoryInfo(this.tbxPathMoveFrom.Text);
            aryFinfoMoveFrom = dinfoMoveFrom.GetFiles();
            aryDinfoArchiveFrom = dinfoMoveFrom.GetDirectories();

            if (aryFinfoMoveFrom.Length >= 1)
            {
                this.lblFileCount.Text = "Total File Count: " + (aryFinfoMoveFrom.Length).ToString();
                this.lblDirectoryCnt.Text = "Total Directories: " + (aryDinfoArchiveFrom.Length).ToString();
            }
            else
            {
                this.lblFileCount.Text = "Total Files: 0";
                this.lblDirectoryCnt.Text = "Total Directories: " + (aryDinfoArchiveFrom.Length).ToString();
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("sender: " + sender.ToString() + "\ne: " + e.ToString());
            if (this.radArchive.Checked)
            {
                this.pnlArchiveDate.Visible = true;

                this.lblFrom.Text = "Archive From:";
                this.tbxPathMoveFrom.Text = this.strDirectoryArchiveFrom;

                this.lblTo.Text = "Archive To:";
                this.tbxPathMoveTo.Text = this.strDirectoryArchiveTo;

                this.Update_lbxArchiveComics_List();

                this.btnMoveGo.Text = "Archive";
                this.btnMoveGo.Enabled = false;
                if (this.radMoveAll.Checked)
                {
                    this.chkbxScrollThrough.Visible = true;
                }

                intFile = 1;
            }
            else
            {
                this.pnlArchiveDate.Visible = false;

                this.lblFrom.Text = "Move From:";
                this.tbxPathMoveFrom.Text = this.strDirectoryMoveFrom;

                this.lblTo.Text = "Move To:";
                this.tbxPathMoveTo.Text = this.strDirectoryMoveTo;
                this.btnMoveGo.Text = "Move 'em";
                this.btnMoveGo.Enabled = true;
                this.chkbxScrollThrough.Visible = false;
            }
        }

        private void tbxPathMoveFrom_TextChanged(object sender, EventArgs e)
        {
            if (this.radArchive.Checked)
            {
                this.Update_lbxArchiveComics_List();
            }
        }

        private void btnSelectArchive_Click(object sender, EventArgs e)
        {
            if (DateTime.Equals(DateTime.Today.Date, this.dtpArchiveDate.Value.Date))
            {
                MessageBox.Show("You need to change the date, or everything will be archived");
            }
            else
            {
                this.updateComboBoxes();
                this.btnMoveGo.Enabled = true;
            }
        }

        private void getComicList()
        {
            DateTime dtArchiveDate = this.dtpArchiveDate.Value.Date;
            this.intFilesToKeep = 0;
            this.lblKeepCnt.Text = "(" + this.intFilesToKeep.ToString() + ")";
            this.intFilesToArchive = 0;
            this.lblArchiveCnt.Text = "(" + this.intFilesToArchive.ToString() + ")";

            int intSelected = this.lbxArchiveComics.SelectedIndex;
            DirectoryInfo dinfoFolderArchiveFrom = new DirectoryInfo(aryDinfoArchiveFrom[intSelected].FullName);
            FileInfo[] aryComicList = dinfoFolderArchiveFrom.GetFiles();

            this.tsprogFileCount.Maximum = aryComicList.Length + 1;
            this.tsprogFileCount.Value = 0;
            this.tsprogFileCount.PerformStep();
            //MessageBox.Show("progress value: " + this.tsprogProgress.Value.ToString() + " count: " + this.tsprogProgress.Maximum.ToString());

            this.aryListFinfoFilestoArchive = new ArrayList();
            //this.aryFinfoFilesToArchive.Initialize();
            this.aryListFinfoFilestoKeep = new ArrayList();

            foreach (FileInfo finfoFileName in aryComicList)
            {
                //aryFinfoFilesToArchive[tsprogProgress.Value - 1] = finfoFileName;

                if (finfoFileName.Extension == ".gif" || finfoFileName.Extension == ".jpg")
                {
                    this.tsprogFileCount.PerformStep();

                    string comicName = finfoFileName.Name;
                    int intExtention = comicName.LastIndexOf('.');
                    //string strDate = comicName.Substring(intExtention - 8, 8);
                    comicName = comicName.Substring(0, intExtention);
                    int intCopyNbr = comicName.LastIndexOf('[');
                    if (intCopyNbr >= 0)
                    {
                        comicName = comicName.Substring(0, intCopyNbr);
                    }
                    string strDate = comicName.Substring(comicName.Length - 8);
                    bool blnArchiveThis = true;
                    DateTime dtComicDate = new DateTime();
                    try
                    {
                        int intYear = Int32.Parse(strDate.Substring(0, 4));
                        int intMonth = Int32.Parse(strDate.Substring(4, 2));
                        int intDay = Int32.Parse(strDate.Substring(6, 2));
                        dtComicDate = new DateTime(intYear, intMonth, intDay);
                    }
                    catch (Exception)
                    {

                        blnArchiveThis = false;
                    }
                    if (blnArchiveThis && DateTime.Compare(dtComicDate, dtArchiveDate) < 0)
                    {
                        this.intFilesToArchive++;
                        //this.aryFinfoFilesToArchive.Add(finfoFileName);
                        this.aryListFinfoFilestoArchive.Add(finfoFileName);
                        //this.cmbxFilesToArchive.Items.Add(finfoFileName);
                        //this.lblArchiveCnt.Text = "(" + this.intFilesToArchive.ToString() + ")";
                    }
                    else
                    {
                        this.intFilesToKeep++;
                        this.aryListFinfoFilestoKeep.Add(finfoFileName);
                        //aryFinfoFilesToKeep.Add(finfoFileName);
                        //this.cmbxFilesWeKeep.Items.Add(finfoFileName);
                        //this.lblKeepCnt.Text = "(" + this.intFilesToKeep.ToString() + ")";
                    }
                    //MessageBoxButtons mbxButton = MessageBoxButtons.OKCancel;
                    //DialogResult result = MessageBox.Show("Comic: " + comicName+" date: "+strDate, "", mbxButton);
                    //if (result != DialogResult.OK)
                    //{
                    //   break;
                    //}
                }
            }
            if (this.cmbxFilesToArchive.Items.Count > 0)
            {
                this.cmbxFilesToArchive.SelectedIndex = 0;
            }

            if (this.cmbxFilesWeKeep.Items.Count > 0)
            {
                this.cmbxFilesWeKeep.SelectedIndex = 0;

            }

            //return aryFinfoFilesToArchive;
        }

        private void radMoveAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radMoveAll.Checked)
            {
                this.chkbxScrollThrough.Visible = true;
            }
            else
            {
                this.chkbxScrollThrough.Visible = false;
            }
        }

        private void updateComboBoxes()
        {
            this.cmbxFilesToArchive.Items.Clear();
            this.cmbxFilesWeKeep.Items.Clear();
            this.intFilesToKeep = 0;
            this.intFilesToArchive = 0;

            this.getComicList();
            FileInfo[] aryForCmbxArchive = new FileInfo[this.aryListFinfoFilestoArchive.Count];
            this.aryListFinfoFilestoArchive.CopyTo(aryForCmbxArchive);
            this.cmbxFilesToArchive.Items.AddRange(aryForCmbxArchive);
            if (cmbxFilesToArchive.Items.Count > 0)
            {
                this.cmbxFilesToArchive.SelectedIndex = 0;
            }
            this.lblArchiveCnt.Text = "(" + this.intFilesToArchive.ToString() + ")";

            FileInfo[] aryForCmbxKeep = new FileInfo[this.aryListFinfoFilestoKeep.Count];
            this.aryListFinfoFilestoKeep.CopyTo(aryForCmbxKeep);
            this.cmbxFilesWeKeep.Items.AddRange(aryForCmbxKeep);
            if (cmbxFilesWeKeep.Items.Count > 0)
            {
                this.cmbxFilesWeKeep.SelectedIndex = 0;
            }
            this.lblKeepCnt.Text = "(" + this.intFilesToKeep.ToString() + ")";
        }
    }
  }