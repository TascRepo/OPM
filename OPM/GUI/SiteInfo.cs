using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class SiteInfo : Form
    {
        public SiteInfo()
        {
            InitializeComponent();
        }
        public SiteInfo(string SiteId)
        {
            InitializeComponent();
            LoadDataGridView(SiteId);
        }
        void AddSiteBinding()
        {
            txtSiteId.DataBindings.Clear();
            txtSiteId.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteId"));
            txtSiteName.DataBindings.Clear();
            txtSiteName.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteName"));
            txtSiteProvince.DataBindings.Clear();
            txtSiteProvince.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteProvince"));
            txtType.DataBindings.Clear();
            txtType.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteType"));
            txtHeadquater.DataBindings.Clear();
            txtHeadquater.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteHeadquater"));
            txtAddress.DataBindings.Clear();
            txtAddress.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteAddress"));
            txtPhoneNumber.DataBindings.Clear();
            txtPhoneNumber.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SitePhonenumber"));
            txtFaxNumber.DataBindings.Clear();
            txtFaxNumber.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteFaxNumber"));
            txtTaxCode.DataBindings.Clear();
            txtTaxCode.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteTaxCode"));
            txtBankAccount.DataBindings.Clear();
            txtBankAccount.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteBankAccount"));
            txtNameOfBank.DataBindings.Clear();
            txtNameOfBank.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteNameOfBank"));
            txtRepresentative1.DataBindings.Clear();
            txtRepresentative1.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteRepresentative1"));
            txtRepresentative2.DataBindings.Clear();
            txtRepresentative2.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteRepresentative2"));
            txtRepresentative3.DataBindings.Clear();
            txtRepresentative3.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteRepresentative3"));
            txtPosition1.DataBindings.Clear();
            txtPosition1.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SitePosition1"));
            txtPosition2.DataBindings.Clear();
            txtPosition2.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SitePosition2"));
            txtPosition3.DataBindings.Clear();
            txtPosition3.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SitePosition3"));
            txtProxy1.DataBindings.Clear();
            txtProxy1.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteProxy1"));
            txtProxy2.DataBindings.Clear();
            txtProxy2.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteProxy2"));
            txtProxy3.DataBindings.Clear();
            txtProxy3.DataBindings.Add(new Binding("Text", dtgvSiteA.DataSource, "SiteProxy3"));
        }
        void LoadDataGridView(string SiteId)
        {
            List<SiteObj> sites = SiteObj.SiteGetList();
            //SiteInfoId = (Tag as OPMDASHBOARDA).Contract.SiteId;
            SiteObj site = new SiteObj(SiteId);
            if (!SiteObj.SiteExist(SiteId))
            {
                sites.Insert(0, site);
            }
            dtgvSiteA.DataSource = sites;
            dtgvSiteA.Columns["SiteId"].HeaderText = @"Mã đơn vị";
            dtgvSiteA.Columns["SiteName"].HeaderText = @"Name";
            dtgvSiteA.Columns["SiteProvince"].HeaderText = @"VNPT ID";
            dtgvSiteA.Columns["SiteType"].HeaderText = @"Phân loại";
            dtgvSiteA.Columns["SiteType"].Visible = false;
            dtgvSiteA.Columns["SiteHeadquater"].HeaderText = @"Trụ sở";
            dtgvSiteA.Columns["SiteHeadquater"].Visible = false;
            dtgvSiteA.Columns["SiteAddress"].HeaderText = @"Địa chỉ";
            dtgvSiteA.Columns["SiteAddress"].Visible = false;
            dtgvSiteA.Columns["SitePhonenumber"].HeaderText = @"Điện thoại";
            dtgvSiteA.Columns["SitePhonenumber"].Visible = false;
            dtgvSiteA.Columns["SiteFaxNumber"].HeaderText = @"Số Fax";
            dtgvSiteA.Columns["SiteFaxNumber"].Visible = false;
            dtgvSiteA.Columns["SiteTaxCode"].HeaderText = @"Mã số thuế";
            dtgvSiteA.Columns["SiteTaxCode"].Visible = false;
            dtgvSiteA.Columns["SiteBankAccount"].HeaderText = @"Tài khoản";
            dtgvSiteA.Columns["SiteBankAccount"].Visible = false;
            dtgvSiteA.Columns["SiteNameOfBank"].HeaderText = @"Nhân hàng";
            dtgvSiteA.Columns["SiteNameOfBank"].Visible = false;
            dtgvSiteA.Columns["SiteRepresentative1"].HeaderText = @"Đại diện 1";
            dtgvSiteA.Columns["SiteRepresentative1"].Visible = false;
            dtgvSiteA.Columns["SitePosition1"].HeaderText = @"Chức vụ";
            dtgvSiteA.Columns["SitePosition1"].Visible = false;
            dtgvSiteA.Columns["SiteProxy1"].HeaderText = @"Văn bản uỷ quyền";
            dtgvSiteA.Columns["SiteProxy1"].Visible = false;
            dtgvSiteA.Columns["SiteRepresentative2"].HeaderText = @"Đại diện 2";
            dtgvSiteA.Columns["SiteRepresentative2"].Visible = false;
            dtgvSiteA.Columns["SitePosition2"].HeaderText = @"Chức vụ";
            dtgvSiteA.Columns["SitePosition2"].Visible = false;
            dtgvSiteA.Columns["SiteProxy2"].HeaderText = @"Văn bản uỷ quyền";
            dtgvSiteA.Columns["SiteProxy2"].Visible = false;
            dtgvSiteA.Columns["SiteRepresentative3"].HeaderText = @"Đại diện 3";
            dtgvSiteA.Columns["SiteRepresentative3"].Visible = false;
            dtgvSiteA.Columns["SitePosition3"].HeaderText = @"Chức vụ";
            dtgvSiteA.Columns["SitePosition3"].Visible = false;
            dtgvSiteA.Columns["SiteProxy3"].HeaderText = @"Văn bản uỷ quyền";
            dtgvSiteA.Columns["SiteProxy3"].Visible = false;
            AddSiteBinding();
            for (int i = 0; i < dtgvSiteA.RowCount; i++)
            {
                //dtgvSiteA.Rows[i].Cells[0].Value = i + 1;
                if (SiteObj.SiteExist(SiteId))
                {
                    if (SiteId == dtgvSiteA.Rows[i].Cells["SiteId"].Value.ToString()) dtgvSiteA.CurrentCell = dtgvSiteA.Rows[i].Cells["SiteId"];
                }
            }
        }
        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            var site = new OPMEnginee.SiteObj
            {
                SiteId = txtSiteId.Text.Trim(),
                SiteName = txtSiteName.Text.Trim(),
                SiteProvince = txtSiteProvince.Text.Trim(),
                SiteHeadquater = txtHeadquater.Text.Trim(),
                SiteAddress = txtAddress.Text.Trim(),
                SitePhonenumber = txtPhoneNumber.Text.Trim(),
                SiteFaxNumber = txtFaxNumber.Text.Trim(),
                SiteTaxCode = txtTaxCode.Text.Trim(),
                SiteBankAccount = txtBankAccount.Text.Trim(),
                SiteNameOfBank = txtNameOfBank.Text.Trim(),
                SiteType = txtType.Text.Trim(),
                SiteRepresentative1 = txtRepresentative1.Text.Trim(),
                SiteRepresentative2 = txtRepresentative2.Text.Trim(),
                SiteRepresentative3 = txtRepresentative3.Text.Trim(),
                SitePosition1 = txtPosition1.Text.Trim(),
                SitePosition2 = txtPosition2.Text.Trim(),
                SitePosition3 = txtPosition3.Text.Trim(),
                SiteProxy1 = txtProxy1.Text.Trim(),
                SiteProxy2 = txtProxy2.Text.Trim(),
                SiteProxy3 = txtProxy3.Text.Trim()
            };
            if (SiteObj.SiteExist(txtSiteId.Text.Trim()))
            {
                site.SiteUpdate(txtSiteId.Text.Trim(), txtSiteId.Text.Trim());
            }
            else site.SiteInsert(txtSiteId.Text.Trim());
            LoadDataGridView(txtSiteId.Text.Trim());
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OPMEnginee.SiteObj.SiteExist(txtSiteId.Text.Trim()))
            {
                OPMEnginee.SiteObj.Delete(txtSiteId.Text.Trim());
                LoadDataGridView((new SiteObj()).SiteId);
            }
            else MessageBox.Show("Site không tồn tại!");
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            var site = new OPMEnginee.SiteObj
            {
                SiteId = txtSiteId.Text.Trim(),
                SiteName = txtSiteName.Text.Trim(),
                SiteProvince = txtSiteProvince.Text.Trim(),
                SiteHeadquater = txtHeadquater.Text.Trim(),
                SiteAddress = txtAddress.Text.Trim(),
                SitePhonenumber = txtPhoneNumber.Text.Trim(),
                SiteFaxNumber = txtFaxNumber.Text.Trim(),
                SiteTaxCode = txtTaxCode.Text.Trim(),
                SiteBankAccount = txtBankAccount.Text.Trim(),
                SiteNameOfBank = txtNameOfBank.Text.Trim(),
                SiteType = txtType.Text.Trim(),
                SiteRepresentative1 = txtRepresentative1.Text.Trim(),
                SiteRepresentative2 = txtRepresentative2.Text.Trim(),
                SiteRepresentative3 = txtRepresentative3.Text.Trim(),
                SitePosition1 = txtPosition1.Text.Trim(),
                SitePosition2 = txtPosition2.Text.Trim(),
                SitePosition3 = txtPosition3.Text.Trim(),
                SiteProxy1 = txtProxy1.Text.Trim(),
                SiteProxy2 = txtProxy2.Text.Trim(),
                SiteProxy3 = txtProxy3.Text.Trim()
            };
            if (SiteObj.SiteExist(txtSiteId.Text.Trim()))
            {
                site.SiteUpdate(txtSiteId.Text.Trim(), txtSiteId.Text.Trim());
            }
            else site.SiteInsert(txtSiteId.Text.Trim());
            (Tag as OPMDASHBOARDA).SiteA.SiteId = txtSiteId.Text.Trim();
            (Tag as OPMDASHBOARDA).Contract.SiteId = txtSiteId.Text.Trim();
            if((Tag as OPMDASHBOARDA).backSiteFormStatus == 0)
            {
                (Tag as OPMDASHBOARDA).OpenContractForm();
            }
            else
            {
                (Tag as OPMDASHBOARDA).OpenDeliveryPlanForm();
            }
        }
        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            (Tag as OPMDASHBOARDA).SiteA.SiteId = txtSiteId.Text.Trim();
        }
    }
}
