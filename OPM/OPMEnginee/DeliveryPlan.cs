using OPM.OPMEnginee;
using System;
using System.Data;
using System.Windows.Forms;

namespace OPM.DBHandler
{
    public partial class DeliveryPlan:POObj
    {
        private string provinceId;
        public string ProvinceId
        {
            get => provinceId;
            set
            {
                ProvinceId = value;
                try
                {
                    string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE ProvinceId = '{0}'", value);
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        POId = row["POId"].ToString();
                        DeliveryPlanQuantity = (row["DeliveryPlanQuantity"] == null || row["DeliveryPlanQuantity"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity"];
                        DeliveryPlanQuantity1 = (row["DeliveryPlanQuantity1"] == null || row["DeliveryPlanQuantity1"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity1"];
                        DeliveryPlanDate1 = (row["DeliveryPlanDate1"] == null || row["DeliveryPlanDate1"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DeliveryPlanDate1"];
                        DeliveryPlanQuantity2 = (row["DeliveryPlanQuantity2"] == null || row["DeliveryPlanQuantity2"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity2"];
                        DeliveryPlanDate2 = (row["DeliveryPlanDate2"] == null || row["DeliveryPlanDate2"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DeliveryPlanDate2"];
                        DeliveryPlanQuantity3 = (row["DeliveryPlanQuantity3"] == null || row["DeliveryPlanQuantity3"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity3"];
                        DeliveryPlanDate3 = (row["DeliveryPlanDate3"] == null || row["DeliveryPlanDate3"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DeliveryPlanDate3"];
                        DeliveryPlanQuantity4 = (row["DeliveryPlanQuantity4"] == null || row["DeliveryPlanQuantity4"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity4"];
                        DeliveryPlanDate4 = (row["DeliveryPlanDate4"] == null || row["DeliveryPlanDate4"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DeliveryPlanDate4"];
                        DeliveryPlanQuantity5 = (row["DeliveryPlanQuantity5"] == null || row["DeliveryPlanQuantity5"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity5"];
                        DeliveryPlanDate5 = (row["DeliveryPlanDate5"] == null || row["DeliveryPlanDate5"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DeliveryPlanDate5"];
                        DeliveryPlanQuantity6 = (row["DeliveryPlanQuantity6"] == null || row["DeliveryPlanQuantity6"] == DBNull.Value) ? 0 : (double)row["DeliveryPlanQuantity6"];
                        DeliveryPlanDate6 = (row["DeliveryPlanDate6"] == null || row["DeliveryPlanDate6"] == DBNull.Value) ? DateTime.Now : (DateTime)row["DeliveryPlanDate6"];
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng DeliveryPlan trong CSDL " + e.Message);
                }
            }
        }
        double deliveryPlanQuantity;
        double deliveryPlanQuantity1;
        DateTime deliveryPlanDate1;
        double deliveryPlanQuantity2;
        DateTime deliveryPlanDate2;
        double deliveryPlanQuantity3;
        DateTime deliveryPlanDate3;
        double deliveryPlanQuantity4;
        DateTime deliveryPlanDate4;
        double deliveryPlanQuantity5;
        DateTime deliveryPlanDate5;
        double deliveryPlanQuantity6;
        DateTime deliveryPlanDate6;

        public double DeliveryPlanQuantity { get => deliveryPlanQuantity; set => deliveryPlanQuantity = value; }
        public double DeliveryPlanQuantity1 { get => deliveryPlanQuantity1; set => deliveryPlanQuantity1 = value; }
        public DateTime DeliveryPlanDate1 { get => deliveryPlanDate1; set => deliveryPlanDate1 = value; }
        public double DeliveryPlanQuantity2 { get => deliveryPlanQuantity2; set => deliveryPlanQuantity2 = value; }
        public DateTime DeliveryPlanDate2 { get => deliveryPlanDate2; set => deliveryPlanDate2 = value; }
        public double DeliveryPlanQuantity3 { get => deliveryPlanQuantity3; set => deliveryPlanQuantity3 = value; }
        public DateTime DeliveryPlanDate3 { get => deliveryPlanDate3; set => deliveryPlanDate3 = value; }
        public double DeliveryPlanQuantity4 { get => deliveryPlanQuantity4; set => deliveryPlanQuantity4 = value; }
        public DateTime DeliveryPlanDate4 { get => deliveryPlanDate4; set => deliveryPlanDate4 = value; }
        public double DeliveryPlanQuantity5 { get => deliveryPlanQuantity5; set => deliveryPlanQuantity5 = value; }
        public DateTime DeliveryPlanDate5 { get => deliveryPlanDate5; set => deliveryPlanDate5 = value; }
        public double DeliveryPlanQuantity6 { get => deliveryPlanQuantity6; set => deliveryPlanQuantity6 = value; }
        public DateTime DeliveryPlanDate6 { get => deliveryPlanDate6; set => deliveryPlanDate6 = value; }

        
    }
}
