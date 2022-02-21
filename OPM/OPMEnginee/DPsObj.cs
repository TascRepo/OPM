using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        public DPsObj(int DPsId, string DPId, DateTime DPDate)
        {
            this.DPsId = DPsId;
            this.POId = DPId;
            this.DPDate = DPDate;
        }
        public DPsObj(int id)
        {
            DPsId = id;
        }
        public DPsObj(DataRow row)
        {
            DPsId = (row["DPId"] == null || row["DPId"] == DBNull.Value) ? -1 : (int)row["DPId"];
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
        public static DataTable DPsGetTableByPOId(string POId)
        {
            string query = string.Format("SELECT * FROM dbo.DPs Where POId = '{0}' Order By VNPTId", POId);
            return OPMDBHandler.ExecuteQuery(query);
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
        public static List<DPObj> DPsGetListByPOId(string POId)
        {
            List<DPObj> list = new List<DPObj>();
            string query = string.Format("SELECT * FROM dbo.DPs Where POId = '{0}' Order By VNPTId", POId);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DPObj dp = new DPObj(item);
                list.Add(dp);
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
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DPs SET DPsId = {0}, DPId = '{1}', VNPTId = '{2}', DPQuantity = {3} WHERE DPId = {0}", DPsId, DPId, VNPTId, DPQuantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void DPsUpdate(int DPId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DPs SET DPsId = {0}, DPId = '{1}', VNPTId = '{2}', DPQuantity = {3} WHERE DPId = {0}", DPsId, DPId, VNPTId, DPQuantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void DPsInsert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DPs(POId,VNPTId,DPQuantity) VALUES({0},'{1}','{2}')", DPId, VNPTId, DPQuantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }
    }
}
