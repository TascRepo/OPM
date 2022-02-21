using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class NTKTInfo : Form
    {
        public NTKTInfo()
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
            lblContractGoodsUnit.Text = (Tag as OPMDASHBOARDA).Ntkt.ContractGoodsUnit;
            lblContractGoodsUnit1.Text = (Tag as OPMDASHBOARDA).Ntkt.ContractGoodsUnit;
            lblContractGoodsUnit2.Text = (Tag as OPMDASHBOARDA).Ntkt.ContractGoodsUnit;
            txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Ntkt.POGoodsQuantity.ToString();
            txtRemainingNTKTGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Ntkt.POGoodsQuantity - NTKTObj.NTKTGoodsQuantityTotalByPOId((Tag as OPMDASHBOARDA).Ntkt.POId)).ToString();
            //txtNTKTExtraQuantity.Text = (Tag as OPMDASHBOARDA).Ntkt.NTKTExtraQuantity.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNTKTId.Text.Trim()) || txtNTKTId.Text.Trim() == (new NTKTObj()).NTKTId)
            {
                MessageBox.Show("Nhập đúng số công văn đề nghị Nghiệm thu kỹ thuật!");
                return;
            }
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PO_" + (Tag as OPMDASHBOARDA).Po.POId;
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
                        txtRemainingNTKTGoodsQuantity.Text = (double.Parse(txtNTKTQuantity.Text.Trim()) - NTKTObj.NTKTGoodsQuantityTotalByPOId((Tag as OPMDASHBOARDA).Ntkt.POId)).ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Nhập đúng NTKTQuantity dạng số!");
                }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName(); 
        }

        private void buttonCreatDocument_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CreatDocumentByNodeName();
        }

        private void txtNTKTId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = txtNTKTId.Text.Trim(); 
            if (NTKTObj.NTKTExist(txtNTKTId.Text.Trim()))
            {
                if (("NTKT_" + txtNTKTId.Text.Trim()) != (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại PO số " + txtNTKTId.Text.Trim());
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Ntkt.NTKTId = txtNTKTId.Text.Trim();
        }

        private void txtNTKTPhase_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Ntkt.NTKTPhase = txtNTKTPhase.Text.Trim();
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode("NTKT " + txtNTKTPhase.Text.Trim());
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

        private void btnNewNTKT_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "NTKT_" + (new NTKTObj()).NTKTId;
        }
    }
}
