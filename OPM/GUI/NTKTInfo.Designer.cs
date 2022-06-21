
namespace OPM.GUI
{
    partial class NTKTInfo
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNTKTId = new System.Windows.Forms.TextBox();
            this.txtNTKTPhase = new System.Windows.Forms.TextBox();
            this.txtNTKTQuantity = new System.Windows.Forms.TextBox();
            this.dtpNTKTTestExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtNTKTExtraQuantity = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpNTKTCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpTechnicalInspectionReportDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpTechnicalAcceptanceReportDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpNTKTLicenseCertificateDate = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.buttonCreatDocument = new System.Windows.Forms.Button();
            this.btnNewNTKT = new System.Windows.Forms.Button();
            this.lblContractGoodsUnit1 = new System.Windows.Forms.Label();
            this.lblContractGoodsUnit2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPOGoodsQuantity = new System.Windows.Forms.TextBox();
            this.lblContractGoodsUnit = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRemainingNTKTGoodsQuantity = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(503, 508);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 24);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số công văn đề nghị nghiệm thu kỹ thuật";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đợt nghiệm thu kỹ thuật";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số lượng nghiệm thu (hàng chính)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ngày dự kiến nghiệm thu kỹ thuật";
            // 
            // txtNTKTId
            // 
            this.txtNTKTId.Location = new System.Drawing.Point(253, 16);
            this.txtNTKTId.Name = "txtNTKTId";
            this.txtNTKTId.Size = new System.Drawing.Size(507, 23);
            this.txtNTKTId.TabIndex = 3;
            this.txtNTKTId.TextChanged += new System.EventHandler(this.txtNTKTId_TextChanged);
            // 
            // txtNTKTPhase
            // 
            this.txtNTKTPhase.Location = new System.Drawing.Point(253, 71);
            this.txtNTKTPhase.Name = "txtNTKTPhase";
            this.txtNTKTPhase.Size = new System.Drawing.Size(196, 23);
            this.txtNTKTPhase.TabIndex = 5;
            this.txtNTKTPhase.TextChanged += new System.EventHandler(this.txtNTKTPhase_TextChanged);
            // 
            // txtNTKTQuantity
            // 
            this.txtNTKTQuantity.Location = new System.Drawing.Point(253, 397);
            this.txtNTKTQuantity.Name = "txtNTKTQuantity";
            this.txtNTKTQuantity.Size = new System.Drawing.Size(177, 23);
            this.txtNTKTQuantity.TabIndex = 10;
            this.txtNTKTQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNTKTQuantity.TextChanged += new System.EventHandler(this.txbNTKTQuantity_TextChanged);
            // 
            // dtpNTKTTestExpectedDate
            // 
            this.dtpNTKTTestExpectedDate.Location = new System.Drawing.Point(253, 127);
            this.dtpNTKTTestExpectedDate.Name = "dtpNTKTTestExpectedDate";
            this.dtpNTKTTestExpectedDate.Size = new System.Drawing.Size(507, 23);
            this.dtpNTKTTestExpectedDate.TabIndex = 6;
            this.dtpNTKTTestExpectedDate.ValueChanged += new System.EventHandler(this.dtpNTKTTestExpectedDate_ValueChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(7, 508);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(91, 24);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtNTKTExtraQuantity
            // 
            this.txtNTKTExtraQuantity.Location = new System.Drawing.Point(253, 455);
            this.txtNTKTExtraQuantity.Name = "txtNTKTExtraQuantity";
            this.txtNTKTExtraQuantity.Size = new System.Drawing.Size(444, 23);
            this.txtNTKTExtraQuantity.TabIndex = 11;
            this.txtNTKTExtraQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(134, 457);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 15);
            this.label16.TabIndex = 14;
            this.label16.Text = "Số lượng hàng 2%";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(453, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 15);
            this.label17.TabIndex = 6;
            this.label17.Text = " Ngày";
            // 
            // dtpNTKTCreatedDate
            // 
            this.dtpNTKTCreatedDate.Location = new System.Drawing.Point(503, 71);
            this.dtpNTKTCreatedDate.Name = "dtpNTKTCreatedDate";
            this.dtpNTKTCreatedDate.Size = new System.Drawing.Size(257, 23);
            this.dtpNTKTCreatedDate.TabIndex = 4;
            this.dtpNTKTCreatedDate.ValueChanged += new System.EventHandler(this.dtpNTKTCreatedDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Ngày biên bản kiểm tra kỹ thuật";
            // 
            // dtpTechnicalInspectionReportDate
            // 
            this.dtpTechnicalInspectionReportDate.Location = new System.Drawing.Point(253, 182);
            this.dtpTechnicalInspectionReportDate.Name = "dtpTechnicalInspectionReportDate";
            this.dtpTechnicalInspectionReportDate.Size = new System.Drawing.Size(507, 23);
            this.dtpTechnicalInspectionReportDate.TabIndex = 7;
            this.dtpTechnicalInspectionReportDate.ValueChanged += new System.EventHandler(this.dtpTechnicalInspectionReportDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ngày biên bản nghiệm thu kỹ thuật";
            // 
            // dtpTechnicalAcceptanceReportDate
            // 
            this.dtpTechnicalAcceptanceReportDate.Location = new System.Drawing.Point(253, 292);
            this.dtpTechnicalAcceptanceReportDate.Name = "dtpTechnicalAcceptanceReportDate";
            this.dtpTechnicalAcceptanceReportDate.Size = new System.Drawing.Size(507, 23);
            this.dtpTechnicalAcceptanceReportDate.TabIndex = 9;
            this.dtpTechnicalAcceptanceReportDate.ValueChanged += new System.EventHandler(this.dtpTechnicalAcceptanceReportDate_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(211, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Ngày chứng chỉ bản quyền phần mềm";
            // 
            // dtpNTKTLicenseCertificateDate
            // 
            this.dtpNTKTLicenseCertificateDate.Location = new System.Drawing.Point(253, 237);
            this.dtpNTKTLicenseCertificateDate.Name = "dtpNTKTLicenseCertificateDate";
            this.dtpNTKTLicenseCertificateDate.Size = new System.Drawing.Size(507, 23);
            this.dtpNTKTLicenseCertificateDate.TabIndex = 8;
            this.dtpNTKTLicenseCertificateDate.ValueChanged += new System.EventHandler(this.dtpNTKTLicenseCertificateDate_ValueChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(337, 508);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 24);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonCreatDocument
            // 
            this.buttonCreatDocument.Location = new System.Drawing.Point(668, 508);
            this.buttonCreatDocument.Name = "buttonCreatDocument";
            this.buttonCreatDocument.Size = new System.Drawing.Size(91, 24);
            this.buttonCreatDocument.TabIndex = 14;
            this.buttonCreatDocument.Text = "CreateDoc";
            this.buttonCreatDocument.UseVisualStyleBackColor = true;
            this.buttonCreatDocument.Click += new System.EventHandler(this.buttonCreatDocument_Click);
            // 
            // btnNewNTKT
            // 
            this.btnNewNTKT.Location = new System.Drawing.Point(172, 508);
            this.btnNewNTKT.Name = "btnNewNTKT";
            this.btnNewNTKT.Size = new System.Drawing.Size(91, 24);
            this.btnNewNTKT.TabIndex = 15;
            this.btnNewNTKT.Text = "New NTKT";
            this.btnNewNTKT.UseVisualStyleBackColor = true;
            this.btnNewNTKT.Click += new System.EventHandler(this.btnNewNTKT_Click);
            // 
            // lblContractGoodsUnit1
            // 
            this.lblContractGoodsUnit1.AutoSize = true;
            this.lblContractGoodsUnit1.Location = new System.Drawing.Point(708, 399);
            this.lblContractGoodsUnit1.Name = "lblContractGoodsUnit1";
            this.lblContractGoodsUnit1.Size = new System.Drawing.Size(21, 15);
            this.lblContractGoodsUnit1.TabIndex = 6;
            this.lblContractGoodsUnit1.Text = "Bộ";
            // 
            // lblContractGoodsUnit2
            // 
            this.lblContractGoodsUnit2.AutoSize = true;
            this.lblContractGoodsUnit2.Location = new System.Drawing.Point(708, 457);
            this.lblContractGoodsUnit2.Name = "lblContractGoodsUnit2";
            this.lblContractGoodsUnit2.Size = new System.Drawing.Size(21, 15);
            this.lblContractGoodsUnit2.TabIndex = 6;
            this.lblContractGoodsUnit2.Text = "Bộ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Số lượng thiết bị PO";
            // 
            // txtPOGoodsQuantity
            // 
            this.txtPOGoodsQuantity.Location = new System.Drawing.Point(253, 347);
            this.txtPOGoodsQuantity.Name = "txtPOGoodsQuantity";
            this.txtPOGoodsQuantity.Size = new System.Drawing.Size(444, 23);
            this.txtPOGoodsQuantity.TabIndex = 17;
            // 
            // lblContractGoodsUnit
            // 
            this.lblContractGoodsUnit.AutoSize = true;
            this.lblContractGoodsUnit.Location = new System.Drawing.Point(708, 349);
            this.lblContractGoodsUnit.Name = "lblContractGoodsUnit";
            this.lblContractGoodsUnit.Size = new System.Drawing.Size(21, 15);
            this.lblContractGoodsUnit.TabIndex = 21;
            this.lblContractGoodsUnit.Text = "Bộ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(444, 399);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 15);
            this.label22.TabIndex = 20;
            this.label22.Text = "Còn lại";
            // 
            // txtRemainingNTKTGoodsQuantity
            // 
            this.txtRemainingNTKTGoodsQuantity.Enabled = false;
            this.txtRemainingNTKTGoodsQuantity.Location = new System.Drawing.Point(492, 397);
            this.txtRemainingNTKTGoodsQuantity.Name = "txtRemainingNTKTGoodsQuantity";
            this.txtRemainingNTKTGoodsQuantity.Size = new System.Drawing.Size(204, 23);
            this.txtRemainingNTKTGoodsQuantity.TabIndex = 19;
            // 
            // NTKTInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(770, 540);
            this.Controls.Add(this.lblContractGoodsUnit);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtRemainingNTKTGoodsQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPOGoodsQuantity);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtNTKTExtraQuantity);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dtpNTKTCreatedDate);
            this.Controls.Add(this.dtpNTKTLicenseCertificateDate);
            this.Controls.Add(this.dtpTechnicalAcceptanceReportDate);
            this.Controls.Add(this.dtpTechnicalInspectionReportDate);
            this.Controls.Add(this.dtpNTKTTestExpectedDate);
            this.Controls.Add(this.txtNTKTQuantity);
            this.Controls.Add(this.txtNTKTPhase);
            this.Controls.Add(this.txtNTKTId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblContractGoodsUnit2);
            this.Controls.Add(this.lblContractGoodsUnit1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNewNTKT);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.buttonCreatDocument);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NTKTInfo";
            this.Load += new System.EventHandler(this.NTKTInfor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNTKTId;
        private System.Windows.Forms.TextBox txtNTKTPhase;
        private System.Windows.Forms.TextBox txtNTKTQuantity;
        private System.Windows.Forms.DateTimePicker dtpNTKTTestExpectedDate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtNTKTExtraQuantity;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpNTKTCreatedDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTechnicalInspectionReportDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpTechnicalAcceptanceReportDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpNTKTLicenseCertificateDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button buttonCreatDocument;
        private System.Windows.Forms.Button btnNewNTKT;
        private System.Windows.Forms.Label lblContractGoodsUnit1;
        private System.Windows.Forms.Label lblContractGoodsUnit2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPOGoodsQuantity;
        private System.Windows.Forms.Label lblContractGoodsUnit;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtRemainingNTKTGoodsQuantity;
    }
}