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
        public ContractObj Contract { get; set; } = new ContractObj();
        public POObj Po { get; set; } = new POObj();
        public NTKTObj Ntkt { get; set; } = new NTKTObj();
        public int TempStatus { get; set; } = 0;
        //TempStatus = 0 : Đang ở Form tạo mới hợp đồng
        //TempStatus = 1 : Đang ở Form chỉnh sửa hợp đồng
        //TempStatus = 3 : Đang ở Form tạo mới PO
        //TempStatus = 4 : Đang ở Form tạo mới PO
        //TempStatus = 6 : Đang ở Form tạo mới NTKT
        //TempStatus = 7 : Đang ở Form chỉnh sửa NTKT
        //TempStatus = 0 : Đang ở Form 
        //TempStatus = 0 : Đang ở Form 
        //TempStatus = 0 : Đang ở Form 

        public OPMDASHBOARDA()
        {
            InitializeComponent();
        }
        private void OPMDASHBOARDA_Load(object sender, EventArgs e)
        {
            OpenContractForm();
        }
        public void InitCatalogByNodeName(string nodeName)
        {
            treeViewOPM.Nodes.Clear();
            DataTable table = CatalogAdmin.Table();
            DataRow row = table.NewRow();
            row["ctlId"] = nodeName;
            string[] temp = nodeName.Split('_', 2);
            switch (temp[0])
            {
                case "Contract":
                    if (!ContractObj.ContractExist(temp[1]))
                    {
                        row["ctlName"] = temp[1];
                        table.Rows.Add(row);
                    }
                    break;
                case "PO":
                    if (!POObj.POExist(temp[1]))
                    {
                        row["ctlName"] = Po.POName;
                        row["ctlParent"] = "Contract_" + Contract.ContractId;
                        table.Rows.Add(row);
                    }
                    break;
                case "DP":
                    break;
                case "NTKT":
                    if (!NTKTObj.NTKTExist(temp[1]))
                    {
                        row["ctlName"] = "NTKT" + Ntkt.NTKTPhase;
                        row["ctlParent"] = "PO_" + Po.POId;
                        table.Rows.Add(row);
                    }
                    break;
                case "PL":
                    break;
                default:
                    MessageBox.Show(string.Format("Không tìm thấy đường dẫn đến nút {0} trên TreeView", nodeName));
                    break;
            }
            InitCatalogAdmin(null, null, table);
            List<string> list = CatalogAdmin.PathToContractNodeFromCurrentNode(nodeName, table);
            list.Reverse();
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
        private void InitCatalogAdmin(TreeNode parentNode, string parent, DataTable table)
        {
            DataRow[] ds = table.Select(string.Format(@"ctlparent is null"), "ctlname");
            if (parent != null) ds = table.Select(string.Format(@"ctlparent = '{0}'", parent), "ctlname");
            if (ds.Length < 1) return;
            foreach (DataRow dr in ds)
            {
                TreeNode node = new TreeNode
                {
                    Text = dr["ctlname"].ToString(),
                    Name = dr["ctlID"].ToString()
                };
                string strChildID = dr["ctlID"].ToString();
                if (null == parentNode || null == parent)
                {
                    InitCatalogAdmin(node, strChildID, table);
                    treeViewOPM.Nodes.Add(node);
                }
                else
                {
                    InitCatalogAdmin(node, strChildID, table);
                    parentNode.Nodes.Add(node);
                }
            }
        }
        public void SetNameOfSelectNode(string nameOfNode)
        {
            treeViewOPM.SelectedNode.Text = nameOfNode;
        }
        public void SetIdSiteA(string vl)
        {
            Contract.ContractSiteId = vl;
        }
        public void TreeViewOPM_DoubleClick(object sender, EventArgs e)
        {
            treeViewOPM.Tag = treeViewOPM.SelectedNode; //Lưu lại Node được chọn
            string[] temp = treeViewOPM.SelectedNode.Name.ToString().Split('_', 2);
            /*Get Detail Infor On Database*/
            switch (temp[0])
            {
                case "Contract":
                    TempStatus = 1;//Đang ở Form chỉnh sửa hợp đồng
                    Contract.ContractId = temp[1];
                    OpenContractForm();
                    break;
                case "PO":
                    TempStatus = 4;//Đang ở Form PO có sẵn
                    Po.POId = temp[1];
                    Contract.ContractId = Po.ContractId;
                    OpenPOForm();
                    break;
                case "DP":
                    /*Display DP */
                    DeliverPartInforDetail deliverPartInforDetail = new DeliverPartInforDetail();
                    //                        deliverPartInforDetail.UpdateCatalogPanel = new DeliverPartInforDetail.UpdateCatalogDelegate(InitCatalogByNodeName);
                    OpenChildForm(deliverPartInforDetail);
                    break;
                case "NTKT":
                    TempStatus = 7;//Đang ở Form chỉnh sửa NTKT
                    Ntkt = new NTKTObj(temp[1]);
                    Po = new POObj(Ntkt.POId);
                    Contract = new ContractObj(Po.ContractId);
                    OpenNTKTForm();
                    break;
                case "PL":
                    /*Display PL */
                    PackageListInfor packageListInfor = new PackageListInfor();
                    packageListInfor.UpdateCatalogPanel = new PackageListInfor.UpdateCatalogDelegate(InitCatalogByNodeName);
                    OpenChildForm(packageListInfor);
                    break;
                default:
                    MessageBox.Show("Invalid grade");
                    break;
            }
        }
        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "toolStripMenuNewContract")
            {
                TempStatus = 0;//Đang ở Form tạo mới Hợp đồng
                Contract = new ContractObj();
                OpenContractForm();
            }
            else if (e.ClickedItem.Name == "toolStripMenuNew")
            {
                if (Contract.ContractExist())
                {
                    TempStatus = 3;//Chuyển sang Form tạo mới PO
                    OpenPOForm();
                }
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
        public void OpenSiteAForm(string idSite)
        {
            SiteInfo siteForm = new SiteInfo
            {
                setStringValue = new SiteInfo.SetStringValue(SetIdSiteA),
                IdSite = idSite
            };
            OpenChildForm(siteForm);
        }
        public void OpenGoodsForm()
        {
            GoodsInfo goodsForm = new GoodsInfo();
            Text = string.Format("Hợp đồng số {0}: Bảng hàng hoá", Contract.ContractId);
            OpenChildForm(goodsForm);
        }
        public void OpenContractForm()
        {
            ContractInfo contractInfo = new ContractInfo();
            Text = string.Format("Hợp đồng số {0}", Contract.ContractId);
            InitCatalogByNodeName("Contract_" + Contract.ContractId);
            OpenChildForm(contractInfo);
        }
        public void OpenPOForm()
        {
            PurchaseOderInfor purchaseOderInfor = new PurchaseOderInfor();
            Text = string.Format("Hợp đồng số {0} - {1}", Contract.ContractId, Po.POName);
            if (TempStatus == 3) Po = new POObj();  //Ở Form tạo mới PO
            Po.ContractId = Contract.ContractId;
            InitCatalogByNodeName("PO_" + Po.POId);
            OpenChildForm(purchaseOderInfor);
        }
        public void OpenNTKTForm()
        {
            NTKTInfor nTKTInfor = new NTKTInfor();
            Text = string.Format(@"Hợp đồng số {2} - {1} - Đợt NTKT{0}", Ntkt.NTKTPhase, Po.POName, Contract.ContractId);
            if (TempStatus == 6) Ntkt = new NTKTObj();  //Ở Form tạo mới NTKT
            Ntkt.POId = Po.POId;
            InitCatalogByNodeName("NTKT_" + Ntkt.NTKTId);
            OpenChildForm(nTKTInfor);
        }
        public void OpenDpForm(string idPO, string idContract, String PONumber)
        {
            DeliverPartInforDetail deliverPartInforDetail = new DeliverPartInforDetail();
            POObj po = new POObj();
            //int retPo = PO.GetObjectPO(idPO, ref po);
            ContractObj contractObj = new ContractObj();
            //int retContract = Contract.GetObjectContract(idContract, ref contractObj);
            deliverPartInforDetail.setIdPO(idPO);
            deliverPartInforDetail.setIdcontract(idContract);
            deliverPartInforDetail.setKHMS(contractObj.ContractShoppingPlan);
            deliverPartInforDetail.setPoname(PONumber);
            OpenChildForm(deliverPartInforDetail);
            return;
        }
        void OpenChildForm(Form childForm)
        {
            ClearPanel();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panContent.Controls.Add(childForm);
            panContent.Tag = childForm;
            childForm.Tag = this;
            childForm.Show();
        }
        public void ClearPanel()
        {
            foreach (Control item in panContent.Controls)
            {
                item.Dispose();
            }
        }
    }
}
