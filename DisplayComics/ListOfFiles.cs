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

namespace DisplayComics
{
    public class ListOfFiles
    {
        private FileInfo[] aryFileList;
        private DateTime[] aryDateTime;
        DayOfWeek[] dowDay = new DayOfWeek[7];
        char[] aryAlphaCharToEliminate;
        char[] aryNumericCharToEliminate;
        
        public ListOfFiles(string strFolderPath, bool blnSortList)
        {
            dowDay[0] = DayOfWeek.Monday;
            dowDay[1] = DayOfWeek.Tuesday;
            dowDay[2] = DayOfWeek.Wednesday;
            dowDay[3] = DayOfWeek.Thursday;
            dowDay[4] = DayOfWeek.Friday;
            dowDay[5] = DayOfWeek.Saturday;
            dowDay[6] = DayOfWeek.Sunday;

            string strAlphaCharsToHold = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_";
            this.aryAlphaCharToEliminate = strAlphaCharsToHold.ToCharArray();
            string strNumericCharsToHold = "0123456789";
            this.aryNumericCharToEliminate = strNumericCharsToHold.ToCharArray();

            this.aryFileList = BuildFiFileArray(strFolderPath);
        }

        private FileInfo[] BuildFiFileArray(string directoryPath)
        {
            FileInfo[] aryReturnFileInfo;
            DirectoryInfo di = new DirectoryInfo(directoryPath);
            FileInfo[] aryGetFiles;
            aryGetFiles = di.GetFiles();
            SortedList mySortedList = new SortedList();
            FileInfo[] aryHoldFiles = new FileInfo[aryGetFiles.Length];
            int intFileCnt = 0;
            foreach (FileInfo eleRJW in aryGetFiles)
            {
                if (eleRJW.Extension == ".jpg" || eleRJW.Extension == ".gif")
                {
                    aryHoldFiles[intFileCnt] = eleRJW;
                    string strSortKey = BuildSortKey(eleRJW.Name);

                    try
                    {
                        mySortedList.Add(strSortKey, eleRJW);
                        intFileCnt++;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Adding to Sorted List key" + Environment.NewLine + e.Message);
                    }
                }
            }
            aryReturnFileInfo = new FileInfo[intFileCnt];
            aryDateTime = new DateTime[intFileCnt];
            int[] aryIntkeys = new int[intFileCnt];
            for (int ix = 0; ix < intFileCnt; ix++)
            {
                aryReturnFileInfo[ix] = (System.IO.FileInfo)mySortedList.GetByIndex(ix);

                string strFileName = aryReturnFileInfo[ix].Name;
                string strNumeric = "";
                int intBracketPos = strFileName.IndexOf("[");
                if (intBracketPos < 0)
                {
                    intBracketPos = strFileName.IndexOf('.');
                }
                string strSubStr = strFileName.Substring(0, intBracketPos);
                strNumeric = strSubStr.Trim(aryAlphaCharToEliminate);
                this.aryDateTime[ix] = GetImageDate(strNumeric);
            }
            return aryReturnFileInfo;
        } // end of method SetupFileArrayFI

        private string BuildSortKey(string strFileName)
        {
            string strAlpha = "";
            string strNumeric = "";
            DateTime dtmReturnValue = new DateTime();
            string strReturnValue = "";
            int intBracketPos = strFileName.IndexOf("[");
            if (intBracketPos < 0)
            {
                intBracketPos = strFileName.IndexOf('.');
            }
            string strSubStr = strFileName.Substring(0, intBracketPos);
            strAlpha = strSubStr.Trim(aryNumericCharToEliminate);
            strNumeric = strSubStr.Trim(aryAlphaCharToEliminate);
            //string strFirstCharOfNumeric = strNumeric.Substring(0, 1);

            if (strAlpha == "" && strNumeric.Length == 4)
            {
                strAlpha = "KevinKell";
            }

            dtmReturnValue = GetImageDate(strNumeric);

            strReturnValue = strAlpha + dtmReturnValue.Date.ToString("yyyyMMdd", null);
            return strReturnValue;
        }

        private DateTime PullOutDate(string strNumeric)
        {

            //string strReturnValue=strNumeric;
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
                int intYear = 1754;
                int intMonth = 1;
                int intDay = 1;

                try
                {
                intYear = Int32.Parse(strYear);
                intMonth = Int32.Parse(strMonth);
                intDay = Int32.Parse(strDay);
                aryBlnValidDates[ix] = true;

                strMessage += Environment.NewLine + ix + "] " + strDates[ix];


                }
                catch (Exception err)
                {

                   string strErr = err.Message;
                }
                if ((intYear <= 2005 || intYear >= 2030) && aryBlnValidDates[ix])
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

        public FileInfo[] GetFileList()
        {
            return this.aryFileList;
        }

        public DateTime[] GetDateTimeList()
        {
            return this.aryDateTime;
        }

        private DateTime GetImageDate(string strNumeric)
        {
            string strYear = "";
            string strMonth = "";
            string strDay = "";
            int intYear;
            int intMonth;
            int intDay;
            DateTime dtmReturnValue = new DateTime();

            switch (strNumeric.Length)
            {
                case 8:
                    strYear = strNumeric.Substring(0, 4);
                    intYear = Int32.Parse(strYear);
                    strMonth = strNumeric.Substring(4, 2);
                    intMonth = Int32.Parse(strMonth);
                    strDay = strNumeric.Substring(6, 2);
                    intDay = Int32.Parse(strDay);
                    dtmReturnValue = new DateTime(intYear, intMonth, intDay);
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
                    strYear = "2007";
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
                default:
                    dtmReturnValue = PullOutDate(strNumeric);
                    break;
            }
            return dtmReturnValue;
        }
    }
}
