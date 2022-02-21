using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class DPInfo : Form
    {
        //public List<SiteObj> sites = SiteObj.SiteGetListProvince();
        //List<DeliveryPlanObj> dPs;
        //public DeliveryPlanObj dP;
        //public string POId;
        //public POObj Po;
        //public ContractObj Contract;
        public DPInfo()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            txtContractGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity.ToString();
            txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.POGoodsQuantity.ToString();
            txtRemainingContractGoodsQuantity.Text = ((Tag as OPMDASHBOARDA).Po.ContractGoodsQuantity - POObj.POGoodsQuantityTotalByContractId((Tag as OPMDASHBOARDA).Po.ContractId)).ToString();
            textBoxDPNumber.Text = (Tag as OPMDASHBOARDA).Dp.DPId;
            //LoadToDtgDeliveryPlan(POId);
            //LoadToComboBoxProvince();
            //DataBindingsFromDtgDeliveryPlanToTextBoxs(POId);
            //if (DeliveryPlanObj.DeliveryPlanExist(POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId))
            //{
            //    textBoxDeliveryPlanTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTId(POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId).ToString();
            //}
            //else
            //{
            //    textBoxDeliveryPlanTotalQuantity.Text = "0";
            //}
            //textBoxRemainingDeliveryPlanQuantity.Text = (double.Parse(textBoxDeliveryPlanTotalQuantity.Text.Trim()) - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
        }

        private void DataBindingsFromDtgDeliveryPlanToTextBoxs(string POId)
        {
            //textBoxDPId.DataBindings.Clear();
            //textBoxDPId.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanId"));
            //textBoxVNPTId.DataBindings.Clear();
            //textBoxVNPTId.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "VNPTId"));
            //textBoxDeliveryPlanTotalQuantity.DataBindings.Clear();
            //textBoxDeliveryPlanTotalQuantity.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanTotalQuantity"));
            //textBoxDeliveryPlanQuantity.DataBindings.Clear();
            //textBoxDeliveryPlanQuantity.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity"));
            //dateTimePickerDeliveryPlanDate.DataBindings.Clear();
            //dateTimePickerDeliveryPlanDate.DataBindings.Add(new Binding("Value", dtgDeliveryPlan.DataSource, "DeliveryPlanDate"));
        }

        private void LoadToComboBoxProvince()
        {
            //comboBoxVNPTId.DataSource = sites;
            //comboBoxVNPTId.DisplayMember = "SiteId";
        }

        private void LoadToDtgDP(string POId)
        {
            //deliveryPlans = DeliveryPlanObj.DeliveryPlanGetList(POId);
            //if (deliveryPlans.Count == 0)
            //{
            //    deliveryPlan = new DeliveryPlanObj();
            //    deliveryPlans.Insert(0, deliveryPlan);
            //}
            //dtgDeliveryPlan.DataSource = deliveryPlans;
            //dtgDeliveryPlan.Columns["DeliveryPlanId"].HeaderText = @"ID";
            //dtgDeliveryPlan.Columns["POId"].Visible = false;
            //dtgDeliveryPlan.Columns["VNPTId"].HeaderText = @"Mã tỉnh";
            //dtgDeliveryPlan.Columns["DeliveryPlanTotalQuantity"].HeaderText = @"Tổng số";
            //dtgDeliveryPlan.Columns["DeliveryPlanTotalQuantity"].Visible = false;
            //dtgDeliveryPlan.Columns["DeliveryPlanQuantity"].HeaderText = @"Số lượng";
            //dtgDeliveryPlan.Columns["DeliveryPlanDate"].HeaderText = @"Ngày";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MessageBox.Show((Tag as OPMDASHBOARDA).Po.POId);
            (Tag as OPMDASHBOARDA).OpenPOForm();
        }

        private void comboBoxVNPTId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox comboBox = sender as ComboBox;
            //if (comboBox.SelectedItem == null) return;
            //SiteObj selected = comboBox.SelectedItem as SiteObj;
            //deliveryPlan.VNPTId = selected.SiteId;
            //if (DeliveryPlanObj.DeliveryPlanExist(POId, selected.SiteId))
            //{
            //    textBoxDeliveryPlanTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTId(POId, selected.SiteId).ToString();
            //}
            //else
            //{
            //    textBoxDeliveryPlanTotalQuantity.Text = "0";
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //deliveryPlan.POId = POId;
            //deliveryPlan.VNPTId = (comboBoxVNPTId.SelectedItem as SiteObj).SiteId;
            //deliveryPlan.DeliveryPlanTotalQuantity = double.Parse(textBoxDeliveryPlanTotalQuantity.Text.Trim());
            //deliveryPlan.DeliveryPlanQuantity = double.Parse(textBoxDPQuantity.Text.Trim());
            //deliveryPlan.DeliveryPlanDate = dateTimePickerDeliveryPlanDate.Value;
            //deliveryPlan.DeliveryPlanInsert();
            //txtRemainingPOGoodsQuantity.Text = (Po.POGoodsQuantity - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(POId)).ToString();
            //deliveryPlan.DeliveryPlanTotalQuantityUpdate();
            //LoadData(POId);
        }

        private void textBoxDPTotalQuantity_TextChanged(object sender, EventArgs e)
        {
            //deliveryPlan.DeliveryPlanTotalQuantity = double.Parse(textBoxDeliveryPlanTotalQuantity.Text.Trim());
            //deliveryPlan.DeliveryPlanTotalQuantityUpdate();
            //txtRemainingPOGoodsQuantity.Text = (Po.POGoodsQuantity - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(POId)).ToString();
            //textBoxRemainingDeliveryPlanQuantity.Text = (double.Parse(textBoxDeliveryPlanTotalQuantity.Text.Trim()) - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
        }

        private void textBoxVNPTId_TextChanged(object sender, EventArgs e)
        {
            //textBoxDeliveryPlanTotalQuantity.Text = DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTId(POId, comboBoxVNPTId.Text.Trim()).ToString();
        }


        private void txtPOGoodsQuantity_TextChanged(object sender, EventArgs e)
        {
            //txtRemainingPOGoodsQuantity.Text = (Po.POGoodsQuantity - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(POId)).ToString();
        }

        private void textBoxDPQuantity_TextChanged(object sender, EventArgs e)
        {
            //deliveryPlan.DeliveryPlanQuantity = double.Parse(textBoxDPQuantity.Text.Trim());
            //textBoxRemainingDeliveryPlanQuantity.Text = (double.Parse(textBoxDeliveryPlanTotalQuantity.Text.Trim()) - DeliveryPlanObj.DeliveryPlanTotalQuantityByPOIdAndVNPTIdDetail(POId, (comboBoxVNPTId.SelectedItem as SiteObj).SiteId)).ToString();
        }

        private void dateTimePickerDPDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Dp.DPDate = dateTimePickerDPDate.Value;
        }

        private void DPInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
