using System.Collections.Generic;

namespace OPM.OPMEnginee
{
    interface ICases
    {
        public int InsertListCases(ICases cases, string strInsertQuery);
        public int GetDetailCases(ref ICases cases, string strQueryOne);
        public int GetAllContract(ref List<ICases> lstCase);
    }
}
