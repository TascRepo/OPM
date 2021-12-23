using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class SiteObj
    {
        private string siteId = "XXXXXXXX";
        public string SiteId 
        {
            get => siteId;
            set 
            {
                siteId = value;
                string query = string.Format("SELECT * FROM dbo.Site WHERE SiteId = N'{0}'", value);
                try
                {
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        SiteName = (row["SiteName"] == null || row["SiteName"] == DBNull.Value) ? "" : row["SiteName"].ToString();
                        SiteProvince = (row["SiteProvince"] == null || row["SiteProvince"] == DBNull.Value) ? "" : row["SiteProvince"].ToString();
                        SiteType = (row["SiteType"] == null || row["SiteType"] == DBNull.Value) ? "" : row["SiteType"].ToString();
                        SiteHeadquater = (row["SiteHeadquater"] == null || row["SiteHeadquater"] == DBNull.Value) ? "" : row["SiteHeadquater"].ToString();
                        SiteAddress = (row["SiteAddress"] == null || row["SiteAddress"] == DBNull.Value) ? "" : row["SiteAddress"].ToString();
                        SitePhonenumber = (row["SitePhonenumber"] == null || row["SitePhonenumber"] == DBNull.Value) ? "" : row["SitePhonenumber"].ToString();
                        SiteFaxNumber = (row["SiteFaxNumber"] == null || row["SiteFaxNumber"] == DBNull.Value) ? "" : row["SiteFaxNumber"].ToString();
                        SiteTaxCode = (row["SiteTaxCode"] == null || row["SiteTaxCode"] == DBNull.Value) ? "" : row["SiteTaxCode"].ToString();
                        SiteBankAccount = (row["SiteBankAccount"] == null || row["SiteBankAccount"] == DBNull.Value) ? "" : row["SiteBankAccount"].ToString();
                        SiteNameOfBank = (row["SiteNameOfBank"] == null || row["SiteNameOfBank"] == DBNull.Value) ? "" : row["SiteNameOfBank"].ToString();
                        SiteRepresentative1 = (row["SiteRepresentative1"] == null || row["SiteRepresentative1"] == DBNull.Value) ? "" : row["SiteRepresentative1"].ToString();
                        SitePosition1 = (row["SitePosition1"] == null || row["SitePosition1"] == DBNull.Value) ? "" : row["SitePosition1"].ToString();
                        SiteProxy1 = (row["SiteProxy1"] == null || row["SiteProxy1"] == DBNull.Value) ? "" : row["SiteProxy1"].ToString();
                        SiteRepresentative2 = (row["SiteRepresentative2"] == null || row["SiteRepresentative2"] == DBNull.Value) ? "" : row["SiteRepresentative2"].ToString();
                        SitePosition2 = (row["SitePosition2"] == null || row["SitePosition2"] == DBNull.Value) ? "" : row["SitePosition2"].ToString();
                        SiteProxy2 = (row["SiteProxy2"] == null || row["SiteProxy2"] == DBNull.Value) ? "" : row["SiteProxy2"].ToString();
                        SiteRepresentative3 = (row["SiteRepresentative3"] == null || row["SiteRepresentative3"] == DBNull.Value) ? "" : row["SiteRepresentative3"].ToString();
                        SitePosition3 = (row["SitePosition3"] == null || row["SitePosition3"] == DBNull.Value) ? "" : row["SitePosition3"].ToString();
                        SiteProxy3 = (row["SiteProxy3"] == null || row["SiteProxy3"] == DBNull.Value) ? "" : row["SiteProxy3"].ToString();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng Site trong CSDL " + e.Message);
                }
            }
        }
        public string SiteName { get; set; } = "Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh";
        public string SiteProvince { get; set; } = "Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh";
        public string SiteType { get; set; } = "CUVT";
        public string SiteHeadquater { get; set; } = "Quận 1 - Thành phố Hồ Chí Minh";
        public string SiteAddress { get; set; } = "Quận 1 - Thành phố Hồ Chí Minh";
        public string SitePhonenumber { get; set; } = "XXXXXXXXXX";
        public string SiteFaxNumber { get; set; } = "XXXXXXXXXX";
        public string SiteTaxCode { get; set; } = "XXXXXXXXXX";
        public string SiteBankAccount { get; set; } = "XXXXXXXXXXXXX";
        public string SiteNameOfBank { get; set; } = "";
        public string SiteRepresentative1 { get; set; } = "Ông ";
        public string SitePosition1 { get; set; } = "Giám đốc";
        public string SiteProxy1 { get; set; } = "";
        public string SiteRepresentative2 { get; set; } = "Ông ";
        public string SitePosition2 { get; set; } = "";
        public string SiteProxy2 { get; set; } = "";
        public string SiteRepresentative3 { get; set; } = "Ông ";
        public string SitePosition3 { get; set; } = "";
        public string SiteProxy3 { get; set; } = "";

        public SiteObj() { }
        public SiteObj(string SiteId, string SiteName, string SiteProvince, string SiteType, string SiteHeadquater, string SiteAddress, string SitePhonenumber, string SiteFaxNumber, string SiteTaxCode, string SiteBankAccount, string SiteNameOfBank,string SiteRepresentative1, string SitePosition1, string SiteProxy1, string SiteRepresentative2, string SitePosition2, string SiteProxy2, string SiteRepresentative3, string SitePosition3, string SiteProxy3)
        {
            this.SiteId = SiteId;
            this.SiteName = SiteName;
            this.SiteProvince = SiteProvince;
            this.SiteType = SiteType;
            this.SiteHeadquater = SiteHeadquater;
            this.SiteAddress = SiteAddress;
            this.SitePhonenumber = SitePhonenumber;
            this.SiteFaxNumber = SiteFaxNumber;
            this.SiteTaxCode = SiteTaxCode;
            this.SiteBankAccount = SiteBankAccount;
            this.SiteNameOfBank = SiteNameOfBank;
            this.SiteRepresentative1 = SiteRepresentative1;
            this.SitePosition1 = SitePosition1;
            this.SiteProxy1 = SiteProxy1;
            this.SiteRepresentative2 = SiteRepresentative2;
            this.SitePosition2 = SitePosition2;
            this.SiteProxy2 = SiteProxy2;
            this.SiteRepresentative3 = SiteRepresentative3;
            this.SitePosition3 = SitePosition3;
            this.SiteProxy3 = SiteProxy3;
        }
        public SiteObj(DataRow row)
        {
            //SiteId = row["SiteId"].ToString();
            SiteName = (row["SiteName"] == null || row["SiteName"] == DBNull.Value) ? "" : row["SiteName"].ToString();
            SiteProvince = (row["SiteProvince"] == null || row["SiteProvince"] == DBNull.Value) ? "" : row["SiteProvince"].ToString();
            SiteType = (row["SiteType"] == null || row["SiteType"] == DBNull.Value) ? "" : row["SiteType"].ToString();
            SiteHeadquater = (row["SiteHeadquater"] == null || row["SiteHeadquater"] == DBNull.Value) ? "" : row["SiteHeadquater"].ToString();
            SiteAddress = (row["SiteAddress"] == null || row["SiteAddress"] == DBNull.Value) ? "" : row["SiteAddress"].ToString();
            SitePhonenumber = (row["SitePhonenumber"] == null || row["SitePhonenumber"] == DBNull.Value) ? "" : row["SitePhonenumber"].ToString();
            SiteFaxNumber = (row["SiteFaxNumber"] == null || row["SiteFaxNumber"] == DBNull.Value) ? "" : row["SiteFaxNumber"].ToString();
            SiteTaxCode = (row["SiteTaxCode"] == null || row["SiteTaxCode"] == DBNull.Value) ? "" : row["SiteTaxCode"].ToString();
            SiteBankAccount = (row["SiteBankAccount"] == null || row["SiteBankAccount"] == DBNull.Value) ? "" : row["SiteBankAccount"].ToString();
            SiteNameOfBank = (row["SiteNameOfBank"] == null || row["SiteNameOfBank"] == DBNull.Value) ? "" : row["SiteNameOfBank"].ToString();
            SiteRepresentative1 = (row["SiteRepresentative1"] == null || row["SiteRepresentative1"] == DBNull.Value) ? "" : row["SiteRepresentative1"].ToString();
            SitePosition1 = (row["SitePosition1"] == null || row["SitePosition1"] == DBNull.Value) ? "" : row["SitePosition1"].ToString();
            SiteProxy1 = (row["SiteProxy1"] == null || row["SiteProxy1"] == DBNull.Value) ? "" : row["SiteProxy1"].ToString();
            SiteRepresentative2 = (row["SiteRepresentative2"] == null || row["SiteRepresentative2"] == DBNull.Value) ? "" : row["SiteRepresentative2"].ToString();
            SitePosition2 = (row["SitePosition2"] == null || row["SitePosition2"] == DBNull.Value) ? "" : row["SitePosition2"].ToString();
            SiteProxy2 = (row["SiteProxy2"] == null || row["SiteProxy2"] == DBNull.Value) ? "" : row["SiteProxy2"].ToString();
            SiteRepresentative3 = (row["SiteRepresentative3"] == null || row["SiteRepresentative3"] == DBNull.Value) ? "" : row["SiteRepresentative3"].ToString();
            SitePosition3 = (row["SitePosition3"] == null || row["SitePosition3"] == DBNull.Value) ? "" : row["SitePosition3"].ToString();
            SiteProxy3 = (row["SiteProxy3"] == null || row["SiteProxy3"] == DBNull.Value) ? "" : row["SiteProxy3"].ToString();
        }
        public SiteObj(string id)
        {
            SiteId = id;
        }
        public bool SiteExist()
        {
            string query = string.Format("SELECT * FROM dbo.Site WHERE SiteId = '{0}'", SiteId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return (table.Rows.Count > 0);
        }
        public static bool SiteExist(string SiteId)
        {
            string query = string.Format("SELECT * FROM dbo.Site WHERE SiteId = '{0}'", SiteId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return (table.Rows.Count > 0);
        }
        public static DataTable SiteGetTable()
        {
            string query = string.Format(@"SELECT  DISTINCT [SiteName],[SiteProvince],[SiteType],[SiteHeadquater],[SiteAddress],[SitePhonenumber],[SiteFaxNumber],[SiteTaxCode],[SiteBankAccount],[SiteNameOfBank],[SiteRepresentative1],[SitePosition1],[SiteProxy1],[SiteRepresentative2],[SitePosition2],[SiteProxy2],[SiteRepresentative3],[SitePosition3],[SiteProxy3] FROM [dbo].[Site]");
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static DataRow RowSite()
        {
            string query = string.Format(@"SELECT  DISTINCT [SiteName],[SiteProvince],[SiteType],[SiteHeadquater],[SiteAddress],[SitePhonenumber],[SiteFaxNumber],[SiteTaxCode],[SiteBankAccount],[SiteNameOfBank],[SiteRepresentative1],[SitePosition1],[SiteProxy1],[SiteRepresentative2],[SitePosition2],[SiteProxy2],[SiteRepresentative3],[SitePosition3],[SiteProxy3] FROM [dbo].[Site] Where SiteId = ",(new SiteObj()).SiteId);
            OPMDBHandler.ExecuteQuery(query);

            return null;
        }
        public static DataTable SiteGetTableBySiteId()
        {
            DataTable table = SiteGetTable();
            
            return table;
        }
        public static List<SiteObj> SiteGetList()
        {
            List<SiteObj> list = new List<SiteObj>();
            DataTable dataTable = SiteGetTable();
            foreach (DataRow item in dataTable.Rows)
            {
                SiteObj site = new SiteObj(item);
                list.Add(site);
            }
            return list;
        }
        public int SiteUpdate()
        {
                string query = string.Format("UPDATE dbo.Site SET SiteId = '{0}', SiteName = N'{1}', SiteType = N'{2}', SiteHeadquater = N'{3}', Siteaddress= N'{4}', Sitephonenumber = '{5}',Sitefaxnumber = '{6}', SitetaxCode= '{7}', SiteBankAccount = '{8}',SiteNameOfBank = N'{9}',Siterepresentative1 = N'{10}',Siteposition1 = N'{11}',Siteproxy1 = N'{12}',Siterepresentative2 = N'{13}',Siteposition2 = N'{14}',Siteproxy2 = N'{15}',Siterepresentative3 = N'{16}',Siteposition3 = N'{17}',Siteproxy3 = N'{18}', WHERE SiteId = '{19}'", SiteId, SiteName, SiteProvince, SiteType, SiteHeadquater, SiteAddress, SitePhonenumber, SiteFaxNumber, SiteTaxCode, SiteBankAccount, SiteNameOfBank, SiteRepresentative1, SitePosition1, SiteProxy1, SiteRepresentative2, SitePosition2, SiteProxy2, SiteRepresentative3, SitePosition3, SiteProxy3);
                return OPMDBHandler.ExecuteNonQuery(query);
        }

        public int SiteUpdate(string newId,string oldId)
        {
            string query = string.Format("UPDATE dbo.Site SET SiteId = '{0}', SiteName = N'{1}', SiteType = N'{2}', SiteHeadquater = N'{3}', Siteaddress= N'{4}', Sitephonenumber = '{5}',Sitefaxnumber = '{6}', SitetaxCode= '{7}', SiteBankAccount = '{8}',SiteNameOfBank = N'{9}',Siterepresentative1 = N'{10}',Siteposition1 = N'{11}',Siteproxy1 = N'{12}',Siterepresentative2 = N'{13}',Siteposition2 = N'{14}',Siteproxy2 = N'{15}',Siterepresentative3 = N'{16}',Siteposition3 = N'{17}',Siteproxy3 = N'{18}', WHERE SiteId = '{19}'",newId, SiteName, SiteProvince, SiteType, SiteHeadquater, SiteAddress, SitePhonenumber, SiteFaxNumber, SiteTaxCode, SiteBankAccount, SiteNameOfBank, SiteRepresentative1, SitePosition1, SiteProxy1, SiteRepresentative2, SitePosition2, SiteProxy2, SiteRepresentative3, SitePosition3, SiteProxy3, oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int SiteInsert(string SiteId)
        {
            if (SiteObj.SiteExist(SiteId)) return 0;
            string query = string.Format(@"INSERT INTO dbo.Site VALUES('{17}',N'{0}',N'{17}',N'{1}',N'{2}',N'{3}','{4}','{5}','{6}','{7}',N'{18}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}')", SiteName, SiteType, SiteHeadquater, SiteAddress, SitePhonenumber, SiteFaxNumber, SiteTaxCode, SiteBankAccount, SiteRepresentative1, SitePosition1, SiteProxy1, SiteRepresentative2, SitePosition2, SiteProxy2, SiteRepresentative3, SitePosition3, SiteProxy3, SiteProvince, SiteNameOfBank,SiteId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int SiteInsert()
        {
            if (SiteObj.SiteExist(SiteId)) return 0;
            string query = string.Format(@"INSERT INTO dbo.Site VALUES(N'{0}',N'{17}',N'{1}',N'{2}',N'{3}','{4}','{5}','{6}','{7}',N'{18}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}')", SiteName, SiteType, SiteHeadquater, SiteAddress, SitePhonenumber, SiteFaxNumber, SiteTaxCode, SiteBankAccount, SiteRepresentative1, SitePosition1, SiteProxy1, SiteRepresentative2, SitePosition2, SiteProxy2, SiteRepresentative3, SitePosition3, SiteProxy3, SiteProvince,SiteNameOfBank);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Delete()
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            string query = string.Format("DELETE FROM dbo.Site WHERE SiteId = N'{0}'", SiteName);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
                MessageBox.Show("Bạn đã xoá thành công!");
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
        }
        public static void Delete(string id)
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            string query = string.Format("DELETE FROM dbo.Site WHERE SiteId = N'{0}'", id);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
                MessageBox.Show("Bạn đã xoá thành công!");
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
        }
        public static List<string> SiteGetListProvinceId()
        {
            string query = string.Format("SELECT provinceId FROM dbo.Site");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            List<string> list = new List<string>(); 
            foreach (string item in dataTable.Rows)
            {
                list.Add(item);
            }
            return list;
        }

    }
}
