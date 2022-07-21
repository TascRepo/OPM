using OPM.OPMEnginee;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class GoodsInfo : Form
    {
        public GoodsInfo()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            ContractObj contract = (Tag as OPMDASHBOARDA).Contract;
            txtContractGoodsDesignation.Text = contract.ContractGoodsDesignation;
            txtContractGoodsDesignation1.Text = contract.ContractGoodsDesignation1;
            txtContractGoodsCode.Text = contract.ContractGoodsCode;
            txtContractGoodsCode1.Text = contract.ContractGoodsCode1;
            txtContractGoodsCode2.Text = contract.ContractGoodsCode2;
            txtContractGoodsManufacture.Text = contract.ContractGoodsManufacture;
            txtContractGoodsOrigin.Text = contract.ContractGoodsOrigin;
            txtContractGoodsSpecies.Text = contract.ContractGoodsSpecies;
            txtContractGoodsNote.Text = contract.ContractGoodsNote;
            txtContractGoodsUnit.Text = contract.ContractGoodsUnit;
            txtContractGoodsUnitPrice.Text = contract.ContractGoodsUnitPrice.ToString();
            txtContractGoodsQuantity.Text = contract.ContractGoodsQuantity.ToString();
            txtPreTaxContractPrice.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", contract.ContractGoodsUnitPrice * contract.ContractGoodsQuantity);
            txtContractGoodsLicenseName.Text = contract.ContractGoodsLicenseName;
            txtContractGoodsLicenseUnitPrice.Text = contract.ContractGoodsLicenseUnitPrice.ToString();
            textBoxContractConformityCertificateNumber.Text = contract.ContractConformityCertificateNumber;

        }
        private void txtContractGoodsUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (Tag as OPMDASHBOARDA).Contract.ContractGoodsUnitPrice = string.IsNullOrEmpty(txtContractGoodsUnitPrice.Text.Trim()) ? 0 : double.Parse(txtContractGoodsUnitPrice.Text.Trim());
                double value = (string.IsNullOrEmpty(txtContractGoodsUnitPrice.Text.Trim()) ? 0 : double.Parse(txtContractGoodsUnitPrice.Text.Trim()) * (string.IsNullOrEmpty(txtContractGoodsQuantity.Text.Trim()) ? 0 : int.Parse(txtContractGoodsQuantity.Text.Trim())));
                txtPreTaxContractPrice.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", value);
            }
            catch
            {
                MessageBox.Show(string.Format("Nhập thông tin UnitPrice ở dạng số"));
            }
        }
        private void txtContractGoodsQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (Tag as OPMDASHBOARDA).Contract.ContractGoodsQuantity = string.IsNullOrEmpty(txtContractGoodsQuantity.Text.Trim()) ? 0 : int.Parse(txtContractGoodsQuantity.Text.Trim());
                double value = (string.IsNullOrEmpty(txtContractGoodsUnitPrice.Text.Trim()) ? 0 : double.Parse(txtContractGoodsUnitPrice.Text.Trim()) * (string.IsNullOrEmpty(txtContractGoodsQuantity.Text.Trim()) ? 0 : int.Parse(txtContractGoodsQuantity.Text.Trim())));
                txtPreTaxContractPrice.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", value);
            }
            catch
            {
                MessageBox.Show(string.Format("Nhập thông tin Quantity ở dạng số"));
            }
        }

        private void txtContractGoodsUnit_TextChanged(object sender, EventArgs e)
        {
            labelQuantity.Text = string.Format(@"Số lượng ({0})", txtContractGoodsUnit.Text.Trim());
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsUnit = txtContractGoodsUnit.Text;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            //(Tag as OPMDASHBOARDA).CurrentNodeName = (Tag as OPMDASHBOARDA).OldNodeName;
            (Tag as OPMDASHBOARDA).OpenContractForm();
        }

        private void GoodsForm_Load(object sender, EventArgs e)
        {
            labelQuantity.Text = string.Format(@"Số lượng ({0})", txtContractGoodsUnit.Text.Trim());
            LoadData();
        }

        private void txtContractGoodsDesignation_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsDesignation = txtContractGoodsDesignation.Text;
        }

        private void txtContractGoodsDesignation1_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsDesignation1 = txtContractGoodsDesignation1.Text;
        }

        private void txtContractGoodsCode_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsCode = txtContractGoodsCode.Text;
        }

        private void txtContractGoodsCode1_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsCode1 = txtContractGoodsCode1.Text;
        }

        private void txtContractGoodsCode2_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsCode2 = txtContractGoodsCode2.Text;
        }

        private void txtContractGoodsManufacture_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsManufacture = txtContractGoodsManufacture.Text;
        }

        private void txtContractGoodsOrigin_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsOrigin = txtContractGoodsOrigin.Text;
        }

        private void txtContractGoodsSpecies_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsSpecies = txtContractGoodsSpecies.Text;
        }

        private void txtContractGoodsNote_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsNote = txtContractGoodsNote.Text;
        }

        private void txtContractGoodsLicenseName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractGoodsLicenseName = txtContractGoodsLicenseName.Text;
        }

        private void txtContractGoodsLicenseUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (Tag as OPMDASHBOARDA).Contract.ContractGoodsLicenseUnitPrice = string.IsNullOrEmpty(txtContractGoodsLicenseUnitPrice.Text.Trim()) ? 0 : int.Parse(txtContractGoodsLicenseUnitPrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show(string.Format("Nhập thông tin LicenseUnitPrice ở dạng số"));
            }
        }

        private void textBoxConformityCertificateNumber_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Contract.ContractConformityCertificateNumber = textBoxContractConformityCertificateNumber.Text;
        }
    }
}
