
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
            this.dtgDP = new System.Windows.Forms.DataGridView();
            this.textBoxDPQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDPsAdd = new System.Windows.Forms.Button();
            this.textBoxVNPTIdTotalQuantity = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtVNPTId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDPType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNewDP = new System.Windows.Forms.Button();
            this.textBoxDPRemarks = new System.Windows.Forms.TextBox();
            this.btnDeleteDP = new System.Windows.Forms.Button();
            this.btnSaveDP = new System.Windows.Forms.Button();
            this.textBoxDPsId = new System.Windows.Forms.TextBox();
            this.dateTimePickerDPDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxDPId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRemainingPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtRemainingVNPTTotalQuantity = new System.Windows.Forms.TextBox();
            this.txtRemainingContractGoodsQuantity = new System.Windows.Forms.TextBox();
            this.txtDPQuantity = new System.Windows.Forms.TextBox();
            this.txtContractGoodsQuantity = new System.Windows.Forms.TextBox();
            this.btnDPsDelete = new System.Windows.Forms.Button();
            this.comboBoxVNPTId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRemainingVNPTTotalQuantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDP)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // textBoxDPQuantity
            // 
            this.textBoxDPQuantity.Location = new System.Drawing.Point(148, 117);
            this.textBoxDPQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDPQuantity.Name = "textBoxDPQuantity";
            this.textBoxDPQuantity.Size = new System.Drawing.Size(130, 31);
            this.textBoxDPQuantity.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(574, 846);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Back";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDPsAdd
            // 
            this.btnDPsAdd.Location = new System.Drawing.Point(946, 846);
            this.btnDPsAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDPsAdd.Name = "btnDPsAdd";
            this.btnDPsAdd.Size = new System.Drawing.Size(130, 40);
            this.btnDPsAdd.TabIndex = 1;
            this.btnDPsAdd.Text = "DPs Add";
            this.btnDPsAdd.UseVisualStyleBackColor = true;
            this.btnDPsAdd.Click += new System.EventHandler(this.btnDPsAdd_Click);
            // 
            // textBoxVNPTIdTotalQuantity
            // 
            this.textBoxVNPTIdTotalQuantity.Enabled = false;
            this.textBoxVNPTIdTotalQuantity.Location = new System.Drawing.Point(146, 460);
            this.textBoxVNPTIdTotalQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxVNPTIdTotalQuantity.Name = "textBoxVNPTIdTotalQuantity";
            this.textBoxVNPTIdTotalQuantity.Size = new System.Drawing.Size(130, 31);
            this.textBoxVNPTIdTotalQuantity.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(285, 403);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 25);
            this.label16.TabIndex = 2;
            this.label16.Text = "Số lượng";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtVNPTId);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.comboBoxDPType);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.btnNewDP);
            this.groupBox7.Controls.Add(this.textBoxDPRemarks);
            this.groupBox7.Controls.Add(this.btnDeleteDP);
            this.groupBox7.Controls.Add(this.btnSaveDP);
            this.groupBox7.Controls.Add(this.textBoxDPsId);
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
            this.groupBox7.Controls.Add(this.txtDPQuantity);
            this.groupBox7.Controls.Add(this.textBoxVNPTIdTotalQuantity);
            this.groupBox7.Controls.Add(this.txtContractGoodsQuantity);
            this.groupBox7.Location = new System.Drawing.Point(568, 20);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Size = new System.Drawing.Size(525, 631);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Thao tác với bảng DP";
            // 
            // txtVNPTId
            // 
            this.txtVNPTId.Enabled = false;
            this.txtVNPTId.Location = new System.Drawing.Point(147, 401);
            this.txtVNPTId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVNPTId.Name = "txtVNPTId";
            this.txtVNPTId.Size = new System.Drawing.Size(130, 31);
            this.txtVNPTId.TabIndex = 6;
            this.txtVNPTId.TextChanged += new System.EventHandler(this.txtVNPTId_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 345);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 25);
            this.label10.TabIndex = 2;
            this.label10.Text = "Ghi chú";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 286);
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
            this.comboBoxDPType.Location = new System.Drawing.Point(146, 283);
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
            this.label1.Location = new System.Drawing.Point(70, 522);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "DPsId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 404);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "VNPTId";
            // 
            // btnNewDP
            // 
            this.btnNewDP.Location = new System.Drawing.Point(6, 581);
            this.btnNewDP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewDP.Name = "btnNewDP";
            this.btnNewDP.Size = new System.Drawing.Size(130, 40);
            this.btnNewDP.TabIndex = 1;
            this.btnNewDP.Text = "New DP";
            this.btnNewDP.UseVisualStyleBackColor = true;
            this.btnNewDP.Click += new System.EventHandler(this.btnNewDP_Click);
            // 
            // textBoxDPRemarks
            // 
            this.textBoxDPRemarks.Location = new System.Drawing.Point(145, 339);
            this.textBoxDPRemarks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDPRemarks.Name = "textBoxDPRemarks";
            this.textBoxDPRemarks.Size = new System.Drawing.Size(363, 31);
            this.textBoxDPRemarks.TabIndex = 3;
            this.textBoxDPRemarks.TextChanged += new System.EventHandler(this.textBoxDPRemarks_TextChanged);
            // 
            // btnDeleteDP
            // 
            this.btnDeleteDP.Location = new System.Drawing.Point(192, 581);
            this.btnDeleteDP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteDP.Name = "btnDeleteDP";
            this.btnDeleteDP.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteDP.TabIndex = 1;
            this.btnDeleteDP.Text = "Delete DP";
            this.btnDeleteDP.UseVisualStyleBackColor = true;
            this.btnDeleteDP.Click += new System.EventHandler(this.btnDeleteDP_Click);
            // 
            // btnSaveDP
            // 
            this.btnSaveDP.Location = new System.Drawing.Point(378, 581);
            this.btnSaveDP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveDP.Name = "btnSaveDP";
            this.btnSaveDP.Size = new System.Drawing.Size(130, 40);
            this.btnSaveDP.TabIndex = 1;
            this.btnSaveDP.Text = "Save DP";
            this.btnSaveDP.UseVisualStyleBackColor = true;
            this.btnSaveDP.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxDPsId
            // 
            this.textBoxDPsId.Enabled = false;
            this.textBoxDPsId.Location = new System.Drawing.Point(146, 519);
            this.textBoxDPsId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDPsId.Name = "textBoxDPsId";
            this.textBoxDPsId.Size = new System.Drawing.Size(363, 31);
            this.textBoxDPsId.TabIndex = 3;
            // 
            // dateTimePickerDPDate
            // 
            this.dateTimePickerDPDate.Location = new System.Drawing.Point(148, 224);
            this.dateTimePickerDPDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDPDate.Name = "dateTimePickerDPDate";
            this.dateTimePickerDPDate.Size = new System.Drawing.Size(363, 31);
            this.dateTimePickerDPDate.TabIndex = 4;
            this.dateTimePickerDPDate.ValueChanged += new System.EventHandler(this.dateTimePickerDPDate_ValueChanged);
            // 
            // textBoxDPId
            // 
            this.textBoxDPId.Location = new System.Drawing.Point(148, 165);
            this.textBoxDPId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDPId.Name = "textBoxDPId";
            this.textBoxDPId.Size = new System.Drawing.Size(363, 31);
            this.textBoxDPId.TabIndex = 3;
            this.textBoxDPId.TextChanged += new System.EventHandler(this.textBoxDPNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 227);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ngày DP";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 50);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 25);
            this.label17.TabIndex = 2;
            this.label17.Text = "Tổng Contract";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 168);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "DPId";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(304, 463);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 25);
            this.label21.TabIndex = 2;
            this.label21.Text = "Còn lại";
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
            this.label7.Location = new System.Drawing.Point(4, 463);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tổng số VNPT";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 109);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 25);
            this.label15.TabIndex = 2;
            this.label15.Text = "Tổng số PO";
            // 
            // txtRemainingPOGoodsQuantity
            // 
            this.txtRemainingPOGoodsQuantity.Enabled = false;
            this.txtRemainingPOGoodsQuantity.Location = new System.Drawing.Point(381, 106);
            this.txtRemainingPOGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemainingPOGoodsQuantity.Name = "txtRemainingPOGoodsQuantity";
            this.txtRemainingPOGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtRemainingPOGoodsQuantity.TabIndex = 3;
            // 
            // txtPOGoodsQuantity
            // 
            this.txtPOGoodsQuantity.Enabled = false;
            this.txtPOGoodsQuantity.Location = new System.Drawing.Point(148, 106);
            this.txtPOGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPOGoodsQuantity.Name = "txtPOGoodsQuantity";
            this.txtPOGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtPOGoodsQuantity.TabIndex = 3;
            // 
            // txtRemainingVNPTTotalQuantity
            // 
            this.txtRemainingVNPTTotalQuantity.Enabled = false;
            this.txtRemainingVNPTTotalQuantity.Location = new System.Drawing.Point(379, 460);
            this.txtRemainingVNPTTotalQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemainingVNPTTotalQuantity.Name = "txtRemainingVNPTTotalQuantity";
            this.txtRemainingVNPTTotalQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtRemainingVNPTTotalQuantity.TabIndex = 3;
            // 
            // txtRemainingContractGoodsQuantity
            // 
            this.txtRemainingContractGoodsQuantity.Enabled = false;
            this.txtRemainingContractGoodsQuantity.Location = new System.Drawing.Point(381, 47);
            this.txtRemainingContractGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemainingContractGoodsQuantity.Name = "txtRemainingContractGoodsQuantity";
            this.txtRemainingContractGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtRemainingContractGoodsQuantity.TabIndex = 3;
            // 
            // txtDPQuantity
            // 
            this.txtDPQuantity.Enabled = false;
            this.txtDPQuantity.Location = new System.Drawing.Point(379, 401);
            this.txtDPQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDPQuantity.Name = "txtDPQuantity";
            this.txtDPQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtDPQuantity.TabIndex = 3;
            // 
            // txtContractGoodsQuantity
            // 
            this.txtContractGoodsQuantity.Enabled = false;
            this.txtContractGoodsQuantity.Location = new System.Drawing.Point(148, 47);
            this.txtContractGoodsQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContractGoodsQuantity.Name = "txtContractGoodsQuantity";
            this.txtContractGoodsQuantity.Size = new System.Drawing.Size(130, 31);
            this.txtContractGoodsQuantity.TabIndex = 3;
            // 
            // btnDPsDelete
            // 
            this.btnDPsDelete.Location = new System.Drawing.Point(760, 846);
            this.btnDPsDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDPsDelete.Name = "btnDPsDelete";
            this.btnDPsDelete.Size = new System.Drawing.Size(130, 40);
            this.btnDPsDelete.TabIndex = 1;
            this.btnDPsDelete.Text = "DPs Delete";
            this.btnDPsDelete.UseVisualStyleBackColor = true;
            this.btnDPsDelete.Click += new System.EventHandler(this.btnDPsDelete_Click);
            // 
            // comboBoxVNPTId
            // 
            this.comboBoxVNPTId.FormattingEnabled = true;
            this.comboBoxVNPTId.Location = new System.Drawing.Point(148, 51);
            this.comboBoxVNPTId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxVNPTId.Name = "comboBoxVNPTId";
            this.comboBoxVNPTId.Size = new System.Drawing.Size(363, 33);
            this.comboBoxVNPTId.TabIndex = 4;
            this.comboBoxVNPTId.SelectedIndexChanged += new System.EventHandler(this.comboBoxVNPTId_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "VNPT tỉnh";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDPQuantity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxVNPTId);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxRemainingVNPTTotalQuantity);
            this.groupBox1.Location = new System.Drawing.Point(567, 661);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(525, 175);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác với bảng DPs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 120);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Còn lại";
            // 
            // textBoxRemainingVNPTTotalQuantity
            // 
            this.textBoxRemainingVNPTTotalQuantity.Enabled = false;
            this.textBoxRemainingVNPTTotalQuantity.Location = new System.Drawing.Point(381, 118);
            this.textBoxRemainingVNPTTotalQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRemainingVNPTTotalQuantity.Name = "textBoxRemainingVNPTTotalQuantity";
            this.textBoxRemainingVNPTTotalQuantity.Size = new System.Drawing.Size(130, 31);
            this.textBoxRemainingVNPTTotalQuantity.TabIndex = 3;
            // 
            // DPInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1100, 900);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnDPsAdd);
            this.Controls.Add(this.dtgDP);
            this.Controls.Add(this.btnDPsDelete);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DPInfo";
            this.Load += new System.EventHandler(this.DPInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDP)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDP;
        private System.Windows.Forms.TextBox textBoxDPQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDPsAdd;
        private System.Windows.Forms.TextBox textBoxVNPTIdTotalQuantity;
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
        private System.Windows.Forms.Button btnDPsDelete;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtRemainingVNPTTotalQuantity;
        private System.Windows.Forms.TextBox textBoxDPsId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDPId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerDPDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxVNPTId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveDP;
        private System.Windows.Forms.TextBox txtVNPTId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteDP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDPQuantity;
        private System.Windows.Forms.Button btnNewDP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRemainingVNPTTotalQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDPType;
        private System.Windows.Forms.TextBox textBoxDPRemarks;
    }
}