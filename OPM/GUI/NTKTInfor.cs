using OPM.DBHandler;
using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class NTKTInfor : Form
    {
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;

        public delegate void RequestDashBoardOpenNTKTForm(string strIDContract, string strKHMS, string strPONumber, string strPOID);
        public RequestDashBoardOpenNTKTForm requestDashBoardOpenNTKTForm;

        public delegate void RequestDashBoardPurchaseOderForm(string strIDPO, string KHMS);
        public RequestDashBoardPurchaseOderForm requestDashBoardPurchaseOderForm;

        //Khai báo NTKT hiện tại
        public PO_Thanh po;
        public NTKT_Thanh ntkt;

        public NTKTInfor()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //- Lưu vào CSDL dbo.NTKT
            NTKT_Thanh nTKT = new NTKT_Thanh();
            nTKT.Id = tbxId.Text.Trim();
            nTKT.Id_po = tbxId_po.Text.Trim();
            nTKT.Number = int.Parse(tbxNumber.Text.Trim());
            nTKT.Numberofdevice = int.Parse(txbNumberOfDevice.Text.Trim());
            nTKT.Numberofdevice2 = int.Parse(txbNumberOfDevice2.Text.Trim());
            nTKT.Create_date = dtpCreate_date.Value;
            nTKT.Deliver_date_expected = dtpDeliver_Date_Expected.Value;
            nTKT.Date_BBKTKT = dtpDate_BBKTKT.Value;
            nTKT.Date_BBNTKT = dtpDate_BBNTKT.Value;
            nTKT.Date_CNBQPM = dateTimePickerCNBQPM.Value;
            nTKT.InsertOrUpdate();
            OpmWordHandler.Temp08_NTKTRequest(nTKT.Id);
            OpmWordHandler.Temp09_BBKTKT(nTKT.Id);
            OpmWordHandler.Temp10_CNBQPM(nTKT.Id);
            OpmWordHandler.Temp11_BBNTKT(nTKT.Id);
            UpdateCatalogPanel("NTKT_" + nTKT.Id.ToString());
            //- Tạo file D:\OPM\''Tên HĐ''\"Tên PO"\"Tên NTKT".docx
            //- tạo và thông báo tạo thành công hay không file Yêu cầu NTKT
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if(tbxNumber.Text != null)
            {
                //ContractInfoChildForm contractInfoChildForm = new ContractInfoChildForm();
                //contractInfoChildForm.RequestDashBoardOpenPOForm = new ContractInfoChildForm.RequestDashBoardOpenChildForm(OP)
                requestDashBoardPurchaseOderForm(tbxContract.Text, tbxId_po.Text);
                //PurchaseOderInfor purchaseOderInfor = new PurchaseOderInfor();
                //purchaseOderInfor.SetValueItemForPO();

            }
            else
            {
                //tra ve form rong
            }
            return;
        }
        //@Dưỡng Bùi -- Show thông tin NTKT lên UI
        public void setValueItemForNTKT(string IDNTKT)
        {
            NTKT nTKT = new NTKT();
            nTKT.GetObjectNTKT(IDNTKT, ref nTKT);
            string idPO = null, poNumber = null, idContract = null;
            int ret = nTKT.getPOinfor(IDNTKT, ref idPO, ref poNumber, ref idContract);
            PO pO = new PO();
            string namecontract = null, KHMS = null;
            pO.DisplayPO(idPO, ref namecontract, ref KHMS);
            this.tbxId_po.Text = (string)KHMS;
            this.tbxId.Text = (string)idContract;
            this.tbxNumber.Text = (string)nTKT.POID;
            this.txbNumberOfDevice.Text = (string)poNumber;
            //this.txbNTKTID.Text = (string)nTKT.ID_NTKT;
            dtpDeliver_Date_Expected.Value = Convert.ToDateTime(nTKT.DateDuKienNTKT);
        }

        private void NTKTInfor_Load(object sender, EventArgs e)
        {
            if (po == null) return;
            Contract contract = new Contract(po.Id_contract);
            tbxContract.Text = contract.Id;
            tbxId_po.Text = po.Id;
            if (ntkt == null) return;
            tbxId.Text = ntkt.Id;
            dtpCreate_date.Value = ntkt.Create_date;
            tbxNumber.Text = ntkt.Number.ToString();
            dtpDeliver_Date_Expected.Value = ntkt.Deliver_date_expected;
            dtpDate_BBKTKT.Value = ntkt.Date_BBKTKT;
            dtpDate_BBNTKT.Value = ntkt.Date_BBNTKT;
            dateTimePickerCNBQPM.Value = ntkt.Date_CNBQPM;
            txbNumberOfDevice.Text = ntkt.Numberofdevice.ToString();
            txbNumberOfDevice2.Text = ntkt.Numberofdevice2.ToString();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {

        }

        private void txbNumberOfDevice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txbNumberOfDevice2.Text = Math.Round(double.Parse(txbNumberOfDevice.Text) / 50, 0, MidpointRounding.AwayFromZero).ToString();
            }
            catch
            {
                MessageBox.Show("Nhập đúng dạng số!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            NTKT_Thanh.Delete(tbxId.Text.Trim());
            UpdateCatalogPanel("PO_" + tbxId_po.Text.Trim());
        }

        private void textBoxIdNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIdNumber.Text.Trim() != null) tbxId.Text = int.Parse(textBoxIdNumber.Text.Trim()).ToString() + @"/ANSV-DO";
            }
            catch
            {
                MessageBox.Show("Nhập đúng dạng số!");
                return;
            }
        }
    }
}
