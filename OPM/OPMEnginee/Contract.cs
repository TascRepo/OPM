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
        private DateTime garanteeCreatedDate = DateTime.Now;
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
        public DateTime GaranteeCreatedDate { get => garanteeCreatedDate; set => garanteeCreatedDate = value; }

        public Contract() { }
        public Contract(string id, string namecontract, string codeaccouting, DateTime datesigned, string typecontract, int durationcontract, DateTime activedate, double valuecontract, int durationpo, string id_siteA, string id_siteB, string phuluc, string vbgurantee, string kHMS, DateTime experationDate, int blvalue,DateTime garanteeCreatedDate)
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
            GaranteeCreatedDate = garanteeCreatedDate;
        }
        public Contract(DataRow row)
        {
                Id = row["id"].ToString();
                Namecontract = (row["namecontract"] == null || row["namecontract"] == DBNull.Value) ? "" : row["namecontract"].ToString();
                Codeaccouting = (row["codeaccouting"] == null || row["codeaccouting"] == DBNull.Value) ? "" : row["codeaccouting"].ToString();
                Datesigned = (row["datesigned"] == null || row["datesigned"] == DBNull.Value) ? DateTime.Now : (DateTime)row["datesigned"];
                Typecontract = (row["typecontract"] == null || row["typecontract"] == DBNull.Value) ? "" : row["typecontract"].ToString();
                Durationcontract = (row["durationcontract"] == null || row["durationcontract"] == DBNull.Value) ? 0 : (int)row["durationcontract"];
                Activedate = (row["activedate"] == null || row["activedate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["activedate"];
                Valuecontract = (row["valuecontract"] == null || row["valuecontract"] == DBNull.Value) ? 0 : (double)row["valuecontract"];
                Durationpo = (row["durationpo"] == null || row["durationpo"] == DBNull.Value) ? 0 : (int)row["durationpo"];
                Id_siteA = (row["id_siteA"] == null || row["id_siteA"] == DBNull.Value) ? "" : row["id_siteA"].ToString();
                Id_siteB = (row["id_siteB"] == null || row["id_siteB"] == DBNull.Value) ? "" : row["id_siteB"].ToString();
                Phuluc = (row["phuluc"] == null || row["phuluc"] == DBNull.Value) ? "" : row["phuluc"].ToString();
                Vbgurantee = (row["vbgurantee"] == null || row["vbgurantee"] == DBNull.Value) ? "" : row["vbgurantee"].ToString();
                KHMS = (row["kHMS"] == null || row["kHMS"] == DBNull.Value) ? "" : row["kHMS"].ToString();
                ExperationDate = (row["experationDate"] == null || row["experationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["experationDate"];
                Blvalue = (row["blvalue"] == null || row["blvalue"] == DBNull.Value) ? 0 : (int)row["blvalue"];
                GaranteeCreatedDate = (row["garanteeCreatedDate"] == null || row["garanteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["garanteeCreatedDate"];
        }
        public Contract(string id)
        {
            Id = id;
            string query = string.Format("SELECT * FROM dbo.Contract WHERE id = '{0}'",id);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    Namecontract = (row["namecontract"] == null || row["namecontract"] == DBNull.Value) ? "" : row["namecontract"].ToString();
                    Codeaccouting = (row["codeaccouting"] == null || row["codeaccouting"] == DBNull.Value) ? "" : row["codeaccouting"].ToString();
                    Datesigned = (row["datesigned"] == null || row["datesigned"] == DBNull.Value) ? DateTime.Now : (DateTime)row["datesigned"];
                    Typecontract = (row["typecontract"] == null || row["typecontract"] == DBNull.Value) ? "" : row["typecontract"].ToString();
                    Durationcontract = (row["durationcontract"] == null || row["durationcontract"] == DBNull.Value) ? 0 : (int)row["durationcontract"];
                    Activedate = (row["activedate"] == null || row["activedate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["activedate"];
                    Valuecontract = (row["valuecontract"] == null || row["valuecontract"] == DBNull.Value) ? 0 : (double)row["valuecontract"];
                    Durationpo = (row["durationpo"] == null || row["durationpo"] == DBNull.Value) ? 0 : (int)row["durationpo"];
                    Id_siteA = (row["id_siteA"] == null || row["id_siteA"] == DBNull.Value) ? "" : row["id_siteA"].ToString();
                    Id_siteB = (row["id_siteB"] == null || row["id_siteB"] == DBNull.Value) ? "" : row["id_siteB"].ToString();
                    Phuluc = (row["phuluc"] == null || row["phuluc"] == DBNull.Value) ? "" : row["phuluc"].ToString();
                    Vbgurantee = (row["vbgurantee"] == null || row["vbgurantee"] == DBNull.Value) ? "" : row["vbgurantee"].ToString();
                    KHMS = (row["kHMS"] == null || row["kHMS"] == DBNull.Value) ? "" : row["kHMS"].ToString();
                    ExperationDate = (row["experationDate"] == null || row["experationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["experationDate"];
                    Blvalue = (row["blvalue"] == null || row["blvalue"] == DBNull.Value) ? 0 : (int)row["blvalue"];
                    GaranteeCreatedDate = (row["garanteeCreatedDate"] == null || row["garanteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["garanteeCreatedDate"];
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract!");
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
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Contract(id,namecontract,codeaccouting,datesigned,typecontract,durationcontract,activedate,valuecontract,durationpo,id_siteA,id_siteB,phuluc,vbgurantee,KHMS,experationDate,blvalue,garanteeCreatedDate) VALUES('{0}',N'{1}',N'{2}','{3}',N'{4}',{5},'{6}',{7},{8},N'{9}',N'{10}','{11}','{12}',N'{13}','{14}',{15},'{16}') --INSERT INTO dbo.CatalogAdmin (ctlID, ctlname) VALUES ('Contract_{0}', '{0}')", id, namecontract, codeaccouting, datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typecontract, durationcontract, activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), valuecontract, durationpo, id_siteA, id_siteB, phuluc, vbgurantee, kHMS, experationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), blvalue, garanteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            OPMDBHandler.ExecuteNonQuery(query);
            //MessageBox.Show(string.Format("Tạo mới thành công hợp đồng {0} !",id));
        }
        public void Insert(string id)
        {
            //string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Contract(id,namecontract,codeaccouting,datesigned,typecontract,durationcontract,activedate,valuecontract,durationpo,id_siteA,id_siteB,phuluc,vbgurantee,KHMS,experationDate,blvalue) VALUES('{0}',N'{1}',N'{2}','{3}',N'{4}',{5},'{6}',{7},{8},N'{9}',N'{10}','{11}','{12}',N'{13}','{14}',{15}) --INSERT INTO dbo.CatalogAdmin (ctlID, ctlname) VALUES ('Contract_{0}', '{0}')", id, namecontract, codeaccouting, datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typecontract, durationcontract, activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), valuecontract, durationpo, id_siteA, id_siteB, phuluc, vbgurantee, kHMS, experationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), blvalue);
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Contract(id,namecontract,codeaccouting,datesigned,typecontract,durationcontract,activedate,valuecontract,durationpo,id_siteA,id_siteB,phuluc,vbgurantee,KHMS,experationDate,blvalue,garanteeCreatedDate) VALUES('{0}',N'{1}',N'{2}','{3}',N'{4}',{5},'{6}',{7},{8},N'{9}',N'{10}','{11}','{12}',N'{13}','{14}',{15},'{16}') --INSERT INTO dbo.CatalogAdmin (ctlID, ctlname) VALUES ('Contract_{0}', '{0}')", id, namecontract, codeaccouting, datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typecontract, durationcontract, activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), valuecontract, durationpo, id_siteA, id_siteB, phuluc, vbgurantee, kHMS, experationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), blvalue, garanteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            OPMDBHandler.ExecuteNonQuery(query);
            //MessageBox.Show(string.Format("Tạo mới thành công hợp đồng {0} !", id));
        }
        public void Update()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Contract SET namecontract = N'{1}', codeaccouting = N'{2}', datesigned = '{3}',typecontract = N'{4}', durationcontract = {5},activedate = '{6}',valuecontract = {7},durationpo = {8},id_siteA = N'{9}',id_siteB = N'{10}',phuluc = '{11}',vbgurantee = '{12}',KHMS = N'{13}',experationDate = '{14}',blvalue = {15}, garanteeCreatedDate='"+ garanteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")) + "' WHERE id = '{0}'", id, namecontract, codeaccouting, datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typecontract, durationcontract, activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), valuecontract, durationpo, id_siteA, id_siteB, phuluc, vbgurantee, kHMS, experationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), blvalue, experationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), blvalue);
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

            //string query = string.Format("DELETE FROM dbo.Contract_Goods WHERE idContract = '{0}' DELETE FROM dbo.DP WHERE id_contract = '{0}' DELETE FROM dbo.PO WHERE id_contract = '{0}' DELETE FROM dbo.Contract WHERE id = '{0}' DELETE FROM dbo.CatalogAdmin WHERE ctlname = '{0}'", id);
            string query = string.Format("DELETE FROM dbo.Contract WHERE id = '{0}'", id);

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
    }
}
