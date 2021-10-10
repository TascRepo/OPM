using OPM.DBHandler;
using System.Data;

namespace OPM.OPMEnginee
{
    class ConfirmPO : NTKT
    {
        private string _idConfirmPO;
        public string ConfirmPOID
        {
            set { _idConfirmPO = value; }
            get { return _idConfirmPO; }
        }

        public int CheckExistConfirmPO(string strIDConfirmPO)
        {
            string strQueryOne = "select * from VBConfirmPO where id=" + "'" + strIDConfirmPO + "'";
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQueryOne, ref ds);
            if (0 != ret)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public int InsertNewConfirmPO(ConfirmPO confirmPO)
        {
            string strInsertConfirmPONew = "insert into VBConfirmPO values (";
            strInsertConfirmPONew += "'";
            strInsertConfirmPONew += confirmPO.ConfirmPOID;
            strInsertConfirmPONew += "','";
            strInsertConfirmPONew += confirmPO.POID;
            strInsertConfirmPONew += "','";
            strInsertConfirmPONew += "')";
            int ret = OPMDBHandler.fInsertData(strInsertConfirmPONew);
            if (0 == ret)
            {
                return ret;
            }
            return 1;
        }
    }
}
