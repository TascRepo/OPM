
namespace OPM.GUI
{
    partial class DeliveryPlanInfo
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
            this.dtgDeliveryPlan = new System.Windows.Forms.DataGridView();
            this.buttonAddProvinceId = new System.Windows.Forms.Button();
            this.textBoxDeliveryPlanQuantity = new System.Windows.Forms.TextBox();
            this.comboBoxVNPTId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerDeliveryPlanDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDeliveryPlanVNPTIdTotalQuantity = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.dtpDeliveryPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeliveryPlanQuantity = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtVNPTId = new System.Windows.Forms.TextBox();
            this.txtDeliveryPlanId = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemainingPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtRemainingContractGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtContractGoodsQuantity = new System.Windows.Forms.TextBox();
            this.buttonDeliveryPlanDataTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDeliveryPlan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgDeliveryPlan
            // 
            this.dtgDeliveryPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDeliveryPlan.Location = new System.Drawing.Point(9, 11);
            this.dtgDeliveryPlan.Name = "dtgDeliveryPlan";
            this.dtgDeliveryPlan.RowHeadersWidth = 62;
            this.dtgDeliveryPlan.RowTemplate.Height = 25;
            this.dtgDeliveryPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDeliveryPlan.Size = new System.Drawing.Size(357, 507);
            this.dtgDeliveryPlan.TabIndex = 0;
            this.dtgDeliveryPlan.SelectionChanged += new System.EventHandler(this.dtgDeliveryPlan_SelectionChanged);
            // 
            // buttonAddProvinceId
            // 
            this.buttonAddProvinceId.Location = new System.Drawing.Point(279, 40);
            this.buttonAddProvinceId.Name = "buttonAddProvinceId";
            this.buttonAddProvinceId.Size = new System.Drawing.Size(91, 24);
            this.buttonAddProvinceId.TabIndex = 1;
            this.buttonAddProvinceId.Text = "Thêm VNPT tỉnh (thành)";
            this.buttonAddProvinceId.UseVisualStyleBackColor = true;
            this.buttonAddProvinceId.Click += new System.EventHandler(this.buttonAddProvinceId_Click);
            // 
            // textBoxDeliveryPlanQuantity
            // 
            this.textBoxDeliveryPlanQuantity.Location = new System.Drawing.Point(120, 83);
            this.textBoxDeliveryPlanQuantity.Name = "textBoxDeliveryPlanQuantity";
            this.textBoxDeliveryPlanQuantity.Size = new System.Drawing.Size(92, 23);
            this.textBoxDeliveryPlanQuantity.TabIndex = 3;
            this.textBoxDeliveryPlanQuantity.TextChanged += new System.EventHandler(this.textBoxDeliveryPlanQuantity_TextChanged);
            // 
            // comboBoxVNPTId
            // 
            this.comboBoxVNPTId.FormattingEnabled = true;
            this.comboBoxVNPTId.Location = new System.Drawing.Point(120, 40);
            this.comboBoxVNPTId.Name = "comboBoxVNPTId";
            this.comboBoxVNPTId.Size = new System.Drawing.Size(92, 23);
            this.comboBoxVNPTId.TabIndex = 4;
            this.comboBoxVNPTId.SelectedIndexChanged += new System.EventHandler(this.comboBoxVNPTId_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đơn vị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Aqua;
            this.groupBox1.Controls.Add(this.buttonAddProvinceId);
            this.groupBox1.Controls.Add(this.dateTimePickerDeliveryPlanDate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.comboBoxVNPTId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDeliveryPlanQuantity);
            this.groupBox1.Location = new System.Drawing.Point(372, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 157);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm hàng trên DataGridView";
            // 
            // dateTimePickerDeliveryPlanDate
            // 
            this.dateTimePickerDeliveryPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDeliveryPlanDate.Location = new System.Drawing.Point(279, 82);
            this.dateTimePickerDeliveryPlanDate.Name = "dateTimePickerDeliveryPlanDate";
            this.dateTimePickerDeliveryPlanDate.Size = new System.Drawing.Size(92, 23);
            this.dateTimePickerDeliveryPlanDate.TabIndex = 4;
            this.dateTimePickerDeliveryPlanDate.ValueChanged += new System.EventHandler(this.dateTimePickerDeliveryPlanDate_ValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(279, 113);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(384, 494);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDeliveryPlanVNPTIdTotalQuantity
            // 
            this.txtDeliveryPlanVNPTIdTotalQuantity.Enabled = false;
            this.txtDeliveryPlanVNPTIdTotalQuantity.Location = new System.Drawing.Point(279, 124);
            this.txtDeliveryPlanVNPTIdTotalQuantity.Name = "txtDeliveryPlanVNPTIdTotalQuantity";
            this.txtDeliveryPlanVNPTIdTotalQuantity.Size = new System.Drawing.Size(92, 23);
            this.txtDeliveryPlanVNPTIdTotalQuantity.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(234, 125);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 15);
            this.label16.TabIndex = 2;
            this.label16.Text = "Tổng";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Aqua;
            this.groupBox7.Controls.Add(this.lblWarning);
            this.groupBox7.Controls.Add(this.dtpDeliveryPlanDate);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.btnDelete);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.txtDeliveryPlanQuantity);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.txtVNPTId);
            this.groupBox7.Controls.Add(this.txtDeliveryPlanId);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.txtRemainingPOGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtPOGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtRemainingContractGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtDeliveryPlanVNPTIdTotalQuantity);
            this.groupBox7.Controls.Add(this.txtContractGoodsQuantity);
            this.groupBox7.Location = new System.Drawing.Point(372, 50);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(382, 265);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Chi tiết số lượng từng hàng trên DataGridView";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(218, 94);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(148, 15);
            this.lblWarning.TabIndex = 5;
            this.lblWarning.Text = "! Vẫn chưa phân bổ hết PO";
            // 
            // dtpDeliveryPlanDate
            // 
            this.dtpDeliveryPlanDate.Enabled = false;
            this.dtpDeliveryPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryPlanDate.Location = new System.Drawing.Point(120, 186);
            this.dtpDeliveryPlanDate.Name = "dtpDeliveryPlanDate";
            this.dtpDeliveryPlanDate.Size = new System.Drawing.Size(251, 23);
            this.dtpDeliveryPlanDate.TabIndex = 4;
            this.dtpDeliveryPlanDate.ValueChanged += new System.EventHandler(this.dateTimePickerDeliveryPlanDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "DeliveryPlanId";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(279, 220);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 24);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ngày giao hàng";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(49, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 15);
            this.label17.TabIndex = 2;
            this.label17.Text = "Contract";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Số lượng";
            // 
            // txtDeliveryPlanQuantity
            // 
            this.txtDeliveryPlanQuantity.Enabled = false;
            this.txtDeliveryPlanQuantity.Location = new System.Drawing.Point(120, 155);
            this.txtDeliveryPlanQuantity.Name = "txtDeliveryPlanQuantity";
            this.txtDeliveryPlanQuantity.Size = new System.Drawing.Size(251, 23);
            this.txtDeliveryPlanQuantity.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(225, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "Còn lại";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(225, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 15);
            this.label18.TabIndex = 2;
            this.label18.Text = "Còn lại";
            // 
            // txtVNPTId
            // 
            this.txtVNPTId.Enabled = false;
            this.txtVNPTId.Location = new System.Drawing.Point(120, 124);
            this.txtVNPTId.Name = "txtVNPTId";
            this.txtVNPTId.Size = new System.Drawing.Size(92, 23);
            this.txtVNPTId.TabIndex = 3;
            this.txtVNPTId.TextChanged += new System.EventHandler(this.txtVNPTId_TextChanged);
            // 
            // txtDeliveryPlanId
            // 
            this.txtDeliveryPlanId.Enabled = false;
            this.txtDeliveryPlanId.Location = new System.Drawing.Point(120, 92);
            this.txtDeliveryPlanId.Name = "txtDeliveryPlanId";
            this.txtDeliveryPlanId.Size = new System.Drawing.Size(92, 23);
            this.txtDeliveryPlanId.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(84, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "PO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "VNPTId";
            // 
            // txtRemainingPOGoodsQuantity
            // 
            this.txtRemainingPOGoodsQuantity.Enabled = false;
            this.txtRemainingPOGoodsQuantity.ForeColor = System.Drawing.Color.Red;
            this.txtRemainingPOGoodsQuantity.Location = new System.Drawing.Point(279, 60);
            this.txtRemainingPOGoodsQuantity.Name = "txtRemainingPOGoodsQuantity";
            this.txtRemainingPOGoodsQuantity.Size = new System.Drawing.Size(92, 23);
            this.txtRemainingPOGoodsQuantity.TabIndex = 3;
            this.txtRemainingPOGoodsQuantity.TextChanged += new System.EventHandler(this.txtRemainingPOGoodsQuantity_TextChanged);
            // 
            // txtPOGoodsQuantity
            // 
            this.txtPOGoodsQuantity.Enabled = false;
            this.txtPOGoodsQuantity.Location = new System.Drawing.Point(120, 61);
            this.txtPOGoodsQuantity.Name = "txtPOGoodsQuantity";
            this.txtPOGoodsQuantity.Size = new System.Drawing.Size(92, 23);
            this.txtPOGoodsQuantity.TabIndex = 3;
            // 
            // txtRemainingContractGoodsQuantity
            // 
            this.txtRemainingContractGoodsQuantity.Enabled = false;
            this.txtRemainingContractGoodsQuantity.Location = new System.Drawing.Point(279, 30);
            this.txtRemainingContractGoodsQuantity.Name = "txtRemainingContractGoodsQuantity";
            this.txtRemainingContractGoodsQuantity.Size = new System.Drawing.Size(92, 23);
            this.txtRemainingContractGoodsQuantity.TabIndex = 3;
            // 
            // txtContractGoodsQuantity
            // 
            this.txtContractGoodsQuantity.Enabled = false;
            this.txtContractGoodsQuantity.Location = new System.Drawing.Point(120, 30);
            this.txtContractGoodsQuantity.Name = "txtContractGoodsQuantity";
            this.txtContractGoodsQuantity.Size = new System.Drawing.Size(92, 23);
            this.txtContractGoodsQuantity.TabIndex = 3;
            // 
            // buttonDeliveryPlanDataTable
            // 
            this.buttonDeliveryPlanDataTable.Location = new System.Drawing.Point(532, 494);
            this.buttonDeliveryPlanDataTable.Name = "buttonDeliveryPlanDataTable";
            this.buttonDeliveryPlanDataTable.Size = new System.Drawing.Size(210, 24);
            this.buttonDeliveryPlanDataTable.TabIndex = 1;
            this.buttonDeliveryPlanDataTable.Text = "Bảng Phụ lục Kế hoạch giao hàng";
            this.buttonDeliveryPlanDataTable.UseVisualStyleBackColor = true;
            this.buttonDeliveryPlanDataTable.Click += new System.EventHandler(this.buttonDeliveryPlanDataTable_Click);
            // 
            // DeliveryPlanInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(755, 527);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDeliveryPlanDataTable);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtgDeliveryPlan);
            this.Name = "DeliveryPlanInfo";
            this.Load += new System.EventHandler(this.DeliveryPlanInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDeliveryPlan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDeliveryPlan;
        private System.Windows.Forms.Button buttonAddProvinceId;
        private System.Windows.Forms.TextBox textBoxDeliveryPlanQuantity;
        private System.Windows.Forms.ComboBox comboBoxVNPTId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeliveryPlanDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDeliveryPlanVNPTIdTotalQuantity;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRemainingContractGoodsQuantity;
        private System.Windows.Forms.TextBox txtContractGoodsQuantity;
        private System.Windows.Forms.TextBox txtRemainingPOGoodsQuantity;
        private System.Windows.Forms.TextBox txtPOGoodsQuantity;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDeliveryPlanId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDeliveryPlanDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeliveryPlanQuantity;
        private System.Windows.Forms.TextBox txtVNPTId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button buttonDeliveryPlanDataTable;
    }
}