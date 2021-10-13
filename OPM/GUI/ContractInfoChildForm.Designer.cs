
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
            this.btnDescriptionA = new System.Windows.Forms.Button();
            this.tbContract = new System.Windows.Forms.TextBox();
            this.tbBidName = new System.Windows.Forms.TextBox();
            this.tbxAccountingCode = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
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
            this.tbxDurationContract = new System.Windows.Forms.TextBox();
            this.txbTypeContract = new System.Windows.Forms.TextBox();
            this.tbxValueContract = new System.Windows.Forms.TextBox();
            this.tbxDurationPO = new System.Windows.Forms.TextBox();
            this.tbxSiteA = new System.Windows.Forms.TextBox();
            this.tbxSiteB = new System.Windows.Forms.TextBox();
            this.btnNewPO = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbGaranteeValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePickerDateSignedPO = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDurationDateContract = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerActiveDateContract = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txbKHMS = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.txbGaranteeActiveDate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContractAnnex = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpGaranteeCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxGaranteeValue = new System.Windows.Forms.TextBox();
            this.buttonCreatDocument = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDescriptionA
            // 
            this.btnDescriptionA.Location = new System.Drawing.Point(493, 453);
            this.btnDescriptionA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDescriptionA.Name = "btnDescriptionA";
            this.btnDescriptionA.Size = new System.Drawing.Size(141, 38);
            this.btnDescriptionA.TabIndex = 10;
            this.btnDescriptionA.Text = "Chi tiết bên A";
            this.btnDescriptionA.UseVisualStyleBackColor = true;
            this.btnDescriptionA.Click += new System.EventHandler(this.IdSiteA_Click);
            // 
            // tbContract
            // 
            this.tbContract.BackColor = System.Drawing.SystemColors.Window;
            this.tbContract.Location = new System.Drawing.Point(200, 58);
            this.tbContract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbContract.Name = "tbContract";
            this.tbContract.Size = new System.Drawing.Size(434, 31);
            this.tbContract.TabIndex = 2;
            this.tbContract.Text = "XXX-2021/CUVT-ANSV/DTRR-KHMS";
            // 
            // tbBidName
            // 
            this.tbBidName.Location = new System.Drawing.Point(200, 108);
            this.tbBidName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBidName.Name = "tbBidName";
            this.tbBidName.Size = new System.Drawing.Size(434, 31);
            this.tbBidName.TabIndex = 3;
            this.tbBidName.Text = "Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)";
            // 
            // tbxAccountingCode
            // 
            this.tbxAccountingCode.Location = new System.Drawing.Point(200, 158);
            this.tbxAccountingCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxAccountingCode.Name = "tbxAccountingCode";
            this.tbxAccountingCode.Size = new System.Drawing.Size(434, 31);
            this.tbxAccountingCode.TabIndex = 4;
            this.tbxAccountingCode.Text = "C01007";
            this.tbxAccountingCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(493, 503);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 38);
            this.button2.TabIndex = 11;
            this.button2.Text = "Chi tiết bên B";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.IdSiteB_Click);
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
            // tbxDurationContract
            // 
            this.tbxDurationContract.Location = new System.Drawing.Point(199, 358);
            this.tbxDurationContract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxDurationContract.Name = "tbxDurationContract";
            this.tbxDurationContract.Size = new System.Drawing.Size(67, 31);
            this.tbxDurationContract.TabIndex = 8;
            this.tbxDurationContract.Text = "365";
            this.tbxDurationContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxDurationContract.TextChanged += new System.EventHandler(this.tbxDurationContract_TextChanged);
            // 
            // txbTypeContract
            // 
            this.txbTypeContract.Location = new System.Drawing.Point(199, 308);
            this.txbTypeContract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbTypeContract.Name = "txbTypeContract";
            this.txbTypeContract.Size = new System.Drawing.Size(434, 31);
            this.txbTypeContract.TabIndex = 7;
            this.txbTypeContract.Text = "Theo đơn giá cố định";
            this.txbTypeContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxValueContract
            // 
            this.tbxValueContract.Enabled = false;
            this.tbxValueContract.Location = new System.Drawing.Point(199, 408);
            this.tbxValueContract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxValueContract.Name = "tbxValueContract";
            this.tbxValueContract.ReadOnly = true;
            this.tbxValueContract.Size = new System.Drawing.Size(230, 31);
            this.tbxValueContract.TabIndex = 8;
            this.tbxValueContract.Text = "0";
            this.tbxValueContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxValueContract.TextChanged += new System.EventHandler(this.tbxValueContract_TextChanged);
            // 
            // tbxDurationPO
            // 
            this.tbxDurationPO.Location = new System.Drawing.Point(189, 120);
            this.tbxDurationPO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxDurationPO.Name = "tbxDurationPO";
            this.tbxDurationPO.Size = new System.Drawing.Size(65, 31);
            this.tbxDurationPO.TabIndex = 14;
            this.tbxDurationPO.Text = "5";
            this.tbxDurationPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxSiteA
            // 
            this.tbxSiteA.Enabled = false;
            this.tbxSiteA.Location = new System.Drawing.Point(199, 457);
            this.tbxSiteA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxSiteA.Name = "tbxSiteA";
            this.tbxSiteA.Size = new System.Drawing.Size(287, 31);
            this.tbxSiteA.TabIndex = 9;
            this.tbxSiteA.Text = "Trung tâm cung ứng vật tư - Viễn thông TP.HCM";
            // 
            // tbxSiteB
            // 
            this.tbxSiteB.Enabled = false;
            this.tbxSiteB.Location = new System.Drawing.Point(199, 507);
            this.tbxSiteB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxSiteB.Name = "tbxSiteB";
            this.tbxSiteB.Size = new System.Drawing.Size(287, 31);
            this.tbxSiteB.TabIndex = 10;
            this.tbxSiteB.Text = "Công ty TNHH thiết bị viễn thông ANSV";
            // 
            // btnNewPO
            // 
            this.btnNewPO.Enabled = false;
            this.btnNewPO.Location = new System.Drawing.Point(526, 805);
            this.btnNewPO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewPO.Name = "btnNewPO";
            this.btnNewPO.Size = new System.Drawing.Size(118, 38);
            this.btnNewPO.TabIndex = 17;
            this.btnNewPO.Text = "New PO";
            this.btnNewPO.UseVisualStyleBackColor = true;
            this.btnNewPO.Click += new System.EventHandler(this.btnNewPO_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(139, 805);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 38);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(10, 805);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(118, 38);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(397, 805);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 38);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbGaranteeValue
            // 
            this.txbGaranteeValue.Location = new System.Drawing.Point(189, 77);
            this.txbGaranteeValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbGaranteeValue.Name = "txbGaranteeValue";
            this.txbGaranteeValue.Size = new System.Drawing.Size(65, 31);
            this.txbGaranteeValue.TabIndex = 13;
            this.txbGaranteeValue.Text = "50";
            this.txbGaranteeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbGaranteeValue.TextChanged += new System.EventHandler(this.txbGaranteeValue_TextChanged);
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
            // dateTimePickerDateSignedPO
            // 
            this.dateTimePickerDateSignedPO.CustomFormat = "dd/mm/yyyy";
            this.dateTimePickerDateSignedPO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateSignedPO.Location = new System.Drawing.Point(350, 208);
            this.dateTimePickerDateSignedPO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDateSignedPO.Name = "dateTimePickerDateSignedPO";
            this.dateTimePickerDateSignedPO.Size = new System.Drawing.Size(284, 31);
            this.dateTimePickerDateSignedPO.TabIndex = 5;
            // 
            // dateTimePickerDurationDateContract
            // 
            this.dateTimePickerDurationDateContract.CustomFormat = "d-m-y";
            this.dateTimePickerDurationDateContract.Enabled = false;
            this.dateTimePickerDurationDateContract.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDurationDateContract.Location = new System.Drawing.Point(350, 358);
            this.dateTimePickerDurationDateContract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerDurationDateContract.Name = "dateTimePickerDurationDateContract";
            this.dateTimePickerDurationDateContract.Size = new System.Drawing.Size(284, 31);
            this.dateTimePickerDurationDateContract.TabIndex = 8;
            // 
            // dateTimePickerActiveDateContract
            // 
            this.dateTimePickerActiveDateContract.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerActiveDateContract.Location = new System.Drawing.Point(350, 258);
            this.dateTimePickerActiveDateContract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerActiveDateContract.Name = "dateTimePickerActiveDateContract";
            this.dateTimePickerActiveDateContract.Size = new System.Drawing.Size(284, 31);
            this.dateTimePickerActiveDateContract.TabIndex = 6;
            this.dateTimePickerActiveDateContract.ValueChanged += new System.EventHandler(this.dateTimePickerActiveDateContract_ValueChanged);
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
            // txbKHMS
            // 
            this.txbKHMS.Location = new System.Drawing.Point(200, 8);
            this.txbKHMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbKHMS.Name = "txbKHMS";
            this.txbKHMS.Size = new System.Drawing.Size(434, 31);
            this.txbKHMS.TabIndex = 1;
            this.txbKHMS.Text = "Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích" +
    " hệ thống gpon cho nhu cầu năm 2020";
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
            // ExpirationDate
            // 
            this.ExpirationDate.Enabled = false;
            this.ExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ExpirationDate.Location = new System.Drawing.Point(339, 176);
            this.ExpirationDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.Size = new System.Drawing.Size(284, 31);
            this.ExpirationDate.TabIndex = 14;
            // 
            // txbGaranteeActiveDate
            // 
            this.txbGaranteeActiveDate.Location = new System.Drawing.Point(187, 175);
            this.txbGaranteeActiveDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbGaranteeActiveDate.Name = "txbGaranteeActiveDate";
            this.txbGaranteeActiveDate.Size = new System.Drawing.Size(67, 31);
            this.txbGaranteeActiveDate.TabIndex = 15;
            this.txbGaranteeActiveDate.Text = "5";
            this.txbGaranteeActiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbGaranteeActiveDate.TextChanged += new System.EventHandler(this.txbGaranteeActiveDate_TextChanged);
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
            this.panel1.Controls.Add(this.btnContractAnnex);
            this.panel1.Location = new System.Drawing.Point(11, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 555);
            this.panel1.TabIndex = 17;
            // 
            // btnContractAnnex
            // 
            this.btnContractAnnex.Location = new System.Drawing.Point(482, 403);
            this.btnContractAnnex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnContractAnnex.Name = "btnContractAnnex";
            this.btnContractAnnex.Size = new System.Drawing.Size(141, 38);
            this.btnContractAnnex.TabIndex = 9;
            this.btnContractAnnex.Text = "Bảng giá";
            this.btnContractAnnex.UseVisualStyleBackColor = true;
            this.btnContractAnnex.Click += new System.EventHandler(this.btnContractAnnex_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbGaranteeActiveDate);
            this.panel2.Controls.Add(this.dtpGaranteeCreatedDate);
            this.panel2.Controls.Add(this.ExpirationDate);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.tbxGaranteeValue);
            this.panel2.Controls.Add(this.txbGaranteeValue);
            this.panel2.Controls.Add(this.tbxDurationPO);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(11, 567);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 228);
            this.panel2.TabIndex = 17;
            // 
            // dtpGaranteeCreatedDate
            // 
            this.dtpGaranteeCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGaranteeCreatedDate.Location = new System.Drawing.Point(339, 21);
            this.dtpGaranteeCreatedDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpGaranteeCreatedDate.Name = "dtpGaranteeCreatedDate";
            this.dtpGaranteeCreatedDate.Size = new System.Drawing.Size(284, 31);
            this.dtpGaranteeCreatedDate.TabIndex = 12;
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
            // tbxGaranteeValue
            // 
            this.tbxGaranteeValue.Enabled = false;
            this.tbxGaranteeValue.Location = new System.Drawing.Point(339, 78);
            this.tbxGaranteeValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxGaranteeValue.Name = "tbxGaranteeValue";
            this.tbxGaranteeValue.Size = new System.Drawing.Size(284, 31);
            this.tbxGaranteeValue.TabIndex = 12;
            this.tbxGaranteeValue.Text = "0";
            this.tbxGaranteeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonCreatDocument
            // 
            this.buttonCreatDocument.Location = new System.Drawing.Point(268, 805);
            this.buttonCreatDocument.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCreatDocument.Name = "buttonCreatDocument";
            this.buttonCreatDocument.Size = new System.Drawing.Size(118, 38);
            this.buttonCreatDocument.TabIndex = 16;
            this.buttonCreatDocument.Text = "Tạo văn bản";
            this.buttonCreatDocument.UseVisualStyleBackColor = true;
            this.buttonCreatDocument.Click += new System.EventHandler(this.buttonCreatDocument_Click);
            // 
            // ContractInfoChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(651, 862);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txbKHMS);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dateTimePickerActiveDateContract);
            this.Controls.Add(this.dateTimePickerDurationDateContract);
            this.Controls.Add(this.dateTimePickerDateSignedPO);
            this.Controls.Add(this.buttonCreatDocument);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
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
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbxSiteB);
            this.Controls.Add(this.tbxSiteA);
            this.Controls.Add(this.tbxValueContract);
            this.Controls.Add(this.txbTypeContract);
            this.Controls.Add(this.tbxDurationContract);
            this.Controls.Add(this.tbxAccountingCode);
            this.Controls.Add(this.tbBidName);
            this.Controls.Add(this.tbContract);
            this.Controls.Add(this.btnDescriptionA);
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

        private System.Windows.Forms.Button btnDescriptionA;
        private System.Windows.Forms.TextBox tbContract;
        private System.Windows.Forms.TextBox tbBidName;
        private System.Windows.Forms.TextBox tbxAccountingCode;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.TextBox tbxDurationContract;
        private System.Windows.Forms.TextBox txbTypeContract;
        private System.Windows.Forms.TextBox tbxValueContract;
        private System.Windows.Forms.TextBox tbxDurationPO;
        private System.Windows.Forms.TextBox tbxSiteA;
  //      private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button btnNewPO;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbxSiteB;
        private System.Windows.Forms.TextBox txbGaranteeValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateSignedPO;
        private System.Windows.Forms.DateTimePicker dateTimePickerDurationDateContract;
        private System.Windows.Forms.DateTimePicker dateTimePickerActiveDateContract;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txbKHMS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker ExpirationDate;
        private System.Windows.Forms.TextBox txbGaranteeActiveDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxGaranteeValue;
        private System.Windows.Forms.Button btnContractAnnex;
        private System.Windows.Forms.DateTimePicker dtpGaranteeCreatedDate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button buttonCreatDocument;
    }
}