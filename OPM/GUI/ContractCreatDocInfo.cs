using OPM.OPMWordHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class ContractCreatDocInfo : Form
    {
        public string ContractId;
        public ContractCreatDocInfo()
        {
            InitializeComponent();
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp1_ContractGuarantee.Checked == true)
            {
                OpmWordHandler.Temp1_ContractGuarantee(ContractId);
            }
            if (checkBoxTemp29_ContractReportOfConpletedVolume.Checked == true)
            {
                OpmWordHandler.Temp29_ContractReportOfConpletedVolume(ContractId);
            }
            if (checkBoxTemp30_ContractLiquidationRecords.Checked == true)
            {
                OpmWordHandler.Temp30_ContractLiquidationRecords(ContractId);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "Contract_" + ContractId;
        }

        private void checkBoxTemp30_ContractLiquidationRecords_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxTemp29_ContractReportOfConpletedVolume_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxTemp1_ContractGuarantee_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
