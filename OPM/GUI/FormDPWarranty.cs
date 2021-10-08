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
    public partial class FormDPWarranty : Form
    {
        public FormDPWarranty()
        {
            InitializeComponent();
        }

        private void FormDPWarranty_Load(object sender, EventArgs e)
        {
            ///Hiển thị danh sách các tỉnh thành ở datagriview
            txtIdDP.Text = DeliverPartInforDetail.tsDP;
            Provinces pr = new Provinces();
            string querySQLProvinces = pr.querySQLProvinces();
            DataTable dtProvince = OPMDBHandler.ExecuteQuery(querySQLProvinces);
            if (dtProvince.Rows.Count > 0)
            {
                dataGridViewWarranty.DataSource = dtProvince;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
