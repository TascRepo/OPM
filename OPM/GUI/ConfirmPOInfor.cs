using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.IO;
using System.Windows.Forms;
namespace OPM.GUI
{
    public partial class ConfirmPOInfor : Form
    {
        public ConfirmPOInfor()
        {
            InitializeComponent();
        }
        public void SetKHMS(string value)
        {
            txbKHMS.Text = value;
            return;
        }
        public void SetContractID(string value)
        {
            txbIDContract.Text = value;
            return;
        }
        public void SetPOID(string value)
        {
            txbPOID.Text = value;
            return;
        }
        public void SetPONumber(string value)
        {
            txbPONumber.Text = value;
            return;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfirmPO newConfirmPOObj = new ConfirmPO();
            newConfirmPOObj.KHMS = txbKHMS.Text;
            newConfirmPOObj.IDContract = txbIDContract.Text;
            newConfirmPOObj.POID = txbPOID.Text;
            newConfirmPOObj.PONumber = txbPONumber.Text;
            newConfirmPOObj.ConfirmPOID = txbConfirmPOID.Text;

            newConfirmPOObj.MrPhoBan = txbForBan.Text;
            newConfirmPOObj.MrPhoBanMobile = txbMobileForBan.Text;
            newConfirmPOObj.MrGD_CSKH = txbGDCSKH.Text;
            newConfirmPOObj.MrGD_CSKH_mobile = txbMobileGDCSKH.Text;
            newConfirmPOObj.MrGD_CSKH_Landline = txbLandLineGDCSKH.Text;
            newConfirmPOObj.MrrGD_CSKH_LandlineExt = txbExt.Text;
            int ret = 0;
            /*Create Folder NTKT*/
            string DriveName = "";
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                //MessageBox.Show(driveInfo.Name.ToString());
                if (String.Compare(driveInfo.Name.ToString().Substring(0, 3), @"D:\") == 0 || String.Compare(driveInfo.Name.ToString().Substring(0, 3), @"E:\") == 0)
                {
                    //MessageBox.Show(driveInfo.Name.ToString().Substring(0, 1));
                    DriveName = driveInfo.Name.ToString().Substring(0, 3);
                    break;
                }
            }
            //Phần xử lý file phụ lục đính kèm ở mẫu 3, do đối tác cung cấp, không cần kiểm tra, chỉ cần có thông tin rồi đính kèm vòa mẫu 3
            string Src_Excel = DriveName + "OPM\\teamplate_PBGHDK.";
            //
            //Check xem Forder đã đc tạo hay chưa? nếu chưa tạo hì tạo, còn nếu đã tạo rồi thì thôi
            //
            string strPODirectory = DriveName + "OPM\\" + txbPONumber.Text;
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
                MessageBox.Show("Folder have been created!!!");
            }

            else
            {
                MessageBox.Show("Folder already exist!!!");
            }
            ret = newConfirmPOObj.CheckExistConfirmPO(txbConfirmPOID.Text);
            if (0 == ret)
            {
                ret = newConfirmPOObj.InsertNewConfirmPO(newConfirmPOObj);
                if (0 == ret)
                {
                    MessageBox.Show(ConstantVar.CreateNewConfirmPOFail);
                }
                else
                {
                    MessageBox.Show(ConstantVar.CreateNewConfirmPOSuccess);
                    string fileCVXNDH_temp = DriveName + @"LP\BVXNHLDH.docx";
                    string strCVXNDHName = strPODirectory + @"\Xac nhan don hang.docx";// + txbPONumber.Text + "_" + txbIDContract.Text + ".docx";
                    ContractObj contractObj = new ContractObj();
                    ret = ContractObj.GetObjectContract(txbIDContract.Text, ref contractObj);
                    PO pO = new PO();
                    ret = PO.GetObjectPO(txbPOID.Text, ref pO);
                    this.Cursor = Cursors.WaitCursor;
                    OpmWordHandler.Create_VBConfirm_PO(fileCVXNDH_temp, strCVXNDHName, newConfirmPOObj, pO, contractObj);
                    this.Cursor = Cursors.Default;
                }
            }
            //requestDashBoardPurchaseOderForm(txbPOID.Text, txbKHMS.Text);
            //PurchaseOderInfor purchaseOderInfor = new PurchaseOderInfor();
            //return;
        }
    }
}
