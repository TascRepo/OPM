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
    public partial class NTKTCreatDocInfo : Form
    {
        public string NTKTId;
        public NTKTCreatDocInfo()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "NTKT_" + NTKTId;
        }

        private void btnCreatDocument_Click(object sender, EventArgs e)
        {
            if (checkBoxTemp08_NTKTRequest.Checked == true)
            {
                OpmWordHandler.Temp08_NTKTRequest(NTKTId);
            }
            if (checkBoxTemp09_NTKTBBKTKT.Checked == true)
            {
                OpmWordHandler.Temp09_NTKTBBKTKT(NTKTId);
            }
            if (checkBoxTemp10_NTKTCNBQPM.Checked == true)
            {
                OpmWordHandler.Temp10_NTKTCNBQPM(NTKTId);
            }
            if (checkBoxTemp11_NTKTBBNTKT.Checked == true)
            {
                OpmWordHandler.Temp11_NTKTBBNTKT(NTKTId);
            }
        }
    }
}
