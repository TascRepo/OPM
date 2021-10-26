using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class POObj:ContractObj
    {
        string pOId = "XXXX/CUVT-KV";
        public string POId
        { 
            get=> pOId;
            set
            {
                pOId = value;
                try
                {
                    string query = string.Format("SELECT * FROM dbo.PO WHERE POId = '{0}'", value);
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        ContractId = (row["ContractId"] == null || row["ContractId"] == DBNull.Value) ? "" : row["ContractId"].ToString();
                        POName = (row["POName"] == null || row["POName"] == DBNull.Value) ? "" : row["POName"].ToString();
                        POGoodsQuantity = (row["POGoodsQuantity"] == null || row["POGoodsQuantity"] == DBNull.Value) ? 0 : (double)row["POGoodsQuantity"];
                        POCreatedDate = (row["POCreatedDate"] == null || row["POCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POCreatedDate"];
                        POConfirmRequestDeadline = (row["POConfirmRequestDeadline"] == null || row["POConfirmRequestDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmRequestDeadline"];
                        PODefaultPerformDate = (row["PODefaultPerformDate"] == null || row["PODefaultPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODefaultPerformDate"];
                        POPerformDate = (row["POPerformDate"] == null || row["POPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POPerformDate"];
                        PODeadline = (row["PODeadline"] == null || row["PODeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODeadline"];
                        POConfirmId = (row["POConfirmId"] == null || row["POConfirmId"] == DBNull.Value) ? "" : row["POConfirmId"].ToString();
                        POConfirmCreatedDate = (row["POConfirmCreatedDate"] == null || row["POConfirmCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmCreatedDate"];
                        POAdvancePercentage = (row["POAdvancePercentage"] == null || row["POAdvancePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvancePercentage"];
                        POAdvanceId = (row["POAdvanceId"] == null || row["POAdvanceId"] == DBNull.Value) ? "" : row["POAdvanceId"].ToString();
                        POAdvanceCreatedDate = (row["POAdvanceCreatedDate"] == null || row["POAdvanceCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceCreatedDate"];
                        POAdvanceGuaranteePercentage = (row["POAdvanceGuaranteePercentage"] == null || row["POAdvanceGuaranteePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvanceGuaranteePercentage"];
                        POAdvanceGuaranteeCreatedDate = (row["POAdvanceGuaranteeCreatedDate"] == null || row["POAdvanceGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceGuaranteeCreatedDate"];
                        POAdvanceRequestId = (row["POAdvanceRequestId"] == null || row["POAdvanceRequestId"] == DBNull.Value) ? "" : row["POAdvanceRequestId"].ToString();
                        POAdvanceRequestCreatedDate = (row["POAdvanceRequestCreatedDate"] == null || row["POAdvanceRequestCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceRequestCreatedDate"];
                        POGuaranteeDate = (row["POGuaranteeDate"] == null || row["POGuaranteeDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POGuaranteeDate"];
                    }
                }
                catch
                {

                }
            }
        }
        public string POName { get; set; } = "POX";
        public DateTime POCreatedDate { get; set; } = DateTime.Now;
        public double POGoodsQuantity { get; set; } = 0;
        public DateTime POConfirmRequestDeadline { get; set; } = DateTime.Now;
        public DateTime PODefaultPerformDate { get; set; } = DateTime.Now;
        public DateTime POPerformDate { get; set; } = DateTime.Now;
        public DateTime PODeadline { get; set; } = DateTime.Now;
        public double POTotalValue => ContractGoodsUnitPrice * POGoodsQuantity;
        public string POConfirmId { get; set; } = "XXXX/ANSV-DO";
        public DateTime POConfirmCreatedDate { get; set; } = DateTime.Now;
        public string POAdvanceId { get; set; } = "XXXX/ANSV-TCKT";
        public DateTime POAdvanceCreatedDate { get; set; } = DateTime.Now;
        public int POAdvancePercentage { get; set; } = 50;
        public DateTime POAdvanceGuaranteeCreatedDate { get; set; } = DateTime.Now;
        public int POAdvanceGuaranteePercentage { get; set; } = 50;
        public string POAdvanceRequestId { get; set; } = "XXXX/ANSV-TCKT";
        public DateTime POAdvanceRequestCreatedDate { get; set; } = DateTime.Now;
        public DateTime POGuaranteeDate { get; set; } = DateTime.Now;

        public POObj() { }
        public POObj(ContractObj contract)
        {
            ContractId = contract.ContractId;
        }
        public POObj(string POId, string POName, double POGoodsQuantity, DateTime POCreatedDate, DateTime POConfirmRequestDeadline, DateTime PODefaultPerformDate, DateTime POPerformDate, DateTime PODeadline, string POConfirmId, DateTime POConfirmCreatedDate, string POAdvanceId,int POAdvancePercentage, DateTime POAdvanceCreatedDate, int POAdvanceGuaranteePercentage, DateTime POAdvanceGuaranteeCreatedDate, string POAdvanceRequestId, DateTime POAdvanceRequestCreatedDate, DateTime POGuaranteeDate)
        {
            this.POId = POId;
            this.POName = POName;
            this.POGoodsQuantity = POGoodsQuantity;
            this.POCreatedDate = POCreatedDate;
            this.POConfirmRequestDeadline = POConfirmRequestDeadline;
            this.PODefaultPerformDate = PODefaultPerformDate;
            this.POPerformDate = POPerformDate;
            this.PODeadline = PODeadline;
            this.POConfirmId = POConfirmId;
            this.POConfirmCreatedDate = POConfirmCreatedDate;
            this.POAdvanceId = POAdvanceId;
            this.POAdvanceCreatedDate = POAdvanceCreatedDate;
            this.POAdvancePercentage = POAdvancePercentage;
            this.POAdvanceGuaranteeCreatedDate = POAdvanceGuaranteeCreatedDate;
            this.POAdvanceGuaranteePercentage = POAdvanceGuaranteePercentage;
            this.POAdvanceRequestId = POAdvanceRequestId;
            this.POAdvanceRequestCreatedDate = POAdvanceRequestCreatedDate;
            this.POGuaranteeDate = POGuaranteeDate;
        }
        public POObj(DataRow row)
        {
            POId = row["POId"].ToString();
            ContractId = (row["ContractId"] == null || row["ContractId"] == DBNull.Value) ? "" : row["ContractId"].ToString();
            POName = (row["POName"] == null || row["POName"] == DBNull.Value) ? "" : row["POName"].ToString();
            POCreatedDate = (row["POCreatedDate"] == null || row["POCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POCreatedDate"];
            POGoodsQuantity = (row["POGoodsQuantity"] == null || row["POGoodsQuantity"] == DBNull.Value) ? 0 : (double)row["POGoodsQuantity"];
            POConfirmRequestDeadline = (row["POConfirmRequestDeadline"] == null || row["POConfirmRequestDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmRequestDeadline"];
            PODefaultPerformDate = (row["PODefaultPerformDate"] == null || row["PODefaultPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODefaultPerformDate"];
            POPerformDate = (row["POPerformDate"] == null || row["POPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POPerformDate"];
            PODeadline = (row["PODeadline"] == null || row["PODeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODeadline"];
            POConfirmId = (row["POConfirmId"] == null || row["POConfirmId"] == DBNull.Value) ? "" : row["POConfirmId"].ToString();
            POConfirmCreatedDate = (row["POConfirmCreatedDate"] == null || row["POConfirmCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmCreatedDate"];
            POAdvancePercentage = (row["POAdvancePercentage"] == null || row["POAdvancePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvancePercentage"];
            POAdvanceId= (row["POAdvanceId"] == null || row["POAdvanceId"] == DBNull.Value) ? "" : row["POAdvanceId"].ToString();
            POAdvanceCreatedDate = (row["POAdvanceCreatedDate"] == null || row["POAdvanceCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceCreatedDate"];
            POAdvanceGuaranteePercentage = (row["AdvanceGuaranteePercentage"] == null || row["AdvanceGuaranteePercentage"] == DBNull.Value) ? 0 : (int)row["AdvanceGuaranteePercentage"];
            POAdvanceGuaranteeCreatedDate = (row["POAdvanceGuaranteeCreatedDate"] == null || row["POAdvanceGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceGuaranteeCreatedDate"];
            POAdvanceRequestId = (row["POAdvanceRequestId"] == null || row["POAdvanceRequestId"] == DBNull.Value) ? "" : row["POAdvanceRequestId"].ToString();
            POAdvanceRequestCreatedDate = (row["POAdvanceRequestCreatedDate"] == null || row["POAdvanceRequestCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceRequestCreatedDate"];
            POGuaranteeDate = (row["POGuaranteeDate"] == null || row["POGuaranteeDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POGuaranteeDate"];
        }
        public POObj(string id)
        {
            POId = id;
            //string query = string.Format("SELECT * FROM dbo.PO WHERE POId = '{0}'", id);
            //DataTable table = OPMDBHandler.ExecuteQuery(query);
            //if (table.Rows.Count > 0)
            //{
            //    DataRow row = table.Rows[0];
            //    ContractId = (row["ContractId"] == null || row["ContractId"] == DBNull.Value) ? "" : row["ContractId"].ToString();
            //    POName = (row["POName"] == null || row["POName"] == DBNull.Value) ? "" : row["POName"].ToString();
            //    POGoodsQuantity = (row["POGoodsQuantity"] == null || row["POGoodsQuantity"] == DBNull.Value) ? 0 : (int)row["POGoodsQuantity"];
            //    POCreatedDate = (row["POCreatedDate"] == null || row["POCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POCreatedDate"];
            //    POConfirmRequestDeadline = (row["POConfirmRequestDeadline"] == null || row["POConfirmRequestDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmRequestDeadline"];
            //    PODefaultPerformDate = (row["PODefaultPerformDate"] == null || row["PODefaultPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODefaultPerformDate"];
            //    POPerformDate = (row["POPerformDate"] == null || row["POPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POPerformDate"];
            //    PODeadline = (row["PODeadline"] == null || row["PODeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODeadline"];
            //    POConfirmId = (row["POConfirmId"] == null || row["POConfirmId"] == DBNull.Value) ? "" : row["POConfirmId"].ToString();
            //    POConfirmCreatedDate = (row["POConfirmCreatedDate"] == null || row["POConfirmCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmCreatedDate"];
            //    POAdvancePercentage = (row["POAdvancePercentage"] == null || row["POAdvancePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvancePercentage"];
            //    POAdvanceId = (row["POAdvanceId"] == null || row["POAdvanceId"] == DBNull.Value) ? "" : row["POAdvanceId"].ToString();
            //    POAdvanceCreatedDate = (row["POAdvanceCreatedDate"] == null || row["POAdvanceCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceCreatedDate"];
            //    POAdvanceGuaranteePercentage = (row["POAdvanceGuaranteePercentage"] == null || row["POAdvanceGuaranteePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvanceGuaranteePercentage"];
            //    POAdvanceGuaranteeCreatedDate = (row["POAdvanceGuaranteeCreatedDate"] == null || row["POAdvanceGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceGuaranteeCreatedDate"];
            //    POAdvanceRequestId = (row["POAdvanceRequestId"] == null || row["POAdvanceRequestId"] == DBNull.Value) ? "" : row["POAdvanceRequestId"].ToString();
            //    POAdvanceRequestCreatedDate = (row["POAdvanceRequestCreatedDate"] == null || row["POAdvanceRequestCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceRequestCreatedDate"];
            //    POGuaranteeDate = (row["POGuaranteeDate"] == null || row["POGuaranteeDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POGuaranteeDate"];
            //    ContractObj contract = new ContractObj(ContractId);
            //    ContractCreatedDate = contract.ContractCreatedDate;
            //    ContractName = contract.ContractName;
            //    ContractShoppingPlan = contract.ContractShoppingPlan;
            //    ContractType = contract.ContractType;
            //    ContractSiteId = contract.ContractSiteId;
            //    ContractValidityDate = contract.ContractValidityDate;
            //    ContractDeadline = contract.ContractDeadline;
            //    ContractGoodsDesignation = contract.ContractGoodsDesignation;
            //    ContractGoodsCode = contract.ContractGoodsCode;
            //    ContractGoodsManufacture = contract.ContractGoodsManufacture;
            //    ContractGoodsOrigin = contract.ContractGoodsOrigin;
            //    ContractGoodsDesignation1 = contract.ContractGoodsDesignation1;
            //    ContractGoodsCode1 = contract.ContractGoodsCode1;
            //    ContractGoodsCode2 = contract.ContractGoodsCode2;
            //    ContractGoodsSpecies = contract.ContractGoodsSpecies;
            //    ContractGoodsNote = contract.ContractGoodsNote;
            //    ContractGoodsUnit = contract.ContractGoodsUnit;
            //    ContractGoodsUnitPrice = contract.ContractGoodsUnitPrice;
            //    ContractGoodsQuantity = contract.ContractGoodsQuantity;
            //    ContractGoodsLicenseName = contract.ContractGoodsLicenseName;
            //    ContractGoodsLicenseUnitPrice = contract.ContractGoodsLicenseUnitPrice;
            //    ContractGuaranteeCreatedDate = contract.ContractGuaranteeCreatedDate;
            //    POGuaranteeRatio = contract.POGuaranteeRatio;
            //    POGuaranteeValidityPeriod = contract.POGuaranteeValidityPeriod;
            //    ContractGuaranteeDeadline = contract.ContractGuaranteeDeadline;
            //    AccoutingCode = contract.AccoutingCode;
            //}
        }
        public bool POExist()
        {
            string query = string.Format("SELECT * FROM dbo.PO WHERE POId = '{0}'", POId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool POExist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.PO WHERE POId = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int POInsert(string id)
        {
            if (POObj.POExist(id)) return 0;
            if (ContractObj.ContractExist(ContractId))
            {
                string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PO(POId,ContractId,POName,POCreatedDate,POGoodsQuantity,POConfirmRequestDeadline,PODefaultPerformDate,POPerformDate,PODeadline,POConfirmId,POConfirmCreatedDate,POAdvanceId,POAdvanceCreatedDate,POAdvancePercentage,POAdvanceGuaranteeCreatedDate,POAdvanceGuaranteePercentage,POAdvanceRequestId,POAdvanceRequestCreatedDate,POGuaranteeDate)VALUES('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},'{14}',{15},'{16}','{17}','{18}')", id, ContractId, POName, POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGoodsQuantity, POConfirmRequestDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODefaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POConfirmId, POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceId, POAdvanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvancePercentage, POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceGuaranteePercentage, POAdvanceRequestId, POAdvanceRequestCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGuaranteeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                return OPMDBHandler.ExecuteNonQuery(query);
            }
            return 0;
        }
        public int POUpdateIdContract()   //Chuyển sang hợp đồng khác (thay đổi IdContract)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO SET ContractId = '{1}', POName = '{2}', POCreatedDate = '{3}', POGoodsQuantity = {4},POConfirmRequestDeadline = '{5}',PODefaultPerformDate = '{6}',POPerformDate = '{7}',PODeadline = '{8}',POConfirmId = '{9}',POConfirmCreatedDate = '{10}',POAdvanceId = '{11}',POAdvanceCreatedDate = '{12}', POAdvancePercentage = {13}, POAdvanceGuaranteeCreatedDate = '{14}', POAdvanceGuaranteePercentage = {15}, POAdvanceRequestId = '{16}', POAdvanceRequestCreatedDate= '{17}',POGuaranteeDate = '{18}' WHERE POId = '{0}'", POId, ContractId, POName, POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGoodsQuantity, POConfirmRequestDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODefaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POConfirmId, POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceId, POAdvanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvancePercentage, POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceGuaranteePercentage, POAdvanceRequestId, POAdvanceRequestCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGuaranteeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int POUpdate()             //Giữ nguyên Id và IdContract
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO SET POName = '{1}',POCreatedDate = '{2}',POGoodsQuantity = {3},POConfirmRequestDeadline = '{4}',PODefaultPerformDate = '{5}',POPerformDate = '{6}',PODeadline='{7}',POConfirmId='{8}',POConfirmCreatedDate='{9}',POAdvanceId='{10}',POAdvanceCreatedDate='{11}',POAdvancePercentage={12},POAdvanceGuaranteeCreatedDate='{13}',POAdvanceGuaranteePercentage={14},POAdvanceRequestId='{15}',POAdvanceRequestCreatedDate='{16}',POGuaranteeDate='{17}' WHERE POId = '{0}'", POId, POName, POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGoodsQuantity, POConfirmRequestDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODefaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POConfirmId, POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceId, POAdvanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvancePercentage, POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceGuaranteePercentage, POAdvanceRequestId, POAdvanceRequestCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGuaranteeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int POUpdate(string oldId)             //Giữ nguyên IdContract đổi Id
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO SET POId = '{0}', ContractId = '{1}', POName = '{2}', POCreatedDate = '{3}', POGoodsQuantity = {4},POConfirmRequestDeadline = '{5}',PODefaultPerformDate = '{6}',POPerformDate = '{7}',PODeadline = '{8}',POConfirmId = '{9}',POConfirmCreatedDate = '{10}',POAdvanceId = '{11}',POAdvanceCreatedDate = '{12}', POAdvancePercentage = {13}, POAdvanceGuaranteeCreatedDate = '{14}', POAdvanceGuaranteePercentage = {15}, POAdvanceRequestId = '{16}', POAdvanceRequestCreatedDate= '{17}',POGuaranteeDate='{19}' WHERE POId = '{18}'", POId, ContractId, POName, POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGoodsQuantity, POConfirmRequestDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODefaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POConfirmId, POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceId, POAdvanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvancePercentage, POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceGuaranteePercentage, POAdvanceRequestId, POAdvanceRequestCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), oldId, POGuaranteeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public bool Check_VBConfirmPO(string id)
        {
            string query = string.Format("SELECT * FROM dbo.VBConfirmPO WHERE id_po = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static List<POObj> GetList()
        {
            List<POObj> list = new List<POObj>();
            string query = string.Format("SELECT * FROM dbo.PO");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                POObj po = new POObj(item);
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
                    string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.VBConfirmPO SET id_ConfirmPO = '{0}' where id_po = '{1}'", POConfirmId, id);
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Cập nhật thành công văn bản số hiệu {0} trong CSDL!", id));
                }
                else
                {
                    string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.VBConfirmPO(id_ConfirmPO, id_po, vb_ConfirmPO) VALUES('{0}','{1}','{2}')", POConfirmId, id, ' ');
                    OPMDBHandler.ExecuteNonQuery(query);
                    MessageBox.Show(string.Format("Tạo mới thành công văn bản số hiệu {0} trong CSDL!", id));
                }
            }
        }
        public int PODelete()
        {
            int result = 0;
            string query = string.Format("DELETE FROM dbo.PO WHERE POId = '{0}'", POId);
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
        public int PODelete(string id)
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