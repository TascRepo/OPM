using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExcelOffice = Microsoft.Office.Interop.Excel;

namespace OPM.ExcelHandler
{
    class OpmExcelHandler : IExcelHandler
    {
        private string _strFileName;


        public string FileName
        {
            set { _strFileName = value; }
            get { return _strFileName; }
        }
        public OpmExcelHandler()
        { }
        ~OpmExcelHandler()
        { }


        public static int fReadExcelFile(string fname)
        {
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;
            try
            {
                Dictionary<string, string> ListTP = new Dictionary<string, string>();

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(fname);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[2];
                xlRange = xlWorksheet.UsedRange;

                string xName = xlWorksheet.Name.ToString();
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                /*Get conntet Danh Sach Tinh/Tp*/
                for (int i = 2; i <= rowCount; i++)
                {
                    string index = Convert.ToString((xlRange.Cells[i, 1] as ExcelOffice.Range).Text);
                    string strName = Convert.ToString((xlRange.Cells[i, 3] as ExcelOffice.Range).Text);
                    if (string.Empty != index && string.Empty != strName)
                    {
                        ListTP.Add(index, strName);
                    }
                    else
                    {
                        i = rowCount + 1;
                    }

                }
                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 1;
            }
            catch (Exception)
            {
                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 0;
            }


        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        public static int fReadExcelFile3(string fname)
        {

            ExcelOffice.Application xlApp = new ExcelOffice.Application();
            ExcelOffice.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            int numSheets = xlWorkbook.Sheets.Count;
            //ExcelOffice._Worksheet xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
            List<string> items = new List<string>();
            foreach (ExcelOffice._Worksheet xlWorksheet in xlWorkbook.Sheets)
            {

                string xName = xlWorksheet.Name.ToString();

                items.Add(xName);

            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return 1;
        }

        public static int fReadPackageListFiles(string[] fnames, ref List<Packagelist> oPackagelist)
        {
            ExcelOffice.Application xlApp = null;
            List<ExcelOffice.Workbook> xlWorkbookList = null;
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice._Worksheet xlWorksheet = null;
            List<string> ListSerial = new List<string>();

            try
            {
                xlApp = new ExcelOffice.Application();
                xlWorkbookList = new List<ExcelOffice.Workbook>();
                foreach (string strfilename in fnames)
                {
                    int i = 0;
                    /*Read infor from file name*/
                    //int iRet = fReadInforFromFileName(strfilename, oPackagelist[i]);
                    //ExcelOffice.Application xlApp1;
                    //ExcelOffice.Workbook xlWorkBook1;
                    //ExcelOffice.Worksheet xlWorkSheet1;
                    //object misValue = System.Reflection.Missing.Value;

                    //xlApp1 = new ExcelOffice.Application();
                    //xlWorkBook1 = xlApp.Workbooks.Open(strfilename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    //xlWorkSheet1 = (ExcelOffice.Worksheet)xlWorkBook1.Worksheets.Item[1];

                    //MessageBox.Show(xlWorkSheet1.get_Range("A1", "A1").Value2.ToString());

                    //xlWorkBook1.Close(true, misValue, misValue);
                    //xlApp1.Quit();

                    //releaseObject(xlWorkSheet1);
                    //releaseObject(xlWorkBook1);
                    //releaseObject(xlApp1);


                    xlWorkbook = xlApp.Workbooks.Open(strfilename);
                    //xlWorkbook = xlApp.Workbooks.Open(strfilename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[3];
                    xlRange = xlWorksheet.UsedRange;
                    string xName = xlWorksheet.Name.ToString();
                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;
                    /*Get conntet Danh Sach Tinh/Tp*/
                    for (int j = 2; j <= rowCount; j++)
                    {
                        //string strCase = Convert.ToString((xlRange.Cells[i, 1] as ExcelOffice.Range).Text);
                        //string strStorage = Convert.ToString((xlRange.Cells[i, 3] as ExcelOffice.Range).Text);
                        string strSerial = Convert.ToString((xlRange.Cells[j, 3] as ExcelOffice.Range).Text);
                        //string strMAC = Convert.ToString((xlRange.Cells[i, 3] as ExcelOffice.Range).Text);
                        //string strSerial_gpon = Convert.ToString((xlRange.Cells[i, 3] as ExcelOffice.Range).Text);
                        if (string.Empty != strSerial)
                        {
                            Packagelist temp = new Packagelist();
                            temp.SetSerial(strSerial);
                            int ret = fReadInforFromFileName(strfilename, temp);
                            oPackagelist.Add(temp);

                        }
                        else
                        {
                            j = rowCount + 1;
                        }

                    }
                    i++;
                }


                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 1;
            }
            catch (Exception)
            {
                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 0;
            }



        }

        public static int fReadInforFromFileName(string strFilename, Packagelist oPackagelist)
        {

            try
            {
                string[] strInfo = strFilename.Split("-");
                string[] strDP = strInfo[6].Split(" ");
                string[] strProvince = strInfo[8].Split(" ");
                oPackagelist.PO_number = strDP[1];
                oPackagelist.Province = strProvince[0];
                oPackagelist.Year = strInfo[1] + strInfo[2];
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int fWriteExcelfile(string strFilename)
        {
            return 0;
        }


        public static int getExcelSheet(ref DataSet result, string file, ComboBox cbx_sheet)
        {
            try
            {
                if (file.EndsWith(".xlsx"))
                {
                    // Reading from a binary Excel file (format; *.xlsx)
                    FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    result = excelReader.AsDataSet();
                    excelReader.Close();
                }

                if (file.EndsWith(".xls"))
                {
                    // Reading from a binary Excel file ('97-2003 format; *.xls)
                    FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    result = excelReader.AsDataSet();
                    excelReader.Close();
                }

                List<string> items = new List<string>();
                for (int i = 0; i < result.Tables.Count; i++)
                    items.Add(result.Tables[i].TableName.ToString());
                cbx_sheet.DataSource = items;
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }


        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        //read Excel and save in database
        public static int fReadExcelFilePO(string fname, string idPO, ref List<ListExpPO> listExpPOs)
        {
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;
            try
            {

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(fname);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                string xName = xlWorksheet.Name.ToString();
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                string nameOfD = Convert.ToString((xlRange.Cells[3, 11] as ExcelOffice.Range).Text);
                for (int i = 11; i <= rowCount; i++)
                {
                    string index = Convert.ToString((xlRange.Cells[i, 1] as ExcelOffice.Range).Text);
                    if (string.Empty != index)
                    {
                        ListExpPO listExpPO = new ListExpPO();
                        string strName = Convert.ToString((xlRange.Cells[i, 2] as ExcelOffice.Range).Text);
                        string idProvine = convertToUnSign3(strName.Trim());
                        idProvine = idProvine.Replace(" ", "");
                        string strNofD = Convert.ToString((xlRange.Cells[i, 11] as ExcelOffice.Range).Text);
                        if (strNofD.Trim() == "-")
                        {
                            continue;
                        }
                        strNofD = strNofD.Replace(",", "").Trim();
                        int NofD = Convert.ToInt32(strNofD);
                        listExpPO.IdPO = idPO;
                        listExpPO.IdProvince = idProvine;
                        listExpPO.NameOfDevice = nameOfD;
                        listExpPO.NumberOfDevice = NofD;
                        listExpPOs.Add(listExpPO);
                    }
                    else
                    {
                        i = rowCount + 1;
                    }

                }
                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 1;
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 0;
            }
        }
        //show data on datagridview
        public static int fReadExcelFilePO2(string fname, ref System.Data.DataTable dt)
        {
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;
            DataRow row;
            try
            {
                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(fname);
                //xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[3];
                //Hiện giờ chỉ có 1 sheet đầu tiên nên Sheet[1]
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                string xName = xlWorksheet.Name.ToString();
                int rowCount = xlRange.Rows.Count;
                //Hiển thị xem có tổng cộng bao nhiêu hàng
                //MessageBox.Show(rowCount.ToString()); 72
                int colCount = xlRange.Columns.Count;
                //Hiển thị xem có tổng cộng bao nhiêu cột
                //MessageBox.Show(colCount.ToString()); 82
                int[] arrcolum = { 1, 3, 4 };
                int rowCounter;
                int StartCells = 0;
                int CountCells = 0;
                dt.Columns.Add("STT");
                dt.Columns.Add("VNPT tỉnh");
                dt.Columns.Add("Số lượng ONT");
                //Tìm hàng bắt đầy chạy STT
                for (int i = 1; i <= rowCount; i++)
                {
                    row = dt.NewRow();
                    if (xlRange.Cells[i, 1] != null)
                    {
                        row[1] = (xlRange.Cells[i, 1] as ExcelOffice.Range).Text;
                        if (row[1].ToString() == "STT")
                        {
                            StartCells = i;
                            break;
                        }
                    }
                }
                //Tim tong so hang can hien thi len man hinh
                for (int i = StartCells + 2; i <= rowCount; i++)
                {
                    row = dt.NewRow();
                    if (xlRange.Cells[i, 1] != null)
                    {
                        row[1] = (xlRange.Cells[i, 1] as ExcelOffice.Range).Text;
                        if (row[1].ToString() == "TỔNG CỘNG")
                        {
                            CountCells = i - 1;
                            break;
                        }
                    }
                }
                //
                for (int i = StartCells + 2; i <= CountCells; i++)
                {
                    row = dt.NewRow();
                    rowCounter = 0;
                    foreach (int j in arrcolum)
                    {
                        if (xlRange.Cells[i, j] != null)
                        {
                            row[rowCounter] = (xlRange.Cells[i, j] as ExcelOffice.Range).Text;
                        }
                        else
                        {
                            row[i] = "";
                        }
                        rowCounter++;
                    }
                    dt.Rows.Add(row);
                }
                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 1;
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 0;
            }
        }
        public static int FindAndReplace(string filename, string filesave, string idDp, string idContract, string site, string dateRequest, string dateOut, string addressB, string purpose, string accountanceCode, string numOfD)
        {
            object m = Type.Missing;
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;

            try
            {

                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(filename, m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                bool success = (bool)xlRange.Replace("<IdDP>", idDp, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success1 = (bool)xlRange.Replace("<IdContract>", idContract, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success2 = (bool)xlRange.Replace("<dateRequest>", dateRequest, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success3 = (bool)xlRange.Replace("<dateOut>", dateOut, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success4 = (bool)xlRange.Replace("<siteB>", site, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success5 = (bool)xlRange.Replace("<addressB>", addressB, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success6 = (bool)xlRange.Replace("<purpose>", purpose, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                bool success7 = (bool)xlRange.Replace("<accountanceCode>", accountanceCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);

                ExcelOffice._Worksheet xlWorksheet2 = (ExcelOffice._Worksheet)xlWorkbook.Sheets[2];
                ExcelOffice.Range xlRange2 = xlWorksheet.UsedRange;

                //bool success8 = (bool)xlRange2.Replace("<NumOfD>", numOfD, XlLookAt.xlWhole, XlSearchOrder.xlByRows, true, m, m, m);
                xlWorkbook.SaveAs(filesave + "\\DP_" + idDp + ".xlsx", Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                return 1;
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 0;
            }
        }
        //Save file excel in SQL
        public static int SaveFileInDelivery_PO(string fname, ref System.Data.DataTable dt)
        {
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;
            DataRow row;
            try
            {
                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(fname);
                //xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[3];
                //Hiện giờ chỉ có 1 sheet đầu tiên nên Sheet[1]
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                string xName = xlWorksheet.Name.ToString();
                int rowCount = xlRange.Rows.Count;
                //Hiển thị xem có tổng cộng bao nhiêu hàng
                //MessageBox.Show(rowCount.ToString()); 72
                int colCount = xlRange.Columns.Count;
                //Hiển thị xem có tổng cộng bao nhiêu cột
                //MessageBox.Show(colCount.ToString()); 82
                int[] arrcolum = { 1, 2, 3, 4, 5 };
                int rowCounter;
                int StartCells = 0;
                int CountCells = 0;
                dt.Columns.Add("STT");
                dt.Columns.Add("VNPT Tỉnh/ Thành phố");
                dt.Columns.Add("Tổng số PO");
                dt.Columns.Add("Số lượng");
                dt.Columns.Add("Ngày giao hàng");
                //Tìm hàng bắt đầy chạy STT
                for (int i = 1; i <= rowCount; i++)
                {
                    row = dt.NewRow();
                    if (xlRange.Cells[i, 1] != null)
                    {
                        row[1] = (xlRange.Cells[i, 1] as ExcelOffice.Range).Text;
                        if (row[1].ToString() == "STT")
                        {
                            StartCells = i;
                            break;
                        }
                    }
                }
                //Tim tong so hang can hien thi len man hinh
                for (int i = StartCells + 2; i <= rowCount; i++)
                {
                    row = dt.NewRow();
                    if (xlRange.Cells[i, 1] != null)
                    {
                        row[1] = (xlRange.Cells[i, 1] as ExcelOffice.Range).Text;
                        if (row[1].ToString() == "Tổng số")
                        {
                            CountCells = i - 1;
                            break;
                        }
                    }
                }
                //
                for (int i = StartCells + 2; i <= CountCells; i++)
                {
                    row = dt.NewRow();
                    rowCounter = 0;
                    foreach (int j in arrcolum)
                    {
                        if (xlRange.Cells[i, j] != null)
                        {
                            row[rowCounter] = (xlRange.Cells[i, j] as ExcelOffice.Range).Text;
                        }
                        else
                        {
                            row[i] = "";
                        }
                        rowCounter++;
                    }
                    dt.Rows.Add(row);
                }
                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 1;
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 0;
            }
        }
        //Mẫu phụ lục Serial kèm theo CNCL
        public static int fReadExcelPhuLucSerial(string fname, ref System.Data.DataTable dt)
        {
            ExcelOffice.Range xlRange = null;
            ExcelOffice.Workbook xlWorkbook = null;
            ExcelOffice.Application xlApp = null;
            ExcelOffice._Worksheet xlWorksheet = null;
            DataRow row;
            try
            {
                xlApp = new ExcelOffice.Application();
                xlWorkbook = xlApp.Workbooks.Open(fname);
                //Hiện giờ chỉ có 1 sheet đầu tiên nên Sheet[1]
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                string xName = xlWorksheet.Name.ToString();
                int rowCount = xlRange.Rows.Count;
                //Hiển thị xem có tổng cộng bao nhiêu hàng
                //MessageBox.Show(rowCount.ToString()); 72
                int colCount = xlRange.Columns.Count;
                //Hiển thị xem có tổng cộng bao nhiêu cột
                //MessageBox.Show(colCount.ToString()); 82
                int[] arrcolum = { 1,2,3,4,5,6,7,8,9,10};
                int rowCounter;
                int StartCells = 1;
                int CountCells = 0;
                dt.Columns.Add("STT1");
                dt.Columns.Add("Serial1");
                dt.Columns.Add("STT2");
                dt.Columns.Add("Serial2");
                dt.Columns.Add("STT3");
                dt.Columns.Add("Serial3");
                dt.Columns.Add("STT4");
                dt.Columns.Add("Serial4");
                dt.Columns.Add("STT5");
                dt.Columns.Add("Serial5");
                //Tim tong so hang can hien thi len man hinh
                for (int i = StartCells; i <= rowCount; i++)
                {
                    row = dt.NewRow();
                    if (xlRange.Cells[i, 1] != null)
                    {
                        row[1] = (xlRange.Cells[i, 1] as ExcelOffice.Range).Text;
                        if (row[1].ToString() == "")
                        {
                            CountCells = i - 1;
                            break;
                        }
                    }
                }
                //
                for (int i = StartCells + 1; i <= CountCells; i++)
                {
                    row = dt.NewRow();
                    rowCounter = 0;
                    foreach (int j in arrcolum)
                    {
                        if (xlRange.Cells[i, j] != null)
                        {
                            row[rowCounter] = (xlRange.Cells[i, j] as ExcelOffice.Range).Text;
                        }
                        else
                        {
                            row[i] = "";
                        }
                        rowCounter++;
                    }
                    dt.Rows.Add(row);
                }
                //cleanup  
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 1;
            }
            catch (Exception)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  

                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                return 0;
            }
        }
    }
}
