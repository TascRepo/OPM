using OPM.DBHandler;
using System;
using System.Data;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class FormDPWarranty : Form
    {
        public FormDPWarranty()
        {
            InitializeComponent();
        }

        private void FormDPWarranty_Load(object sender, EventArgs e)
        {
            ///Hiển thị danh sách các tỉnh thành ở datagriview
            txtIdDP.Text = DeliverPartInforDetail.tsDP;
            maPO.Text = DeliverPartInforDetail.tsPO;
            Provinces pr = new Provinces();
            string querySQLProvinces = pr.querySQLProvinces();
            DataTable dtProvince = OPMDBHandler.ExecuteQuery(querySQLProvinces);
            if (dtProvince.Rows.Count > 0)
            {
                dataGridViewWarranty.DataSource = dtProvince;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DP dp = new DP();
            for (int i = 0; i < dataGridViewWarranty.Rows.Count - 1; i++)
            {
                bool isCellChecked = (bool)dataGridViewWarranty.Rows[i].Cells[0].Value;
                if (dataGridViewWarranty.Rows[i].Cells[1].Value.ToString() != "" && isCellChecked == true)
                {
                    if (dp.Check_ListExpected_DP(dataGridViewWarranty.Rows[i].Cells[3].Value.ToString(), txtIdDP.Text, textBox1.Text, maPO.Text))
                    {
                        dp.UpdateListExpected_DP(dataGridViewWarranty.Rows[i].Cells[3].Value.ToString(), dataGridViewWarranty.Rows[i].Cells[1].Value.ToString(), textBox1.Text, txtIdDP.Text, maPO.Text);
                    }
                    else
                    {
                        dp.InsertListExpected_DP(dataGridViewWarranty.Rows[i].Cells[3].Value.ToString(), dataGridViewWarranty.Rows[i].Cells[1].Value.ToString(), textBox1.Text, txtIdDP.Text, maPO.Text);
                    }
                }
            }
            MessageBox.Show("Xử lý các thông tin hàng 2% bảo hành thuộc DP: "+txtIdDP.Text+" thành công!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
