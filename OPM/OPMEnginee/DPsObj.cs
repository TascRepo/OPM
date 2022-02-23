using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class DPsObj : DPObj
    {
        int dPsId;
        public int DPsId
        {
            get => dPsId;
            set
            {
                dPsId = value;
                string query = string.Format("SELECT * FROM dbo.DPs WHERE DPsId = {0}", value);
                try
                {
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        DPId = (row["DPId"] == null || row["DPId"] == DBNull.Value) ? "XXXX/2022" : row["DPId"].ToString();
                        VNPTId = (row["VNPTId"] == null || row["VNPTId"] == DBNull.Value) ? "ANSV" : row["VNPTId"].ToString();
                        DPQuantity = (row["DPQuantity"] == null || row["DPQuantity"] == DBNull.Value) ? 0 : (double)row["DPQuantity"];
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng DP trong CSDL " + query + e.Message);
                }
            }
        }
        public string VNPTId { get; set; } = "ANSV";
        public double DPQuantity { get; set; } = 0;

        public DPsObj() { }
        public DPsObj(int DPsId, string DPId, string VNPTId, double DPQuantity)
        {
            this.DPsId = DPsId;
            this.DPId = DPId;
            this.VNPTId = VNPTId;
            this.DPQuantity = DPQuantity;
        }
        public DPsObj(int id)
        {
            DPsId = id;
        }
        public DPsObj(DataRow row)
        {
            DPsId = (row["DPsId"] == null || row["DPsId"] == DBNull.Value) ? -1 : (int)row["DPsId"];
            DPId = (row["DPId"] == null || row["DPId"] == DBNull.Value) ? "XXXX/2022" : row["DPId"].ToString();
            VNPTId = (row["VNPTId"] == null || row["VNPTId"] == DBNull.Value) ? "ANSV" : row["VNPTId"].ToString();
            DPQuantity = (row["DPQuantity"] == null || row["DPQuantity"] == DBNull.Value) ? 0 : (double)row["DPQuantity"];
        }
        public bool DPsExist()
        {
            string query = string.Format("SELECT * FROM dbo.DPs WHERE DPsId = {0}", DPsId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool DPsExist(int DPsId)
        {
            string query = string.Format("SELECT * FROM dbo.DPs WHERE DPsId = {0}", DPsId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }

        public static void DPsDelete(int DPsId)
        {
            string query = string.Format("DELETE FROM dbo.DPs WHERE DPsId = {0}", DPsId);
            OPMDBHandler.ExecuteNonQuery(query);
        }

        public void DPsDelete()
        {
            string query = string.Format("DELETE FROM dbo.DPs WHERE DPsId = {0}", DPsId);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void DPsResetQuantityByIdPO(string DPId)
        {
            string query = string.Format("UPDATE dbo.DPs SET DPQuantity = 0 WHERE DPId = '{0}'", DPId);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static DataTable DPsGetTableByVNPTId(string VNPTId)
        {
            string query = string.Format("SELECT * FROM dbo.DPs Where VNPTId = '{0}' Order By DPId", VNPTId);
            return OPMDBHandler.ExecuteQuery(query); ;
        }
        public static List<DPObj> DPsGetListByVNPTId(string VNPTId)
        {
            List<DPObj> list = new List<DPObj>();
            string query = string.Format("SELECT * FROM dbo.DPs Where VNPTId = '{0}' Order By idPO_Thanh, phase", VNPTId);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DPObj dpo = new DPObj(item);
                list.Add(dpo);
            }
            return list;
        }

        public static DataTable DPsGetTableByDPId(string DPId)
        {
            string query = string.Format("SELECT * FROM dbo.DPs Where DPId = '{0}' Order By VNPTId", DPId);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static List<DPsObj> DPsGetListByDPId(string DPId)
        {
            List<DPsObj> list = new List<DPsObj>();
            DataTable dataTable = DPsGetTableByDPId(DPId);
            foreach (DataRow item in dataTable.Rows)
            {
                DPsObj DPs = new DPsObj(item);
                list.Add(DPs);
            }
            return list;
        }
        public static void DPsInsertOrUpdateList(List<DPObj> DPs)
        {
            foreach (DPObj dp in DPs)
            {
                if (dp.DPExist()) dp.DPUpdate();
                else dp.DPInsert();
            }
        }
        public static void DPsInsertOrUpdateTable(DataTable table)
        {
            foreach (DataRow item in table.Rows)
            {
                DPObj dp = new DPObj(item);
                if (dp.DPExist()) dp.DPUpdate();
                else dp.DPInsert();
            }
        }
        public void DPsUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DPs SET DPsId = {0}, DPId = '{1}', VNPTId = '{2}', DPQuantity = {3} WHERE DPsId = {0}", DPsId, DPId, VNPTId, DPQuantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void DPsUpdate(int DPsId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DPs SET DPsId = {0}, DPId = '{1}', VNPTId = '{2}', DPQuantity = {3} WHERE DPsId = {0}", DPsId, DPId, VNPTId, DPQuantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void DPsInsert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DPs(DPId,VNPTId,DPQuantity) VALUES('{0}','{1}',{2})", DPId, VNPTId, DPQuantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static double DPTotalQuantityByPOIdAndVNPTIdDetail(string POId, string VNPTId, int DPType = 0)
        {
            string query = string.Format(@"SELECT SUM(DPQuantity) FROM dbo.DPs,DP WHERE DPs.DPId = DP.DPId AND POId = '{0}' and DPs.VNPTId = '{1}' AND DP.DPType =  {2}", POId, VNPTId, DPType);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }
        public static double DPTotalQuantityByPOId(string POId, int DPType = 0)
        {
            string query = string.Format(@"SELECT SUM(DPQuantity) FROM dbo.DPs,DP WHERE DPs.DPId = DP.DPId AND DP.POId = '{0}' AND DP.DPType =  {1}", POId, DPType);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }
    }
}
