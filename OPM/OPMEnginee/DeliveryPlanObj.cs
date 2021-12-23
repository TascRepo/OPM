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
        string provinceId;
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
        public string ProvinceId { get => provinceId; set => provinceId = value; }
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

        public DeliveryPlanObj(string ProvinceId, string POId, double DeliveryPlanQuantity, double DeliveryPlanQuantity1, DateTime DeliveryPlanDate1, double DeliveryPlanQuantity2, DateTime DeliveryPlanDate2, double DeliveryPlanQuantity3, DateTime DeliveryPlanDate3, double DeliveryPlanQuantity4, DateTime DeliveryPlanDate4, double DeliveryPlanQuantity5, DateTime DeliveryPlanDate5, double DeliveryPlanQuantity6, DateTime DeliveryPlanDate6)
        {
            this.ProvinceId = ProvinceId;
            this.POId = POId;
            this.DeliveryPlanQuantity = DeliveryPlanQuantity;
            this.DeliveryPlanQuantity1 = DeliveryPlanQuantity1;
            this.DeliveryPlanDate1 = DeliveryPlanDate1;
            this.DeliveryPlanQuantity1 = DeliveryPlanQuantity2;
            this.DeliveryPlanDate1 = DeliveryPlanDate2;
            this.DeliveryPlanQuantity1 = DeliveryPlanQuantity3;
            this.DeliveryPlanDate1 = DeliveryPlanDate3;
            this.DeliveryPlanQuantity1 = DeliveryPlanQuantity4;
            this.DeliveryPlanDate1 = DeliveryPlanDate4;
            this.DeliveryPlanQuantity1 = DeliveryPlanQuantity5;
            this.DeliveryPlanDate1 = DeliveryPlanDate5;
            this.DeliveryPlanQuantity1 = DeliveryPlanQuantity6;
            this.DeliveryPlanDate1 = DeliveryPlanDate6;
        }
        public DeliveryPlanObj(string ProvinceId, string POId)
        {
            this.ProvinceId = ProvinceId;
            this.POId = POId;
            try
            {
                string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE ProvinceId = '{0}' and POId = ", ProvinceId, POId);
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
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
        public DeliveryPlanObj(DataRow row)
        {
            ProvinceId = (row["ProvinceId"] == null || row["ProvinceId"] == DBNull.Value) ? "" : row["ProvinceId"].ToString();
            POId = (row["POId"] == null || row["POId"] == DBNull.Value) ? "" : row["POId"].ToString();
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
        }
        public bool DeliveryPlanExist()
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE ProvinceId = '{0}' and POId = ", ProvinceId, POId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool DeliveryPlanExist(string ProvinceId, string POId)
        {
            string query = string.Format("SELECT * FROM dbo.DeliveryPlan WHERE ProvinceId = '{0}' and POId = ", ProvinceId, POId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int DeliveryPlanInsert(string ProvinceId, string POId)
        {
            if (DeliveryPlanObj.DeliveryPlanExist(ProvinceId, POId)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.DeliveryPlan(ProvinceId, POId, DeliveryPlanQuantity, DeliveryPlanQuantity1, DeliveryPlanDate1, DeliveryPlanQuantity2, DeliveryPlanDate2, DeliveryPlanQuantity3, DeliveryPlanDate3, DeliveryPlanQuantity4, DeliveryPlanDate4, DeliveryPlanQuantity5, DeliveryPlanDate5, DeliveryPlanQuantity6, DeliveryPlanDate6) VALUES ('{0}','{1}',{2},{3}, '{4}', {5}, '{6}', {7}, '{8}', {9}, '{10}', {11}, '{12}', {13}, '{14}')", ProvinceId, POId, DeliveryPlanQuantity, DeliveryPlanQuantity1, DeliveryPlanDate1.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity2, DeliveryPlanDate2.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity3, DeliveryPlanDate3.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity4, DeliveryPlanDate4.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity5, DeliveryPlanDate5.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity6, DeliveryPlanDate6.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DeliveryPlanUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DeliveryPlan SET  DeliveryPlanQuantity = {2}, DeliveryPlanQuantity1 = {3}, DeliveryPlanDate1 = '{4}', DeliveryPlanQuantity2 = {5}, DeliveryPlanDate2 = '{6}', DeliveryPlanQuantity3 = {7}, DeliveryPlanDate3 = '{8}', DeliveryPlanQuantity4 = {9}, DeliveryPlanDate4 = '{10}', DeliveryPlanQuantity5 = {11}, DeliveryPlanDate5 = '{12}', DeliveryPlanQuantity6 = {13}, DeliveryPlanDate6 = '{14}' Where ProvinceId = '{0}', POId = '{1}'", ProvinceId, POId, DeliveryPlanQuantity, DeliveryPlanQuantity1, DeliveryPlanDate1.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity2, DeliveryPlanDate2.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity3, DeliveryPlanDate3.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity4, DeliveryPlanDate4.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity5, DeliveryPlanDate5.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity6, DeliveryPlanDate6.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DeliveryPlanUpdate(string NewProvinceId, string NewPOId, string OldProvinceId, string OldPOId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DeliveryPlan SET NewProvinceId  = '{0}', NewPOId = '{1}',DeliveryPlanQuantity = {2}, DeliveryPlanQuantity1 = {3}, DeliveryPlanDate1 = '{4}', DeliveryPlanQuantity2 = {5}, DeliveryPlanDate2 = '{6}', DeliveryPlanQuantity3 = {7}, DeliveryPlanDate3 = '{8}', DeliveryPlanQuantity4 = {9}, DeliveryPlanDate4 = '{10}', DeliveryPlanQuantity5 = {11}, DeliveryPlanDate5 = '{12}', DeliveryPlanQuantity6 = {13}, DeliveryPlanDate6 = '{14}' Where OldProvinceId = '{15}', OldPOId = '{16}'", ProvinceId, POId, DeliveryPlanQuantity, DeliveryPlanQuantity1, DeliveryPlanDate1.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity2, DeliveryPlanDate2.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity3, DeliveryPlanDate3.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity4, DeliveryPlanDate4.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity5, DeliveryPlanDate5.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), DeliveryPlanQuantity6, DeliveryPlanDate6.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), OldProvinceId, OldPOId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int DeliveryPlanDelete()
        {
            string query = string.Format("Delete FROM dbo.DeliveryPlan WHERE ProvinceId  = '{0}', POId = '{1}'", ProvinceId, POId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static int DeliveryPlanDelete(string ProvinceId, string POId)
        {
            string query = string.Format("Delete FROM dbo.DeliveryPlan WHERE ProvinceId  = '{0}', POId = '{1}'", ProvinceId, POId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static DataTable DeliveryPlanGetTable()
        {
            string query = string.Format(@"SELECT  * FROM dbo.DeliveryPlan");
            return OPMDBHandler.ExecuteQuery(query);
        }

        public static DataTable DeliveryPlanGetTable(string POId)
        {
            string query = string.Format(@"SELECT ProvinceId,DeliveryPlanQuantity,DeliveryPlanQuantity1,DeliveryPlanDate1,DeliveryPlanQuantity2,DeliveryPlanDate2,DeliveryPlanQuantity3,DeliveryPlanDate3,DeliveryPlanQuantity4,DeliveryPlanDate4,DeliveryPlanQuantity5,DeliveryPlanDate5,DeliveryPlanQuantity6,DeliveryPlanDate6 FROM dbo.DeliveryPlan WHERE ProvinceId  = '{0}', POId = '{1}'", POId);
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
    }
}
