using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class DPInfo : Form
    {
        public DPInfo()
        {
            InitializeComponent();
        }
        void LoadData(string VNPTId = "ANSV")
        {
            (Tag as OPMDASHBOARDA).Dp.POId = (Tag as OPMDASHBOARDA).Po.POId;
            (Tag as OPMDASHBOARDA).DPs.DPId = (Tag as OPMDASHBOARDA).Dp.DPId;
            (Tag as OPMDASHBOARDA).DPs.POId = (Tag as OPMDASHBOARDA).Po.POId;
            (Tag as OPMDASHBOARDA).DPss = DPsObj.DPsGetListByDPId((Tag as OPMDASHBOARDA).Dp.DPId);
            LoadToDtgDP(VNPTId);
            DataBindingsFromDtgDPToTextBoxs();
            LoadToComboBoxVNPIId();
            if((Tag as OPMDASHBOARDA).Dp.DPType == 0)
            {
                txtContractGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity.ToString();
                txtRemainingContractGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId((Tag as OPMDASHBOARDA).Po.ContractId)).ToString();
                txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.POGoodsQuantity.ToString();
                txtRemainingPOGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.POGoodsQuantity - DPsObj.DPTotalQuantityByPOId((Tag as OPMDASHBOARDA).Po.POId)).ToString();
                textBoxVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text).ToString();
                txtRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text) - DPsObj.DPTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text)).ToString();
            }
            else
            {
                txtContractGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.ContractSpareGoodsQuantity.ToString();
                txtRemainingContractGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.ContractSpareGoodsQuantity - POObj.POSpareGoodsQuantityTotalByContractId((Tag as OPMDASHBOARDA).Po.ContractId)).ToString();
                txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.POSpareGoodsQuantity.ToString();
                txtRemainingPOGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.POSpareGoodsQuantity - DPsObj.DPTotalQuantityByPOId((Tag as OPMDASHBOARDA).Po.POId,1)).ToString();
                textBoxVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text).ToString();
                txtRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text) - DPsObj.DPTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text, 1)).ToString();
            }
        }
        private void LoadToDtgDP(string VNPTId = "ANSV")
        {
            if ((Tag as OPMDASHBOARDA).DPss.Count == 0)
            {
                (Tag as OPMDASHBOARDA).DPss.Insert(0, (Tag as OPMDASHBOARDA).DPs);
            }
            dtgDP.DataSource = (Tag as OPMDASHBOARDA).DPss;
            dtgDP.Columns["DPsId"].HeaderText = @"ID";
            dtgDP.Columns["DPsId"].Visible = false;
            dtgDP.Columns["DPId"].Visible = false;
            dtgDP.Columns["VNPTId"].HeaderText = @"Mã tỉnh";
            dtgDP.Columns["DPQuantity"].HeaderText = @"Số lượng";
            foreach (DataGridViewRow row in dtgDP.Rows)
            {
                if (row.Cells["VNPTId"].Value.ToString() == VNPTId)
                {
                    dtgDP.CurrentCell = row.Cells["VNPTId"];
                    return;
                }
            }
        }

        private void DataBindingsFromDtgDPToTextBoxs()
        {
            //txtContractGoodsQuantity.DataBindings.Clear();
            //txtContractGoodsQuantity.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "ContractGoodsQuantity"));
            //txtPOGoodsQuantity.DataBindings.Clear();
            //txtPOGoodsQuantity.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "POGoodsQuantity"));
            textBoxDPId.DataBindings.Clear();
            textBoxDPId.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPId"));
            dateTimePickerDPDate.DataBindings.Clear();
            dateTimePickerDPDate.DataBindings.Add(new Binding("Value", dtgDP.DataSource, "DPDate"));
            textBoxDPRemarks.DataBindings.Clear();
            textBoxDPRemarks.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPRemarks"));
            comboBoxDPType.DataBindings.Clear();
            comboBoxDPType.DataBindings.Add(new Binding("SelectedIndex", dtgDP.DataSource, "DPType"));
            txtVNPTId.DataBindings.Clear();
            txtVNPTId.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "VNPTId"));
            textBoxDPsId.DataBindings.Clear();
            textBoxDPsId.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPsId"));
            txtDPQuantity.DataBindings.Clear();
            txtDPQuantity.DataBindings.Add(new Binding("Text", dtgDP.DataSource, "DPQuantity"));
        }

        private void LoadToComboBoxVNPIId()
        {
            (Tag as OPMDASHBOARDA).Sites = SiteObj.SiteGetListProvince((Tag as OPMDASHBOARDA).Po.POId, textBoxDPId.Text.Trim());
            comboBoxVNPTId.DataSource = (Tag as OPMDASHBOARDA).Sites;
            comboBoxVNPTId.DisplayMember = "SiteId";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenPOForm();
        }

        private void DPInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBoxDPNumber_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = textBoxDPId.Text.Trim();
            if (DPObj.DPExist(textBoxDPId.Text.Trim()))
            {
                if (("DP_" + textBoxDPId.Text.Trim()) != (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại DP số " + textBoxDPId.Text.Trim());
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Dp.DPId = textBoxDPId.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDPId.Text.Trim()) || textBoxDPId.Text.Trim() == (new POObj()).POId)
            {
                MessageBox.Show("Nhập đúng số DP!");
                return;
            }
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }

        private void dateTimePickerDPDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPDate = dateTimePickerDPDate.Value;
        }

        private void btnNewDP_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "DP_" + (new DPObj()).DPId;
        }

        private void btnDeleteDP_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }

        private void btnDPsAdd_Click(object sender, EventArgs e)
        {
            DPsObj dPs = new DPsObj()
            {
                DPId = textBoxDPId.Text.Trim(),
                VNPTId = (comboBoxVNPTId.SelectedItem as SiteObj).SiteId,
                DPQuantity = double.Parse(textBoxDPQuantity.Text.Trim()),
            };
            dPs.DPsInsert();
            //txtRemainingPOGoodsQuantity.Text = (deliveryPlan.POGoodsQuantity - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(deliveryPlan.POId)).ToString();
            LoadData(dPs.VNPTId);
        }

        private void btnDPsDelete_Click(object sender, EventArgs e)
        {
            DPsObj.DPsDelete(int.Parse(textBoxDPsId.Text.Trim()));
            LoadData(txtVNPTId.Text.Trim());
        }

        private void txtVNPTId_TextChanged(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Dp.DPType == 0)
            {
                textBoxVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text).ToString();
                txtRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text) - DPsObj.DPTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text)).ToString();
            }
            else
            {
                textBoxVNPTIdTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text).ToString();
                txtRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text) - DPsObj.DPTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, txtVNPTId.Text, 1)).ToString();
            }
        }

        private void comboBoxVNPTId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Dp.DPType == 0)
            {
                textBoxRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - DPsObj.DPTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
            }
            else
            {
                textBoxRemainingVNPTTotalQuantity.Text = (DeliveryPlanObj.DeliveryPlanTotalSpareQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId) - DPsObj.DPTotalQuantityByPOIdAndVNPTIdDetail((Tag as OPMDASHBOARDA).Po.POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId, 1)).ToString();
            }
        }

        private void textBoxDPRemarks_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPRemarks = textBoxDPRemarks.Text;
        }

        private void comboBoxDPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPType = comboBoxDPType.SelectedIndex;
        }
    }
}
