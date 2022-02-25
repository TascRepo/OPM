
namespace OPM.GUI
{
    partial class DPInfo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.textBoxVNPTIdTotalQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDPType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPLDetail = new System.Windows.Forms.Button();
            this.btnDPNew = new System.Windows.Forms.Button();
            this.textBoxDPRemarks = new System.Windows.Forms.TextBox();
            this.btnDPDelete = new System.Windows.Forms.Button();
            this.btnDPSave = new System.Windows.Forms.Button();
            this.textBoxPLId = new System.Windows.Forms.TextBox();
            this.dateTimePickerDPDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxDPId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRemainingPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtRemainingContractGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtContractGoodsQuantity = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtVNPTId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDPQuantity = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRemainingVNPTTotalQuantity = new System.Windows.Forms.TextBox();
            this.txtPLQuantity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPLQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVNPTId = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxRemainingDPQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRemainingVNPTTotalQuantity = new System.Windows.Forms.TextBox();
            this.btnPLAdd = new System.Windows.Forms.Button();
            this.btnPLDelete = new System.Windows.Forms.Button();
            this.dtgDP = new System.Windows.Forms.DataGridView();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(570, 846);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textBoxVNPTIdTotalQuantity
            // 
            this.textBoxVNPTIdTotalQuantity.Enabled = false;
            this.textBoxVNPTIdTotalQuantity.Location = new System.Drawing.Point(145, 481);
            this.textBoxVNPTIdTotalQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxVNPTIdTotalQuantity.Name = "textBoxVNPTIdTotalQuantity";
            this.textBoxVNPTIdTotalQuantity.Size = new System.Drawing.Size(130, 31);
            this.textBoxVNPTIdTotalQuantity.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 375);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 25);
            this.label10.TabIndex = 2;
            this.label10.Text = "Ghi chú";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 266);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Phân loại";
            // 
            // comboBoxDPType
            // 
            this.comboBoxDPType.FormattingEnabled = true;
            this.comboBoxDPType.Items.AddRange(new object[] {
            "Hàng chính",
            "Hàng dự phòng 2%"});
            this.comboBoxDPType.Location = new System.Drawing.Point(145, 263);
            this.comboBoxDPType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDPType.Name = "comboBoxDPType";
            this.comboBoxDPType.Size = new System.Drawing.Size(363, 33);
            this.comboBoxDPType.TabIndex = 4;
            this.comboBoxDPType.Text = "Hàng chính";
            this.comboBoxDPType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDPType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 537);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "PLId";
            // 
            // btnPLDetail
            // 
            this.btnPLDetail.Location = new System.Drawing.Point(378, 534);
            this.btnPLDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPLDetail.Name = "btnPLDetail";
            this.btnPLDetail.Size = new System.Drawing.Size(130, 40);
            this.btnPLDetail.TabIndex = 1;
            this.btnPLDetail.Text = "PLDetail";
            this.btnPLDetail.UseVisualStyleBackColor = true;
            this.btnPLDetail.Click += new System.EventHandler(this.btnNewPL_Click);
            // 
            // btnDPNew
            // 
            this.btnDPNew.Location = new System.Drawing.Point(4, 588);
            this.btnDPNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDPNew.Name = "btnDPNew";
            this.btnDPNew.Size = new System.Drawing.Size(130, 40);
            this.btnDPNew.TabIndex = 1;
            this.btnDPNew.Text = "DP - New";
            this.btnDPNew.UseVisualStyleBackColor = true;
            this.btnDPNew.Click += new System.EventHandler(this.btnNewDP_Click);
            // 
            // textBoxDPRemarks
            // 
            this.textBoxDPRemarks.Location = new System.Drawing.Point(145, 373);
            this.textBoxDPRemarks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDPRemarks.Name = "textBoxDPRemarks";
            this.textBoxDPRemarks.Size = new System.Drawing.Size(363, 31);
            this.textBoxDPRemarks.TabIndex = 3;
            this.textBoxDPRemarks.TextChanged += new System.EventHandler(this.textBoxDPRemarks_TextChanged);
            // 
            // btnDPDelete
            // 
            this.btnDPDelete.Location = new System.Drawing.Point(190, 588);
            this.btnDPDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDPDelete.Name = "btnDPDelete";
            this.btnDPDelete.Size = new System.Drawing.Size(130, 40);
            this.btnDPDelete.TabIndex = 1;
            this.btnDPDelete.Text = "DP - Delete";
            this.btnDPDelete.UseVisualStyleBackColor = true;
            this.btnDPDelete.Click += new System.EventHandler(this.btnDeleteDP_Click);
            // 
            // btnDPSave
            // 
            this.btnDPSave.Location = new System.Drawing.Point(378, 588);
            this.btnDPSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDPSave.Name = "btnDPSave";
            this.btnDPSave.Size = new System.Drawing.Size(130, 40);
            this.btnDPSave.TabIndex = 1;
            this.btnDPSave.Text = "DP - Save";
            this.btnDPSave.UseVisualStyleBackColor = true;
            this.btnDPSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxPLId
            // 
            this.textBoxPLId.Enabled = false;
            this.textBoxPLId.Location = new System.Drawing.Point(145, 535);
            this.textBoxPLId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPLId.Name = "textBoxPLId";
            this.textBoxPLId.Size = new System.Drawing.Size(130, 31);
            this.textBoxPLId.TabIndex = 3;
            // 
            // dateTimePickerDPDate
            // 
            this.dateTimePickerDPDate.Location = new System.Drawing.Point(145, 209);
            this.dateTimePickerDPDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDPDate.Name = "dateTimePickerDPDate";
            this.dateTimePickerDPDate.Size = new System.Drawing.Size(363, 31);
            this.dateTimePickerDPDate.TabIndex = 4;
            this.dateTimePickerDPDate.ValueChanged += new System.EventHandler(this.dateTimePickerDPDate_ValueChanged);
            // 
            // textBoxDPId
            // 
            this.textBoxDPId.Location = new System.Drawing.Point(145, 155);
            this.textBoxDPId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDPId.Name = "textBoxDPId";
            this.textBoxDPId.Size = new System.Drawing.Size(363, 31);
            this.textBoxDPId.TabIndex = 3;
            this.textBoxDPId.TextChanged += new System.EventHandler(this.textBoxDPNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ngày DP";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 46);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 25);
            this.label17.TabIndex = 2;
            this.label17.Text = "Tổng Contract";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "DPId";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(306, 50);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 25);
            this.label19.TabIndex = 2;
            this.label19.Text = "Còn lại";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(307, 109);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 25);
            this.label18.TabIndex = 2;
            this.label18.Text = "Còn lại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 483);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tổng số VNPT";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 101);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 25);
            this.label15.TabIndex = 2;
            this.label15.Text = "Tổng số PO";
            // 
            // txtRemainingPOGoodsQuantity
            // 
            this.txtRemainingPOGoodsQuantity.Enabled = false;
            this.txtRemainingPOGoodsQuantity.Location = new System.Drawing.Point(378, 103);
            this.txtRemainingPOGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemainingPOGoodsQuantity.Name = "txtRemainingPOGoodsQuantity";
            this.txtRemainingPOGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtRemainingPOGoodsQuantity.TabIndex = 3;
            // 
            // txtPOGoodsQuantity
            // 
            this.txtPOGoodsQuantity.Enabled = false;
            this.txtPOGoodsQuantity.Location = new System.Drawing.Point(145, 101);
            this.txtPOGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPOGoodsQuantity.Name = "txtPOGoodsQuantity";
            this.txtPOGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtPOGoodsQuantity.TabIndex = 3;
            // 
            // txtRemainingContractGoodsQuantity
            // 
            this.txtRemainingContractGoodsQuantity.Enabled = false;
            this.txtRemainingContractGoodsQuantity.Location = new System.Drawing.Point(378, 47);
            this.txtRemainingContractGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemainingContractGoodsQuantity.Name = "txtRemainingContractGoodsQuantity";
            this.txtRemainingContractGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtRemainingContractGoodsQuantity.TabIndex = 3;
            // 
            // txtContractGoodsQuantity
            // 
            this.txtContractGoodsQuantity.Enabled = false;
            this.txtContractGoodsQuantity.Location = new System.Drawing.Point(145, 47);
            this.txtContractGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContractGoodsQuantity.Name = "txtContractGoodsQuantity";
            this.txtContractGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtContractGoodsQuantity.TabIndex = 3;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtVNPTId);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.comboBoxDPType);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.btnPLDetail);
            this.groupBox7.Controls.Add(this.textBoxDPQuantity);
            this.groupBox7.Controls.Add(this.btnDPNew);
            this.groupBox7.Controls.Add(this.textBoxDPRemarks);
            this.groupBox7.Controls.Add(this.btnDPDelete);
            this.groupBox7.Controls.Add(this.btnDPSave);
            this.groupBox7.Controls.Add(this.textBoxPLId);
            this.groupBox7.Controls.Add(this.dateTimePickerDPDate);
            this.groupBox7.Controls.Add(this.textBoxDPId);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.txtRemainingPOGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtPOGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtRemainingVNPTTotalQuantity);
            this.groupBox7.Controls.Add(this.txtRemainingContractGoodsQuantity);
            this.groupBox7.Controls.Add(this.txtPLQuantity);
            this.groupBox7.Controls.Add(this.textBoxVNPTIdTotalQuantity);
            this.groupBox7.Controls.Add(this.txtContractGoodsQuantity);
            this.groupBox7.Location = new System.Drawing.Point(568, 20);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Size = new System.Drawing.Size(525, 650);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Thao tác với bảng DP";
            // 
            // txtVNPTId
            // 
            this.txtVNPTId.Enabled = false;
            this.txtVNPTId.Location = new System.Drawing.Point(145, 427);
            this.txtVNPTId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVNPTId.Name = "txtVNPTId";
            this.txtVNPTId.Size = new System.Drawing.Size(130, 31);
            this.txtVNPTId.TabIndex = 6;
            this.txtVNPTId.TextChanged += new System.EventHandler(this.txtVNPTId_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 321);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 25);
            this.label11.TabIndex = 2;
            this.label11.Text = "DPQuantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 430);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "VNPTId";
            // 
            // textBoxDPQuantity
            // 
            this.textBoxDPQuantity.Location = new System.Drawing.Point(145, 319);
            this.textBoxDPQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDPQuantity.Name = "textBoxDPQuantity";
            this.textBoxDPQuantity.Size = new System.Drawing.Size(363, 31);
            this.textBoxDPQuantity.TabIndex = 3;
            this.textBoxDPQuantity.TextChanged += new System.EventHandler(this.textBoxDPQuantity_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(304, 484);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 25);
            this.label21.TabIndex = 2;
            this.label21.Text = "Còn lại";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(285, 426);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 25);
            this.label16.TabIndex = 2;
            this.label16.Text = "Số lượng";
            // 
            // txtRemainingVNPTTotalQuantity
            // 
            this.txtRemainingVNPTTotalQuantity.Enabled = false;
            this.txtRemainingVNPTTotalQuantity.Location = new System.Drawing.Point(381, 484);
            this.txtRemainingVNPTTotalQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemainingVNPTTotalQuantity.Name = "txtRemainingVNPTTotalQuantity";
            this.txtRemainingVNPTTotalQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtRemainingVNPTTotalQuantity.TabIndex = 3;
            // 
            // txtPLQuantity
            // 
            this.txtPLQuantity.Enabled = false;
            this.txtPLQuantity.Location = new System.Drawing.Point(378, 427);
            this.txtPLQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPLQuantity.Name = "txtPLQuantity";
            this.txtPLQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtPLQuantity.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxPLQuantity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxVNPTId);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxRemainingDPQuantity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxRemainingVNPTTotalQuantity);
            this.groupBox1.Location = new System.Drawing.Point(568, 680);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(525, 147);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác với bảng PL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // textBoxPLQuantity
            // 
            this.textBoxPLQuantity.Location = new System.Drawing.Point(148, 94);
            this.textBoxPLQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPLQuantity.Name = "textBoxPLQuantity";
            this.textBoxPLQuantity.Size = new System.Drawing.Size(130, 31);
            this.textBoxPLQuantity.TabIndex = 3;
            this.textBoxPLQuantity.TextChanged += new System.EventHandler(this.textBoxPLQuantity_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "VNPTId";
            // 
            // comboBoxVNPTId
            // 
            this.comboBoxVNPTId.FormattingEnabled = true;
            this.comboBoxVNPTId.Location = new System.Drawing.Point(148, 39);
            this.comboBoxVNPTId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxVNPTId.Name = "comboBoxVNPTId";
            this.comboBoxVNPTId.Size = new System.Drawing.Size(130, 33);
            this.comboBoxVNPTId.TabIndex = 4;
            this.comboBoxVNPTId.SelectedIndexChanged += new System.EventHandler(this.comboBoxVNPTId_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(277, 97);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "DP Còn lại";
            // 
            // textBoxRemainingDPQuantity
            // 
            this.textBoxRemainingDPQuantity.Enabled = false;
            this.textBoxRemainingDPQuantity.Location = new System.Drawing.Point(378, 94);
            this.textBoxRemainingDPQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRemainingDPQuantity.Name = "textBoxRemainingDPQuantity";
            this.textBoxRemainingDPQuantity.Size = new System.Drawing.Size(130, 31);
            this.textBoxRemainingDPQuantity.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "PO Còn lại";
            // 
            // textBoxRemainingVNPTTotalQuantity
            // 
            this.textBoxRemainingVNPTTotalQuantity.Enabled = false;
            this.textBoxRemainingVNPTTotalQuantity.Location = new System.Drawing.Point(378, 42);
            this.textBoxRemainingVNPTTotalQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRemainingVNPTTotalQuantity.Name = "textBoxRemainingVNPTTotalQuantity";
            this.textBoxRemainingVNPTTotalQuantity.Size = new System.Drawing.Size(130, 31);
            this.textBoxRemainingVNPTTotalQuantity.TabIndex = 3;
            // 
            // btnPLAdd
            // 
            this.btnPLAdd.Location = new System.Drawing.Point(946, 846);
            this.btnPLAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPLAdd.Name = "btnPLAdd";
            this.btnPLAdd.Size = new System.Drawing.Size(130, 40);
            this.btnPLAdd.TabIndex = 1;
            this.btnPLAdd.Text = "PL - Add";
            this.btnPLAdd.UseVisualStyleBackColor = true;
            this.btnPLAdd.Click += new System.EventHandler(this.btnPLAdd_Click);
            // 
            // btnPLDelete
            // 
            this.btnPLDelete.Location = new System.Drawing.Point(758, 846);
            this.btnPLDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPLDelete.Name = "btnPLDelete";
            this.btnPLDelete.Size = new System.Drawing.Size(130, 40);
            this.btnPLDelete.TabIndex = 1;
            this.btnPLDelete.Text = "PL - Delete";
            this.btnPLDelete.UseVisualStyleBackColor = true;
            this.btnPLDelete.Click += new System.EventHandler(this.btnPLDelete_Click);
            // 
            // dtgDP
            // 
            this.dtgDP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDP.Location = new System.Drawing.Point(17, 20);
            this.dtgDP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgDP.Name = "dtgDP";
            this.dtgDP.RowHeadersWidth = 62;
            this.dtgDP.RowTemplate.Height = 25;
            this.dtgDP.Size = new System.Drawing.Size(542, 866);
            this.dtgDP.TabIndex = 0;
            // 
            // DPInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1100, 900);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnPLAdd);
            this.Controls.Add(this.dtgDP);
            this.Controls.Add(this.btnPLDelete);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DPInfo";
            this.Load += new System.EventHandler(this.DPInfo_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textBoxVNPTIdTotalQuantity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRemainingContractGoodsQuantity;
        private System.Windows.Forms.TextBox txtContractGoodsQuantity;
        private System.Windows.Forms.TextBox txtRemainingPOGoodsQuantity;
        private System.Windows.Forms.TextBox txtPOGoodsQuantity;
        private System.Windows.Forms.TextBox textBoxPLId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDPId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerDPDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDPSave;
        private System.Windows.Forms.Button btnDPDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDPNew;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDPType;
        private System.Windows.Forms.TextBox textBoxDPRemarks;
        private System.Windows.Forms.Button btnPLDetail;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPLAdd;
        private System.Windows.Forms.Button btnPLDelete;
        private System.Windows.Forms.DataGridView dtgDP;
        private System.Windows.Forms.TextBox txtVNPTId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRemainingVNPTTotalQuantity;
        private System.Windows.Forms.TextBox txtPLQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPLQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVNPTId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRemainingVNPTTotalQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxDPQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxRemainingDPQuantity;
    }
}