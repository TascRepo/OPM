using OPM.OPMEnginee;
using System;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class Contract_Goods_Form : Form
    {
        public delegate void SetValueContractForm(string vl);
        public SetValueContractForm setValueContractForm;
        public Contract_Goods_Form()
        {
            InitializeComponent();
        }
        void AddGoodsBinding()
        {
            tbxName.DataBindings.Clear();
            tbxCode.DataBindings.Clear();
            tbxOrigin.DataBindings.Clear();
            tbxManufacturer.DataBindings.Clear();
            textBoxUnit.DataBindings.Clear();
            textBoxPriceUnit.DataBindings.Clear();
            textBoxQuantity.DataBindings.Clear();
            textBoxPricePreTax.DataBindings.Clear();
            textBoxNote.DataBindings.Clear();
            textBoxLicense.DataBindings.Clear();
            textBoxName1.DataBindings.Clear();
            tbxName.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Name"));
            tbxCode.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Code"));
            tbxOrigin.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Origin"));
            tbxManufacturer.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Manufacturer"));
            textBoxUnit.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Unit"));
            textBoxPriceUnit.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "PriceUnit"));
            textBoxQuantity.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Quantity"));
            textBoxPricePreTax.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "PricePreTax"));
            textBoxNote.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Note"));
            textBoxLicense.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "License"));
            textBoxName1.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "License"));
        }
        void LoadDataGridView()
        {
            dtgvGoods.DataSource = Contract_Goods.GetListByIdContract(Tag.ToString());
            dtgvGoods.Columns["Name"].HeaderText = "Mô tả";
            dtgvGoods.Columns["Origin"].HeaderText = "Xuất xứ";
            dtgvGoods.Columns["Origin"].Visible = false;
            dtgvGoods.Columns["Manufacturer"].HeaderText = "Nhà sản xuất";
            dtgvGoods.Columns["Manufacturer"].Visible = false;
            dtgvGoods.Columns["Code"].HeaderText = "Mã hàng";
            dtgvGoods.Columns["Code"].Width = 250;
            dtgvGoods.Columns["PriceUnit"].HeaderText = "Đơn giá";
            dtgvGoods.Columns["License"].HeaderText = "License";
            dtgvGoods.Columns["License"].Visible = false;
            dtgvGoods.Columns["Name1"].HeaderText = "Tên hàng";
            dtgvGoods.Columns["Name1"].Visible = false;
            //dtgvGoods.Columns["PriceUnit"].Width = 120;
            dtgvGoods.Columns["Quantity"].HeaderText = "Số lượng";
            //dtgvGoods.Columns["Quantity"].Width = 120;
            dtgvGoods.Columns["PricePreTax"].HeaderText = "Thành tiền";
            //dtgvGoods.Columns["PricePreTax"].Width = 120;
            dtgvGoods.Columns["Note"].HeaderText = "Ghi chú";
            dtgvGoods.Columns["Note"].Visible = false;
            dtgvGoods.Columns["IdContract"].Visible = false;
            dtgvGoods.Columns["Unit"].Visible = false;
            dtgvGoods.Columns["Tax"].Visible = false;
            dtgvGoods.Columns["PriceAfterTax"].Visible = false;
            textBoxTotalPricePreTax.Text = Contract_Goods.TotalPricePreTax(Tag.ToString()).ToString();
            //textBoxTotalTax.Text = (double.Parse(textBoxTotalPricePreTax.Text) / 10).ToString();
            textBoxTotalTax.Text = (double.Parse(textBoxTotalPricePreTax.Text) / 10).ToString();
            textBoxTotalPriceAfterTax.Text = (double.Parse(textBoxTotalPricePreTax.Text) + double.Parse(textBoxTotalTax.Text)).ToString();
            AddGoodsBinding();
            //dtgvGoods.RowTemplate.Height = 40;
        }
        private void Contract_Goods_Form_Load(object sender, EventArgs e)
        {
            if (Tag == null) return;
            if (!Contract.Exist(Tag.ToString()))
            {
                MessageBox.Show("Cần tạo hợp đồng trước khi nhập phụ lục hợp đồng!");
                this.Close();
            }
            LoadDataGridView();
            labelQuantity.Text = string.Format(@"Số lượng ({0})", textBoxUnit.Text.Trim());
        }

        private void btnGoodsAdd_Click(object sender, EventArgs e)
        {
            Contract_Goods goods = new Contract_Goods(Tag.ToString(), tbxName.Text.Trim(), tbxOrigin.Text.Trim(), tbxManufacturer.Text.Trim(), tbxCode.Text.Trim(), textBoxUnit.Text.Trim(), double.Parse(textBoxPriceUnit.Text.Trim()), int.Parse(textBoxQuantity.Text.Trim()),textBoxNote.Text.Trim(),textBoxLicense.Text.Trim(), textBoxName1.Text.Trim());
            if (goods.Exist()) goods.Update();
            else
            {
                goods.Insert();
                LoadDataGridView();
            }
        }

        private void btnGoodsDelete_Click(object sender, EventArgs e)
        {
            if (!Contract_Goods.Exist(Tag.ToString()))
            {
                MessageBox.Show("Nhập đúng tên hàng hoá!");
                return;
            }
            Contract_Goods.Delete(Tag.ToString());
            LoadDataGridView();
        }

        private void textBoxPriceUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxPricePreTax.Text = (double.Parse(textBoxPriceUnit.Text.Trim()) * int.Parse(textBoxQuantity.Text.Trim())).ToString();
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
                textBoxPricePreTax.Text = (double.Parse(textBoxPriceUnit.Text.Trim()) * int.Parse(textBoxQuantity.Text.Trim())).ToString();
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

        private void textBoxTotalPricePreTax_TextChanged(object sender, EventArgs e)
        {
            setValueContractForm(textBoxTotalPricePreTax.Text);
        }
    }
}
