using OPM.DBHandler;
using OPM.ExcelHandler;
using OPM.OPMEnginee;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class POInfo : Form
    {
        public POInfo()
        {
            InitializeComponent();
        }
        private void PurchaseOderInfor_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            txtPOId.Text = (Tag as OPMDASHBOARDA).Po.POId;
            txtPOId.Tag = (Tag as OPMDASHBOARDA).Po.POId;     //Lưu lại Id khi cần vì txtIdPO.Text có thể thay đổi khi Edit
            txtPOName.Text = (Tag as OPMDASHBOARDA).Po.POName;
            dtpPOCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POCreatedDate;
            txtPODuration.Text = ((Tag as OPMDASHBOARDA).Po.PODeadline.Date - (Tag as OPMDASHBOARDA).Po.POPerformDate.Date).TotalDays.ToString();
            txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.POGoodsQuantity.ToString();
            txtContractGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity.ToString();
            txtRemainingContractGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId((Tag as OPMDASHBOARDA).Po.ContractId)).ToString();
            lblContractGoodsUnit.Text = (Tag as OPMDASHBOARDA).Po.ContractGoodsUnit;
            txtPOConfirmRequestDuration.Text = ((Tag as OPMDASHBOARDA).Po.POConfirmRequestDeadline.Date - (Tag as OPMDASHBOARDA).Po.POCreatedDate.Date).Days.ToString();
            dtpPODefaultPerformDate.Value = (Tag as OPMDASHBOARDA).Po.PODefaultPerformDate;
            txtPOTotalValue.Text = (Tag as OPMDASHBOARDA).Po.POTotalValue.ToString();
            txtPOConfirmId.Text = (Tag as OPMDASHBOARDA).Po.POConfirmId.ToString();
            dtpPOConfirmCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POConfirmCreatedDate;
            dtpPOPerformDate.Value = (Tag as OPMDASHBOARDA).Po.POPerformDate;
            //dtpDeadline.Value = (Tag as OPMDASHBOARDA).PO.Deadline;
            txtPOAdvanceId.Text = (Tag as OPMDASHBOARDA).Po.POAdvanceId;
            txtPOAdvancePercentage.Text = (Tag as OPMDASHBOARDA).Po.POAdvancePercentage.ToString();
            dtpPOAdvanceCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POAdvanceCreatedDate;
            txtPOAdvanceGuaranteePercentage.Text = (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteePercentage.ToString();
            dtpPOAdvanceGuaranteeCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteeCreatedDate;
            txtPOAdvanceRequestId.Text = (Tag as OPMDASHBOARDA).Po.POAdvanceRequestId;
            dtpPOAdvanceRequestCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POAdvanceRequestCreatedDate;
            dtpPOGuaranteeDate.Value = (Tag as OPMDASHBOARDA).Po.POGuaranteeDate;
            txtPOGuaranteeRatio.Text = (Tag as OPMDASHBOARDA).Po.POGuaranteeRatio.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPOId.Text.Trim()) || txtPOId.Text.Trim() == (new POObj()).POId)
            {
                MessageBox.Show("Nhập đúng số PO!");
                return;
            }
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }

        private void btnNewNTKT_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Po.POExist())
            {
                (Tag as OPMDASHBOARDA).CurrentNodeName = "NTKT_" + (new NTKTObj()).NTKTId;
            }
            else
            {
                MessageBox.Show(string.Format("Vẫn chưa lưu PO số {0}", (Tag as OPMDASHBOARDA).Po.POId), "Thông báo");
            }
        }
        private void btnNewDP_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Po.POExist())
            {
                if (DeliveryPlanObj.DeliveryPlanExist((Tag as OPMDASHBOARDA).Po.POId))
                {
                    (Tag as OPMDASHBOARDA).CurrentNodeName = "DP_" + (new DPObj()).DPId;
                }
                else
                {
                    MessageBox.Show(string.Format("Vẫn chưa tạo kế hoạch giao hàng của PO số {0}", (Tag as OPMDASHBOARDA).Po.POId), "Thông báo");
                }
            }
            else
            {
                MessageBox.Show(string.Format("Vẫn chưa lưu PO số {0}", (Tag as OPMDASHBOARDA).Po.POId), "Thông báo");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }

        public OpenFileDialog openFileExcel = new OpenFileDialog();
        public string sConnectionString = null;
        private void txtPOConfirmRequestDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOConfirmRequestDuration.Text.Trim()))
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value.AddDays(int.Parse(txtPOConfirmRequestDuration.Text.Trim()));
                else
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại POConfirmRequestDuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.POConfirmRequestDeadline = dtpPOConfirmRequestDeadline.Value;
        }
        private void dtpPOCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POCreatedDate = dtpPOCreatedDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtPOConfirmRequestDuration.Text.Trim()))
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value.AddDays(int.Parse(txtPOConfirmRequestDuration.Text.Trim()));
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại POConfirmRequestDuration dạng số!");
            }
        }
        private void txtPODuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại PODuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPODeadline.Value;
        }
        static public DataTable dt = new DataTable();
        static public DataTable dtkhgh = new DataTable();
        static public string IDVBXN = "";
        static public string IPPO = "";


        private void btnDeliveryPlan_Click(object sender, EventArgs e)
        {
            if (POObj.POExist((Tag as OPMDASHBOARDA).Po.POId))
            {
                (Tag as OPMDASHBOARDA).backSiteFormStatus = 1;
                (Tag as OPMDASHBOARDA).OpenDeliveryPlanForm();
            }
            else MessageBox.Show("Không tồn tại PO số: ", (Tag as OPMDASHBOARDA).Po.POId);
        }
        private void txtPOId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = txtPOId.Text.Trim();
            if (POObj.POExist(txtPOId.Text.Trim()))
            {
                if (("PO_" + txtPOId.Text.Trim()) != (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại PO số " + txtPOId.Text.Trim());
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Po.POId = txtPOId.Text.Trim();
        }
        private void TxtPOName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POName = txtPOName.Text;
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtPOName.Text);
        }
        private void txtPOGoodsQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOGoodsQuantity.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.POGoodsQuantity = int.Parse(txtPOGoodsQuantity.Text.Trim());
                    txtPOTotalValue.Text = (Tag as OPMDASHBOARDA).Po.POTotalValue.ToString();
                    txtPOAdvanceValue.Text = (0.01 * (Tag as OPMDASHBOARDA).Po.POAdvancePercentage * (Tag as OPMDASHBOARDA).Po.POTotalValue).ToString();
                }
                else
                    (Tag as OPMDASHBOARDA).Po.POGoodsQuantity = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại POGoodsQuantity dạng số!");
            }
        }

        private void dtpPODefaultPerformDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.PODefaultPerformDate = dtpPODefaultPerformDate.Value;
        }
        private void txtPOConfirmId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POConfirmId = txtPOConfirmId.Text.Trim();
        }
        private void dtpPOConfirmCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POConfirmCreatedDate = dtpPOConfirmCreatedDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                }
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại ConfirmCreatedDate dạng số!");
            }
        }

        private void dtpPOPerformDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POPerformDate = dtpPOPerformDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại PODuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPODeadline.Value;
        }

        private void txtPOAdvancePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOAdvancePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtPOAdvancePercentage.Text.Trim()) && int.Parse(txtPOAdvancePercentage.Text.Trim()) <= 100)
                    {
                        (Tag as OPMDASHBOARDA).Po.POAdvancePercentage = int.Parse(txtPOAdvancePercentage.Text.Trim());
                        txtPOAdvanceValue.Text = (0.01 * (Tag as OPMDASHBOARDA).Po.POAdvancePercentage * (Tag as OPMDASHBOARDA).Po.POTotalValue).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại POAdvancePercentage dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nhập lại POAdvancePercentage dạng số!");
            }
        }

        private void dtpAdvanceCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceCreatedDate = dtpPOAdvanceCreatedDate.Value;
        }

        private void txtPOAdvanceGuaranteePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOAdvanceGuaranteePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim()) && int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim()) <= 100)
                        (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteePercentage = int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim());
                    else
                    {
                        MessageBox.Show("Nhập lại dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
                else
                    (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteePercentage = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại POAdvanceGuaranteePercentage dạng số!");
            }
        }

        private void dtpAdvanceGuaranteeCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteeCreatedDate = dtpPOAdvanceGuaranteeCreatedDate.Value;
        }

        private void txtIdAdvanceRequest_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceRequestId = txtPOAdvanceRequestId.Text.Trim();
        }

        private void dtpAdvanceRequestDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceRequestCreatedDate = dtpPOAdvanceRequestCreatedDate.Value;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "Contract_" + (Tag as OPMDASHBOARDA).Po.ContractId;
        }

        private void btnNewPO_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PO_" + (new POObj()).POId;
        }

        private void btnCreatDoc_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CreatDocumentByNodeName();
        }

        private void txtPOAdvanceId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceId = txtPOAdvanceId.Text.Trim();
        }

        private void dtpPOGuaranteeDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POGuaranteeDate = dtpPOGuaranteeDate.Value;
        }

    }
}
