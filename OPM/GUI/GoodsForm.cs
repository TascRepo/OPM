using OPM.OPMEnginee;
using System;
using System.Data;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class GoodsForm : Form
    {
        public GoodsForm()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            tbxName.Text = (Tag as OPMDASHBOARDA).Goods.Name;
            tbxCode.Text = (Tag as OPMDASHBOARDA).Goods.Code;
            tbxManufacturer.Text = (Tag as OPMDASHBOARDA).Goods.Manufacturer;
            tbxOrigin.Text = (Tag as OPMDASHBOARDA).Goods.Origin;
            textBoxLicense.Text = (Tag as OPMDASHBOARDA).Goods.License;
            textBoxName1.Text = (Tag as OPMDASHBOARDA).Goods.Name1;
            textBoxNote.Text = (Tag as OPMDASHBOARDA).Goods.Note;
            textBoxPricePreTax.Text = (Tag as OPMDASHBOARDA).Goods.PricePreTax.ToString();
            textBoxPriceUnit.Text = (Tag as OPMDASHBOARDA).Goods.PriceUnit.ToString();
            textBoxQuantity.Text = (Tag as OPMDASHBOARDA).Goods.Quantity.ToString();
            textBoxTotalTax.Text = (Tag as OPMDASHBOARDA).Goods.Tax.ToString();
            textBoxUnit.Text = (Tag as OPMDASHBOARDA).Goods.Unit;
            textBoxTotalPriceAfterTax.Text = (Tag as OPMDASHBOARDA).Goods.PriceAfterTax.ToString();
        }
        private void textBoxPriceUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxPricePreTax.Text = ((string.IsNullOrEmpty(textBoxPriceUnit.Text.Trim()) ? 0 : double.Parse(textBoxPriceUnit.Text.Trim()) * (string.IsNullOrEmpty(textBoxQuantity.Text.Trim()) ? 0 : int.Parse(textBoxQuantity.Text.Trim())))).ToString();
            }
            catch
            {
                MessageBox.Show(string.Format("Nhập thông tin ở dạng số"));
            }
        }
        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxPricePreTax.Text = ((string.IsNullOrEmpty(textBoxPriceUnit.Text.Trim())? 0 : double.Parse(textBoxPriceUnit.Text.Trim()) * (string.IsNullOrEmpty(textBoxQuantity.Text.Trim()) ? 0 : int.Parse(textBoxQuantity.Text.Trim())))).ToString();
            }
            catch
            {
                MessageBox.Show(string.Format("Nhập thông tin ở dạng số"));
            }
        }

        private void textBoxUnit_TextChanged(object sender, EventArgs e)
        {
            labelQuantity.Text = string.Format(@"Số lượng ({0})", textBoxUnit.Text.Trim());
        }

        private void textBoxPricePreTax_TextChanged(object sender, EventArgs e)
        {
            //setValueContractForm(textBoxPricePreTax.Text,goods);
            textBoxTotalTax.Text = ( (string.IsNullOrEmpty(textBoxPricePreTax.Text.Trim()) ? 0 : Convert.ToDouble(textBoxPricePreTax.Text.Trim()))/10).ToString();
            textBoxTotalPriceAfterTax.Text = ((string.IsNullOrEmpty(textBoxTotalTax.Text.Trim()) ? 0 : Convert.ToDouble(textBoxTotalTax.Text.Trim()))+(string.IsNullOrEmpty(textBoxPricePreTax.Text.Trim()) ? 0 : Convert.ToDouble(textBoxPricePreTax.Text.Trim()))).ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Goods.IdContract = (Tag as OPMDASHBOARDA).Contract.Id;
            (Tag as OPMDASHBOARDA).Goods.Name = tbxName.Text;
            (Tag as OPMDASHBOARDA).Goods.Code= tbxCode.Text;
            (Tag as OPMDASHBOARDA).Goods.Manufacturer= tbxManufacturer.Text;
            (Tag as OPMDASHBOARDA).Goods.Origin= tbxOrigin.Text;
            (Tag as OPMDASHBOARDA).Goods.License= textBoxLicense.Text;
            (Tag as OPMDASHBOARDA).Goods.Name1= textBoxName1.Text;
            (Tag as OPMDASHBOARDA).Goods.Note= textBoxNote.Text;
            (Tag as OPMDASHBOARDA).Goods.PriceUnit= Convert.ToDouble(textBoxPriceUnit.Text.Trim());
            (Tag as OPMDASHBOARDA).Goods.Quantity= Convert.ToInt32(textBoxQuantity.Text);
            (Tag as OPMDASHBOARDA).Goods.Unit= textBoxUnit.Text;
            (Tag as OPMDASHBOARDA).Contract.ContractValue = (Tag as OPMDASHBOARDA).Goods.PriceUnit * (Tag as OPMDASHBOARDA).Goods.Quantity;
            (Tag as OPMDASHBOARDA).OpenContractForm();
        }

        private void GoodsForm_Load(object sender, EventArgs e)
        {
            labelQuantity.Text = string.Format(@"Số lượng ({0})", textBoxUnit.Text.Trim());
            LoadData();
        }
    }
}
