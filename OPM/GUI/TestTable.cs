using OPM.OPMEnginee;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WordOffice = Microsoft.Office.Interop.Word;
using ExcelOffice = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace OPM.GUI
{
    public partial class TestTableForm : Form
    {
        public TestTableForm()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dataGridViewTest.DataSource = CatalogAdmin.Table();
            textBox1.DataBindings.Add("Text", dataGridViewTest.DataSource, "ctlId");
            textBox2.DataBindings.Add("Text", dataGridViewTest.DataSource, "ctlName");
            textBox3.DataBindings.Add("Text", dataGridViewTest.DataSource, "ctlParent");
            dataGridViewTest.CurrentCell = dataGridViewTest.Rows[2].Cells["ctlId"];
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
                xlWorkbook.SaveAs(filesave, Type.Missing, Type.Missing,
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

        private void TestTableForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public static string Test()
        {
            object filename = string.Format(@"C:\Users\XUANTHANH\Desktop\Test.docx");
            object path = @"C:\Users\XUANTHANH\Desktop\Mẫu 8. De nghi NTKT.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(@"Không tìm thấy file C: \Users\XUANTHANH\Desktop\Mẫu 8. De nghi NTKT.docx");
                return @"Không tìm thấy file C: \Users\XUANTHANH\Desktop\Mẫu 8. De nghi NTKT.docx";
            }
            WordOffice.Application wordApp = null;
            WordOffice.Document myDoc=null;
            try
            {
                wordApp = new WordOffice.Application
                {
                    Visible = false
                };
                object missing = Missing.Value;
                object readOnly = true;
                
                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //Khai báo bảng trong File Word
                WordOffice.Table tab = myDoc.Tables[1];
                //Lấy dữ liệu từ bảng CatalogAdmin
                //List<CatalogAdmin> list = CatalogAdmin.CatalogAdmins();
                System.Data.DataTable tabsql = CatalogAdmin.Table();
                //Đặt tên các cột (Không cần thiết vì thường để cứng)
                tab.Cell(1, 1).Range.Text = "ID";
                tab.Cell(1, 2).Range.Text = "Name";
                tab.Cell(1, 3).Range.Text = "Parent";

                //Đưa dữ liệu từ SQL vào bảng Word
                for (int i = 0; i < tabsql.Rows.Count; i++)
                {
                    tab.Rows.Add(ref missing);
                    tab.Cell(i + 2, 1).Range.Text = tabsql.Rows[i][0].ToString();
                    tab.Cell(i + 2, 2).Range.Text = tabsql.Rows[i][1].ToString(); ;
                    tab.Cell(i + 2, 3).Range.Text = tabsql.Rows[i][2].ToString(); ;
                }


                //find and replace
                //OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);

                //OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                //OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.Confirmpo_number);
                //OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));
                //OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.Numberofdevice + Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.Phonenumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.Representative);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.Tin);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.Type);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.Headquater_info);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.Address);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.Account);
                ////OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_CNBQPM>", ntkt.Date_CNBQPM.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Total>", ntkt.Numberofdevice2 + ntkt.Numberofdevice);



                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"C:\Users\XUANTHANH\Desktop");
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
