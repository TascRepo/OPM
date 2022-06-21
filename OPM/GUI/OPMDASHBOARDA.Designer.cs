
namespace OPM.GUI
{
    partial class OPMDASHBOARDA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panCatalog = new System.Windows.Forms.Panel();
            this.treeViewOPM = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuNewContract = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewPO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewNTKT = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewDP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewPL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuCreatDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.panContent = new System.Windows.Forms.Panel();
            this.panCatalog.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCatalog
            // 
            this.panCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panCatalog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panCatalog.Controls.Add(this.treeViewOPM);
            this.panCatalog.Location = new System.Drawing.Point(9, 17);
            this.panCatalog.Name = "panCatalog";
            this.panCatalog.Size = new System.Drawing.Size(246, 795);
            this.panCatalog.TabIndex = 1;
            // 
            // treeViewOPM
            // 
            this.treeViewOPM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewOPM.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.treeViewOPM.ContextMenuStrip = this.contextMenuStrip;
            this.treeViewOPM.ItemHeight = 20;
            this.treeViewOPM.LabelEdit = true;
            this.treeViewOPM.Location = new System.Drawing.Point(0, 3);
            this.treeViewOPM.Name = "treeViewOPM";
            this.treeViewOPM.Size = new System.Drawing.Size(243, 537);
            this.treeViewOPM.TabIndex = 0;
            this.treeViewOPM.DoubleClick += new System.EventHandler(this.TreeViewOPM_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuNewContract,
            this.toolStripMenuNewPO,
            this.toolStripMenuNewNTKT,
            this.toolStripMenuNewDP,
            this.toolStripMenuNewPL,
            this.toolStripMenuSave,
            this.toolStripMenuCreatDoc});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(175, 158);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // toolStripMenuNewContract
            // 
            this.toolStripMenuNewContract.Name = "toolStripMenuNewContract";
            this.toolStripMenuNewContract.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewContract.Text = "Tạo mới Hợp đồng";
            // 
            // toolStripMenuNewPO
            // 
            this.toolStripMenuNewPO.Name = "toolStripMenuNewPO";
            this.toolStripMenuNewPO.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewPO.Text = "Tạo mới PO";
            // 
            // toolStripMenuNewNTKT
            // 
            this.toolStripMenuNewNTKT.CheckOnClick = true;
            this.toolStripMenuNewNTKT.Name = "toolStripMenuNewNTKT";
            this.toolStripMenuNewNTKT.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewNTKT.Text = "Tạo mới NTKT";
            // 
            // toolStripMenuNewDP
            // 
            this.toolStripMenuNewDP.Name = "toolStripMenuNewDP";
            this.toolStripMenuNewDP.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewDP.Text = "Tạo mới DP";
            // 
            // toolStripMenuNewPL
            // 
            this.toolStripMenuNewPL.Name = "toolStripMenuNewPL";
            this.toolStripMenuNewPL.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewPL.Text = "Tạo mới PL";
            // 
            // toolStripMenuSave
            // 
            this.toolStripMenuSave.Name = "toolStripMenuSave";
            this.toolStripMenuSave.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuSave.Text = "Save";
            // 
            // toolStripMenuCreatDoc
            // 
            this.toolStripMenuCreatDoc.Name = "toolStripMenuCreatDoc";
            this.toolStripMenuCreatDoc.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuCreatDoc.Text = "Creat Document";
            // 
            // panContent
            // 
            this.panContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panContent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panContent.Location = new System.Drawing.Point(260, 17);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(770, 540);
            this.panContent.TabIndex = 2;
            // 
            // OPMDASHBOARDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 566);
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.panCatalog);
            this.Name = "OPMDASHBOARDA";
            this.Text = "OPMDASHBOARDA";
            this.Load += new System.EventHandler(this.OPMDASHBOARDA_Load);
            this.panCatalog.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panCatalog;
        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.TreeView treeViewOPM;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewContract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewPO;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewNTKT;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCreatDoc;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewDP;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewPL;
    }
}