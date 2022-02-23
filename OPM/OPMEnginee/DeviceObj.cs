using OPM.DBHandler;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class DeviceObj : CaseObj
    {
        private string deviceSerial = "XXXXXXXXXXXXXXX";

        public string DeviceSerial
        {
            get => deviceSerial;
            set
            {
                deviceSerial = value;
                string query = string.Format("SELECT * FROM dbo.Device WHERE DeviceSerial = '{0}'", value);
                try
                {
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        CaseId = row["CaseId"].ToString();
                        DeviceMAC = row["DeviceMAC"].ToString();
                        DeviceSerialGpon = row["DeviceSerialGpon"].ToString();
                        DeviceBoxNumber = row["DeviceBoxNumber"].ToString();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng PL trong CSDL " + query + e.Message);
                }
            }
        }
        public string DeviceMAC { get; set; } = "XXXXXXXXXXXX";
        public string DeviceSerialGpon { get; set; } = "VNPTXXXXXXXX";
        public string DeviceBoxNumber { get; set; } = "XXXXXXX_XXXXXX";
        public DeviceObj(string CaseId, string PLId, double CaseQuantity)
        {
            this.DeviceSerial = CaseId;
            this.PLId = PLId;
            this.CaseQuantity = CaseQuantity;
        }
        public DeviceObj(DataRow row)
        {
            DeviceSerial = row["DeviceSerial"].ToString();
            CaseId = row["CaseId"].ToString();
            DeviceMAC = row["DeviceMAC"].ToString();
            DeviceSerialGpon = row["DeviceSerialGpon"].ToString();
            DeviceBoxNumber = row["DeviceBoxNumber"].ToString();
        }
        public DeviceObj(string DeviceSerial)
        {
            this.DeviceSerial = DeviceSerial;
        }
        public DeviceObj() { }
        public bool DeviceExist()
        {
            string query = string.Format("SELECT * FROM dbo.Device WHERE DeviceSerial = '{0}'", DeviceSerial);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool DeviceExist(string DeviceSerial)
        {
            string query = string.Format("SELECT * FROM dbo.Device WHERE DeviceSerial = '{0}'", DeviceSerial);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int DeviceInsert(string DeviceSerial)
        {
            if (CaseObj.CaseExist(DeviceSerial)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Device(DeviceSerial,CaseId,DeviceMAC,DeviceSerialGpon,DeviceBoxNumber)VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", DeviceSerial, CaseId, DeviceMAC, DeviceSerialGpon, DeviceBoxNumber);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DeviceUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Device SET CaseId = '{1}', DeviceMAC = '{2}' , DeviceSerialGpon = '{3}', DeviceBoxNumber = '{4}' Where DeviceSerial = '{0}'", DeviceSerial, CaseId, DeviceMAC, DeviceSerialGpon, DeviceBoxNumber);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DeviceUpdate(string newId, string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Device SET DeviceSerial = '{0}', CaseId = '{1}', DeviceMAC = '{2}' , DeviceSerialGpon = '{3}', DeviceBoxNumber = '{4}'  Where DeviceSerial = '{5}'", newId, CaseId, DeviceMAC, DeviceSerialGpon, DeviceBoxNumber, oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int DeviceDelete()
        {
            string query = string.Format("Delete FROM dbo.Device WHERE DeviceSerial = '{0}'", DeviceSerial);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static int DeviceDelete(string DeviceSerial)
        {
            string query = string.Format("Delete FROM dbo.Device WHERE CaseId = '{0}'", DeviceSerial);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
    }
}
