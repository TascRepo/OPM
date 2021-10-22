using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class Contract_Thanh
    {
        private string id = "XXX-2021/CUVT-ANSV/DTRR-KHMS";
        private string contractName = "Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)";
        private string accoutingCode = "C01007";
        private DateTime signedDate = DateTime.Now.Date;
        private string typeContract = "Theo đơn giá cố định";
        private int contractDuration = 0;
        private DateTime activeDate = DateTime.Now.Date;
        private double contractValue = 0;
        private int poDuration = 5;
        private string idsiteA = "Trung tâm cung ứng vật tư - Viễn thông TP.HCM";
        private string idsiteB = "Công ty TNHH thiết bị Viễn thông ANSV";
        private string appendix = "Phụ lục";
        private string guaranteeDoc = "Văn bản bảo lãnh";
        private string kHMS = "Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020";
        private DateTime guaranteeDeadline = DateTime.Now.Date;
        private int guaranteeValue = 0;
        private DateTime guaranteeCreatedDate = DateTime.Now.Date;
        public string Id { get => id; set => id = value; }
        public string ContractName { get => contractName; set => contractName = value; }
        public string AccoutingCode { get => accoutingCode; set => accoutingCode = value; }
        public DateTime SignedDate { get => signedDate; set => signedDate = value; }
        public string TypeContract { get => typeContract; set => typeContract = value; }
        public int ContractDuration { get => contractDuration; set => contractDuration = value; }
        public DateTime ActiveDate { get => activeDate; set => activeDate = value; }
        public double ContractValue { get => contractValue; set => contractValue = value; }
        public int PoDuration { get => poDuration; set => poDuration = value; }
        public string IdSiteA { get => idsiteA; set => idsiteA = value; }
        public string IdSiteB { get => idsiteB; set => idsiteB = value; }
        public string Appendix { get => appendix; set => appendix = value; }
        public string GuaranteeDoc { get => guaranteeDoc; set => guaranteeDoc = value; }
        public string KHMS { get => kHMS; set => kHMS = value; }
        public DateTime GuaranteeDeadline { get => guaranteeDeadline; set => guaranteeDeadline = value; }
        public int GuaranteeValue { get => guaranteeValue; set => guaranteeValue = value; }
        public DateTime GuaranteeCreatedDate { get => guaranteeCreatedDate; set => guaranteeCreatedDate = value; }
        public List<PO_Thanh> ListPO() 
        {
            List<PO_Thanh> list = new List<PO_Thanh>();
            string query = string.Format("SELECT * FROM dbo.PO Where id_contract = {0} Order By id",id);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                PO_Thanh po = new PO_Thanh(item);
                list.Add(po);
            }
            return list;
        }
        public Contract_Thanh() { }
        public Contract_Thanh(string id, string namecontract, string codeaccouting, DateTime datesigned, string typecontract, int durationcontract, DateTime activedate, double valuecontract, int durationpo, string id_siteA, string id_siteB, string phuluc, string vbgurantee, string kHMS, DateTime experationDate, int blvalue, DateTime garanteeCreatedDate)
        {
            Id = id;
            ContractName = namecontract;
            AccoutingCode = codeaccouting;
            SignedDate = datesigned;
            TypeContract = typecontract;
            ContractDuration = durationcontract;
            ActiveDate = activedate;
            ContractValue = valuecontract;
            PoDuration = durationpo;
            IdSiteA = id_siteA;
            IdSiteB = id_siteB;
            Appendix = phuluc;
            GuaranteeDoc = vbgurantee;
            KHMS = kHMS;
            GuaranteeDeadline = experationDate;
            GuaranteeValue = blvalue;
            GuaranteeCreatedDate = garanteeCreatedDate;
        }
        public Contract_Thanh(DataRow row)
        {
            Id = row["id"].ToString();
            ContractName = (row["namecontract"] == null || row["namecontract"] == DBNull.Value) ? "" : row["namecontract"].ToString();
            AccoutingCode = (row["codeaccouting"] == null || row["codeaccouting"] == DBNull.Value) ? "" : row["codeaccouting"].ToString();
            SignedDate = (row["datesigned"] == null || row["datesigned"] == DBNull.Value) ? DateTime.Now : (DateTime)row["datesigned"];
            TypeContract = (row["typecontract"] == null || row["typecontract"] == DBNull.Value) ? "" : row["typecontract"].ToString();
            ContractDuration = (row["durationcontract"] == null || row["durationcontract"] == DBNull.Value) ? 0 : (int)row["durationcontract"];
            ActiveDate = (row["activedate"] == null || row["activedate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["activedate"];
            ContractValue = (row["valuecontract"] == null || row["valuecontract"] == DBNull.Value) ? 0 : (double)row["valuecontract"];
            PoDuration = (row["durationpo"] == null || row["durationpo"] == DBNull.Value) ? 0 : (int)row["durationpo"];
            IdSiteA = (row["id_siteA"] == null || row["id_siteA"] == DBNull.Value) ? "" : row["id_siteA"].ToString();
            IdSiteB = (row["id_siteB"] == null || row["id_siteB"] == DBNull.Value) ? "" : row["id_siteB"].ToString();
            Appendix = (row["phuluc"] == null || row["phuluc"] == DBNull.Value) ? "" : row["phuluc"].ToString();
            GuaranteeDoc = (row["vbgurantee"] == null || row["vbgurantee"] == DBNull.Value) ? "" : row["vbgurantee"].ToString();
            KHMS = (row["kHMS"] == null || row["kHMS"] == DBNull.Value) ? "" : row["kHMS"].ToString();
            GuaranteeDeadline = (row["experationDate"] == null || row["experationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["experationDate"];
            GuaranteeValue = (row["blvalue"] == null || row["blvalue"] == DBNull.Value) ? 0 : (int)row["blvalue"];
            GuaranteeCreatedDate = (row["garanteeCreatedDate"] == null || row["garanteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["garanteeCreatedDate"];
        }
        public Contract_Thanh(string id)
        {
            Id = id;
            string query = string.Format("SELECT * FROM dbo.Contract WHERE id = '{0}'", id);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    ContractName = (row["namecontract"] == null || row["namecontract"] == DBNull.Value) ? "" : row["namecontract"].ToString();
                    AccoutingCode = (row["codeaccouting"] == null || row["codeaccouting"] == DBNull.Value) ? "" : row["codeaccouting"].ToString();
                    SignedDate = (row["datesigned"] == null || row["datesigned"] == DBNull.Value) ? DateTime.Now : (DateTime)row["datesigned"];
                    TypeContract = (row["typecontract"] == null || row["typecontract"] == DBNull.Value) ? "" : row["typecontract"].ToString();
                    ContractDuration = (row["durationcontract"] == null || row["durationcontract"] == DBNull.Value) ? 0 : (int)row["durationcontract"];
                    ActiveDate = (row["activedate"] == null || row["activedate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["activedate"];
                    ContractValue = (row["valuecontract"] == null || row["valuecontract"] == DBNull.Value) ? 0 : (double)row["valuecontract"];
                    PoDuration = (row["durationpo"] == null || row["durationpo"] == DBNull.Value) ? 0 : (int)row["durationpo"];
                    IdSiteA = (row["id_siteA"] == null || row["id_siteA"] == DBNull.Value) ? "" : row["id_siteA"].ToString();
                    IdSiteB = (row["id_siteB"] == null || row["id_siteB"] == DBNull.Value) ? "" : row["id_siteB"].ToString();
                    Appendix = (row["phuluc"] == null || row["phuluc"] == DBNull.Value) ? "" : row["phuluc"].ToString();
                    GuaranteeDoc = (row["vbgurantee"] == null || row["vbgurantee"] == DBNull.Value) ? "" : row["vbgurantee"].ToString();
                    KHMS = (row["kHMS"] == null || row["kHMS"] == DBNull.Value) ? "" : row["kHMS"].ToString();
                    GuaranteeDeadline = (row["experationDate"] == null || row["experationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["experationDate"];
                    GuaranteeValue = (row["blvalue"] == null || row["blvalue"] == DBNull.Value) ? 0 : (int)row["blvalue"];
                    GuaranteeCreatedDate = (row["garanteeCreatedDate"] == null || row["garanteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["garanteeCreatedDate"];
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract!");
            }
        }
        public static List<Contract_Thanh> GetList()
        {
            List<Contract_Thanh> contracts = new List<Contract_Thanh>();
            string query = string.Format("SELECT * FROM dbo.Contract");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Contract_Thanh contract = new Contract_Thanh(row);
                contracts.Add(contract);
            }
            return contracts;
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.Contract WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool Exist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.Contract WHERE id = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int Insert()
        {
            string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.Contract(id,namecontract,codeaccouting,datesigned,typecontract,durationcontract,activedate,valuecontract,durationpo,id_siteA,id_siteB,phuluc,vbgurantee,KHMS,experationDate,blvalue,garanteeCreatedDate) VALUES('{0}',N'{1}',N'{2}','{3}',N'{4}',{5},'{6}',{7},{8},N'{9}',N'{10}',N'{11}',N'{12}',N'{13}','{14}',{15},'{16}') --INSERT INTO dbo.CatalogAdmin (ctlID, ctlname) VALUES ('Contract_{0}', '{0}')", id, contractName, accoutingCode, signedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typeContract, contractDuration, activeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), contractValue, poDuration, idsiteA, idsiteB, appendix, guaranteeDoc, kHMS, guaranteeDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), guaranteeValue, guaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int Update()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Contract SET namecontract = N'{1}', codeaccouting = N'{2}', datesigned = '{3}',typecontract = N'{4}', durationcontract = {5},activedate = '{6}',valuecontract = {7},durationpo = {8},id_siteA = N'{9}',id_siteB = N'{10}',phuluc = N'{11}',vbgurantee = N'{12}',KHMS = N'{13}',experationDate = '{14}',blvalue = {15}, garanteeCreatedDate='" + guaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")) + "' WHERE id = '{0}'", id, contractName, accoutingCode, signedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typeContract, contractDuration, activeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), contractValue, poDuration, idsiteA, idsiteB, appendix, guaranteeDoc, kHMS, guaranteeDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), guaranteeValue);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int Update(string oldId)
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Contract SET namecontract = N'{1}', codeaccouting = N'{2}', datesigned = '{3}',typecontract = N'{4}', durationcontract = {5},activedate = '{6}',valuecontract = {7},durationpo = {8},id_siteA = N'{9}',id_siteB = N'{10}',phuluc = N'{11}',vbgurantee = N'{12}',KHMS = N'{13}',experationDate = '{14}',blvalue = {15}, garanteeCreatedDate='" + guaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")) + "',id = '{0}' WHERE id = '{16}'", id, contractName, accoutingCode, signedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), typeContract, contractDuration, activeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), contractValue, poDuration, idsiteA, idsiteB, appendix, guaranteeDoc, kHMS, guaranteeDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), guaranteeValue,oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static int Delete(string id)
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá hợp đồng: {0} không?", id), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return 0;
            string query = string.Format("DELETE FROM dbo.Contract WHERE id = '{0}'", id);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public int Delete()
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá hợp đồng: {0} không?", id), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return 0;
            string query = string.Format("DELETE FROM dbo.Contract WHERE id = '{0}'", id);
            return OPMDBHandler .ExecuteNonQuery(query);
        }
    }
}
