using System;
using System.Data;

namespace OPM.DBHandler
{
    class DPOld
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
        public DPOld() { }
        public static int InsertDP(DPOld dP)
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
            int ret = OPM.DBHandler.OPMDBHandler.fInsertData(strInsert);
            if (ret == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public bool Check_DP(string id, string id_po)
        {
            string query = string.Format("SELECT * FROM dbo.DP WHERE id = N'{0}' and id_po = N'{1}'", id, id_po);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public DataTable SqlContract_Goods(string id)
        {
            DataTable d1 = new DataTable();
            string query = string.Format("SELECT name FROM dbo.Contract_Goods WHERE idContract = N'{0}'", id);
            d1 = OPMDBHandler.ExecuteQuery(query);
            return d1;
        }
        public DataTable GetCodeByContract(string id, string name)
        {
            DataTable d1 = new DataTable();
            string query = string.Format("SELECT top 1 code FROM dbo.Contract_Goods WHERE idContract = N'{0}' and name = N'{1}'", id, name);
            d1 = OPMDBHandler.ExecuteQuery(query);
            return d1;
        }
        public int InsertListExpected_DP(string ProvinceName, string NumberDevice, string type, string id_dp, string id_po)
        {
            int result = 0;
            string query = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.ListExpected_DP(ProvinceName, NumberDevice, id_dp, type, id_po) VALUES(N'{0}',{1},'{2}',N'{3}','{4}')", ProvinceName, Int64.Parse(NumberDevice), id_dp, type, id_po);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
        public int UpdateListExpected_DP(string ProvinceName, string NumberDevice, string type, string id_dp, string id_po)
        {
            int result = 0;
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.ListExpected_DP set NumberDevice = {0} where ProvinceName = '{1}' and  id_dp = '{2}' and type = N'{3}' and id_po = '{4}'", Int64.Parse(NumberDevice), ProvinceName, id_dp, type, id_po);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
        public bool Check_ListExpected_DP(string ProvinceName, string id_dp, string type, string id_po)
        {
            string query = string.Format("SELECT * FROM dbo.ListExpected_DP WHERE ProvinceName = '{0}' and id_dp = '{1}' and type = N'{2}' and id_po = '{3}'", ProvinceName, id_dp, type, id_po);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int InsertUpdateDP(string id, string id_po, string id_contract, string cbbType, string note, string dtpRequest, string dtpOutCap, string maHangSP, string tenHangSP)
        {
            int Return = 0;
            if (Check_DP(id, id_po))
            {
                int result = 0;
                string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.DP SET note = N'{0}',dateopen = '{1}',datedeliver = '{2}',maSP = '{3}',tenSP = '{4}' WHERE id = N'{5}' and type = N'{6}' and id_po = '{7}'", note, dtpRequest, dtpOutCap, maHangSP, tenHangSP, id, "", id_po);
                result = OPMDBHandler.fInsertData(query);
                Return = 0;
            }
            else
            {
                int result = 0;
                string sql = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.CatalogAdmin(ctlID,ctlname,ctlparent) VALUES(N'{0}',N'{1}',N'{2}')", "DP_" + id, id, "PO_" + id_po);
                result = OPMDBHandler.fInsertData(sql);
                string query = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.DP(id,id_po,id_contract,type,dateopen,datedeliver,mskt,note,maSP,tenSP) VALUES(N'{0}',N'{1}',N'{2}',N'{3}','{4}','{5}','{6}',N'{7}',N'{8}',N'{9}')", id, id_po, id_contract, "", dtpRequest, dtpOutCap, "", note, maHangSP, tenHangSP);
                result = OPMDBHandler.fInsertData(query);
                Return = 1;
            }
            return Return;
        }
        public void DeleteDP(string id)
        {
            int result = 0;
            string query1 = string.Format("delete dbo.ListExpected_DP where id_dp = '" + id + "'");
            result = OPMDBHandler.fInsertData(query1);
            string query2 = string.Format("delete dbo.DP where id = '" + id + "'");
            result = OPMDBHandler.fInsertData(query2);
            string query3 = string.Format("delete dbo.CatalogAdmin where ctlID = '" + id + "'");
            result = OPMDBHandler.fInsertData(query3);
        }
        public DataTable GetInforSite(String ProvinceName)
        {
            DataTable dataTable = new DataTable();
            string query = string.Format("SELECT TOP 1 * FROM dbo.Site WHERE headquater = N'{0}'", ProvinceName);
            dataTable = OPMDBHandler.ExecuteQuery(query);
            return dataTable;
        }
        public DataTable GetInforPrice(string idContract, string code)
        {
            DataTable dataTable = new DataTable();
            string query = string.Format("SELECT TOP 1 * FROM dbo.Contract_Goods WHERE idContract = N'{0}' and code = N'{1}'", idContract, code);
            dataTable = OPMDBHandler.ExecuteQuery(query);
            return dataTable;
        }
        public string GetInforSLP(string ProvinceName, string id_dp, string id_po)
        {
            DataTable dataTable = new DataTable();
            string result = "";
            string query = string.Format("SELECT TOP 1 NumberDevice FROM dbo.ListExpected_DP WHERE ProvinceName = N'{0}' and id_dp = N'{1}' and id_po = N'{2}' and type = N'Hàng bảo hành'", ProvinceName, id_dp, id_po);
            dataTable = OPMDBHandler.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                result = dataTable.Rows[0][0].ToString();
            }
            else
            {
                result = "0";
            }
            return result;
        }
        public int InsertListPhuLucSerial(string SerialName, string id_dp, string id_po)
        {
            int result = 0;
            string query = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.PhuLucSerial(Serial,id_dp,id_po) VALUES(N'{0}',N'{1}',N'{2}')", SerialName, id_dp, id_po);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
        public bool Check_Serial(string id_dp, string id_po)
        {
            string query = string.Format("SELECT * FROM dbo.PhuLucSerial WHERE id_dp = N'{0}' and id_po = N'{1}'", id_dp, id_po);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public void Delete_Serial(string id_dp, string id_po)
        {
            string query = string.Format("delete dbo.PhuLucSerial WHERE id_dp = N'{0}' and id_po = N'{1}'", id_dp, id_po);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
        }
        public string querySQL(string id_dp, string id_po)
        {
            string query = string.Format("SELECT * FROM dbo.PhuLucSerial WHERE id_dp = N'{0}' and id_po = N'{1}'", id_dp, id_po);
            return query;
        }
        public DataTable getInforDPByIdDP(string id_dp)
        {
            string query = string.Format("select d.id as 'IdDP', d.id_po,p.po_number, d.id_contract,c.KHMS, d.dateopen, d.datedeliver,d.note,cg.name,cg.code,cg.quantity,d.maSP,d.tenSP from dbo.DP d left join dbo.PO p on p.id = d.id_po left join dbo.Contract c on c.id = p.id_contract left join dbo.Contract_Goods cg on cg.idContract = c.id where d.id = N'{0}'", id_dp);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }
        public bool Check_DSHang(string id_dp, string id_po, string type)
        {
            string query = string.Format("SELECT * FROM dbo.ListExpected_DP WHERE id_dp = '{0}' and type = N'{1}' and id_po = '{2}'", id_dp, type, id_po);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public DataTable getInforListExxpected_DP(string id_dp, string id_po, string type)
        {
            string query = string.Format("select ProvinceName,NumberDevice from dbo.ListExpected_DP where id_dp = '{0}' and id_po = N'{1}' and type = N'{2}'", id_dp, id_po, type);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table;
        }
    }
}
