
using System.Drawing;

namespace OPM.GUI
{
    partial class ContractInfo
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
            this.txtContractId = new System.Windows.Forms.TextBox();
            this.txtContractName = new System.Windows.Forms.TextBox();
            this.txtAccoutingCode = new System.Windows.Forms.TextBox();
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
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtPOGuaranteeValidityPeriod = new System.Windows.Forms.TextBox();
            this.txtSiteId = new System.Windows.Forms.TextBox();
            this.btnNewPO = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbGuaranteeValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpContractCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.dtpContractDeadline = new System.Windows.Forms.DateTimePicker();
            this.dtpContractValidityDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtContractShoppingPlan = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpGuaranteeDeadline = new System.Windows.Forms.DateTimePicker();
            this.txtGuaranteeDuration = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerContractLiquidationRecordsDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerContractReportOfConpletedVolumeDate = new System.Windows.Forms.DateTimePicker();
            this.btnAnnex = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxContractTotalAmountPaid = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpGuaranteeDateCreated = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCreatDocument = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.textBoxContractTotalAmountPaidCurrency = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIdSiteA
            // 
            this.btnIdSiteA.Location = new System.Drawing.Point(604, 225);
            this.btnIdSiteA.Name = "btnIdSiteA";
            this.btnIdSiteA.Size = new System.Drawing.Size(94, 25);
            this.btnIdSiteA.TabIndex = 10;
            this.btnIdSiteA.Text = "Chi tiết bên A";
            this.btnIdSiteA.UseVisualStyleBackColor = true;
            this.btnIdSiteA.Click += new System.EventHandler(this.btnIdSiteA_Click);
            // 
            // txtContractId
            // 
            this.txtContractId.BackColor = System.Drawing.SystemColors.Window;
            this.txtContractId.Location = new System.Drawing.Point(197, 4);
            this.txtContractId.Name = "txtContractId";
            this.txtContractId.Size = new System.Drawing.Size(503, 23);
            this.txtContractId.TabIndex = 2;
            this.txtContractId.TextChanged += new System.EventHandler(this.txtContractId_TextChanged);
            // 
            // txtContractName
            // 
            this.txtContractName.Location = new System.Drawing.Point(197, 55);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.Size = new System.Drawing.Size(503, 23);
            this.txtContractName.TabIndex = 3;
            this.txtContractName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtAccoutingCode
            // 
            this.txtAccoutingCode.Location = new System.Drawing.Point(197, 261);
            this.txtAccoutingCode.Name = "txtAccoutingCode";
            this.txtAccoutingCode.Size = new System.Drawing.Size(503, 23);
            this.txtAccoutingCode.TabIndex = 4;
            this.txtAccoutingCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAccoutingCode.TextChanged += new System.EventHandler(this.txtAccountingCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(99, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hợp Đồng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Gói Thầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã Kế Toán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày Ký";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Thời Hạn Thực Hiện";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Loại Hợp Đồng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ngày Hiệu Lực";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Giá trị trước VAT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Thời hạn hiệu lực đơn hàng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(149, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "SiteA";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(197, 167);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(198, 23);
            this.txtDuration.TabIndex = 8;
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(197, 111);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(503, 23);
            this.txtType.TabIndex = 7;
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // txtValue
            // 
            this.txtValue.Enabled = false;
            this.txtValue.Location = new System.Drawing.Point(197, 197);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(367, 23);
            this.txtValue.TabIndex = 8;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPOGuaranteeValidityPeriod
            // 
            this.txtPOGuaranteeValidityPeriod.Location = new System.Drawing.Point(197, 77);
            this.txtPOGuaranteeValidityPeriod.Name = "txtPOGuaranteeValidityPeriod";
            this.txtPOGuaranteeValidityPeriod.Size = new System.Drawing.Size(198, 23);
            this.txtPOGuaranteeValidityPeriod.TabIndex = 14;
            this.txtPOGuaranteeValidityPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPOGuaranteeValidityPeriod.TextChanged += new System.EventHandler(this.txtDurationPO_TextChanged);
            // 
            // txtSiteId
            // 
            this.txtSiteId.Enabled = false;
            this.txtSiteId.Location = new System.Drawing.Point(197, 228);
            this.txtSiteId.Name = "txtSiteId";
            this.txtSiteId.Size = new System.Drawing.Size(367, 23);
            this.txtSiteId.TabIndex = 9;
            this.txtSiteId.TextChanged += new System.EventHandler(this.txtIdSiteA_TextChanged);
            // 
            // btnNewPO
            // 
            this.btnNewPO.Location = new System.Drawing.Point(635, 557);
            this.btnNewPO.Name = "btnNewPO";
            this.btnNewPO.Size = new System.Drawing.Size(87, 27);
            this.btnNewPO.TabIndex = 17;
            this.btnNewPO.Text = "New PO";
            this.btnNewPO.UseVisualStyleBackColor = true;
            this.btnNewPO.Click += new System.EventHandler(this.btnNewPO_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(257, 557);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 27);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(131, 557);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 27);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 557);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbGuaranteeValue
            // 
            this.txbGuaranteeValue.Location = new System.Drawing.Point(197, 45);
            this.txbGuaranteeValue.Name = "txbGuaranteeValue";
            this.txbGuaranteeValue.Size = new System.Drawing.Size(198, 23);
            this.txbGuaranteeValue.TabIndex = 13;
            this.txbGuaranteeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbGuaranteeValue.TextChanged += new System.EventHandler(this.txbGaranteeValue_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "Tỷ lệ bảo lãnh đơn hàng";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(56, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "Ngày hết hạn bảo lãnh";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(407, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "%";
            // 
            // dtpDateSigned
            // 
            this.dtpContractCreatedDate.CustomFormat = "dd/mm/yyyy";
            this.dtpContractCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContractCreatedDate.Location = new System.Drawing.Point(452, 28);
            this.dtpContractCreatedDate.Name = "dtpDateSigned";
            this.dtpContractCreatedDate.Size = new System.Drawing.Size(247, 23);
            this.dtpContractCreatedDate.TabIndex = 5;
            this.dtpContractCreatedDate.ValueChanged += new System.EventHandler(this.dtpDateSigned_ValueChanged);
            // 
            // dtpContractDeadline
            // 
            this.dtpContractDeadline.CustomFormat = "d-m-y";
            this.dtpContractDeadline.Enabled = false;
            this.dtpContractDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContractDeadline.Location = new System.Drawing.Point(452, 167);
            this.dtpContractDeadline.Name = "dtpContractDeadline";
            this.dtpContractDeadline.Size = new System.Drawing.Size(247, 23);
            this.dtpContractDeadline.TabIndex = 8;
            // 
            // dtpContractValidityDate
            // 
            this.dtpContractValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContractValidityDate.Location = new System.Drawing.Point(452, 139);
            this.dtpContractValidityDate.Name = "dtpContractValidityDate";
            this.dtpContractValidityDate.Size = new System.Drawing.Size(247, 23);
            this.dtpContractValidityDate.TabIndex = 6;
            this.dtpContractValidityDate.ValueChanged += new System.EventHandler(this.dtpActiveDate_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(73, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Kế Hoạch Mua Sắm";
            // 
            // txtContractShoppingPlan
            // 
            this.txtContractShoppingPlan.Location = new System.Drawing.Point(197, 82);
            this.txtContractShoppingPlan.Name = "txtContractShoppingPlan";
            this.txtContractShoppingPlan.Size = new System.Drawing.Size(503, 23);
            this.txtContractShoppingPlan.TabIndex = 1;
            this.txtContractShoppingPlan.TextChanged += new System.EventHandler(this.txtContractShoppingPlan_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(571, 199);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 15);
            this.label17.TabIndex = 13;
            this.label17.Text = "VND";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(407, 169);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 15);
            this.label18.TabIndex = 14;
            this.label18.Text = "Ngày";
            // 
            // dtpGuaranteeDeadline
            // 
            this.dtpGuaranteeDeadline.Enabled = false;
            this.dtpGuaranteeDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGuaranteeDeadline.Location = new System.Drawing.Point(452, 113);
            this.dtpGuaranteeDeadline.Name = "dtpGuaranteeDeadline";
            this.dtpGuaranteeDeadline.Size = new System.Drawing.Size(247, 23);
            this.dtpGuaranteeDeadline.TabIndex = 14;
            // 
            // txtGuaranteeDuration
            // 
            this.txtGuaranteeDuration.Location = new System.Drawing.Point(195, 112);
            this.txtGuaranteeDuration.Name = "txtGuaranteeDuration";
            this.txtGuaranteeDuration.Size = new System.Drawing.Size(199, 23);
            this.txtGuaranteeDuration.TabIndex = 15;
            this.txtGuaranteeDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGuaranteeDuration.TextChanged += new System.EventHandler(this.txtGuaranteeDuration_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(407, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 15);
            this.label15.TabIndex = 14;
            this.label15.Text = "Ngày";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.dtpContractDeadline);
            this.panel1.Controls.Add(this.dateTimePickerContractLiquidationRecordsDate);
            this.panel1.Controls.Add(this.dateTimePickerContractReportOfConpletedVolumeDate);
            this.panel1.Controls.Add(this.dtpContractValidityDate);
            this.panel1.Controls.Add(this.txtContractShoppingPlan);
            this.panel1.Controls.Add(this.btnAnnex);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxContractTotalAmountPaidCurrency);
            this.panel1.Controls.Add(this.textBoxContractTotalAmountPaid);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtContractName);
            this.panel1.Controls.Add(this.dtpContractCreatedDate);
            this.panel1.Controls.Add(this.txtSiteId);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btnIdSiteA);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtValue);
            this.panel1.Controls.Add(this.txtAccoutingCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtContractId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDuration);
            this.panel1.Controls.Add(this.txtType);
            this.panel1.Location = new System.Drawing.Point(7, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 381);
            this.panel1.TabIndex = 17;
            // 
            // dateTimePickerContractLiquidationRecordsDate
            // 
            this.dateTimePickerContractLiquidationRecordsDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerContractLiquidationRecordsDate.Location = new System.Drawing.Point(452, 323);
            this.dateTimePickerContractLiquidationRecordsDate.Name = "dateTimePickerContractLiquidationRecordsDate";
            this.dateTimePickerContractLiquidationRecordsDate.Size = new System.Drawing.Size(247, 23);
            this.dateTimePickerContractLiquidationRecordsDate.TabIndex = 6;
            this.dateTimePickerContractLiquidationRecordsDate.ValueChanged += new System.EventHandler(this.dateTimePickerContractLiquidationRecordsDate_ValueChanged);
            // 
            // dateTimePickerContractReportOfConpletedVolumeDate
            // 
            this.dateTimePickerContractReportOfConpletedVolumeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerContractReportOfConpletedVolumeDate.Location = new System.Drawing.Point(452, 291);
            this.dateTimePickerContractReportOfConpletedVolumeDate.Name = "dateTimePickerContractReportOfConpletedVolumeDate";
            this.dateTimePickerContractReportOfConpletedVolumeDate.Size = new System.Drawing.Size(247, 23);
            this.dateTimePickerContractReportOfConpletedVolumeDate.TabIndex = 6;
            this.dateTimePickerContractReportOfConpletedVolumeDate.ValueChanged += new System.EventHandler(this.dateTimePickerContractReportOfConpletedVolumeDate_ValueChanged);
            // 
            // btnAnnex
            // 
            this.btnAnnex.Location = new System.Drawing.Point(604, 194);
            this.btnAnnex.Name = "btnAnnex";
            this.btnAnnex.Size = new System.Drawing.Size(94, 25);
            this.btnAnnex.TabIndex = 9;
            this.btnAnnex.Text = "Bảng giá";
            this.btnAnnex.UseVisualStyleBackColor = true;
            this.btnAnnex.Click += new System.EventHandler(this.BtnAnnex_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(32, 355);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(149, 15);
            this.label22.TabIndex = 0;
            this.label22.Text = "Tổng số tiền đã thanh toán";
            // 
            // textBoxContractTotalAmountPaid
            // 
            this.textBoxContractTotalAmountPaid.Location = new System.Drawing.Point(197, 353);
            this.textBoxContractTotalAmountPaid.Name = "textBoxContractTotalAmountPaid";
            this.textBoxContractTotalAmountPaid.Size = new System.Drawing.Size(198, 23);
            this.textBoxContractTotalAmountPaid.TabIndex = 3;
            this.textBoxContractTotalAmountPaid.TextChanged += new System.EventHandler(this.textBoxContractTotalAmountPaid_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(32, 326);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(185, 15);
            this.label21.TabIndex = 5;
            this.label21.Text = "Ngày biên bản thanh lý hợp đồng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(259, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Ngày biên bản xác nhận khối lượng hoàn thành";
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
            this.panel2.Controls.Add(this.txbGuaranteeValue);
            this.panel2.Controls.Add(this.txtPOGuaranteeValidityPeriod);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(7, 408);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 139);
            this.panel2.TabIndex = 17;
            // 
            // dtpGuaranteeDateCreated
            // 
            this.dtpGuaranteeDateCreated.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGuaranteeDateCreated.Location = new System.Drawing.Point(452, 7);
            this.dtpGuaranteeDateCreated.Name = "dtpGuaranteeDateCreated";
            this.dtpGuaranteeDateCreated.Size = new System.Drawing.Size(247, 23);
            this.dtpGuaranteeDateCreated.TabIndex = 12;
            this.dtpGuaranteeDateCreated.ValueChanged += new System.EventHandler(this.dtpGaranteeDateCreated_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(78, 7);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 15);
            this.label20.TabIndex = 11;
            this.label20.Text = "Ngày tạo bảo lãnh";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(407, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 15);
            this.label19.TabIndex = 13;
            this.label19.Text = "Ngày";
            // 
            // btnCreatDocument
            // 
            this.btnCreatDocument.Location = new System.Drawing.Point(509, 557);
            this.btnCreatDocument.Name = "btnCreatDocument";
            this.btnCreatDocument.Size = new System.Drawing.Size(87, 27);
            this.btnCreatDocument.TabIndex = 16;
            this.btnCreatDocument.Text = "CreatDoc";
            this.btnCreatDocument.UseVisualStyleBackColor = true;
            this.btnCreatDocument.Click += new System.EventHandler(this.btnCreatDocument_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(7, 557);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 27);
            this.btnNew.TabIndex = 19;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // textBoxContractTotalAmountPaidCurrency
            // 
            this.textBoxContractTotalAmountPaidCurrency.Location = new System.Drawing.Point(452, 354);
            this.textBoxContractTotalAmountPaidCurrency.Name = "textBoxContractTotalAmountPaidCurrency";
            this.textBoxContractTotalAmountPaidCurrency.Size = new System.Drawing.Size(198, 23);
            this.textBoxContractTotalAmountPaidCurrency.TabIndex = 3;
            this.textBoxContractTotalAmountPaidCurrency.TextChanged += new System.EventHandler(this.textBoxContractTotalAmountPaid_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(668, 358);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 15);
            this.label23.TabIndex = 13;
            this.label23.Text = "VND";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(416, 358);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 15);
            this.label24.TabIndex = 13;
            this.label24.Text = "=";
            // 
            // ContractInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(733, 600);
            this.Controls.Add(this.btnCreatDocument);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNewPO);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContractInfo";
            this.Text = "ContractInfoChildForm";
            this.Load += new System.EventHandler(this.ContractInfoChildForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIdSiteA;
        private System.Windows.Forms.TextBox txtContractId;
        private System.Windows.Forms.TextBox txtContractName;
        private System.Windows.Forms.TextBox txtAccoutingCode;
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
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtPOGuaranteeValidityPeriod;
        private System.Windows.Forms.TextBox txtSiteId;
  //      private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button btnNewPO;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txbGuaranteeValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpContractCreatedDate;
        private System.Windows.Forms.DateTimePicker dtpContractDeadline;
        private System.Windows.Forms.DateTimePicker dtpContractValidityDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtContractShoppingPlan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpGuaranteeDeadline;
        private System.Windows.Forms.TextBox txtGuaranteeDuration;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAnnex;
        private System.Windows.Forms.DateTimePicker dtpGuaranteeDateCreated;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnCreatDocument;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dateTimePickerContractReportOfConpletedVolumeDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePickerContractLiquidationRecordsDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxContractTotalAmountPaid;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxContractTotalAmountPaidCurrency;
        private System.Windows.Forms.Label label24;
    }
}