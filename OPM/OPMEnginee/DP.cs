using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    class DP:POObj
    {
        string dPId = @"XXXX/202X";
        public string DPId 
        { 
            get => dPId;
            set
            {
                dPId = value;
                try
                {
                    string query = string.Format("SELECT * FROM dbo.DP WHERE DPId = '{0}'", value);
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        POId = (row["POId"] == null || row["POId"] == DBNull.Value) ? "" : row["POId"].ToString();
                        ProvinceId = (row["ProvinceId"] == null || row["ProvinceId"] == DBNull.Value) ? "" : row["ProvinceId"].ToString();
                        DPPhase = (row["DPPhase"] == null || row["DPPhase"] == DBNull.Value) ? "0" : row["DPPhase"].ToString();
                        DPQuantity = (row["DPQuantity"] == null || row["DPQuantity"] == DBNull.Value) ? 0 : (double)row["DPQuantity"];
                        DPDate = (row["DPDate"] == null || row["DPDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DPDate"];
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng DP trong CSDL " + e.Message);
                }
            }
        }
        public string ProvinceId { get; set; }
        public string DPPhase { get; set; }
        public double DPQuantity { get; set; } = 0;
        public DateTime DPDate { get; set; } = DateTime.Now;

        public DP() { }
        public DP(string DPId, string ProvinceId, string DPPhase, double DPQuantity, DateTime DPDate)
        {
            this.DPId = DPId;
            this.ProvinceId = ProvinceId;
            this.DPPhase = DPPhase;
            this.DPQuantity = DPQuantity;
            this.DPDate = DPDate;
        }
        public DP(string id)
        {
            DPId = id;
        }
        public static void Delete(string idPO_Thanh, string province, int phase)
        {
            string query = string.Format("DELETE FROM dbo.DP WHERE DPId = '{0}' AND province = N'{1}' AND phase = {2}", idPO_Thanh, province, phase);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void Delete(string DPId, int phase)
        {
            string query = string.Format("DELETE FROM dbo.DP WHERE DPId = '{0}' AND phase = {2}", DPId, phase);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void DPDelete(string idPO)
        {
            string query = string.Format("DELETE FROM dbo.DP WHERE DPId = '{0}'", idPO);
            OPMDBHandler.ExecuteNonQuery(query);
        }

        public void DPDelete()
        {
            string query = string.Format("DELETE FROM dbo.DP WHERE idPO_Thanh = '{0}' AND province = N'{1}' AND phase = {2}", dPId, ProvinceId, DPPhase);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void ResetQuantityByIdPO(string idPO)
        {
            string query = string.Format("UPDATE dbo.DP SET expectedQuantity = 0 WHERE idPO_Thanh = '{0}'", idPO);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void ResetQuantityByIdPOAndTimes(string idPO, int times)
        {
            string query = string.Format("UPDATE dbo.DP SET expectedQuantity = 0 WHERE idPO_Thanh = '{0}' And phase = {1}", idPO, times);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static List<DP> GetListByProvince(string province)
        {
            List<DP> list = new List<DP>();
            string query = string.Format("SELECT * FROM dbo.DP Where province = '{0}' Order By idPO_Thanh, phase", province);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DP dpo = new DP(item);
                list.Add(dpo);
            }
            return list;
        }
        public static List<DP> GetListByIdPO(string idPO)
        {
            List<DP> list = new List<DP>();
            string query = string.Format("SELECT * FROM dbo.DP Where idPO_Thanh = '{0}' Order By phase, province", idPO);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DP dpo = new DP(item);
                list.Add(dpo);
            }
            return list;
        }
        public static List<DP> GetListByIdPOAndTimes(string idPO, int phase)
        {
            List<DP> list = new List<DP>();
            string query = string.Format("SELECT * FROM dbo.DP Where idPO_Thanh = '{0}' AND phase = {1} Order By Province", idPO, phase);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DP dpo = new DP(item);
                list.Add(dpo);
            }
            return list;
        }
        public static void InsertOrUpdateList(List<DP> deliveryPlans)
        {
            foreach (DP deliveryPlan in deliveryPlans)
            {
                if (deliveryPlan.Exist()) deliveryPlan.Update();
                else deliveryPlan.Insert();
            }
        }
        public static void InsertOrUpdateTable(DataTable table)
        {
            foreach (DataRow item in table.Rows)
            {
                DP deliveryPlan = new DP(item);
                if (deliveryPlan.Exist()) deliveryPlan.Update();
                else deliveryPlan.Insert();
            }
        }
        public void Update()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DP SET ExpectedQuantity = {3}, ExpectedDate = '{4}' WHERE IdPO_Thanh = '{0}' AND Province = N'{1}' AND Phase = {2})", dPId, ProvinceId, DPPhase, DPQuantity, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Insert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DP(IdPO_Thanh,Province,Phase,ExpectedQuantity,ExpectedDate) VALUES('{0}',N'{1}',{2},{3},'{4}')", dPId, ProvinceId, DPPhase, DPQuantity, DPDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public DP(DataRow row)
        {
            DPId = row["IdPO_Thanh"].ToString();
            ProvinceId = row["Province"].ToString();
            DPPhase = row["Phase"].ToString();
            DPQuantity = (row["ExpectedQuantity"] == null || row["ExpectedQuantity"] == DBNull.Value) ? 0 : (int)row["ExpectedQuantity"];
            DPDate = (row["ExpectedDate"] == null || row["ExpectedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ExpectedDate"];
        }
        public DP(string idPO, string province, string DPPhase)
        {
            DPId = idPO;
            ProvinceId = province;
            this.DPPhase = DPPhase;
            string query = string.Format("SELECT * FROM dbo.DP WHERE IdPO_Thanh = '{0}' AND Province = N'{1}' AND Phase = {2}", idPO, province, DPPhase);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    DPQuantity = (row["ExpectedQuantity"] == null || row["ExpectedQuantity"] == DBNull.Value) ? 0 : (int)row["ExpectedQuantity"];
                    DPDate = (row["ExpectedDate"] == null || row["ExpectedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ExpectedDate"];
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.DPO!");
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.DP WHERE IdPO_Thanh = '{0}' AND Province = N'{1}' AND Phase = {2}", dPId, ProvinceId, DPPhase);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
    }
}
