using OPM.DBHandler;
using OPM.ExcelHandler;
using OPM.OPMEnginee;
using System;
using System.Data;
using System.Globalization;
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
            POObj po = (Tag as OPMDASHBOARDA).Po;
            txtPOId.Text = po.POId;
            txtPOId.Tag = po.POId;     //Lưu lại Id khi cần vì txtIdPO.Text có thể thay đổi khi Edit
            txtPOName.Text = po.POName;
            dtpPOCreatedDate.Value = po.POCreatedDate;
            txtPODuration.Text = (po.PODeadline.Date - po.POPerformDate.Date).TotalDays.ToString();
            txtPOGoodsQuantity.Text = po.POGoodsQuantity.ToString();
            txtContractGoodsQuantity.Text = po.ContractGoodsQuantity.ToString();
            txtRemainingContractGoodsQuantity.Text = (po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId(po.ContractId)).ToString();
            lblContractGoodsUnit.Text = po.ContractGoodsUnit;
            txtPOConfirmRequestDuration.Text = (po.POConfirmRequestDeadline.Date - po.POCreatedDate.Date).Days.ToString();
            dtpPODefaultPerformDate.Value = po.PODefaultPerformDate;
            txtPOTotalValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.POTotalValue);
            txtPOConfirmId.Text = po.POConfirmId.ToString();
            dtpPOConfirmCreatedDate.Value = po.POConfirmCreatedDate;
            dtpPOPerformDate.Value = po.POPerformDate;
            //dtpDeadline.Value = (Tag as OPMDASHBOARDA).PO.Deadline;
            txtPOAdvanceId.Text = po.POAdvanceId;
            txtPOAdvancePercentage.Text = po.POAdvancePercentage.ToString();
            dtpPOAdvanceCreatedDate.Value = po.POAdvanceCreatedDate;
            txtPOAdvanceGuaranteePercentage.Text = po.POAdvanceGuaranteePercentage.ToString();
            dtpPOAdvanceGuaranteeCreatedDate.Value = po.POAdvanceGuaranteeCreatedDate;
            txtPOAdvanceRequestId.Text = po.POAdvanceRequestId;
            dtpPOAdvanceRequestCreatedDate.Value = po.POAdvanceRequestCreatedDate;
            dtpPOGuaranteeDate.Value = po.POGuaranteeDate;
            txtPOGuaranteeRatio.Text = po.POGuaranteeRatio.ToString();
            dateTimePickerPOReportOfAcceptanceAndHandlingOfGoodsDate.Value = po.POReportOfAcceptanceAndHandlingOfGoodsDate;
            dateTimePickerPOOfferToGuaranteePOWarrantyDate.Value = po.POOfferToGuaranteePOWarrantyDate;
            textBoxPOGoodQuantityAfterAdjustment.Text = po.POGoodQuantityAfterAdjustment.ToString();
            dateTimePickerPOAdjustmentConfirmationDate.Value = po.POAdjustmentConfirmationDate;
            textBoxPOAdjustmentConfirmationNumber.Text = po.POAdjustmentConfirmationNumber;
            textBoxPOValueAfterAdjustment.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.POTotalValueAfterAdjustment);
            dateTimePickerPOQualityCertificationDate.Value = po.POQualityCertificationDate;
            dateTimePickerPOFactoryQualityCertificationDate.Value = po.POFactoryQualityCertificationDate;
            dateTimePickerPOInstallLicenseDate.Value = po.POInstallLicenseDate;
            dateTimePickerPOAcceptanceLicenceDate.Value = po.POAcceptanceLicenceDate;
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
                    double value = (Tag as OPMDASHBOARDA).Po.POTotalValue;
                    txtPOTotalValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", value);
                    value = (0.01 * (Tag as OPMDASHBOARDA).Po.POAdvancePercentage * (Tag as OPMDASHBOARDA).Po.POTotalValue);
                    txtPOAdvanceValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", value);
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
                        txtPOAdvanceValue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", 0.01 * (Tag as OPMDASHBOARDA).Po.POAdvancePercentage * (Tag as OPMDASHBOARDA).Po.POTotalValue);
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

        private void dateTimePickerPOReportOfAcceptanceAndHandlingOfGoodsDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POReportOfAcceptanceAndHandlingOfGoodsDate = dateTimePickerPOReportOfAcceptanceAndHandlingOfGoodsDate.Value;
        }

        private void dateTimePickerPOOfferToGuaranteePOWarrantyDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POOfferToGuaranteePOWarrantyDate = dateTimePickerPOOfferToGuaranteePOWarrantyDate.Value;
        }

        private void textBoxPOAdjustmentConfirmationNumber_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdjustmentConfirmationNumber = textBoxPOAdjustmentConfirmationNumber.Text.Trim();
        }

        private void textBoxPOQuantityAfterAdjustment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxPOGoodQuantityAfterAdjustment.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.POGoodQuantityAfterAdjustment = int.Parse(textBoxPOGoodQuantityAfterAdjustment.Text.Trim());
                    textBoxPOValueAfterAdjustment.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", (Tag as OPMDASHBOARDA).Po.POTotalValueAfterAdjustment);
                }
                else
                    (Tag as OPMDASHBOARDA).Po.POGoodsQuantity = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại POGoodsQuantity dạng số!");
            }
        }

        private void dateTimePickerPOAdjustmentConfirmationDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdjustmentConfirmationDate = dateTimePickerPOAdjustmentConfirmationDate.Value;
        }

        private void dateTimePickerPOQualityCertificationDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POQualityCertificationDate = dateTimePickerPOQualityCertificationDate.Value;
        }

        private void dateTimePickerPOFactoryQualityCertificationDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POFactoryQualityCertificationDate = dateTimePickerPOFactoryQualityCertificationDate.Value;
        }

        private void dateTimePickerPOAcceptanceLicenceDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAcceptanceLicenceDate = dateTimePickerPOAcceptanceLicenceDate.Value;
        }

        private void dateTimePickerPOInstallLicenseDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POInstallLicenseDate = dateTimePickerPOInstallLicenseDate.Value;
        }
    }
}
