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
            try
            {
                po.Numberofdevice = double.Parse(txbNumberDevice.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng sô thiết bị!");
                return;
            }
            po.Dateconfirm = TimePickerDateConfirmPO.Value;
            po.Dateperform = TimepickerDefaultActive.Value;
            po.Dateline = TimePickerDeadLinePO.Value;
            try
            {
                po.Totalvalue = double.Parse(txbValuePO.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng Tổng giá trị hợp đồng");
                return;
            }
            if (po.Totalvalue < 0)
            {
                MessageBox.Show("Nhập lại dạng Tổng giá trị hợp >= 0");
                return;
            }
            try
            {
                po.Tupo = int.Parse(tbxTupo.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số TUPO!");
                return;
            }
            if (po.Tupo < 0|| po.Tupo>100)
            {
                MessageBox.Show("Nhập lại 0 <= Tạm ứng PO <= 100");
                return;
            }
            po.Id_contract = txbIDContract.Text;
            po.Confirmpo_datecreated=confirmpo_datecreated.Value;
            po.Confirmpo_number = confirmpo_number.Text;
            po.Tupo_datecreated=tupo_datecreated.Value;
            try
            {
                po.Bltupo = int.Parse(bltupo.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng sô BLTUPO!");
                return;
            }
            if (po.Bltupo < 0 || po.Bltupo > 100)
            {
                MessageBox.Show("Nhập lại 0 <= Bảo lãnh tạm ứng PO <= 100");
                return;
            }
            po.Bltupo_datecreated=bltupo_datecreated.Value;
            po.Confirmpo_dateactive = confirmpo_dateactive.Value;
            if (Contract.Exist(txbIDContract.Text.Trim())) 
            {
                po.InsertOrUpdate();
                OpmWordHandler.Temp3_CreatPOConfirm(po.Id);
            }
            else MessageBox.Show(string.Format("Không tồn tại hợp đồng {0}", txbIDContract.Text));
            UpdateCatalogPanel(txbIDContract.Text);
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
                    tbxTupo.Text = po.Tupo.ToString();
                    confirmpo_datecreated.Value = po.Confirmpo_datecreated;
                    confirmpo_number.Text = po.Confirmpo_number.ToString();
                    tupo_datecreated.Value = po.Tupo_datecreated;
                    bltupo.Text = po.Bltupo.ToString();
                    bltupo_datecreated.Value = po.Bltupo_datecreated;
                    confirmpo_dateactive.Value = po.Confirmpo_dateactive;
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

        private void txbDurationConfirm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TimePickerDateConfirmPO.Value = TimePickerDateCreatedPO.Value.AddDays(int.Parse(txbDurationConfirm.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }

        private void TimePickerDateCreatedPO_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TimePickerDateConfirmPO.Value = TimePickerDateCreatedPO.Value.AddDays(int.Parse(txbDurationConfirm.Text));
                TimepickerDefaultActive.Value = TimePickerDateCreatedPO.Value.AddDays(int.Parse(txbActiveAfter.Text));
                TimePickerDeadLinePO.Value = TimePickerDateCreatedPO.Value.AddDays(int.Parse(txbDeadLine.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số!");
            }

        }

        private void txbActiveAfter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TimepickerDefaultActive.Value = TimePickerDateCreatedPO.Value.AddDays(int.Parse(txbActiveAfter.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số!");
            }

        }

        private void txbDeadLine_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TimePickerDeadLinePO.Value = TimePickerDateCreatedPO.Value.AddDays(int.Parse(txbDeadLine.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số!");
            }

        }
    }
}
