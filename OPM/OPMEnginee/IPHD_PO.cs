using System.Data;
namespace OPM.DBHandler
{
    class IPHD_PO
    {
        public bool Check(string id_dp, string id_po)
        {
            string query = string.Format("SELECT * FROM dbo.ListExpected_DP WHERE id_dp = N'{0}' and id_po = N'{1}'", id_dp, id_po);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public DataTable GetInforDP(string id_dp, string id_po, string type)
        {
            DataTable d = new DataTable();
            string query = string.Format("select ProvinceName as N'Tỉnh/TP',id_dp as N'Mã DP',id_po as N'Mã PO',type as N'Loại hàng',NumberDevice as N'Số lượng' from dbo.ListExpected_DP where id_dp = '{0}' and id_po = N'{1}' and type = N'{2}'", id_dp, id_po, type);
            d = OPMDBHandler.ExecuteQuery(query);
            return d;
        }
        public DataTable GetInforDP_PO_Contract(string provincename, string id_dp, string id_po, string type)
        {
            DataTable d = new DataTable();
            string query = string.Format("select top 1 c.id,c.namecontract,d.id_po,p.po_number,d.id_dp,g.name,g.code,d.ProvinceName,CONVERT(nvarchar, p.dateconfirm, 103) as 'dateconfirm' from dbo.ListExpected_DP d left join dbo.PO p on p.id = d.id_po left join dbo.Contract c on c.id = p.id_contract left join dbo.Contract_Goods g on g.idContract = c.id where d.ProvinceName = N'{0}' and d.id_dp = '{1}' and d.id_po = N'{2}' and type = N'{3}'", provincename, id_dp, id_po, type);
            d = OPMDBHandler.ExecuteQuery(query);
            return d;
        }
    }
}
