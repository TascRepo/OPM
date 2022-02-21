
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
            this.txtDeliveryPlanTotalQuantity = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgDeliveryPlan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgDeliveryPlan
            // 
            this.dtgDeliveryPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDeliveryPlan.Location = new System.Drawing.Point(13, 19);
            this.dtgDeliveryPlan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgDeliveryPlan.Name = "dtgDeliveryPlan";
            this.dtgDeliveryPlan.RowHeadersWidth = 62;
            this.dtgDeliveryPlan.RowTemplate.Height = 25;
            this.dtgDeliveryPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDeliveryPlan.Size = new System.Drawing.Size(510, 845);
            this.dtgDeliveryPlan.TabIndex = 0;
            this.dtgDeliveryPlan.SelectionChanged += new System.EventHandler(this.dtgDeliveryPlan_SelectionChanged);
            // 
            // buttonAddProvinceId
            // 
            this.buttonAddProvinceId.Location = new System.Drawing.Point(398, 66);
            this.buttonAddProvinceId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddProvinceId.Name = "buttonAddProvinceId";
            this.buttonAddProvinceId.Size = new System.Drawing.Size(130, 40);
            this.buttonAddProvinceId.TabIndex = 1;
            this.buttonAddProvinceId.Text = "Thêm VNPT tỉnh (thành)";
            this.buttonAddProvinceId.UseVisualStyleBackColor = true;
            this.buttonAddProvinceId.Click += new System.EventHandler(this.buttonAddProvinceId_Click);
            // 
            // textBoxDeliveryPlanQuantity
            // 
            this.textBoxDeliveryPlanQuantity.Location = new System.Drawing.Point(171, 139);
            this.textBoxDeliveryPlanQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDeliveryPlanQuantity.Name = "textBoxDeliveryPlanQuantity";
            this.textBoxDeliveryPlanQuantity.Size = new System.Drawing.Size(130, 31);
            this.textBoxDeliveryPlanQuantity.TabIndex = 3;
            this.textBoxDeliveryPlanQuantity.TextChanged += new System.EventHandler(this.textBoxDeliveryPlanQuantity_TextChanged);
            // 
            // comboBoxVNPTId
            // 
            this.comboBoxVNPTId.FormattingEnabled = true;
            this.comboBoxVNPTId.Location = new System.Drawing.Point(171, 66);
            this.comboBoxVNPTId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxVNPTId.Name = "comboBoxVNPTId";
            this.comboBoxVNPTId.Size = new System.Drawing.Size(130, 33);
            this.comboBoxVNPTId.TabIndex = 4;
            this.comboBoxVNPTId.SelectedIndexChanged += new System.EventHandler(this.comboBoxVNPTId_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đơn vị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddProvinceId);
            this.groupBox1.Controls.Add(this.dateTimePickerDeliveryPlanDate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.comboBoxVNPTId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDeliveryPlanQuantity);
            this.groupBox1.Location = new System.Drawing.Point(531, 536);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(545, 249);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm hàng trên DataGridView";
            // 
            // dateTimePickerDeliveryPlanDate
            // 
            this.dateTimePickerDeliveryPlanDate.Location = new System.Drawing.Point(399, 137);
            this.dateTimePickerDeliveryPlanDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDeliveryPlanDate.Name = "dateTimePickerDeliveryPlanDate";
            this.dateTimePickerDeliveryPlanDate.Size = new System.Drawing.Size(130, 31);
            this.dateTimePickerDeliveryPlanDate.TabIndex = 4;
            this.dateTimePickerDeliveryPlanDate.ValueChanged += new System.EventHandler(this.dateTimePickerDeliveryPlanDate_ValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(398, 189);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(702, 824);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDeliveryPlanTotalQuantity
            // 
            this.txtDeliveryPlanTotalQuantity.Enabled = false;
            this.txtDeliveryPlanTotalQuantity.Location = new System.Drawing.Point(398, 206);
            this.txtDeliveryPlanTotalQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeliveryPlanTotalQuantity.Name = "txtDeliveryPlanTotalQuantity";
            this.txtDeliveryPlanTotalQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtDeliveryPlanTotalQuantity.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(334, 209);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 25);
            this.label16.TabIndex = 2;
            this.label16.Text = "Tổng";
            // 
            // groupBox7
            // 
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
            this.groupBox7.Controls.Add(this.txtDeliveryPlanTotalQuantity);
            this.groupBox7.Controls.Add(this.txtContractGoodsQuantity);
            this.groupBox7.Location = new System.Drawing.Point(531, 84);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Size = new System.Drawing.Size(545, 417);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Chi tiết số lượng từng hàng trên DataGridView";
            // 
            // dtpDeliveryPlanDate
            // 
            this.dtpDeliveryPlanDate.Enabled = false;
            this.dtpDeliveryPlanDate.Location = new System.Drawing.Point(171, 310);
            this.dtpDeliveryPlanDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDeliveryPlanDate.Name = "dtpDeliveryPlanDate";
            this.dtpDeliveryPlanDate.Size = new System.Drawing.Size(357, 31);
            this.dtpDeliveryPlanDate.TabIndex = 4;
            this.dtpDeliveryPlanDate.ValueChanged += new System.EventHandler(this.dateTimePickerDeliveryPlanDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "DeliveryPlanId";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(398, 366);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 40);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 315);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ngày giao hàng";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(70, 53);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 25);
            this.label17.TabIndex = 2;
            this.label17.Text = "Contract";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 261);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Số lượng";
            // 
            // txtDeliveryPlanQuantity
            // 
            this.txtDeliveryPlanQuantity.Enabled = false;
            this.txtDeliveryPlanQuantity.Location = new System.Drawing.Point(171, 258);
            this.txtDeliveryPlanQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeliveryPlanQuantity.Name = "txtDeliveryPlanQuantity";
            this.txtDeliveryPlanQuantity.Size = new System.Drawing.Size(357, 31);
            this.txtDeliveryPlanQuantity.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(321, 53);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 25);
            this.label19.TabIndex = 2;
            this.label19.Text = "Còn lại";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(321, 103);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 25);
            this.label18.TabIndex = 2;
            this.label18.Text = "Còn lại";
            // 
            // txtVNPTId
            // 
            this.txtVNPTId.Enabled = false;
            this.txtVNPTId.Location = new System.Drawing.Point(171, 206);
            this.txtVNPTId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVNPTId.Name = "txtVNPTId";
            this.txtVNPTId.Size = new System.Drawing.Size(130, 31);
            this.txtVNPTId.TabIndex = 3;
            this.txtVNPTId.TextChanged += new System.EventHandler(this.txtVNPTId_TextChanged);
            // 
            // txtDeliveryPlanId
            // 
            this.txtDeliveryPlanId.Enabled = false;
            this.txtDeliveryPlanId.Location = new System.Drawing.Point(171, 154);
            this.txtDeliveryPlanId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeliveryPlanId.Name = "txtDeliveryPlanId";
            this.txtDeliveryPlanId.Size = new System.Drawing.Size(130, 31);
            this.txtDeliveryPlanId.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(120, 103);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 25);
            this.label15.TabIndex = 2;
            this.label15.Text = "PO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "VNPTId";
            // 
            // txtRemainingPOGoodsQuantity
            // 
            this.txtRemainingPOGoodsQuantity.Enabled = false;
            this.txtRemainingPOGoodsQuantity.Location = new System.Drawing.Point(398, 100);
            this.txtRemainingPOGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemainingPOGoodsQuantity.Name = "txtRemainingPOGoodsQuantity";
            this.txtRemainingPOGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtRemainingPOGoodsQuantity.TabIndex = 3;
            // 
            // txtPOGoodsQuantity
            // 
            this.txtPOGoodsQuantity.Enabled = false;
            this.txtPOGoodsQuantity.Location = new System.Drawing.Point(171, 102);
            this.txtPOGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPOGoodsQuantity.Name = "txtPOGoodsQuantity";
            this.txtPOGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtPOGoodsQuantity.TabIndex = 3;
            // 
            // txtRemainingContractGoodsQuantity
            // 
            this.txtRemainingContractGoodsQuantity.Enabled = false;
            this.txtRemainingContractGoodsQuantity.Location = new System.Drawing.Point(399, 50);
            this.txtRemainingContractGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemainingContractGoodsQuantity.Name = "txtRemainingContractGoodsQuantity";
            this.txtRemainingContractGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtRemainingContractGoodsQuantity.TabIndex = 3;
            // 
            // txtContractGoodsQuantity
            // 
            this.txtContractGoodsQuantity.Enabled = false;
            this.txtContractGoodsQuantity.Location = new System.Drawing.Point(171, 50);
            this.txtContractGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContractGoodsQuantity.Name = "txtContractGoodsQuantity";
            this.txtContractGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtContractGoodsQuantity.TabIndex = 3;
            // 
            // DeliveryPlanInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 878);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtgDeliveryPlan);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.TextBox txtDeliveryPlanTotalQuantity;
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
    }
}