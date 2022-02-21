using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class ContractInfo : Form
    {
        public ContractInfo()
        {
            InitializeComponent();
        }
        public void State(bool state)
        {
            txtContractShoppingPlan.ReadOnly = state;
            txtContractId.ReadOnly = state;
            txtContractName.ReadOnly = state;
            txtAccoutingCode.ReadOnly = state;
            txtDuration.ReadOnly = state;
            txtType.ReadOnly = state;
            txtPOGuaranteeValidityPeriod.ReadOnly = state;
            txbGuaranteeValue.ReadOnly = state;
            txtGuaranteeDuration.ReadOnly = state;
            txtIdSiteA.ReadOnly = state;
            dtpContractValidityDate.Enabled = !state;
            dtpDateSigned.Enabled = !state;
            dtpGuaranteeDateCreated.Enabled = !state;
        }
        //Tải các thông số ContractForm với Contract tương ứng
        private void LoadData()
        {
            txtContractShoppingPlan.Text = (Tag as OPMDASHBOARDA).Contract.ContractShoppingPlan;
            txtContractId.Text = (Tag as OPMDASHBOARDA).Contract.ContractId;
            txtContractId.Tag = txtContractId.Text;
            txtContractName.Text = (Tag as OPMDASHBOARDA).Contract.ContractName;
            txtAccoutingCode.Text = (Tag as OPMDASHBOARDA).Contract.ContractAccoutingCode;
            dtpDateSigned.Value = (Tag as OPMDASHBOARDA).Contract.ContractCreatedDate;
            dtpContractDeadline.Value = dtpDateSigned.Value.AddDays(Convert.ToInt32((Tag as OPMDASHBOARDA).Contract.ContractPeriod));
            txtType.Text = (Tag as OPMDASHBOARDA).Contract.ContractType;
            txtDuration.Text = (Tag as OPMDASHBOARDA).Contract.ContractPeriod.ToString();
            dtpContractValidityDate.Value = (Tag as OPMDASHBOARDA).Contract.ContractValidityDate;
            txtValue.Text = Math.Round((Tag as OPMDASHBOARDA).Contract.ContractValue).ToString();
            txtPOGuaranteeValidityPeriod.Text = (Tag as OPMDASHBOARDA).Contract.POGuaranteeValidityPeriod.ToString();
            txtIdSiteA.Text = (Tag as OPMDASHBOARDA).Contract.SiteId;
            txtGuaranteeDuration.Text = ((Tag as OPMDASHBOARDA).Contract.ContractGuaranteeDeadline - (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeCreatedDate).Days.ToString();
            txbGuaranteeValue.Text = (Tag as OPMDASHBOARDA).Contract.POGuaranteeRatio.ToString();
            dtpGuaranteeDateCreated.Value = (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeCreatedDate;
        }
        //Mở Form thông tin Site A
        private void btnIdSiteA_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).backSiteFormStatus = 0;
            (Tag as OPMDASHBOARDA).OpenSiteAForm((Tag as OPMDASHBOARDA).SiteA.SiteId);
        }
        //Mở Form PO
        private void btnNewPO_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Contract.ContractExist())
            {
                (Tag as OPMDASHBOARDA).CurrentNodeName = "PO_" + (new POObj()).POId;
            }
            else
            {
                MessageBox.Show(string.Format("Vẫn chưa lưu hợp đồng số {0}", (Tag as OPMDASHBOARDA).Contract.ContractId), "Thông báo");
            }
        }

        private void dtpActiveDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpContractDeadline.Value = dtpContractValidityDate.Value.AddDays(double.Parse(txtDuration.Text.Trim()));
                (Tag as OPMDASHBOARDA).Contract.ContractDeadline = dtpContractDeadline.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải chọn đúng định dạng ngày bắt đầu hợp đồng có hiệu lực!", "Thông báo");
                return;
            }
            (Tag as OPMDASHBOARDA).Contract.ContractValidityDate = dtpContractValidityDate.Value;
        }
        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDuration.Text.Trim()))
                try
                {
                    dtpContractDeadline.Value = dtpContractValidityDate.Value.AddDays(double.Parse(txtDuration.Text.Trim()));
                    (Tag as OPMDASHBOARDA).Contract.ContractDeadline = dtpContractDeadline.Value;
                }
                catch (Exception)
                {
                    MessageBox.Show("Bạn phải nhập đúng số lượng (bằng số) ngày trong hợp đồng!", "Thông báo");
                    return;
                }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            State(false);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContractId.Text.Trim()) || txtContractId.Text.Trim() == (new ContractObj()).ContractId) 
            {
                MessageBox.Show("Nhập đúng số hợp đồng!");
                return;
            }
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }
        private void ContractInfoChildForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void BtnAnnex_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenGoodsForm();
        }
        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CreatDocumentByNodeName();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "Contract_" + (new ContractObj()).ContractId;
        }
        private void txtContractId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = txtContractId.Text.Trim();
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtContractId.Text.Trim());
            if (ContractObj.ContractExist(txtContractId.Text.Trim())) 
            {
                if(("Contract_"+txtContractId.Text.Trim())!= (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại hợp đồng số " + txtContractId.Text.Trim());
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Contract.ContractId = txtContractId.Text.Trim();
        }
        private void txtContractShoppingPlan_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractShoppingPlan = txtContractShoppingPlan.Text.Trim();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractName = txtContractName.Text.Trim();
        }
        private void txtAccountingCode_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractAccoutingCode = txtAccoutingCode.Text.Trim();
        }
        private void dtpDateSigned_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractCreatedDate = dtpDateSigned.Value;
        }
        private void txtType_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractType = txtType.Text.Trim();
        }
        private void dtpGaranteeDateCreated_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeCreatedDate = dtpGuaranteeDateCreated.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtGuaranteeDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeDeadline = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
                    dtpGuaranteeDeadline.Value = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
                }
                else
                    dtpGuaranteeDeadline.Value = dtpGuaranteeDateCreated.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số thời hạn bảo lãnh!");
            }
        }
        private void txtDurationPO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOGuaranteeValidityPeriod.Text.Trim()))
                    (Tag as OPMDASHBOARDA).Contract.POGuaranteeValidityPeriod = Convert.ToInt32(txtPOGuaranteeValidityPeriod.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Cần nhập đúng định dạng số ngày bảo lãnh PO!");
                return;
            }
        }
        private void txbGaranteeValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txbGuaranteeValue.Text.Trim()))
                    (Tag as OPMDASHBOARDA).Contract.POGuaranteeRatio = int.Parse(txbGuaranteeValue.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Cần nhập đúng định dạng giá trị bảo lãnh!");
                return;
            }
        }
        private void txtGuaranteeDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtGuaranteeDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeDeadline = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
                    dtpGuaranteeDeadline.Value = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
                }
                else
                    dtpGuaranteeDeadline.Value = dtpGuaranteeDateCreated.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số thời hạn bảo lãnh!");
            }
        }

        private void txtIdSiteA_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.SiteId = txtIdSiteA.Text.Trim();
            (Tag as OPMDASHBOARDA).Contract.SetSiteA(new SiteObj(txtIdSiteA.Text.Trim()));
            (Tag as OPMDASHBOARDA).SiteA = new SiteObj(txtIdSiteA.Text.Trim());
        }
    }
}
