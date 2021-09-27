using System;
using System.Collections.Generic;
using System.Text;

namespace OPM.OPMEnginee
{
    interface IPackageList
    {
        public int InsertPackageList(IPackageList packageList, string strInsertQuery);
        public int GetDetailPackageList(ref IPackageList packageList, string strQueryOne);
        public int GetAllPackageList(ref List<IPackageList> lstpackageList);
    }
}
