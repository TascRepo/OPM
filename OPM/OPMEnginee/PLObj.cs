using OPM.DBHandler;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class PLObj : DPsObj
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
                        DPsId = (int)row["DPsId"];
                        PLDate = (row["PLDate"] == null || row["PLDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PLDate"];
                        PLDimension = (row["PLDimension"] == null || row["PLDimension"] == DBNull.Value) ? "55x45x31" : row["PLDimension"].ToString();
                        PLVolume = (row["PLVolume"] == null || row["PLVolume"] == DBNull.Value) ? 0 : (double)row["PLVolume"];
                        PLNetWeight = (row["PLNetWeight"] == null || row["PLNetWeight"] == DBNull.Value) ? 0 : (double)row["PLNetWeight"];
                        PLGrossWeight = (row["PLGrossWeight"] == null || row["PLGrossWeight"] == DBNull.Value) ? 0 : (double)row["PLGrossWeight"];
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng PL trong CSDL " + query + e.Message);
                }
            }
        }
        public DateTime PLDate { get; set; } = DateTime.Now;
        public string PLDimension { get; set; } = "55x45x31";
        public double PLVolume { get; set; } = 0;
        public double PLNetWeight { get; set; } = 0;
        public double PLGrossWeight { get; set; } = 0;
        public PLObj(string PLId, DateTime PLDate, string PLDimension, double PLVolume, double PLNetWeight, double PLGrossWeight)
        {
            this.PLId = PLId;
            this.PLDate = PLDate;
            this.PLDimension = PLDimension;
            this.PLVolume = PLVolume;
            this.PLNetWeight = PLNetWeight;
            this.PLGrossWeight = PLGrossWeight;
        }
        public PLObj(DataRow row)
        {
            PLId = row["PLId"].ToString();
            DPsId = (int)row["DPsId"];
            PLDate = (row["PLDate"] == null || row["PLDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PLDate"];
            PLDimension = (row["PLDimension"] == null || row["PLDimension"] == DBNull.Value) ? "55x45x31" : row["PLDimension"].ToString();
            PLVolume = (row["PLVolume"] == null || row["PLVolume"] == DBNull.Value) ? 0 : (double)row["PLVolume"];
            PLNetWeight = (row["PLNetWeight"] == null || row["PLNetWeight"] == DBNull.Value) ? 0 : (double)row["PLNetWeight"];
            PLGrossWeight = (row["PLGrossWeight"] == null || row["PLGrossWeight"] == DBNull.Value) ? 0 : (double)row["PLGrossWeight"];
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
        public static bool PLExist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.PL WHERE PLId = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int PLInsert(string id)
        {
            if (PLObj.PLExist(id)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PL(PLId,DPsId,PLDate,PLDimension,PLVolume,PLNetWeight,PLGrossWeight)VALUES('{0}',{1}, '{2}', '{3}', {4}, {5}, {6})", PLId, DPsId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLDimension, PLVolume, PLNetWeight, PLGrossWeight);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int PLUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PL SET DPsId = {1}, PLDate = '{2}', PLDimension = '{3}', PLVolume = {4}, PLNetWeight = {5}, PLGrossWeight = {6} Where PLId = '{0}'", PLId, DPsId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLDimension, PLVolume, PLNetWeight, PLGrossWeight);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int PLUpdate(string newId, string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PL SET PLId = '{0}', DPsId = {1}, PLDate = '{2}', PLDimension = '{3}', PLVolume = {4}, PLNetWeight = {5}, PLGrossWeight = {6} Where PLId = '{7}'", newId, DPsId, PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PLDimension, PLVolume, PLNetWeight, PLGrossWeight, oldId);
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
    }
}
