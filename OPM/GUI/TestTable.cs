using OPM.OPMEnginee;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ExcelOffice = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using DataTable = System.Data.DataTable;
using System.Globalization;

namespace OPM.GUI
{
    public partial class TestTable : Form
    {
        public TestTable()
        {
            InitializeComponent();
        }
        public static int FindAndReplace(string filename, string filesave)
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

                //bool success = (bool)xlRange.Replace("<IdDP>", idDp, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                //bool success1 = (bool)xlRange.Replace("<IdContract>", idContract, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                //bool success2 = (bool)xlRange.Replace("<dateRequest>", dateRequest, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                //bool success3 = (bool)xlRange.Replace("<dateOut>", dateOut, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                //bool success4 = (bool)xlRange.Replace("<siteB>", site, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                //bool success5 = (bool)xlRange.Replace("<addressB>", addressB, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                //bool success6 = (bool)xlRange.Replace("<purpose>", purpose, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);
                //bool success7 = (bool)xlRange.Replace("<accountanceCode>", accountanceCode, XlLookAt.xlWhole, XlSearchOrder.xlByColumns, true, m, m, m);

                ExcelOffice._Worksheet xlWorksheet2 = (ExcelOffice._Worksheet)xlWorkbook.Sheets[2];
                ExcelOffice.Range xlRange2 = xlWorksheet.UsedRange;

                //bool success8 = (bool)xlRange2.Replace("<NumOfD>", numOfD, XlLookAt.xlWhole, XlSearchOrder.xlByRows, true, m, m, m);
                xlWorkbook.SaveAs(filesave, m, m, m, m, m, XlSaveAsAccessMode.xlExclusive, m, m, m, m, m);
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
        public static System.Data.DataTable ReadExcelToDataTable(string nameOfExcelFile, int indexWorksheet, int indexHeaderLine, int indexStartColumn)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            Microsoft.Office.Interop.Excel.Application excel=null;
            Microsoft.Office.Interop.Excel.Workbook workbook=null;
            Microsoft.Office.Interop.Excel.Worksheet sheet=null;
            Microsoft.Office.Interop.Excel.Range range=null;
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
                sheet = (Microsoft.Office.Interop.Excel.Worksheet) workbook.Worksheets.Item[indexWorksheet];
                range = sheet.UsedRange;
                if(range.Rows.Count< indexHeaderLine|| range.Columns.Count< indexStartColumn)
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
                    dataTable.Columns.Add(string.Format(@"{0} {1}",Convert.ToString((range.Cells[indexHeaderLine, j] as Microsoft.Office.Interop.Excel.Range).Value2),j), typeof(string));
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
        public static int GetIndexDataRowInDataTable(DataTable table,string identifying)
        {
            for(int i=0;i< table.Rows.Count; i++)
            {
                if ((table.Rows[i][0].ToString() == identifying)) return (i + 1);
            }
            return 0;
        }
        public static DataTable DataTableDeliveryPlanFromExcelFile(string nameOfExcelFile)
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
                int indexHeaderRows = 4;
                int countOfColumns = range.Columns.Count;
                // Tổng số dòng
                int countOfEndRows = range.Rows.Count;
                for (int i= indexHeaderRows; i< range.Rows.Count; i++)
                {
                    if ((Convert.ToString((range.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Text) == "Tổng cộng:")|| (Convert.ToString((range.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Text) == "Tổng cộng:"))
                    {
                        countOfEndRows = i;
                        break;
                    }
                }
                //MessageBox.Show(countOfEndRows.ToString());

                //Tạo Headder cho Datatable DeliveryPlan
                dataTable.Columns.Add("Province", typeof(string));
                dataTable.Columns.Add("Phase", typeof(int));
                dataTable.Columns.Add("ExpectedQuantity", typeof(int));
                dataTable.Columns.Add("ExpectedDate", typeof(string));
                //filling the table from  excel file                
                for (int i = indexHeaderRows + 1; i < countOfEndRows; i++)
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
                        row["ExpectedQuantity"] = ((range.Cells[i, 2 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2==null)?DBNull.Value:(range.Cells[i, 2 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2;
                        if(((range.Cells[i, 3 + 2 * j] as Microsoft.Office.Interop.Excel.Range).Value2 == null))
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
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            string str = GetNameOfExcelFile();
            System.Data.DataTable dataTable = DataTableDeliveryPlanFromExcelFile(str);
            dataGridViewTest.DataSource = dataTable;
        }
    }
}
