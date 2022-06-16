using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class DPObj : POObj
    {
        private string dPId = @"XXXX/2022";
        public string DPId
        {
            get => dPId;
            set
            {
                dPId = value;
                string query = string.Format("SELECT * FROM dbo.DP WHERE DPId = '{0}'", value);
                try
                {
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        POId = (row["POId"] == null || row["POId"] == DBNull.Value) ? "XXXX/CUVT-KV" : row["POId"].ToString();
                        DPDate = (row["DPDate"] == null || row["DPDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DPDate"];
                        DPType = (row["DPType"] == null || row["DPType"] == DBNull.Value) ? 0 : (int)row["DPType"];
                        DPQuantity = (row["DPQuantity"] == null || row["DPQuantity"] == DBNull.Value) ? 0 : (int)row["DPQuantity"];
                        DPQuantity1 = (row["DPQuantity1"] == null || row["DPQuantity1"] == DBNull.Value) ? 0 : (int)row["DPQuantity1"];
                        DPRequestDate = (row["DPRequestDate"] == null || row["DPRequestDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DPRequestDate"];
                        DPResponseDate = (row["DPResponseDate"] == null || row["DPResponseDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DPResponseDate"];
                        DPRefundDate = (row["DPRefundDate"] == null || row["DPRefundDate"] == DBNull.Value) ? DateTime.Parse("01/01/2000") : (DateTime)row["DPRefundDate"];
                        DPRemarks = (row["DPRemarks"] == null || row["DPRemarks"] == DBNull.Value) ? "" : row["DPRemarks"].ToString();
                        DPVNPTTechANSVContractNumber = (row["DPVNPTTechANSVContractNumber"] == null || row["DPVNPTTechANSVContractNumber"] == DBNull.Value) ? "" : row["DPVNPTTechANSVContractNumber"].ToString();
                        DPContractAccoutingCode = (row["DPContractAccoutingCode"] == null || row["DPContractAccoutingCode"] == DBNull.Value) ? "" : row["DPContractAccoutingCode"].ToString();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng DP trong CSDL " + query + e.Message);
                }
            }
        }
        public DateTime DPDate { get; set; } = DateTime.Now;
        public int DPType { get; set; } = 0;
        public int DPQuantity { get; set; } = 0;
        public int DPQuantity1 { get; set; } = 0;
        public DateTime DPRequestDate { get; set; } = DateTime.Now;
        public DateTime DPResponseDate { get; set; } = DateTime.Now;
        public DateTime DPRefundDate { get; set; } = DateTime.MinValue;
        public string DPRemarks { get; set; } = "";
        public string DPVNPTTechANSVContractNumber { get; set; } = "";
        public string DPContractAccoutingCode { get; set; } = "";

        public DPObj() { }
        public DPObj(string DPId, string POId, DateTime DPDate, int DPType, int DPQuantity, string DPRemarks)
        {
            this.DPId = DPId;
            this.POId = POId;
            this.DPDate = DPDate;
            this.DPType = DPType;
            this.DPQuantity = DPQuantity;
            this.DPRemarks = DPRemarks;
        }
        public DPObj(string id)
        {
            DPId = id;
        }
        public DPObj(DataRow row)
        {
            POId = (row["POId"] == null || row["POId"] == DBNull.Value) ? "XXXX/CUVT-KV" : row["POId"].ToString();
            DPDate = (row["DPDate"] == null || row["DPDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DPDate"];
            DPType = (row["DPType"] == null || row["DPType"] == DBNull.Value) ? 0 : (int)row["DPType"];
            DPQuantity = (row["DPQuantity"] == null || row["DPQuantity"] == DBNull.Value) ? 0 : (int)row["DPQuantity"];
            DPQuantity1 = (row["DPQuantity1"] == null || row["DPQuantity1"] == DBNull.Value) ? 0 : (int)row["DPQuantity1"];
            DPRequestDate = (row["DPRequestDate"] == null || row["DPRequestDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DPRequestDate"];
            DPResponseDate = (row["DPResponseDate"] == null || row["DPResponseDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DPResponseDate"];
            DPRefundDate = (row["DPRefundDate"] == null || row["DPRefundDate"] == DBNull.Value) ? DateTime.Parse("01/01/2000") : (DateTime)row["DPRefundDate"];
            DPRemarks = (row["DPRemarks"] == null || row["DPRemarks"] == DBNull.Value) ? "" : row["DPRemarks"].ToString();
            DPVNPTTechANSVContractNumber = (row["DPVNPTTechANSVContractNumber"] == null || row["DPVNPTTechANSVContractNumber"] == DBNull.Value) ? "" : row["DPVNPTTechANSVContractNumber"].ToString();
            DPContractAccoutingCode = (row["DPContractAccoutingCode"] == null || row["DPContractAccoutingCode"] == DBNull.Value) ? "" : row["DPContractAccoutingCode"].ToString();
        }
        public bool DPExist()
        {
            string query = string.Format("SELECT * FROM dbo.DP WHERE DPId = '{0}'", DPId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool DPExist(string DPId)
        {
            string query = string.Format("SELECT * FROM dbo.DP WHERE DPId = '{0}'", DPId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }

        public static int DPDelete(string DPId)
        {
            string query = string.Format("DELETE FROM dbo.DP WHERE DPId = '{0}'", DPId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int DPDelete()
        {
            string query = string.Format("DELETE FROM dbo.DP WHERE DPId = '{0}'", DPId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static DataTable DPGetTableByPOId(string POId)
        {
            string query = string.Format("SELECT * FROM dbo.DP Where POId = '{0}' Order By DPId", POId);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static List<DPObj> DPGetListByPOId(string POId)
        {
            List<DPObj> list = new List<DPObj>();
            string query = string.Format("SELECT * FROM dbo.DP Where POId = '{0}' Order By DPId", POId);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DPObj dp = new DPObj(item);
                list.Add(dp);
            }
            return list;
        }
        public static double DPGetTotalQuantityByPOId(string POId)
        {
            string query = string.Format(@"SELECT SUM(DPQuantity) FROM dbo.DP WHERE DPType = 0 AND POId = '{0}'", POId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            int tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (int)tem1;
            return tem;
        }
        public static double DPGetTotalSpareQuantityByPOId(string POId)
        {
            string query = string.Format(@"SELECT SUM(DPQuantity) FROM dbo.DP WHERE DPType = 1 AND POId = '{0}'", POId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            int tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (int)tem1;
            return tem;
        }

        public static void DPInsertOrUpdateList(List<DPObj> DPs)
        {
            foreach (DPObj dp in DPs)
            {
                if (dp.DPExist()) dp.DPUpdate();
                else dp.DPInsert();
            }
        }
        public static void DPInsertOrUpdateTable(DataTable table)
        {
            foreach (DataRow item in table.Rows)
            {
                DPObj dp = new DPObj(item);
                if (dp.DPExist()) dp.DPUpdate();
                else dp.DPInsert();
            }
        }
        public void DPUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DP SET DPId = '{0}', POId = '{1}', DPDate = '{2}', DPType = {3}, DPQuantity = {4}, DPQuantity1 = {5}, DPRequestDate = '{6}', DPResponseDate = '{7}', DPRefundDate = '{8}', DPRemarks = N'{9}', DPVNPTTechANSVContractNumber = '{10}', DPContractAccoutingCode = '{11}' WHERE DPId = '{0}'", DPId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPQuantity, DPQuantity1, DPRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPResponseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRefundDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRemarks, DPVNPTTechANSVContractNumber, DPContractAccoutingCode);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void DPUpdate(int DPId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DP SET DPId = '{0}', POId = '{1}', DPDate = '{2}', DPType = {3}, DPQuantity = {4}, DPQuantity1 = {5}, DPRequestDate = '{6}', DPResponseDate = '{7}', DPRefundDate = '{8}', DPRemarks = N'{9}', DPVNPTTechANSVContractNumber = '{10}', DPContractAccoutingCode = '{11}' WHERE DPId = '{0}'", DPId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPQuantity, DPQuantity1, DPRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPResponseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRefundDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRemarks, DPVNPTTechANSVContractNumber, DPContractAccoutingCode);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DPUpdate(string newId, string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DP SET DPId = '{0}', POId = '{1}', DPDate = '{2}', DPType = {3}, DPQuantity = {4}, DPQuantity1 = {5}, DPRequestDate = '{6}', DPResponseDate = '{7}', DPRefundDate = '{8}', DPRemarks = N'{9}' , DPVNPTTechANSVContractNumber = '{10}', DPContractAccoutingCode = '{11}' WHERE DPId = '{12}'", newId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPQuantity, DPQuantity1, DPRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPResponseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRefundDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRemarks, DPVNPTTechANSVContractNumber, DPContractAccoutingCode, oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DPInsert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DP(DPId,POId,DPDate,DPType,DPQuantity,DPRemarks, DPVNPTTechANSVContractNumber, DPContractAccoutingCode) VALUES('{0}','{1}','{2}',{3},{4},{5},'{6}','{7}','{8}',N'{9}','{10}','{11}')", DPId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPQuantity, DPQuantity1, DPRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPResponseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRefundDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRemarks, DPVNPTTechANSVContractNumber, DPContractAccoutingCode);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DPInsert(string DPId)
        {
            if (DPObj.DPExist(DPId)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DP(DPId,POId,DPDate,DPType,DPQuantity,DPRemarks, DPVNPTTechANSVContractNumber, DPContractAccoutingCode) VALUES('{0}','{1}','{2}',{3},{4},{5},'{6}','{7}','{8}',N'{9}','{10}','{11}')", DPId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPQuantity, DPQuantity1, DPRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPResponseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRefundDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPRemarks, DPVNPTTechANSVContractNumber, DPContractAccoutingCode);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
    }
}
