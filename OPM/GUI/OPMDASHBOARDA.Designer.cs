
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
            this.panHeader = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabContent = new System.Windows.Forms.TabPage();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.panCatalog = new System.Windows.Forms.Panel();
            this.treeViewOPM = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuNewContract = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewPO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewNTKT = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuCreatDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.panContent = new System.Windows.Forms.Panel();
            this.toolStripMenuNewDP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewPL = new System.Windows.Forms.ToolStripMenuItem();
            this.panHeader.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.panCatalog.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHeader
            // 
            this.panHeader.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panHeader.Controls.Add(this.tabControl1);
            this.panHeader.Location = new System.Drawing.Point(7, 8);
            this.panHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(357, 167);
            this.panHeader.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabContent);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 167);
            this.tabControl1.TabIndex = 0;
            // 
            // tabContent
            // 
            this.tabContent.Location = new System.Drawing.Point(4, 37);
            this.tabContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabContent.Name = "tabContent";
            this.tabContent.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabContent.Size = new System.Drawing.Size(362, 126);
            this.tabContent.TabIndex = 0;
            this.tabContent.Text = "Content";
            this.tabContent.UseVisualStyleBackColor = true;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.textBox1);
            this.tabSearch.Controls.Add(this.label1);
            this.tabSearch.Controls.Add(this.btnEnter);
            this.tabSearch.Location = new System.Drawing.Point(4, 37);
            this.tabSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSearch.Size = new System.Drawing.Size(362, 126);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 40);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 31);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type the word ";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(264, 40);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(77, 38);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // panCatalog
            // 
            this.panCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panCatalog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panCatalog.Controls.Add(this.treeViewOPM);
            this.panCatalog.Location = new System.Drawing.Point(13, 167);
            this.panCatalog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panCatalog.Name = "panCatalog";
            this.panCatalog.Size = new System.Drawing.Size(351, 1254);
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
            this.treeViewOPM.Location = new System.Drawing.Point(0, 0);
            this.treeViewOPM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewOPM.Name = "treeViewOPM";
            this.treeViewOPM.Size = new System.Drawing.Size(350, 1250);
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
            this.contextMenuStrip.Size = new System.Drawing.Size(238, 228);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // toolStripMenuNewContract
            // 
            this.toolStripMenuNewContract.Name = "toolStripMenuNewContract";
            this.toolStripMenuNewContract.Size = new System.Drawing.Size(237, 32);
            this.toolStripMenuNewContract.Text = "Tạo mới Hợp đồng";
            // 
            // toolStripMenuNewPO
            // 
            this.toolStripMenuNewPO.Name = "toolStripMenuNewPO";
            this.toolStripMenuNewPO.Size = new System.Drawing.Size(237, 32);
            this.toolStripMenuNewPO.Text = "Tạo mới PO";
            // 
            // toolStripMenuNewNTKT
            // 
            this.toolStripMenuNewNTKT.CheckOnClick = true;
            this.toolStripMenuNewNTKT.Name = "toolStripMenuNewNTKT";
            this.toolStripMenuNewNTKT.Size = new System.Drawing.Size(237, 32);
            this.toolStripMenuNewNTKT.Text = "Tạo mới NTKT";
            // 
            // toolStripMenuSave
            // 
            this.toolStripMenuSave.Name = "toolStripMenuSave";
            this.toolStripMenuSave.Size = new System.Drawing.Size(237, 32);
            this.toolStripMenuSave.Text = "Save";
            // 
            // toolStripMenuCreatDoc
            // 
            this.toolStripMenuCreatDoc.Name = "toolStripMenuCreatDoc";
            this.toolStripMenuCreatDoc.Size = new System.Drawing.Size(237, 32);
            this.toolStripMenuCreatDoc.Text = "Creat Document";
            // 
            // panContent
            // 
            this.panContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panContent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panContent.Location = new System.Drawing.Point(373, 8);
            this.panContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(1474, 1411);
            this.panContent.TabIndex = 2;
            // 
            // toolStripMenuNewDP
            // 
            this.toolStripMenuNewDP.Name = "toolStripMenuNewDP";
            this.toolStripMenuNewDP.Size = new System.Drawing.Size(237, 32);
            this.toolStripMenuNewDP.Text = "Tạo mới DP";
            // 
            // toolStripMenuNewPL
            // 
            this.toolStripMenuNewPL.Name = "toolStripMenuNewPL";
            this.toolStripMenuNewPL.Size = new System.Drawing.Size(237, 32);
            this.toolStripMenuNewPL.Text = "Tạo mới PL";
            // 
            // OPMDASHBOARDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 1011);
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.panCatalog);
            this.Controls.Add(this.panHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OPMDASHBOARDA";
            this.Text = "OPMDASHBOARDA";
            this.Load += new System.EventHandler(this.OPMDASHBOARDA_Load);
            this.panHeader.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.panCatalog.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.Panel panCatalog;
        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.TreeView treeViewOPM;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewContract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewPO;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewNTKT;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCreatDoc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabContent;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewDP;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewPL;
    }
}