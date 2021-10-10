using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
        public static List<string> PathToContractNodeFromCurrentNode(string nameOfCurrentNode)
        {
            if (!CatalogAdmin.Exist(nameOfCurrentNode)) 
            {
                MessageBox.Show(string.Format(@"Không có Node {0} trong CSDL!", nameOfCurrentNode));
                return null;
            }
            List<string> list = new List<string>(); 
            string nameOfParentNode = nameOfCurrentNode;
            do
            {
                list.Add(nameOfParentNode);
                CatalogAdmin catalog = new CatalogAdmin(nameOfParentNode);
                nameOfParentNode = catalog.Parent;
            } while (nameOfParentNode != "Contract");
            return list;
        }
    }
}
