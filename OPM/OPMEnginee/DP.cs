using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.DBHandler
{
    class DP
    {
        private string id;
        private string idPO;
        private string idContract;
        private string type;
        private string dateOpen;
        private string dateDeliver;
        private string maKT;
        private string note;

        public string Id { get => id; set => id = value; }
        public string IdPO { get => idPO; set => idPO = value; }
        public string IdContract { get => idContract; set => idContract = value; }
        public string Type { get => type; set => type = value; }
        public string DateOpen { get => dateOpen; set => dateOpen = value; }
        public string DateDeliver { get => dateDeliver; set => dateDeliver = value; }
        public string MaKT { get => maKT; set => maKT = value; }
        public string Note { get => note; set => note = value; }
        public DP() { }
        public static int InsertDP(DP dP)
        {
            string strInsert = "INSERT INTO DP VALUES(";
            strInsert += "'";
            strInsert += dP.Id;
            strInsert += "','";
            strInsert += dP.IdPO;
            strInsert += "','";
            strInsert += dP.IdContract;
            strInsert += "',N'";
            strInsert += dP.type;
            strInsert += "','";
            strInsert += dP.dateOpen;
            strInsert += "','";
            strInsert += dP.DateDeliver;
            strInsert += "','";
            strInsert += dP.maKT;
            strInsert += "',N'";
            strInsert += dP.note;
            strInsert += "')";
            int ret =OPM.DBHandler.OPMDBHandler.fInsertData(strInsert);
            if(ret == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public bool Check_DP(string id)
        {
            string query = string.Format("SELECT * FROM dbo.DP WHERE id_po = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int InsertListExpected_DP(string ProvinceName, string NumberDevice, string id_dp)
        {
            int result = 0;
            string query = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.ListExpected_DP(ProvinceName, NumberDevice, id_dp) VALUES(N'{0}',{1},'{2}')", ProvinceName, Int64.Parse(NumberDevice), id_dp);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
        public bool Check_ListExpected_DP(string ProvinceName, string id_dp)
        {
            string query = string.Format("SELECT * FROM dbo.ListExpected_DP WHERE ProvinceName = '{0}' and id_dp = '{1}'", ProvinceName, id_dp);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int InsertDP(string id, string id_po, string id_contract)
        {
            int result = 0;
            string query = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.DP(id,id_po,id_contract) VALUES(N'{0}',N'{1}',N'{2}')", id, id_po, id_contract);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
    }

}
