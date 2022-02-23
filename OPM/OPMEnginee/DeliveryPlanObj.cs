using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.DBHandler
{
    public partial class DeliveryPlanObj : POObj
    {
        int deliveryPlanId = -1;
        string vNPTId = "XXXXXX";
        double deliveryPlanQuantity = 0;
        DateTime deliveryPlanDate = DateTime.Now;

        public int DeliveryPlanId { get => deliveryPlanId; set => deliveryPlanId = value; }
        public string VNPTId { get => vNPTId; set => vNPTId = value; }
        public double DeliveryPlanQuantity { get => deliveryPlanQuantity; set => deliveryPlanQuantity = value; }
        public DateTime DeliveryPlanDate { get => deliveryPlanDate; set => deliveryPlanDate = value; }

        public DeliveryPlanObj(int DeliveryPlanId, string POId, string VNPTId, double DeliveryPlanQuantity, DateTime DeliveryPlanDate)
        {
            this.DeliveryPlanId = DeliveryPlanId;
            this.POId = POId;
            this.VNPTId = VNPTId;
            this.DeliveryPlanQuantity = DeliveryPlanQuantity;
            this.DeliveryPlanDate = DeliveryPlanDate;
        }
        public DeliveryPlanObj() { }
        public DeliveryPlanObj(int DeliveryPlanId)
        {
            this.DeliveryPlanId = DeliveryPlanId;
            try
            {
                string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE DeliveryPlanId = '{0}'", DeliveryPlanId);
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    POId = (row["POId"] == null || row["POId"] == DBNull.Value) ? "XXXX/CUVT-KV" : row["POId"].ToString();
                    VNPTId = (row["VNPTId"] == null || row["VNPTId"] == DBNull.Value) ? "XXXXXXXX" : row["VNPTId"].ToString();
                    DeliveryPlanQuantity = (row["DeliveryPlanQuantity"] == null || row["DeliveryPlanQuantity"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity"];
                    DeliveryPlanDate = (row["DeliveryPlanDate"] == null || row["DeliveryPlanDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DeliveryPlanDate"];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi kết nối bảng DeliveryPlan trong CSDL " + e.Message);
            }
        }
        public DeliveryPlanObj(DataRow row)
        {
            DeliveryPlanId = (row["DeliveryPlanId"] == null || row["DeliveryPlanId"] == DBNull.Value) ? 0 : (int)row["DeliveryPlanId"];
            POId = (row["POId"] == null || row["POId"] == DBNull.Value) ? "XXXX/CUVT-KV" : row["POId"].ToString();
            VNPTId = (row["VNPTId"] == null || row["VNPTId"] == DBNull.Value) ? "XXXXXXXX" : row["VNPTId"].ToString();
            DeliveryPlanQuantity = (row["DeliveryPlanQuantity"] == null || row["DeliveryPlanQuantity"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity"];
            DeliveryPlanDate = (row["DeliveryPlanDate"] == null || row["DeliveryPlanDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DeliveryPlanDate"];
        }
        public static bool DeliveryPlanExist(string POId, string VNPTId)
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE POId = '{0}' and VNPTId = '{1}'", POId, VNPTId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public bool DeliveryPlanExist()
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE DeliveryPlanId = '{0}'", DeliveryPlanId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool DeliveryPlanExist(int DeliveryPlanId)
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE DeliveryPlanId = '{0}'", DeliveryPlanId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool DeliveryPlanExist(string POId)
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE POId = '{0}'", POId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }

        public int DeliveryPlanInsert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DeliveryPlan(POId, VNPTId, DeliveryPlanQuantity, DeliveryPlanDate) VALUES ('{0}','{1}',{2},'{3}')", POId, VNPTId, DeliveryPlanQuantity, DeliveryPlanDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int DeliveryPlanUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DeliveryPlan SET  POId = '{1}', VNPTId = '{2}', DeliveryPlanQuantity = {3}, DeliveryPlanDate = '{4}' Where DeliveryPlanId = '{0}'", DeliveryPlanId, POId, VNPTId, DeliveryPlanQuantity, DeliveryPlanDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int DeliveryPlanDelete()
        {
            string query = string.Format("Delete FROM dbo.DeliveryPlan WHERE DeliveryPlanId  = '{0}'", DeliveryPlanId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static int DeliveryPlanDelete(int DeliveryPlanId)
        {
            string query = string.Format("Delete FROM dbo.DeliveryPlan WHERE DeliveryPlanId  = '{0}'", DeliveryPlanId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static DataTable DeliveryPlanGetTable()
        {
            string query = string.Format(@"SELECT * FROM dbo.DeliveryPlan ORDER BY VNPTId");
            return OPMDBHandler.ExecuteQuery(query);
        }

        public static DataTable DeliveryPlanGetTable(string POId)
        {
            string query = string.Format(@"SELECT * FROM dbo.DeliveryPlan WHERE POId = '{0}' ORDER BY VNPTId, DeliveryPlanDate", POId);
            return OPMDBHandler.ExecuteQuery(query);
        }

        public static List<DeliveryPlanObj> DeliveryPlanGetList(string POId)
        {
            List<DeliveryPlanObj> list = new List<DeliveryPlanObj>();
            DataTable dataTable = DeliveryPlanGetTable(POId);
            foreach (DataRow item in dataTable.Rows)
            {
                DeliveryPlanObj deliveryPlanObj = new DeliveryPlanObj(item);
                list.Add(deliveryPlanObj);
            }
            return list;
        }

        public static DataTable DeliveryPlanGetTable(string POId, string VNPTId)
        {
            string query = string.Format(@"SELECT * FROM dbo.DeliveryPlan WHERE POId = '{0}'and VNPTd = '{1}' ORDER BY VNPTId", POId, VNPTId);
            return OPMDBHandler.ExecuteQuery(query);
        }

        public static List<DeliveryPlanObj> DeliveryPlanGetList(string POId, string VNPTId)
        {
            List<DeliveryPlanObj> list = new List<DeliveryPlanObj>();
            DataTable dataTable = DeliveryPlanGetTable(POId,VNPTId);
            foreach (DataRow item in dataTable.Rows)
            {
                DeliveryPlanObj deliveryPlanObj = new DeliveryPlanObj(item);
                list.Add(deliveryPlanObj);
            }
            return list;
        }

        public static double DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(string POId, string VNPTId)
        {
            string query = string.Format(@"SELECT SUM(DeliveryPlanQuantity) FROM dbo.DeliveryPlan WHERE POId = '{0}' and VNPTId = '{1}'", POId, VNPTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }
        public static double DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail(string POId, string VNPTId)
        {
            string query = string.Format(@"SELECT SUM(DeliveryPlanQuantity) FROM dbo.DeliveryPlan WHERE POId = '{0}' and VNPTId = '{1}'", POId, VNPTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return Math.Round(tem * 0.02, 0, MidpointRounding.AwayFromZero);
        }

        public static double DeliveryPlanTotalQuantityByPOId(string POId)
        {
            //string query = string.Format(@"SELECT SUM(tam.DeliveryPlanQuantity) FROM (SELECT DISTINCT VNPTId, DeliveryPlanQuantity FROM dbo.DeliveryPlan WHERE POId = '{0}') tam", POId);
            string query = string.Format(@"SELECT SUM(DeliveryPlanQuantity) FROM dbo.DeliveryPlan WHERE POId = '{0}'", POId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }
        public static double DeliveryPlanTotalSpareQuantityByPOId(string POId)
        {
            //string query = string.Format(@"SELECT SUM(tam.DeliveryPlanQuantity) FROM (SELECT DISTINCT VNPTId, DeliveryPlanQuantity FROM dbo.DeliveryPlan WHERE POId = '{0}') tam", POId);
            string query = string.Format(@"SELECT SUM(DeliveryPlanQuantity) FROM dbo.DeliveryPlan WHERE POId = '{0}'", POId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return Math.Round(tem * 0.02, 0, MidpointRounding.AwayFromZero);
        }

    }
}
