using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.DBHandler
{
    public partial class PO_Thanh
    {
        private string id = "5120/CUVT-KV";
        private string id_contract = "111-2020/CUVT-ANSV/DTRR-KHMS";
        private string po_number = "PO1";
        private double numberofdevice = 0;
        private DateTime datecreated = DateTime.Now;
        private int priceunit = 0;
        private DateTime dateconfirm = DateTime.Now;
        private DateTime dateperform = DateTime.Now;
        private DateTime dateline = DateTime.Now;
        private string targetdeliveradd = "Hà Nội";
        private string email_BLBH_status = "";
        private string email_BLTH_status = "";
        private double totalvalue = 0;
        private int tupo = 50;
        private DateTime tupo_datecreated = DateTime.Now;
        private string confirmpo_number = "679/ANSV-DO";
        private DateTime confirmpo_datecreated = DateTime.Now;
        private int bltupo = 5;
        private DateTime bltupo_datecreated = DateTime.Now;
        private DateTime confirmpo_dateactive = DateTime.Now;
        public string Id { get => id; set => id = value; }
        public string Id_contract { get => id_contract; set => id_contract = value; }
        public string Po_number { get => po_number; set => po_number = value; }
        public double Numberofdevice { get => numberofdevice; set => numberofdevice = value; }
        public DateTime Datecreated { get => datecreated; set => datecreated = value; }
        public int Priceunit { get => priceunit; set => priceunit = value; }
        public DateTime Dateconfirm { get => dateconfirm; set => dateconfirm = value; }
        public DateTime Dateperform { get => dateperform; set => dateperform = value; }
        public DateTime Dateline { get => dateline; set => dateline = value; }
        public string Targetdeliveradd { get => targetdeliveradd; set => targetdeliveradd = value; }
        public string Email_BLBH_status { get => email_BLBH_status; set => email_BLBH_status = value; }
        public string Email_BLTH_status { get => email_BLTH_status; set => email_BLTH_status = value; }
        public double Totalvalue { get => totalvalue; set => totalvalue = value; }
        public int Tupo { get => tupo; set => tupo = value; }
        public DateTime Tupo_datecreated { get => tupo_datecreated; set => tupo_datecreated = value; }
        public string Confirmpo_number { get => confirmpo_number; set => confirmpo_number = value; }
        public DateTime Confirmpo_datecreated { get => confirmpo_datecreated; set => confirmpo_datecreated = value; }
        public int Bltupo { get => bltupo; set => bltupo = value; }
        public DateTime Bltupo_datecreated { get => bltupo_datecreated; set => bltupo_datecreated = value; }
        public DateTime Confirmpo_dateactive { get => confirmpo_dateactive; set => confirmpo_dateactive = value; }

        public PO_Thanh() { }
        public PO_Thanh(string id, string id_contract, string po_number, double numberofdevice, DateTime datecreated, int priceunit, DateTime dateconfirm, DateTime dateperform, DateTime dateline, string targetdeliveradd, string email_BLBH_status, string email_BLTH_status, double totalvalue, int tupo, DateTime tupo_datecreated, string confirmpo_number, DateTime confirmpo_datecreated, int bltupo, DateTime bltupo_datecreated, DateTime confirmpo_dateactive)
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
            Tupo_datecreated = tupo_datecreated;
            Confirmpo_number = confirmpo_number;
            Confirmpo_datecreated = confirmpo_datecreated;
            Bltupo = bltupo;
            Bltupo_datecreated = bltupo_datecreated;
            Confirmpo_dateactive = confirmpo_dateactive;
        }
        public int GetDetailPO(string strQueryOne)
        {
            string strQuery = "select * from PO where id=" + "/'" + strQueryOne + "/'";
            PO_Thanh newPO = new PO_Thanh();
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQuery, ref ds);
            if (0 != ds.Tables.Count)
            {
                newPO.Id = (string)ds.Tables[0].Rows[0].ItemArray[0];
            }
            else
            {
                return 0;
            }
            return 1;
        }
        public PO_Thanh(DataRow row)
        {
            Id = row["id"].ToString();
            Id_contract = (row["id_contract"] == null || row["id_contract"] == DBNull.Value) ? "" : row["id_contract"].ToString();
            Po_number = (row["po_number"] == null || row["po_number"] == DBNull.Value) ? "" : row["po_number"].ToString();
            Numberofdevice = (row["numberofdevice"] == null || row["numberofdevice"] == DBNull.Value) ? 0 : (double)row["numberofdevice"];
            Datecreated = (row["datecreated"] == null || row["datecreated"] == DBNull.Value) ? DateTime.Now : (DateTime)row["datecreated"];
            Priceunit = (row["priceunit"] == null || row["priceunit"] == DBNull.Value) ? 0 : (int)row["priceunit"];
            Dateconfirm = (row["dateconfirm"] == null || row["dateconfirm"] == DBNull.Value) ? DateTime.Now : (DateTime)row["dateconfirm"];
            Dateperform = (row["dateperform"] == null || row["dateperform"] == DBNull.Value) ? DateTime.Now : (DateTime)row["dateperform"];
            Dateline = (row["dateline"] == null || row["dateline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["dateline"];
            Targetdeliveradd = (row["targetdeliveradd"] == null || row["targetdeliveradd"] == DBNull.Value) ? "" : row["targetdeliveradd"].ToString();
            Email_BLBH_status = (row["email_BLBH_status"] == null || row["email_BLBH_status"] == DBNull.Value) ? "" : row["email_BLBH_status"].ToString();
            Email_BLTH_status = (row["email_BLTH_status"] == null || row["email_BLTH_status"] == DBNull.Value) ? "" : row["email_BLTH_status"].ToString();
            Totalvalue = (row["totalvalue"] == null || row["totalvalue"] == DBNull.Value) ? 0 : (double)row["totalvalue"];
            Tupo = (row["tupo"] == null || row["tupo"] == DBNull.Value) ? 0 : (int)row["tupo"];
            Tupo_datecreated = (row["tupo_datecreated"] == null || row["tupo_datecreated"] == DBNull.Value) ? DateTime.Now : (DateTime)row["tupo_datecreated"];
            Confirmpo_number = (row["confirmpo_number"] == null || row["confirmpo_number"] == DBNull.Value) ? "" : row["confirmpo_number"].ToString();
            Confirmpo_datecreated = (row["confirmpo_datecreated"] == null || row["confirmpo_datecreated"] == DBNull.Value) ? DateTime.Now : (DateTime)row["confirmpo_datecreated"];
            Bltupo = (row["bltupo"] == null || row["bltupo"] == DBNull.Value) ? 0 : (int)row["bltupo"];
            Bltupo_datecreated = (row["bltupo_datecreated"] == null || row["bltupo_datecreated"] == DBNull.Value) ? DateTime.Now : (DateTime)row["bltupo_datecreated"];
            Confirmpo_dateactive = (row["confirmpo_dateactive"] == null || row["confirmpo_dateactive"] == DBNull.Value) ? DateTime.Now : (DateTime)row["confirmpo_dateactive"];
        }
        public PO_Thanh(string id)
        {
            Id = id;
            string query = string.Format("SELECT * FROM dbo.PO WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Id_contract = (row["id_contract"] == null || row["id_contract"] == DBNull.Value) ? "" : row["id_contract"].ToString();
                Po_number = (row["po_number"] == null || row["po_number"] == DBNull.Value) ? "" : row["po_number"].ToString();
                Numberofdevice = (row["numberofdevice"] == null || row["numberofdevice"] == DBNull.Value) ? 0 : (double)row["numberofdevice"];
                Datecreated = (row["datecreated"] == null || row["datecreated"] == DBNull.Value) ? DateTime.Now : (DateTime)row["datecreated"];
                Priceunit = (row["priceunit"] == null || row["priceunit"] == DBNull.Value) ? 0 : (int)row["priceunit"];
                Dateconfirm = (row["dateconfirm"] == null || row["dateconfirm"] == DBNull.Value) ? DateTime.Now : (DateTime)row["dateconfirm"];
                Dateperform = (row["dateperform"] == null || row["dateperform"] == DBNull.Value) ? DateTime.Now : (DateTime)row["dateperform"];
                Dateline = (row["dateline"] == null || row["dateline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["dateline"];
                Targetdeliveradd = (row["targetdeliveradd"] == null || row["targetdeliveradd"] == DBNull.Value) ? "" : row["targetdeliveradd"].ToString();
                Email_BLBH_status = (row["email_BLBH_status"] == null || row["email_BLBH_status"] == DBNull.Value) ? "" : row["email_BLBH_status"].ToString();
                Email_BLTH_status = (row["email_BLTH_status"] == null || row["email_BLTH_status"] == DBNull.Value) ? "" : row["email_BLTH_status"].ToString();
                Totalvalue = (row["totalvalue"] == null || row["totalvalue"] == DBNull.Value) ? 0 : (double)row["totalvalue"];
                Tupo = (row["tupo"] == null || row["tupo"] == DBNull.Value) ? 0 : (int)row["tupo"];
                Tupo_datecreated = (row["tupo_datecreated"] == null || row["tupo_datecreated"] == DBNull.Value) ? DateTime.Now : (DateTime)row["tupo_datecreated"];
                Confirmpo_number = (row["confirmpo_number"] == null || row["confirmpo_number"] == DBNull.Value) ? "" : row["confirmpo_number"].ToString();
                Confirmpo_datecreated = (row["confirmpo_datecreated"] == null || row["confirmpo_datecreated"] == DBNull.Value) ? DateTime.Now : (DateTime)row["confirmpo_datecreated"];
                Bltupo = (row["bltupo"] == null || row["bltupo"] == DBNull.Value) ? 0 : (int)row["bltupo"];
                Bltupo_datecreated = (row["bltupo_datecreated"] == null || row["bltupo_datecreated"] == DBNull.Value) ? DateTime.Now : (DateTime)row["bltupo_datecreated"];
                Confirmpo_dateactive = (row["confirmpo_dateactive"] == null || row["confirmpo_dateactive"] == DBNull.Value) ? DateTime.Now : (DateTime)row["confirmpo_dateactive"];
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
        public bool Check_VBConfirmPO(string id)
        {
            string query = string.Format("SELECT * FROM dbo.VBConfirmPO WHERE id_po = '{0}'", id);
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
                    string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO SET id_contract = '{1}', po_number = '{2}', numberofdevice = {3}, datecreated = '{4}', priceunit = {5},dateconfirm = '{6}',dateperform = '{7}',dateline = '{8}',targetdeliveradd = N'{9}',email_BLBH_status = '{10}',email_BLTH_status = '{11}',totalvalue = {12},tupo = {13}, tupo_datecreated = '{14}', confirmpo_number = '{15}', confirmpo_datecreated = '{16}', bltupo = {17}, bltupo_datecreated= '{18}', confirmpo_dateactive = '{19}'  WHERE id = '{0}'", id, id_contract, po_number, numberofdevice, datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), priceunit, dateconfirm.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), dateperform.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), dateline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo, tupo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmpo_number, confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), bltupo, bltupo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmpo_dateactive.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                    try
                    {
                        OPMDBHandler.ExecuteNonQuery(query);
                        MessageBox.Show(string.Format("Cập nhật thành công PO {0} !", id));
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("Cập nhật thất bại PO {0} !", id));
                    }
                }
                else
                {
                    string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PO(id, id_contract, po_number, numberofdevice, datecreated, priceunit, dateconfirm, dateperform, dateline, targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo, tupo_datecreated, confirmpo_number, confirmpo_datecreated, bltupo, bltupo_datecreated, confirmpo_dateactive) VALUES('{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}','{8}',N'{9}','{10}','{11}','{12}',{13},'{14}','{15}','{16}',{17},'{18}','{19}')  --INSERT INTO dbo.CatalogAdmin(ctlID,ctlname,ctlparent) VALUES('PO_{0}','{2}','Contract_{1}')", id, id_contract, po_number, numberofdevice, datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), priceunit, dateconfirm.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), dateperform.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), dateline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo, tupo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmpo_number, confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), bltupo, bltupo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmpo_dateactive.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                    try
                    {
                        OPMDBHandler.ExecuteNonQuery(query);
                        MessageBox.Show(string.Format("Tạo mới thành công PO {0} !", id));
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("Tạo mới thất bại PO {0} !", id));
                    }
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
                    string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO SET id_contract = '{1}', po_number = '{2}', numberofdevice = {3}, datecreated = '{4}', priceunit = {5},dateconfirm = '{6}',dateperform = '{7}',dateline = '{8}',targetdeliveradd = N'{9}',email_BLBH_status = '{10}',email_BLTH_status = '{11}',totalvalue = {12},tupo = {13}, tupo_datecreated = '{14}', confirmpo_number = '{15}', confirmpo_datecreated = '{16}', bltupo = {17}, bltupo_datecreated= '{18}', confirmpo_dateactive = '{19}'  WHERE id = '{0}'", id, id_contract, po_number, numberofdevice, datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), priceunit, dateconfirm.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), dateperform.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), dateline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo, tupo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmpo_number, confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), bltupo, bltupo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmpo_dateactive.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                    try
                    {
                        OPMDBHandler.ExecuteNonQuery(query);
                        MessageBox.Show(string.Format("Cập nhật thành công PO {0} !", id));
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("Cập nhật thất bại PO {0} !", id));
                    }
                }
                else
                {
                    string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PO(id, id_contract, po_number, numberofdevice, datecreated, priceunit, dateconfirm, dateperform, dateline, targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo, tupo_datecreated, confirmpo_number, confirmpo_datecreated, bltupo, bltupo_datecreated, confirmpo_dateactive) VALUES('{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}','{8}',N'{9}','{10}','{11}','{12}',{13},'{14}','{15}','{16}',{17},'{18}','{19}')  --INSERT INTO dbo.CatalogAdmin(ctlID,ctlname,ctlparent) VALUES('PO_{0}','{2}','Contract_{1}')", id, id_contract, po_number, numberofdevice, datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), priceunit, dateconfirm.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), dateperform.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), dateline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), targetdeliveradd, email_BLBH_status, email_BLTH_status, totalvalue, tupo, tupo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmpo_number, confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), bltupo, bltupo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmpo_dateactive.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                    try
                    {
                        OPMDBHandler.ExecuteNonQuery(query);
                        MessageBox.Show(string.Format("Tạo mới thành công PO {0} !", id));
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("Tạo mới thất bại PO {0} !", id));
                    }
                }
            }
        }
        public void InsertOrUpdate_VBConfirmPO(string id)
        {
            if (id == null)
                MessageBox.Show("Id chưa khởi tạo!");
            else
            {
                if (Check_VBConfirmPO(id))
                {
                    string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.VBConfirmPO SET id_ConfirmPO = '{0}' where id_po = '{1}'", Confirmpo_number, id);
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Cập nhật thành công văn bản số hiệu {0} trong CSDL!", id));
                }
                else
                {
                    string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.VBConfirmPO(id_ConfirmPO, id_po, vb_ConfirmPO) VALUES('{0}','{1}','{2}')", Confirmpo_number, id, ' ');
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Tạo mới thành công văn bản số hiệu {0} trong CSDL!", id));
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
        public int InsertImportFilePO(string id_po, string id_province, string numberofdevice, string namefdevice)
        {
            int result = 0;
            numberofdevice = numberofdevice.Replace(",", string.Empty);
            numberofdevice = numberofdevice.Replace(".", string.Empty);
            string query = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.ListExpected_PO(id_po, id_province, numberofdevice, nameofdevice) VALUES('{0}',N'{1}',{2},N'{3}')", id_po, id_province, Int64.Parse(numberofdevice), namefdevice);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
        public int InsertImportFileKHGH(string NumberConfirmPO, string Province, string Count_PO, string Number_PO, string Date_Delivery, string id_po)
        {
            int result = 0;
            string query = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.Delivery_PO(NumberConfirmPO, Province, Count_PO, Number_PO, Date_Delivery,id_po) VALUES('{0}',N'{1}',{2},{3},N'{4}',N'{5}')", NumberConfirmPO, Province, Int64.Parse(Count_PO), Int64.Parse(Number_PO), Date_Delivery, id_po);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
        public bool CheckListExpected_PO(string id)
        {
            string query = string.Format("SELECT * FROM dbo.ListExpected_PO WHERE id_po = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public bool CheckListDelivery_PO(string Confirmpo_number)
        {
            string query = string.Format("SELECT * FROM dbo.Delivery_PO WHERE NumberConfirmPO = '{0}'", Confirmpo_number);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
    }
}
