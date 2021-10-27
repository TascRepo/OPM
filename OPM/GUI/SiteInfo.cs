using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class SiteInfo : Form
    {
        public delegate void SetStringValue(string vl);
        public SetStringValue setStringValue;

        public string SiteId { get; set; }

        public SiteInfo()
        {
            InitializeComponent();
        }
        void AddSiteBinding()
        {
            txtSiteId.DataBindings.Clear();
            txtSiteId.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "SiteId"));
            txtProvinceId.DataBindings.Clear();
            txtProvinceId.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "ProvinceId"));
            txtTypeOfSite.DataBindings.Clear();
            txtTypeOfSite.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "TypeOfSite"));
            txtHeadquater.DataBindings.Clear();
            txtHeadquater.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Headquater"));
            txtAddress.DataBindings.Clear();
            txtAddress.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Address"));
            txtPhoneNumber.DataBindings.Clear();
            txtPhoneNumber.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Phonenumber"));
            txtFaxNumber.DataBindings.Clear();
            txtFaxNumber.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "FaxNumber"));
            txtTaxCode.DataBindings.Clear();
            txtTaxCode.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "TaxCode"));
            txtBankAccount.DataBindings.Clear();
            txtBankAccount.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "BankAccount"));
            txtNameOfBank.DataBindings.Clear();
            txtNameOfBank.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "NameOfBank"));
            txtRepresentative1.DataBindings.Clear();
            txtRepresentative1.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Representative1"));
            txtRepresentative2.DataBindings.Clear();
            txtRepresentative2.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Representative2"));
            txtRepresentative3.DataBindings.Clear();
            txtRepresentative3.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Representative3"));
            txtPosition1.DataBindings.Clear();
            txtPosition1.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Position1"));
            txtPosition2.DataBindings.Clear();
            txtPosition2.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Position2"));
            txtPosition3.DataBindings.Clear();
            txtPosition3.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Position3"));
            txtProxy1.DataBindings.Clear();
            txtProxy1.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Proxy1"));
            txtProxy2.DataBindings.Clear();
            txtProxy2.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Proxy2"));
            txtProxy3.DataBindings.Clear();
            txtProxy3.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Proxy3"));
        }
        void LoadDataGridView()
        {
            List<OPMEnginee.SiteObj> sites = OPMEnginee.SiteObj.GetList();
            dtgvSite.DataSource = sites;
            dtgvSite.Columns["SiteId"].HeaderText = @"Tên đơn vị";
            //dtgvSite.Columns["Id"].Width = 250;
            dtgvSite.Columns["ProvinceId"].HeaderText = @"VNPT tỉnh";
            dtgvSite.Columns["TypeOfSite"].HeaderText = @"Phân loại";
            //dtgvSite.Columns["TypeOfSite"].Width = 250;
            dtgvSite.Columns["TypeOfSite"].Visible = false;
            dtgvSite.Columns["Headquater"].HeaderText = @"Trụ sở";
            //dtgvSite.Columns["Headquater"].Width = 250;
            dtgvSite.Columns["Headquater"].Visible = false;

            dtgvSite.Columns["Address"].HeaderText = @"Địa chỉ";
            dtgvSite.Columns["Address"].Visible = false;
            //dtgvSite.Columns["Address"].Width = 250;
            dtgvSite.Columns["Phonenumber"].HeaderText = @"Điện thoại";
            dtgvSite.Columns["Phonenumber"].Visible = false;
            //dtgvSite.Columns["Phonenumber"].Width = 250;
            dtgvSite.Columns["FaxNumber"].HeaderText = @"Số Fax";
            dtgvSite.Columns["FaxNumber"].Visible = false;
            //dtgvSite.Columns["FaxNumber"].Width = 250;
            dtgvSite.Columns["TaxCode"].HeaderText = @"Mã số thuế";
            //dtgvSite.Columns["TaxCode"].Width = 250;
            dtgvSite.Columns["TaxCode"].Visible = false;

            dtgvSite.Columns["BankAccount"].HeaderText = @"Tài khoản";
            //dtgvSite.Columns["BankAccount"].Width = 250;
            dtgvSite.Columns["BankAccount"].Visible = false;
            dtgvSite.Columns["NameOfBank"].HeaderText = @"Nhân hàng";
            //dtgvSite.Columns["NameOfBank"].Width = 250;
            dtgvSite.Columns["NameOfBank"].Visible = false;

            dtgvSite.Columns["Representative1"].HeaderText = @"Đại diện 1";
            dtgvSite.Columns["Representative1"].Visible = false;
            //dtgvSite.Columns["Representative1"].Width = 250;
            dtgvSite.Columns["Position1"].HeaderText = @"Chức vụ";
            dtgvSite.Columns["Position1"].Visible = false;
            //dtgvSite.Columns["Position1"].Width = 250;
            dtgvSite.Columns["Proxy1"].HeaderText = @"Văn bản uỷ quyền";
            //dtgvSite.Columns["Proxy1"].Width = 250;
            dtgvSite.Columns["Proxy1"].Visible = false;

            dtgvSite.Columns["Representative2"].HeaderText = @"Đại diện 2";
            //dtgvSite.Columns["Representative2"].Width = 250;
            dtgvSite.Columns["Representative2"].Visible = false;

            dtgvSite.Columns["Position2"].HeaderText = @"Chức vụ";
            //dtgvSite.Columns["Position2"].Width = 250;
            dtgvSite.Columns["Position2"].Visible = false;
            dtgvSite.Columns["Proxy2"].HeaderText = @"Văn bản uỷ quyền";
            dtgvSite.Columns["Proxy2"].Visible = false;
            //dtgvSite.Columns["Proxy2"].Width = 250;
            dtgvSite.Columns["Representative3"].HeaderText = @"Đại diện 3";
            dtgvSite.Columns["Representative3"].Visible = false;
            //dtgvSite.Columns["Representative3"].Width = 250;
            dtgvSite.Columns["Position3"].HeaderText = @"Chức vụ";
            dtgvSite.Columns["Position3"].Visible = false;
            //dtgvSite.Columns["Position3"].Width = 250;
            dtgvSite.Columns["Proxy3"].HeaderText = @"Văn bản uỷ quyền";
            dtgvSite.Columns["Proxy3"].Visible = false;
            //dtgvSite.Columns["Proxy3"].Width = 250;
            for (int i = 0; i < dtgvSite.RowCount; i++)
            {
                dtgvSite.Rows[i].Cells[0].Value = i + 1;
                if (SiteId == dtgvSite.Rows[i].Cells["SiteId"].Value.ToString()) dtgvSite.CurrentCell = dtgvSite.Rows[i].Cells["SiteId"];
            }
            AddSiteBinding();
        }
        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            var site = new OPMEnginee.SiteObj
            {
                SiteId = txtSiteId.Text.Trim(),
                ProvinceId = txtProvinceId.Text.Trim(),
                Headquater = txtHeadquater.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phonenumber = txtPhoneNumber.Text.Trim(),
                FaxNumber = txtFaxNumber.Text.Trim(),
                TaxCode = txtTaxCode.Text.Trim(),
                BankAccount = txtBankAccount.Text.Trim(),
                NameOfBank = txtNameOfBank.Text.Trim(),
                TypeOfSite = txtTypeOfSite.Text.Trim(),
                Representative1 = txtRepresentative1.Text.Trim(),
                Representative2 = txtRepresentative2.Text.Trim(),
                Representative3 = txtRepresentative3.Text.Trim(),
                Position1 = txtPosition1.Text.Trim(),
                Position2 = txtPosition2.Text.Trim(),
                Position3 = txtPosition3.Text.Trim(),
                Proxy1 = txtProxy1.Text.Trim(),
                Proxy2 = txtProxy2.Text.Trim(),
                Proxy3 = txtProxy3.Text.Trim()
            };
            if (site.Exist()) site.Update();
            else site.Insert();
            LoadDataGridView();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OPMEnginee.SiteObj.Exist(txtSiteId.Text.Trim()))
            {
                OPMEnginee.SiteObj.Delete(txtSiteId.Text.Trim());
                LoadDataGridView();
            }
            else MessageBox.Show("Site không tồn tại!");
        }
        private void SiteForm_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            var site = new OPMEnginee.SiteObj
            {
                SiteId = txtSiteId.Text.Trim(),
                ProvinceId = txtProvinceId.Text.Trim(),
                Headquater = txtHeadquater.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phonenumber = txtPhoneNumber.Text.Trim(),
                FaxNumber = txtFaxNumber.Text.Trim(),
                TaxCode = txtTaxCode.Text.Trim(),
                BankAccount = txtBankAccount.Text.Trim(),
                NameOfBank = txtNameOfBank.Text.Trim(),
                TypeOfSite = txtTypeOfSite.Text.Trim(),
                Representative1 = txtRepresentative1.Text.Trim(),
                Representative2 = txtRepresentative2.Text.Trim(),
                Representative3 = txtRepresentative3.Text.Trim(),
                Position1 = txtPosition1.Text.Trim(),
                Position2 = txtPosition2.Text.Trim(),
                Position3 = txtPosition3.Text.Trim(),
                Proxy1 = txtProxy1.Text.Trim(),
                Proxy2 = txtProxy2.Text.Trim(),
                Proxy3 = txtProxy3.Text.Trim()
            };
            if (site.Exist()) site.Update();
            else site.Insert();
            LoadDataGridView();
            setStringValue(SiteId);
            (Tag as OPMDASHBOARDA).OpenContractForm();
        }
        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            SiteId = txtSiteId.Text.Trim();
        }
    }
}
