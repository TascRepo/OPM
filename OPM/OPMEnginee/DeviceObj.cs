using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class DeviceObj : PLObj
    {
        public string DeviceCaseNumber { get; set; } = "XXXXXXXX-XXX";
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
                        PLId = row["PLId"].ToString();
                        DeviceCaseNumber = row["DeviceCaseNumber"].ToString();
                        DeviceSerial = row["DeviceSerial"].ToString();
                        DeviceMAC = row["DeviceMAC"].ToString();
                        DeviceSerialGpon = row["DeviceSerialGpon"].ToString();
                        DeviceBoxNumber = row["DeviceBoxNumber"].ToString();
                        DeviceSerialRange = row["DeviceSerialRange"].ToString();
                        DeviceMACRange = row["DeviceMACRange"].ToString();
                        DeviceSerialGponRange = row["DeviceSerialGponRange"].ToString();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng PL trong CSDL " + query + e.Message);
                }
            }
        }
        public string DeviceBoxNumber { get; set; } = "XXXXXXX_XXXXXX";
        public string DeviceMAC { get; set; } = "XXXXXXXXXXXX";
        public string DeviceSerialGpon { get; set; } = "VNPTXXXXXXX";
        public string DeviceSerialRange { get; set; } = "XXXXXXX_XXXXXX";
        public string DeviceMACRange { get; set; } = "XXXXXXXXXXXX";
        public string DeviceSerialGponRange { get; set; } = "VNPTXXXXXXX";

        public DeviceObj(string PLId, string DeviceCaseNumber, string DeviceSerial, string DeviceMAC, string DeviceSerialGpon, string DeviceBoxNumber, string DeviceSerialRange, string DeviceMACRange, string DeviceSerialGponRange)
        {
            this.PLId = PLId;
            this.DeviceCaseNumber = DeviceCaseNumber;
            this.DeviceSerial = DeviceSerial;
            this.DeviceMAC = DeviceMAC;
            this.DeviceSerialGpon = DeviceSerialGpon;
            this.DeviceBoxNumber = DeviceBoxNumber;
            this.DeviceSerialRange = DeviceSerialRange;
            this.DeviceMACRange = DeviceMACRange;
            this.DeviceSerialGponRange = DeviceSerialGponRange;
        }
        public DeviceObj(DataRow row)
        {
            PLId = row["PLId"].ToString();
            DeviceCaseNumber = row["DeviceCaseNumber"].ToString(); 
            DeviceSerial = row["DeviceSerial"].ToString();
            DeviceMAC = row["DeviceMAC"].ToString();
            DeviceSerialGpon = row["DeviceSerialGpon"].ToString();
            DeviceBoxNumber = row["DeviceBoxNumber"].ToString();
            DeviceSerialRange = row["DeviceSerialRange"].ToString();
            DeviceMACRange = row["DeviceMACRange"].ToString();
            DeviceSerialGponRange = row["DeviceSerialGponRange"].ToString();
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
            if (DeviceObj.DeviceExist(DeviceSerial)) return 0;
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Device(DeviceSerial,PLId,DeviceMAC,DeviceSerialGpon,DeviceBoxNumber)VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", DeviceSerial, PLId, DeviceMAC, DeviceSerialGpon, DeviceBoxNumber);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DeviceUpdate()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Device SET PLId = '{1}', DeviceMAC = '{2}' , DeviceSerialGpon = '{3}', DeviceBoxNumber = '{4}' Where DeviceSerial = '{0}'", DeviceSerial, PLId, DeviceMAC, DeviceSerialGpon, DeviceBoxNumber);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int DeviceUpdate(string newId, string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Device SET DeviceSerial = '{0}', PLId = '{1}', DeviceMAC = '{2}' , DeviceSerialGpon = '{3}', DeviceBoxNumber = '{4}'  Where DeviceSerial = '{5}'", newId, PLId, DeviceMAC, DeviceSerialGpon, DeviceBoxNumber, oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static int DeviceUpdateByBoxNumber(string DeviceBoxNumber, string DeviceCaseNumber)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Device SET DeviceBoxNumber = '{0}' Where DeviceCaseNumber = '{1}'", DeviceBoxNumber, DeviceCaseNumber);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int DeviceDelete()
        {
            string query = string.Format("Delete FROM dbo.Device WHERE DeviceSerial = '{0}'", DeviceSerial);
            return OPMDBHandler.ExecuteNonQuery(query);
        }

        public static int DeviceDelete(string DeviceSerial)
        {
            string query = string.Format("Delete FROM dbo.Device WHERE DeviceSerial = '{0}'", DeviceSerial);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static bool DevicePLIdExist(string PLId)
        {
            string query = string.Format("SELECT * FROM dbo.Device WHERE PLId = '{0}'", PLId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static string DevicePLIdToCaseNumber(string pLId, int i)
        {
            string ret;
            int temp = i / 20 +1;
            if ((temp < 1)||(temp>1000))
            {
                return "Số lượng kiện hàng nhập vào không hợp lệ!";
            }
            else if ((temp < 10) && (temp > 0))
            {
                ret = pLId + "-00" + temp.ToString();
            }
            else if ((temp < 100)&&(i>9))
            {
                ret = pLId + "-0" + temp.ToString();
            }
            else
            {
                ret = pLId + "-" + temp.ToString();
            }
            return ret;
        }
        public static int DeviceNumberOfCase(int i, int DeviceTotalQuantityByPLId, int CaseQuantity)
        {
            if (i < (DeviceTotalQuantityByPLId / CaseQuantity) || (DeviceTotalQuantityByPLId % CaseQuantity) == 0)
                return CaseQuantity;
            else
                return (DeviceTotalQuantityByPLId % CaseQuantity);

        }
        public static DataTable DeviceGetDataTableByDistinctDeviceCaseNumber(string PLId)
        {
            string query = string.Format("SELECT DISTINCT DeviceCaseNumber, DeviceBoxNumber, DeviceSerialRange, DeviceNumberOfCase FROM dbo.Device WHERE PLId = '{0}'", PLId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }
        public static DataTable DeviceGetDataTableByPLId(string PLId)
        {
            string query = string.Format("SELECT * FROM dbo.Device WHERE PLId = '{0}'", PLId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }
        public static List<DeviceObj> DeviceGetListByPLId(string PLId)
        {
            List<DeviceObj> list = new List<DeviceObj>(); 
            DataTable table = DeviceGetDataTableByPLId(PLId);
            foreach(DataRow item in table.Rows)
            {
                DeviceObj device = new DeviceObj(item);
                list.Add(device);
            }
            return list;
        }
        public static string DeviceCaseNumberRange(string PLId)
        {
            string temp = "";
            string query = string.Format("SELECT DISTINCT DeviceCaseNumber FROM dbo.Device WHERE PLId = '{0}'", PLId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            foreach(DataRow item in table.Rows)
            {
                temp = temp + item.ItemArray[0].ToString() + @"; ";
            }
            return temp;
        }
    }
}
