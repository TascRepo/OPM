using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    class PODeliveryProgressObj:POObj
    {
        public string PODeliveryProgressVNPTId { get; set; } = "";
        public string PODeliveryProgressVNPTName { get; set; } = "";
        public double PODeliveryProgressDeliveryQuantity { get; set; } = 0;
        public DateTime PODeliveryProgressLastDeliveryDate { get; set; } = DateTime.Now;

        public double PODeliveryProgressDeliveredQuantity { get; set; } = 0;
        public DateTime PODeliveryProgressLastDeliveredDate { get; set; } = DateTime.Now;
        public double PODeliveryProgressRemainingQuantity => (PODeliveryProgressDeliveryQuantity - PODeliveryProgressDeliveredQuantity);

        public PODeliveryProgressObj(){}
        public PODeliveryProgressObj(DataRow row)
        {
            POId = row["POId"].ToString();
            PODeliveryProgressVNPTId = (row["PODeliveryProgressVNPTId"] == null || row["PODeliveryProgressVNPTId"] == DBNull.Value) ? "" : row["PODeliveryProgressVNPTId"].ToString();
            PODeliveryProgressVNPTName = (row["PODeliveryProgressVNPTName"] == null || row["PODeliveryProgressVNPTName"] == DBNull.Value) ? "" : row["PODeliveryProgressVNPTName"].ToString();
            PODeliveryProgressDeliveryQuantity = (row["PODeliveryProgressDeliveryQuantity"] == null || row["PODeliveryProgressDeliveryQuantity"] == DBNull.Value) ? 0 : (double)row["PODeliveryProgressDeliveryQuantity"];
            PODeliveryProgressLastDeliveryDate = (row["PODeliveryProgressLastDeliveryDate"] == null || row["PODeliveryProgressLastDeliveryDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODeliveryProgressLastDeliveryDate"];
            PODeliveryProgressDeliveredQuantity = (row["PODeliveryProgressDeliveredQuantity"] == null || row["PODeliveryProgressDeliveredQuantity"] == DBNull.Value) ? 0 : (int)row["PODeliveryProgressDeliveredQuantity"];
            PODeliveryProgressLastDeliveredDate = (row["PODeliveryProgressLastDeliveredDate"] == null || row["PODeliveryProgressLastDeliveredDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODeliveryProgressLastDeliveredDate"];
        }
        public static DataTable PODeliveryProgressGetDataTableByPOId(string POId)
        {
            string query = string.Format("SELECT * FROM (SELECT temp.POId,temp.VNPTId as PODeliveryProgressVNPTId,SiteName AS PODeliveryProgressVNPTName,temp.DeliveryQuantity as PODeliveryProgressDeliveryQuantity,temp.LastDeliveryDate as PODeliveryProgressLastDeliveryDate,temp.DeliveredQuantity as PODeliveryProgressDeliveredQuantity,temp.LastDeliveredDate as PODeliveryProgressLastDeliveredDate FROM (SELECT temp1.POId,temp1.VNPTId,temp1.DeliveryQuantity,temp1.LastDeliveryDate,temp2.DeliveredQuantity,temp2.LastDeliveredDate FROM (SELECT POId,VNPTId, SUM(DeliveryPlanQuantity) AS DeliveryQuantity, MAX(DeliveryPlanDate) AS LastDeliveryDate FROM dbo.DeliveryPlan GROUP BY POId,VNPTId) AS temp1 LEFT JOIN (SELECT POId,VNPTId,SUM(PLQuantity) AS DeliveredQuantity,MAX(DPResponseDate) AS LastDeliveredDate FROM dbo.PL,dbo.DP WHERE PL.DPId = DP.DPId AND DPType = 0 GROUP BY POId,VNPTId)AS temp2 ON temp2.POId = temp1.POId AND temp1.VNPTId = temp2.VNPTId) AS temp LEFT JOIN dbo.Site ON SiteId = temp.VNPTId) AS PODeliveryProgress WHERE PODeliveryProgress.POId = '{0}' ORDER BY PODeliveryProgress.PODeliveryProgressVNPTId", POId);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static List<PODeliveryProgressObj> PODeliveryProgressGetListByPOId(string POId)
        {
            List<PODeliveryProgressObj> list = new List<PODeliveryProgressObj>();
            DataTable table = PODeliveryProgressGetDataTableByPOId(POId);
            foreach(DataRow row in table.Rows)
            {
                PODeliveryProgressObj temp = new PODeliveryProgressObj(row);
                list.Add(temp);
            }
            return list;
        }
    }
}
