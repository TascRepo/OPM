using OPM.OPMEnginee;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class KHGH_PO : Form
    {
        public KHGH_PO()
        {
            InitializeComponent();
        }
        private void KHGH_PO_Load(object sender, EventArgs e)
        {
            dataKHGH.DataSource = POInfo.dtkhgh;
            mpo.Text = POInfo.IPPO;
            vbxn.Text = POInfo.IDVBXN;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POObj po = new POObj();
            int returnValue = 0;
            if (po.CheckListDelivery_PO(vbxn.Text))
            {
                po.DeleteDelivery_PO(vbxn.Text);
            }
            for (int i = 0; i < dataKHGH.Rows.Count - 1; i++)
            {
                returnValue = po.InsertImportFileKHGH(vbxn.Text, dataKHGH.Rows[i].Cells[1].Value.ToString(), dataKHGH.Rows[i].Cells[2].Value.ToString(), dataKHGH.Rows[i].Cells[3].Value.ToString(), dataKHGH.Rows[i].Cells[4].Value.ToString(), mpo.Text);
            }
            if (returnValue == 1)
            {
                MessageBox.Show("Lưu trữ thông tin file phân bổ thành công");
            }
            else
            {
                MessageBox.Show("Lưu trữ thông tin file phân bổ thất bại");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataKHGH_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dataKHGH.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dataKHGH.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dataKHGH_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dataKHGH.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dataKHGH.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }
    }
}
