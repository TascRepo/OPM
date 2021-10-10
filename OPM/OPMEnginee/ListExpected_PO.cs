using OPM.DBHandler;
using System;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class ListExpected_PO
    {
        private string idPO;
        private string idProvince;
        private int numberOfDevice;
        private string nameOfDevice;

        public string IdPO { get => idPO; set => idPO = value; }
        public string IdProvince { get => idProvince; set => idProvince = value; }
        public int NumberOfDevice { get => numberOfDevice; set => numberOfDevice = value; }
        public string NameOfDevice { get => nameOfDevice; set => nameOfDevice = value; }
        public ListExpected_PO(string id_po, string id_province, int numberofdevice, string nameofdevice)
        {
            idPO = id_po;
            idProvince = id_province;
            NumberOfDevice = numberofdevice;
            NameOfDevice = nameofdevice;
        }
        public ListExpected_PO(DataRow row)
        {
            IdPO = row["id_po"].ToString();
            IdProvince = row["id_province"].ToString();
            NumberOfDevice = (row["numberofdevice"] == null || row["numberofdevice"] == DBNull.Value) ? 0 : int.Parse(row["numberofdevice"].ToString());
            NameOfDevice = (row["nameofdevice"] == null || row["nameofdevice"] == DBNull.Value) ? "" : row["nameofdevice"].ToString();
        }
        public ListExpected_PO() { }
        public ListExpected_PO(string idPO, string idProvince)
        {
            IdPO = idPO;
            IdProvince = idProvince;
            string query = string.Format("SELECT * FROM dbo.ListExpected_PO WHERE id_po = '{0}' and id_province = {1}", idPO, idProvince);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    NumberOfDevice = (row["numberofdevice"] == null || row["numberofdevice"] == DBNull.Value) ? 0 : int.Parse(row["numberofdevice"].ToString());
                    NameOfDevice = row["nameofdevice"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không lấy được dữ liệu");
                return;
            }
        }

        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.ListExpected_PO WHERE id_po = '{0}' and id_province = N'{1}'", idPO, idProvince);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                return table.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Không lấy được dữ liệu");
            }
            return false;
        }
        public static bool Exist(string idPO, string idProvince)
        {
            string query = string.Format("SELECT * FROM dbo.ListExpected_PO WHERE id_po = '{0}' and id_province = N'{1}'", idPO, idProvince);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                return table.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Không lấy được dữ liệu");
            }
            return false;
        }

        public void InsertOrUpdate()
        {
            if (idPO == null || idProvince == null)
            {
                MessageBox.Show("Thêm mới thất bại vì chưa có idPO hoặc IdProvince!");
                return;
            }
            if (Exist(idPO, idProvince))
            {
                string query = string.Format(@"INSERT INTO dbo.ListExpected_PO(id_po,id_province,numberofdevice,nameofdevice) VALUES('{0}',N'{1}',{2},'{3}'", idPO, idProvince, numberOfDevice, nameOfDevice);
                try
                {
                    OPMDBHandler.ExecuteNonQuery(query);
                }
                catch
                {
                    MessageBox.Show("Thêm mới thất bại!");
                }

            }
            else
            {
                string query = string.Format("UPDATE dbo.ListExpected_PO SET numberofdevice =  {2}, nameofdevice = N'{3}' WHERE id_po = '{0}' and id_province = {1}", idPO, idProvince, numberOfDevice, nameOfDevice);
                try
                {
                    OPMDBHandler.ExecuteNonQuery(query);
                }
                catch
                {
                    MessageBox.Show("cập nhật thất bại!");
                }
            }
        }
        public static void Delete(string id_po, string id_province)
        {
            if (id_po == null || id_province == null)
            {
                MessageBox.Show("Xoá thất bại vì chưa có idPO hoặc IdProvince!");
                return;
            }
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            string query = string.Format(" DELETE FROM dbo.ListExpected_PO WHERE id_po = '{0}' and id_province = N'{1}'", id_po, id_province);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
        }

    }
}
