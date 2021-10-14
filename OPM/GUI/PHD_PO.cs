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
using System.IO;
namespace OPM.GUI
{
    public partial class PHD_PO : Form
    {
        public PHD_PO()
        {
            InitializeComponent();
        }
        private void PHD_PO_Load(object sender, EventArgs e)
        {
            txbsoHopDong.Text = PurchaseOderInfor.maHD;
            txbmaPO.Text = PurchaseOderInfor.maPO;
            txbsoPO.Text = PurchaseOderInfor.tenPO;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public OpenFileDialog openFileExcel = new OpenFileDialog();
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileExcel.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileExcel.FileName))
                {
                    txbnamefilePO.Text = openFileExcel.FileName;
                    string filename = openFileExcel.FileName;
                    DataTable dt = new DataTable();
                    int ret = OpmExcelHandler.fReadExcelDeNghiHD(filename, ref dt);
                    if (ret == 1)
                    {
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Import thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Import Không thành công!");
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
