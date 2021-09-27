using System;
using System.Collections.Generic;
using System.Text;

namespace OPM.OPMEnginee
{
    class ListExpPO
    {
        private string idPO;
        private string idProvince;
        private int numberOfDevice;
        private string nameOfDevice;

        public string IdPO { get => idPO; set => idPO = value; }
        public string IdProvince { get => idProvince; set => idProvince = value; }
        public int NumberOfDevice { get => numberOfDevice; set => numberOfDevice = value; }
        public string NameOfDevice { get => nameOfDevice; set => nameOfDevice = value; }
        public int InsertListPO(ListExpPO listExpPO)
        {
            string strInsertListpo = "INSERT INTO ListExpected_PO VALUES (";
            strInsertListpo += "'";
            strInsertListpo += listExpPO.IdPO;
            strInsertListpo += "','";
            strInsertListpo += listExpPO.IdProvince;
            strInsertListpo += "','";
            strInsertListpo += listExpPO.NumberOfDevice;
            strInsertListpo += "','";
            strInsertListpo += listExpPO.NameOfDevice;
            strInsertListpo += "')";
            int ret = OPM.DBHandler.OPMDBHandler.fInsertData(strInsertListpo);
            if (ret == 0)
            {
                return 0;
            }else
                return 1;
        }
        public int InsertMultiListPO(List<ListExpPO> listExpPOs)
        {
            string strInsertListpo = "INSERT INTO ListExpected_PO VALUES ";
            foreach(ListExpPO listExpPO in listExpPOs)
            {
            strInsertListpo += "('";
            strInsertListpo += listExpPO.IdPO;
            strInsertListpo += "','";
            strInsertListpo += listExpPO.IdProvince;
            strInsertListpo += "','";
            strInsertListpo += listExpPO.NumberOfDevice;
            strInsertListpo += "','";
            strInsertListpo += listExpPO.NameOfDevice;
            strInsertListpo += "'),";
            }
            strInsertListpo= strInsertListpo.Remove(strInsertListpo.Length - 1);
            int ret = OPM.DBHandler.OPMDBHandler.fInsertData(strInsertListpo);
            if (ret == 0)
            {
                return 0;
            }
            else
                return 1;
        }
    }

    
}
