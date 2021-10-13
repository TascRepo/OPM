using OPM.DBHandler;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class NTKT_Thanh
    {
        private string id = "1320/ANSV-DO";
        private string id_po = "5120/CUVT-KV";
        private int numberofdevice = 0;
        private DateTime deliver_date_expected = DateTime.Now;
        private string email_request_status = "";
        private DateTime create_date = DateTime.Now;
        private int numberofdevice2 = 0;
        private int number = 1;
        private DateTime date_BBKTKT = DateTime.Now;
        private DateTime date_BBNTKT = DateTime.Now;
        private DateTime date_CNBQPM = DateTime.Now;

        public string Id { get => id; set => id = value; }
        public string Id_po { get => id_po; set => id_po = value; }
        public int Numberofdevice { get => numberofdevice; set => numberofdevice = value; }
        public DateTime Deliver_date_expected { get => deliver_date_expected; set => deliver_date_expected = value; }
        public string Email_request_status { get => email_request_status; set => email_request_status = value; }
        public DateTime Create_date { get => create_date; set => create_date = value; }
        public int Numberofdevice2 { get => numberofdevice2; set => numberofdevice2 = value; }
        public int Number { get => number; set => number = value; }
        public DateTime Date_BBKTKT { get => date_BBKTKT; set => date_BBKTKT = value; }
        public DateTime Date_BBNTKT { get => date_BBNTKT; set => date_BBNTKT = value; }
        public DateTime Date_CNBQPM { get => date_CNBQPM; set => date_CNBQPM = value; }

        public NTKT_Thanh(string id, string id_po, int numberofdevice, DateTime deliver_date_expected, string email_request_status, DateTime create_date, int numberofdevice2, int number, DateTime date_BBKTKT, DateTime date_BBNTKT, DateTime date_CNBQPM)
        {
            Id = id;
            Id_po = id_po;
            Numberofdevice = numberofdevice;
            Deliver_date_expected = deliver_date_expected;
            Email_request_status = email_request_status;
            Create_date = create_date;
            Numberofdevice2 = numberofdevice2;
            Number = number;
            Date_BBKTKT = date_BBKTKT;
            Date_BBNTKT = date_BBNTKT;
            Date_CNBQPM = date_CNBQPM;
        }
        public NTKT_Thanh(DataRow row)
        {
            Id = row["id"].ToString();
            Id_po = row["id_po"].ToString();
            Numberofdevice = (row["numberofdevice"] == null || row["numberofdevice"] == DBNull.Value) ? 0 : (int)row["numberofdevice"];
            Deliver_date_expected = (row["deliver_date_expected"] == null || row["deliver_date_expected"] == DBNull.Value) ? DateTime.Now : (DateTime)row["deliver_date_expected"];
            Email_request_status = (row["email_request_status"] == null || row["email_request_status"] == DBNull.Value) ? "" : row["email_request_status"].ToString();
            Create_date = (row["create_date"] == null || row["create_date"] == DBNull.Value) ? DateTime.Now : (DateTime)row["create_date"];
            Numberofdevice2 = (row["Numberofdevice2"] == null || row["Numberofdevice2"] == DBNull.Value) ? 0 : (int)row["Numberofdevice2"];
            Number = (row["number"] == null || row["number"] == DBNull.Value) ? 0 : (int)row["number"];
            Date_BBKTKT = (row["date_BBKTKT"] == null || row["date_BBKTKT"] == DBNull.Value) ? DateTime.Now : (DateTime)row["date_BBKTKT"];
            Date_BBNTKT = (row["date_BBNTKT"] == null || row["date_BBNTKT"] == DBNull.Value) ? DateTime.Now : (DateTime)row["date_BBNTKT"];
            Date_CNBQPM = (row["date_CNBQPM"] == null || row["date_CNBQPM"] == DBNull.Value) ? DateTime.Now : (DateTime)row["date_CNBQPM"];
        }
        public NTKT_Thanh(string id)
        {
            string query = string.Format("SELECT * FROM dbo.NTKT WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Id = id;
                Id_po = row["id_po"].ToString();
                Numberofdevice = (row["numberofdevice"] == null || row["numberofdevice"] == DBNull.Value) ? 0 : (int)row["numberofdevice"];
                Deliver_date_expected = (row["deliver_date_expected"] == null || row["deliver_date_expected"] == DBNull.Value) ? DateTime.Now : (DateTime)row["deliver_date_expected"];
                Email_request_status = (row["email_request_status"] == null || row["email_request_status"] == DBNull.Value) ? "" : row["email_request_status"].ToString();
                Create_date = (row["create_date"] == null || row["create_date"] == DBNull.Value) ? DateTime.Now : (DateTime)row["create_date"];
                Numberofdevice2 = (row["Numberofdevice2"] == null || row["Numberofdevice2"] == DBNull.Value) ? 0 : (int)row["Numberofdevice2"];
                Number = (row["number"] == null || row["number"] == DBNull.Value) ? 0 : (int)row["number"];
                Date_BBKTKT = (row["date_BBKTKT"] == null || row["date_BBKTKT"] == DBNull.Value) ? DateTime.Now : (DateTime)row["date_BBKTKT"];
                Date_BBNTKT = (row["date_BBNTKT"] == null || row["date_BBNTKT"] == DBNull.Value) ? DateTime.Now : (DateTime)row["date_BBNTKT"];
                Date_CNBQPM = (row["date_CNBQPM"] == null || row["date_CNBQPM"] == DBNull.Value) ? DateTime.Now : (DateTime)row["date_CNBQPM"];
            }
        }
        public NTKT_Thanh() { }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.NTKT WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool Exist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.NTKT WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public void InsertOrUpdate()
        {
            if (id == null)
                MessageBox.Show("Id chưa khởi tạo!");
            else
            {
                if (Exist(id))
                {
                    string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.NTKT SET  id_po = '{1}', numberofdevice = {2}, deliver_date_expected = '{3}', email_request_status = '{4}', create_date = '{5}', Numberofdevice2 = {6}, number = {7}, date_BBNTKT = '{8}', date_BBKTKT = '{9}',date_CNBQPM = '{10}' Where id = '{0}'", id, id_po, numberofdevice, deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), email_request_status, create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), Numberofdevice2, number, date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), date_CNBQPM.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                    try
                    {
                        OPMDBHandler.ExecuteNonQuery(query);
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("Cập nhật KHÔNG THÀNH CÔNG NTKT {0} của PO {1}!", id, id_po));
                        return;
                    }
                }
                else
                {
                    string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.NTKT(id,id_po,numberofdevice,deliver_date_expected,email_request_status,create_date,numberofdevice2,number,date_BBNTKT,date_BBKTKT,date_CNBQPM)VALUES('{0}','{1}', {2}, '{3}', '{4}', '{5}', {6}, {7}, '{8}', '{9}','{10}')", id, id_po, numberofdevice, deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), email_request_status, create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), Numberofdevice2, number, date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), date_CNBQPM.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                    try
                    {
                        OPMDBHandler.ExecuteNonQuery(query);
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("Tạo mới KHÔNG THÀNH CÔNG NTKT {0} của PO {1}!", id, id_po));
                        return;
                    }
                }
            }
        }
        public void Delete()
        {
            string query = string.Format("Delete FROM dbo.NTKT WHERE id = '{0}'", id);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);

            }
            catch
            {
                MessageBox.Show(string.Format("Không xoá được NTKT số {0}", id));
                return;
            }
        }

        public static void Delete(string id)
        {
            string query = string.Format("Delete FROM dbo.NTKT WHERE id = '{0}'", id);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);

            }
            catch
            {
                MessageBox.Show(string.Format("Không xoá được NTKT số {0}", id));
                return;
            }
        }
    }
}
