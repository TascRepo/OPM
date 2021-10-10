using OPM.DBHandler;
using System.Data;

namespace OPM.OPMEnginee
{
    class SiteInfo : ISiteInfo
    {
        private string _id;
        private string _type;
        private string _headquaterInfo;
        private string _address;
        private string _phonenumber;
        private string _tin;
        private string _account;
        private string _representative;

        public SiteInfo()
        {
        }

        public SiteInfo(string id, string type, string headquaterInfo, string address, string phonenumber, string tin, string account, string representative)
        {
            Id = id;
            Type = type;
            HeadquaterInfo = headquaterInfo;
            Address = address;
            Phonenumber = phonenumber;
            Tin = tin;
            Account = account;
            Representative = representative;
        }

        public string Id { get => _id; set => _id = value; }
        public string Type { get => _type; set => _type = value; }
        public string HeadquaterInfo { get => _headquaterInfo; set => _headquaterInfo = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phonenumber { get => _phonenumber; set => _phonenumber = value; }
        public string Tin { get => _tin; set => _tin = value; }
        public string Account { get => _account; set => _account = value; }
        public string Representative { get => _representative; set => _representative = value; }
        public int GetSiteInfo(string idSiteInfo, ref SiteInfo siteInfo)
        {
            string strQueryOne = "SELECT DISTINCT * FROM Site_Info  WHERE Site_Info.id =" + "N'" + idSiteInfo + "'";
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQueryOne, ref ds);
            if (0 != ds.Tables[0].Rows.Count)
            {
                siteInfo.Id = (string)ds.Tables[0].Rows[0].ItemArray[0];
                siteInfo.Type = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                siteInfo.HeadquaterInfo = (string)ds.Tables[0].Rows[0].ItemArray[2];
                siteInfo.Address = (string)ds.Tables[0].Rows[0].ItemArray[3];
                siteInfo.Phonenumber = (string)ds.Tables[0].Rows[0].ItemArray[4];
                siteInfo.Tin = (string)ds.Tables[0].Rows[0].ItemArray[5];
                siteInfo.Account = (string)ds.Tables[0].Rows[0].ItemArray[6];
                siteInfo.Representative = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            }
            else
            {
                return 0;
            }
            return 1;
        }

        public int GetSiteInfoObject(string idContract, ref SiteInfo siteInfo)
        {
            string strQueryOne = "SELECT DISTINCT * FROM Contract INNER JOIN Site_Info ON Site_Info.id COLLATE SQL_Latin1_General_CP1_CI_AS = Contract.id_siteB WHERE Contract.id =" + "'" + idContract + "'";
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQueryOne, ref ds);
            if (0 != ds.Tables.Count)
            {
                siteInfo.Id = (string)ds.Tables[0].Rows[0].ItemArray[15];
                siteInfo.Type = (string)ds.Tables[0].Rows[0].ItemArray[16];
                siteInfo.HeadquaterInfo = (string)ds.Tables[0].Rows[0].ItemArray[17];
                siteInfo.Address = (string)ds.Tables[0].Rows[0].ItemArray[18];
                siteInfo.Phonenumber = (string)ds.Tables[0].Rows[0].ItemArray[19];
                siteInfo.Tin = (string)ds.Tables[0].Rows[0].ItemArray[20];
                siteInfo.Account = (string)ds.Tables[0].Rows[0].ItemArray[21];
                siteInfo.Representative = (string)ds.Tables[0].Rows[0].ItemArray[22];
            }
            else
            {
                return 0;
            }
            return 1;
        }
        public int GetSiteInfoA(string idContract, ref SiteInfo siteInfo)
        {
            string strQueryOne = "SELECT DISTINCT * FROM Contract INNER JOIN Site_Info ON Site_Info.id COLLATE SQL_Latin1_General_CP1_CI_AS = Contract.id_siteA WHERE Contract.id =" + "'" + idContract + "'";
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQueryOne, ref ds);
            if (0 != ds.Tables.Count)
            {
                siteInfo.Id = (string)ds.Tables[0].Rows[0].ItemArray[15];
                siteInfo.Type = (string)ds.Tables[0].Rows[0].ItemArray[16];
                siteInfo.HeadquaterInfo = (string)ds.Tables[0].Rows[0].ItemArray[17];
                siteInfo.Address = (string)ds.Tables[0].Rows[0].ItemArray[18];
                siteInfo.Phonenumber = (string)ds.Tables[0].Rows[0].ItemArray[19];
                siteInfo.Tin = (string)ds.Tables[0].Rows[0].ItemArray[20];
                siteInfo.Account = (string)ds.Tables[0].Rows[0].ItemArray[21];
                siteInfo.Representative = (string)ds.Tables[0].Rows[0].ItemArray[22];
            }
            else
            {
                return 0;
            }
            return 1;
        }
        public int UpdateExistedSite(SiteInfo siteInfo)
        {
            string strUpdateContract = "update Site_Info set headquater_info = N'" + siteInfo.HeadquaterInfo + "', address = '" + siteInfo.Address + "', phonenumber = '" + siteInfo.Phonenumber + "',tin = N'" + siteInfo.Tin + "', account = '" + siteInfo.Account + "', representative='" + siteInfo.Representative + "' where id = '" + siteInfo.Id + "'";
            int ret = OPMDBHandler.fInsertData(strUpdateContract);
            if (ret == 0)
            {
                return 0;
            }
            else return 1;
        }
    }
}
