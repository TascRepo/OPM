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
    public partial class KHGH_PO : Form
    {
        public KHGH_PO()
        {
            InitializeComponent();
        }
        private void KHGH_PO_Load(object sender, EventArgs e)
        {
            dataKHGH.DataSource = PurchaseOderInfor.dtkhgh;
            mpo.Text = PurchaseOderInfor.IPPO;
            vbxn.Text = PurchaseOderInfor.IDVBXN;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PO_Thanh po = new PO_Thanh();
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
    }
}
