using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPM.OPMEnginee;
using System.IO;
using OPM.WordHandler;
using OPM.ExcelHandler;
using OPM.DBHandler;
namespace OPM.GUI
{
    public partial class DeliverPartInforDetail : Form
    {
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;
        
        public DeliverPartInforDetail()
        {
            InitializeComponent();
        }
        public void setKHMS(string value)
        {
            txbKHMS.Text = value;
            return;
        }
        public void setIdcontract(string value)
        {
            txbIDContract.Text = value;
            return;
        }
        public void setIdPO(string value)
        {
            txbPOCode.Text = value;
            return;
        }
        public void setPoname(string value)
        {
            txbPOName.Text = value;
            return;
        }
        public void setIDpd(string value)
        {
            txbIdDP.Text = value;
            return;
        }
        private void txbPurpose_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DP dp = new DP();
            //Thêm mới 1 DP vào database
            int returnDP = dp.InsertUpdateDP(txbIdDP.Text, txbPOCode.Text, txbIDContract.Text, cbbType.Text,ghiChu.Text);
            if(returnDP == 0)
            {
                MessageBox.Show("Cập nhật DP "+ txbIdDP.Text+" thành công!");
            }
            else
            {
                MessageBox.Show("Thêm mới DP " + txbIdDP.Text + " thành công!");
            }
            //Lưu trữ thông tin vào database với các tỉnh và file phân bổ
            for (int i = 0; i < dataGridViewProvince.Rows.Count - 1; i++)
            {
                bool IsCheck = Convert.ToBoolean(dataGridViewProvince.Rows[i].Cells[0].Value);
                if (IsCheck == true && dataGridViewProvince.Rows[i].Cells[0].ToString().Length > 0)
                {
                    dp.InsertListExpected_DP(dataGridViewProvince.Rows[i].Cells[2].Value.ToString(), dataGridViewProvince.Rows[i].Cells[1].Value.ToString(), txbIdDP.Text.ToString());
                    //Xuất mẫu 19
                    OpmWordHandler.Word_DPCNKTCL(txbIDContract.Text, txbPOName.Text, txbIdDP.Text, dataGridViewProvince.Rows[i].Cells[2].Value.ToString(), mahangHD.Text, tenhangHD.Text, maHangSP.Text, tenHangSP.Text, dataGridViewProvince.Rows[i].Cells[1].Value.ToString(), ghiChu.Text);
                    //Xuất mẫu 20
                    OpmWordHandler.Word_DPCNCL(txbIDContract.Text, txbPOName.Text, txbPOCode.Text, txbIdDP.Text, dataGridViewProvince.Rows[i].Cells[2].Value.ToString(), mahangHD.Text, tenhangHD.Text, maHangSP.Text, tenHangSP.Text, dataGridViewProvince.Rows[i].Cells[1].Value.ToString(), ghiChu.Text);
                }
            }
            MessageBox.Show("Tạo mẫu 19,20 đi các tỉnh thành công!");
        }
        private void DeliverPartInforDetail_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "Hàng chính");
            comboSource.Add(2, "Hàng bảo hành");
            cbbType.DataSource = new BindingSource(comboSource, null);
            cbbType.DisplayMember = "Value";
            cbbType.ValueMember = "Key";
            ///Hiển thị danh sách các tỉnh thành ở datagriview
            Provinces pr = new Provinces();
            string querySQLProvinces = pr.querySQLProvinces();
            DataTable dtProvince = OPMDBHandler.ExecuteQuery(querySQLProvinces);
            if(dtProvince.Rows.Count > 0)
            {
                dataGridViewProvince.DataSource = dtProvince;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewProvince_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
        }
    }
}
