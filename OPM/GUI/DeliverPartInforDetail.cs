using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPM.OPMEnginee;
using System.IO;

namespace OPM.GUI
{
    public partial class DeliverPartInforDetail : Form
    {
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;
        
        public DeliverPartInforDetail()
        {
            InitializeComponent();
        }
        public void setKHMS(string value)
        {
            txbKHMS.Text = value;
            return;
        }
        public void setIdcontract(string value)
        {
            txbIDContract.Text = value;
            return;
        }
        public void setIdPO(string value)
        {
            txbPOCode.Text = value;
            return;
        }
        public void setPoname(string value)
        {
            txbPOName.Text = value;
            return;
        }
        public void setIDpd(string value)
        {
            txbIdDP.Text = value;
            return;
        }
        
        private void txbPurpose_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DP dP = new DP();
            dP.Id = txbIdDP.Text;
            dP.IdContract = txbIDContract.Text;
            dP.IdPO = txbPOCode.Text;
            dP.MaKT = txbAccountance.Text;
            dP.DateDeliver = dtpRequest.Value.ToString("yyyy-MM-dd");
            dP.DateOpen = dtpOutCap.Value.ToString("yyyy-MM-dd");
            dP.Type = cbbType.Text;
            dP.Note = txbPurpose.Text;
            int ret = DP.InsertDP(dP);
            if (ret == 1)
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lưu không thành công");
            }
            string strContractDirectory = dP.IdContract.Replace('/', '_');
            strContractDirectory = strContractDirectory.Replace('-', '_');
            string strfileDP = "F:\\OPM\\" + strContractDirectory + "\\" + txbPOName.Text;
            SiteInfo siteInfo = new SiteInfo();
            siteInfo.GetSiteInfoObject(dP.IdContract, ref siteInfo);
            if (1 == ret)
            {
                
            int retex= OPM.ExcelHandler.OpmExcelHandler.FindAndReplace(@"F:\LP\DP-template1.xlsx", strfileDP, dP.Id, dP.IdContract, siteInfo.Id, dP.DateDeliver, dP.DateOpen, siteInfo.HeadquaterInfo, dP.Note, dP.MaKT,txbNumber.Text);
            if(retex == 0)
            {
                MessageBox.Show("file excel create false");
            }
            else
            {
                MessageBox.Show("file excel created ");
            }
            }
            else
            {
                MessageBox.Show("lưu không thành công");
            }
        }

        private void DeliverPartInforDetail_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "chính");
            comboSource.Add(2, "bảo hành");
            cbbType.DataSource = new BindingSource(comboSource, null);
            cbbType.DisplayMember = "Value";
            cbbType.ValueMember = "Key";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
