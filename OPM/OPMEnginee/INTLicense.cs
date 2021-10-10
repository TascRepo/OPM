using System.Collections.Generic;

namespace OPM.OPMEnginee
{
    interface INTLicense
    {
        public int InsertNTLicense(INTLicense ntLicense, string strInsertQuery);
        public int GetDetailNTLicense(ref INTLicense ntLicense, string strQueryOne);
        public int GetAllNTLicense(ref List<INTLicense> lstntLicenses);
    }
}
