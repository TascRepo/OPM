using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    class CatalogAdmin
    {
        string id;
        string name;
        string parent;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Parent { get => parent; set => parent = value; }
        public CatalogAdmin() { }
        public CatalogAdmin(string id, string name, string parent)
        {
            Id = id;
            Name = name;
            Parent = parent;
        }
        public CatalogAdmin(DataRow row)
        {
            Id = (row["ctlId"] == null || row["ctlId"] == DBNull.Value) ? "" : row["ctlId"].ToString();
            Name = (row["ctlName"] == null || row["ctlName"] == DBNull.Value) ? "" : row["ctlName"].ToString();
            Parent = (row["ctlParent"] == null || row["ctlParent"] == DBNull.Value) ? "" : row["ctlParent"].ToString();
        }
        public CatalogAdmin(string id)
        {
            Id = id;
            string query = string.Format("SELECT * FROM dbo.CatalogAdmin WHERE ctlID = '{0}'", id);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    Name = (row["ctlName"] == null || row["ctlName"] == DBNull.Value) ? "" : row["ctlName"].ToString();
                    Parent = (row["ctlParent"] == null || row["ctlParent"] == DBNull.Value) ? "Contract" : row["ctlParent"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.CatalogAdmin!");
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.CatalogAdmin WHERE ctlID = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool Exist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.CatalogAdmin WHERE ctlID = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static DataTable GetCatalogNodes(string strParent)
        {
            string query = "select ctlparent, ctlID, ctlname from CatalogAdmin where ctlparent=" + "'" + strParent + "' ORDER BY ctlname";
            if (null == strParent) query = "select ctlparent, ctlID, ctlname from CatalogAdmin where ctlparent is NULL ORDER BY ctlname";
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static int GetCatalogNodes(ref DataSet ds, string strParent)
        {
            string strQuerry;
            if (null == strParent)
            {
                strQuerry = "select ctlparent, ctlID, ctlname from CatalogAdmin where ctlparent is NULL ORDER BY ctlname";
            }
            else
            {
                strQuerry = "select ctlparent, ctlID, ctlname from CatalogAdmin where ctlparent=" + "'" + strParent + "' ORDER BY ctlname";
            }
            int ret = OPMDBHandler.fQuerryData(strQuerry, ref ds);
            if (0 == ret)
            {
                return 0;
            }
            return 1;
        }
        public static List<string> PathToContractNodeFromCurrentNode(string nameOfCurrentNode,DataTable table)
        {
            if (table.Rows.Count < 1) return null;
            List<string> list = new List<string>();
            string nameOfParentNode = nameOfCurrentNode;
            do
            {
                list.Add(nameOfParentNode);
                //CatalogAdmin catalog = new CatalogAdmin(nameOfParentNode);
                DataRow[] ds = table.Select(string.Format(@"ctlId = '{0}'", nameOfCurrentNode), "ctlname");
                nameOfParentNode = ds[0]["ctlParent"].ToString();
                nameOfCurrentNode = nameOfParentNode;
            } while (nameOfParentNode != "");
            return list;
        }
        public static DataTable Table()
        {
            string query = string.Format("SELECT ctlID, ctlname, ctlparent FROM dbo.CatalogAdmin Order By ctlname");
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static DataRow ToRow(CatalogAdmin catalogAdmin)
        {
            DataRow row = Table().NewRow();
            row["ctlId"] = catalogAdmin.Id;
            row["ctlName"] = catalogAdmin.Name;
            row["ctlParent"] = catalogAdmin.Parent;
            return row;
        }
        public DataRow ToRow()
        {
            DataRow row = Table().NewRow();
            row["ctlId"] = id;
            row["ctlName"] = name;
            row["ctlParent"] = parent;
            return row;
        }
        public static List<CatalogAdmin> CatalogAdmins()
        {
            string query = string.Format("SELECT * FROM dbo.CatalogAdmin Order By ctlname");
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            List<CatalogAdmin> list = new List<CatalogAdmin>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new CatalogAdmin(row));
            }
            return list;
        }
    }
}
