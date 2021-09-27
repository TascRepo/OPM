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

        public PurchaseOderInfor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*Check PO in DB*/
            int ret = 0;
            /*Save The Edited Contract Info */
            PO newPO = new PO();
            newPO.IDContract = txbIDContract.Text ;
            newPO.IDPO = txbPOCode.Text;
            newPO.PONumber = txbPOName.Text;
            newPO.NumberOfDevice = float.Parse(txbNumberDevice.Text);
            newPO.DateCreatedPO = TimePickerDateCreatedPO.Value.ToString("yyyy-MM-dd");
            newPO.DurationConfirmPO = TimePickerDateConfirmPO.Value.ToString("yyyy-MM-dd");
            newPO.DefaultActiveDatePO = TimepickerDefaultActive.Value.ToString("yyyy-MM-dd");
            newPO.DeadLinePO = TimePickerDeadLinePO.Value.ToString("yyyy-MM-dd");
            newPO.TotalValuePO = float.Parse(txbValuePO.Text);

            /*Create Folder Contract on F Disk*/
            string strContractDirectory = txbIDContract.Text.Replace('/', '_');
            strContractDirectory = strContractDirectory.Replace('-', '_');
            string strPODirectory = "F:\\OPM\\" + strContractDirectory + "\\" + txbPOName.Text;

            ret = newPO.GetDetailPO(txbPOCode.Text);
            if (0 == ret)
            {
                if (!Directory.Exists(strPODirectory))
                {
                    Directory.CreateDirectory(strPODirectory);
                    MessageBox.Show("Folder have been created!!!");
                }

                else
                {
                    MessageBox.Show("Folder already exist!!!");

                }
                
                ret = newPO.InsertNewPO(newPO);
                if (0 == ret)
                {
                    MessageBox.Show(ConstantVar.CreateNewPOFail);
                }
                else
                {
                    MessageBox.Show(ConstantVar.CreateNewPOSuccess);
                    UpdateCatalogPanel(txbPOName.Text);
                    /*Create Bao Lanh Thuc Hien Hop Dong*/
                    string fileBLTUPO_temp = @"F:\LP\BLPO_Template.docx";
                    string strBLTUPOName = strPODirectory + "\\De nghi Bao lanh thuc hien & tam ung PO MSTT.docx";
                    /*truy Suất thông tin của Contract*/
                    ContractObj contractObj = new ContractObj();
                    ContractObj.GetObjectContract(txbIDContract.Text, ref contractObj);
                    this.Cursor = Cursors.WaitCursor;
                    OpmWordHandler.Create_BLTU_PO(fileBLTUPO_temp, strBLTUPOName, txbPOName.Text, txbIDContract.Text, contractObj.NameContract, contractObj.DateSigned, TimePickerDateCreatedPO.Value.ToString("yyyy-MM-dd"),txbValuePO.Text, txbTUPO.Text, contractObj.SiteB, TimepickerDefaultActive.Value.ToString("yyyy-MM-dd"));
                    /*Send Email To DF*/

                    OPMEmailHandler.fSendEmail("Mail From DoanTD Gmail", strBLTUPOName);
                    this.Cursor = Cursors.Default;
                }

                /*Create Bao Lanh Thuc Hien Hop Dong*/
                //string filename = @"F:\LP\MSTT_Template.docx";
                //string strBLHPName = strContractDirectory + "\\Bao_Lanh_Hop_Dong.docx";

                //OpmWordHandler.CreateBLTH_Contract(filename, strBLHPName, tbContract.Text, tbBidName.Text, tbxDateSigned.Text, tbxSiteB.Text, txbGaranteeValue.Text, txbGaranteeActiveDate.Text);

                /*Send Email To DF*/
                //OPMEmailHandler.fSendEmail("Mail From DoanTD Gmail", strBLHPName);

                //UpdateCatalogPanel(txbPOCode.Text);
            }
            //đọc file excel--Dưỡng
            List<ListExpPO> listExpPOs = new List<ListExpPO>();
            if(txbnamefilePO.Text!= null)
            {
                int retEx = OpmExcelHandler.fReadExcelFilePO(txbnamefilePO.Text,txbPOCode.Text,ref listExpPOs);
                if(retEx == 1){
                    ListExpPO listExpPO = new ListExpPO();
                    int retInsert = listExpPO.InsertMultiListPO(listExpPOs);
                    if(retInsert == 1)
                    {

                        MessageBox.Show("thông tin trong File PO đã lưu thành công");
                    }
                    else
                    {
                        MessageBox.Show("thông tin trong File PO không lưu được");
                    }
                }
                else
                {
                    MessageBox.Show("Đọc file không thành công");
                }

            }
            else
            {
                MessageBox.Show("chưa import file PO");
            }
            
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
