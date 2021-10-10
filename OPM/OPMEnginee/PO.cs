using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;

namespace OPM.OPMEnginee
{
    class PO : ContractObj, IPO
    {
        private string _idPO;
        private string _idContract;
        private string _numberPO;
        private string _dateCreatedPO;
        private float _numbefOfDevice;
        private string _durationConfirmPO;
        private string _defaultActiveDatePO;
        private string _deadlinePO;
        private float _totalValuePO;

        public string IDPO
        {
            set { _idPO = value; }
            get { return _idPO; }
        }
        public string IDContract
        {
            set { _idContract = value; }
            get { return _idContract; }
        }
        public string PONumber
        {
            set { _numberPO = value; }
            get { return _numberPO; }
        }
        public float NumberOfDevice
        {
            set { _numbefOfDevice = value; }
            get { return _numbefOfDevice; }
        }
        public string DateCreatedPO
        {
            set { _dateCreatedPO = value; }
            get { return _dateCreatedPO; }
        }
        public string DurationConfirmPO
        {
            set { _durationConfirmPO = value; }
            get { return _durationConfirmPO; }
        }
        public string DefaultActiveDatePO
        {
            set { _defaultActiveDatePO = value; }
            get { return _defaultActiveDatePO; }
        }

        public string DeadLinePO
        {
            set { _deadlinePO = value; }
            get { return _deadlinePO; }
        }

        public float TotalValuePO
        {
            set { _totalValuePO = value; }
            get { return _totalValuePO; }
        }

        public int GetAllPOs(ref List<IPO> lstPOs)
        {
            throw new NotImplementedException();
        }

        public int GetDetailPO(string strQueryOne)
        {
            string strQuery = "select * from PO where id=" + "/'" + strQueryOne + "/'";
            PO newPO = new PO();
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQuery, ref ds);
            if (0 != ds.Tables.Count)
            {
                newPO.IDPO = (string)ds.Tables[0].Rows[0].ItemArray[0];
            }
            else
            {
                return 0;
            }
            return 1;
        }
        public void DeleteInforPO(string ip_po)
        {
            string strQuery1 = "delete from dbo.DP where id_po = N'" + ip_po + "'";
            string strQuery2 = "delete from dbo.ListExpected_DP where id = N'" + ip_po + "'";
            string strQuery3 = "delete from dbo.VBConfirmPO where id_po = N'" + ip_po + "'";
            string strQuery4 = "delete from dbo.PO where id = N'" + ip_po + "'";
            OPMDBHandler.fInsertData(strQuery1);
            OPMDBHandler.fInsertData(strQuery2);
            OPMDBHandler.fInsertData(strQuery3);
            OPMDBHandler.fInsertData(strQuery4);
        }

        public static int GetObjectPO(string strIdPO, ref PO objPO)
        {
            string strQueryOne = "select * from PO where id=" + "'" + strIdPO + "'";
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQueryOne, ref ds);
            Console.Write(ds);
            if (0 != ds.Tables.Count)
            {
                objPO.IDPO = (string)ds.Tables[0].Rows[0].ItemArray[0];
                objPO.IdContract = (string)ds.Tables[0].Rows[0].ItemArray[1];
                objPO.PONumber = (string)ds.Tables[0].Rows[0].ItemArray[2];
                objPO.NumberOfDevice = (float)(double)ds.Tables[0].Rows[0].ItemArray[3];
                objPO.DateCreatedPO = ((DateTime)ds.Tables[0].Rows[0].ItemArray[4]).ToString("yyyy-MM-dd");
                objPO.DurationConfirmPO = ((DateTime)ds.Tables[0].Rows[0].ItemArray[6]).ToString("yyyy-MM-dd");
                objPO.DefaultActiveDatePO = ((DateTime)ds.Tables[0].Rows[0].ItemArray[7]).ToString("yyyy-MM-dd");
                objPO.DeadLinePO = ((DateTime)ds.Tables[0].Rows[0].ItemArray[8]).ToString("yyyy-MM-dd");
                objPO.TotalValuePO = (float)(double)ds.Tables[0].Rows[0].ItemArray[12];

            }
            else
            {
                return 0;
            }
            return 1;
        }

        public int GetDisplayPO(string strIdPO, ref PO objPO)
        {
            string strQueryOne = "select * from PO where id=" + "'" + strIdPO + "'";
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQueryOne, ref ds);
            Console.Write(ds);
            if (0 != ds.Tables.Count)
            {
                objPO.IDPO = (string)ds.Tables[0].Rows[0].ItemArray[0];
                objPO.IdContract = (string)ds.Tables[0].Rows[0].ItemArray[1];
                objPO.PONumber = (string)ds.Tables[0].Rows[0].ItemArray[2];
                objPO.NumberOfDevice = (float)(double)ds.Tables[0].Rows[0].ItemArray[3];
                objPO.DateCreatedPO = ((DateTime)ds.Tables[0].Rows[0].ItemArray[4]).ToString("yyyy-MM-dd");
                objPO.DurationConfirmPO = ((DateTime)ds.Tables[0].Rows[0].ItemArray[6]).ToString("yyyy-MM-dd");
                objPO.DefaultActiveDatePO = ((DateTime)ds.Tables[0].Rows[0].ItemArray[7]).ToString("yyyy-MM-dd");
                objPO.DeadLinePO = ((DateTime)ds.Tables[0].Rows[0].ItemArray[8]).ToString("yyyy-MM-dd");
                objPO.TotalValuePO = (float)(double)ds.Tables[0].Rows[0].ItemArray[12];

            }
            else
            {
                return 0;
            }
            return 1;
        }

        public int DisplayPO(string idPO, ref string namecontract, ref string KHMS)
        {
            string strQueryOne = "SELECT DISTINCT Contract.namecontract, Contract.KHMS FROM Contract INNER JOIN PO ON PO.id_contract = Contract.id WHERE PO.id =" + "'" + idPO + "'";
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQueryOne, ref ds);

            if (0 != ds.Tables.Count)
            {
                namecontract = (string)ds.Tables[0].Rows[0].ItemArray[0];
                KHMS = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            else
            {
                return 0;
            }
            return 1;
        }


        public int InsertListPO(IPO po, string strInsertQuery)
        {
            throw new NotImplementedException();
        }

        public int InsertNewPO(PO po)
        {
            string strInsertPONew = "insert into PO values (";
            strInsertPONew += "'";
            strInsertPONew += po.IDPO;
            strInsertPONew += "','";
            strInsertPONew += po.IDContract;
            strInsertPONew += "','";
            strInsertPONew += po.PONumber;
            strInsertPONew += "','";
            strInsertPONew += po.NumberOfDevice.ToString();
            strInsertPONew += "','";
            strInsertPONew += po.DateCreatedPO;
            strInsertPONew += "','";

            strInsertPONew += "','";

            strInsertPONew += po.DurationConfirmPO;
            strInsertPONew += "','";
            strInsertPONew += po.DefaultActiveDatePO;
            strInsertPONew += "','";
            strInsertPONew += po.DeadLinePO;
            strInsertPONew += "','";

            strInsertPONew += "','";

            strInsertPONew += "','";

            strInsertPONew += "','";

            strInsertPONew += po.TotalValuePO;
            strInsertPONew += "')";
            int ret = OPMDBHandler.fInsertData(strInsertPONew);
            if (0 == ret)
            {
                return ret;
            }
            return 1;
        }
    }
}
