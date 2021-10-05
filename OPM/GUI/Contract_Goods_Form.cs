using OPM.OPMEnginee;
using System;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class Contract_Goods_Form : Form
    {
        public Contract_Goods_Form()
        {
            InitializeComponent();
        }
        void AddGoodsBinding()
        {
            //tbxName.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource,Name ));
            //tbxFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Tên"));
            //tbxFoodCategory.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Danh mục"));
            //nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Giá (nghìn)"));
        }
        void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            //dtpkFromDate.Value = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            //dtpkToDate.Value = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(1);
        }
        private void BtnViewBill_Click(object sender, System.EventArgs e)
        {
        }

        private void BtnFoodView_Click(object sender, EventArgs e)
        {
        }

        private void Contract_Goods_Form_Load(object sender, EventArgs e)
        {
            if (Tag == null) return;
            if (!Contract.Exist(Tag.ToString()))
            {
                MessageBox.Show("Cần tạo hợp đồng trước khi nhập phụ lục hợp đồng!");
                this.Close();
            }
            dtgvGoods.DataSource = Contract_Goods.GetListByIdContract(Tag.ToString());
            tbxName.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Name"));
            tbxCode.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Code"));
            textBoxUnit.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Unit"));
            textBoxPriceUnit.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "PriceUnit"));
            textBoxQuantity.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Quantity"));
            textBoxPricePreTax.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "PricePreTax"));
        }
    }
}
