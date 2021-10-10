using OPM.DBHandler;
using System.Collections.Generic;
using System.Windows.Forms;

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
        public ListExpPO() { }
        public ListExpPO(string _idPO, string _idProvince, int _numberOfDevice, string _nameOfDevice)
        {
            this.idPO = _idPO;
            this.idProvince = _idProvince;
            this.numberOfDevice = _numberOfDevice;
            this.nameOfDevice = _nameOfDevice;
        }
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
            }
            else
                return 1;
        }
        public int InsertListPO(string _idPO, string _idProvince, int _numberOfDevice, string _nameOfDevice)
        {
            string strInsertListpo = "INSERT INTO ListExpected_PO VALUES (";
            strInsertListpo += "'";
            strInsertListpo += _idPO;
            strInsertListpo += "','";
            strInsertListpo += _idProvince;
            strInsertListpo += "','";
            strInsertListpo += _numberOfDevice;
            strInsertListpo += "','";
            strInsertListpo += _nameOfDevice;
            strInsertListpo += "')";
            int ret = OPM.DBHandler.OPMDBHandler.fInsertData(strInsertListpo);
            if (ret == 0)
            {
                return 0;
            }
            else
                return 1;
        }
        public int InsertMultiListPO(List<ListExpPO> listExpPOs)
        {
            string strInsertListpo = "INSERT INTO ListExpected_PO VALUES ";
            foreach (ListExpPO listExpPO in listExpPOs)
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
            strInsertListpo = strInsertListpo.Remove(strInsertListpo.Length - 1);
            int ret = OPM.DBHandler.OPMDBHandler.fInsertData(strInsertListpo);
            if (ret == 0)
            {
                return 0;
            }
            else
                return 1;
        }
        public void Insert()
        {
            string query = string.Format(@"INSERT INTO dbo.ListExpected_PO(id_po,id_province,numberofdevice,nameofdevice) VALUES('{0}','{1}',{2},'{3}'", idPO, idProvince, numberOfDevice, nameOfDevice);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
            }
            catch
            {
                MessageBox.Show("Thêm mới thất bại!");
            }
        }
        public void Update()
        {
            string query = string.Format("UPDATE dbo.ListExpected_PO SET numberofdevice =  {2}, nameofdevice = N'{3}' WHERE id_po = '{0}' and id_province = {1}", idPO, idProvince, numberOfDevice, nameOfDevice);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
            }
            catch
            {
                MessageBox.Show("cập nhật thất bại!");
            }
        }
        public static void Delete(string id_po, string id_province)
        {
            if (MessageBox.Show(string.Format("Có chắc chắn xoá không?"), "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            string query = string.Format(" DELETE FROM dbo.ListExpected_PO WHERE id_po = '{0}' and id_province = '{1}'", id_po, id_province);
            try
            {
                OPMDBHandler.ExecuteNonQuery(query);
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
        }
    }


}
