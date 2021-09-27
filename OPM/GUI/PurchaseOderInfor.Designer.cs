
namespace OPM.GUI
{
    partial class PurchaseOderInfor
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
            this.txbPOCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewDP = new System.Windows.Forms.Button();
            this.txbIDContract = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPOName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbNumberDevice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbDurationConfirm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TimePickerDateConfirmPO = new System.Windows.Forms.DateTimePicker();
            this.TimepickerDefaultActive = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.TimePickerDeadLinePO = new System.Windows.Forms.DateTimePicker();
            this.txbDeadLine = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbValuePO = new System.Windows.Forms.TextBox();
            this.dataGridViewPO = new System.Windows.Forms.DataGridView();
            this.TimePickerDateCreatedPO = new System.Windows.Forms.DateTimePicker();
            this.txbTUPO = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txbActiveAfter = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txbKHMS = new System.Windows.Forms.TextBox();
            this.btnNTKT = new System.Windows.Forms.Button();
            this.btnBaoHiem = new System.Windows.Forms.Button();
            this.btnConfirmPO = new System.Windows.Forms.Button();
            this.btnKTKT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txbnamefilePO = new System.Windows.Forms.TextBox();
            this.importPO = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPO)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 515);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(41, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbPOCode
            // 
            this.txbPOCode.Location = new System.Drawing.Point(132, 70);
            this.txbPOCode.Name = "txbPOCode";
            this.txbPOCode.Size = new System.Drawing.Size(312, 23);
            this.txbPOCode.TabIndex = 1;
            this.txbPOCode.Text = "865/CUVT-KV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã PO";
            // 
            // btnNewDP
            // 
            this.btnNewDP.Location = new System.Drawing.Point(380, 515);
            this.btnNewDP.Name = "btnNewDP";
            this.btnNewDP.Size = new System.Drawing.Size(75, 23);
            this.btnNewDP.TabIndex = 3;
            this.btnNewDP.Text = "New DP";
            this.btnNewDP.UseVisualStyleBackColor = true;
            this.btnNewDP.Click += new System.EventHandler(this.btnNewDP_Click);
            // 
            // txbIDContract
            // 
            this.txbIDContract.Location = new System.Drawing.Point(132, 40);
            this.txbIDContract.Name = "txbIDContract";
            this.txbIDContract.Size = new System.Drawing.Size(312, 23);
            this.txbIDContract.TabIndex = 1;
            this.txbIDContract.Text = "111-2020/CUVT-ANSV/DTRR-KHMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Hợp Đồng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "PO Number";
            // 
            // txbPOName
            // 
            this.txbPOName.Location = new System.Drawing.Point(132, 100);
            this.txbPOName.Name = "txbPOName";
            this.txbPOName.Size = new System.Drawing.Size(312, 23);
            this.txbPOName.TabIndex = 1;
            this.txbPOName.Text = "PO1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày Tạo PO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Số Lượng Thiết Bị";
            // 
            // txbNumberDevice
            // 
            this.txbNumberDevice.Location = new System.Drawing.Point(132, 160);
            this.txbNumberDevice.Name = "txbNumberDevice";
            this.txbNumberDevice.Size = new System.Drawing.Size(312, 23);
            this.txbNumberDevice.TabIndex = 1;
            this.txbNumberDevice.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Thời Hạn Confirm";
            // 
            // txbDurationConfirm
            // 
            this.txbDurationConfirm.Location = new System.Drawing.Point(132, 190);
            this.txbDurationConfirm.Name = "txbDurationConfirm";
            this.txbDurationConfirm.Size = new System.Drawing.Size(80, 23);
            this.txbDurationConfirm.TabIndex = 1;
            this.txbDurationConfirm.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Default PO Hiệu Lực";
            // 
            // TimePickerDateConfirmPO
            // 
            this.TimePickerDateConfirmPO.Location = new System.Drawing.Point(244, 190);
            this.TimePickerDateConfirmPO.Name = "TimePickerDateConfirmPO";
            this.TimePickerDateConfirmPO.Size = new System.Drawing.Size(200, 23);
            this.TimePickerDateConfirmPO.TabIndex = 4;
            // 
            // TimepickerDefaultActive
            // 
            this.TimepickerDefaultActive.Location = new System.Drawing.Point(244, 220);
            this.TimepickerDefaultActive.Name = "TimepickerDefaultActive";
            this.TimepickerDefaultActive.Size = new System.Drawing.Size(200, 23);
            this.TimepickerDefaultActive.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "DeadLine PO";
            // 
            // TimePickerDeadLinePO
            // 
            this.TimePickerDeadLinePO.Location = new System.Drawing.Point(244, 250);
            this.TimePickerDeadLinePO.Name = "TimePickerDeadLinePO";
            this.TimePickerDeadLinePO.Size = new System.Drawing.Size(200, 23);
            this.TimePickerDeadLinePO.TabIndex = 4;
            // 
            // txbDeadLine
            // 
            this.txbDeadLine.Location = new System.Drawing.Point(132, 250);
            this.txbDeadLine.Name = "txbDeadLine";
            this.txbDeadLine.Size = new System.Drawing.Size(80, 23);
            this.txbDeadLine.TabIndex = 1;
            this.txbDeadLine.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Giá Trị PO No VAT";
            // 
            // txbValuePO
            // 
            this.txbValuePO.Location = new System.Drawing.Point(132, 280);
            this.txbValuePO.Name = "txbValuePO";
            this.txbValuePO.Size = new System.Drawing.Size(232, 23);
            this.txbValuePO.TabIndex = 1;
            this.txbValuePO.Text = "10000000000";
            // 
            // dataGridViewPO
            // 
            this.dataGridViewPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPO.Location = new System.Drawing.Point(12, 367);
            this.dataGridViewPO.Name = "dataGridViewPO";
            this.dataGridViewPO.RowHeadersWidth = 62;
            this.dataGridViewPO.RowTemplate.Height = 25;
            this.dataGridViewPO.Size = new System.Drawing.Size(431, 142);
            this.dataGridViewPO.TabIndex = 5;
            // 
            // TimePickerDateCreatedPO
            // 
            this.TimePickerDateCreatedPO.Location = new System.Drawing.Point(244, 130);
            this.TimePickerDateCreatedPO.Name = "TimePickerDateCreatedPO";
            this.TimePickerDateCreatedPO.Size = new System.Drawing.Size(200, 23);
            this.TimePickerDateCreatedPO.TabIndex = 4;
            // 
            // txbTUPO
            // 
            this.txbTUPO.Location = new System.Drawing.Point(132, 310);
            this.txbTUPO.Name = "txbTUPO";
            this.txbTUPO.Size = new System.Drawing.Size(100, 23);
            this.txbTUPO.TabIndex = 6;
            this.txbTUPO.Text = "50";
            this.txbTUPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 315);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Tạm Ứng PO";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(232, 313);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "%";
            // 
            // txbActiveAfter
            // 
            this.txbActiveAfter.Location = new System.Drawing.Point(132, 220);
            this.txbActiveAfter.Name = "txbActiveAfter";
            this.txbActiveAfter.Size = new System.Drawing.Size(80, 23);
            this.txbActiveAfter.TabIndex = 1;
            this.txbActiveAfter.Text = "0";
            this.txbActiveAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 15);
            this.label15.TabIndex = 7;
            this.label15.Text = "Kế Hoạch Mua Sắm";
            // 
            // txbKHMS
            // 
            this.txbKHMS.Location = new System.Drawing.Point(132, 10);
            this.txbKHMS.Name = "txbKHMS";
            this.txbKHMS.Size = new System.Drawing.Size(312, 23);
            this.txbKHMS.TabIndex = 8;
            this.txbKHMS.Text = "Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích" +
    " hệ thống gpon cho nhu cầu năm 2020";
            // 
            // btnNTKT
            // 
            this.btnNTKT.Location = new System.Drawing.Point(299, 515);
            this.btnNTKT.Name = "btnNTKT";
            this.btnNTKT.Size = new System.Drawing.Size(75, 23);
            this.btnNTKT.TabIndex = 9;
            this.btnNTKT.Text = "New NTKT";
            this.btnNTKT.UseVisualStyleBackColor = true;
            this.btnNTKT.Click += new System.EventHandler(this.btnNTKT_Click);
            // 
            // btnBaoHiem
            // 
            this.btnBaoHiem.Location = new System.Drawing.Point(218, 515);
            this.btnBaoHiem.Name = "btnBaoHiem";
            this.btnBaoHiem.Size = new System.Drawing.Size(75, 23);
            this.btnBaoHiem.TabIndex = 10;
            this.btnBaoHiem.Text = "Bảo Hiểm";
            this.btnBaoHiem.UseVisualStyleBackColor = true;
            this.btnBaoHiem.Click += new System.EventHandler(this.btnBaoHiem_Click);
            // 
            // btnConfirmPO
            // 
            this.btnConfirmPO.Location = new System.Drawing.Point(137, 515);
            this.btnConfirmPO.Name = "btnConfirmPO";
            this.btnConfirmPO.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmPO.TabIndex = 11;
            this.btnConfirmPO.Text = "ConfirmPO";
            this.btnConfirmPO.UseVisualStyleBackColor = true;
            this.btnConfirmPO.Click += new System.EventHandler(this.btnConfirmPO_Click);
            // 
            // btnKTKT
            // 
            this.btnKTKT.Location = new System.Drawing.Point(55, 515);
            this.btnKTKT.Name = "btnKTKT";
            this.btnKTKT.Size = new System.Drawing.Size(76, 23);
            this.btnKTKT.TabIndex = 12;
            this.btnKTKT.Text = "Export KTKT";
            this.btnKTKT.UseVisualStyleBackColor = true;
            this.btnKTKT.Click += new System.EventHandler(this.btnKTKT_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 553);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Import Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbnamefilePO
            // 
            this.txbnamefilePO.Location = new System.Drawing.Point(132, 339);
            this.txbnamefilePO.Name = "txbnamefilePO";
            this.txbnamefilePO.Size = new System.Drawing.Size(100, 23);
            this.txbnamefilePO.TabIndex = 14;
            // 
            // importPO
            // 
            this.importPO.Location = new System.Drawing.Point(254, 339);
            this.importPO.Name = "importPO";
            this.importPO.Size = new System.Drawing.Size(91, 23);
            this.importPO.TabIndex = 15;
            this.importPO.Text = "Import file PO";
            this.importPO.UseVisualStyleBackColor = true;
            this.importPO.Click += new System.EventHandler(this.importPO_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "File phân bổ hợp đồng ";
            // 
            // PurchaseOderInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(476, 473);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.importPO);
            this.Controls.Add(this.txbnamefilePO);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnKTKT);
            this.Controls.Add(this.btnConfirmPO);
            this.Controls.Add(this.btnBaoHiem);
            this.Controls.Add(this.btnNTKT);
            this.Controls.Add(this.txbKHMS);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txbTUPO);
            this.Controls.Add(this.dataGridViewPO);
            this.Controls.Add(this.TimePickerDeadLinePO);
            this.Controls.Add(this.TimepickerDefaultActive);
            this.Controls.Add(this.TimePickerDateCreatedPO);
            this.Controls.Add(this.TimePickerDateConfirmPO);
            this.Controls.Add(this.btnNewDP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbDeadLine);
            this.Controls.Add(this.txbActiveAfter);
            this.Controls.Add(this.txbDurationConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbValuePO);
            this.Controls.Add(this.txbNumberDevice);
            this.Controls.Add(this.txbPOName);
            this.Controls.Add(this.txbIDContract);
            this.Controls.Add(this.txbPOCode);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PurchaseOderInfor";
            this.Text = "Purchase Oder Infor";
            this.Load += new System.EventHandler(this.PurchaseOderInfor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txbPOCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewDP;
        private System.Windows.Forms.TextBox txbIDContract;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPOName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbNumberDevice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbDurationConfirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker TimePickerDateConfirmPO;
        private System.Windows.Forms.DateTimePicker TimepickerDefaultActive;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker TimePickerDeadLinePO;
        private System.Windows.Forms.TextBox txbDeadLine;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbValuePO;
        private System.Windows.Forms.DataGridView dataGridViewPO;
        private System.Windows.Forms.DateTimePicker TimePickerDateCreatedPO;
        private System.Windows.Forms.TextBox txbTUPO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbActiveAfter;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbKHMS;
        private System.Windows.Forms.Button btnNTKT;
        private System.Windows.Forms.Button btnBaoHiem;
        private System.Windows.Forms.Button btnConfirmPO;
        private System.Windows.Forms.Button btnKTKT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbnamefilePO;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button importPO;
        private System.Windows.Forms.Label label8;
    }
}