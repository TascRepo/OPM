using System.Collections.Generic;

namespace OPM.OPMEnginee
{
    interface IDP
    {
        public int InsertListDP(IDP dp, string strInsertQuery);
        public int GetDetailDP(ref IDP dp, string strQueryOne);
        public int GetAllDP(ref List<IDP> dps);
    }
}
