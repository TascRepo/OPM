using System;
using System.Collections.Generic;
using System.Text;

namespace OPM.OPMEnginee
{
    class DP
    {
        private string id;
        private string idPO;
        private string idContract;
        private string type;
        private string dateOpen;
        private string dateDeliver;
        private string maKT;
        private string note;

        public string Id { get => id; set => id = value; }
        public string IdPO { get => idPO; set => idPO = value; }
        public string IdContract { get => idContract; set => idContract = value; }
        public string Type { get => type; set => type = value; }
        public string DateOpen { get => dateOpen; set => dateOpen = value; }
        public string DateDeliver { get => dateDeliver; set => dateDeliver = value; }
        public string MaKT { get => maKT; set => maKT = value; }
        public string Note { get => note; set => note = value; }


        public static int getObjectDP(string idDP)
        {
            return 1;
        }
        public static int InsertDP(DP dP)
        {
            string strInsert = "INSERT INTO DP VALUES(";
            strInsert += "'";
            strInsert += dP.Id;
            strInsert += "','";
            strInsert += dP.IdPO;
            strInsert += "','";
            strInsert += dP.IdContract;
            strInsert += "',N'";
            strInsert += dP.type;
            strInsert += "','";
            strInsert += dP.dateOpen;
            strInsert += "','";
            strInsert += dP.DateDeliver;
            strInsert += "','";
            strInsert += dP.maKT;
            strInsert += "',N'";
            strInsert += dP.note;
            strInsert += "')";
            int ret =OPM.DBHandler.OPMDBHandler.fInsertData(strInsert);
            if(ret == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

}
