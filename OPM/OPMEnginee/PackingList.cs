using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class PackingListObj : PLObj
    {
        public string CaseNumber => Math.Round(POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero);

        public string VNPTId { get; set; } = "XXXXXXXX";
        public DateTime PLDate { get; set; } = DateTime.Now;
        public double PLQuantity { get; set; } = 0;
        public double CaseQuantity { get; set; } = 20;
        public string PLDimension { get; set; } = "55x45x31";
        public double PLVolume { get; set; } = 0.076;
        public double PLNetWeight { get; set; } = 15;
        public double PLGrossWeight { get; set; } = 16;
        public PLObj(string PLId, string VNPTId, DateTime PLDate, double PLQuantity, double CaseQuantity, string PLDimension, double PLVolume, double PLNetWeight, double PLGrossWeight)
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
            PLQuantity = (row["PLQuantity"] == null || row["PLQuantity"] == DBNull.Value) ? 0 : (double)row["PLQuantity"];
            CaseQuantity = (row["CaseQuantity"] == null || row["CaseQuantity"] == DBNull.Value) ? 20 : (double)row["CaseQuantity"];
            PLDimension = (row["PLDimension"] == null || row["PLDimension"] == DBNull.Value) ? "55x45x31" : row["PLDimension"].ToString();
            PLVolume = (row["PLVolume"] == null || row["PLVolume"] == DBNull.Value) ? 0.076 : (double)row["PLVolume"];
            PLNetWeight = (row["PLNetWeight"] == null || row["PLNetWeight"] == DBNull.Value) ? 15 : (double)row["PLNetWeight"];
            PLGrossWeight = (row["PLGrossWeight"] == null || row["PLGrossWeight"] == DBNull.Value) ? 16 : (double)row["PLGrossWeight"];
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
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PL(PLId,DPId,VNPTId,PLDate,PLQuantity,CaseQuantity,PLDimension,PLVolume,PLNetWeight,PLGrossWeight)VALUES('{0}','{1}', '{2}', '{3}', {4}, {5}, '{6}',{7}, {8}, {9})", PLId, DPId, VNPTId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQuantity, CaseQuantity, PLDimension, PLVolume, PLNetWeight, PLGrossWeight);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int PLInsert(string id)
        {
            if (PLObj.PLExist(id)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PL(PLId,DPId,VNPTId,PLDate,PLQuantity,CaseQuantity,PLDimension,PLVolume,PLNetWeight,PLGrossWeight)VALUES('{0}','{1}', '{2}', '{3}', {4}, {5}, '{6}',{7}, {8}, {9})", id, DPId, VNPTId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQuantity, CaseQuantity, PLDimension, PLVolume, PLNetWeight, PLGrossWeight);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int PLUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PL SET PLId = '{0}', DPId = '{1}', VNPTId = '{2}', PLDate = '{3}', PLQuantity = {4}, CaseQuantity = {5}, PLDimension = '{6}', PLVolume = {7}, PLNetWeight = {8}, PLGrossWeight = {9} Where PLId = '{0}'", PLId, DPId, VNPTId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQuantity, CaseQuantity, PLDimension, PLVolume, PLNetWeight, PLGrossWeight);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int PLUpdate(string newId, string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PL SET PLId = '{0}', DPId = '{1}', VNPTId = '{2}', PLDate = '{3}', PLQuantity = {4}, CaseQuantity = {5}, PLDimension = '{6}', PLVolume = {7}, PLNetWeight = {8}, PLGrossWeight = {9} Where PLId = '{10}'", newId, DPId, VNPTId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLQuantity, CaseQuantity, PLDimension, PLVolume, PLNetWeight, PLGrossWeight, oldId);
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
        public static double PLGetTotalQuantityByPOIdAndVNPTId(string POId, string VNPTId)
        {
            string query = string.Format(@"SELECT SUM(PL.PLQuantity) FROM dbo.PL,dbo.DP WHERE DPType = 0 AND PL.DPId = DP.DPId AND POId = '{0}' AND VNPTId = '{1}'", POId, VNPTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }
        public static double PLGetTotalSpareQuantityByPOIdAndVNPTId(string POId, string VNPTId)
        {
            string query = string.Format(@"SELECT SUM(PL.PLQuantity) FROM dbo.PL,dbo.DP WHERE DPType = 1 AND PL.DPId = DP.DPId AND POId = '{0}' AND VNPTId = '{1}'", POId, VNPTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }
        public static double PLGetTotalQuantityByDPIddAndNotEqualVNPTId(string DPId, string VNPTId)
        {
            string query = string.Format(@"SELECT SUM(PL.PLQuantity) FROM dbo.PL WHERE DPId  = '{0}' AND VNPTId != '{1}'", DPId, VNPTId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }

    }
}
