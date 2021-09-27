using OPM.EmailHandler;
using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OPM.ExcelHandler;
using System.Data.OleDb;
using System.Data.Common;
using OPM.DBHandler;

namespace OPM.GUI
{
    public partial class PurchaseOderInfor : Form
    {
        /*Delegate Request Dashboard Update Catalog Admin*/
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;

        /*Delegate Request Dashboard Open NTKT form*/
        public delegate void RequestDashBoardOpenNTKTForm(string strIDContract, string strKHMS, string strPONumber, string strPOID);
        public RequestDashBoardOpenNTKTForm requestDashBoardOpenNTKTForm;

        /*Delegate Request Dashboard Open Confirm form*/
        public delegate void RequestDashBoardOpenConfirmForm(string strIDContract, string strKHMS, string strPONumber, string strPOID);
        public RequestDashBoardOpenConfirmForm requestDashBoardOpenConfirmPOForm;

        public delegate void RequestDashBoardPurchaseOderForm(string strIDPO, string strKHMS);
        public RequestDashBoardPurchaseOderForm requestDashBoardPurchaseOderForm;

        //open excel handle
        public delegate void RequestDasckboardOpenExcel();
        public RequestDasckboardOpenExcel requestDasckboardOpenExcel;

        //open new DP
        public delegate void RequestDaskboardOpenDP(string idpo, string idcontract);
        public RequestDaskboardOpenDP requestDaskboardOpenDP;

        //Khai báo POCurrent
        public Contract contract;
        public PO_Thanh po;

        public PurchaseOderInfor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PO_Thanh po = new PO_Thanh();
            po.Id = txbPOCode.Text;
            po.Po_number = txbPOName.Text;
            po.Datecreated = TimePickerDateCreatedPO.Value;
            po.Numberofdevice = double.Parse(txbNumberDevice.Text);
            po.Dateconfirm = TimePickerDateConfirmPO.Value;
            po.Dateperform = TimepickerDefaultActive.Value;
            po.Dateline = TimePickerDeadLinePO.Value;
            po.Totalvalue = double.Parse(txbValuePO.Text);
            po.Tupo = int.Parse(txbTUPO.Text);
            po.Id_contract = txbIDContract.Text;
            if (Contract.Exist(txbIDContract.Text.Trim())) po.InsertOrUpdate();
            else MessageBox.Show(string.Format("Không tồn tại hợp đồng {0}", txbIDContract.Text));
            UpdateCatalogPanel("");
        }

        public void SetValueItemForPO(string idPO)
        {
            PO pO = new PO();
            string namecontract = null, KHMS= null;
            pO.DisplayPO(idPO,ref namecontract,ref KHMS);
            pO.GetDisplayPO(idPO, ref pO);
            this.txbKHMS.Text = KHMS;
            
            this.txbIDContract.Text = pO.IdContract;
            this.txbPOCode.Text = pO.IDPO;
            this.txbPOName.Text = pO.PONumber;
            TimePickerDateCreatedPO.Value = Convert.ToDateTime(pO.DateCreatedPO);
            this.txbNumberDevice.Text = pO.NumberOfDevice.ToString();
            TimePickerDateConfirmPO.Value = Convert.ToDateTime(pO.DurationConfirmPO);
            TimepickerDefaultActive.Value = Convert.ToDateTime(pO.DefaultActiveDatePO);
            TimePickerDeadLinePO.Value = Convert.ToDateTime(pO.DeadLinePO);
            this.txbValuePO.Text = pO.TotalValuePO.ToString();
            return;

        }

        public void SetTxbIDContract(string strIDContract)
        {
            this.txbIDContract.Text = strIDContract;
        }
        public void SetTxbKHMS(string strKHMS)
        {
            this.txbKHMS.Text = strKHMS;
        }
        private void btnNTKT_Click(object sender, EventArgs e)
        {
            /*Request DashBoard Open NTKT Form*/
            string strContract = "Contract_" + txbIDContract.Text.ToString();
            /*Request DashBoard Open PO Form*/
            requestDashBoardOpenNTKTForm(txbKHMS.Text,strContract,txbPOCode.Text, txbPOName.Text) ;
            return;

        }
        private void btnBaoHiem_Click(object sender, EventArgs e)
        {

        }

        private void btnNewDP_Click(object sender, EventArgs e)
        {
            requestDaskboardOpenDP(txbPOCode.Text, txbIDContract.Text);
        }

        private void btnConfirmPO_Click(object sender, EventArgs e)
        {
            /*Request DashBoard Open Confirm PO Form*/
            string strContract = "Contract_" + txbIDContract.Text.ToString();
            /*Request DashBoard Open PO Form*/
            requestDashBoardOpenConfirmPOForm(txbKHMS.Text, strContract, txbPOCode.Text, txbPOName.Text);
            return;
        }

        private void btnKTKT_Click(object sender, EventArgs e)
        {
            string strContractDirectory = txbIDContract.Text.Replace('/', '_');
            strContractDirectory = strContractDirectory.Replace('-', '_');
            string strPODirectory = @"F:\\OPM\\" + strContractDirectory + "\\" + txbPOName.Text;

            /*Create Bao Lanh Thuc Hien Hop Dong*/
            int ret = 0;
            string fileBBKTKTHH_temp = @"F:\LP\Bien_Ban_KTKT_HH_Template.docx";
            string strBBKTKT = strPODirectory + "\\Biên Bản Kiểm Tra Kỹ Thuật_" + txbPOName.Text + "_" + txbIDContract.Text + ".docx";
            strBBKTKT = strBBKTKT.Replace("/", "_");
            ContractObj contractObj = new ContractObj();
            ret = ContractObj.GetObjectContract(txbIDContract.Text, ref contractObj);
            PO pO = new PO();
            ret = PO.GetObjectPO(txbPOCode.Text, ref pO);
            NTKT nTKT = new NTKT();
            nTKT.GetObjectNTKTByIDPO(txbPOCode.Text, ref nTKT);
            SiteInfo siteInfoB = new SiteInfo();
            SiteInfo siteInfoA = new SiteInfo();
            siteInfoB.GetSiteInfoObject(txbIDContract.Text, ref siteInfoB);
            siteInfoA.GetSiteInfoA(txbIDContract.Text, ref siteInfoA);
            this.Cursor = Cursors.WaitCursor;
            OpmWordHandler.Create_BBKTKT_HH(fileBBKTKTHH_temp,strBBKTKT, contractObj, pO, nTKT,siteInfoB,siteInfoA);
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            requestDasckboardOpenExcel();
        }

        private void PurchaseOderInfor_Load(object sender, EventArgs e)
        {
            txbnamefilePO.ReadOnly = true;
            txbKHMS.Enabled = false;
            if (contract != null)
            {
                txbKHMS.Text = contract.KHMS;
                txbIDContract.Text = contract.Id;
                txbIDContract.Enabled = false;
                if (po != null)
                {
                    txbPOCode.Text = po.Id;
                    txbPOName.Text = po.Po_number;
                    TimePickerDateCreatedPO.Value = po.Datecreated;
                    txbNumberDevice.Text = po.Numberofdevice.ToString();
                    TimePickerDateConfirmPO.Value = po.Dateconfirm;
                    TimepickerDefaultActive.Value = po.Dateperform;
                    TimePickerDeadLinePO.Value = po.Dateline;
                    txbValuePO.Text = po.Totalvalue.ToString();
                    txbTUPO.Text = po.Tupo.ToString();
                }
            }
        }
        public OpenFileDialog openFileExcel = new OpenFileDialog();
        public string sConnectionString= null;
        private void importPO_Click(object sender, EventArgs e)
        {
           // openFileExcel.Multiselect = true;
             openFileExcel.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            if (openFileExcel.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileExcel.FileName))
                {
                    txbnamefilePO.Text = openFileExcel.FileName;
                    string filename = openFileExcel.FileName;
                    DataTable dt = new DataTable();
                    int ret = OpmExcelHandler.fReadExcelFilePO2(filename, ref dt);
                    if(ret==1)
                    {
                        dataGridViewPO.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("đọc lỗi");
                    }
                }
               
            }
        }    
    }
}
