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
        public PurchaseOderInfor()
        {
            InitializeComponent();
        }
        private void PurchaseOderInfor_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            txtIdPO.Text = (Tag as OPMDASHBOARDA).Po.Id;
            txtIdPO.Tag = (Tag as OPMDASHBOARDA).Po.Id;     //Lưu lại Id khi cần vì txtIdPO.Text có thể thay đổi khi Edit
            txtPOName.Text = (Tag as OPMDASHBOARDA).Po.POName;
            dtpSignedDate.Value = (Tag as OPMDASHBOARDA).Po.SignedDate;
            txtNumberOfDevice.Text = (Tag as OPMDASHBOARDA).Po.NumberOfDevice.ToString();
            txtConfirmRequestDuration.Text = ((Tag as OPMDASHBOARDA).Po.ConfirmRequestDate.Date - (Tag as OPMDASHBOARDA).Po.SignedDate.Date).TotalDays.ToString();
            dtpDefaultPerformDate.Value = (Tag as OPMDASHBOARDA).Po.DefaultPerformDate;
            txtDuration.Text = ((Tag as OPMDASHBOARDA).Po.Deadline.Date - (Tag as OPMDASHBOARDA).Po.PerformDate.Date).TotalDays.ToString();
            //dtpDeadline.Value = (Tag as OPMDASHBOARDA).PO.Deadline;
            txtTotalValue.Text = (Tag as OPMDASHBOARDA).Po.TotalValue.ToString();
            txtAdvancePercentage.Text = (Tag as OPMDASHBOARDA).Po.AdvancePercentage.ToString();
            dtpConfirmCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.ConfirmCreatedDate;
            txtIdConfirm.Text = (Tag as OPMDASHBOARDA).Po.IdConfirm.ToString();
            dtpAdvanceCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.AdvanceCreatedDate;
            txtAdvanceGuaranteePercentage.Text = (Tag as OPMDASHBOARDA).Po.AdvanceGuaranteePercentage.ToString();
            dtpAdvanceGuaranteeCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.AdvanceGuaranteeCreatedDate;
            dtpPerformDate.Value = (Tag as OPMDASHBOARDA).Po.PerformDate;
            txtIdAdvanceRequest.Text = (Tag as OPMDASHBOARDA).Po.IdAdvanceRequest;
            dtpAdvanceRequestDate.Value = (Tag as OPMDASHBOARDA).Po.AdvanceRequestDate;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Po.Id == (new PO()).Id)
            {
                MessageBox.Show("Nhập đúng số PO!");
                return;
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 4)//Đang ở Form chỉnh sửa
            {
                if (txtIdPO.Text == (txtIdPO.Tag as string))    //Không thay đổi IdPO
                    (Tag as OPMDASHBOARDA).Po.Update();
                else if (!(Tag as OPMDASHBOARDA).Po.Exist())
                    (Tag as OPMDASHBOARDA).Po.Update(txtIdPO.Tag as string);
                else
                {
                    MessageBox.Show(string.Format("Đã tồn tại PO số '{0}'", (Tag as OPMDASHBOARDA).Po.Id));
                    return;
                }
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 3)//Đang ở Form tạo mới PO
            {
                if (!(Tag as OPMDASHBOARDA).Po.Exist())
                {
                    if ((Tag as OPMDASHBOARDA).Po.Insert() > 0)
                    {
                        (Tag as OPMDASHBOARDA).TempStatus = 4;//Chuyển sang Form chỉnh sửa PO (đã tồn tại trong CSDL)
                        (Tag as OPMDASHBOARDA).OpenPOForm();
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Không tạo được vì PO số '{0}' đã tồn tại", (Tag as OPMDASHBOARDA).Po.Id));
                    return;
                }
            }
        }

        private void btnNTKT_Click(object sender, EventArgs e)
        {
            NTKT ntkt = new NTKT();
            ntkt.Id_po = (Tag as OPMDASHBOARDA).Po.Id;
            (Tag as OPMDASHBOARDA).OpenNTKTForm();
        }
        private void btnNewDP_Click(object sender, EventArgs e)
        {
            PO pCheck = new PO();
            if (!pCheck.Exist(txtIdPO.Text))
            {
                MessageBox.Show("PO chưa tồn tại trong CSDL!");
            }
            else
            {
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).TempStatus == 3) return;
            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa PO số '{0}'", (Tag as OPMDASHBOARDA).Po.Id), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if ((Tag as OPMDASHBOARDA).Po.Delete() > 0)
                {
                    (Tag as OPMDASHBOARDA).TempStatus = 3;  //Chuyển đến Form tạo mới PO
                    (Tag as OPMDASHBOARDA).OpenPOForm();
                }
            }
        }

        public OpenFileDialog openFileExcel = new OpenFileDialog();
        public string sConnectionString = null;
        private void importPO_Click(object sender, EventArgs e)
        {
            if (openFileExcel.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileExcel.FileName))
                {
                    txbnamefilePO.Text = openFileExcel.FileName;
                    string filename = openFileExcel.FileName;
                    DataTable dt = new DataTable();
                    int ret = OpmExcelHandler.fReadExcelFilePO2(filename, ref dt);
                    if (ret == 1)
                    {
                        dataGridViewPO.DataSource = dt;
                        MessageBox.Show("Import thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Import Không thành công!");
                    }
                }

            }
        }
        private void txbDurationConfirm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtConfirmRequestDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.ConfirmRequestDate = dtpSignedDate.Value.AddDays(int.Parse(txtConfirmRequestDuration.Text.Trim()));
                    dtpConfirmRequestDate.Value = dtpSignedDate.Value.AddDays(int.Parse(txtConfirmRequestDuration.Text.Trim()));
                }
                else
                    dtpConfirmRequestDate.Value = dtpSignedDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }
        private void dtpSignedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.SignedDate = dtpSignedDate.Value;
            try
            {
                dtpConfirmRequestDate.Value = dtpSignedDate.Value.AddDays(int.Parse(txtConfirmRequestDuration.Text));
                dtpDeadline.Value = dtpSignedDate.Value.AddDays(int.Parse(txtDuration.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }
        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.Deadline = dtpPerformDate.Value.AddDays(int.Parse(txtDuration.Text));
                    dtpDeadline.Value = dtpPerformDate.Value.AddDays(int.Parse(txtDuration.Text));
                }
                else
                    dtpDeadline.Value = dtpPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }
        static public DataTable dt = new DataTable();
        static public DataTable dtkhgh = new DataTable();
        static public string IDVBXN = "";
        static public string IPPO = "";


        private void btnDeliveryPlan_Click(object sender, EventArgs e)
        {
            //openFileExcel.Multiselect = true;
            //openFileExcel.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            if (openFileExcel.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileExcel.FileName))
                {
                    string filename = openFileExcel.FileName;
                    int ret = OpmExcelHandler.SaveFileInDelivery_PO(filename, ref dtkhgh);
                    if (ret == 1)
                    {
                        IDVBXN = txtIdConfirm.Text;
                        IPPO = txtIdPO.Text;
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
        private void txtIdPO_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.Id = txtIdPO.Text.Trim();
        }
        private void txtPOName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POName = txtPOName.Text;
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtPOName.Text);
        }
        private void txtNumberOfDevice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNumberOfDevice.Text.Trim()))
                    (Tag as OPMDASHBOARDA).Po.NumberOfDevice = int.Parse(txtNumberOfDevice.Text.Trim());
                else
                    (Tag as OPMDASHBOARDA).Po.NumberOfDevice = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }
        private void dtpConfirmRequestDate_ValueChanged(object sender, EventArgs e)
        {
            //(Tag as OPMDASHBOARDA).PO.ConfirmRequestDate = dtpConfirmRequestDate.Value;
        }

        private void dtpDefaultPerformDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.DefaultPerformDate = dtpDefaultPerformDate.Value;
        }

        private void txtTotalValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTotalValue.Text.Trim()))
                    (Tag as OPMDASHBOARDA).Po.TotalValue = double.Parse(txtTotalValue.Text.Trim());
                else
                    (Tag as OPMDASHBOARDA).Po.TotalValue = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }
        private void txtIdConfirm_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.IdConfirm = txtIdConfirm.Text.Trim();
        }
        private void dtpConfirmCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.ConfirmCreatedDate = dtpConfirmCreatedDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.Deadline = dtpPerformDate.Value.AddDays(int.Parse(txtDuration.Text));
                    dtpDeadline.Value = dtpPerformDate.Value.AddDays(int.Parse(txtDuration.Text));
                }
                else
                    dtpDeadline.Value = dtpPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }

        private void dtpPerformDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.PerformDate = dtpPerformDate.Value;
        }

        private void txtAdvancePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAdvancePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtAdvancePercentage.Text.Trim()) && int.Parse(txtAdvancePercentage.Text.Trim()) <= 100)
                        (Tag as OPMDASHBOARDA).Po.AdvancePercentage = int.Parse(txtAdvancePercentage.Text.Trim());
                    else
                    {
                        MessageBox.Show("Nhập lại dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
                else
                    (Tag as OPMDASHBOARDA).Po.AdvancePercentage = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }

        private void dtpAdvanceCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.AdvanceCreatedDate = dtpAdvanceCreatedDate.Value;
        }

        private void txtAdvanceGuaranteePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAdvanceGuaranteePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtAdvanceGuaranteePercentage.Text.Trim()) && int.Parse(txtAdvanceGuaranteePercentage.Text.Trim()) <= 100)
                        (Tag as OPMDASHBOARDA).Po.AdvanceGuaranteePercentage = int.Parse(txtAdvanceGuaranteePercentage.Text.Trim());
                    else
                    {
                        MessageBox.Show("Nhập lại dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
                else
                    (Tag as OPMDASHBOARDA).Po.AdvanceGuaranteePercentage = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }

        private void dtpAdvanceGuaranteeCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.AdvanceGuaranteeCreatedDate = dtpAdvanceGuaranteeCreatedDate.Value;
        }

        private void txtIdAdvanceRequest_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.IdAdvanceRequest = txtIdAdvanceRequest.Text.Trim();
        }

        private void dtpAdvanceRequestDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.AdvanceRequestDate = dtpAdvanceRequestDate.Value;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).TempStatus = 1;
            (Tag as OPMDASHBOARDA).OpenContractForm();
        }

        private void btnNewPO_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).TempStatus = 3;//Chuyển sang Form tạo mới PO
            (Tag as OPMDASHBOARDA).OpenPOForm();
        }

        private void btnCreatDoc_Click(object sender, EventArgs e)
        {
            //Tạo mẫu 7

            //Tạo mẫu 6

            //Tạo mẫu 5

            //Tạo mẫu 4

            //Tạo mẫu 3
            OpmWordHandler.Temp3_CreatPOConfirm((Tag as OPMDASHBOARDA).Po.Id);
            //Tạo các mẫu 23,24,36,37
            OpmWordHandler.Temp23_CNCL_TongHop((Tag as OPMDASHBOARDA).Po.Id);
            OpmWordHandler.Temp24_CNCLNMTongHop((Tag as OPMDASHBOARDA).Po.Id);
            OpmWordHandler.Temp36_BBNTLicense((Tag as OPMDASHBOARDA).Po.Id);
            OpmWordHandler.Temp37_BBXNCDLicense((Tag as OPMDASHBOARDA).Po.Id);
        }
    }
}
