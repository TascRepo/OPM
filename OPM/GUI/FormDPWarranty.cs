using OPM.DBHandler;
using System;
using System.Data;
using System.Windows.Forms;

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
