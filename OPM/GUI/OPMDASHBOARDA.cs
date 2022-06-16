﻿using OPM.DBHandler;
using OPM.ExcelHandler;
using OPM.OPMEnginee;
using OPM.OPMWordHandler;
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
        public int backSiteFormStatus;
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
        public List<SiteObj> Sites { get; set; } = new List<SiteObj>();
        public ContractObj Contract { get; set; } = new ContractObj();
        public List<ContractObj> Contracts { get; set; } = new List<ContractObj>();
        public POObj Po { get; set; } = new POObj();
        public List<POObj> Pos { get; set; } = new List<POObj>();
        public NTKTObj Ntkt { get; set; } = new NTKTObj();
        public List<NTKTObj> Ntkts { get; set; } = new List<NTKTObj>();
        public DeliveryPlanObj DeliveryPlan = new DeliveryPlanObj();
        public List<DeliveryPlanObj> DeliveryPlans { get; set; } = new List<DeliveryPlanObj>();
        public DPObj Dp { get; set; } = new DPObj();
        public List<DPObj> Dps { get; set; } = new List<DPObj>();
        public PLObj Pl { get; set; } = new PLObj();
        public List<PLObj> Pls { get; set; } = new List<PLObj>();
        public DeviceObj Device { get; set; } = new DeviceObj();
        public List<DeviceObj> Devices { get; set; } = new List<DeviceObj>();

        public OPMDASHBOARDA()
        {
            InitializeComponent();
        }
        private void OPMDASHBOARDA_Load(object sender, EventArgs e)
        {
            CurrentNodeName = "Contract_" + (new ContractObj()).ContractId;
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
                        OpmWordHandler.Temp3_CreatPOConfirm(temp[1]);
                        OpmWordHandler.Temp4_CreatPOPerformanceGuarantee(temp[1]);
                        OpmWordHandler.Temp5_CreatPOAdvanceGuarantee(temp[1]);
                        OpmWordHandler.Temp6_CreatPOAdvanceReques(temp[1]);
                        OpmExcelHandler.Temp7_CreatPODistributionTable(temp[1]);
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
                    if (DPObj.DPExist(temp[1]))
                    {
                        OpmExcelHandler.Temp12_CreatedbyOPM_DP(temp[1]);
                        OpmExcelHandler.Temp13_ExportRequestForm_ANSV(temp[1]);
                        OpmExcelHandler.Temp14_CreatedbyANSV_DP(temp[1]);
                        OpmExcelHandler.Temp16_ExportRequestForm_VNPTTech(temp[1]);
                    }
                    else
                    {
                        MessageBox.Show(string.Format(@"Không có DP số '{0}'", temp[1]));
                    }
                    break;
                case "NTKT":
                    if (NTKTObj.NTKTExist(temp[1]))
                    {
                        OpmWordHandler.Temp08_NTKTRequest(temp[1]);
                        OpmWordHandler.Temp09_BBKTKT(temp[1]);
                        OpmWordHandler.Temp10_CNBQPM(temp[1]);
                        OpmWordHandler.Temp11_BBNTKT(temp[1]);
                    }
                    else
                    {
                        MessageBox.Show(string.Format(@"Không có NTKT số '{0}'", temp[1]));
                    }
                    break;
                case "PL":
                    if (PLObj.PLExist(temp[1]))
                    {
                        //OpmWordHandler.Temp18_GoodsDeliveryRecord(temp[1]);
                        OpmWordHandler.Temp19_QualityInspectionCertificateInFactory(temp[1]);
                    }
                    else
                    {
                        MessageBox.Show(string.Format(@"Không có NTKT số '{0}'", temp[1]));
                    }
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
                        if (POObj.PODelete(temp[1]) > 0)
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
                        if (DPObj.DPDelete(temp[1]) > 0)
                        {
                            MessageBox.Show("Xoá thành công DP số " + temp[1]);
                            CurrentNodeName = "DP_" + (new DPObj()).DPId;
                        }
                        else
                        {
                            MessageBox.Show("Xoá thất bại vì chưa có NTKT số " + temp[1]);
                        }
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
                        if (PLObj.PLDelete(temp[1]) > 0)
                        {
                            MessageBox.Show("Xoá thành công PL số " + temp[1]);
                            CurrentNodeName = "PL_" + (new PLObj()).PLId;
                        }
                        else
                        {
                            MessageBox.Show("Xoá thất bại vì chưa có PL số " + temp[1]);
                        }

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
                        if (Contract.ContractInsert(CurrentNodeId) > 0)
                        {
                            MessageBox.Show("Tạo mới thành công hợp đồng số " + CurrentNodeId);
                            CurrentNodeName = "Contract_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Tạo mới thất bại vì đã có hợp đồng số " + CurrentNodeId);
                            CurrentNodeName = "Contract_" + (new ContractObj()).ContractId; ;
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
                    if (!DPObj.DPExist(temp[1]))
                    {
                        if (Dp.DPInsert(CurrentNodeId) > 0)
                        {
                            MessageBox.Show("Tạo mới thành công DP số " + CurrentNodeId);
                            CurrentNodeName = "DP_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Tạo mới thất bại vì đã có DP số " + CurrentNodeId);
                            CurrentNodeName = "DP_" + (new DPObj()).DPId;
                        }
                    }
                    else
                    {
                        if (Dp.DPUpdate(CurrentNodeId, temp[1]) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công DP số " + CurrentNodeId);
                            CurrentNodeName = "DP_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại vì đã có DP số " + CurrentNodeId);
                        }
                    }
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
                    if (!PLObj.PLExist(temp[1]))
                    {
                        if (Pl.PLInsert(CurrentNodeId) > 0)
                        {
                            MessageBox.Show("Tạo mới thành công PL số " + CurrentNodeId);
                            CurrentNodeName = "PL_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Tạo mới thất bại vì đã có PL số " + CurrentNodeId);
                            CurrentNodeName = "PL_" + (new PLObj()).PLId;
                        }
                    }
                    else
                    {
                        if (Pl.PLUpdate(CurrentNodeId, temp[1]) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công PL số " + CurrentNodeId);
                            CurrentNodeName = "PL_" + CurrentNodeId;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại vì đã có PL số " + CurrentNodeId);
                        }
                    }

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
                    Contract = new ContractObj(temp[1]);
                    SiteA = new SiteObj(Contract.SiteId);
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
                    POInfo pOInfo = new POInfo();
                    OpenChildForm(pOInfo);
                    break;
                case "DP":
                    Dp = new DPObj(temp[1]);
                    if (DPObj.DPExist(temp[1]))
                    {
                        Po.POId = Dp.POId;
                        Contract.ContractId = Po.ContractId;
                    }
                    else
                    {
                        Dp.POId = Po.POId;
                    }
                    Text = string.Format(@"Hợp đồng số {2} - {1} - DP {0}", Dp.DPId, Po.POName, Contract.ContractId);
                    DPInfo dPInfor = new DPInfo();
                    OpenChildForm(dPInfor);
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
                    Text = string.Format(@"Hợp đồng số {2} - {1} - Đợt NTKT {0}", Ntkt.NTKTPhase, Po.POName, Contract.ContractId);
                    NTKTInfo nTKTInfor = new NTKTInfo();
                    OpenChildForm(nTKTInfor);
                    break;
                case "PL":
                    Pl = new PLObj(temp[1]);
                    if (NTKTObj.NTKTExist(temp[1]))
                    {
                        Dp.DPId = Pl.DPId;
                        Po.POId = Dp.POId;
                        Contract.ContractId = Po.ContractId;
                    }
                    else
                    {
                        Pl.DPId = Dp.DPId;
                    }
                    Text = string.Format(@"Hợp đồng số {2} - {1} - DP {3} - PL {0}", Pl.VNPTId, Po.POName, Contract.ContractId, Dp.DPId);
                    PLInfo plInfor = new PLInfo();
                    OpenChildForm(plInfor);
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
            if (currentNodeName == "DP_" + (new DPObj()).DPId)
            {
                row["ctlName"] = "DP " + Dp.DPId;
                row["ctlParent"] = "PO_" + Po.POId;
                table.Rows.Add(row);
            }
            if (currentNodeName == "PL_" + (new PLObj()).PLId)
            {
                row["ctlName"] = "PL " + Pl.VNPTId;
                row["ctlParent"] = "DP_" + Dp.DPId;
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
                if (Po.POExist())
                {
                    CurrentNodeName = "DP_" + (new DPObj()).DPId;
                }
            }
            else if (e.ClickedItem.Name == "toolStripMenuNewPL")
            {
                if (Dp.DPExist())
                {
                    CurrentNodeName = "PL_" + (new PLObj()).DPId;
                }
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
            if (backSiteFormStatus == 0)
            {
                Text = string.Format("Hợp đồng số {0}: Bảng lựa chọn chi tiết bên A", Contract.ContractId);

            }
            else
            {
                Text = string.Format("Hợp đồng số {0}: Bảng lựa chọn chi tiết các đơn vị nhận hàng VNPTId", Contract.ContractId);
            }
            SiteInfo siteForm = new SiteInfo(idSite);
            SiteA = new SiteObj(idSite);
            OpenChildForm(siteForm);
        }
        public void OpenGoodsForm()
        {
            GoodsInfo goodsForm = new GoodsInfo();
            Text = string.Format("Hợp đồng số {0}: Bảng hàng hoá", Contract.ContractId);
            OpenChildForm(goodsForm);
        }
        public void OpenDeliveryPlanForm()
        {
            DeliveryPlanInfo deliveryPlanForm = new DeliveryPlanInfo();
            Text = string.Format("Kê hoạch giao hàng của PO số {0} của hợp đồng số {1}", Po.POName, Contract.ContractId);
            DeliveryPlan.POId = Po.POId;
            OpenChildForm(deliveryPlanForm);
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
        public void OpenDPForm()
        {
            DPInfo dPInfo = new DPInfo();
            Text = string.Format("Hợp đồng số {0} - {1} - {2}", Contract.ContractId, Po.POName, Dp.DPId);
            Dp.POId = Po.POId;
            CurrentNodeName = "DP_" + Dp.DPId;
            OpenChildForm(dPInfo);
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
