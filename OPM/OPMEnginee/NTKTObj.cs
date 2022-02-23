using OPM.DBHandler;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class NTKTObj : POObj
    {
        private string ntktId = "XXXX/ANSV-DO";

        public string NTKTId
        {
            get => ntktId;
            set
            {
                ntktId = value;
                string query = string.Format("SELECT * FROM dbo.NTKT WHERE NTKTId = '{0}'", value);
                try
                {
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        POId = row["POId"].ToString();
                        NTKTQuantity = (row["NTKTQuantity"] == null || row["NTKTQuantity"] == DBNull.Value) ? 0 : (double)row["NTKTQuantity"];
                        NTKTTestExpectedDate = (row["NTKTTestExpectedDate"] == null || row["NTKTTestExpectedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["NTKTTestExpectedDate"];
                        NTKTCreatedDate = (row["NTKTCreatedDate"] == null || row["NTKTCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["NTKTCreatedDate"];
                        NTKTPhase = (row["NTKTPhase"] == null || row["NTKTPhase"] == DBNull.Value) ? "X" : row["NTKTPhase"].ToString();
                        TechnicalInspectionReportDate = (row["TechnicalInspectionReportDate"] == null || row["TechnicalInspectionReportDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["TechnicalInspectionReportDate"];
                        TechnicalAcceptanceReportDate = (row["TechnicalAcceptanceReportDate"] == null || row["TechnicalAcceptanceReportDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["TechnicalAcceptanceReportDate"];
                        NTKTLicenseCertificateDate = (row["NTKTLicenseCertificateDate"] == null || row["NTKTLicenseCertificateDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["NTKTLicenseCertificateDate"];
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng NTKT trong CSDL " + query + e.Message);
                }
            }
        }
        public DateTime NTKTCreatedDate { get; set; } = DateTime.Now;
        public string NTKTPhase { get; set; } = "X";
        public double NTKTQuantity { get; set; } = 0;
        public double NTKTExtraQuantity => Math.Round(NTKTQuantity * 0.02, 0, MidpointRounding.AwayFromZero);
        public DateTime NTKTTestExpectedDate { get; set; } = DateTime.Now;
        public DateTime TechnicalInspectionReportDate { get; set; } = DateTime.Now;
        public DateTime TechnicalAcceptanceReportDate { get; set; } = DateTime.Now;
        public DateTime NTKTLicenseCertificateDate { get; set; } = DateTime.Now;

        public NTKTObj(string NTKTId, double NTKTQuantity, DateTime NTKTTestExpectedDate, DateTime NTKTCreatedDate, string NTKTPhase, DateTime TechnicalInspectionReportDate, DateTime TechnicalAcceptanceReportDate, DateTime NTKTLicenseCertificateDate)
        {
            this.NTKTId = NTKTId;
            this.NTKTQuantity = NTKTQuantity;
            this.NTKTTestExpectedDate = NTKTTestExpectedDate;
            this.NTKTCreatedDate = NTKTCreatedDate;
            this.NTKTPhase = NTKTPhase;
            this.TechnicalInspectionReportDate = TechnicalInspectionReportDate;
            this.TechnicalAcceptanceReportDate = TechnicalAcceptanceReportDate;
            this.NTKTLicenseCertificateDate = NTKTLicenseCertificateDate;
        }
        public NTKTObj(DataRow row)
        {
            NTKTId = row["NTKTId"].ToString();
            POId = row["POId"].ToString();
            NTKTQuantity = (row["NTKTQuantity"] == null || row["NTKTQuantity"] == DBNull.Value) ? 0 : (double)row["NTKTQuantity"];
            NTKTTestExpectedDate = (row["NTKTTestExpectedDate"] == null || row["NTKTTestExpectedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["NTKTTestExpectedDate"];
            NTKTCreatedDate = (row["NTKTCreatedDate"] == null || row["NTKTCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["NTKTCreatedDate"];
            NTKTPhase = (row["NTKTPhase"] == null || row["NTKTPhase"] == DBNull.Value) ? "X" : row["NTKTPhase"].ToString();
            TechnicalInspectionReportDate = (row["TechnicalInspectionReportDate"] == null || row["TechnicalInspectionReportDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["TechnicalInspectionReportDate"];
            TechnicalAcceptanceReportDate = (row["TechnicalAcceptanceReportDate"] == null || row["TechnicalAcceptanceReportDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["TechnicalAcceptanceReportDate"];
            NTKTLicenseCertificateDate = (row["NTKTLicenseCertificateDate"] == null || row["NTKTLicenseCertificateDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["NTKTLicenseCertificateDate"];
        }
        public NTKTObj(string ntktId)
        {
            NTKTId = ntktId;
        }
        public NTKTObj() { }
        public bool NTKTExist()
        {
            string query = string.Format("SELECT * FROM dbo.NTKT WHERE NTKTId = '{0}'", ntktId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool NTKTExist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.NTKT WHERE NTKTId = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int NTKTInsert(string id)
        {
            if (NTKTObj.NTKTExist(id)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.NTKT(NTKTId,POId,NTKTCreatedDate,NTKTPhase,NTKTQuantity,NTKTTestExpectedDate,TechnicalInspectionReportDate,TechnicalAcceptanceReportDate,NTKTLicenseCertificateDate)VALUES('{0}','{1}', '{2}', '{3}', {4}, '{5}', '{6}', '{7}', '{8}')", id, POId, NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), NTKTPhase, NTKTQuantity, NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), TechnicalInspectionReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), NTKTLicenseCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int NTKTUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.NTKT SET  POId = '{1}', NTKTCreatedDate = '{2}', NTKTPhase = '{3}', NTKTQuantity = {4}, NTKTTestExpectedDate = '{5}', TechnicalInspectionReportDate = '{6}', TechnicalAcceptanceReportDate = '{7}', NTKTLicenseCertificateDate = '{8}' Where NTKTId = '{0}'", NTKTId, POId, NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), NTKTPhase, NTKTQuantity, NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), TechnicalInspectionReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), NTKTLicenseCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int NTKTUpdate(string newId, string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.NTKT SET NTKTId = '{0}', POId = '{1}', NTKTCreatedDate = '{2}', NTKTPhase = '{3}', NTKTQuantity = {4}, NTKTTestExpectedDate = '{5}', TechnicalInspectionReportDate = '{6}', TechnicalAcceptanceReportDate = '{7}', NTKTLicenseCertificateDate = '{8}' Where NTKTId = '{9}'", newId, POId, NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), NTKTPhase, NTKTQuantity, NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), TechnicalInspectionReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), NTKTLicenseCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int NTKTDelete()
        {
            string query = string.Format("Delete FROM dbo.NTKT WHERE NTKTId = '{0}'", ntktId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static int NTKTDelete(string id)
        {
            string query = string.Format("Delete FROM dbo.NTKT WHERE NTKTId = '{0}'", id);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static double NTKTGoodsQuantityTotalByPOId(string POId)
        {
            string query = string.Format(@"SELECT SUM(NTKTQuantity) FROM NTKT WHERE POId = '{0}'", POId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }

    }
}
