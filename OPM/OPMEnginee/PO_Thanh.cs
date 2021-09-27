using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.DBHandler
{
    public partial class PO_Thanh
    {
        private string id= "5120/CUVT-KV";
        private string id_contract= "100-2020/CUVT-ANSV/DTRR-KHMS";
        private string po_number= "PO1";
        private Nullable<double> numberofdevice=0;
        private Nullable<System.DateTime> datecreated=DateTime.Now;
        private Nullable<int> priceunit=0;
        private Nullable<System.DateTime> dateconfirm = DateTime.Now;
        private Nullable<System.DateTime> dateperform = DateTime.Now;
        private Nullable<System.DateTime> dateline = DateTime.Now;
        private string targetdeliveradd="Hà Nội";
        private string email_BLBH_status=@"thanhqn80@gmail.com";
        private string email_BLTH_status= @"thanhqn80@gmail.com";
        private Nullable<double> totalvalue=0;
        private Nullable<int> tupo=0;

        public string Id { get => id; set => id = value; }
        public string Id_contract { get => id_contract; set => id_contract = value; }
        public string Po_number { get => po_number; set => po_number = value; }
        public double? Numberofdevice { get => numberofdevice; set => numberofdevice = value; }
        public DateTime? Datecreated { get => datecreated; set => datecreated = value; }
        public int? Priceunit { get => priceunit; set => priceunit = value; }
        public DateTime? Dateconfirm { get => dateconfirm; set => dateconfirm = value; }
        public DateTime? Dateperform { get => dateperform; set => dateperform = value; }
        public DateTime? Dateline { get => dateline; set => dateline = value; }
        public string Targetdeliveradd { get => targetdeliveradd; set => targetdeliveradd = value; }
        public string Email_BLBH_status { get => email_BLBH_status; set => email_BLBH_status = value; }
        public string Email_BLTH_status { get => email_BLTH_status; set => email_BLTH_status = value; }
        public double? Totalvalue { get => totalvalue; set => totalvalue = value; }
        public int? Tupo { get => tupo; set => tupo = value; }
        public PO_Thanh() { }
        public PO_Thanh(string id, string id_contract, string po_number, Nullable<double> numberofdevice, Nullable<System.DateTime> datecreated, Nullable<int> priceunit, Nullable<System.DateTime> dateconfirm, Nullable<System.DateTime> dateperform, Nullable<System.DateTime> dateline, string targetdeliveradd, string email_BLBH_status, string email_BLTH_status, Nullable<double> totalvalue, Nullable<int> tupo)
        {
            Id = id;
            Id_contract = id_contract;
            Po_number = po_number;
            Numberofdevice = numberofdevice;
            Datecreated = datecreated;
            Priceunit = priceunit;
            Dateconfirm = dateconfirm;
            Dateperform = dateperform;
            Dateline = dateline;
            Targetdeliveradd = targetdeliveradd;
            Email_BLBH_status = email_BLBH_status;
            Email_BLTH_status = email_BLTH_status;
            Totalvalue = totalvalue;
            Tupo = tupo;
        }
        public PO_Thanh(DataRow row)
        {
            Id = row["id"].ToString();
            Id_contract = row["id_contract"].ToString();
            Po_number = row["po_number"].ToString();
            Numberofdevice = (double)row["numberofdevice"];
            Datecreated = (DateTime)row["datecreated"];
            Priceunit = (int)row["priceunit"];
            Dateconfirm = (DateTime)row["dateconfirm"];
            Dateperform = (DateTime)row["dateperform"];
            Dateline = (DateTime)row["dateline"];
            Targetdeliveradd = row["targetdeliveradd"].ToString();
            Email_BLBH_status = row["email_BLBH_status"].ToString();
            Email_BLTH_status = row["email_BLTH_status"].ToString();
            Totalvalue = (double)row["totalvalue"];
            Tupo = (int)row["tupo"];
        }
        public PO_Thanh(string id)
        {
            Id = id;
            string query = string.Format("SELECT * FROM dbo.PO WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Id_contract = row["id_contract"].ToString();
                Po_number = row["po_number"].ToString();
                Numberofdevice = (double)row["numberofdevice"];
                Datecreated = (DateTime)row["datecreated"];
                Priceunit = (int)row["priceunit"];
                Dateconfirm = (DateTime)row["dateconfirm"];
                Dateperform = (DateTime)row["dateperform"];
                Dateline = (DateTime)row["dateline"];
                Targetdeliveradd = row["targetdeliveradd"].ToString();
                Email_BLBH_status = row["email_BLBH_status"].ToString();
                Email_BLTH_status = row["email_BLTH_status"].ToString();
                Totalvalue = (double)row["totalvalue"];
                Tupo = (row["tupo"]==null)||(DBNull.Value==row["tupo"])?0: (int)row["tupo"];
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.PO WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public bool Exist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.PO WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public List<PO_Thanh> GetList()
        {
            List<PO_Thanh> list = new List<PO_Thanh>();
            string query = string.Format("SELECT * FROM dbo.PO");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                PO_Thanh po = new PO_Thanh(item);
                list.Add(po);
            }
            return list;
        }
        public void InsertOrUpdate()
        {
            if (id == null)
                MessageBox.Show("Id chưa khởi tạo!");
            else
            {
                if (Exist(id))
                {
                    string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO SET id_contract = '{1}', po_number = {2}, numberofdevice = {3}, datecreated = '{4}', priceunit = {5},dateconfirm = '{6}',dateperform = {7},dateline = {8},targetdeliveradd = '{9}',email_BLBH_status = '{10}',email_BLTH_status = '{11}',totalvalue = {12},tupo = {13} WHERE id = '{0}'", id, id_contract, po_number, numberofdevice, datecreated, priceunit, dateconfirm, dateperform, dateline, targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo);
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("SET DATEFORMAT DMY Cập nhật thành công hợp đồng {0} !", id));
                }
                else
                {
                    string query = string.Format(@"INSERT INTO dbo.Contract(id, id_contract, po_number, numberofdevice, datecreated, priceunit, dateconfirm, dateperform, dateline, targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo) VALUES('{0}','{1}',{2},'{3}','{4}',{5},'{6}',{7},{8},N'{9}','{10}','{11}','{12}','{13}')", id, id_contract, po_number, numberofdevice, datecreated, priceunit, dateconfirm, dateperform, dateline, targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo);
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Tạo mới thành công hợp đồng {0} !", id));
                }
            }
        }
        public void InsertOrUpdate(string id)
        {
            if (id == null)
                MessageBox.Show("Id chưa khởi tạo!");
            else
            {
                if (Exist(id))
                {
                    string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO SET id_contract = '{1}', po_number = {2}, numberofdevice = {3}, datecreated = '{4}', priceunit = {5},dateconfirm = '{6}',dateperform = {7},dateline = {8},targetdeliveradd = '{9}',email_BLBH_status = '{10}',email_BLTH_status = '{11}',totalvalue = {12},tupo = {13} WHERE id = '{0}'", id, id_contract, po_number, numberofdevice, datecreated, priceunit, dateconfirm, dateperform, dateline, targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo);
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Cập nhật thành công PO {0} !", id));
                }
                else
                {
                    string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Contract(id, id_contract, po_number, numberofdevice, datecreated, priceunit, dateconfirm, dateperform, dateline, targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo) VALUES('{0}','{1}',{2},'{3}','{4}',{5},'{6}',{7},{8},N'{9}','{10}','{11}','{12}','{13}')", id, id_contract, po_number, numberofdevice, datecreated, priceunit, dateconfirm, dateperform, dateline, targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo);
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Tạo mới thành công PO {0} !", id));
                }
            }
        }
        public int Delete()
        {
            int result = 0;
            MessageBox.Show(string.Format("Có chắc chắn xoá PO: {0} không?", id), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string query = string.Format("DELETE FROM dbo.PO WHERE id = '{0}'", id);
            try
            {
                result = OPMDBHandler.ExecuteNonQuery(query);
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
            if (result != 0) MessageBox.Show("Bạn đã xoá thành công!");
            return result;
        }
        public int Delete(string id)
        {
            int result = 0;
            MessageBox.Show(string.Format("Có chắc chắn xoá PO: {0} không?", id), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string query = string.Format("DELETE FROM dbo.PO WHERE id = '{0}'", id);
            try
            {
                result = OPMDBHandler.ExecuteNonQuery(query);
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
            if (result != 0) MessageBox.Show("Bạn đã xoá thành công!");
            return result;
        }

    }
}
