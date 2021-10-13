using OPM.DBHandler;
using OPM.WordHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class DeliverPartInforDetail : Form
    {
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;
        public static string tsDP = "";
        public static string tsPO = "";
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
            if (txbIdDP.Text == "DPXXX/202X")
            {
                MessageBox.Show("Nhập sai định dạng số DP!");
            }
            else
            {
                DP dp = new DP();
                //Thêm mới 1 DP vào database
                int returnDP = dp.InsertUpdateDP(txbIdDP.Text.Trim().Replace('/', '-'), txbPOCode.Text, txbIDContract.Text, cbbType.Text, ghiChu.Text, dtpRequest.Text, dtpOutCap.Text);
                if (returnDP == 0)
                {
                    MessageBox.Show("Cập nhật DP " + txbIdDP.Text + " thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm mới DP " + txbIdDP.Text + " thành công!");
                }
                //Them danh sach cac hang chinh vao ListExpect_DP
                for (int i = 0; i < dataGridViewProvince.Rows.Count - 1; i++)
                {
                    bool isCellChecked = (bool)dataGridViewProvince.Rows[i].Cells[0].Value;
                    if (dataGridViewProvince.Rows[i].Cells[1].Value.ToString() != "" && isCellChecked == true)
                    {
                        if (dp.Check_ListExpected_DP(dataGridViewProvince.Rows[i].Cells[3].Value.ToString(), txbIdDP.Text, cbbType.Text, txbPOCode.Text))
                        {
                            dp.UpdateListExpected_DP(dataGridViewProvince.Rows[i].Cells[3].Value.ToString(), dataGridViewProvince.Rows[i].Cells[1].Value.ToString(), cbbType.Text, txbIdDP.Text, txbPOCode.Text);
                        }
                        else
                        {
                            dp.InsertListExpected_DP(dataGridViewProvince.Rows[i].Cells[3].Value.ToString(), dataGridViewProvince.Rows[i].Cells[1].Value.ToString(), cbbType.Text, txbIdDP.Text, txbPOCode.Text);
                        }
                    }
                }
                MessageBox.Show("Xử lý các thông tin hàng chinh thuộc DP: " + txbIdDP.Text + " thành công vao CSDL!");
                //Xử lý các mẫu 18,19,20,21,22,23
                for (int i = 0; i < dataGridViewProvince.Rows.Count - 1; i++)
                {
                    bool isCellChecked = (bool)dataGridViewProvince.Rows[i].Cells[0].Value;
                    if (dataGridViewProvince.Rows[i].Cells[1].Value.ToString() != "" && isCellChecked == true)
                    {
                        //Xuất mẫu 18
                        OpmWordHandler.Word_GiaoNhanHangHoa(txbKHMS.Text, txbIDContract.Text, txbPOCode.Text, txbPOName.Text, dataGridViewProvince.Rows[i].Cells[3].Value.ToString(), dtpRequest.Text, txbIdDP.Text, dtpOutCap.Text, mahangHD.Text, tenhangHD.Text, dataGridViewProvince.Rows[i].Cells[1].Value.ToString());
                        //Xuất mẫu 19
                        OpmWordHandler.Word_DPCNKTCL(txbIDContract.Text, txbPOName.Text, txbIdDP.Text, dataGridViewProvince.Rows[i].Cells[3].Value.ToString(), mahangHD.Text, tenhangHD.Text, maHangSP.Text, tenHangSP.Text, dataGridViewProvince.Rows[i].Cells[1].Value.ToString(), ghiChu.Text, dtpOutCap.Text);
                        //Xuất mẫu 20
                        OpmWordHandler.Word_DPCNCL(txbIDContract.Text, txbPOName.Text, txbPOCode.Text, txbIdDP.Text, dataGridViewProvince.Rows[i].Cells[3].Value.ToString(), mahangHD.Text, tenhangHD.Text, maHangSP.Text, tenHangSP.Text, dataGridViewProvince.Rows[i].Cells[1].Value.ToString(), ghiChu.Text, dtpOutCap.Text);
                        //Xuất mẫu 22
                        OpmWordHandler.Word_PBH(txbIDContract.Text, txbPOName.Text, txbPOCode.Text, txbIdDP.Text, dataGridViewProvince.Rows[i].Cells[3].Value.ToString(), mahangHD.Text, tenhangHD.Text, maHangSP.Text, tenHangSP.Text, dataGridViewProvince.Rows[i].Cells[1].Value.ToString(), ghiChu.Text);
                        //Xuất mẫu 21
                        OpmWordHandler.Word_PhuLucSerial(txbIDContract.Text, txbPOCode.Text, txbPOName.Text, txbIdDP.Text, dataGridViewProvince.Rows[i].Cells[3].Value.ToString());
                    }
                }
                MessageBox.Show("Tạo mẫu 18,19,20,21,22 đi các tỉnh thành công!");
                //
            }
        }
        private void DeliverPartInforDetail_Load(object sender, EventArgs e)
        {
            //Load thông tin combobox
            DP dp1 = new DP();
            DataTable d1 = dp1.SqlContract_Goods(txbIDContract.Text);
            for (int i = 0; i < d1.Rows.Count; i++)
            {
                tenhangHD.Items.Add(d1.Rows[i][0].ToString());
            }
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "Hàng chính");
            cbbType.DataSource = new BindingSource(comboSource, null);
            cbbType.DisplayMember = "Value";
            cbbType.ValueMember = "Key";
            ///Hiển thị danh sách các tỉnh thành ở datagriview
            Provinces pr = new Provinces();
            string querySQLProvinces = pr.querySQLProvinces();
            DataTable dtProvince = OPMDBHandler.ExecuteQuery(querySQLProvinces);
            if (dtProvince.Rows.Count > 0)
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

        private void mahangHD_TextChanged(object sender, EventArgs e)
        {
        }

        private void tenhangHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //find giá trị code theo tên
            DP dp1 = new DP();
            DataTable dtResult = new DataTable();
            dtResult = dp1.GetCodeByContract(txbIDContract.Text, tenhangHD.Text);
            if (dtResult.Rows.Count > 0)
            {
                mahangHD.Text = dtResult.Rows[0][0].ToString();
            }
            else
            {
                mahangHD.Text = "";
            }
            //
        }

        private void xoaDP_Click(object sender, EventArgs e)
        {
            DP dp2 = new DP();
            dp2.DeleteDP(txbIdDP.Text);
            MessageBox.Show("Xóa DP thành công!");
        }

        private void hangPhu_CheckedChanged(object sender, EventArgs e)
        {
            if (txbIdDP.Text == "DPXXX/202X")
            {
                MessageBox.Show("Nhập sai định dạng số DP!");
            }
            else
            {
                tsDP = txbIdDP.Text;
                tsPO = txbPOCode.Text;
                if (hangPhu.Checked == true)
                {
                    FormDPWarranty frm2 = new FormDPWarranty();
                    frm2.Activate();
                    frm2.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txbIdDP.Text == "DPXXX/202X")
            {
                MessageBox.Show("Nhập sai định dạng số DP!");
            }
            else
            {
                tsDP = txbIdDP.Text;
                tsPO = txbPOCode.Text;
                PhuLucSerial frm2 = new PhuLucSerial();
                frm2.Activate();
                frm2.Show();
            }
        }
    }
}
