using System;
using System.Collections.Generic;

namespace OPM.OPMEnginee
{
    class Devices : IDevices
    {
        private string _serial;
        private string _MAC;
        private string _serial_gpon;
        private string _device_name;
        //private string _note;

        public Devices()
        {

        }
        ~Devices()
        {

        }
        public string Serial
        {
            set { this._serial = value; }
            get { return this._serial; }
        }
        public string ID_storage { set; get; }
        public string MAC
        {
            set { this._MAC = value; }
            get { return this._MAC; }
        }
        public string Serial_gpon
        {
            set { this._serial_gpon = value; }
            get { return this._serial_gpon; }
        }
        public string Device_name
        {
            set { this._device_name = value; }
            get { return this._device_name; }
        }

        public int GetAllDevices(ref List<IDevices> devices)
        {
            throw new NotImplementedException();
        }

        public int GetDetailDevices(ref IDevices cases, string strQueryOne)
        {
            throw new NotImplementedException();
        }

        public int InsertListDevices(IDevices devices, string strInsertQuery)
        {
            throw new NotImplementedException();
        }
    }
}
