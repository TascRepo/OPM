using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OPM.OPMEnginee
{
    class CatalogAdmin : ICatalogAdmin
    {
        private int _iNumber;
        private string _ctlName;
        private string _ctlParent;
        private int _isParent;

        private string _ctlRootNode;
        private string _ctlParentNode;
        private List<string> _ctlChildNode;

        public CatalogAdmin()
        {
             this._ctlChildNode = new List<string>();
        }
        public string RootNode
        {
            set { _ctlRootNode = value; }
            get { return _ctlRootNode; }
        }
        public string ParentNode
        {
            set { _ctlParentNode = value; }
            get { return _ctlParentNode; }
        }
        public void SetListChildNode(List<string> lstItem)
        {
            foreach(string item in lstItem)
            {
                _ctlChildNode.Add(item);
            }    
        }
        public List<string> GetListChildNode()
        {
            List<string> xlCloneSerial = new List<string>(_ctlChildNode);
            return xlCloneSerial;
        }

        public int STT
        {
            get;
            set;
        }
        public string CatalogName
        {
            get;
            set;
        }
        public string CatalogParent
        {
            get;
            set;
        }
        public int IsParent
        {
            get;
            set;
        }

        public int GetAllNodes()
        {
            string strQuerryCatalog = "select * from CatalogAdmin";
            List<CatalogAdmin> lstCatalogAdmin = new List<CatalogAdmin>();

            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQuerryCatalog, ref ds);
            if (0 != ds.Tables.Count)
            {
                
            }
            else
            {
                return 0;
            }
            return 1;
        }

        public static int GetNodes(ref List<string> strLstNodes, Boolean isParent, string strParent)
        {
            string strQuerry = String.Empty;
            DataSet ds = new DataSet();
            int ret = 0;

            if (true == isParent)
            {
                strQuerry = "select distinct ctlparent from CatalogAdmin where ctlparent is not null";
            }    
            else
            {
                strQuerry = "select ctlID from CatalogAdmin where ctlparent=" + "'" + strParent + "'"; 
            }
            ret = OPMDBHandler.fQuerryData(strQuerry, ref ds);
            if(0 == ret)
            {
                return 0;
            }    

            if (0 != ds.Tables.Count)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    strLstNodes.Add(row[0].ToString());
                }
            }
            else
            {
                return 0;
            }
            return 1;


        }
        public static int GetFamilyNodes(ref List<CatalogAdmin> lstCatalogAdmins)
        {
            List<string> strLstParentNodes  = new List<string>();
            int ret = GetNodes(ref strLstParentNodes, true, String.Empty);
            if( 0 == ret)
            {
                return 0;
            }    

            foreach(string temp in strLstParentNodes)
            {
                List<string> strLstChildNodes = new List<string>();
                ret = GetNodes(ref strLstChildNodes, false, temp);
                if(0 == ret)
                {
                    return 0;
                }
                CatalogAdmin ctlTemp = new CatalogAdmin();
                ctlTemp.CatalogParent = temp;
                ctlTemp.SetListChildNode(strLstChildNodes);
                lstCatalogAdmins.Add(ctlTemp);
            }
            return 1;
        }

        public static int GetCatalogNodes(ref DataSet ds, string strParent)
        {
            string strQuerry = String.Empty;
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
    }
}
