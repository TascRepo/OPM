﻿using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExcelOffice = Microsoft.Office.Interop.Excel;

namespace OPM.ExcelHandler
{
    class OpmExcelHandler
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

        public static string GetNameOfExcelFile()
        {
            OpenFileDialog openFileExcel = new OpenFileDialog();
            openFileExcel.Multiselect = false;
            openFileExcel.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)|*.xlsx|Excel Files(*.xlsm)|*.xlsm";
            openFileExcel.FilterIndex = 2;
            if (openFileExcel.ShowDialog() == DialogResult.OK)
                if (File.Exists(openFileExcel.FileName))
                    return openFileExcel.FileName;
            return null;
        }
        public static void ExportDataTableToExcel(System.Data.DataTable dataTable, string nameOfExcelFile, int indexWorksheet, int indexHeaderLine, int indexStartColumn)
        {
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = null;
            Microsoft.Office.Interop.Excel.Range excelCellrange = null;
            try
            {
                // Get Application object.
                // Start Excel and get Application object.  
                excel = new Microsoft.Office.Interop.Excel.Application();
                // for making Excel visible  
                excel.Visible = false;
                excel.DisplayAlerts = false;
                // Creation a new Workbook  
                excelworkBook = excel.Workbooks.Add(Type.Missing);
                // Workk sheet  
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = "Test work sheet";
                //Test
                excelSheet.Cells[5, 1] = 1;
                excelSheet.Cells[6, 1] = 2;

                //int countOfColumns = dataTable.Columns.Count;
                //// Tổng số dòng
                //int countOfRows = dataTable.Rows.Count; ;
                ////filling the table from  excel file                
                //for (int i = 0; i < countOfRows; i++)
                //{
                //    for (int j = 0; j <countOfColumns; j++)
                //    {
                //        range.Cells[i + indexHeaderLine, j + indexStartColumn] = dataTable.Rows[i].ItemArray[j];
                //    }

                //}

                //now close the workbook and make the function return the data table
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(excelCellrange);
                Marshal.ReleaseComObject(excelSheet);
                excelworkBook.Close();
                Marshal.ReleaseComObject(excelworkBook);
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(excelCellrange);
                Marshal.ReleaseComObject(excelSheet);
                excelworkBook.Close();
                Marshal.ReleaseComObject(excelworkBook);
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                return;
            }
        }
        public static System.Data.DataTable ReadExcelToDataTable(string nameOfExcelFile, int indexWorksheet, int indexHeaderLine, int indexStartColumn)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Range range = null;
            try
            {
                // Get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application
                {
                    Visible = false,
                    DisplayAlerts = false
                };
                // Open Workbook
                object m = Type.Missing;
                workbook = excel.Workbooks.Open(nameOfExcelFile, m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                // Worksheet
                sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Item[indexWorksheet];
                range = sheet.UsedRange;
                if (range.Rows.Count < indexHeaderLine || range.Columns.Count < indexStartColumn)
                {
                    MessageBox.Show(string.Format("Giá trị indexHeaderLine và indexStartColumn không phù hợp với File Excel"));
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(range);
                    Marshal.ReleaseComObject(sheet);
                    workbook.Close();
                    Marshal.ReleaseComObject(workbook);
                    excel.Quit();
                    Marshal.ReleaseComObject(excel);
                    return null;
                }
                int countOfColumns = range.Columns.Count;
                // Tổng số dòng
                int countOfRows = range.Rows.Count; ;
                //Tạo Headder cho Datatable (Kiểu là String)
                for (int j = indexStartColumn; j <= countOfColumns; j++)
                {
                    dataTable.Columns.Add(Convert.ToString((range.Cells[indexHeaderLine, j] as Microsoft.Office.Interop.Excel.Range).Value2), typeof(string));
                }
                //filling the table from  excel file                
                for (int i = indexHeaderLine + 1; i <= countOfRows; i++)
                {
                    DataRow dr = dataTable.NewRow();
                    for (int j = indexStartColumn; j <= countOfColumns; j++)
                    {

                        dr[j - indexStartColumn] = Convert.ToString((range.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value2);
                    }

                    dataTable.Rows.InsertAt(dr, dataTable.Rows.Count + 1);
                }

                //now close the workbook and make the function return the data table
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(sheet);
                workbook.Close();
                Marshal.ReleaseComObject(workbook);
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(sheet);
                workbook.Close();
                Marshal.ReleaseComObject(workbook);
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                return null;
            }
        }
        public static int GetIndexDataRowInDataTable(System.Data.DataTable table, string identifying)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if ((table.Rows[i][0].ToString() == identifying)) return (i + 1);
            }
            return 0;
        }
        public static System.Data.DataTable DataTableSerialFromExcelFile(string nameOfExcelFile)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Range range = null;
            try
            {
                // Get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application
                {
                    Visible = false,
                    DisplayAlerts = false
                };
                // Open Workbook
                object m = Type.Missing;
                workbook = excel.Workbooks.Open(nameOfExcelFile, m, false, m, m, m, m, m, m, m, m, m, m, m, m);
                // Worksheet
                sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Item[1];
                range = sheet.UsedRange;
                int indexHeaderRows = 1;
                int countOfColumns = range.Columns.Count;
                // Tổng số dòng
                int countOfRows = range.Rows.Count;
                //Tạo Headder cho Datatable DeliveryPlan
                dataTable.Columns.Add("CaseNumber", typeof(string));
                dataTable.Columns.Add("ProductionBoxNumber", typeof(string));
                dataTable.Columns.Add("Srial", typeof(string));
                dataTable.Columns.Add("Mac", typeof(string));
                dataTable.Columns.Add("SeriGPON", typeof(string));
                dataTable.Columns.Add("SrialOfBox", typeof(string));
                //filling the table from  excel file                
                for (int i = indexHeaderRows + 1; i < countOfRows; i++)
                {
                    DataRow row = dataTable.NewRow();
                    row["Province"] = (range.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2;
                    row["Phase"] = 0;
                    row["ExpectedQuantity"] = (range.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2;
                    dataTable.Rows.Add(row);
                    for (int j = 1; 2 * j <= (countOfColumns - 3); j++)
                    {
                        row = dataTable.NewRow();
                        row["Province"] = (range.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2;
                        row["Phase"] = j;
                        row["ExpectedQuantity"] = ((range.Cells[i, 2 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? DBNull.Value : (range.Cells[i, 2 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2;
                        if (((range.Cells[i, 3 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2 == null))
                        {
                            row["ExpectedDate"] = DBNull.Value;
                        }
                        else
                        {
                            row["ExpectedDate"] = DateTime.FromOADate((double)((range.Cells[i, 3 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2)).ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"));
                        }
                        //row["ExpectedDate"] =((range.Cells[i, 3 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2 == null)? DBNull.Value : (range.Cells[i, 3 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2;
                        dataTable.Rows.Add(row);

                        //row[j - 1] = ((range.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? null : (range.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                        //dr[j - 1] = Convert.ToString((range.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value2);
                    }

                }
                //now close the workbook and make the function return the data table
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(sheet);
                workbook.Close();
                Marshal.ReleaseComObject(workbook);
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(sheet);
                workbook.Close();
                Marshal.ReleaseComObject(workbook);
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                return null;
            }
        }
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
                //Hiện giờ có 06 sheet đầu tiên nên Sheet[3] trong mẫu 17.PL
                xlWorksheet = (ExcelOffice._Worksheet)xlWorkbook.Sheets["Serial-Mac"];
                xlRange = xlWorksheet.UsedRange;
                string xName = xlWorksheet.Name.ToString();
                int rowCount = xlRange.Rows.Count;
                //Hiển thị xem có tổng cộng bao nhiêu hàng
                //MessageBox.Show(rowCount.ToString()); 72
                int colCount = xlRange.Columns.Count;
                //Hiển thị xem có tổng cộng bao nhiêu cột
                //MessageBox.Show(colCount.ToString()); 82
                int[] arrcolum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                int rowCounter;
                int StartCells = 1;
                int CountCells = 0;
                dt.Columns.Add("STT");
                dt.Columns.Add("Kiện số");
                dt.Columns.Add("Thùng sản phẩm số");
                dt.Columns.Add("Serial");
                dt.Columns.Add("Mac");
                dt.Columns.Add("SeriGPON");
                dt.Columns.Add("Serial theo thùng");
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
        //Đề nghị phát hóa đơn
        public static int fReadExcelDeNghiHD(string fname, ref System.Data.DataTable dt)
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
                int[] arrcolum = { 1, 2, 3, 4, 5, 6, 7 };
                int rowCounter;
                int StartCells = 0;
                int CountCells = 0;
                dt.Columns.Add("STT");
                dt.Columns.Add("VNPT Tỉnh/ Thành Phố");
                dt.Columns.Add("ONT Hàng chính");
                dt.Columns.Add("ONT Hàng phụ");
                dt.Columns.Add("Đơn giá(Chưa VAT)");
                dt.Columns.Add("Thành tiền(Chưa VAT)");
                dt.Columns.Add("Đề nghị tạm ứng");
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
                for (int i = StartCells + 1; i <= rowCount; i++)
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

    }
}
