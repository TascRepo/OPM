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
            txtPOId.Text = (Tag as OPMDASHBOARDA).Po.POId;
            txtPOId.Tag = (Tag as OPMDASHBOARDA).Po.POId;     //Lưu lại Id khi cần vì txtIdPO.Text có thể thay đổi khi Edit
            txtPOName.Text = (Tag as OPMDASHBOARDA).Po.POName;
            dtpPOCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POCreatedDate;
            txtPODuration.Text = ((Tag as OPMDASHBOARDA).Po.PODeadline.Date - (Tag as OPMDASHBOARDA).Po.POPerformDate.Date).TotalDays.ToString();
            txtPOGoodsQuantity.Text = (Tag as OPMDASHBOARDA).Po.POGoodsQuantity.ToString();
            txtPOConfirmRequestDuration.Text = ((Tag as OPMDASHBOARDA).Po.POConfirmRequestDeadline.Date - (Tag as OPMDASHBOARDA).Po.POCreatedDate.Date).Days.ToString();
            dtpPODefaultPerformDate.Value = (Tag as OPMDASHBOARDA).Po.PODefaultPerformDate;
            txtPOTotalValue.Text = (Tag as OPMDASHBOARDA).Po.POTotalValue.ToString();
            txtPOConfirmId.Text = (Tag as OPMDASHBOARDA).Po.POConfirmId.ToString();
            dtpPOConfirmCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POConfirmCreatedDate;
            dtpPOPerformDate.Value = (Tag as OPMDASHBOARDA).Po.POPerformDate;
            //dtpDeadline.Value = (Tag as OPMDASHBOARDA).PO.Deadline;
            txtPOAdvanceId.Text = (Tag as OPMDASHBOARDA).Po.POAdvanceId;
            txtPOAdvancePercentage.Text = (Tag as OPMDASHBOARDA).Po.POAdvancePercentage.ToString();
            dtpPOAdvanceCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POAdvanceCreatedDate;
            txtPOAdvanceGuaranteePercentage.Text = (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteePercentage.ToString();
            dtpPOAdvanceGuaranteeCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteeCreatedDate;
            txtPOAdvanceRequestId.Text = (Tag as OPMDASHBOARDA).Po.POAdvanceRequestId;
            dtpPOAdvanceRequestCreatedDate.Value = (Tag as OPMDASHBOARDA).Po.POAdvanceRequestCreatedDate;
            dtpPOGuaranteeDate.Value=(Tag as OPMDASHBOARDA).Po.POGuaranteeDate;
            txtPOGuaranteeRatio.Text = (Tag as OPMDASHBOARDA).Po.POGuaranteeRatio.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Po.POId == (new POObj()).POId)
            {
                MessageBox.Show("Nhập đúng số PO!");
                return;
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 4)//Đang ở Form chỉnh sửa
            {
                if (txtPOId.Text.Trim() == (txtPOId.Tag as string))    //Không thay đổi IdPO
                    (Tag as OPMDASHBOARDA).Po.POUpdate();
                else if (!(Tag as OPMDASHBOARDA).Po.POExist())
                    (Tag as OPMDASHBOARDA).Po.POUpdate(txtPOId.Tag as string);
                else
                {
                    MessageBox.Show(string.Format("Đã tồn tại PO số '{0}'", txtPOId.Text.Trim()));
                    return;
                }
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 3)//Đang ở Form tạo mới PO
            {
                if (!(Tag as OPMDASHBOARDA).Po.POExist())
                {
                    if ((Tag as OPMDASHBOARDA).Po.POInsert(txtPOId.Text.Trim()) > 0)
                    {
                        (Tag as OPMDASHBOARDA).TempStatus = 4;//Chuyển sang Form chỉnh sửa PO (đã tồn tại trong CSDL)
                        (Tag as OPMDASHBOARDA).Po.POId = txtPOId.Text.Trim();
                        //(Tag as OPMDASHBOARDA).Contract.ContractId = (Tag as OPMDASHBOARDA).Po.ContractId;
                        (Tag as OPMDASHBOARDA).OpenPOForm();
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Không tạo được vì PO số '{0}' đã tồn tại", (Tag as OPMDASHBOARDA).Po.POId));
                    return;
                }
            }
        }

        private void btnNTKT_Click(object sender, EventArgs e)
        {
            if ((Tag as OPMDASHBOARDA).Po.POExist())
            {
                (Tag as OPMDASHBOARDA).TempStatus = 6;//Chuyển sang Form tạo mới NTKT
                (Tag as OPMDASHBOARDA).OpenNTKTForm();
            }
        }
        private void btnNewDP_Click(object sender, EventArgs e)
        {
            if (!POObj.POExist(txtPOId.Text))
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
            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa PO số '{0}'", (Tag as OPMDASHBOARDA).Po.POId), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if ((Tag as OPMDASHBOARDA).Po.PODelete() > 0)
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
        private void txtPOConfirmRequestDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOConfirmRequestDuration.Text.Trim()))
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value.AddDays(int.Parse(txtPOConfirmRequestDuration.Text.Trim()));
                else
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại POConfirmRequestDuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.POConfirmRequestDeadline = dtpPOConfirmRequestDeadline.Value;
        }
        private void dtpPOCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POCreatedDate = dtpPOCreatedDate.Value;
            try
            {
                if(!string.IsNullOrEmpty(txtPOConfirmRequestDuration.Text.Trim()))
                    dtpPOConfirmRequestDeadline.Value = dtpPOCreatedDate.Value.AddDays(int.Parse(txtPOConfirmRequestDuration.Text.Trim()));
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại POConfirmRequestDuration dạng số!");
            }
        }
        private void txtPODuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại PODuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPODeadline.Value;
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
                        IDVBXN = txtPOConfirmId.Text;
                        IPPO = txtPOId.Text;
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
        private void txtPOId_TextChanged(object sender, EventArgs e)
        {
            if (POObj.POExist(txtPOId.Text.Trim()))
            {
                if(("PO_" + txtPOId.Text.Trim())!= (Tag as OPMDASHBOARDA).SelectedNodeName)
                {
                    MessageBox.Show("Đã tồn tại PO số " + txtPOId.Text.Trim());
                    //string[] temp = (Tag as OPMDASHBOARDA).SelectedNodeName.Split('_', 2);
                    //txtPOId.Text = temp[1];
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Po.POId = txtPOId.Text.Trim();
        }
        private void TxtPOName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POName = txtPOName.Text;
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtPOName.Text);
        }
        private void txtPOGoodsQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOGoodsQuantity.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.POGoodsQuantity = int.Parse(txtPOGoodsQuantity.Text.Trim());
                    txtPOTotalValue.Text = (Tag as OPMDASHBOARDA).Po.POTotalValue.ToString();
                    txtPOAdvanceValue.Text = (0.01 * (Tag as OPMDASHBOARDA).Po.POAdvancePercentage * (Tag as OPMDASHBOARDA).Po.POTotalValue).ToString();
                }
                else
                    (Tag as OPMDASHBOARDA).Po.POGoodsQuantity = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại POGoodsQuantity dạng số!");
            }
        }

        private void dtpPODefaultPerformDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.PODefaultPerformDate = dtpPODefaultPerformDate.Value;
        }
        private void txtPOConfirmId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POConfirmId = txtPOConfirmId.Text.Trim();
        }
        private void dtpPOConfirmCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POConfirmCreatedDate = dtpPOConfirmCreatedDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                }
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại ConfirmCreatedDate dạng số!");
            }
        }

        private void dtpPOPerformDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POPerformDate = dtpPOPerformDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtPODuration.Text.Trim()))
                    dtpPODeadline.Value = dtpPOPerformDate.Value.AddDays(int.Parse(txtPODuration.Text));
                else
                    dtpPODeadline.Value = dtpPOPerformDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập lại PODuration dạng số!");
            }
            (Tag as OPMDASHBOARDA).Po.PODeadline = dtpPODeadline.Value;
        }

        private void txtPOAdvancePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOAdvancePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtPOAdvancePercentage.Text.Trim()) && int.Parse(txtPOAdvancePercentage.Text.Trim()) <= 100)
                    {
                        (Tag as OPMDASHBOARDA).Po.POAdvancePercentage = int.Parse(txtPOAdvancePercentage.Text.Trim());
                        txtPOAdvanceValue.Text = (0.01 * (Tag as OPMDASHBOARDA).Po.POAdvancePercentage * (Tag as OPMDASHBOARDA).Po.POTotalValue).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại POAdvancePercentage dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nhập lại POAdvancePercentage dạng số!");
            }
        }

        private void dtpAdvanceCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceCreatedDate = dtpPOAdvanceCreatedDate.Value;
        }

        private void txtPOAdvanceGuaranteePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPOAdvanceGuaranteePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim()) && int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim()) <= 100)
                        (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteePercentage = int.Parse(txtPOAdvanceGuaranteePercentage.Text.Trim());
                    else
                    {
                        MessageBox.Show("Nhập lại dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
                else
                    (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteePercentage = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại POAdvanceGuaranteePercentage dạng số!");
            }
        }

        private void dtpAdvanceGuaranteeCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceGuaranteeCreatedDate = dtpPOAdvanceGuaranteeCreatedDate.Value;
        }

        private void txtIdAdvanceRequest_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceRequestId = txtPOAdvanceRequestId.Text.Trim();
        }

        private void dtpAdvanceRequestDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceRequestCreatedDate = dtpPOAdvanceRequestCreatedDate.Value;
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
            if (!(Tag as OPMDASHBOARDA).Po.POExist()) return;
            //Tạo mẫu 7

            //Tạo mẫu 6
            OpmWordHandler.Temp6_CreatPOAdvanceReques((Tag as OPMDASHBOARDA).Po.POId); 
            //Tạo mẫu 5
            OpmWordHandler.Temp5_CreatPOAdvanceGuarantee((Tag as OPMDASHBOARDA).Po.POId);
            //Tạo mẫu 4
            OpmWordHandler.Temp4_CreatPOPerformanceGuarantee((Tag as OPMDASHBOARDA).Po.POId); 
            //Tạo mẫu 3
            OpmWordHandler.Temp3_CreatPOConfirm((Tag as OPMDASHBOARDA).Po.POId);
            //Tạo các mẫu 23,24,36,37
            OpmWordHandler.Temp23_CNCL_TongHop((Tag as OPMDASHBOARDA).Po.POId);
            OpmWordHandler.Temp24_CNCLNMTongHop((Tag as OPMDASHBOARDA).Po.POId);
            OpmWordHandler.Temp36_BBNTLicense((Tag as OPMDASHBOARDA).Po.POId);
            OpmWordHandler.Temp37_BBXNCDLicense((Tag as OPMDASHBOARDA).Po.POId);
        }

        private void txtPOAdvanceId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POAdvanceId = txtPOAdvanceId.Text.Trim();
        }

        private void dtpPOGuaranteeDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Po.POGuaranteeDate = dtpPOGuaranteeDate.Value;
        }
    }
}
