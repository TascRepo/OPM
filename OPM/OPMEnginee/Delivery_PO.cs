using System.Data;

namespace OPM.DBHandler
{
    public partial class Delivery_PO
    {
        private string numberConfirmPO = "1";
        private string province = "2";
        private string count_PO = "3";
        private string number_PO = "4";
        private string date_Delivery = "5";
        public string NumberConfirmPO { get => numberConfirmPO; set => numberConfirmPO = value; }
        public string Province { get => province; set => province = value; }
        public string Count_PO { get => count_PO; set => count_PO = value; }
        public string Number_PO { get => number_PO; set => number_PO = value; }
        public string Date_Delivery { get => date_Delivery; set => date_Delivery = value; }
        public Delivery_PO() { }
        public Delivery_PO(string _numberConfirmPO, string _province, string _count_PO, string _number_PO, string _date_Delivery)
        {
            numberConfirmPO = _numberConfirmPO;
            province = _province;
            count_PO = _count_PO;
            number_PO = _number_PO;
            date_Delivery = _date_Delivery;
        }
        public int CheckDelivery_PO(string strQueryOne, string id_po)
        {
            string strQuery = string.Format("SELECT * FROM dbo.Delivery_PO WHERE NumberConfirmPO = '{0}' and id_po = '{0}'", strQueryOne, id_po);
            Delivery_PO newPO = new Delivery_PO();
            DataSet ds = new DataSet();
            int ret = OPMDBHandler.fQuerryData(strQuery, ref ds);
            if (0 != ds.Tables.Count)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string querySQL(string strQueryOne)
        {
            string strQuery = string.Format("SELECT * FROM dbo.Delivery_PO WHERE NumberConfirmPO = '{0}'", strQueryOne);
            return strQuery;
        }
    }
}
