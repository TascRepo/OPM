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
    public partial class PLCreatDocInfo : Form
    {
        public string PLId;
        public PLCreatDocInfo()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PL_" + PLId;
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp18_PLGoodsDeliveryRecord.Checked == true)
            {
                OpmWordHandler.Temp18_PLGoodsDeliveryRecord(PLId);
            }
            if (checkBoxTemp19_PLQualityInspectionCertificateInFactory.Checked == true)
            {
                OpmWordHandler.Temp19_PLQualityInspectionCertificateInFactory(PLId);
            }
            if (checkBoxTemp20_PLQualityInspectionCertificate.Checked == true)
            {
                OpmWordHandler.Temp20_PLQualityInspectionCertificate(PLId);
            }
            if (checkBoxTemp22_PLWarranty.Checked == true)
            {
                OpmWordHandler.Temp22_PLWarranty(PLId);
            }
            if (checkBoxTemp27_PLReportForDelivery.Checked == true)
            {
                OpmExcelHandler.Temp27_PLReportForDelivery(PLId);
            }
        }
    }
}
