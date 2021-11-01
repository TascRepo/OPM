using OPM.OPMEnginee;
using OPM.WordHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OPM.GUI
{
    
    public partial class OPMDASHBOARDA : Form
    {
        private string currentNodeName;
        public string CurrentNodeId;
        public string CurrentNodeName 
        {
            get => currentNodeName;
            set
            {
                currentNodeName = value;
                InitByCurrentNodeName(value);
            }
        }
        public SiteObj SiteA { get; set; } = new SiteObj();
        public ContractObj Contract { get; set; } = new ContractObj();
        public POObj Po { get; set; } = new POObj();
        public NTKTObj Ntkt { get; set;} = new NTKTObj();
        public OPMDASHBOARDA()
        {
            InitializeComponent();
        }
        private void OPMDASHBOARDA_Load(object sender, EventArgs e)
        {
            CurrentNodeName= "Contract_" + (new ContractObj()).ContractId;
        }
        public void CreatDocumentByNodeName()
        {
            string[] temp = CurrentNodeName.Split('_', 2);
            switch (temp[0])
            {
                case "Contract":
                    if (ContractObj.ContractExist(temp[1]))
                    {
                        OpmWordHandler.Temp1_CreatContractGuarantee(temp[1]);
                    }
                    else
                    {
                        MessageBox.Show(string.Format(@"Không có hợp đồng số '{0}'", temp[1]));
                    }
                    break;
                case "PO":
                    if (POObj.POExist(temp[1]))
                    {
                        //Tạo mẫu 7
                        OpmWordHandler.Temp3_CreatPOConfirm(temp[1]);
                        OpmWordHandler.Temp4_CreatPOPerformanceGuarantee(temp[1]);
                        OpmWordHandler.Temp5_CreatPOAdvanceGuarantee(temp[1]);
                        OpmWordHandler.Temp6_CreatPOAdvanceReques(temp[1]);
                        OpmWordHandler.Temp23_CNCL_TongHop(temp[1]);
                        OpmWordHandler.Temp24_CNCLNMTongHop(temp[1]);
                        OpmWordHandler.Temp36_BBNTLicense(temp[1]);
                        OpmWordHandler.Temp37_BBXNCDLicense(temp[1]);
                    }
                    else
                    {
                        MessageBox.Show(string.Format(@"Không có PO số '{0}'", temp[1]));
                    }
                    break;
                case "DP":
                    break;
                case "NTKT":
                    OpmWordHandler.Temp08_NTKTRequest(temp[1]);
                    OpmWordHandler.Temp09_BBKTKT(temp[1]);
                    OpmWordHandler.Temp10_CNBQPM(temp[1]);
                    OpmWordHandler.Temp11_BBNTKT(temp[1]);
                    break;
                case "PL":
                    break;
                default:
                    MessageBox.Show("Invalid grade");
                    break;
            }
        }
        public void DeleteSQLByNodeName()
        {
            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa '{0}'", CurrentNodeName), "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string[] temp = CurrentNodeName.Split('_', 2);
                switch (temp[0])
                {
                    case "Contract":
                        if (ContractObj.ContractDelete(temp[1]) > 0)
                        {
                            MessageBox.Show("Xoá thành công hợp đồng số " + temp[1]);
                            CurrentNodeName = "Contract_" + (new ContractObj()).ContractId;
                        }
                        else
                        {
                            MessageBox.Show("Xoá thất bại vì chưa có hợp đồng số " + temp[1]);
                        }
                        break;
                    case "PO":
                        if (POObj.PODelete(temp[1])>0)
                        {
                            MessageBox.Show("Xoá thành công PO số " + temp[1]);
                            CurrentNodeName = "PO_" + (new POObj()).POId;
                        }
                        else
                        {
                            MessageBox.Show("Xoá thất bại vì chưa có PO số " + temp[1]);
                        }
                        break;
                    case "DP":
                        break;
                    case "NTKT":
                        if (NTKTObj.NTKTDelete(temp[1]) > 0)
                        {
                            MessageBox.Show("Xoá thành công NTKT số " + temp[1]);
                            CurrentNodeName = "NTKT_" + (new NTKTObj()).NTKTId;
                        }
                        else
                        {
                            MessageBox.Show("Xoá thất bại vì chưa có NTKT số " + temp[1]);
                        }
                        break;
                    case "PL":
                        break;
                    default:
                        MessageBox.Show("Invalid grade");
                        break;
                }
            }
        }
        public void SaveSQLByNodeName()
        {
            string[] temp = CurrentNodeName.Split('_', 2);
            switch (temp[0])
            {
                case "Contract":
                    if (!ContractObj.ContractExist(temp[1]))
                    {
                        if(Contract.ContractInsert(CurrentNodeId) >0)
                        {
                            MessageBox.Show("Tạo mới thành công hợp đồng số " + CurrentNodeId);
                            CurrentNodeName = "Contract_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Tạo mới thất bại vì đã có hợp đồng số " + CurrentNodeId);
                            CurrentNodeName = "Contract_"+(new ContractObj()).ContractId; ;
                        }
                    }
                    else
                    {
                        if (Contract.ContractUpdate(CurrentNodeId, temp[1]) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công hợp đồng số " + CurrentNodeId);
                            CurrentNodeName = "Contract_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại vì đã có hợp đồng số " + CurrentNodeId);
                        }
                    }
                    break;
                case "PO":
                    if (!POObj.POExist(temp[1]))
                    {
                        if (Po.POInsert(CurrentNodeId) > 0)
                        {
                            MessageBox.Show("Tạo mới thành công PO số " + CurrentNodeId);
                            CurrentNodeName = "PO_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Tạo mới thất bại vì đã có PO số " + CurrentNodeId);
                            CurrentNodeName = "PO_" + (new POObj()).POId;
                        }
                    }
                    else
                    {
                        if (Po.POUpdate(CurrentNodeId, temp[1]) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công PO số " + CurrentNodeId);
                            CurrentNodeName = "PO_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại vì đã có PO số " + CurrentNodeId);
                        }
                    }
                    break;
                case "DP":
                    break;
                case "NTKT":
                    if (!NTKTObj.NTKTExist(temp[1]))
                    {
                        if (Ntkt.NTKTInsert(CurrentNodeId) > 0)
                        {
                            MessageBox.Show("Tạo mới thành công NTKT số " + CurrentNodeId);
                            CurrentNodeName = "NTKT_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Tạo mới thất bại vì đã có NTKT số " + CurrentNodeId);
                            CurrentNodeName = "NTKT_" + (new NTKTObj()).NTKTId;
                        }
                    }
                    else
                    {
                        if (Ntkt.NTKTUpdate(CurrentNodeId, temp[1]) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công NTKT số " + CurrentNodeId);
                            CurrentNodeName = "NTKT_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại vì đã có NTKT số " + CurrentNodeId);
                        }
                    }
                    break;
                case "PL":
                    break;
                default:
                    MessageBox.Show("Invalid grade");
                    break;
            }
        }
        void OpenChildFormByNodeName(string currentNodeName) 
        {
            string[] temp = currentNodeName.Split('_', 2);
            switch (temp[0])
            {
                case "Contract":
                    Contract =new ContractObj(temp[1]);
                    Text = string.Format("Hợp đồng số {0}", temp[1]);
                    ContractInfo contractInfo = new ContractInfo();
                    OpenChildForm(contractInfo);
                    break;
                case "PO":
                    Po = new POObj(temp[1]);
                    if (POObj.POExist(temp[1]))
                    {
                        Contract.ContractId = Po.ContractId;
                    }
                    else
                    {
                        Po.ContractId = Contract.ContractId;
                    }
                    Text = string.Format("Hợp đồng số {0} - {1}", Po.ContractId, Po.POName);
                    POInfo purchaseOderInfor = new POInfo();
                    OpenChildForm(purchaseOderInfor);
                    break;
                case "DP":
                    DPInfo deliverPartInforDetail = new DPInfo();
                    OpenChildForm(deliverPartInforDetail);
                    break;
                case "NTKT":
                    Ntkt = new NTKTObj(temp[1]);
                    if (NTKTObj.NTKTExist(temp[1]))
                    {
                        Po.POId = Ntkt.POId;
                        Contract.ContractId = Ntkt.ContractId;
                    }
                    else
                    {
                        Ntkt.POId = Po.POId;
                    }
                    Text = string.Format(@"Hợp đồng số {2} - {1} - Đợt NTKT{0}", Ntkt.NTKTPhase, Po.POName, Contract.ContractId);
                    NTKTInfo nTKTInfor = new NTKTInfo();
                    OpenChildForm(nTKTInfor);
                    break;
                case "PL":
                    PLInfo packageListInfor = new PLInfo();
                    OpenChildForm(packageListInfor);
                    break;
                default:
                    MessageBox.Show("Invalid grade");
                    break;
            }
        }
        void InitByCurrentNodeName(string currentNodeName)
        {
            DataTable table = CatalogAdmin.Table();
            DataRow row = table.NewRow();
            row["ctlId"] = currentNodeName;
            if (currentNodeName == "Contract_" + (new ContractObj()).ContractId)
            {
                row["ctlName"] = (new ContractObj()).ContractId;
                table.Rows.Add(row);
            }
            if (currentNodeName == "PO_" + (new POObj()).POId)
            {
                row["ctlName"] = (new POObj()).POName;
                row["ctlParent"] = "Contract_" + Contract.ContractId;
                table.Rows.Add(row);
            }
            if (currentNodeName == "NTKT_" + (new NTKTObj()).NTKTId)
            {
                row["ctlName"] = "NTKT " + Ntkt.NTKTPhase;
                row["ctlParent"] = "PO_" + Po.POId;
                table.Rows.Add(row);
            }
            treeViewOPM.Nodes.Clear();
            InitCatalogAdmin(null, null, table);
            List<string> list = CatalogAdmin.PathToContractNodeFromCurrentNode(currentNodeName, table);
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
            OpenChildFormByNodeName(currentNodeName);
        }
        private void InitCatalogAdmin(TreeNode parentNode, string parent, DataTable table)
        {
            DataRow[] rows = table.Select(string.Format(@"ctlparent is null"), "ctlname");
            if (parent != null) rows = table.Select(string.Format(@"ctlparent = '{0}'", parent), "ctlname");
            if (rows.Length < 1) return;
            foreach (DataRow dr in rows)
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
            Contract.SiteId = vl;
        }
        public void TreeViewOPM_DoubleClick(object sender, EventArgs e)
        {
            CurrentNodeName = treeViewOPM.SelectedNode.Name;
        }
        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string[] temp = CurrentNodeName.Split('_', 2);
            if (e.ClickedItem.Name == "toolStripMenuNewContract")
            {
                CurrentNodeName = "Contract_" + (new ContractObj()).ContractId;
            }
            else if (e.ClickedItem.Name == "toolStripMenuNewPO")
            {
                if (Contract.ContractExist())
                {
                    CurrentNodeName = "PO_" + (new POObj()).POId;
                }
                else
                {
                    MessageBox.Show(string.Format("Vẫn chưa lưu hợp đồng số {0}", Contract.ContractId), "Thông báo");
                }
            }
            else if (e.ClickedItem.Name == "toolStripMenuNewNTKT")
            {
                if (Po.POExist())
                {
                    CurrentNodeName = "NTKT_" + (new NTKTObj()).NTKTId;
                }
            }
            else if (e.ClickedItem.Name == "toolStripMenuNewDP")
            {
                //Do Something
            }
            else if (e.ClickedItem.Name == "toolStripMenuNewPL")
            {
                //Do Something
            }
            else if (e.ClickedItem.Name == "toolStripMenuSave")
            {
                SaveSQLByNodeName();
            }
            else if (e.ClickedItem.Name == "toolStripMenuCreatDoc")
            {
                CreatDocumentByNodeName();
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
                SiteId = idSite
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
            OpenChildForm(contractInfo);
        }
        public void OpenPOForm()
        {
            POInfo purchaseOderInfor = new POInfo();
            Text = string.Format("Hợp đồng số {0} - {1}", Contract.ContractId, Po.POName);
            Po.ContractId = Contract.ContractId;
            CurrentNodeName = "PO_" + Po.POId; 
            OpenChildForm(purchaseOderInfor);
        }
        public void OpenNTKTForm()
        {
            NTKTInfo nTKTInfor = new NTKTInfo();
            Text = string.Format(@"Hợp đồng số {2} - {1} - Đợt NTKT{0}", Ntkt.NTKTPhase, Po.POName, Contract.ContractId);
            Ntkt.POId = Po.POId;
            CurrentNodeName = "NTKT_" + Ntkt.NTKTId; 
            OpenChildForm(nTKTInfor);
        }
        public void OpenDpForm(string idPO, string idContract, String PONumber)
        {
            DPInfo deliverPartInforDetail = new DPInfo();
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
