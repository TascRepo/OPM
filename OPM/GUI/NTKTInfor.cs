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
        public delegate void RequestDashBoardPurchaseOderForm(PO_Thanh pO);
        public RequestDashBoardPurchaseOderForm requestDashBoardPurchaseOderForm;
        private NTKT_Thanh ntkt;
        public NTKT_Thanh Ntkt
        {
            get => ntkt;
            set
            {
                ntkt = value;
                LoadData();
            }
        }
        public NTKTInfor()
        {
            InitializeComponent();
        }
        void LoadData()
        {
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            ntkt.Id = tbxId.Text.Trim();
            ntkt.Number = int.Parse(tbxNumber.Text.Trim());
            ntkt.Numberofdevice = int.Parse(txbNumberOfDevice.Text.Trim());
            ntkt.Numberofdevice2 = int.Parse(txbNumberOfDevice2.Text.Trim());
            ntkt.Create_date = dtpCreate_date.Value;
            ntkt.Deliver_date_expected = dtpDeliver_Date_Expected.Value;
            ntkt.Date_BBKTKT = dtpDate_BBKTKT.Value;
            ntkt.Date_BBNTKT = dtpDate_BBNTKT.Value;
            ntkt.Date_CNBQPM = dateTimePickerCNBQPM.Value;
            ntkt.InsertOrUpdate();
            UpdateCatalogPanel("NTKT_" + ntkt.Id);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            UpdateCatalogPanel("PO_" + ntkt.Id_po);
            PO_Thanh pO = new PO_Thanh(ntkt.Id_po);
            requestDashBoardPurchaseOderForm(pO);
        }
        private void txbNumberOfDevice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbNumberOfDevice.Text.Trim()))
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
            if (MessageBox.Show(string.Format("Bạn có chắc chắn xoá cả đợt NTKT số {0} của {1} không?", ntkt.Id, ntkt.Id_po), "Cảnh báo!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            ntkt.Delete();
            UpdateCatalogPanel("PO_" + ntkt.Id_po);
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

        private void buttonCreatDocument_Click(object sender, EventArgs e)
        {
            OpmWordHandler.Temp08_NTKTRequest(ntkt.Id);
            OpmWordHandler.Temp09_BBKTKT(ntkt.Id);
            OpmWordHandler.Temp10_CNBQPM(ntkt.Id);
            OpmWordHandler.Temp11_BBNTKT(ntkt.Id);
        }
    }
}
