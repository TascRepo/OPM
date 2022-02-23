using OPM.DBHandler;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class CaseObj : PLObj
    {
        private string caseId = "XXXXXXXX_XXX";

        public string CaseId
        {
            get => caseId;
            set
            {
                caseId = value;
                string query = string.Format("SELECT * FROM dbo.PL WHERE PLId = '{0}'", value);
                try
                {
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        PLId = row["PLId"].ToString();
                        CaseQuantity = (row["CaseQuantity"] == null || row["CaseQuantity"] == DBNull.Value) ? 0 : (double)row["CaseQuantity"];
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng Case trong CSDL " + query + e.Message);
                }
            }
        }
        public double CaseQuantity { get; set; } = 20;
        public CaseObj(string CaseId, string PLId, double CaseQuantity)
        {
            this.CaseId = CaseId;
            this.PLId = PLId;
            this.CaseQuantity = CaseQuantity;
        }
        public CaseObj(DataRow row)
        {
            CaseId = row["CaseId"].ToString();
            PLId = row["PLId"].ToString();
            CaseQuantity = (row["CaseQuantity"] == null || row["CaseQuantity"] == DBNull.Value) ? 0 : (double)row["CaseQuantity"];
        }
        public CaseObj(string CaseId)
        {
            this.CaseId = CaseId;
        }
        public CaseObj() { }
        public bool CaseExist()
        {
            string query = string.Format("SELECT * FROM dbo.Case WHERE CaseId = '{0}'", CaseId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool CaseExist(string Case)
        {
            string query = string.Format("SELECT * FROM dbo.Case WHERE CaseId = '{0}'", Case);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int CaseInsert(string CaseId)
        {
            if (CaseObj.CaseExist(CaseId)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Case(CaseId,PLId,CaseQuantity)VALUES('{0}', '{1}', {2})", CaseId, PLId, CaseQuantity);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int CaseUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Case SET PLId = '{1}', CaseQuantity = {2} Where CaseId = '{0}'", CaseId, PLId, CaseQuantity);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int CaseUpdate(string newId, string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Case SET CaseId = '{0}', PLId = '{1}', CaseQuantity = {2} Where CaseId = '{3}'", newId, PLId, CaseQuantity, oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int CaseDelete()
        {
            string query = string.Format("Delete FROM dbo.Case WHERE CaseId = '{0}'", CaseId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static int CaseDelete(string CaseId)
        {
            string query = string.Format("Delete FROM dbo.Case WHERE CaseId = '{0}'", CaseId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
    }
}
