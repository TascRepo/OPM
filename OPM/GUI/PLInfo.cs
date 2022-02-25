using OPM.OPMEnginee;
using System;
using System.Windows.Forms;

namespace OPM.GUI
{

    public partial class PLInfo : Form
    {
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;
        public PLInfo()
        {
            InitializeComponent();
        }
        private void PLInfo_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            txtPLId.Text = (Tag as OPMDASHBOARDA).Pl.PLId;
            txtVNPTId.Text = (Tag as OPMDASHBOARDA).Pl.VNPTId;
            txtPLQuantity.Text = (Tag as OPMDASHBOARDA).Pl.PLQuantity.ToString();
            txtCaseQuantity.Text = (Tag as OPMDASHBOARDA).Pl.CaseQuantity.ToString();
            dateTimePickerPLDate.Value = (Tag as OPMDASHBOARDA).Pl.PLDate;
            txtPLDimension.Text = (Tag as OPMDASHBOARDA).Pl.PLDimension;
            txtPLVolume.Text = (Tag as OPMDASHBOARDA).Pl.PLVolume.ToString();
            txtPLNetWeight.Text = (Tag as OPMDASHBOARDA).Pl.PLNetWeight.ToString();
            txtPLGrossWeight.Text = (Tag as OPMDASHBOARDA).Pl.PLGrossWeight.ToString();
            LoadToDtgPL();
        }

        private void LoadToDtgPL()
        {
            
        }

        private void btnNewPL_Click(object sender, System.EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PL_" + (new PLObj()).PLId;
        }

        private void txtPLId_TextChanged(object sender, System.EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = txtPLId.Text.Trim();
            if (DPObj.DPExist(txtPLId.Text.Trim()))
            {
                if (("PL_" + txtPLId.Text.Trim()) != (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại PL số " + txtPLId.Text.Trim());
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Pl.PLId = txtPLId.Text.Trim();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenDPForm();
        }

        private void btnDeletePL_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }

        private void btnSavePL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPLId.Text.Trim()) || txtPLId.Text.Trim() == (new PLObj()).PLId)
            {
                MessageBox.Show("Nhập đúng số LPId!");
                return;
            }
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }

        private void dateTimePickerPLDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Pl.PLDate = dateTimePickerPLDate.Value;
        }

        private void txtPLDimension_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Pl.PLDimension = txtPLDimension.Text;
        }

        private void txtPLVolume_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPLVolume.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Pl.PLVolume = double.Parse(txtPLVolume.Text.Trim());
                }
                else
                    (Tag as OPMDASHBOARDA).Pl.PLVolume = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại PLVolume dạng số!");
            }
        }

        private void txtPLNetWeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPLVolume.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Pl.PLNetWeight = double.Parse(txtPLNetWeight.Text.Trim());
                }
                else
                    (Tag as OPMDASHBOARDA).Pl.PLNetWeight = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại PLNetWeight dạng số!");
            }
        }

        private void txtPLGrossWeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPLGrossWeight.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Pl.PLGrossWeight = double.Parse(txtPLGrossWeight.Text.Trim());
                }
                else
                    (Tag as OPMDASHBOARDA).Pl.PLGrossWeight = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại PLNetWeight dạng số!");
            }
        }
    }
}
