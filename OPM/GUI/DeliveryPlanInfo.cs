using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class DeliveryPlanInfo : Form
    {
        public DeliveryPlanInfo()
        {
            InitializeComponent();
        }
        void LoadData(string VNPTId = "ANSV")
        {
            (Tag as OPMDASHBOARDA).DeliveryPlans = DeliveryPlanObj.DeliveryPlanGetList((Tag as OPMDASHBOARDA).Po.POId);
            txtRemainingContractGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId((Tag as OPMDASHBOARDA).Po.ContractId)).ToString();
            txtRemainingPOGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.POGoodsQuantity - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOId((Tag as OPMDASHBOARDA).Po.POId)).ToString();
            LoadToDtgDeliveryPlan(VNPTId);
            LoadToComboBoxProvince();
            DataBindingsFromDtgDeliveryPlanToTextBoxs();
        }

        private void DataBindingsFromDtgDeliveryPlanToTextBoxs()
        {
            txtContractGoodsQuantity.DataBindings.Clear();
            txtContractGoodsQuantity.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "ContractGoodsQuantity"));
            txtPOGoodsQuantity.DataBindings.Clear();
            txtPOGoodsQuantity.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "POGoodsQuantity"));
            txtDeliveryPlanId.DataBindings.Clear();
            txtDeliveryPlanId.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanId"));
            txtVNPTId.DataBindings.Clear();
            txtVNPTId.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "VNPTId"));
            txtDeliveryPlanQuantity.DataBindings.Clear();
            txtDeliveryPlanQuantity.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity"));
            dtpDeliveryPlanDate.DataBindings.Clear();
            dtpDeliveryPlanDate.DataBindings.Add(new Binding("Value", dtgDeliveryPlan.DataSource, "DeliveryPlanDate"));
        }

        private void LoadToComboBoxProvince()
        {
            (Tag as OPMDASHBOARDA).Sites = SiteObj.SiteGetListProvince();
            comboBoxVNPTId.DataSource = (Tag as OPMDASHBOARDA).Sites;
            comboBoxVNPTId.DisplayMember = "SiteId";
        }

        private void LoadToDtgDeliveryPlan(string VNPTId = "ANSV")
        {
            if ((Tag as OPMDASHBOARDA).DeliveryPlans.Count == 0)
            {
                (Tag as OPMDASHBOARDA).DeliveryPlans.Insert(0, (Tag as OPMDASHBOARDA).DeliveryPlan);
            }
            dtgDeliveryPlan.DataSource = (Tag as OPMDASHBOARDA).DeliveryPlans;
            dtgDeliveryPlan.Columns["DeliveryPlanId"].HeaderText = @"ID";
            dtgDeliveryPlan.Columns["DeliveryPlanId"].Visible = false;
            dtgDeliveryPlan.Columns["POId"].Visible = false;
            dtgDeliveryPlan.Columns["VNPTId"].HeaderText = @"Mã tỉnh";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity"].HeaderText = @"Số lượng";
            dtgDeliveryPlan.Columns["DeliveryPlanDate"].HeaderText = @"Ngày";
            foreach (DataGridViewRow row in dtgDeliveryPlan.Rows)
            {
                if(row.Cells["VNPTId"].Value.ToString() == VNPTId)
                {
                    dtgDeliveryPlan.CurrentCell = row.Cells["VNPTId"];
                    return;
                }
            }
        }

        private void buttonAddProvinceId_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenSiteAForm((new SiteObj()).SiteId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (txtRemainingPOGoodsQuantity.Text == "0")
            {
                (Tag as OPMDASHBOARDA).OpenPOForm();
            }
            else
            {
                if (DialogResult.No == MessageBox.Show("! Vẫn chưa phân bổ hết PO", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) return;
            }
        }

        private void comboBoxVNPTId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem == null) return;
            SiteObj selected = comboBox.SelectedItem as SiteObj;
            (Tag as OPMDASHBOARDA).DeliveryPlan.VNPTId = selected.SiteId;
            if (DeliveryPlanObj.DeliveryPlanExist((Tag as OPMDASHBOARDA).DeliveryPlan.POId, selected.SiteId))
            {
                //textBoxRemainingDeliveryPlanQuantity.Text = (double.Parse(textBoxDeliveryPlanTotalQuantity.Text.Trim()) - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).DeliveryPlan.POId, selected.SiteId)).ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DeliveryPlanObj deliveryPlan = new DeliveryPlanObj
            {
                POId = (Tag as OPMDASHBOARDA).Po.POId,
                VNPTId = (comboBoxVNPTId.SelectedItem as SiteObj).SiteId,
                DeliveryPlanQuantity = double.Parse(textBoxDeliveryPlanQuantity.Text.Trim()),
                DeliveryPlanDate = dateTimePickerDeliveryPlanDate.Value
            };
            deliveryPlan.DeliveryPlanInsert();
            //txtRemainingPOGoodsQuantity.Text = (deliveryPlan.POGoodsQuantity - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(deliveryPlan.POId)).ToString();
            LoadData(deliveryPlan.VNPTId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeliveryPlanObj.DeliveryPlanDelete(int.Parse(txtDeliveryPlanId.Text.Trim()));
            LoadData(txtVNPTId.Text.Trim());
        }

        private void textBoxDeliveryPlanQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxDeliveryPlanQuantity.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).DeliveryPlan.DeliveryPlanQuantity = double.Parse(textBoxDeliveryPlanQuantity.Text.Trim());
                }
                else
                    (Tag as OPMDASHBOARDA).DeliveryPlan.DeliveryPlanQuantity = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại DeliveryPlanQuantity dạng số!");
            }
        }

        private void dateTimePickerDeliveryPlanDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeliveryPlan.DeliveryPlanDate = dateTimePickerDeliveryPlanDate.Value;
        }

        private void DeliveryPlanInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgDeliveryPlan_SelectionChanged(object sender, EventArgs e)
        {
            //textBoxDeliveryPlanId.Text = dtgDeliveryPlan.SelectedRows[0].Cells["DeliveryPlanId"].ToString();
        }

        private void txtVNPTId_TextChanged(object sender, EventArgs e)
        {
            txtDeliveryPlanVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text.Trim()).ToString();
        }

        private void txtRemainingPOGoodsQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtRemainingPOGoodsQuantity.Text == "0")
            {
                txtRemainingPOGoodsQuantity.ForeColor = Color.Black;
                lblWarning.ForeColor = Color.Black;
                lblWarning.Text = "Đã phân bổ hết PO!";
            }
            else
            {
                txtRemainingPOGoodsQuantity.ForeColor = Color.Red;
                lblWarning.ForeColor = Color.Red;
                lblWarning.Text = "! Vẫn chưa phân bổ hết PO";
            }
        }
    }
}
