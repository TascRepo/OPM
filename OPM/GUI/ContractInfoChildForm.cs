using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class ContractInfoChildForm : Form
    {
        public ContractInfoChildForm()
        {
            InitializeComponent();
        }
        public void State(bool state)
        {
            ttxtKHMS.ReadOnly = state;
            txtId.ReadOnly = state;
            txtName.ReadOnly = state;
            txtAccountingCode.ReadOnly = state;
            txtDuration.ReadOnly = state;
            txtType.ReadOnly = state;
            txtDurationPO.ReadOnly = state;
            txbGuaranteeValue.ReadOnly = state;
            txtGuaranteeDuration.ReadOnly = state;
            txtIdSiteA.ReadOnly = state;
            txtIdSiteB.ReadOnly = state;
            dtpDateActive.Enabled = !state;
            dtpDateSigned.Enabled = !state;
            dtpGuaranteeDateCreated.Enabled = !state;
        }
        //Tải các thông số mặc định cho ContractForm với Contract tương ứng
        private void LoadData()
        {
            ttxtKHMS.Text = (Tag as OPMDASHBOARDA).Contract.KHMS;
            txtId.Text = (Tag as OPMDASHBOARDA).Contract.Id;
            txtId.Tag = txtId.Text;
            txtName.Text = (Tag as OPMDASHBOARDA).Contract.ContractName;
            txtAccountingCode.Text = (Tag as OPMDASHBOARDA).Contract.AccoutingCode;
            dtpDateSigned.Value = (Tag as OPMDASHBOARDA).Contract.SignedDate;
            dtpDeadline.Value = dtpDateSigned.Value.AddDays(Convert.ToInt32((Tag as OPMDASHBOARDA).Contract.ContractDuration));
            txtType.Text = (Tag as OPMDASHBOARDA).Contract.TypeContract;
            txtDuration.Text = (Tag as OPMDASHBOARDA).Contract.ContractDuration.ToString();
            dtpDateActive.Value = (Tag as OPMDASHBOARDA).Contract.ActiveDate;
            txtValue.Text = Math.Round((Tag as OPMDASHBOARDA).Contract.ContractValue).ToString();
            txtDurationPO.Text = (Tag as OPMDASHBOARDA).Contract.PoDuration.ToString();
            txtIdSiteA.Text = (Tag as OPMDASHBOARDA).Contract.IdSiteA;
            txtIdSiteB.Text = (Tag as OPMDASHBOARDA).Contract.IdSiteB;
            txtGuaranteeDuration.Text = ((Tag as OPMDASHBOARDA).Contract.GuaranteeDeadline.Date - (Tag as OPMDASHBOARDA).Contract.GuaranteeCreatedDate).TotalDays.ToString();
            txbGuaranteeValue.Text = (Tag as OPMDASHBOARDA).Contract.GuaranteeValue.ToString();
            txtGuaranteeValue.Text = Math.Round(((0.01 * (Tag as OPMDASHBOARDA).Contract.GuaranteeValue) * (Tag as OPMDASHBOARDA).Contract.ContractValue)).ToString();
            dtpGuaranteeDateCreated.Value = (Tag as OPMDASHBOARDA).Contract.GuaranteeCreatedDate;
        }
        //Mở Form thông tin Site A
        private void btnIdSiteA_Click(object sender, EventArgs e)
        {

            (Tag as OPMDASHBOARDA).OpenSiteAForm(txtIdSiteA.Text);
        }
        //Mở Form thông tin Site B
        private void btnIdSiteB_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenSiteBForm(txtIdSiteB.Text);
        }
        //Mở Form PO
        private void btnNewPO_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Contract.Exist())
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
                dtpDeadline.Value = dtpDateActive.Value.AddDays(double.Parse(txtDuration.Text.Trim()));
                //dtpGaranteeDeadline.Value = dtpDateActive.Value.AddDays(double.Parse(txtDurationGarantee.Text.Trim()));
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải chọn đúng định dạng ngày bắt đầu hợp đồng có hiệu lực!", "Thông báo");
                return;
            }
            (Tag as OPMDASHBOARDA).Contract.ActiveDate = dtpDateActive.Value;
        }
        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDuration.Text.Trim()))
                try
                {
                    dtpDeadline.Value = dtpDateActive.Value.AddDays(double.Parse(txtDuration.Text.Trim()));
                    (Tag as OPMDASHBOARDA).Contract.ContractDuration = int.Parse(txtDuration.Text.Trim());
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
            if ((Tag as OPMDASHBOARDA).Contract.Exist())
            {
                (Tag as OPMDASHBOARDA).Contract.Delete();
                (Tag as OPMDASHBOARDA).Contract = new Contract_Thanh();
                (Tag as OPMDASHBOARDA).OpenContractForm();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Lưu thông tin vào bảng Contract
            if (string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                MessageBox.Show("Cần nhập đúng mã Hợp đồng!");
                return;
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 1)//Chỉnh sửa
            {
                if (txtId.Text == (txtId.Tag as string))
                    (Tag as OPMDASHBOARDA).Contract.Update();
                else if (!(Tag as OPMDASHBOARDA).Contract.Exist())
                    (Tag as OPMDASHBOARDA).Contract.Update(txtId.Tag as string);
                else
                {
                    MessageBox.Show(string.Format("Đã tồn tại hợp đồng số: '{0}'", (Tag as OPMDASHBOARDA).Contract.Id));
                    return;
                }
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 0)//Tạo mới
            {
                if (!(Tag as OPMDASHBOARDA).Contract.Exist())
                    if ((Tag as OPMDASHBOARDA).Contract.Insert() > 0)
                    {
                        (Tag as OPMDASHBOARDA).TempStatus = 1;
                        (Tag as OPMDASHBOARDA).OpenContractForm();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Đã tồn tại hợp đồng số: '{0}'", (Tag as OPMDASHBOARDA).Contract.Id));
                        return;
                    }
            }
            //Lưu thông tin vào bảng Goods
            (Tag as OPMDASHBOARDA).Goods.IdContract = (Tag as OPMDASHBOARDA).Contract.Id;
            if (!(Tag as OPMDASHBOARDA).Goods.Exist())
                (Tag as OPMDASHBOARDA).Goods.Insert();
            else
                (Tag as OPMDASHBOARDA).Goods.Update();
        }
        private void ContractInfoChildForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGuaranteeValue.Text = ((0.01 * int.Parse(txbGuaranteeValue.Text)) * double.Parse(txtValue.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("Cần nhập đúng định dạng số!");
                return;
            }
            (Tag as OPMDASHBOARDA).Contract.ContractValue = double.Parse(txtValue.Text.Trim());
        }
        private void btnAnnex_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenGoodsForm();
        }
        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Contract.Exist()) OpmWordHandler.Temp1_CreatContractGuarantee(txtId.Text.Trim());
            else MessageBox.Show(string.Format(@"Không có hợp đồng số '{0}'", (Tag as OPMDASHBOARDA).Contract.Id));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).TempStatus = 0;//Tạo mới Hợp đồng
            (Tag as OPMDASHBOARDA).Contract = new Contract_Thanh();
            (Tag as OPMDASHBOARDA).OpenContractForm();
        }
        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.Id = txtId.Text.Trim();
            (Tag as OPMDASHBOARDA).Goods.IdContract = txtId.Text.Trim();
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtId.Text.Trim());
        }
        private void ttxtKHMS_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.KHMS = ttxtKHMS.Text.Trim();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractName = txtName.Text.Trim();
        }
        private void txtAccountingCode_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.AccoutingCode = txtAccountingCode.Text.Trim();
        }
        private void dtpDateSigned_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.SignedDate = dtpDateSigned.Value;
        }
        private void txtType_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.TypeContract = txtType.Text.Trim();
        }
        private void txtIdSiteA_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.IdSiteA = txtIdSiteA.Text.Trim();
        }
        private void txtIdSiteB_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.IdSiteB = txtIdSiteB.Text.Trim();
        }
        private void dtpGaranteeDateCreated_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.GuaranteeCreatedDate = dtpGuaranteeDateCreated.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtGuaranteeDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Contract.GuaranteeDeadline = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
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
                if (!string.IsNullOrEmpty(txtDurationPO.Text.Trim()))
                    (Tag as OPMDASHBOARDA).Contract.PoDuration = Convert.ToInt32(txtDurationPO.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Cần nhập đúng định dạng số!");
                return;
            }
        }
        private void dtpGaranteeDeadline_ValueChanged(object sender, EventArgs e)
        {
            //txtGuaranteeDuration.Text = (dtpGuaranteeDeadline.Value - dtpDateActive.Value).TotalDays.ToString();
            //(Tag as OPMDASHBOARDA).Contract.GuaranteeDeadline = dtpGuaranteeDeadline.Value;
        }
        private void txbGaranteeValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txbGuaranteeValue.Text.Trim()))
                {
                    txtGuaranteeValue.Text = string.Format("{0:0.##}", (0.01 * int.Parse(txbGuaranteeValue.Text.Trim())) * double.Parse(txtValue.Text.Trim()));
                    (Tag as OPMDASHBOARDA).Contract.GuaranteeValue = int.Parse(txbGuaranteeValue.Text.Trim());
                }
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
                    (Tag as OPMDASHBOARDA).Contract.GuaranteeDeadline = dtpGuaranteeDateCreated.Value.AddDays(int.Parse(txtGuaranteeDuration.Text.Trim()));
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
