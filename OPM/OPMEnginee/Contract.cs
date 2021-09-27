using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WordOffice = Microsoft.Office.Interop.Word;
using System.Reflection;
using OPM.WordHandler;
using System.IO;
using System.Globalization;

namespace OPM.OPMEnginee
{
    public class Contract
    {
        private string id= "111-2020/CUVT-ANSV/DTRR-KHMS";
        private string namecontract = "Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)";
        private string codeaccouting = "C01007";
        private DateTime datesigned = DateTime.Now;
        private string typecontract = "Theo đơn giá cố định";
        private int durationcontract = 0;
        private DateTime activedate = DateTime.Now;
        private double valuecontract=0;
        private int durationpo=5;
        private string id_siteA= "Trung tâm cung ứng vật tư - Viễn thông TP.HCM";
        private string id_siteB= "Công ty TNHH thiết bị Viễn thông ANSV";
        private string phuluc= "phuluc";
        private string vbgurantee="vbgurantee";
        private string kHMS= "Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020";
        private DateTime experationDate = DateTime.Now;
        private int blvalue=0; 
        public string Id { get => id; set => id = value; }
        public string Namecontract { get => namecontract; set => namecontract = value; }
        public string Codeaccouting { get => codeaccouting; set => codeaccouting = value; }
        public DateTime Datesigned { get => datesigned; set => datesigned = value; }
        public string Typecontract { get => typecontract; set => typecontract = value; }
        public int Durationcontract { get => durationcontract; set => durationcontract = value; }
        public DateTime Activedate { get => activedate; set => activedate = value; }
        public double Valuecontract { get => valuecontract; set => valuecontract = value; }
        public int Durationpo { get => durationpo; set => durationpo = value; }
        public string Id_siteA { get => id_siteA; set => id_siteA = value; }
        public string Id_siteB { get => id_siteB; set => id_siteB = value; }
        public string Phuluc { get => phuluc; set => phuluc = value; }
        public string Vbgurantee { get => vbgurantee; set => vbgurantee = value; }
        public string KHMS { get => kHMS; set => kHMS = value; }
        public DateTime ExperationDate { get => experationDate; set => experationDate = value; }
        public int Blvalue { get => blvalue; set => blvalue = value; }
        public Contract() { }
        public Contract(string id, string namecontract, string codeaccouting, DateTime datesigned, string typecontract, int durationcontract, DateTime activedate, double valuecontract, int durationpo, string id_siteA, string id_siteB, string phuluc, string vbgurantee, string kHMS, DateTime experationDate, int blvalue)
        {
            Id = id;
            Namecontract = namecontract;
            Codeaccouting = codeaccouting;
            Datesigned = datesigned;
            Typecontract = typecontract;
            Durationcontract = durationcontract;
            Activedate = activedate;
            Valuecontract = valuecontract;
            Durationpo = durationpo;
            Id_siteA = id_siteA;
            Id_siteB = id_siteB;
            Phuluc = phuluc;
            Vbgurantee = vbgurantee;
            KHMS = kHMS;
            ExperationDate = experationDate;
            Blvalue = blvalue;
        }
        public Contract(DataRow row)
        {
            Id = row["id"].ToString();
            Namecontract = row["namecontract"].ToString();
            Codeaccouting = row["codeaccouting"].ToString();
            Datesigned = (row["datesigned"] == DBNull.Value) ? DateTime.Now : (DateTime)row["datesigned"];
            Typecontract = row["typecontract"].ToString();
            Durationcontract = (int)row["durationcontract"];
            Activedate = (row["activedate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["activedate"];
            Valuecontract = (double)row["valuecontract"];
            Durationpo = (int)row["durationpo"];
            Id_siteA = row["id_siteA"].ToString();
            Id_siteB = row["id_siteB"].ToString();
            Phuluc = row["phuluc"].ToString();
            Vbgurantee = row["vbgurantee"].ToString();
            KHMS = row["kHMS"].ToString();
            ExperationDate = (row["experationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["experationDate"];
            Blvalue = (int)row["blvalue"];
        }
        public Contract(string id)
        {
            Id = id;
            string query = string.Format("SELECT * FROM dbo.Contract WHERE id = '{0}'",id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            if (table.Rows.Count>0)
            {
                DataRow row = table.Rows[0];
                Namecontract = row["namecontract"].ToString();
                Codeaccouting = row["codeaccouting"].ToString();
                Datesigned = (row["datesigned"]==DBNull.Value)? DateTime.Now:(DateTime)row["datesigned"];
                Typecontract = row["typecontract"].ToString();
                Durationcontract = (int)row["durationcontract"];
                Activedate = (row["activedate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["activedate"];
                Valuecontract = (double)row["valuecontract"];
                Durationpo = (int)row["durationpo"];
                Id_siteA = row["id_siteA"].ToString();
                Id_siteB = row["id_siteB"].ToString();
                Phuluc = row["phuluc"].ToString();
                Vbgurantee = row["vbgurantee"].ToString();
                KHMS = row["kHMS"].ToString();
                ExperationDate = (row["experationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["experationDate"];
                Blvalue = (row["blvalue"]==DBNull.Value)?0:(int)row["blvalue"];
            }
        }
        public List<Contract> GetList()
        {
            List<Contract> contracts=new List<Contract>();
            string query = string.Format("SELECT * FROM dbo.Contract");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach(DataRow row in dataTable.Rows)
            {
                Contract contract = new Contract(row);
                contracts.Add(contract);
            }
            return contracts;
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.Contract WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool Exist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.Contract WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count>0;
        }
        public void Insert()
        {
            //string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Contract(id,namecontract,codeaccouting,datesigned,typecontract,durationcontract,activedate,valuecontract,durationpo,id_siteA,id_siteB,phuluc,vbgurantee,KHMS,experationDate,blvalue) VALUES('{0}',N'{1}',N'{2}','{3}',N'{4}',{5},'{6}',{7},{8},N'{9}',N'{10}','{11}','{12}',N'{13}','{14}',{15}) --INSERT INTO dbo.CatalogAdmin (ctlID, ctlname) VALUES ('Contract_{0}', '{0}')", id, namecontract, codeaccouting, datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typecontract, durationcontract, activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), valuecontract, durationpo, id_siteA, id_siteB, phuluc, vbgurantee, kHMS, experationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), blvalue);
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Contract(id,namecontract,codeaccouting,datesigned,typecontract,durationcontract,activedate,valuecontract,durationpo,id_siteA,id_siteB,phuluc,vbgurantee,KHMS,experationDate,blvalue) VALUES('{0}',N'{1}',N'{2}','{3}',N'{4}',{5},'{6}',{7},{8},N'{9}',N'{10}','{11}','{12}',N'{13}','{14}',{15}) INSERT INTO dbo.CatalogAdmin (ctlID, ctlname) VALUES ('Contract_{0}', '{0}')", id, namecontract, codeaccouting, datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typecontract, durationcontract, activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), valuecontract, durationpo, id_siteA, id_siteB, phuluc, vbgurantee, kHMS, experationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), blvalue);
            OPMDBHandler.ExecuteNonQuery(query);
            MessageBox.Show(string.Format("Tạo mới thành công hợp đồng {0} !",id));
        }
        public void Update()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Contract SET namecontract = N'{1}', codeaccouting = N'{2}', datesigned = '{3}',typecontract = N'{4}', durationcontract = {5},activedate = '{6}',valuecontract = {7},durationpo = {8},id_siteA = N'{9}',id_siteB = N'{10}',phuluc = '{11}',vbgurantee = '{12}',KHMS = N'{13}',experationDate = '{14}',blvalue = {15} WHERE id = '{0}'", id, namecontract, codeaccouting, datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typecontract, durationcontract, activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), valuecontract, durationpo, id_siteA, id_siteB, phuluc, vbgurantee, kHMS, experationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), blvalue);
            OPMDBHandler.ExecuteNonQuery(query);
            MessageBox.Show(string.Format("Cập nhật thành công hợp đồng {0} !", id));
        }
        public static void Delete(string id)
        {
            int result = 0;
            if (id.Trim()==null)
            {
                MessageBox.Show("Xoá hợp đồng thất bại vì chưa nhập tên!");
                return;
            }
            if(MessageBox.Show(string.Format("Có chắc chắn xoá hợp đồng: {0} không?", id),"Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.Cancel) return;

            string query = string.Format(" DELETE FROM dbo.DP WHERE id_contract = '{0}' DELETE FROM dbo.PO WHERE id_contract = '{0}' DELETE FROM dbo.Contract WHERE id = '{0}' DELETE FROM dbo.CatalogAdmin WHERE ctlname = '{0}'", id);
            try
            {
                result = OPMDBHandler.ExecuteNonQuery(query);
            }
            catch
            {
                MessageBox.Show("Xoá hợp đồng thất bại!");
            }
            if (result != 0) MessageBox.Show("Bạn đã xoá hợp đồng thành công!");
        }
        public string CreatContractGuarantee()
        {
            object filename = string.Format(@"D:\OPM\{0}\BLHD_{0}.docx", id.Trim().Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Đề nghị mở bảo lãnh thực hiện HĐ.docx";
            if (File.Exists(path.ToString()))
            {
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //Tạo thư mục
                string folder = string.Format(@"D:\OPM\{0}", id.Trim().Replace('/', '-'));
                Directory.CreateDirectory(folder);

                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_Code>", id.Trim());
                OpmWordHandler.FindAndReplace(wordApp, "<Now>", activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_Name>", namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<Signed_Date>", datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<Site_B>", id_siteB);
                OpmWordHandler.FindAndReplace(wordApp, "<blvalue>", blvalue);
                OpmWordHandler.FindAndReplace(wordApp, "<durationpo>", durationpo);
                //Tạo file BLHĐ trong thư mục D:\OPM
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}",filename.ToString()));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                myDoc.Close();
                wordApp.Quit();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản mẫu BLHD.docx! ");
            }
            return filename.ToString();
        }
    }
}
