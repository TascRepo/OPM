
using System.Drawing;

namespace OPM.GUI
{
    partial class ContractInfoChildForm
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
            this.btnIdSiteA = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAccountingCode = new System.Windows.Forms.TextBox();
            this.btnIdSiteB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtDurationPO = new System.Windows.Forms.TextBox();
            this.txtIdSiteA = new System.Windows.Forms.TextBox();
            this.txtIdSiteB = new System.Windows.Forms.TextBox();
            this.btnNewPO = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbGuaranteeValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpDateSigned = new System.Windows.Forms.DateTimePicker();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.dtpDateActive = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.ttxtKHMS = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpGuaranteeDeadline = new System.Windows.Forms.DateTimePicker();
            this.txtGuaranteeDuration = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAnnex = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpGuaranteeDateCreated = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtGuaranteeValue = new System.Windows.Forms.TextBox();
            this.btnCreatDocument = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIdSiteA
            // 
            this.btnIdSiteA.Location = new System.Drawing.Point(493, 453);
            this.btnIdSiteA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIdSiteA.Name = "btnIdSiteA";
            this.btnIdSiteA.Size = new System.Drawing.Size(141, 38);
            this.btnIdSiteA.TabIndex = 10;
            this.btnIdSiteA.Text = "Chi tiết bên A";
            this.btnIdSiteA.UseVisualStyleBackColor = true;
            this.btnIdSiteA.Click += new System.EventHandler(this.btnIdSiteA_Click);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.Window;
            this.txtId.Location = new System.Drawing.Point(200, 58);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(434, 31);
            this.txtId.TabIndex = 2;
            this.txtId.Text = "XXX-2021/CUVT-ANSV/DTRR-KHMS";
            this.txtId.TextChanged += new System.EventHandler(this.TxtId_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(200, 108);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(434, 31);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtAccountingCode
            // 
            this.txtAccountingCode.Location = new System.Drawing.Point(200, 158);
            this.txtAccountingCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccountingCode.Name = "txtAccountingCode";
            this.txtAccountingCode.Size = new System.Drawing.Size(434, 31);
            this.txtAccountingCode.TabIndex = 4;
            this.txtAccountingCode.Text = "C01007";
            this.txtAccountingCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAccountingCode.TextChanged += new System.EventHandler(this.txtAccountingCode_TextChanged);
            // 
            // btnIdSiteB
            // 
            this.btnIdSiteB.Location = new System.Drawing.Point(493, 503);
            this.btnIdSiteB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIdSiteB.Name = "btnIdSiteB";
            this.btnIdSiteB.Size = new System.Drawing.Size(141, 38);
            this.btnIdSiteB.TabIndex = 11;
            this.btnIdSiteB.Text = "Chi tiết bên B";
            this.btnIdSiteB.UseVisualStyleBackColor = true;
            this.btnIdSiteB.Click += new System.EventHandler(this.btnIdSiteB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hợp Đồng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Gói Thầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã Kế Toán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 217);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày Ký";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 362);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Thời Hạn Thực Hiện";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 317);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Loại Hợp Đồng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 262);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ngày Hiệu Lực";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 417);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 25);
            this.label8.TabIndex = 8;
            this.label8.Text = "Giá trị trước VAT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 128);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "Thời hạn hiệu lực";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 465);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "SiteA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 515);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "SiteB";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(199, 358);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(67, 31);
            this.txtDuration.TabIndex = 8;
            this.txtDuration.Text = "365";
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(199, 308);
            this.txtType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(434, 31);
            this.txtType.TabIndex = 7;
            this.txtType.Text = "Theo đơn giá cố định";
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // txtValue
            // 
            this.txtValue.Enabled = false;
            this.txtValue.Location = new System.Drawing.Point(199, 408);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(230, 31);
            this.txtValue.TabIndex = 8;
            this.txtValue.Text = "0";
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // txtDurationPO
            // 
            this.txtDurationPO.Location = new System.Drawing.Point(189, 120);
            this.txtDurationPO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDurationPO.Name = "txtDurationPO";
            this.txtDurationPO.Size = new System.Drawing.Size(65, 31);
            this.txtDurationPO.TabIndex = 14;
            this.txtDurationPO.Text = "5";
            this.txtDurationPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDurationPO.TextChanged += new System.EventHandler(this.txtDurationPO_TextChanged);
            // 
            // txtIdSiteA
            // 
            this.txtIdSiteA.Enabled = false;
            this.txtIdSiteA.Location = new System.Drawing.Point(199, 457);
            this.txtIdSiteA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdSiteA.Name = "txtIdSiteA";
            this.txtIdSiteA.Size = new System.Drawing.Size(287, 31);
            this.txtIdSiteA.TabIndex = 9;
            this.txtIdSiteA.Text = "Trung tâm cung ứng vật tư - Viễn thông TP.HCM";
            this.txtIdSiteA.TextChanged += new System.EventHandler(this.txtIdSiteA_TextChanged);
            // 
            // txtIdSiteB
            // 
            this.txtIdSiteB.Enabled = false;
            this.txtIdSiteB.Location = new System.Drawing.Point(199, 507);
            this.txtIdSiteB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdSiteB.Name = "txtIdSiteB";
            this.txtIdSiteB.Size = new System.Drawing.Size(287, 31);
            this.txtIdSiteB.TabIndex = 10;
            this.txtIdSiteB.Text = "Công ty TNHH thiết bị viễn thông ANSV";
            this.txtIdSiteB.TextChanged += new System.EventHandler(this.txtIdSiteB_TextChanged);
            // 
            // btnNewPO
            // 
            this.btnNewPO.Location = new System.Drawing.Point(553, 809);
            this.btnNewPO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewPO.Name = "btnNewPO";
            this.btnNewPO.Size = new System.Drawing.Size(94, 43);
            this.btnNewPO.TabIndex = 17;
            this.btnNewPO.Text = "New PO";
            this.btnNewPO.UseVisualStyleBackColor = true;
            this.btnNewPO.Click += new System.EventHandler(this.btnNewPO_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(229, 809);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(97, 43);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(120, 809);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 43);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(338, 809);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 43);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbGuaranteeValue
            // 
            this.txbGuaranteeValue.Location = new System.Drawing.Point(189, 77);
            this.txbGuaranteeValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbGuaranteeValue.Name = "txbGuaranteeValue";
            this.txbGuaranteeValue.Size = new System.Drawing.Size(65, 31);
            this.txbGuaranteeValue.TabIndex = 13;
            this.txbGuaranteeValue.Text = "50";
            this.txbGuaranteeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbGuaranteeValue.TextChanged += new System.EventHandler(this.txbGaranteeValue_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 85);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 25);
            this.label12.TabIndex = 12;
            this.label12.Text = "Giá Trị Bảo Lãnh";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 182);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 25);
            this.label13.TabIndex = 14;
            this.label13.Text = "Ngày hết hạn bảo lãnh";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(264, 82);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 30);
            this.label14.TabIndex = 3;
            this.label14.Text = "%";
            // 
            // dtpDateSigned
            // 
            this.dtpDateSigned.CustomFormat = "dd/mm/yyyy";
            this.dtpDateSigned.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSigned.Location = new System.Drawing.Point(350, 208);
            this.dtpDateSigned.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDateSigned.Name = "dtpDateSigned";
            this.dtpDateSigned.Size = new System.Drawing.Size(284, 31);
            this.dtpDateSigned.TabIndex = 5;
            this.dtpDateSigned.ValueChanged += new System.EventHandler(this.dtpDateSigned_ValueChanged);
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.CustomFormat = "d-m-y";
            this.dtpDeadline.Enabled = false;
            this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeadline.Location = new System.Drawing.Point(350, 358);
            this.dtpDeadline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(284, 31);
            this.dtpDeadline.TabIndex = 8;
            // 
            // dtpDateActive
            // 
            this.dtpDateActive.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateActive.Location = new System.Drawing.Point(350, 258);
            this.dtpDateActive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDateActive.Name = "dtpDateActive";
            this.dtpDateActive.Size = new System.Drawing.Size(284, 31);
            this.dtpDateActive.TabIndex = 6;
            this.dtpDateActive.ValueChanged += new System.EventHandler(this.dtpActiveDate_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 17);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(167, 25);
            this.label16.TabIndex = 0;
            this.label16.Text = "Kế Hoạch Mua Sắm";
            // 
            // ttxtKHMS
            // 
            this.ttxtKHMS.Location = new System.Drawing.Point(200, 8);
            this.ttxtKHMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ttxtKHMS.Name = "ttxtKHMS";
            this.ttxtKHMS.Size = new System.Drawing.Size(434, 31);
            this.ttxtKHMS.TabIndex = 1;
            this.ttxtKHMS.Text = "Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích" +
    " hệ thống gpon cho nhu cầu năm 2020";
            this.ttxtKHMS.TextChanged += new System.EventHandler(this.ttxtKHMS_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(430, 408);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 25);
            this.label17.TabIndex = 13;
            this.label17.Text = "VND";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(293, 362);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 25);
            this.label18.TabIndex = 14;
            this.label18.Text = "Ngày";
            // 
            // dtpGuaranteeDeadline
            // 
            this.dtpGuaranteeDeadline.Enabled = false;
            this.dtpGuaranteeDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGuaranteeDeadline.Location = new System.Drawing.Point(339, 176);
            this.dtpGuaranteeDeadline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpGuaranteeDeadline.Name = "dtpGuaranteeDeadline";
            this.dtpGuaranteeDeadline.Size = new System.Drawing.Size(284, 31);
            this.dtpGuaranteeDeadline.TabIndex = 14;
            this.dtpGuaranteeDeadline.ValueChanged += new System.EventHandler(this.dtpGaranteeDeadline_ValueChanged);
            // 
            // txtGuaranteeDuration
            // 
            this.txtGuaranteeDuration.Location = new System.Drawing.Point(187, 175);
            this.txtGuaranteeDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGuaranteeDuration.Name = "txtGuaranteeDuration";
            this.txtGuaranteeDuration.Size = new System.Drawing.Size(67, 31);
            this.txtGuaranteeDuration.TabIndex = 15;
            this.txtGuaranteeDuration.Text = "5";
            this.txtGuaranteeDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGuaranteeDuration.TextChanged += new System.EventHandler(this.txtGuaranteeDuration_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(260, 182);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 25);
            this.label15.TabIndex = 14;
            this.label15.Text = "Ngày";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.btnAnnex);
            this.panel1.Location = new System.Drawing.Point(11, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 539);
            this.panel1.TabIndex = 17;
            // 
            // btnAnnex
            // 
            this.btnAnnex.Location = new System.Drawing.Point(482, 403);
            this.btnAnnex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnnex.Name = "btnAnnex";
            this.btnAnnex.Size = new System.Drawing.Size(141, 38);
            this.btnAnnex.TabIndex = 9;
            this.btnAnnex.Text = "Bảng giá";
            this.btnAnnex.UseVisualStyleBackColor = true;
            this.btnAnnex.Click += new System.EventHandler(this.btnAnnex_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtGuaranteeDuration);
            this.panel2.Controls.Add(this.dtpGuaranteeDateCreated);
            this.panel2.Controls.Add(this.dtpGuaranteeDeadline);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtGuaranteeValue);
            this.panel2.Controls.Add(this.txbGuaranteeValue);
            this.panel2.Controls.Add(this.txtDurationPO);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(11, 551);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 228);
            this.panel2.TabIndex = 17;
            // 
            // dtpGuaranteeDateCreated
            // 
            this.dtpGuaranteeDateCreated.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGuaranteeDateCreated.Location = new System.Drawing.Point(339, 21);
            this.dtpGuaranteeDateCreated.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpGuaranteeDateCreated.Name = "dtpGuaranteeDateCreated";
            this.dtpGuaranteeDateCreated.Size = new System.Drawing.Size(284, 31);
            this.dtpGuaranteeDateCreated.TabIndex = 12;
            this.dtpGuaranteeDateCreated.ValueChanged += new System.EventHandler(this.dtpGaranteeDateCreated_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 27);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(159, 25);
            this.label20.TabIndex = 11;
            this.label20.Text = "Ngày tạo bảo lãnh";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(264, 128);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(285, 25);
            this.label19.TabIndex = 13;
            this.label19.Text = "ngày làm việc kể từ ngày đặt hàng";
            // 
            // txtGuaranteeValue
            // 
            this.txtGuaranteeValue.Enabled = false;
            this.txtGuaranteeValue.Location = new System.Drawing.Point(339, 78);
            this.txtGuaranteeValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGuaranteeValue.Name = "txtGuaranteeValue";
            this.txtGuaranteeValue.Size = new System.Drawing.Size(284, 31);
            this.txtGuaranteeValue.TabIndex = 12;
            this.txtGuaranteeValue.Text = "0";
            this.txtGuaranteeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCreatDocument
            // 
            this.btnCreatDocument.Location = new System.Drawing.Point(447, 809);
            this.btnCreatDocument.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreatDocument.Name = "btnCreatDocument";
            this.btnCreatDocument.Size = new System.Drawing.Size(94, 43);
            this.btnCreatDocument.TabIndex = 16;
            this.btnCreatDocument.Text = "CreatDoc";
            this.btnCreatDocument.UseVisualStyleBackColor = true;
            this.btnCreatDocument.Click += new System.EventHandler(this.btnCreatDocument_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(11, 809);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(97, 43);
            this.btnNew.TabIndex = 19;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // ContractInfoChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(792, 1005);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.ttxtKHMS);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtpDateActive);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.dtpDateSigned);
            this.Controls.Add(this.btnCreatDocument);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNewPO);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIdSiteB);
            this.Controls.Add(this.txtIdSiteB);
            this.Controls.Add(this.txtIdSiteA);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtAccountingCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnIdSiteA);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ContractInfoChildForm";
            this.Text = "ContractInfoChildForm";
            this.Load += new System.EventHandler(this.ContractInfoChildForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIdSiteA;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAccountingCode;
        private System.Windows.Forms.Button btnIdSiteB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtDurationPO;
        private System.Windows.Forms.TextBox txtIdSiteA;
  //      private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button btnNewPO;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIdSiteB;
        private System.Windows.Forms.TextBox txbGuaranteeValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpDateSigned;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.DateTimePicker dtpDateActive;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ttxtKHMS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpGuaranteeDeadline;
        private System.Windows.Forms.TextBox txtGuaranteeDuration;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtGuaranteeValue;
        private System.Windows.Forms.Button btnAnnex;
        private System.Windows.Forms.DateTimePicker dtpGuaranteeDateCreated;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCreatDocument;
        private System.Windows.Forms.Button btnNew;
    }
}