using System;
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
            txtContractGoodsDesignation.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsDesignation;
            txtContractGoodsDesignation1.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsDesignation1;
            txtContractGoodsCode.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsCode;
            txtContractGoodsCode1.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsCode1;
            txtContractGoodsCode2.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsCode2;
            txtContractGoodsManufacture.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsManufacture;
            txtContractGoodsOrigin.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsOrigin;
            txtContractGoodsSpecies.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsSpecies;
            txtContractGoodsNote.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsNote;
            txtContractGoodsUnit.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsUnit;
            txtContractGoodsUnitPrice.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsUnitPrice.ToString();
            txtContractGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsQuantity.ToString();
            txtPreTaxContractPrice.Text = ((Tag as OPMDASHBOARDA).Contract.ContractGoodsUnitPrice * (Tag as OPMDASHBOARDA).Contract.ContractGoodsQuantity).ToString();
            txtContractGoodsLicenseName.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsLicenseName;
            txtContractGoodsLicenseUnitPrice.Text = (Tag as OPMDASHBOARDA).Contract.ContractGoodsLicenseUnitPrice.ToString();
        }
        private void txtContractGoodsUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (Tag as OPMDASHBOARDA).Contract.ContractGoodsUnitPrice = string.IsNullOrEmpty(txtContractGoodsUnitPrice.Text.Trim()) ? 0 : double.Parse(txtContractGoodsUnitPrice.Text.Trim());
                txtPreTaxContractPrice.Text = ((string.IsNullOrEmpty(txtContractGoodsUnitPrice.Text.Trim()) ? 0 : double.Parse(txtContractGoodsUnitPrice.Text.Trim()) * (string.IsNullOrEmpty(txtContractGoodsQuantity.Text.Trim()) ? 0 : int.Parse(txtContractGoodsQuantity.Text.Trim())))).ToString();
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
                txtPreTaxContractPrice.Text = ((string.IsNullOrEmpty(txtContractGoodsUnitPrice.Text.Trim()) ? 0 : double.Parse(txtContractGoodsUnitPrice.Text.Trim()) * (string.IsNullOrEmpty(txtContractGoodsQuantity.Text.Trim()) ? 0 : int.Parse(txtContractGoodsQuantity.Text.Trim())))).ToString();
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
    }
}
