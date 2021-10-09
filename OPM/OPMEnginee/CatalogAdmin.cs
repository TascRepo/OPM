using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OPM.OPMEnginee
{
    class CatalogAdmin
    {
        string ctlParent;
        string ctlID;
        string ctlName;

        public string CtlParent { get => ctlParent; set => ctlParent = value; }
        public string CtlID { get => ctlID; set => ctlID = value; }
        public string CtlName { get => ctlName; set => ctlName = value; }

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
