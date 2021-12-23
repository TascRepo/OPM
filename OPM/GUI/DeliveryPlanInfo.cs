using OPM.DBHandler;
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
            LoadData();
        }
        void LoadData()
        {
            LoadToDtgDeliveryPlan();
            LoadToComboBoxProvinceId();
            DataBindingsFromDtgDeliveryPlanToTextBoxs();
        }

        private void DataBindingsFromDtgDeliveryPlanToTextBoxs()
        {
            //List<DeliveryPlanObj> deliveryPlans = DeliveryPlanObj.DeliveryPlanGetList((Tag as OPMDASHBOARDA).Po.POId);
            //dtgDeliveryPlan.DataSource = deliveryPlans;
            //dtgDeliveryPlan.Columns["ProvinceId"].HeaderText = "Mã tỉnh";
        }

        private void LoadToComboBoxProvinceId()
        {
            
        }

        private void LoadToDtgDeliveryPlan()
        {
            
        }

    }
}
