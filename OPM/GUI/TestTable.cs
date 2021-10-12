using OPM.OPMEnginee;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WordOffice = Microsoft.Office.Interop.Word;

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
                DataTable tabsql = CatalogAdmin.Table();
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
