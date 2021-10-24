using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class SiteObj
    {
        public string SiteId { get; set; } = "Công ty TNHH thiết bị viễn thông ANSV";
        public string ProvinceId { get; set; } = "ANSV";
        public string TypeOfSite { get; set; } = "Site A";
        public string Headquater { get; set; } = "124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội";
        public string Address { get; set; } = "124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội";
        public string Phonenumber { get; set; } = "02438362094";
        public string FaxNumber { get; set; } = "02433861195";
        public string TaxCode { get; set; } = "0100113871";
        public string BankAccount { get; set; } = "0071001103933";
        public string NameOfBank { get; set; } = "MSB";
        public string Representative1 { get; set; } = "Ông Nguyễn Văn Nam";
        public string Position1 { get; set; } = "Tổng giám đốc";
        public string Proxy1 { get; set; } = "";
        public string Representative2 { get; set; } = "Ông Vũ Thiện Nhượng";
        public string Position2 { get; set; } = "Giám đốc DO";
        public string Proxy2 { get; set; } = "";
        public string Representative3 { get; set; } = "Ông Nguyễn Ngọc Huy";
        public string Position3 { get; set; } = "Giám đốc Tasc";
        public string Proxy3 { get; set; } = "";

        public SiteObj() { }
        public SiteObj(string id, string idVNPT, string type, string headquater, string address, string phonenumber, string fax, string tax, string account, string nameOfBank,string representative1, string position1, string proxy1, string representative2, string position2, string proxy2, string representative3, string position3, string proxy3)
        {
            SiteId = id;
            ProvinceId = idVNPT;
            TypeOfSite = type;
            Headquater = headquater;
            Address = address;
            Phonenumber = phonenumber;
            FaxNumber = fax;
            TaxCode = tax;
            BankAccount = account;
            NameOfBank = nameOfBank;
            Representative1 = representative1;
            Position1 = position1;
            Proxy1 = proxy1;
            Representative2 = representative2;
            Position2 = position2;
            Proxy2 = proxy2;
            Representative3 = representative3;
            Position3 = position3;
            Proxy3 = proxy3;
        }
        public SiteObj(DataRow row)
        {
            SiteId = row["SiteId"].ToString();
            ProvinceId = row["ProvinceId"].ToString();
            TypeOfSite = (row["TypeOfSite"] == null || row["TypeOfSite"] == DBNull.Value) ? "" : row["TypeOfSite"].ToString();
            Headquater = (row["Headquater"] == null || row["Headquater"] == DBNull.Value) ? "" : row["Headquater"].ToString();
            Address = (row["Address"] == null || row["Address"] == DBNull.Value) ? "" : row["Address"].ToString();
            Phonenumber = (row["Phonenumber"] == null || row["Phonenumber"] == DBNull.Value) ? "" : row["Phonenumber"].ToString();
            FaxNumber = (row["FaxNumber"] == null || row["FaxNumber"] == DBNull.Value) ? "" : row["FaxNumber"].ToString();
            TaxCode = (row["TaxCode"] == null || row["TaxCode"] == DBNull.Value) ? "" : row["TaxCode"].ToString();
            BankAccount = (row["BankAccount"] == null || row["BankAccount"] == DBNull.Value) ? "" : row["BankAccount"].ToString();
            NameOfBank = (row["NameOfBank"] == null || row["NameOfBank"] == DBNull.Value) ? "" : row["NameOfBank"].ToString();
            Representative1 = (row["Representative1"] == null || row["Representative1"] == DBNull.Value) ? "" : row["Representative1"].ToString();
            Position1 = (row["Position1"] == null || row["Position1"] == DBNull.Value) ? "" : row["Position1"].ToString();
            Proxy1 = (row["Proxy1"] == null || row["Proxy1"] == DBNull.Value) ? "" : row["Proxy1"].ToString();
            Representative2 = (row["Representative2"] == null || row["Representative2"] == DBNull.Value) ? "" : row["Representative2"].ToString();
            Position2 = (row["Position2"] == null || row["Position2"] == DBNull.Value) ? "" : row["Position2"].ToString();
            Proxy2 = (row["Proxy2"] == null || row["Proxy2"] == DBNull.Value) ? "" : row["Proxy2"].ToString();
            Representative3 = (row["Representative3"] == null || row["Representative3"] == DBNull.Value) ? "" : row["Representative3"].ToString();
            Position3 = (row["Position3"] == null || row["Position3"] == DBNull.Value) ? "" : row["Position3"].ToString();
            Proxy3 = (row["Proxy3"] == null || row["Proxy3"] == DBNull.Value) ? "" : row["Proxy3"].ToString();
        }
        public SiteObj(string id)
        {
            string query = string.Format("SELECT * FROM dbo.Site WHERE SiteId = N'{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                SiteId = row["SiteId"].ToString();
                ProvinceId = row["ProvinceId"].ToString();
                TypeOfSite = (row["TypeOfSite"] == null || row["TypeOfSite"] == DBNull.Value) ? "" : row["TypeOfSite"].ToString();
                Headquater = (row["Headquater"] == null || row["Headquater"] == DBNull.Value) ? "" : row["Headquater"].ToString();
                Address = (row["Address"] == null || row["Address"] == DBNull.Value) ? "" : row["Address"].ToString();
                Phonenumber = (row["Phonenumber"] == null || row["Phonenumber"] == DBNull.Value) ? "" : row["Phonenumber"].ToString();
                FaxNumber = (row["FaxNumber"] == null || row["FaxNumber"] == DBNull.Value) ? "" : row["FaxNumber"].ToString();
                TaxCode = (row["TaxCode"] == null || row["TaxCode"] == DBNull.Value) ? "" : row["TaxCode"].ToString();
                BankAccount = (row["BankAccount"] == null || row["BankAccount"] == DBNull.Value) ? "" : row["BankAccount"].ToString();
                NameOfBank = (row["NameOfBank"] == null || row["NameOfBank"] == DBNull.Value) ? "" : row["NameOfBank"].ToString();
                Representative1 = (row["Representative1"] == null || row["Representative1"] == DBNull.Value) ? "" : row["Representative1"].ToString();
                Position1 = (row["Position1"] == null || row["Position1"] == DBNull.Value) ? "" : row["Position1"].ToString();
                Proxy1 = (row["Proxy1"] == null || row["Proxy1"] == DBNull.Value) ? "" : row["Proxy1"].ToString();
                Representative2 = (row["Representative2"] == null || row["Representative2"] == DBNull.Value) ? "" : row["Representative2"].ToString();
                Position2 = (row["Position2"] == null || row["Position2"] == DBNull.Value) ? "" : row["Position2"].ToString();
                Proxy2 = (row["Proxy2"] == null || row["Proxy2"] == DBNull.Value) ? "" : row["Proxy2"].ToString();
                Representative3 = (row["Representative3"] == null || row["Representative3"] == DBNull.Value) ? "" : row["Representative3"].ToString();
                Position3 = (row["Position3"] == null || row["Position3"] == DBNull.Value) ? "" : row["Position3"].ToString();
                Proxy3 = (row["Proxy3"] == null || row["Proxy3"] == DBNull.Value) ? "" : row["Proxy3"].ToString();
            }
            else
            {
                ProvinceId = id;
                query = string.Format("SELECT * FROM dbo.Site WHERE ProvinceId = N'{0}'", id);
                table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    SiteId = row["SiteId"].ToString();
                    TypeOfSite = (row["TypeOfSite"] == null || row["TypeOfSite"] == DBNull.Value) ? "" : row["TypeOfSite"].ToString();
                    Headquater = (row["Headquater"] == null || row["Headquater"] == DBNull.Value) ? "" : row["Headquater"].ToString();
                    Address = (row["Address"] == null || row["Address"] == DBNull.Value) ? "" : row["Address"].ToString();
                    Phonenumber = (row["Phonenumber"] == null || row["Phonenumber"] == DBNull.Value) ? "" : row["Phonenumber"].ToString();
                    FaxNumber = (row["FaxNumber"] == null || row["FaxNumber"] == DBNull.Value) ? "" : row["FaxNumber"].ToString();
                    TaxCode = (row["TaxCode"] == null || row["TaxCode"] == DBNull.Value) ? "" : row["TaxCode"].ToString();
                    BankAccount = (row["BankAccount"] == null || row["BankAccount"] == DBNull.Value) ? "" : row["BankAccount"].ToString();
                    NameOfBank = (row["NameOfBank"] == null || row["NameOfBank"] == DBNull.Value) ? "" : row["NameOfBank"].ToString();
                    Representative1 = (row["Representative1"] == null || row["Representative1"] == DBNull.Value) ? "" : row["Representative1"].ToString();
                    Position1 = (row["Position1"] == null || row["Position1"] == DBNull.Value) ? "" : row["Position1"].ToString();
                    Proxy1 = (row["Proxy1"] == null || row["Proxy1"] == DBNull.Value) ? "" : row["Proxy1"].ToString();
                    Representative2 = (row["Representative2"] == null || row["Representative2"] == DBNull.Value) ? "" : row["Representative2"].ToString();
                    Position2 = (row["Position2"] == null || row["Position2"] == DBNull.Value) ? "" : row["Position2"].ToString();
                    Proxy2 = (row["Proxy2"] == null || row["Proxy2"] == DBNull.Value) ? "" : row["Proxy2"].ToString();
                    Representative3 = (row["Representative3"] == null || row["Representative3"] == DBNull.Value) ? "" : row["Representative3"].ToString();
                    Position3 = (row["Position3"] == null || row["Position3"] == DBNull.Value) ? "" : row["Position3"].ToString();
                    Proxy3 = (row["Proxy3"] == null || row["Proxy3"] == DBNull.Value) ? "" : row["Proxy3"].ToString();
                }
            }
        }
        public bool Exist()
        {
            string query1 = string.Format("SELECT * FROM dbo.Site WHERE SiteId = N'{0}'", SiteId);
            DataTable table1 = OPMDBHandler.ExecuteQuery(query1);
            string query2 = string.Format("SELECT * FROM dbo.Site WHERE ProvinceId = N'{0}'", ProvinceId);
            DataTable table2 = OPMDBHandler.ExecuteQuery(query2);
            return (table1.Rows.Count > 0) || (table2.Rows.Count > 0);
        }
        public static bool Exist(string id)
        {
            string query1 = string.Format("SELECT * FROM dbo.Site WHERE SiteId = N'{0}'", id);
            DataTable table1 = OPMDBHandler.ExecuteQuery(query1);
            string query2 = string.Format("SELECT * FROM dbo.Site WHERE ProvinceId = N'{0}'", id);
            DataTable table2 = OPMDBHandler.ExecuteQuery(query2);
            return (table1.Rows.Count > 0) || (table2.Rows.Count > 0);
        }
        public static DataTable GetTable()
        {
            string query = string.Format("SELECT * FROM dbo.Site order by TypeOfSite, SiteId");
            return OPMDBHandler.ExecuteQuery(query);
        }

        public static List<SiteObj> GetList()
        {
            List<SiteObj> list = new List<SiteObj>();
            string query = string.Format("SELECT * FROM dbo.Site order by TypeOfSite, SiteId");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                SiteObj site = new SiteObj(item);
                list.Add(site);
            }
            return list;
        }

        public void Update()
        {
            if (SiteId == null)
                MessageBox.Show("Id chưa khởi tạo!");
            else
            {
                string query = string.Format("UPDATE dbo.Site SET TypeOfSite = N'{1}', headquater = N'{2}', address= N'{3}', phonenumber = '{4}',faxnumber = '{5}', taxCode= '{6}', BankAccount = '{7}',representative1 = N'{8}',position1 = N'{9}',proxy1 = N'{10}',representative2 = N'{11}',position2 = N'{12}',proxy2 = N'{13}',representative3 = N'{14}',position3 = N'{15}',proxy3 = N'{16}',NameOfBank = N'{18}' WHERE SiteId = N'{0}' or ProvinceId = N'{17}'", SiteId, TypeOfSite, Headquater, Address, Phonenumber, FaxNumber, TaxCode, BankAccount, Representative1, Position1, Proxy1, Representative2, Position2, Proxy2, Representative3, Position3, Proxy3, ProvinceId, NameOfBank);
                OPMDBHandler.ExecuteNonQuery(query);
            }
        }
        public void Insert()
        {
            string query = string.Format(@"INSERT INTO dbo.Site VALUES(N'{0}',N'{17}',N'{1}',N'{2}',N'{3}','{4}','{5}','{6}','{7}',N'{18}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}')", SiteId, TypeOfSite, Headquater, Address, Phonenumber, FaxNumber, TaxCode, BankAccount, Representative1, Position1, Proxy1, Representative2, Position2, Proxy2, Representative3, Position3, Proxy3, ProvinceId,NameOfBank);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Delete()
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            string query = string.Format("DELETE FROM dbo.Site WHERE SiteId = N'{0}'", SiteId);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
                MessageBox.Show("Bạn đã xoá thành công!");
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
        }
        public static void Delete(string id)
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            string query = string.Format("DELETE FROM dbo.Site WHERE SiteId = N'{0}'", id);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
                MessageBox.Show("Bạn đã xoá thành công!");
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
        }
    }
}
