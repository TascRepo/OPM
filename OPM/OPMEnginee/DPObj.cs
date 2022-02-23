﻿using OPM.DBHandler;
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
                        DPRemarks = (row["DPRemarks"] == null || row["DPRemarks"] == DBNull.Value) ? "" : row["DPRemarks"].ToString();
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
        public string DPRemarks { get; set; } = "";

        public DPObj() { }
        public DPObj(string DPId, string POId, DateTime DPDate, int DPType, string DPRemarks)
        {
            this.DPId = DPId;
            this.POId = POId;
            this.DPDate = DPDate;
            this.DPType = DPType;
            this.DPRemarks = DPRemarks;
        }
        public DPObj(string id)
        {
            DPId = id;
        }
        public DPObj(DataRow row)
        {
            DPId = (row["DPId"] == null || row["DPId"] == DBNull.Value) ? @"XXXX/2021" : row["DPId"].ToString();
            POId = (row["POId"] == null || row["POId"] == DBNull.Value) ? "XXXX/CUVT-KV" : row["POId"].ToString();
            DPDate = (row["DPDate"] == null || row["DPDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DPDate"];
            DPType = (row["DPType"] == null || row["DPType"] == DBNull.Value) ? 0 : (int)row["DPType"];
            DPRemarks = (row["DPRemarks"] == null || row["DPRemarks"] == DBNull.Value) ? "" : row["DPRemarks"].ToString();
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
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DP SET DPId = '{0}', POId = '{1}', DPDate = '{2}', DPType = {3}, DPRemarks = N'{4}' WHERE DPId = '{0}'", DPId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPRemarks);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void DPUpdate(int DPId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DP SET DPId = '{0}', POId = '{1}', DPDate = '{2}', DPType = {3}, DPRemarks = N'{4}' WHERE DPId = '{0}'", DPId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPRemarks);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DPUpdate(string newId, string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DP SET DPId = '{0}', POId = '{1}', DPDate = '{2}', DPType = {3}, DPRemarks = N'{4}' WHERE DPId = '{5}'", newId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPRemarks, oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DPInsert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DP(DPId,POId,DPDate,DPType,DPRemarks) VALUES('{0}','{1}','{2}',{3},N'{4}')", DPId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPRemarks);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DPInsert(string id)
        {
            if (DPObj.DPExist(id)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DP(DPId,POId,DPDate,DPType,DPRemarks) VALUES('{0}','{1}','{2}',{3},N'{4}')", DPId, POId, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DPType, DPRemarks);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
    }
}
