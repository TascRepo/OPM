using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class Site
    {
        string id = "Công ty TNHH thiết bị viễn thông ANSV";
        string idVNPT = "ANSV";
        string type = "Site A";
        string headquater = "124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội";
        string address = "124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội";
        string phonenumber = "02438362094";
        string fax = "02433861195";
        string tax = "0100113871";
        string account = "0071001103933";
        string representative1 = "Ông Nguyễn Văn Nam";
        string position1 = "Tổng giám đốc";
        string proxy1 = "";
        string representative2 = "";
        string position2 = "";
        string proxy2 = "";
        string representative3 = "";
        string position3 = "";
        string proxy3 = "";

        public string Id { get => id; set => id = value; }
        public string IdVNPT { get => idVNPT; set => idVNPT = value; }
        public string Type { get => type; set => type = value; }
        public string Headquater { get => headquater; set => headquater = value; }
        public string Address { get => address; set => address = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Tax { get => tax; set => tax = value; }
        public string Account { get => account; set => account = value; }
        public string Representative1 { get => representative1; set => representative1 = value; }
        public string Position1 { get => position1; set => position1 = value; }
        public string Proxy1 { get => proxy1; set => proxy1 = value; }
        public string Representative2 { get => representative2; set => representative2 = value; }
        public string Position2 { get => position2; set => position2 = value; }
        public string Proxy2 { get => proxy2; set => proxy2 = value; }
        public string Representative3 { get => representative3; set => representative3 = value; }
        public string Position3 { get => position3; set => position3 = value; }
        public string Proxy3 { get => proxy3; set => proxy3 = value; }

        public Site() { }
        public Site(string id,string idVNPT, string type, string headquater, string address, string phonenumber, string fax, string tax, string account, string representative1, string position1, string proxy1, string representative2, string position2, string proxy2, string representative3, string position3, string proxy3)
        {
            Id = id;
            IdVNPT = idVNPT;
            Type = type;
            Headquater = headquater;
            Address = address;
            Phonenumber = phonenumber;
            Fax = fax;
            Tax = tax;
            Account = account;
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
        public Site(DataRow row)
        {
            Id = row["id"].ToString();
            IdVNPT= row["IdVNPT"].ToString();
            Type = (row["Type"] == null || row["Type"] == DBNull.Value) ? "" : row["Type"].ToString();
            Headquater = (row["Headquater"] == null || row["Headquater"] == DBNull.Value) ? "" : row["Headquater"].ToString();
            Address = (row["Address"] == null || row["Address"] == DBNull.Value) ? "" : row["Address"].ToString();
            Phonenumber = (row["Phonenumber"] == null || row["Phonenumber"] == DBNull.Value) ? "" : row["Phonenumber"].ToString();
            Fax = (row["Fax"] == null || row["Fax"] == DBNull.Value) ? "" : row["Fax"].ToString();
            Tax = (row["Tax"] == null || row["Tax"] == DBNull.Value) ? "" : row["Tax"].ToString();
            Account = (row["Account"] == null || row["Account"] == DBNull.Value) ? "" : row["Account"].ToString();
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
        public Site(string id)
        {
            string query = string.Format("SELECT * FROM dbo.Site WHERE id = N'{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Id = row["Id"].ToString();
                IdVNPT = row["IdVNPT"].ToString();
                Type = (row["Type"] == null || row["Type"] == DBNull.Value) ? "" : row["Type"].ToString();
                Headquater = (row["Headquater"] == null || row["Headquater"] == DBNull.Value) ? "" : row["Headquater"].ToString();
                Address = (row["Address"] == null || row["Address"] == DBNull.Value) ? "" : row["Address"].ToString();
                Phonenumber = (row["Phonenumber"] == null || row["Phonenumber"] == DBNull.Value) ? "" : row["Phonenumber"].ToString();
                Fax = (row["Fax"] == null || row["Fax"] == DBNull.Value) ? "" : row["Fax"].ToString();
                Tax = (row["Tax"] == null || row["Tax"] == DBNull.Value) ? "" : row["Tax"].ToString();
                Account = (row["Account"] == null || row["Account"] == DBNull.Value) ? "" : row["Account"].ToString();
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
                IdVNPT = id;
                query = string.Format("SELECT * FROM dbo.Site WHERE idVNPT = N'{0}'", id);
                table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    Id = row["Id"].ToString();
                    Type = (row["Type"] == null || row["Type"] == DBNull.Value) ? "" : row["Type"].ToString();
                    Headquater = (row["Headquater"] == null || row["Headquater"] == DBNull.Value) ? "" : row["Headquater"].ToString();
                    Address = (row["Address"] == null || row["Address"] == DBNull.Value) ? "" : row["Address"].ToString();
                    Phonenumber = (row["Phonenumber"] == null || row["Phonenumber"] == DBNull.Value) ? "" : row["Phonenumber"].ToString();
                    Fax = (row["Fax"] == null || row["Fax"] == DBNull.Value) ? "" : row["Fax"].ToString();
                    Tax = (row["Tax"] == null || row["Tax"] == DBNull.Value) ? "" : row["Tax"].ToString();
                    Account = (row["Account"] == null || row["Account"] == DBNull.Value) ? "" : row["Account"].ToString();
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
            string query1 = string.Format("SELECT * FROM dbo.Site WHERE id = N'{0}'", id);
            DataTable table1 = OPMDBHandler.ExecuteQuery(query1);
            string query2 = string.Format("SELECT * FROM dbo.Site WHERE idVNPT = N'{0}'", idVNPT);
            DataTable table2 = OPMDBHandler.ExecuteQuery(query2);
            return (table1.Rows.Count > 0)|| (table2.Rows.Count > 0);
        }
        public static bool Exist(string id)
        {
            string query1 = string.Format("SELECT * FROM dbo.Site WHERE id = N'{0}'", id);
            DataTable table1 = OPMDBHandler.ExecuteQuery(query1);
            string query2 = string.Format("SELECT * FROM dbo.Site WHERE idVNPT = N'{0}'", id);
            DataTable table2 = OPMDBHandler.ExecuteQuery(query2);
            return (table1.Rows.Count > 0) || (table2.Rows.Count > 0);
        }
        public static DataTable GetTable()
        {
            string query = string.Format("SELECT * FROM dbo.Site order by type, id");
            return OPMDBHandler.ExecuteQuery(query);
        }

        public static List<Site> GetList()
        {
            List<Site> list = new List<Site>();
            string query = string.Format("SELECT * FROM dbo.Site order by type, id");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                Site site = new Site(item);
                list.Add(site);
            }
            return list;
        }

        public void Update()
        {
            if (Id == null)
                MessageBox.Show("Id chưa khởi tạo!");
            else
            {
                string query = string.Format("UPDATE dbo.Site SET type = N'{1}', headquater = N'{2}', address= N'{3}', phonenumber = '{4}',fax = '{5}', tax= '{6}', account = '{7}',representative1 = N'{8}',position1 = N'{9}',proxy1 = N'{10}',representative2 = N'{11}',position2 = N'{12}',proxy2 = N'{13}',representative3 = N'{14}',position3 = N'{15}',proxy3 = N'{16}' WHERE id = N'{0}' or idVNPT = N'{17}'", id, type, headquater, address, phonenumber, fax, tax, account, representative1, position1, proxy1, representative2, position2, proxy2, representative3, position3, proxy3,idVNPT);
                OPMDBHandler.ExecuteNonQuery(query);
            }
        }
        public void Insert()
        {
            string query = string.Format(@"INSERT INTO dbo.Site VALUES(N'{0}',N'{17}',N'{1}',N'{2}',N'{3}','{4}','{5}','{6}','{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}')", id, type, headquater, address, phonenumber, fax, tax, account, representative1, position1, proxy1, representative2, position2, proxy2, representative3, position3, proxy3,idVNPT);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Delete()
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            string query = string.Format("DELETE FROM dbo.Site WHERE id = N'{0}'", Id);
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
            string query = string.Format("DELETE FROM dbo.Site WHERE id = N'{0}'", id);
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
