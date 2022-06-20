using OPM.ExcelHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class DPCreatDocInfo : Form
    {
        public string DPId;
        public DPCreatDocInfo()
        {
            InitializeComponent();
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp12_DPCreatedbyOPM.Checked == true)
            {
                OpmExcelHandler.Temp12_DPCreatedbyOPM(DPId);
            }
            if (checkBoxTemp13_DPExportRequestForm_ANSV.Checked == true)
            {
                OpmExcelHandler.Temp13_DPExportRequestForm_ANSV(DPId);
            }
            if (checkBoxTemp14_DPCreatedbyANSV.Checked == true)
            {
                OpmExcelHandler.Temp14_DPCreatedbyANSV(DPId);
            }
            if (checkBoxTemp16_DPExportRequestForm_VNPTTech.Checked == true)
            {
                OpmExcelHandler.Temp16_DPExportRequestForm_VNPTTech(DPId);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "DP_" + DPId;
        }
    }
}
