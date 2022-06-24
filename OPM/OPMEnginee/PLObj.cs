using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class PLObj : DPObj
    {
        private string pLId = "XXXXXXXX";

        public string PLId
        {
            get => pLId;
            set
            {
                pLId = value;
                string query = string.Format("SELECT * FROM dbo.PL WHERE PLId = '{0}'", value);
                try
                {
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        DPId = row["DPId"].ToString();
                        VNPTId = row["VNPTId"].ToString();
                        PLDate = (row["PLDate"] == null || row["PLDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PLDate"];
                        PLQuantity = (row["PLQuantity"] == null || row["PLQuantity"] == DBNull.Value) ? 0 : (int)row["PLQuantity"];
                        CaseQuantity = (row["CaseQuantity"] == null || row["CaseQuantity"] == DBNull.Value) ? 20 : (int)row["CaseQuantity"];
                        PLDimension = (row["PLDimension"] == null || row["PLDimension"] == DBNull.Value) ? "55x45x31" : row["PLDimension"].ToString();
                        PLVolume = (row["PLVolume"] == null || row["PLVolume"] == DBNull.Value) ? @"0.076" : row["PLVolume"].ToString();
                        PLNetWeight = (row["PLNetWeight"] == null || row["PLNetWeight"] == DBNull.Value) ? 15 : (double)row["PLNetWeight"];
                        PLGrossWeight = (row["PLGrossWeight"] == null || row["PLGrossWeight"] == DBNull.Value) ? 16 : (double)row["PLGrossWeight"];
                        PLQualityInspectionCertificateInFactoryDate = (row["PLQualityInspectionCertificateInFactoryDate"] == null || row["PLQualityInspectionCertificateInFactoryDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PLQualityInspectionCertificateInFactoryDate"];
                        PLQualityInspectionCertificateDate = (row["PLQualityInspectionCertificateDate"] == null || row["PLQualityInspectionCertificateDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PLQualityInspectionCertificateDate"];
                        PLReportForDeliveryNumber = (row["PLReportForDeliveryNumber"] == null || row["PLReportForDeliveryNumber"] == DBNull.Value) ? "BBBG" : row["PLReportForDeliveryNumber"].ToString();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng PL trong CSDL " + query + e.Message);
                }
            }
        }
        public string VNPTId { get; set; } = "XXXXXXXX";
        public DateTime PLDate { get; set; } = DateTime.Now;
        public int PLQuantity { get; set; } = 0;
        public double CaseQuantity { get; set; } = 20;
        public string PLDimension { get; set; } = "55x45x31";
        public string PLVolume { get; set; } = @"0.076";
        public double PLNetWeight { get; set; } = 15;
        public double PLGrossWeight { get; set; } = 16;
        public DateTime PLQualityInspectionCertificateInFactoryDate { get; set; } = DateTime.Now;
        public DateTime PLQualityInspectionCertificateDate { get; set; } = DateTime.Now;
        public string PLReportForDeliveryNumber { get; set; } = "BBBG";

        public PLObj(string PLId, string VNPTId, DateTime PLDate, int PLQuantity, double CaseQuantity, string PLDimension, string PLVolume, double PLNetWeight, double PLGrossWeight)
        {
            this.PLId = PLId;
            this.VNPTId = VNPTId; 
            this.PLDate = PLDate;
            this.PLQuantity = PLQuantity;
            this.CaseQuantity = CaseQuantity;
            this.PLDimension = PLDimension;
            this.PLVolume = PLVolume;
            this.PLNetWeight = PLNetWeight;
            this.PLGrossWeight = PLGrossWeight;
        }
        public PLObj(DataRow row)
        {
            PLId = row["PLId"].ToString();
            DPId = row["DPId"].ToString();
            VNPTId = row["VNPTId"].ToString();
            PLDate = (row["PLDate"] == null || row["PLDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PLDate"];
            PLQuantity = (row["PLQuantity"] == null || row["PLQuantity"] == DBNull.Value) ? 0 : (int)row["PLQuantity"];
            CaseQuantity = (row["CaseQuantity"] == null || row["CaseQuantity"] == DBNull.Value) ? 20 : (int)row["CaseQuantity"];
            PLDimension = (row["PLDimension"] == null || row["PLDimension"] == DBNull.Value) ? "55x45x31" : row["PLDimension"].ToString();
            PLVolume = (row["PLVolume"] == null || row["PLVolume"] == DBNull.Value) ? @"0.076" : row["PLVolume"].ToString();
            PLNetWeight = (row["PLNetWeight"] == null || row["PLNetWeight"] == DBNull.Value) ? 15 : (double)row["PLNetWeight"];
            PLGrossWeight = (row["PLGrossWeight"] == null || row["PLGrossWeight"] == DBNull.Value) ? 16 : (double)row["PLGrossWeight"];
            PLQualityInspectionCertificateInFactoryDate = (row["PLQualityInspectionCertificateInFactoryDate"] == null || row["PLQualityInspectionCertificateInFactoryDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PLQualityInspectionCertificateInFactoryDate"];
            PLQualityInspectionCertificateDate = (row["PLQualityInspectionCertificateDate"] == null || row["PLQualityInspectionCertificateDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PLQualityInspectionCertificateDate"];
            PLReportForDeliveryNumber = (row["PLReportForDeliveryNumber"] == null || row["PLReportForDeliveryNumber"] == DBNull.Value) ? "BBBG" : row["PLReportForDeliveryNumber"].ToString();
        }
        public PLObj(string PLId)
        {
            this.PLId = PLId;
        }
        public PLObj() { }
        public bool PLExist()
        {
            string query = string.Format("SELECT * FROM dbo.PL WHERE PLId = '{0}'", PLId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool PLExist(string PLId)
        {
            string query = string.Format("SELECT * FROM dbo.PL WHERE PLId = '{0}'", PLId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int PLInsert()
        {
            if (PLObj.PLExist(PLId)) return 0;
            PLVolume = PLVolume.Replace(',', '.');
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PL(PLId,DPId,VNPTId,PLDate,PLQuantity,CaseQuantity,PLDimension,PLVolume,PLNetWeight,PLGrossWeight,PLQualityInspectionCertificateInFactoryDate,PLQualityInspectionCertificateDate,PLReportForDeliveryNumber)VALUES('{0}','{1}', '{2}', '{3}', {4}, {5}, '{6}',{7}, {8}, {9},'{10}', '{11}', '{12}')", PLId, DPId, VNPTId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQuantity, CaseQuantity, PLDimension, PLVolume, PLNetWeight, PLGrossWeight, PLQualityInspectionCertificateInFactoryDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQualityInspectionCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLReportForDeliveryNumber);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int PLInsert(string PLId)
        {
            if (PLObj.PLExist(PLId)) return 0;
            PLVolume = PLVolume.Replace(',', '.');
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PL(PLId,DPId,VNPTId,PLDate,PLQuantity,CaseQuantity,PLDimension,PLVolume,PLNetWeight,PLGrossWeight,PLQualityInspectionCertificateInFactoryDate,PLQualityInspectionCertificateDate,PLReportForDeliveryNumber)VALUES('{0}','{1}', '{2}', '{3}', {4}, {5}, '{6}',{7}, {8}, {9},'{10}', '{11}', '{12}')", PLId, DPId, VNPTId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQuantity, CaseQuantity, PLDimension, PLVolume, PLNetWeight, PLGrossWeight, PLQualityInspectionCertificateInFactoryDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQualityInspectionCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLReportForDeliveryNumber);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int PLUpdate()
        {
            PLVolume = PLVolume.Replace(',', '.');
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PL SET PLId = '{0}', DPId = '{1}', VNPTId = '{2}', PLDate = '{3}', PLQuantity = {4}, CaseQuantity = {5}, PLDimension = '{6}', PLVolume = {7}, PLNetWeight = {8}, PLGrossWeight = {9}, PLQualityInspectionCertificateInFactoryDate = '{10}', PLQualityInspectionCertificateDate = '{11}',PLReportForDeliveryNumber = '{12}' Where PLId = '{0}'", PLId, DPId, VNPTId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQuantity, CaseQuantity, PLDimension, PLVolume, PLNetWeight, PLGrossWeight, PLQualityInspectionCertificateInFactoryDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQualityInspectionCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLReportForDeliveryNumber);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int PLUpdate(string newId, string oldId)
        {
            PLVolume = PLVolume.Replace(',', '.');
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PL SET PLId = '{0}', DPId = '{1}', VNPTId = '{2}', PLDate = '{3}', PLQuantity = {4}, CaseQuantity = {5}, PLDimension = '{6}', PLVolume = {7}, PLNetWeight = {8}, PLGrossWeight = {9}, PLQualityInspectionCertificateInFactoryDate = '{10}', PLQualityInspectionCertificateDate = '{11}',PLReportForDeliveryNumber = '{12}' Where PLId = '{13}'", newId, DPId, VNPTId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQuantity, CaseQuantity, PLDimension, PLVolume, PLNetWeight, PLGrossWeight, PLQualityInspectionCertificateInFactoryDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQualityInspectionCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLReportForDeliveryNumber, oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int PLDelete()
        {
            string query = string.Format("Delete FROM dbo.PL WHERE PLId = '{0}'", PLId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static int PLDelete(string PLId)
        {
            string query = string.Format("Delete FROM dbo.PL WHERE PLId = '{0}'", PLId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static DataTable PLGetTableByDPId(string DPId)
        {
            string query = string.Format("SELECT * FROM dbo.PL Where DPId = '{0}' Order By VNPTId", DPId);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static List<PLObj> PLGetListByDPId(string DPId)
        {
            List<PLObj> list = new List<PLObj>();
            DataTable dataTable = PLGetTableByDPId(DPId);
            foreach (DataRow item in dataTable.Rows)
            {
                PLObj pl = new PLObj(item);
                list.Add(pl);
            }
            return list;
        }
        public static double PLGetTotalQuantityByPOIdAndVNPTId(string POId,string VNPTId)
        {
            string query = string.Format(@"SELECT SUM(PL.PLQuantity) FROM dbo.PL,dbo.DP WHERE DPType = 0 AND PL.DPId = DP.DPId AND POId = '{0}' AND VNPTId = '{1}'", POId, VNPTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (int)tem1;
            return tem;
        }
        public static double PLGetTotalSpareQuantityByPOIdAndVNPTId(string POId, string VNPTId)
        {
            string query = string.Format(@"SELECT SUM(PL.PLQuantity) FROM dbo.PL,dbo.DP WHERE DPType = 1 AND PL.DPId = DP.DPId AND POId = '{0}' AND VNPTId = '{1}'", POId, VNPTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            int tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (int)tem1;
            return tem;
        }
        public static int PLGetTotalQuantityByDPIddAndNotEqualVNPTId(string DPId, string VNPTId)
        {
            string query = string.Format(@"SELECT SUM(PL.PLQuantity) FROM dbo.PL WHERE DPId  = '{0}' AND VNPTId != '{1}'", DPId, VNPTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            int tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (int)tem1;
            return tem;
        }
        public static DataTable GetDataTableByDPId(string DPId)
        {
            string query = string.Format("SELECT dbo.PL.VNPTId, dbo.Site.SiteName, PLQuantity FROM dbo.PL,dbo.Site WHERE dbo.PL.DPId='{0}' AND dbo.PL.VNPTId = dbo.Site.SiteId", DPId);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static DataTable GetDataTableByPOIdAndVNPTId(string POId,string VNPTId)
        {
            string query = string.Format("SELECT POId,DP.DPId,VNPTId,PLQuantity,DPResponseDate FROM dbo.PL LEFT JOIN dbo.DP ON DP.DPId = PL.DPId WHERE POId = '{0}' AND VNPTId = '{1}' ORDER BY DPResponseDate", POId,VNPTId);
            return OPMDBHandler.ExecuteQuery(query);
        }
   }
}
