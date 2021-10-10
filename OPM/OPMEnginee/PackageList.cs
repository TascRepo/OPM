using System;
using System.Collections.Generic;

namespace OPM.OPMEnginee
{
    class Packagelist : IPackageList
    {
        private string _year;
        private string _po_number;
        private string _province;
        private int _number;
        private List<string> _serial = new List<string>();

        public Packagelist()
        {

        }
        ~Packagelist()
        {

        }
        public string Year
        {
            set { _year = value; }
            get { return _year; }
        }
        public string PO_number
        {
            set { _po_number = value; }
            get { return _po_number; }
        }
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        public int Numberdevice
        {
            set { _number = value; }
            get { return _number; }
        }
        public void SetSerial(string strItem)
        {
            _serial.Add(strItem);
        }
        public string GetItem(int index)
        {
            return _serial[index];
        }

        public List<string> GetListSerial()
        {
            List<string> xlCloneSerial = new List<string>(_serial);
            return xlCloneSerial;
        }

        public int InsertPackageList(IPackageList packageList, string strInsertQuery)
        {
            throw new NotImplementedException();
        }

        public int GetDetailPackageList(ref IPackageList packageList, string strQueryOne)
        {
            throw new NotImplementedException();
        }

        public int GetAllPackageList(ref List<IPackageList> lstpackageList)
        {
            throw new NotImplementedException();
        }
    }

}
