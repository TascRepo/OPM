using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPM.DBHandler;
using OPM.ExcelHandler;
using OPM.OPMEnginee;
using OPM.WordHandler;
namespace OPM.GUI
{
    public partial class PBPO : Form
    {
        public PBPO()
        {
            InitializeComponent();
        }

        private void PBPO_Load(object sender, EventArgs e)
        {
            dataPBDKPO.DataSource = PurchaseOderInfor.pbpo;
            mpo.Text = PurchaseOderInfor.IPPO;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PO_Thanh po = new PO_Thanh();
            PO pO = new PO();
            int returnValue = 0;
            //Lấy tên thiết bị COntract theo PO
            string NameContract = "";
            NameContract = pO.GetNameContractByPOId(mpo.Text);
            //
            if (po.CheckListExpected_PO(mpo.Text))
            {
                pO.DeleteListExpected_PO(mpo.Text);
            }
            for (int i = 0; i < dataPBDKPO.Rows.Count - 1; i++)
            {
                returnValue = po.InsertImportFilePO(po.Id, dataPBDKPO.Rows[i].Cells[1].Value.ToString(), dataPBDKPO.Rows[i].Cells[2].Value.ToString(), NameContract);
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

        private void dataPBDKPO_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dataPBDKPO.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dataPBDKPO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dataPBDKPO_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dataPBDKPO.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dataPBDKPO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }
    }
}
