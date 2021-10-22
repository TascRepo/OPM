using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class SiteForm : Form
    {
        public delegate void SetStringValue(string vl);
        public SetStringValue setStringValue;
        string idSite;

        public string IdSite { get => idSite; set => idSite = value; }

        public SiteForm()
        {
            InitializeComponent();
        }
        void AddSiteBinding()
        {
            txtId.DataBindings.Clear();
            txtId.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Id"));
            txtIdVNPT.DataBindings.Clear();
            txtIdVNPT.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "IdVNPT"));
            textBoxType.DataBindings.Clear();
            textBoxType.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Type"));
            textBoxHeadquater.DataBindings.Clear();
            textBoxHeadquater.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Headquater"));
            textBoxAddress.DataBindings.Clear();
            textBoxAddress.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Address"));
            textBoxPhonenumber.DataBindings.Clear();
            textBoxPhonenumber.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Phonenumber"));
            textBoxFax.DataBindings.Clear();
            textBoxFax.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Fax"));
            textBoxTax.DataBindings.Clear();
            textBoxTax.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Tax"));
            textBoxAccount.DataBindings.Clear();
            textBoxAccount.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Account"));
            textBoxRepresentative1.DataBindings.Clear();
            textBoxRepresentative1.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Representative1"));
            textBoxRepresentative2.DataBindings.Clear();
            textBoxRepresentative2.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Representative2"));
            textBoxRepresentative3.DataBindings.Clear();
            textBoxRepresentative3.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Representative3"));
            textBoxPosition1.DataBindings.Clear();
            textBoxPosition1.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Position1"));
            textBoxPosition2.DataBindings.Clear();
            textBoxPosition2.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Position2"));
            textBoxPosition3.DataBindings.Clear();
            textBoxPosition3.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Position3"));
            textBoxProxy1.DataBindings.Clear();
            textBoxProxy1.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Proxy1"));
            textBoxProxy2.DataBindings.Clear();
            textBoxProxy2.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Proxy2"));
            textBoxProxy3.DataBindings.Clear();
            textBoxProxy3.DataBindings.Add(new Binding("Text", dtgvSite.DataSource, "Proxy3"));
        }
        void LoadDataGridView()
        {
            List<OPMEnginee.Site> sites = OPMEnginee.Site.GetList();
            dtgvSite.DataSource = sites;
            dtgvSite.Columns["Id"].HeaderText = @"Tên đơn vị";
            //dtgvSite.Columns["Id"].Width = 250;
            dtgvSite.Columns["IdVNPT"].HeaderText = @"VNPT tỉnh";
            dtgvSite.Columns["Type"].HeaderText = @"Phân loại";
            //dtgvSite.Columns["Type"].Width = 250;
            dtgvSite.Columns["Type"].Visible = false;
            dtgvSite.Columns["Headquater"].HeaderText = @"Trụ sở";
            //dtgvSite.Columns["Headquater"].Width = 250;
            dtgvSite.Columns["Headquater"].Visible = false;

            dtgvSite.Columns["Address"].HeaderText = @"Địa chỉ";
            dtgvSite.Columns["Address"].Visible = false;
            //dtgvSite.Columns["Address"].Width = 250;
            dtgvSite.Columns["Phonenumber"].HeaderText = @"Điện thoại";
            dtgvSite.Columns["Phonenumber"].Visible = false;
            //dtgvSite.Columns["Phonenumber"].Width = 250;
            dtgvSite.Columns["Fax"].HeaderText = @"Fax";
            dtgvSite.Columns["Fax"].Visible = false;
            //dtgvSite.Columns["Fax"].Width = 250;
            dtgvSite.Columns["Tax"].HeaderText = @"Mã số thuế";
            //dtgvSite.Columns["Tax"].Width = 250;
            dtgvSite.Columns["Tax"].Visible = false;

            dtgvSite.Columns["Account"].HeaderText = @"Tài khoản";
            //dtgvSite.Columns["Account"].Width = 250;
            dtgvSite.Columns["Account"].Visible = false;

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
                if (idSite == dtgvSite.Rows[i].Cells["Id"].Value.ToString()) dtgvSite.CurrentCell = dtgvSite.Rows[i].Cells["Id"];
            }
            AddSiteBinding();
        }
        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            OPMEnginee.Site site = new OPMEnginee.Site();
            site.Id = txtId.Text.Trim();
            site.IdVNPT = txtIdVNPT.Text.Trim();
            site.Headquater = textBoxHeadquater.Text.Trim();
            site.Address = textBoxAddress.Text.Trim();
            site.Phonenumber = textBoxPhonenumber.Text.Trim();
            site.Fax = textBoxFax.Text.Trim();
            site.Tax = textBoxTax.Text.Trim();
            site.Account = textBoxAccount.Text.Trim();
            site.Type = textBoxType.Text.Trim();
            site.Representative1 = textBoxRepresentative1.Text.Trim();
            site.Representative2 = textBoxRepresentative2.Text.Trim();
            site.Representative3 = textBoxRepresentative3.Text.Trim();
            site.Position1 = textBoxPosition1.Text.Trim();
            site.Position2 = textBoxPosition2.Text.Trim();
            site.Position3 = textBoxPosition3.Text.Trim();
            site.Proxy1 = textBoxProxy1.Text.Trim();
            site.Proxy2 = textBoxProxy2.Text.Trim();
            site.Proxy3 = textBoxProxy3.Text.Trim();
            if (site.Exist()) site.Update();
            else site.Insert();
            LoadDataGridView();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OPMEnginee.Site.Exist(txtId.Text.Trim()))
            {
                OPMEnginee.Site.Delete(txtId.Text.Trim());
                //LoadDataGridView();
            }
            else MessageBox.Show("Site không tồn tại!");
        }
        private void SiteForm_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            OPMEnginee.Site site = new OPMEnginee.Site();
            site.Id = txtId.Text.Trim();
            site.IdVNPT = txtIdVNPT.Text.Trim();
            site.Headquater = textBoxHeadquater.Text.Trim();
            site.Address = textBoxAddress.Text.Trim();
            site.Phonenumber = textBoxPhonenumber.Text.Trim();
            site.Fax = textBoxFax.Text.Trim();
            site.Tax = textBoxTax.Text.Trim();
            site.Account = textBoxAccount.Text.Trim();
            site.Type = textBoxType.Text.Trim();
            site.Representative1 = textBoxRepresentative1.Text.Trim();
            site.Representative2 = textBoxRepresentative2.Text.Trim();
            site.Representative3 = textBoxRepresentative3.Text.Trim();
            site.Position1 = textBoxPosition1.Text.Trim();
            site.Position2 = textBoxPosition2.Text.Trim();
            site.Position3 = textBoxPosition3.Text.Trim();
            site.Proxy1 = textBoxProxy1.Text.Trim();
            site.Proxy2 = textBoxProxy2.Text.Trim();
            site.Proxy3 = textBoxProxy3.Text.Trim();
            if (site.Exist()) site.Update();
            else site.Insert();
            LoadDataGridView();
            setStringValue(idSite);
            (Tag as OPMDASHBOARDA).OpenContractForm();
        }
        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            idSite = txtId.Text;
        }
    }
}
