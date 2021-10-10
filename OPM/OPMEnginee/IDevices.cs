using System.Collections.Generic;

namespace OPM.OPMEnginee
{
    interface IDevices
    {
        public int InsertListDevices(IDevices devices, string strInsertQuery);
        public int GetDetailDevices(ref IDevices devices, string strQueryOne);
        public int GetAllDevices(ref List<IDevices> devices);
    }
}
