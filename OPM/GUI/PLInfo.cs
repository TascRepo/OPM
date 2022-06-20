using OPM.DBHandler;
using OPM.ExcelHandler;
using OPM.OPMEnginee;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OPM.GUI
{

    public partial class PLInfo : Form
    {
        public PLInfo()
        {
            InitializeComponent();
        }
        private void PLInfo_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            PLObj pl = (Tag as OPMDASHBOARDA).Pl;
            txtPLId.Text = pl.PLId;
            txtVNPTId.Text = pl.VNPTId;
            txtPLQuantity.Text = pl.PLQuantity.ToString();
            txtCaseQuantity.Text = pl.CaseQuantity.ToString();
            dateTimePickerPLDate.Value = pl.PLDate;
            txtPLDimension.Text = pl.PLDimension;
            txtPLVolume.Text = pl.PLVolume.ToString();
            txtPLNetWeight.Text = pl.PLNetWeight.ToString();
            txtPLGrossWeight.Text = pl.PLGrossWeight.ToString();
            dateTimePickerPLQualityInspectionCertificateInFactoryDate.Value = pl.PLQualityInspectionCertificateInFactoryDate;
            dateTimePickerPLQualityInspectionCertificateDate.Value = pl.PLQualityInspectionCertificateDate;
            DataTable dataTable = DeviceObj.DeviceGetDataTableByPLId(pl.PLId);
            dtgPL.DataSource = dataTable;
            DataBindingsFromDtgPLToTextBoxsPL();

        }

        private void btnNewPL_Click(object sender, System.EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeName = "PL_" + (new PLObj()).PLId;
        }

        private void txtPLId_TextChanged(object sender, System.EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CurrentNodeId = txtPLId.Text.Trim();
            if (DPObj.DPExist(txtPLId.Text.Trim()))
            {
                if (("PL_" + txtPLId.Text.Trim()) != (Tag as OPMDASHBOARDA).CurrentNodeName)
                {
                    MessageBox.Show("Đã tồn tại PL số " + txtPLId.Text.Trim());
                }
                return;
            }
            (Tag as OPMDASHBOARDA).Pl.PLId = txtPLId.Text.Trim();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).OpenDPForm();
        }

        private void btnDeletePL_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).DeleteSQLByNodeName();
        }

        private void btnSavePL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPLId.Text.Trim()) || txtPLId.Text.Trim() == (new PLObj()).PLId)
            {
                MessageBox.Show("Nhập đúng số LPId!");
                return;
            }
            (Tag as OPMDASHBOARDA).SaveSQLByNodeName();
        }

        private void dateTimePickerPLDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Pl.PLDate = dateTimePickerPLDate.Value;
        }

        private void txtPLDimension_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Pl.PLDimension = txtPLDimension.Text;
        }

        private void txtPLVolume_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPLVolume.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Pl.PLVolume = txtPLVolume.Text.Trim();
                }
                else
                    (Tag as OPMDASHBOARDA).Pl.PLVolume = "0";
            }
            catch
            {
                MessageBox.Show("Nhập lại PLVolume dạng số!");
            }
        }

        private void txtPLNetWeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPLVolume.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Pl.PLNetWeight = double.Parse(txtPLNetWeight.Text.Trim());
                }
                else
                    (Tag as OPMDASHBOARDA).Pl.PLNetWeight = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại PLNetWeight dạng số!");
            }
        }

        private void txtPLGrossWeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPLGrossWeight.Text.Trim()))
                {
                    (Tag as OPMDASHBOARDA).Pl.PLGrossWeight = double.Parse(txtPLGrossWeight.Text.Trim());
                }
                else
                    (Tag as OPMDASHBOARDA).Pl.PLGrossWeight = 0;
            }
            catch
            {
                MessageBox.Show("Nhập lại PLNetWeight dạng số!");
            }
        }

        private void buttonAddSerial_Click(object sender, EventArgs e)
        {
            // Mở file Mẫu 17.PL
            //string nameOfExcelFile = OpmExcelHandler.GetNameOfExcelFile();
            // Đọc file Mẫu 17.PL;
            //DataTable plTable = OpmExcelHandler.ReadExcelToDataTable(nameOfExcelFile, 3, 1, 1);
            DataTable plTable = OpmExcelHandler.ReadExcelToDataTable(@"D:\OPM\Template\Mẫu 17. PL.xlsx", 3, 1, 1);
            int pLTableCount = plTable.Rows.Count;
            PLObj pl = (Tag as OPMDASHBOARDA).Pl;
            string pLId = pl.PLId;
            //dtgPL.DataSource = plTable;
            // Insert plTble to MSSQL dbo.Device
            int pLQuantity = pl.PLQuantity;
            int caseQuantity = int.Parse(txtCaseQuantity.Text);
            int naturalPart = pLQuantity / caseQuantity;
            int residualPart = pLQuantity % caseQuantity;
            if (!DeviceObj.DevicePLIdExist(pLId))
            {
                for (int i = 0; i < pLTableCount; i++)
                {
                    int temp = i / caseQuantity;
                    int min = Math.Min(temp * caseQuantity + caseQuantity, pLTableCount);
                    int deviceNumberOfCase = caseQuantity;
                    if ((residualPart != 0) && (i >= naturalPart * caseQuantity)) deviceNumberOfCase = residualPart;
                    string DeviceSerialRange = plTable.Rows[temp * caseQuantity].ItemArray[2].ToString();
                    string DeviceMacNumberRange = plTable.Rows[temp * caseQuantity].ItemArray[3].ToString();
                    string DeviceSeriGPONRange = plTable.Rows[temp * caseQuantity].ItemArray[4].ToString();
                    for (int j=temp* caseQuantity + 1;j< min; j++)
                    {
                        DeviceSerialRange += ", " + plTable.Rows[j].ItemArray[2].ToString();
                        DeviceMacNumberRange += ", " + plTable.Rows[j].ItemArray[3].ToString();
                        DeviceSeriGPONRange += ", " + plTable.Rows[j].ItemArray[4].ToString();
                    }
                    string deviceCaseNumber = DeviceObj.DevicePLIdToCaseNumber(pLId, i);
                    string query = string.Format("INSERT INTO dbo.Device(PLId, DeviceCaseNumber, DeviceSerial, DeviceMAC, DeviceSerialGpon, DeviceBoxNumber, DeviceSerialRange, DeviceMacRange, DeviceSerialGPONRange, DeviceNumberOfCase)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})", pLId, deviceCaseNumber, plTable.Rows[i].ItemArray[2].ToString(), plTable.Rows[i].ItemArray[3].ToString(), plTable.Rows[i].ItemArray[4].ToString(), plTable.Rows[i].ItemArray[1].ToString(), DeviceSerialRange, DeviceMacNumberRange, DeviceSeriGPONRange, deviceNumberOfCase);
                    OPMDBHandler.ExecuteNonQuery(query);
                }
            }
            else
            {
                MessageBox.Show("PL đã tồn tại, nếu bạn muốn thay đổi thì xoá PL này đi và tạo lại mới!", "Cảnh báo!");
            }

            DataTable dataTable = DeviceObj.DeviceGetDataTableByPLId(pLId);
            dtgPL.DataSource = dataTable;
            DataBindingsFromDtgPLToTextBoxsPL();
        }
        private void DataBindingsFromDtgPLToTextBoxsPL()
        {
            dtgPL.Columns["DeviceId"].Visible = false;
            dtgPL.Columns["PLId"].Visible = false;
            dtgPL.Columns["DeviceSerialGpon"].Visible = false;
            dtgPL.Columns["DeviceCaseNumber"].HeaderText = @"CaseNumber";
            dtgPL.Columns["DeviceSerial"].HeaderText = @"Serial";
            dtgPL.Columns["DeviceMAC"].HeaderText = @"MAC";
            dtgPL.Columns["DeviceSerialGPON"].HeaderText = @"SerialGPON";
            dtgPL.Columns["DeviceBoxNumber"].HeaderText = @"BoxNumber";

            textBoxDeviceCaseNumber.DataBindings.Clear();
            textBoxDeviceCaseNumber.DataBindings.Add(new Binding("Text", dtgPL.DataSource, "DeviceCaseNumber"));
            textBoxDeviceBoxNumber.DataBindings.Clear();
            textBoxDeviceBoxNumber.DataBindings.Add(new Binding("Text", dtgPL.DataSource, "DeviceBoxNumber"));
            textBoxPackingListSerialNumberRange.DataBindings.Clear();
            textBoxPackingListSerialNumberRange.DataBindings.Add(new Binding("Text", dtgPL.DataSource, "DeviceSerialRange"));
        }
        private void DataBindingsFromDtgPLToTextBoxsPackingList()
        {
            dtgPL.Columns["DeviceCaseNumber"].HeaderText = @"Kiện số";
            dtgPL.Columns["DeviceBoxNumber"].HeaderText = @"Thùng số";
            dtgPL.Columns["DeviceSerialRange"].Visible = false;
            dtgPL.Columns["DeviceNumberOfCase"].HeaderText = @"Số lượng";

            textBoxDeviceCaseNumber.DataBindings.Clear();
            textBoxDeviceCaseNumber.DataBindings.Add(new Binding("Text", dtgPL.DataSource, "DeviceCaseNumber"));
            textBoxDeviceBoxNumber.DataBindings.Clear();
            textBoxDeviceBoxNumber.DataBindings.Add(new Binding("Text", dtgPL.DataSource, "DeviceBoxNumber"));
            textBoxCaseQuantity.DataBindings.Clear();
            textBoxCaseQuantity.DataBindings.Add(new Binding("Text", dtgPL.DataSource, "DeviceNumberOfCase"));
            textBoxPackingListSerialNumberRange.DataBindings.Clear();
            textBoxPackingListSerialNumberRange.DataBindings.Add(new Binding("Text", dtgPL.DataSource, "DeviceSerialRange"));

        }

        private void btnAddPackingList_Click(object sender, EventArgs e)
        {
            DataTable dataTable = DeviceObj.DeviceGetDataTableByDistinctDeviceCaseNumber((Tag as OPMDASHBOARDA).Pl.PLId);
            dtgPL.DataSource = dataTable;
            DataBindingsFromDtgPLToTextBoxsPackingList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DeviceObj.DeviceUpdateByBoxNumber(textBoxDeviceBoxNumber.Text.Trim(), textBoxDeviceCaseNumber.Text.Trim());
        }

        private void buttonCreatDoc_Click(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).CreatDocumentByNodeName();
        }

        private void dateTimePickerPLQualityInspectionCertificateInFactoryDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Pl.PLQualityInspectionCertificateInFactoryDate = dateTimePickerPLQualityInspectionCertificateInFactoryDate.Value;
        }

        private void dateTimePickerPLQualityInspectionCertificateDate_ValueChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).Pl.PLQualityInspectionCertificateDate = dateTimePickerPLQualityInspectionCertificateDate.Value;
        }
    }
}
