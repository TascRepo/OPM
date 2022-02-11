using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class DeliveryPlanInfo : Form
    {
        public DeliveryPlanInfo()
        {
            InitializeComponent();
        }
        public DeliveryPlanInfo(string POId)
        {
            InitializeComponent();
            LoadData(POId);
        }
        void LoadData(string POId)
        {
            POObj pO = new POObj(POId);
            ContractObj contract = new ContractObj(pO.ContractId);
            txtPOGoodsQuantity.Text = pO.POGoodsQuantity.ToString();
            txtContractGoodsQuantity.Text = contract.ContractGoodsQuantity.ToString();
            LoadToDtgDeliveryPlan(POId);
            LoadToComboBoxProvince();
            DataBindingsFromDtgDeliveryPlanToTextBoxs(POId);
        }

        private void DataBindingsFromDtgDeliveryPlanToTextBoxs(string POId)
        {
            textBoxDeliveryPlanQuantity.DataBindings.Clear();
            textBoxDeliveryPlanQuantity.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity"));
            textBoxDeliveryPlanQuantity1.DataBindings.Clear();
            textBoxDeliveryPlanQuantity1.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity1"));
            //dateTimePickerDeliveryPlanDate1.DataBindings.Clear();
            //dateTimePickerDeliveryPlanDate1.DataBindings.Add(new Binding("Value", dtgDeliveryPlan.DataSource, "DeliveryPlanDate1"));
            textBoxDeliveryPlanQuantity2.DataBindings.Clear();
            textBoxDeliveryPlanQuantity2.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity2"));
            //dateTimePickerDeliveryPlanDate2.DataBindings.Clear();
            //dateTimePickerDeliveryPlanDate2.DataBindings.Add(new Binding("Value", dtgDeliveryPlan.DataSource, "DeliveryPlanDate2"));
            textBoxDeliveryPlanQuantity3.DataBindings.Clear();
            textBoxDeliveryPlanQuantity3.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity3"));
            //dateTimePickerDeliveryPlanDate3.DataBindings.Clear();
            //dateTimePickerDeliveryPlanDate3.DataBindings.Add(new Binding("Value", dtgDeliveryPlan.DataSource, "DeliveryPlanDate3"));
            textBoxDeliveryPlanQuantity4.DataBindings.Clear();
            textBoxDeliveryPlanQuantity4.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity4"));
            //dateTimePickerDeliveryPlanDate4.DataBindings.Clear();
            //dateTimePickerDeliveryPlanDate4.DataBindings.Add(new Binding("Value", dtgDeliveryPlan.DataSource, "DeliveryPlanDate4"));
            textBoxDeliveryPlanQuantity5.DataBindings.Clear();
            textBoxDeliveryPlanQuantity5.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity5"));
            //dateTimePickerDeliveryPlanDate5.DataBindings.Clear();
            //dateTimePickerDeliveryPlanDate5.DataBindings.Add(new Binding("Value", dtgDeliveryPlan.DataSource, "DeliveryPlanDate5"));
            textBoxDeliveryPlanQuantity6.DataBindings.Clear();
            textBoxDeliveryPlanQuantity6.DataBindings.Add(new Binding("Text", dtgDeliveryPlan.DataSource, "DeliveryPlanQuantity6"));
            //dateTimePickerDeliveryPlanDate6.DataBindings.Clear();
            //dateTimePickerDeliveryPlanDate6.DataBindings.Add(new Binding("Value", dtgDeliveryPlan.DataSource, "DeliveryPlanDate6"));
        }

        private void LoadToComboBoxProvince()
        {
            List<SiteObj> sites = SiteObj.SiteGetListProvince();
            comboBoxProvince.DataSource = sites;
            comboBoxProvince.DisplayMember = "SiteProvince";
        }

        private void LoadToDtgDeliveryPlan(string POId)
        {
            List<DeliveryPlanObj> deliveryPlans = DeliveryPlanObj.DeliveryPlanGetList(POId);
            if (deliveryPlans.Count == 0)
            {
                DeliveryPlanObj deliveryPlan = new DeliveryPlanObj();
                deliveryPlans.Insert(0, deliveryPlan);
            }
            dtgDeliveryPlan.DataSource = deliveryPlans;
            dtgDeliveryPlan.Columns["POId"].Visible = false;
            dtgDeliveryPlan.Columns["ProvinceId"].HeaderText = @"Mã tỉnh";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity"].HeaderText = @"Tổng số";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity1"].HeaderText = @"Đợt 1";
            dtgDeliveryPlan.Columns["DeliveryPlanDate1"].HeaderText = @"Ngày 1";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity2"].HeaderText = @"Đợt 2";
            dtgDeliveryPlan.Columns["DeliveryPlanDate2"].HeaderText = @"Ngày 2";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity3"].HeaderText = @"Đợt 3";
            dtgDeliveryPlan.Columns["DeliveryPlanDate3"].HeaderText = @"Ngày 3";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity4"].HeaderText = @"Đợt 4";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity4"].Visible = false;
            dtgDeliveryPlan.Columns["DeliveryPlanDate4"].HeaderText = @"Ngày 4";
            dtgDeliveryPlan.Columns["DeliveryPlanDate4"].Visible = false;
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity5"].HeaderText = @"Đợt 5";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity5"].Visible = false;
            dtgDeliveryPlan.Columns["DeliveryPlanDate5"].HeaderText = @"Ngày 5";
            dtgDeliveryPlan.Columns["DeliveryPlanDate5"].Visible = false;
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity6"].HeaderText = @"Đợt 6";
            dtgDeliveryPlan.Columns["DeliveryPlanQuantity6"].Visible = false;
            dtgDeliveryPlan.Columns["DeliveryPlanDate6"].HeaderText = @"Ngày 6";
            dtgDeliveryPlan.Columns["DeliveryPlanDate6"].Visible = false;
        }

        private void buttonAddProvinceId_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenSiteAForm((new SiteObj()).SiteId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenPOForm();
        }
    }
}
