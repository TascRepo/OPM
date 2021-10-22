﻿using OPM.DBHandler;
using OPM.ExcelHandler;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DP dP = new DP();
            if (dP.Check_Serial(txtIdDP.Text, maPO.Text))
            {
                dP.Delete_Serial(txtIdDP.Text, maPO.Text);
            }
            for (int i = 0; i < 10; i = i + 2)
            {
                if (dataGridView1.Rows[1].Cells[i + 1].Value.ToString() != "")
                {
                    for (int j = 1; j < dataGridView1.Rows.Count - 1; j++)
                    {
                        dP.InsertListPhuLucSerial(dataGridView1.Rows[j].Cells[i + 1].Value.ToString(), txtIdDP.Text, maPO.Text);
                    }
                }
            }
            MessageBox.Show("Xử lý file phụ lục Serial đính kèm thành công!");
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
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
    }
}
