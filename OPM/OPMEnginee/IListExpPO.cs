using System.Collections.Generic;

namespace OPM.OPMEnginee
{
    interface IListExpPO
    {
        public int InsertListExpPO(IListExpPO lstExpPO, string strInsertQuery);
        public int GetDetailListExpPO(ref IListExpPO lstExpPO, string strQueryOne);
        public int GetAllListExpPOP(ref List<IListExpPO> lstExpPOs);
    }
}
