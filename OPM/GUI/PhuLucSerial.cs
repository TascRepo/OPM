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
    public partial class PhuLucSerial : Form
    {
        public PhuLucSerial()
        {
            InitializeComponent();
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
                    int ret = OpmExcelHandler.fReadExcelPhuLucSerial(filename, ref dt);
                    if (ret == 1)
                    {
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Import thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Import không thành công!");
                    }
                }
            }
        }

        private void PhuLucSerial_Load(object sender, EventArgs e)
        {
            txtIdDP.Text = DeliverPartInforDetail.tsDP;
            maPO.Text = DeliverPartInforDetail.tsPO;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
