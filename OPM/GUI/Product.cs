using OPM.DBHandler;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            Products products = new Products();
            DataTable dataTable = products.GetListProduct();
            dtgProduct.DataSource = dataTable;
            //Load comboBox
            DataTable cbb = products.GetListmaHang();
            for (int i = 0; i < cbb.Rows.Count; i++)
            {
                mH.Items.Add(cbb.Rows[i][0].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //find giá trị code theo tên
            Products products = new Products();
            DataTable dataTable = products.GetListProduct();
            if (dataTable.Rows.Count > 0)
            {
                tH.Text = dataTable.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra lại Hàng, có thể đã bị xóa!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            //Thêm mới 1 DP vào database
            int IdContract_Goods = products.GetId(mH.Text);
            if (IdContract_Goods != 0)
            {
                int returnDP = products.InsertUpdateProducts(IdContract_Goods, mSP.Text, tSP.Text);
                if (returnDP == 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm mới sản phẩm thành công!");
                }
            }
            else
            {
                MessageBox.Show("Mã hàng không tồn tại trong CSDL!");
            }
            DataTable dataTable = products.GetListProduct();
            dtgProduct.DataSource = dataTable;
        }

        private void dtgProduct_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgProduct.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dtgProduct.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dtgProduct_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgProduct.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dtgProduct.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void dtgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Products products = new Products();
            int index = e.RowIndex;
            DataGridViewRow row = dtgProduct.Rows[index];
            //Lấy giá trị Rows vừa Click vào
            mH.Text = row.Cells[1].Value.ToString();
            tH.Text = row.Cells[2].Value.ToString();
            mSP.Text = row.Cells[3].Value.ToString();
            tSP.Text = row.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            int resuilt = products.DeleteProduct(mSP.Text);
            if (resuilt == 1)
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa không thành công!");
            }
        }
    }
}
