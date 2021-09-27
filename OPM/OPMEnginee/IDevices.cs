using System;
using System.Collections.Generic;
using System.Text;

namespace OPM.OPMEnginee
{
    interface IDevices
    {
        public int InsertListDevices(IDevices devices, string strInsertQuery);
        public int GetDetailDevices(ref IDevices devices, string strQueryOne);
        public int GetAllDevices(ref List<IDevices> devices);
    }
}
