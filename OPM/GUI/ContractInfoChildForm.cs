using System;
using System.Windows.Forms;
using OPM.WordHandler;
using OPM.OPMEnginee;
using OPM.EmailHandler;
using System.IO;

namespace OPM.GUI
{
    

    public partial class ContractInfoChildForm : Form
    {
        //Yêu cầu cập nhật Node trên TreeView
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;
        public UpdateCatalogDelegate OpenPurchaseOrderInforGUI;

        //Yêu cầu mở Form PO 
        public delegate void RequestDashBoardOpenChildForm(string strIDContract, string strKHMS);
        public RequestDashBoardOpenChildForm RequestDashBoardOpenPOForm;

        //Yêu cầu mở Form SieA, B
        public delegate void RequestDashBoardOpenDescriptionForm(string id, DescriptionSiteForm.SetIdSite setIdSite);
        public RequestDashBoardOpenDescriptionForm requestDashBoardOpendescriptionForm;

        public ContractInfoChildForm()
        {
            InitializeComponent();
        }
        //Form được gọi bằng IdContract
        public ContractInfoChildForm(string idContract)
        {
            InitializeComponent();
            SetValueItemForm(idContract);
        }
        void SetIdSiteA(string value)
        {
            tbxSiteA.Text = value;
        }
        void SetIdSiteB(string value)
        {
            tbxSiteB.Text = value;
        }
        public void State(bool state)
        {
            txbKHMS.ReadOnly = state;
            tbContract.ReadOnly = state;
            tbBidName.ReadOnly = state;
            tbxAccountingCode.ReadOnly = state;
            tbxDurationContract.ReadOnly = state;
            txbTypeContract.ReadOnly = state;
            tbxValueContract.ReadOnly = state;
            tbxDurationPO.ReadOnly = state;
            txbGaranteeValue.ReadOnly = state;
            txbGaranteeActiveDate.ReadOnly = state;
            tbxSiteA.ReadOnly = state;
            tbxSiteB.ReadOnly = state;
            dateTimePickerActiveDateContract.Enabled = !state;
            dateTimePickerDateSignedPO.Enabled = !state;
        }
        private void SetValueItemForm(string idContract)
        {
            if (Contract.Exist(idContract))
            {
                Contract contract = new Contract(idContract);
                txbKHMS.Text = contract.KHMS;
                tbContract.Text = contract.Id;
                tbBidName.Text = contract.Namecontract;
                tbxAccountingCode.Text = contract.Codeaccouting;
                dateTimePickerDateSignedPO.Value = contract.Datesigned;
                dateTimePickerDurationDateContract.Value = dateTimePickerDateSignedPO.Value.AddDays(Convert.ToInt32(contract.Durationcontract));
                txbTypeContract.Text = contract.Typecontract;
                tbxDurationContract.Text = contract.Durationcontract.ToString();
                dateTimePickerActiveDateContract.Value = contract.Activedate;
                tbxValueContract.Text = contract.Valuecontract.ToString();
                tbxDurationPO.Text = contract.Durationpo.ToString();
                tbxSiteA.Text = contract.Id_siteA;
                tbxSiteB.Text = contract.Id_siteB;
                ExpirationDate.Value = contract.ExperationDate;
                txbGaranteeActiveDate.Text = (contract.ExperationDate - contract.Activedate).TotalDays.ToString();
                txbGaranteeValue.Text = contract.Blvalue.ToString();
                btnCreateGarantee.Enabled = true;
                btnRemove.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnNewPO.Enabled = true;
                State(true);
            }
            else SetItemValue_Default();
        }
        //Tải các thông số mặc định cho Form
        private void SetItemValue_Default()
        {
            txbKHMS.Text = "mua sắm tập trung thiết bị đầu cuối ont loại (2fe/ge+wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020";
            tbContract.Text = "XXX-2021/CUVT-ANSV/DTRR-KHMS";
            tbBidName.Text = "Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)";
            tbxAccountingCode.Text = "C01007";
            dateTimePickerDateSignedPO.Value = DateTime.Now;
            dateTimePickerActiveDateContract.Value = DateTime.Now;
            txbTypeContract.Text = "Theo đơn giá cố định";
            tbxDurationContract.Text = "365";
            dateTimePickerDurationDateContract.Value = DateTime.Now.AddDays(365);
            dateTimePickerDurationDateContract.Enabled = false;
            tbxValueContract.Text = "0";
            tbxDurationPO.Text = "5";
            txbGaranteeValue.Text = "50";
            txbGaranteeActiveDate.Text = "7";
            ExpirationDate.Value = DateTime.Now.AddDays(7);
            ExpirationDate.Enabled = false;
            tbxSiteA.Text = "Trung tâm cung ứng vật tư - Viễn thông TP.HCM";
            tbxSiteB.Text = "Công ty TNHH thiết bị viễn thông ANSV";
            btnCreateGarantee.Enabled = false;
            btnRemove.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = true;
        }
        //Mở Form thông tin Site A
        private void IdSiteA_Click(object sender, EventArgs e)
        {
            requestDashBoardOpendescriptionForm(tbxSiteA.Text, SetIdSiteA);
        }
        //Mở Form thông tin Site B
        private void IdSiteB_Click(object sender, EventArgs e)
        {
            requestDashBoardOpendescriptionForm(tbxSiteB.Text, SetIdSiteB);
        }
        //Mở Form PO
        private void btnNewPO_Click(object sender, EventArgs e)
        {
            string strContract = "Contract_" + tbContract.Text.Trim();
            RequestDashBoardOpenPOForm(strContract, txbKHMS.Text);
            return;
        }
        //private static bool isNumber(string val)
        //{
        //    if (val != "")
        //    {
        //        return System.Text.RegularExpressions.Regex.IsMatch(val, "[^0-9]");
        //    }
        //      else return true;
        //}

        //**********************************
        //Ngày hết hạn hợp đồng = ngày hiệu lực + số ngày thực hiện hợp đồng
        //Ngày hết hạn bảo lãnh = ngày hiệu lực + số ngày bảo lãnh
        private void dateTimePickerActiveDateContract_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerDurationDateContract.Value = dateTimePickerActiveDateContract.Value.AddDays(double.Parse(tbxDurationContract.Text.Trim()));
                ExpirationDate.Value = dateTimePickerActiveDateContract.Value.AddDays(double.Parse(txbGaranteeActiveDate.Text.Trim()));
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải chọn đúng định dạng ngày bắt đầu hợp đồng có hiệu lực!", "Thông báo");
            }
        }
        private void txbGaranteeActiveDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ExpirationDate.Value = dateTimePickerActiveDateContract.Value.AddDays(double.Parse(txbGaranteeActiveDate.Text.Trim()));
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải nhập đúng số lượng (bằng số) ngày đến hạn bảo lãnh!", "Thông báo");
            }
        }
        private void tbxDurationContract_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerDurationDateContract.Value = dateTimePickerActiveDateContract.Value.AddDays(double.Parse(tbxDurationContract.Text.Trim()));
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải nhập đúng số lượng (bằng số) ngày trong hợp đồng!", "Thông báo");
            }
            //TextBox textBox = sender as TextBox;
            //if (isNumber(tbxDurationContract.Text) != true && (tbxDurationContract.Text) !=null)
            //{
            //    dateTimePickerDurationDateContract.Value= dateTimePickerDateSignedPO.Value.AddDays(Convert.ToInt32(tbxDurationContract.Text));
            //} else
            //{
            //    MessageBox.Show("only allow input numbers");
            //    tbxDurationContract.Text = "";
            //}
        }
        //Tạo File bảo lãnh thực hiện hợp đồng .docx
        private void btnCreateGarantee_Click(object sender, EventArgs e)
        {
            if (Contract.Exist(tbContract.Text.Trim()))
            {
                Contract contract = new Contract(tbContract.Text.Trim());
                contract.CreatContractGuarantee();
            }
            else MessageBox.Show("Chưa có hợp đồng {0}", tbContract.Text);
        }
        //Chuyển sang dạng có thể chỉnh sửa Form
        private void btnEdit_Click(object sender, EventArgs e)
        {
            State(false);
            btnSave.Enabled = true;
        }
        //Xoá hợp đồng
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Contract.Delete(tbContract.Text);
            UpdateCatalogPanel(tbContract.Text);
            SetItemValue_Default();
            btnEdit.Enabled = true;
            btnCreateGarantee.Enabled = false;
            btnSave.Enabled = true;
            State(false);
        }
        //Lưu thông tin hợp đồng vào dbo.Contract
        //Cập nhật trên TreeView
        private void btnSave_Click(object sender, EventArgs e)
        {
            Contract contract = new Contract();
            contract.KHMS = txbKHMS.Text;
            contract.Id = tbContract.Text;
            contract.Namecontract = tbBidName.Text;
            contract.Codeaccouting = tbxAccountingCode.Text;
            contract.Typecontract = txbTypeContract.Text;
            contract.Valuecontract = double.Parse(tbxValueContract.Text);
            contract.Blvalue = int.Parse(txbGaranteeValue.Text);
            contract.Id_siteA = tbxSiteA.Text;
            contract.Id_siteB = tbxSiteB.Text;
            contract.Datesigned = dateTimePickerDateSignedPO.Value;
            contract.Activedate = dateTimePickerActiveDateContract.Value;
            contract.ExperationDate = ExpirationDate.Value;
            contract.Durationcontract = int.Parse(tbxDurationContract.Text);
            contract.Durationpo = int.Parse(tbxDurationPO.Text);
            if (contract.Exist()) contract.Update();
            else contract.Insert();
            State(true);
            btnCreateGarantee.Enabled = true;
            btnRemove.Enabled = true;
            btnNewPO.Enabled = true;
            //Cập nhật trên TreeView
            UpdateCatalogPanel(tbContract.Text.Trim());
        }
    }
}
