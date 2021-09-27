using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    class Site_Info
    {
        string id = "Công ty TNHH thiết bị viễn thông ANSV";
        string type = "0300954529";
        string headquater_info = "124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội";
        string address = "124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội";
        string phonenumber= "02835282338";
        string tin= "02433861195";
        string account= "0071001103933";
        string representative="Ông Nguyễn Văn Nam - Tổng giám đốc";

        public string Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public string Headquater_info { get => headquater_info; set => headquater_info = value; }
        public string Address { get => address; set => address = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Tin { get => tin; set => tin = value; }
        public string Account { get => account; set => account = value; }
        public string Representative { get => representative; set => representative = value; }

        public Site_Info() { }
        public Site_Info(string id,string type,string headquater_info,string address,string phonenumber,string tin,string account,string representative) 
        {
            Id = id;
            Type = type;
            Headquater_info = headquater_info;
            Address = address;
            Phonenumber = phonenumber;
            Tin = tin;
            Account = account;
            Representative = representative;
        }
        public Site_Info(DataRow row)
        {
            Id = row["id"].ToString();
            Type = row["type"].ToString();
            Headquater_info = row["headquater_info"].ToString();
            Address = row["address"].ToString();
            Phonenumber = row["phonenumber"].ToString();
            Tin = row["tin"].ToString();
            Account = row["account"].ToString();
            Representative = row["representative"].ToString();
        }
        public Site_Info(string id)
        {
            Id = id;
            string query = string.Format("SELECT * FROM dbo.Site_Info WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Id = row["id"].ToString();
                Type = row["type"].ToString();
                Headquater_info = row["headquater_info"].ToString();
                Address = row["address"].ToString();
                Phonenumber = row["phonenumber"].ToString();
                Tin = row["tin"].ToString();
                Account = row["account"].ToString();
                Representative = row["representative"].ToString();
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.Site_Info WHERE id = N'{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool Exist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.Site_Info WHERE id = N'{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static DataTable GetTable()
        {
            string query = string.Format("SELECT * FROM dbo.Site_Info");
            return OPMDBHandler.ExecuteQuery(query);
        }

        public static List<Site_Info> GetList()
        {
            List<Site_Info> list = new List<Site_Info>();
            string query = string.Format("SELECT * FROM dbo.Site_Info");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                Site_Info po = new Site_Info(item);
                list.Add(po);
            }
            return list;
        }
        public void Update()
        {
            if (id == null)
                MessageBox.Show("Id chưa khởi tạo!");
            else
            {
                string query = string.Format("UPDATE dbo.Site_Info SET type = '{1}', headquater_info = N'{2}', address= N'{3}', phonenumber = '{4}', tin= '{5}', account = '{6}',representative = N'{7}' WHERE id = N'{0}'", id, type, headquater_info, address, phonenumber, tin, account, representative);
                try
                {
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Cập nhật thành công Site_Info {0} !", id));
                }
                catch
                {
                    MessageBox.Show("Xoá thất bại!");
                }
            }
        }
        public void Insert()
        {
            string query = string.Format(@"INSERT INTO dbo.Site_Info(id, type, headquater_info, address, phonenumber, tin, account, representative) VALUES(N'{0}','{1}',N'{2}',N'{3}','{4}','{5}','{6}',N'{7}')", id, type, headquater_info, address, phonenumber, tin, account, representative);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
                MessageBox.Show(string.Format("Thêm mới thành công Site_Info {0} !", id));
            }
            catch
            {
                MessageBox.Show("Thêm mới thất bại!");
            }
        }
        public void Delete()
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return; 
            string query = string.Format("DELETE FROM dbo.Site_Info WHERE id = N'{0}'", id);
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
        public static void Delete(int stt)
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            string query = string.Format("DELETE FROM dbo.Site_Info WHERE stt = {0}", stt);
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
