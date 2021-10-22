using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    class DeliveryPlan
    {
        string idPO_Thanh;
        string province;
        int phase = 0;
        int expectedQuantity = 0;
        DateTime expectedDate = DateTime.Now;

        public string IdPO_Thanh { get => idPO_Thanh; set => idPO_Thanh = value; }
        public string Province { get => province; set => province = value; }
        public int Phase { get => phase; set => phase = value; }
        public int ExpectedQuantity { get => expectedQuantity; set => expectedQuantity = value; }
        public DateTime ExpectedDate { get => expectedDate; set => expectedDate = value; }

        public DeliveryPlan() { }
        public DeliveryPlan(string idPO_Thanh, string province, int phase, int expectedQuantity, DateTime expectedDate)
        {
            IdPO_Thanh = idPO_Thanh;
            Province = province;
            Phase = phase;
            ExpectedQuantity = expectedQuantity;
            ExpectedDate = expectedDate;
        }
        public static void Delete(string idPO_Thanh, string province, int phase)
        {
            string query = string.Format("DELETE FROM dbo.DeliveryPlan WHERE idPO_Thanh = '{0}' AND province = N'{1}' AND phase = {2}", idPO_Thanh, province, phase);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void Delete(string idPO_Thanh, int phase)
        {
            string query = string.Format("DELETE FROM dbo.DeliveryPlan WHERE idPO_Thanh = '{0}' AND phase = {2}", idPO_Thanh, phase);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void Delete(string idPO)
        {
            string query = string.Format("DELETE FROM dbo.DeliveryPlan WHERE idPO_Thanh = '{0}'", idPO);
            OPMDBHandler.ExecuteNonQuery(query);
        }

        public void Delete()
        {
            string query = string.Format("DELETE FROM dbo.DeliveryPlan WHERE idPO_Thanh = '{0}' AND province = N'{1}' AND phase = {2}", idPO_Thanh, province, phase);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void ResetQuantityByIdPO(string idPO)
        {
            string query = string.Format("UPDATE dbo.DeliveryPlan SET expectedQuantity = 0 WHERE idPO_Thanh = '{0}'", idPO);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void ResetQuantityByIdPOAndTimes(string idPO, int times)
        {
            string query = string.Format("UPDATE dbo.DeliveryPlan SET expectedQuantity = 0 WHERE idPO_Thanh = '{0}' And phase = {1}", idPO, times);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static List<DeliveryPlan> GetListByProvince(string province)
        {
            List<DeliveryPlan> list = new List<DeliveryPlan>();
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan Where province = '{0}' Order By idPO_Thanh, phase", province);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DeliveryPlan dpo = new DeliveryPlan(item);
                list.Add(dpo);
            }
            return list;
        }
        public static List<DeliveryPlan> GetListByIdPO(string idPO)
        {
            List<DeliveryPlan> list = new List<DeliveryPlan>();
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan Where idPO_Thanh = '{0}' Order By phase, province", idPO);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DeliveryPlan dpo = new DeliveryPlan(item);
                list.Add(dpo);
            }
            return list;
        }
        public static List<DeliveryPlan> GetListByIdPOAndTimes(string idPO, int phase)
        {
            List<DeliveryPlan> list = new List<DeliveryPlan>();
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan Where idPO_Thanh = '{0}' AND phase = {1} Order By Province", idPO, phase);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                DeliveryPlan dpo = new DeliveryPlan(item);
                list.Add(dpo);
            }
            return list;
        }
        public static void InsertOrUpdateList(List<DeliveryPlan> deliveryPlans)
        {
            foreach (DeliveryPlan deliveryPlan in deliveryPlans)
            {
                if (deliveryPlan.Exist()) deliveryPlan.Update();
                else deliveryPlan.Insert();
            }
        }
        public static void InsertOrUpdateTable(DataTable table)
        {
            foreach (DataRow item in table.Rows)
            {
                DeliveryPlan deliveryPlan = new DeliveryPlan(item);
                if (deliveryPlan.Exist()) deliveryPlan.Update();
                else deliveryPlan.Insert();
            }
        }
        public void Update()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DeliveryPlan SET ExpectedQuantity = {3}, ExpectedDate = '{4}' WHERE IdPO_Thanh = '{0}' AND Province = N'{1}' AND Phase = {2})", idPO_Thanh, province, phase, expectedQuantity, expectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Insert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DeliveryPlan(IdPO_Thanh,Province,Phase,ExpectedQuantity,ExpectedDate) VALUES('{0}',N'{1}',{2},{3},'{4}')", idPO_Thanh, province, phase, expectedQuantity, expectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public DeliveryPlan(DataRow row)
        {
            IdPO_Thanh = row["IdPO_Thanh"].ToString();
            Province = row["Province"].ToString();
            Phase = (int)row["Phase"];
            ExpectedQuantity = (row["ExpectedQuantity"] == null || row["ExpectedQuantity"] == DBNull.Value) ? 0 : (int)row["ExpectedQuantity"];
            ExpectedDate = (row["ExpectedDate"] == null || row["ExpectedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ExpectedDate"];
        }
        public DeliveryPlan(string idPO, string province, int times)
        {
            IdPO_Thanh = idPO;
            Province = province;
            Phase = times;
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE IdPO_Thanh = '{0}' AND Province = N'{1}' AND Phase = {2}", idPO, province, times);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    ExpectedQuantity = (row["ExpectedQuantity"] == null || row["ExpectedQuantity"] == DBNull.Value) ? 0 : (int)row["ExpectedQuantity"];
                    ExpectedDate = (row["ExpectedDate"] == null || row["ExpectedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["ExpectedDate"];
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.DPO!");
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE IdPO_Thanh = '{0}' AND Province = N'{1}' AND Phase = {2}", idPO_Thanh, province, phase);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
    }
}
