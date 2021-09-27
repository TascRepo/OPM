using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPM.ExcelHandler;
using OPM.OPMEnginee;

namespace OPM.GUI
{
    public partial class HandlerExcel : Form
    {
        public delegate void RequestDasckboardOpenExcel();
        public RequestDasckboardOpenExcel requestDasckboardOpenExcel; 
        public HandlerExcel()
        {
            InitializeComponent();
        }

        public OpenFileDialog openFileExcel = new OpenFileDialog();
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            openFileExcel.Multiselect = true;
           // openFileExcel.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            if (openFileExcel.ShowDialog() == DialogResult.OK)
            {
                foreach(string fileName in openFileExcel.FileNames)
                {
                    textBox1.Text += fileName +","; 
                }
            }

        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] strFile = textBox1.Text.Trim().Split(",");
            foreach(string strFileExcel in strFile)
            {
                OpmExcelHandler.fReadExcelFile(strFileExcel);

            }
            
        }

    }
}
