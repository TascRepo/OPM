using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class NTKTInfor : Form
    {
        public NTKTInfor()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            txtNTKTId.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTId;
            txtNTKTId.Tag = txtNTKTId.Text;
            dtpNTKTCreatedDate.Value = (Tag as OPMDASHBOARDA).Ntkt.NTKTCreatedDate;
            txtNTKTPhase.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTPhase.ToString();
            dtpNTKTTestExpectedDate.Value = (Tag as OPMDASHBOARDA).Ntkt.NTKTTestExpectedDate;
            dtpTechnicalInspectionReportDate.Value = (Tag as OPMDASHBOARDA).Ntkt.TechnicalInspectionReportDate;
            dtpTechnicalAcceptanceReportDate.Value = (Tag as OPMDASHBOARDA).Ntkt.TechnicalAcceptanceReportDate;
            dtpNTKTLicenseCertificateDate.Value = (Tag as OPMDASHBOARDA).Ntkt.NTKTLicenseCertificateDate;
            txtNTKTQuantity.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTQuantity.ToString();
            //txtNTKTExtraQuantity.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTExtraQuantity.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNTKTId.Text.Trim())) return;
            //if((Tag as OPMDASHBOARDA).)
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
        }
        private void txbNTKTQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNTKTQuantity.Text.Trim()))
                try
                {
                    if (!string.IsNullOrEmpty(txtNTKTQuantity.Text.Trim()))
                    {
                        (Tag as OPMDASHBOARDA).Ntkt.NTKTQuantity = double.Parse(txtNTKTQuantity.Text.Trim());
                        txtNTKTExtraQuantity.Text = Math.Round(double.Parse(txtNTKTQuantity.Text.Trim()) / 50, 0, MidpointRounding.AwayFromZero).ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Nhập đúng NTKTQuantity dạng số!");
                }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có chắc chắn xoá cả đợt NTKT số {0} của {1} không?", (Tag as OPMDASHBOARDA).Ntkt.NTKTId, (Tag as OPMDASHBOARDA).Ntkt.POId), "Cảnh báo!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
        }

        private void buttonCreatDocument_Click(object sender, EventArgs e)
        {
            OpmWordHandler.Temp08_NTKTRequest((Tag as OPMDASHBOARDA).Ntkt.NTKTId);
            OpmWordHandler.Temp09_BBKTKT((Tag as OPMDASHBOARDA).Ntkt.NTKTId);
            OpmWordHandler.Temp10_CNBQPM((Tag as OPMDASHBOARDA).Ntkt.NTKTId);
            OpmWordHandler.Temp11_BBNTKT((Tag as OPMDASHBOARDA).Ntkt.NTKTId);
        }

        private void txtNTKTId_TextChanged(object sender, EventArgs e)
        {
            if (NTKTObj.NTKTExist(txtNTKTId.Text.Trim())) return;
            (Tag as OPMDASHBOARDA).Ntkt.NTKTId = txtNTKTId.Text.Trim();
        }

        private void txtNTKTPhase_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTPhase = txtNTKTPhase.Text.Trim();
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode("NTKT" + txtNTKTPhase.Text.Trim());
        }

        private void dtpNTKTCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTCreatedDate = dtpNTKTCreatedDate.Value;
        }

        private void dtpNTKTTestExpectedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTTestExpectedDate = dtpNTKTTestExpectedDate.Value;
        }

        private void dtpTechnicalInspectionReportDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.TechnicalInspectionReportDate = dtpTechnicalInspectionReportDate.Value;
        }

        private void dtpNTKTLicenseCertificateDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTLicenseCertificateDate = dtpNTKTLicenseCertificateDate.Value;
        }

        private void dtpTechnicalAcceptanceReportDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.TechnicalAcceptanceReportDate = dtpTechnicalAcceptanceReportDate.Value;
        }

        private void NTKTInfor_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
