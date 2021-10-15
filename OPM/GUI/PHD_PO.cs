﻿using System;
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
            DataTable dataTable = new DataTable();
            IPHD_PO iPHD_PO = new IPHD_PO();
            string tsDP = DeliverPartInforDetail.tsDP;
            string tsPO = DeliverPartInforDetail.tsPO;
            //load thông tin lên datagrview
            if(iPHD_PO.Check(tsDP, tsPO))
            {
                dataTable = iPHD_PO.GetInforDP(tsDP, tsPO, "Hàng chính");
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("DP mày chưa có thông tin trong CSDL!");
            }
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public OpenFileDialog openFileExcel = new OpenFileDialog();
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IPHD_PO iPHD_PO = new IPHD_PO();
            int index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            //Lấy giá trị Rows vừa Click vào
            string valueprovince = row.Cells[0].Value.ToString();
            string valueid_dp = row.Cells[1].Value.ToString();
            string valueid_po = row.Cells[2].Value.ToString();
            string valuetype = row.Cells[3].Value.ToString();
            DataTable data = new DataTable();
            data = iPHD_PO.GetInforDP_PO_Contract(valueprovince, valueid_dp, valueid_po, valuetype);
            //Set các giá trị vào Textbox
            txbmaHD.Text = data.Rows[0][0].ToString();
            txbtenHD.Text = data.Rows[0][1].ToString();
            txbmaPO.Text = data.Rows[0][2].ToString();
            txbsoPO.Text = data.Rows[0][3].ToString();
            txbsoDP.Text = data.Rows[0][4].ToString();
            txbtenHang.Text = data.Rows[0][5].ToString();
            txbmaHang.Text = data.Rows[0][6].ToString();
            txbprovincename.Text = data.Rows[0][7].ToString();
            //dtpycbd.Text = data.Rows[0][8].ToString();
            //dtpthbd.Text = data.Rows[0][8].ToString();
        }
    }
}
