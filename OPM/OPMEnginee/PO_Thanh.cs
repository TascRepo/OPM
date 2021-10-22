using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class PO_Thanh
    {
        private string id = "XXXX/CUVT-KV";
        private string idContract = "XXX-2021/CUVT-ANSV/DTRR-KHMS";
        private string poName = "POX";
        private double numberOfDevice = 0;
        private DateTime signedDate = DateTime.Now;
        private DateTime confirmRequestDate = DateTime.Now;
        private DateTime defaultPerformDate = DateTime.Now;
        private DateTime performDate = DateTime.Now;
        private DateTime deadline = DateTime.Now;
        private double totalValue = 0;
        private string idConfirm = "XXXX/ANSV-DO";
        private DateTime confirmCreatedDate = DateTime.Now;
        private int advancePercentage = 50;
        private DateTime advanceCreatedDate = DateTime.Now;
        private int advanceGuaranteePercentage = 5;
        private DateTime advanceGuaranteeCreatedDate = DateTime.Now;
        private string idAdvanceRequest = "XXXX/ANSV-TCKT";
        private DateTime advanceRequestDate = DateTime.Now;
        public string Id { get => id; set => id = value; }
        public string IdContract { get => idContract; set => idContract = value; }
        public string POName { get => poName; set => poName = value; }
        public double NumberOfDevice { get => numberOfDevice; set => numberOfDevice = value; }
        public DateTime SignedDate { get => signedDate; set => signedDate = value; }
        public DateTime ConfirmRequestDate { get => confirmRequestDate; set => confirmRequestDate = value; }
        public DateTime DefaultPerformDate { get => defaultPerformDate; set => defaultPerformDate = value; }
        public DateTime PerformDate { get => performDate; set => performDate = value; }
        public DateTime Deadline { get => deadline; set => deadline = value; }
        public double TotalValue { get => totalValue; set => totalValue = value; }
        public string IdConfirm { get => idConfirm; set => idConfirm = value; }
        public DateTime ConfirmCreatedDate { get => confirmCreatedDate; set => confirmCreatedDate = value; }
        public int AdvancePercentage { get => advancePercentage; set => advancePercentage = value; }
        public DateTime AdvanceCreatedDate { get => advanceCreatedDate; set => advanceCreatedDate = value; }
        public int AdvanceGuaranteePercentage { get => advanceGuaranteePercentage; set => advanceGuaranteePercentage = value; }
        public DateTime AdvanceGuaranteeCreatedDate { get => advanceGuaranteeCreatedDate; set => advanceGuaranteeCreatedDate = value; }
        public string IdAdvanceRequest { get => idAdvanceRequest; set => idAdvanceRequest = value; }
        public DateTime AdvanceRequestDate { get => advanceRequestDate; set => advanceRequestDate = value; }

        public PO_Thanh() { }
        public PO_Thanh(string id, string idContract, string poName, double numberOfDevice, DateTime signedDate, DateTime confirmRequestDate, DateTime defaultPerformDate, DateTime performDate, DateTime dateline, double totalValue, string idConfirm, DateTime confirmCreatedDate, int advancePercentage, DateTime advanceCreatedDate,  int advanceGuaranteePercentage, DateTime advanceGuaranteeCreatedDate, string idAdvanceRequest, DateTime advanceRequestDate)
        {
            Id = id;
            IdContract = idContract;
            POName = poName;
            NumberOfDevice = numberOfDevice;
            SignedDate = signedDate;
            ConfirmRequestDate = confirmRequestDate;
            DefaultPerformDate = defaultPerformDate;
            PerformDate = performDate;
            Deadline = dateline;
            TotalValue = totalValue;
            IdConfirm = idConfirm;
            ConfirmCreatedDate = confirmCreatedDate;
            AdvancePercentage = advancePercentage;
            AdvanceCreatedDate = advanceCreatedDate;
            AdvanceGuaranteePercentage = advanceGuaranteePercentage;
            AdvanceGuaranteeCreatedDate = advanceGuaranteeCreatedDate;
            IdAdvanceRequest = idAdvanceRequest;
            AdvanceRequestDate = advanceRequestDate;
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
            IdContract = (row["IdContract"] == null || row["IdContract"] == DBNull.Value) ? "" : row["IdContract"].ToString();
            POName = (row["POName"] == null || row["POName"] == DBNull.Value) ? "" : row["POName"].ToString();
            NumberOfDevice = (row["NumberOfDevice"] == null || row["NumberOfDevice"] == DBNull.Value) ? 0 : (double)row["NumberOfDevice"];
            SignedDate = (row["SignedDate"] == null || row["SignedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["SignedDate"];
            ConfirmRequestDate = (row["ConfirmRequestDate"] == null || row["ConfirmRequestDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ConfirmRequestDate"];
            DefaultPerformDate = (row["DefaultPerformDate"] == null || row["DefaultPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DefaultPerformDate"];
            PerformDate = (row["PerformDate"] == null || row["PerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PerformDate"];
            Deadline = (row["Deadline"] == null || row["Deadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["Deadline"];
            TotalValue = (row["TotalValue"] == null || row["TotalValue"] == DBNull.Value) ? 0 : (double)row["TotalValue"];
            IdConfirm = (row["IdConfirm"] == null || row["IdConfirm"] == DBNull.Value) ? "" : row["IdConfirm"].ToString();
            ConfirmCreatedDate = (row["ConfirmCreatedDate"] == null || row["ConfirmCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ConfirmCreatedDate"];
            AdvancePercentage = (row["AdvancePercentage"] == null || row["AdvancePercentage"] == DBNull.Value) ? 0 : (int)row["AdvancePercentage"];
            AdvanceCreatedDate = (row["AdvanceCreatedDate"] == null || row["AdvanceCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["AdvanceCreatedDate"];
            AdvanceGuaranteePercentage = (row["AdvanceGuaranteePercentage"] == null || row["AdvanceGuaranteePercentage"] == DBNull.Value) ? 0 : (int)row["AdvanceGuaranteePercentage"];
            AdvanceGuaranteeCreatedDate = (row["AdvanceGuaranteeCreatedDate"] == null || row["AdvanceGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["AdvanceGuaranteeCreatedDate"];
            IdAdvanceRequest = (row["IdAdvanceRequest"] == null || row["IdAdvanceRequest"] == DBNull.Value) ? "" : row["IdAdvanceRequest"].ToString();
            AdvanceRequestDate = (row["AdvanceRequestDate"] == null || row["AdvanceRequestDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["AdvanceRequestDate"];
        }
        public PO_Thanh(string id)
        {
            Id = id;
            string query = string.Format("SELECT * FROM dbo.PO_Thanh WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                IdContract = (row["IdContract"] == null || row["IdContract"] == DBNull.Value) ? "" : row["IdContract"].ToString();
                POName = (row["POName"] == null || row["POName"] == DBNull.Value) ? "" : row["POName"].ToString();
                NumberOfDevice = (row["NumberOfDevice"] == null || row["NumberOfDevice"] == DBNull.Value) ? 0 : (double)row["NumberOfDevice"];
                SignedDate = (row["SignedDate"] == null || row["SignedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["SignedDate"];
                ConfirmRequestDate = (row["ConfirmRequestDate"] == null || row["ConfirmRequestDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ConfirmRequestDate"];
                DefaultPerformDate = (row["DefaultPerformDate"] == null || row["DefaultPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DefaultPerformDate"];
                PerformDate = (row["PerformDate"] == null || row["PerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PerformDate"];
                Deadline = (row["Deadline"] == null || row["Deadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["Deadline"];
                TotalValue = (row["TotalValue"] == null || row["TotalValue"] == DBNull.Value) ? 0 : (double)row["TotalValue"];
                IdConfirm = (row["IdConfirm"] == null || row["IdConfirm"] == DBNull.Value) ? "" : row["IdConfirm"].ToString();
                ConfirmCreatedDate = (row["ConfirmCreatedDate"] == null || row["ConfirmCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ConfirmCreatedDate"];
                AdvancePercentage = (row["AdvancePercentage"] == null || row["AdvancePercentage"] == DBNull.Value) ? 0 : (int)row["AdvancePercentage"];
                AdvanceCreatedDate = (row["AdvanceCreatedDate"] == null || row["AdvanceCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["AdvanceCreatedDate"];
                AdvanceGuaranteePercentage = (row["AdvanceGuaranteePercentage"] == null || row["AdvanceGuaranteePercentage"] == DBNull.Value) ? 0 : (int)row["AdvanceGuaranteePercentage"];
                AdvanceGuaranteeCreatedDate = (row["AdvanceGuaranteeCreatedDate"] == null || row["AdvanceGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["AdvanceGuaranteeCreatedDate"];
                IdAdvanceRequest = (row["IdAdvanceRequest"] == null || row["IdAdvanceRequest"] == DBNull.Value) ? "" : row["IdAdvanceRequest"].ToString();
                AdvanceRequestDate = (row["AdvanceRequestDate"] == null || row["AdvanceRequestDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["AdvanceRequestDate"];
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.PO_Thanh WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public bool Exist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.PO_Thanh WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int Insert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PO_Thanh(id,idContract,poName,numberOfDevice,signedDate,confirmRequestDate,defaultPerformDate,performDate,deadline,totalValue,idConfirm,confirmCreatedDate,advancePercentage,advanceCreatedDate,advanceGuaranteePercentage,advanceGuaranteeCreatedDate,idAdvanceRequest,advanceRequestDate)VALUES('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}',{12},'{13}',{14},'{15}','{16}','{17}')", id, idContract, poName, numberOfDevice, signedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), defaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), performDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), deadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), totalValue, idConfirm, confirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), advancePercentage, advanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), advanceGuaranteePercentage, advanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), idAdvanceRequest, advanceRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int UpdateIdContract()   //Chuyển sang hợp đồng khác (thay đổi IdContract)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO_Thanh SET idContract = '{1}', poName = '{2}', numberOfDevice = {3}, signedDate = '{4}',confirmRequestDate = '{5}',defaultPerformDate = '{6}',performDate = '{7}',deadline = N'{8}',totalValue = {9},idConfirm = '{10}',confirmCreatedDate = '{11}',advancePercentage = {12}, advanceCreatedDate = '{13}', advanceGuaranteePercentage = {14}, advanceGuaranteeCreatedDate = '{15}', idAdvanceRequest = '{16}', advanceRequestDate= '{17}' WHERE id = '{0}'", id, idContract, poName, numberOfDevice, signedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), defaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), performDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), deadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), totalValue, idConfirm, confirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), advancePercentage, advanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), advanceGuaranteePercentage, advanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), idAdvanceRequest, advanceRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int Update()             //Giữ nguyên Id và IdContract
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO_Thanh SET poName = '{1}', numberOfDevice = {2}, signedDate = '{3}',confirmRequestDate = '{4}',defaultPerformDate = '{5}',performDate = '{6}',deadline = '{7}',totalValue = {8},idConfirm = '{9}',confirmCreatedDate = '{10}',advancePercentage = {11}, advanceCreatedDate = '{12}', advanceGuaranteePercentage = {13}, advanceGuaranteeCreatedDate = '{14}', idAdvanceRequest = '{15}', advanceRequestDate= '{16}' WHERE id = '{0}'", id, poName, numberOfDevice, signedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), defaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), performDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), deadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), totalValue, idConfirm, confirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), advancePercentage, advanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), advanceGuaranteePercentage, advanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), idAdvanceRequest, advanceRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int Update(string oldId)             //Giữ nguyên IdContract đổi Id
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO_Thanh SET id='{0}', poName = '{1}', numberOfDevice = {2}, signedDate = '{3}',confirmRequestDate = '{4}',defaultPerformDate = '{5}',performDate = '{6}',deadline = '{7}',totalValue = {8},idConfirm = '{9}',confirmCreatedDate = '{10}',advancePercentage = {11}, advanceCreatedDate = '{12}', advanceGuaranteePercentage = {13}, advanceGuaranteeCreatedDate = '{14}', idAdvanceRequest = '{15}', advanceRequestDate= '{16}' WHERE id = '{17}'", id, poName, numberOfDevice, signedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), confirmRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), defaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), performDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), deadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), totalValue, idConfirm, confirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), advancePercentage, advanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), advanceGuaranteePercentage, advanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), idAdvanceRequest, advanceRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")),oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public bool Check_VBConfirmPO(string id)
        {
            string query = string.Format("SELECT * FROM dbo.VBConfirmPO WHERE id_po = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static List<PO_Thanh> GetList()
        {
            List<PO_Thanh> list = new List<PO_Thanh>();
            string query = string.Format("SELECT * FROM dbo.PO_Thanh");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                PO_Thanh po = new PO_Thanh(item);
                list.Add(po);
            }
            return list;
        }
        public void InsertOrUpdate_VBConfirmPO(string id)
        {
            if (id == null)
                MessageBox.Show("Id chưa khởi tạo!");
            else
            {
                if (Check_VBConfirmPO(id))
                {
                    string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.VBConfirmPO SET id_ConfirmPO = '{0}' where id_po = '{1}'", IdConfirm, id);
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Cập nhật thành công văn bản số hiệu {0} trong CSDL!", id));
                }
                else
                {
                    string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.VBConfirmPO(id_ConfirmPO, id_po, vb_ConfirmPO) VALUES('{0}','{1}','{2}')", IdConfirm, id, ' ');
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Tạo mới thành công văn bản số hiệu {0} trong CSDL!", id));
                }
            }
        }
        public int Delete()
        {
            int result = 0;
            string query = string.Format("DELETE FROM dbo.PO_Thanh WHERE id = '{0}'", id);
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
            string query = string.Format("DELETE FROM dbo.PO_Thanh WHERE id = '{0}'", id);
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
        public void DeleteDelivery_PO(string Confirmpo_number)
        {
            int result = 0;
            string query = string.Format("DELETE FROM dbo.Delivery_PO WHERE NumberConfirmPO = '{0}'", Confirmpo_number);
            try
            {
                result = OPMDBHandler.ExecuteNonQuery(query);
                result = 1;
            }
            catch
            {
                result = 0;
            }
        }
    }
}