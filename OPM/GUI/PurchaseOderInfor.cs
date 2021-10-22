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
            txtIdPO.Text = (Tag as OPMDASHBOARDA).PO.Id;
            txtIdPO.Tag = (Tag as OPMDASHBOARDA).PO.Id;     //Lưu lại Id khi cần vì txtIdPO.Text có thể thay đổi khi Edit
            txtPOName.Text = (Tag as OPMDASHBOARDA).PO.POName;
            dtpSignedDate.Value = (Tag as OPMDASHBOARDA).PO.SignedDate;
            txtNumberOfDevice.Text = (Tag as OPMDASHBOARDA).PO.NumberOfDevice.ToString();
            txtConfirmRequestDuration.Text = ((Tag as OPMDASHBOARDA).PO.ConfirmRequestDate.Date - (Tag as OPMDASHBOARDA).PO.SignedDate.Date).TotalDays.ToString();
            dtpDefaultPerformDate.Value = (Tag as OPMDASHBOARDA).PO.DefaultPerformDate;
            txtDuration.Text= ((Tag as OPMDASHBOARDA).PO.Deadline.Date - (Tag as OPMDASHBOARDA).PO.PerformDate.Date).TotalDays.ToString();
            //dtpDeadline.Value = (Tag as OPMDASHBOARDA).PO.Deadline;
            txtTotalValue.Text = (Tag as OPMDASHBOARDA).PO.TotalValue.ToString();
            txtAdvancePercentage.Text = (Tag as OPMDASHBOARDA).PO.AdvancePercentage.ToString();
            dtpConfirmCreatedDate.Value = (Tag as OPMDASHBOARDA).PO.ConfirmCreatedDate;
            txtIdConfirm.Text = (Tag as OPMDASHBOARDA).PO.IdConfirm.ToString();
            dtpAdvanceCreatedDate.Value = (Tag as OPMDASHBOARDA).PO.AdvanceCreatedDate;
            txtAdvanceGuaranteePercentage.Text = (Tag as OPMDASHBOARDA).PO.AdvanceGuaranteePercentage.ToString();
            dtpAdvanceGuaranteeCreatedDate.Value = (Tag as OPMDASHBOARDA).PO.AdvanceGuaranteeCreatedDate;
            dtpPerformDate.Value = (Tag as OPMDASHBOARDA).PO.PerformDate;
            txtIdAdvanceRequest.Text = (Tag as OPMDASHBOARDA).PO.IdAdvanceRequest;
            dtpAdvanceRequestDate.Value = (Tag as OPMDASHBOARDA).PO.AdvanceRequestDate;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if((Tag as OPMDASHBOARDA).PO.Id==(new PO_Thanh()).Id)
            {
                MessageBox.Show("Nhập đúng số PO!");
                return;
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 4)//Đang ở Form chỉnh sửa
            {
                if (txtIdPO.Text == (txtIdPO.Tag as string))    //Không thay đổi IdPO
                    (Tag as OPMDASHBOARDA).PO.Update();
                else if (!(Tag as OPMDASHBOARDA).PO.Exist())
                    (Tag as OPMDASHBOARDA).PO.Update(txtIdPO.Tag as string);
                else
                {
                    MessageBox.Show(string.Format("Đã tồn tại PO số '{0}'", (Tag as OPMDASHBOARDA).PO.Id));
                    return;
                }
            }
            if ((Tag as OPMDASHBOARDA).TempStatus == 3)//Đang ở Form tạo mới PO
            {
                if (!(Tag as OPMDASHBOARDA).PO.Exist())
                {
                    if((Tag as OPMDASHBOARDA).PO.Insert() > 0)
                    {
                        (Tag as OPMDASHBOARDA).TempStatus = 4;//Chuyển sang Form chỉnh sửa PO (đã tồn tại trong CSDL)
                        (Tag as OPMDASHBOARDA).OpenPOForm();
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Không tạo được vì PO số '{0}' đã tồn tại", (Tag as OPMDASHBOARDA).PO.Id));
                    return;
                }
            }
            //if((Tag as OPMDASHBOARDA).TempStatus = 4)

            //(Tag as OPMDASHBOARDA).PO.Id = txtIdPO.Text.Trim();
            //(Tag as OPMDASHBOARDA).PO.POName = txtPOName.Text;
            //(Tag as OPMDASHBOARDA).PO.SignedDate = dtpSignedDate.Value;
            //try
            //{
            //    (Tag as OPMDASHBOARDA).PO.NumberOfDevice = double.Parse(txtNumberOfDevice.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Nhập lại dạng số thiết bị!");
            //    return;
            //}
            //(Tag as OPMDASHBOARDA).PO.ConfirmRequestDate = dtpConfirmRequestDate.Value;
            //(Tag as OPMDASHBOARDA).PO.DefaultPerformDate = dtpDefaultPerformDate.Value;
            //(Tag as OPMDASHBOARDA).PO.Deadline = dtpDeadline.Value;
            //try
            //{
            //    (Tag as OPMDASHBOARDA).PO.TotalValue = double.Parse(txtTotalValue.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Nhập lại dạng Tổng giá trị hợp đồng");
            //    return;
            //}
            //if ((Tag as OPMDASHBOARDA).PO.TotalValue < 0)
            //{
            //    MessageBox.Show("Nhập lại dạng Tổng giá trị hợp >= 0");
            //    return;
            //}
            //try
            //{
            //    (Tag as OPMDASHBOARDA).PO.AdvancePercentage = int.Parse(txtAdvancePercentage.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Nhập lại dạng số TUPO!");
            //    return;
            //}
            //if ((Tag as OPMDASHBOARDA).PO.AdvancePercentage < 0 || (Tag as OPMDASHBOARDA).PO.AdvancePercentage > 100)
            //{
            //    MessageBox.Show("Nhập lại 0 <= Tạm ứng PO <= 100");
            //    return;
            //}
            //(Tag as OPMDASHBOARDA).PO.ConfirmCreatedDate = dtpConfirmCreatedDate.Value;
            //(Tag as OPMDASHBOARDA).PO.IdConfirm = txtIdConfirm.Text;
            //(Tag as OPMDASHBOARDA).PO.AdvanceCreatedDate = dtpAdvanceCreatedDate.Value;
            //try
            //{
            //    (Tag as OPMDASHBOARDA).PO.AdvanceGuaranteePercentage = int.Parse(txtAdvanceGuaranteePercentage.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Nhập lại dạng sô BLTUPO!");
            //    return;
            //}
            //if ((Tag as OPMDASHBOARDA).PO.AdvanceGuaranteePercentage < 0 || (Tag as OPMDASHBOARDA).PO.AdvanceGuaranteePercentage > 100)
            //{
            //    MessageBox.Show("Nhập lại 0 <= Bảo lãnh tạm ứng PO <= 100");
            //    return;
            //}
            //(Tag as OPMDASHBOARDA).PO.AdvanceGuaranteeCreatedDate = dtpAdvanceGuaranteeCreatedDate.Value;
            //(Tag as OPMDASHBOARDA).PO.PerformDate = dtpPerformDate.Value;
            //(Tag as OPMDASHBOARDA).PO.InsertOrUpdate();
            ////Tạo file xác nhận hợp đồng
            //if (txbnamefileKHGH.Text != "")
            //{
            //    (Tag as OPMDASHBOARDA).PO.InsertOrUpdate_VBConfirmPO(txtIdPO.Text);
            //    //OpmWordHandler.Word_POConfirm(txbKHMS.Text, txbIDContract.Text, txbPOCode.Text, txbPOName.Text, confirmpo_number.Text, TimePickerDateCreatedPO.Text, confirmpo_datecreated.Text, confirmpo_dateactive.Text);
            //}
            //else
            //{
            //    if ((Tag as OPMDASHBOARDA).PO.CheckListDelivery_PO((Tag as OPMDASHBOARDA).PO.IdConfirm))
            //    {
            //        MessageBox.Show((Tag as OPMDASHBOARDA).PO.IdConfirm + "đã có file giao hàng dự kiến, không cần import thêm!");
            //    }
            //    else
            //    {
            //        MessageBox.Show((Tag as OPMDASHBOARDA).PO.IdConfirm + "chưa có trong hệ thống, bạn phải bổ sung sau!");
            //    }
            //}
            ////Tạo 3 mẫu văn bản m4,m5,m6
            //if (txbnamefilePO.Text != "")
            //{
            //    int returnValue = 0;
            //    if ((Tag as OPMDASHBOARDA).PO.CheckListExpected_PO((Tag as OPMDASHBOARDA).PO.Id))
            //    {
            //        MessageBox.Show((Tag as OPMDASHBOARDA).PO.Id + "Đã có file phẩn bổ, không cần import thêm!");
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dataGridViewPO.Rows.Count - 1; i++)
            //        {
            //            returnValue = (Tag as OPMDASHBOARDA).PO.InsertImportFilePO((Tag as OPMDASHBOARDA).PO.Id, dataGridViewPO.Rows[i].Cells[1].Value.ToString(), dataGridViewPO.Rows[i].Cells[2].Value.ToString(), (new Contract_Thanh((Tag as OPMDASHBOARDA).PO.IdContract)).ContractName);
            //        }
            //        if (returnValue == 1)
            //        {
            //            MessageBox.Show("Lưu trữ thông tin file phân bổ thành công");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Lưu trữ thông tin file phân bổ thất bại");
            //        }
            //    }
            //}
            //else
            //{
            //    if ((Tag as OPMDASHBOARDA).PO.CheckListExpected_PO((Tag as OPMDASHBOARDA).PO.Id))
            //    {
            //        MessageBox.Show((Tag as OPMDASHBOARDA).PO.Id + "đã có file phẩn bổ, không cần import thêm!");
            //    }
            //}
            //OpmWordHandler.Word_POBaoLanh(txbKHMS.Text, txbIDContract.Text, txbPOCode.Text, txbPOName.Text, confirmpo_number.Text, TimePickerDateCreatedPO.Text, confirmpo_datecreated.Text, confirmpo_dateactive.Text, txbValuePO.Text, bltupo.Text, txbDurationConfirm.Text);
            //OpmWordHandler.Word_POTamUng(txbKHMS.Text, txbIDContract.Text, txbPOCode.Text, txbPOName.Text, confirmpo_number.Text, TimePickerDateCreatedPO.Text, confirmpo_datecreated.Text, confirmpo_dateactive.Text, txbValuePO.Text, bltupo.Text, txbDurationConfirm.Text, svbdntt.Text);
            //this.Cursor = Cursors.Default;
        }
        public void SetValueItemForPO(string idPO)
        {
            PO pO = new PO();
            string namecontract = null, KHMS = null;
            pO.DisplayPO(idPO, ref namecontract, ref KHMS);
            pO.GetDisplayPO(idPO, ref pO);
            this.txtIdPO.Text = pO.IDPO;
            this.txtPOName.Text = pO.PONumber;
            dtpSignedDate.Value = Convert.ToDateTime(pO.DateCreatedPO);
            this.txtNumberOfDevice.Text = pO.NumberOfDevice.ToString();
            dtpConfirmRequestDate.Value = Convert.ToDateTime(pO.DurationConfirmPO);
            dtpDefaultPerformDate.Value = Convert.ToDateTime(pO.DefaultActiveDatePO);
            dtpDeadline.Value = Convert.ToDateTime(pO.DeadLinePO);
            this.txtTotalValue.Text = pO.TotalValuePO.ToString();
            return;

        }

        private void btnNTKT_Click(object sender, EventArgs e)
        {
            NTKT_Thanh ntkt = new NTKT_Thanh();
            ntkt.Id_po = (Tag as OPMDASHBOARDA).PO.Id;
            (Tag as OPMDASHBOARDA).OpenNTKTForm();
        }
        private void btnNewDP_Click(object sender, EventArgs e)
        {
            PO_Thanh pCheck = new PO_Thanh();
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
            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa PO số '{0}'",(Tag as OPMDASHBOARDA).PO.Id), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if((Tag as OPMDASHBOARDA).PO.Delete() > 0)
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
                    (Tag as OPMDASHBOARDA).PO.ConfirmRequestDate = dtpSignedDate.Value.AddDays(int.Parse(txtConfirmRequestDuration.Text.Trim()));
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
            (Tag as OPMDASHBOARDA).PO.SignedDate = dtpSignedDate.Value;
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
                    (Tag as OPMDASHBOARDA).PO.Deadline = dtpPerformDate.Value.AddDays(int.Parse(txtDuration.Text));
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
            (Tag as OPMDASHBOARDA).PO.Id = txtIdPO.Text.Trim();
        }
        private void txtPOName_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).PO.POName = txtPOName.Text;
            (Tag as OPMDASHBOARDA).SetNameOfSelectNode(txtPOName.Text);
        }
        private void txtNumberOfDevice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNumberOfDevice.Text.Trim()))
                    (Tag as OPMDASHBOARDA).PO.NumberOfDevice = int.Parse(txtNumberOfDevice.Text.Trim());
                else
                    (Tag as OPMDASHBOARDA).PO.NumberOfDevice = 0;
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
            (Tag as OPMDASHBOARDA).PO.DefaultPerformDate = dtpDefaultPerformDate.Value;
        }

        private void txtTotalValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTotalValue.Text.Trim()))
                    (Tag as OPMDASHBOARDA).PO.TotalValue = double.Parse(txtTotalValue.Text.Trim());
                else
                    (Tag as OPMDASHBOARDA).PO.TotalValue = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }
        private void txtIdConfirm_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).PO.IdConfirm = txtIdConfirm.Text.Trim();
        }
        private void dtpConfirmCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).PO.ConfirmCreatedDate = dtpConfirmCreatedDate.Value;
            try
            {
                if (!string.IsNullOrEmpty(txtDuration.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).PO.Deadline = dtpPerformDate.Value.AddDays(int.Parse(txtDuration.Text));
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
            (Tag as OPMDASHBOARDA).PO.PerformDate = dtpPerformDate.Value;
        }

        private void txtAdvancePercentage_TextChanged(object sender, EventArgs e)
        {
            try
           {
                if (!string.IsNullOrEmpty(txtAdvancePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtAdvancePercentage.Text.Trim()) && int.Parse(txtAdvancePercentage.Text.Trim()) <= 100)
                        (Tag as OPMDASHBOARDA).PO.AdvancePercentage = int.Parse(txtAdvancePercentage.Text.Trim());
                    else
                    {
                        MessageBox.Show("Nhập lại dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
                else
                    (Tag as OPMDASHBOARDA).PO.AdvancePercentage = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }

        private void dtpAdvanceCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).PO.AdvanceCreatedDate = dtpAdvanceCreatedDate.Value;
        }

        private void txtAdvanceGuaranteePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAdvanceGuaranteePercentage.Text.Trim()))
                {
                    if (0 <= int.Parse(txtAdvanceGuaranteePercentage.Text.Trim()) && int.Parse(txtAdvanceGuaranteePercentage.Text.Trim()) <= 100)
                        (Tag as OPMDASHBOARDA).PO.AdvanceGuaranteePercentage = int.Parse(txtAdvanceGuaranteePercentage.Text.Trim());
                    else
                    {
                        MessageBox.Show("Nhập lại dạng số trong khoảng 0 đến 100!");
                        return;
                    }
                }
                else
                    (Tag as OPMDASHBOARDA).PO.AdvanceGuaranteePercentage = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại dạng số!");
            }
        }

        private void dtpAdvanceGuaranteeCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).PO.AdvanceGuaranteeCreatedDate = dtpAdvanceGuaranteeCreatedDate.Value;
        }

        private void txtIdAdvanceRequest_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).PO.IdAdvanceRequest = txtIdAdvanceRequest.Text.Trim();
        }

        private void dtpAdvanceRequestDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).PO.AdvanceRequestDate = dtpAdvanceRequestDate.Value;
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
            OpmWordHandler.Temp3_CreatPOConfirm((Tag as OPMDASHBOARDA).PO.Id);
            //Tạo các mẫu 23,24,36,37
            OpmWordHandler.Temp23_CNCL_TongHop((Tag as OPMDASHBOARDA).PO.Id);
            OpmWordHandler.Temp24_CNCLNMTongHop((Tag as OPMDASHBOARDA).PO.Id);
            OpmWordHandler.Temp36_BBNTLicense((Tag as OPMDASHBOARDA).PO.Id);
            OpmWordHandler.Temp37_BBXNCDLicense((Tag as OPMDASHBOARDA).PO.Id);
        }
    }
}
