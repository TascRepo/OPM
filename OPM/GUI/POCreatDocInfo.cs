using OPM.ExcelHandler;
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
    public partial class POCreatDocInfo : Form
    {
        public string POId;
        public POCreatDocInfo()
        {
            InitializeComponent();
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp3_POConfirm.Checked == true)
            {
                OpmWordHandler.Temp3_POConfirm(POId);
            }
            if (checkBoxTemp4_POPerformanceGuarantee.Checked == true)
            {
                OpmWordHandler.Temp4_POPerformanceGuarantee(POId);
            }
            if (checkBoxTemp5_POAdvanceGuarantee.Checked == true)
            {
                OpmWordHandler.Temp5_POAdvanceGuarantee(POId);
            }
            if (checkBoxTemp6_POAdvanceRequest.Checked == true)
            {
                OpmWordHandler.Temp6_POAdvanceRequest(POId);
            }
            if (checkBoxTemp7_PODistributionTable.Checked == true)
            {
                OpmExcelHandler.Temp7_PODistributionTable(POId);
            }
            if (checkBoxTemp23_POCNCL_TongHop.Checked == true)
            {
                OpmWordHandler.Temp23_POCNCL_TongHop(POId);
            }
            if (checkBoxTemp24_POCNCLNMTongHop.Checked == true)
            {
                OpmWordHandler.Temp24_POCNCLNMTongHop(POId);
            }
            if (checkBoxTemp25_InvoicingRequestPO.Checked == true)
            {
                OpmWordHandler.Temp25_InvoicingRequestPO(POId);
            }
            if (checkBoxTemp26_MinutesConfirmingDeliveryProgressPO.Checked == true)
            {
                OpmWordHandler.Temp26_MinutesConfirmingDeliveryProgressPO(POId);
            }
            if (checkBoxTemp28_POReportOfAcceptanceAndHandlingOfGoods.Checked == true)
            {
                OpmWordHandler.Temp28_POReportOfAcceptanceAndHandlingOfGoods(POId);
            }
            if (checkBoxTemp33_POOfferToGuaranteeWarranty.Checked == true)
            {
                OpmWordHandler.Temp33_POOfferToGuaranteeWarranty(POId);
            }
            if (checkBoxTemp36_POBBNTLicense.Checked == true)
            {
                OpmWordHandler.Temp36_POBBNTLicense(POId);
            }
            if (checkBoxTemp37_POBBXNCDLicense.Checked == true)
            {
                OpmWordHandler.Temp37_POBBXNCDLicense(POId);
            }
            if (checkBoxTemp39_POAdjustmentConfirmation.Checked == true)
            {
                OpmWordHandler.Temp39_POAdjustmentConfirmation(POId);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PO_" + POId;
        }
    }
}
