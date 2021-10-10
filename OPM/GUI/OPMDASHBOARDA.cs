using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OPM.GUI
{
    public partial class OPMDASHBOARDA : Form
    {

        //private TreeNode selectedNode;

        //public PurchaseOderInfor objPurchaseOder= new PurchaseOderInfor();
        public OPMDASHBOARDA()
        {
            InitializeComponent();
        }
        private void OPMDASHBOARDA_Load(object sender, EventArgs e)
        {
            InitCatalogAdmin(null, null);
            OpenContractForm();
        }
        public void GetCatalogvalue(string nodeName)
        {
            //Khởi tạo TreeNode
            treeViewOPM.Nodes.Clear();
            InitCatalogAdmin(null, null);
            if (nodeName == "Contract") return;
            if (!CatalogAdmin.Exist(nodeName))
            {
                MessageBox.Show(string.Format("Không tìm thấy đường dẫn đến nút {0} trên TreeView", nodeName));
                return;
            }
            //Tìm đường đến TreeNode hiện tại
            List<string> list = CatalogAdmin.PathToContractNodeFromCurrentNode(nodeName);
            list.Reverse();
            //Vẽ đường đến TreeNode hiện tại
            treeViewOPM.SelectedNode = treeViewOPM.Nodes[list[0]];
            treeViewOPM.SelectedNode.Expand();
            treeViewOPM.SelectedNode.ForeColor = Color.Blue;
            for (int i = 1; i <= list.Count - 1; i++)
            {
                treeViewOPM.SelectedNode = treeViewOPM.SelectedNode.Nodes[list[i]];
                treeViewOPM.SelectedNode.Expand();
                treeViewOPM.SelectedNode.ForeColor = Color.Blue;
            }
        }
        private int InitCatalogAdmin(TreeNode parentNode, string parent)
        {
            DataSet ds = new DataSet();
            int ret = CatalogAdmin.GetCatalogNodes(ref ds, parent);
            if (0 == ret)
            {
                return 0;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode node = new TreeNode
                {
                    Text = dr["ctlname"].ToString(),
                    Name = dr["ctlID"].ToString()
                };
                string strChildID = dr["ctlID"].ToString();
                if (null == parentNode || null == parent)
                {
                    InitCatalogAdmin(node, strChildID);
                    treeViewOPM.Nodes.Add(node);
                }
                else
                {
                    InitCatalogAdmin(node, strChildID);
                    parentNode.Nodes.Add(node);
                }
            }
            return 1;
        }
        private Form activeForm = null;

        private void OpenChidForm(Form childForm)
        {
            ClearPanel();
            if (null != activeForm) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panContent.Controls.Add(childForm);
            panContent.Tag = childForm;
            //childForm.BringToFront();
            childForm.Show();

        }
        public void ClearPanel()
        {
            for (int ix = panDescription.Controls.Count - 1; ix >= 0; ix--)
            {
                if (panDescription.Controls[ix] is Form) panDescription.Controls[ix].Dispose();
            }
        }
        public void OpenChidForm1(Form childForm)
        {
            ClearPanel();
            panDescription.Controls.Clear();
            childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panDescription.Controls.Add(childForm);
            panDescription.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void treeViewOPM_DoubleClick(object sender, EventArgs e)
        {
            /*OK Important for Communication*/

            /*Check What Label Checked and it's parent Checked*/
            try
            {
                string strNodeID = treeViewOPM.SelectedNode.Name.ToString();
                if (null != treeViewOPM.SelectedNode.Parent)
                {
                    string strParentNodeID = treeViewOPM.SelectedNode.Parent.Name.ToString();
                    //MessageBox.Show(treeView1.SelectedNode.Parent.Text);
                }
                else
                {
                    //MessageBox.Show("No Parent Node");
                }
                string[] temp = strNodeID.Split('_', 2);
                temp[0] += "_";
                /*Get Detail Infor On Database*/
                switch (temp[0])
                {
                    case ConstantVar.ContractType:
                        //Khai báo contractInfoChildForm ứng với IdContract
                        ContractInfoChildForm contractInfoChildForm = new ContractInfoChildForm(temp[1]);
                        contractInfoChildForm.UpdateCatalogPanel = new ContractInfoChildForm.UpdateCatalogDelegate(GetCatalogvalue);
                        //DASHBOAD nhận yêu cầu mở PurchaseOderInfor từ ContractInfoChildForm
                        contractInfoChildForm.RequestDashBoardOpenPOForm = new ContractInfoChildForm.RequestDashBoardOpenChildForm(OpenPOForm);
                        //DASHBOAD nhận yêu cầu mở DescriptionSiteForm từ ContractInfoChildForm
                        contractInfoChildForm.requestDashBoardOpendescriptionForm = new ContractInfoChildForm.RequestDashBoardOpenDescriptionForm(OpenDescription);
                        //Mở ContractInfoChildForm
                        OpenChidForm(contractInfoChildForm);
                        break;
                    case ConstantVar.POType:
                        /*Display PO */
                        PurchaseOderInfor purchaseOderInfor = new PurchaseOderInfor();
                        purchaseOderInfor.UpdateCatalogPanel = new PurchaseOderInfor.UpdateCatalogDelegate(GetCatalogvalue);
                        purchaseOderInfor.po = new DBHandler.PO_Thanh(temp[1]);
                        purchaseOderInfor.contract = new Contract(treeViewOPM.SelectedNode.Parent.Text);
                        //MessageBox.Show(temp[1]);
                        purchaseOderInfor.requestDashBoardOpenNTKTForm = new PurchaseOderInfor.RequestDashBoardOpenNTKTForm(OpenNTKTForm);
                        //purchaseOderInfor.SetValueItemForPO(temp[1]);
                        purchaseOderInfor.requestDaskboardOpenDP = new PurchaseOderInfor.RequestDaskboardOpenDP(OpenDpForm);
                        //Click vao ComfirmPO
                        purchaseOderInfor.requestDashBoardOpenConfirmPOForm = new PurchaseOderInfor.RequestDashBoardOpenConfirmForm(OpenConfirmPOForm);
                        //
                        OpenChidForm(purchaseOderInfor);
                        break;
                    case ConstantVar.DPType:
                        /*Display DP */
                        DeliverPartInforDetail deliverPartInforDetail = new DeliverPartInforDetail();
                        deliverPartInforDetail.UpdateCatalogPanel = new DeliverPartInforDetail.UpdateCatalogDelegate(GetCatalogvalue);
                        OpenChidForm(deliverPartInforDetail);
                        break;
                    case ConstantVar.NTKTType:
                        /*Display NTKT */
                        NTKTInfor nTKTInfor = new NTKTInfor();
                        nTKTInfor.UpdateCatalogPanel = new NTKTInfor.UpdateCatalogDelegate(GetCatalogvalue);
                        nTKTInfor.requestDashBoardPurchaseOderForm = new NTKTInfor.RequestDashBoardPurchaseOderForm(OpenPOForm);
                        //nTKTInfor.setValueItemForNTKT(temp[1]);
                        //Lấy NTKT hiện tại
                        nTKTInfor.ntkt = new NTKT_Thanh(temp[1]);
                        nTKTInfor.po = new DBHandler.PO_Thanh(nTKTInfor.ntkt.Id_po);
                        OpenChidForm(nTKTInfor);
                        break;
                    case ConstantVar.PLType:
                        /*Display PL */
                        PackageListInfor packageListInfor = new PackageListInfor();
                        packageListInfor.UpdateCatalogPanel = new PackageListInfor.UpdateCatalogDelegate(GetCatalogvalue);
                        OpenChidForm(packageListInfor);
                        break;
                    default:
                        Console.WriteLine("Invalid grade");
                        break;
                }
            }
            catch (Exception)
            {

            }
        }
        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "toolStripMenuRefresh")
            {
                OpenContractForm();
            }
            else if (e.ClickedItem.Name == "toolStripMenuNew")
            {
                //Do Something
                PurchaseOderInfor purchaseOderInfor = new PurchaseOderInfor();
                purchaseOderInfor.UpdateCatalogPanel = new PurchaseOderInfor.UpdateCatalogDelegate(GetCatalogvalue);
                OpenChidForm(purchaseOderInfor);
            }
            else if (e.ClickedItem.Name == "toolStripMenuEdit")
            {
                //Do Something
            }
            else
            {
                //Do Something

            }


        }
        void OpenContractForm()
        {
            ContractInfoChildForm contractInfoChildForm = new ContractInfoChildForm
            {
                UpdateCatalogPanel = new ContractInfoChildForm.UpdateCatalogDelegate(GetCatalogvalue),
                RequestDashBoardOpenPOForm = new ContractInfoChildForm.RequestDashBoardOpenChildForm(OpenPOForm),
                requestDashBoardOpendescriptionForm = new ContractInfoChildForm.RequestDashBoardOpenDescriptionForm(OpenDescription)
            };
            OpenChidForm(contractInfoChildForm);
        }
        public void OpenPOForm(string strIDContract, string idPO)
        {
            PurchaseOderInfor purchaseOderInfor = new PurchaseOderInfor();
            purchaseOderInfor.UpdateCatalogPanel = new PurchaseOderInfor.UpdateCatalogDelegate(GetCatalogvalue);

            /*Receipt Request Open Nghiệm Thu Kỹ Thuật Form*/
            purchaseOderInfor.requestDashBoardOpenNTKTForm = new PurchaseOderInfor.RequestDashBoardOpenNTKTForm(OpenNTKTForm);

            /*Receipt Request Open Xác Nhận Đơn Hàng Form*/
            purchaseOderInfor.requestDashBoardOpenConfirmPOForm = new PurchaseOderInfor.RequestDashBoardOpenConfirmForm(OpenConfirmPOForm);

            /**/

            purchaseOderInfor.requestDaskboardOpenDP = new PurchaseOderInfor.RequestDaskboardOpenDP(OpenDpForm);
            purchaseOderInfor.requestDasckboardOpenExcel = new PurchaseOderInfor.RequestDasckboardOpenExcel(OpenExcel);
            ContractInfoChildForm contractInfoChildForm = new ContractInfoChildForm();
            contractInfoChildForm.requestDashBoardOpendescriptionForm = new ContractInfoChildForm.RequestDashBoardOpenDescriptionForm(OpenDescription);
            strIDContract = strIDContract.Replace("Contract_", "");
            purchaseOderInfor.SetTxbIDContract(strIDContract);
            purchaseOderInfor.po = new DBHandler.PO_Thanh(idPO);
            OpenChidForm(purchaseOderInfor);
            return;

        }
        public void OpenNTKTForm(string strKHMS, string strContractID, string strPOID, string strPONumber)
        {
            NTKTInfor nTKTInfor = new NTKTInfor();
            nTKTInfor.requestDashBoardPurchaseOderForm = new NTKTInfor.RequestDashBoardPurchaseOderForm(OpenPOForm);
            nTKTInfor.UpdateCatalogPanel = new NTKTInfor.UpdateCatalogDelegate(GetCatalogvalue);
            nTKTInfor.po = new DBHandler.PO_Thanh(strPOID);
            OpenChidForm(nTKTInfor);
            return;
        }

        public void OpenConfirmPOForm(string strKHMS, string strContractID, string strPOID, string strPONumber)
        {
            ConfirmPOInfor confirmPO = new ConfirmPOInfor();
            confirmPO.SetKHMS(strKHMS);

            strContractID = strContractID.Replace("Contract_", "");
            confirmPO.SetContractID(strContractID);
            confirmPO.SetPOID(strPOID);
            confirmPO.SetPONumber(strPONumber);
            OpenChidForm(confirmPO);
            return;
        }
        public void OpenDescription(string id, DescriptionSiteForm.SetIdSite setIdSite)
        {
            DescriptionSiteForm descriptionSiteForm = new DescriptionSiteForm(id);
            OpenChidForm1(descriptionSiteForm);
            descriptionSiteForm.setIdSite = setIdSite;
        }
        public void OpenExcel()
        {
            HandlerExcel handlerExcel = new HandlerExcel();
            OpenChidForm(handlerExcel);
            return;
        }
        public void OpenDpForm(string idPO, string idContract, String PONumber)
        {
            DeliverPartInforDetail deliverPartInforDetail = new DeliverPartInforDetail();
            PO po = new PO();
            //int retPo = PO.GetObjectPO(idPO, ref po);
            ContractObj contractObj = new ContractObj();
            int retContract = ContractObj.GetObjectContract(idContract, ref contractObj);
            deliverPartInforDetail.setIdPO(idPO);
            deliverPartInforDetail.setIdcontract(idContract);
            deliverPartInforDetail.setKHMS(contractObj.KHMS);
            deliverPartInforDetail.setPoname(PONumber);
            OpenChidForm(deliverPartInforDetail);
            return;
        }
    }
}
