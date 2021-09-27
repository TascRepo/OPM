using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OPM.DBHandler;
using OPM.OPMEnginee;
namespace OPM.GUI
{
    public partial class DescriptionSiteForm : Form
    {
        //public delegate void UpdateCatalogDelegate(string value);
        //public UpdateCatalogDelegate UpdateCatalogPanel;

        //public delegate void RequestDashBoardOpenDescriptionForm(string siteId);
        //public RequestDashBoardOpenDescriptionForm requestDashBoardOpendescriptionForm;

        //Truyền giá trị của Id_Site về Form Contract
        public delegate void SetIdSite(string idSite);
        public SetIdSite setIdSite;


        //private void SetDefaultValues()
        //{
        //    txbID.Clear();
        //    txbhead.Clear();
        //    txbAddress.Clear();
        //    txbPhone.Clear();
        //    txbFax.Clear();
        //    txbRepresen.Clear();
        //    txbAccount.Clear();
        //}
        //public void setId(string value)
        //{
        //    txbID.Text = value;
        //    return;
        //}
        //public void setHeadquater(string value)
        //{
        //    txbhead.Text = value;
        //    return;
        //}
        //public void setAddress(string value)
        //{
        //    txbAddress.Text = value;
        //    return;
        //}
        //public void setPhone(string value)
        //{
        //    txbPhone.Text = value;
        //    return;
        //}
        //public void setFax(string value)
        //{
        //    txbFax.Text = value;
        //    return;

        //}
        //public void setAccount(string value)
        //{
        //    txbAccount.Text = value;
        //    return;

        //}
        //public void setRepresentative(string value)
        //{
        //    txbRepresen.Text = value;
        //    return;

        //}
        public void state(bool state)
        {
            txbID.ReadOnly = state;
            txbhead.ReadOnly = state;
            txbAddress.ReadOnly = state;
            txbPhone.ReadOnly = state;
            txbFax.ReadOnly = state;
            txbRepresen.ReadOnly = state;
            txbAccount.ReadOnly = state;
            textBoxTaxCode.ReadOnly = state;
        }
        public DescriptionSiteForm()
        {
            InitializeComponent();
        }
        public DescriptionSiteForm(string id)
        {
            InitializeComponent();
            SetItemValue(id);
        }
        void SetItemValue(string id)
        {
            Site_Info site_Info = new Site_Info(id);
            txbID.Text = site_Info.Id;
            txbhead.Text = site_Info.Headquater_info;
            txbAddress.Text = site_Info.Address;
            txbPhone.Text = site_Info.Phonenumber;
            txbFax.Text = site_Info.Tin;
            txbRepresen.Text = site_Info.Representative;
            txbAccount.Text = site_Info.Account;
            textBoxTaxCode.Text = site_Info.Type;
        }
        private void DescriptionSiteForm_Load(object sender, EventArgs e)
        {
            state(true);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            state(false);
        }
        private void save_Click(object sender, EventArgs e)
        {
            //Cập nhật (nếu ID đã tồn tại) hoặc thêm mới Site_Info và cập nhật vào Form Contract
            Site_Info site_Info = new Site_Info();
            site_Info.Id = txbID.Text;
            site_Info.Headquater_info = txbhead.Text;
            site_Info.Address = txbAddress.Text;
            site_Info.Phonenumber = txbPhone.Text;
            site_Info.Type = textBoxTaxCode.Text;
            site_Info.Tin = txbFax.Text;
            site_Info.Account = txbAccount.Text;
            site_Info.Representative = txbRepresen.Text;
            if (Site_Info.Exist(txbID.Text.Trim())) site_Info.Update(); //Cập nhật vào dbo.Site_Info
            else
            {
                site_Info.Insert();             //Thêm mới vào dbo.Site_Info
                setIdSite(txbID.Text.Trim()); //Cập nhật vào Form Contract
            }
            this.Close();
        }

    }
}
