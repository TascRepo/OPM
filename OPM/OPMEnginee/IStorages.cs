using System;
using System.Collections.Generic;
using System.Text;

namespace OPM.OPMEnginee
{
    interface IStorages
    {
        public int InsertListPO(IStorages storages, string strInsertQuery);
        public int GetDetailPO(ref IStorages storages, string strQueryOne);
        public int GetAllPOs(ref List<IStorages> lstStorages);
    }
}
