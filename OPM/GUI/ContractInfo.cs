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
            txtAccoutingCode.Text = (Tag as OPMDASHBOARDA).Contract.AccoutingCode;
            dtpDateSigned.Value = (Tag as OPMDASHBOARDA).Contract.ContractCreatedDate;
            dtpContractDeadline.Value = dtpDateSigned.Value.AddDays(Convert.ToInt32((Tag as OPMDASHBOARDA).Contract.ContractPeriod));
            txtType.Text = (Tag as OPMDASHBOARDA).Contract.ContractType;
            txtDuration.Text = (Tag as OPMDASHBOARDA).Contract.ContractPeriod.ToString();
            dtpContractValidityDate.Value = (Tag as OPMDASHBOARDA).Contract.ContractValidityDate;
            txtValue.Text = Math.Round((Tag as OPMDASHBOARDA).Contract.ContractValue).ToString();
            txtPOGuaranteeValidityPeriod.Text = (Tag as OPMDASHBOARDA).Contract.POGuaranteeValidityPeriod.ToString();
            txtIdSiteA.Text = (Tag as OPMDASHBOARDA).Contract.ContractSiteId;
            txtGuaranteeDuration.Text = ((Tag as OPMDASHBOARDA).Contract.ContractGuaranteeDeadline - (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeCreatedDate).Days.ToString();
            txbGuaranteeValue.Text = (Tag as OPMDASHBOARDA).Contract.POGuaranteeRatio.ToString();
            dtpGuaranteeDateCreated.Value = (Tag as OPMDASHBOARDA).Contract.ContractGuaranteeCreatedDate;
        }
        //Mở Form thông tin Site A
        private void btnIdSiteA_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenSiteAForm(txtIdSiteA.Text);
        }
        //Mở Form PO
        private void btnNewPO_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Contract.ContractExist())
            {
                (Tag as OPMDASHBOARDA).TempStatus = 3;//Chuyển sang Form tạo mới PO
                (Tag as OPMDASHBOARDA).OpenPOForm();
            }
        }

        //**********************************
        //Ngày hết hạn hợp đồng = ngày hiệu lực + số ngày thực hiện hợp đồng
        //Ngày hết hạn bảo lãnh = ngày hiệu lực + số ngày bảo lãnh
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
            //(Tag as OPMDASHBOARDA).TempStatus = 1;//Chỉnh sửa Hợp đồng
            State(false);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Contract.ContractExist())
            {
                (Tag as OPMDASHBOARDA).Contract.ContractDelete();
                (Tag as OPMDASHBOARDA).Contract = new ContractObj();
                (Tag as OPMDASHBOARDA).OpenContractForm();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Lưu thông tin vào bảng Contract
            if (string.IsNullOrEmpty(txtContractId.Text.Trim()))
            {
                MessageBox.Show("Cần nhập đúng mã Hợp đồng!");
                return;
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 1)//Chỉnh sửa
            {
                if (txtContractId.Text == (txtContractId.Tag as string))
                    (Tag as OPMDASHBOARDA).Contract.ContractUpdate();
                else if (!(Tag as OPMDASHBOARDA).Contract.ContractExist())
                    (Tag as OPMDASHBOARDA).Contract.ContractUpdate(txtContractId.Tag as string);
                else
                {
                    MessageBox.Show(string.Format("Đã tồn tại hợp đồng số: '{0}'", (Tag as OPMDASHBOARDA).Contract.ContractId));
                    return;
                }
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 0)//Tạo mới
            {
                if (!(Tag as OPMDASHBOARDA).Contract.ContractExist())
                    if ((Tag as OPMDASHBOARDA).Contract.ContractInsert() > 0)
                    {
                        (Tag as OPMDASHBOARDA).TempStatus = 1;
                        (Tag as OPMDASHBOARDA).OpenContractForm();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Đã tồn tại hợp đồng số: '{0}'", (Tag as OPMDASHBOARDA).Contract.ContractId));
                        return;
                    }
            }
            //Lưu thông tin vào bảng Goods
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
            if ((Tag as OPMDASHBOARDA).Contract.ContractExist()) OpmWordHandler.Temp1_CreatContractGuarantee(txtContractId.Text.Trim());
            else MessageBox.Show(string.Format(@"Không có hợp đồng số '{0}'", (Tag as OPMDASHBOARDA).Contract.ContractId));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).TempStatus = 0;//Tạo mới Hợp đồng
            (Tag as OPMDASHBOARDA).Contract = new ContractObj();
            (Tag as OPMDASHBOARDA).OpenContractForm();
        }
        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtContractId.Text.Trim());
            if (ContractObj.ContractExist(txtContractId.Text.Trim())) return;
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
            (Tag as OPMDASHBOARDA).Contract.AccoutingCode = txtAccoutingCode.Text.Trim();
        }
        private void dtpDateSigned_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractCreatedDate = dtpDateSigned.Value;
        }
        private void txtType_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractType = txtType.Text.Trim();
        }
        private void txtIdSiteA_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractSiteId = txtIdSiteA.Text.Trim();
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

    }
}
