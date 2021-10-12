using OPM.OPMEnginee;
using System;
using System.Data;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class Contract_Goods_Form : Form
    {
        public delegate void SetValueContractForm(string vl, Contract_Goods goods);
        public SetValueContractForm setValueContractForm;
        private Contract_Goods goods;

        public Contract_Goods Goods { get => goods; set => goods = value; }

        public Contract_Goods_Form()
        {
            InitializeComponent();
        }
        private void Contract_Goods_Form_Load(object sender, EventArgs e)
        {
            if (goods == null) return;
            LoadData();
            //if (!Contract.Exist(Tag.ToString()))
            //{
            //    MessageBox.Show("Cần tạo hợp đồng trước khi nhập phụ lục hợp đồng!");
            //    this.Close();
            //}
            labelQuantity.Text = string.Format(@"Số lượng ({0})", textBoxUnit.Text.Trim());
        }
        void LoadData()
        {
            tbxName.Text = goods.Name;
            tbxCode.Text = goods.Code;
            tbxManufacturer.Text = goods.Manufacturer;
            tbxOrigin.Text = goods.Origin;
            textBoxLicense.Text = goods.License;
            textBoxName1.Text = goods.Name1;
            textBoxNote.Text = goods.Note;
            textBoxPricePreTax.Text = goods.PricePreTax.ToString();
            textBoxPriceUnit.Text = goods.PriceUnit.ToString();
            textBoxQuantity.Text = goods.Quantity.ToString();
            textBoxTotalTax.Text = goods.Tax.ToString();
            textBoxUnit.Text = goods.Unit;
            textBoxTotalPriceAfterTax.Text = goods.PriceAfterTax.ToString();
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
            setValueContractForm(textBoxPricePreTax.Text,goods);
            textBoxTotalTax.Text = (0.1 * (string.IsNullOrEmpty(textBoxPricePreTax.Text.Trim()) ? 0 : double.Parse(textBoxPricePreTax.Text.Trim()))).ToString();
            textBoxTotalPriceAfterTax.Text = ((string.IsNullOrEmpty(textBoxTotalTax.Text.Trim()) ? 0 : double.Parse(textBoxTotalTax.Text.Trim()))+(string.IsNullOrEmpty(textBoxPricePreTax.Text.Trim()) ? 0 : double.Parse(textBoxPricePreTax.Text.Trim()))).ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            goods.Name= tbxName.Text;
            goods.Code= tbxCode.Text;
            goods.Manufacturer= tbxManufacturer.Text;
            goods.Origin= tbxOrigin.Text;
            goods.License= textBoxLicense.Text;
            goods.Name1= textBoxName1.Text;
            goods.Note= textBoxNote.Text;
            goods.PriceUnit=double.Parse(textBoxPriceUnit.Text.Trim());
            goods.Quantity= int.Parse(textBoxQuantity.Text);
            goods.Unit= textBoxUnit.Text;
            setValueContractForm(textBoxPricePreTax.Text, goods);
            this.Close();
        }
    }
}
