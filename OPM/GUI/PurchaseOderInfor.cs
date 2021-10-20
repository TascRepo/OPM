using OPM.DBHandler;
using OPM.ExcelHandler;
using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class PurchaseOderInfor : Form
    {
        /*Delegate Request Dashboard Update Catalog Admin*/
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;

        /*Delegate Request Dashboard Open NTKT form*/
        public delegate void RequestDashBoardOpenNTKTForm(string strPOID);
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
        public delegate void RequestDaskboardOpenDP(string idpo, string idcontract, string POName);
        public RequestDaskboardOpenDP requestDaskboardOpenDP;

        //Khai báo POCurrent
        public Contract contract;
        public PO_Thanh po;
        //
        public static string maHD = "";
        public static string maPO = "";
        public static string tenPO = "";
        public PurchaseOderInfor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PO_Thanh po = new PO_Thanh();
            Contract contract = new Contract();
            po.Id = txbPOCode.Text.Trim();
            po.Po_number = txbPOName.Text;
            po.Datecreated = TimePickerDateCreatedPO.Value;
            try
            {
                po.Numberofdevice = double.Parse(txbNumberDevice.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số thiết bị!");
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
            if (po.Tupo < 0 || po.Tupo > 100)
            {
                MessageBox.Show("Nhập lại 0 <= Tạm ứng PO <= 100");
                return;
            }
            po.Id_contract = txbIDContract.Text.Trim();
            po.Confirmpo_datecreated = confirmpo_datecreated.Value;
            po.Confirmpo_number = confirmpo_number.Text;
            po.Tupo_datecreated = tupo_datecreated.Value;
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
            po.Bltupo_datecreated = bltupo_datecreated.Value;
            po.Confirmpo_dateactive = confirmpo_dateactive.Value;
            ///////////////////////////////////
            if (Contract.Exist(txbIDContract.Text.Trim()))
            {
                po.InsertOrUpdate();
                //Tạo file xác nhận hợp đồng
                if (txbnamefileKHGH.Text == "")
                {
                    if (po.CheckListDelivery_PO(po.Confirmpo_number))
                    {
                        MessageBox.Show(po.Confirmpo_number + "đã có file giao hàng dự kiến, không cần import thêm!");
                    }
                    else
                    {
                        MessageBox.Show(po.Confirmpo_number + "chưa có trong hệ thống, bạn phải bổ sung sau!");
                    }
                }
                if (txbnamefilePO.Text == "")
                {
                    if (po.CheckListExpected_PO(po.Id))
                    {
                        MessageBox.Show(po.Confirmpo_number + "đã có file giao hàng dự kiến, không cần import thêm!");
                    }
                    else
                    {
                        MessageBox.Show(po.Confirmpo_number + "chưa có trong hệ thống, bạn phải bổ sung sau!");
                    }
                }
                po.InsertOrUpdate_VBConfirmPO(txbPOCode.Text);
                OpmWordHandler.Word_POConfirm(txbKHMS.Text, txbIDContract.Text, txbPOCode.Text, txbPOName.Text, confirmpo_number.Text, TimePickerDateCreatedPO.Text, confirmpo_datecreated.Text, confirmpo_dateactive.Text);
                OpmWordHandler.Word_POBaoLanh(txbKHMS.Text, txbIDContract.Text, txbPOCode.Text, txbPOName.Text, confirmpo_number.Text, TimePickerDateCreatedPO.Text, confirmpo_datecreated.Text, confirmpo_dateactive.Text, txbValuePO.Text, bltupo.Text, txbDurationConfirm.Text);
                OpmWordHandler.Word_POTamUng(txbKHMS.Text, txbIDContract.Text, txbPOCode.Text, txbPOName.Text, confirmpo_number.Text, TimePickerDateCreatedPO.Text, confirmpo_datecreated.Text, confirmpo_dateactive.Text, txbValuePO.Text, bltupo.Text, txbDurationConfirm.Text, svbdntt.Text);
            }
            else
            {
                MessageBox.Show(string.Format("Không tồn tại hợp đồng {0}", txbIDContract.Text));
                return;
            }
            UpdateCatalogPanel("PO_" + po.Id);
            //Tạo các mẫu 23,24,36,37
            OpmWordHandler.Temp23_CNCL_TongHop(po.Id);
            OpmWordHandler.Temp24_CNCLNMTongHop(po.Id);
            OpmWordHandler.Temp36_BBNTLicense(po.Id);
            OpmWordHandler.Temp37_BBXNCDLicense(po.Id);

            this.Cursor = Cursors.Default;
        }
        public void SetValueItemForPO(string idPO)
        {
            PO pO = new PO();
            string namecontract = null, KHMS = null;
            pO.DisplayPO(idPO, ref namecontract, ref KHMS);
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
            requestDashBoardOpenNTKTForm(txbPOCode.Text.Trim());
            return;

        }
        private void btnBaoHiem_Click(object sender, EventArgs e)
        {

        }

        private void btnNewDP_Click(object sender, EventArgs e)
        {
            PO_Thanh pCheck = new PO_Thanh();
            if (txbPOName.Text == "POX" || txbPOCode.Text == "XXX/CUVT-KV" || txbIDContract.Text == "XXX-202X/CUVT-ANSV/DTRR-KHMS")
            {
                MessageBox.Show("Chưa khởi tạo PO thì không tạo DP!");
            }
            else if (!pCheck.Exist(txbPOCode.Text))
            {
                MessageBox.Show("PO chưa tồn tại trong CSDL!");
            }
            else
            {
                requestDaskboardOpenDP(txbPOCode.Text, txbIDContract.Text, txbPOName.Text);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //requestDasckboardOpenExcel();
            DialogResult d;
            d = MessageBox.Show("Bạn có chắc chắn muốn xóa PO", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                PO p1 = new PO();
                p1.DeleteInforPO(po.Id);
                Close();
            }
            MessageBox.Show("Xóa PO " + po.Id + " thành công!");
            UpdateCatalogPanel("Contract_" + po.Id_contract);
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
            else
            {
                txbIDContract.Text = po.Id_contract.Substring(9);
            }
        }
        public OpenFileDialog openFileExcel = new OpenFileDialog();
        public string sConnectionString = null;
        private void importPO_Click(object sender, EventArgs e)
        {
            //
            if (openFileExcel.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileExcel.FileName))
                {
                    txbnamefilePO.Text = openFileExcel.FileName;
                    string filename = openFileExcel.FileName;
                    int ret = OpmExcelHandler.fReadExcelFilePO2(filename, ref pbpo);
                    if (ret == 1)
                    {
                        IPPO = txbIDContract.Text;
                        PBPO pBPO = new PBPO();
                        pBPO.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Import thất bại");
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
        static public DataTable dt = new DataTable();
        static public DataTable dtkhgh = new DataTable();
        static public DataTable pbpo = new DataTable();
        static public string IDVBXN = "";
        static public string IPPO = "";
        private void button3_Click(object sender, EventArgs e)
        {
            //openFileExcel.Multiselect = true;
            //openFileExcel.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            if (openFileExcel.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileExcel.FileName))
                {
                    txbnamefileKHGH.Text = openFileExcel.FileName;
                    string filename = openFileExcel.FileName;
                    int ret = OpmExcelHandler.SaveFileInDelivery_PO(filename, ref dtkhgh);
                    if (ret == 1)
                    {
                        IDVBXN = confirmpo_number.Text;
                        IPPO = txbIDContract.Text;
                        KHGH_PO kHGH_PO = new KHGH_PO();
                        kHGH_PO.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Import thất bại");
                    }
                }

            }
        }

        private void TimepickerDefaultActive_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void txbValuePO_TextChanged(object sender, EventArgs e)
        {
        }

        private void txbNumberDevice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)20)
            {
                Contract_Goods cg = new Contract_Goods();
                double priceUnit = cg.GetPriceUnit(txbIDContract.Text);
                priceUnit = double.Parse(txbNumberDevice.Text) * priceUnit;
                txbValuePO.Text = priceUnit.ToString();
            }
        }
    }
}
