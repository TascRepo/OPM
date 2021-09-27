
namespace OPM.GUI
{
    partial class NTKTInfor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbContact = new System.Windows.Forms.GroupBox();
            this.txbExt = new System.Windows.Forms.TextBox();
            this.txbMobileForBan = new System.Windows.Forms.TextBox();
            this.txbLandLineGDCSKH = new System.Windows.Forms.TextBox();
            this.txbMobileGDCSKH = new System.Windows.Forms.TextBox();
            this.txbGDCSKH = new System.Windows.Forms.TextBox();
            this.txbForBan = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbKHMS = new System.Windows.Forms.TextBox();
            this.txbIDContract = new System.Windows.Forms.TextBox();
            this.txbPOID = new System.Windows.Forms.TextBox();
            this.txbPONumber = new System.Windows.Forms.TextBox();
            this.txbNTKTID = new System.Windows.Forms.TextBox();
            this.dateTimePickerNTKT = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txbNoD = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dateTimePickerNTKTCreated = new System.Windows.Forms.DateTimePicker();
            this.gbContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(499, 798);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "KHMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Hợp Đồng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã PO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "PO Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Số Văn Bản NTKT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 322);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ngày Dự Kiến NTKT";
            // 
            // gbContact
            // 
            this.gbContact.Controls.Add(this.txbExt);
            this.gbContact.Controls.Add(this.txbMobileForBan);
            this.gbContact.Controls.Add(this.txbLandLineGDCSKH);
            this.gbContact.Controls.Add(this.txbMobileGDCSKH);
            this.gbContact.Controls.Add(this.txbGDCSKH);
            this.gbContact.Controls.Add(this.txbForBan);
            this.gbContact.Controls.Add(this.label15);
            this.gbContact.Controls.Add(this.label14);
            this.gbContact.Controls.Add(this.label13);
            this.gbContact.Controls.Add(this.label9);
            this.gbContact.Controls.Add(this.label11);
            this.gbContact.Controls.Add(this.label10);
            this.gbContact.Controls.Add(this.label12);
            this.gbContact.Controls.Add(this.label8);
            this.gbContact.Location = new System.Drawing.Point(19, 458);
            this.gbContact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbContact.Name = "gbContact";
            this.gbContact.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbContact.Size = new System.Drawing.Size(587, 287);
            this.gbContact.TabIndex = 8;
            this.gbContact.TabStop = false;
            this.gbContact.Text = "Thông Tin Liên Hệ";
            // 
            // txbExt
            // 
            this.txbExt.Location = new System.Drawing.Point(523, 197);
            this.txbExt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbExt.Name = "txbExt";
            this.txbExt.Size = new System.Drawing.Size(53, 31);
            this.txbExt.TabIndex = 2;
            this.txbExt.Text = "22";
            // 
            // txbMobileForBan
            // 
            this.txbMobileForBan.Location = new System.Drawing.Point(86, 73);
            this.txbMobileForBan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbMobileForBan.Name = "txbMobileForBan";
            this.txbMobileForBan.Size = new System.Drawing.Size(181, 31);
            this.txbMobileForBan.TabIndex = 1;
            this.txbMobileForBan.Text = "0918903099";
            // 
            // txbLandLineGDCSKH
            // 
            this.txbLandLineGDCSKH.Location = new System.Drawing.Point(364, 197);
            this.txbLandLineGDCSKH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbLandLineGDCSKH.Name = "txbLandLineGDCSKH";
            this.txbLandLineGDCSKH.Size = new System.Drawing.Size(133, 31);
            this.txbLandLineGDCSKH.TabIndex = 1;
            this.txbLandLineGDCSKH.Text = "02437506666";
            // 
            // txbMobileGDCSKH
            // 
            this.txbMobileGDCSKH.Location = new System.Drawing.Point(86, 195);
            this.txbMobileGDCSKH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbMobileGDCSKH.Name = "txbMobileGDCSKH";
            this.txbMobileGDCSKH.Size = new System.Drawing.Size(181, 31);
            this.txbMobileGDCSKH.TabIndex = 1;
            this.txbMobileGDCSKH.Text = "0913508156";
            // 
            // txbGDCSKH
            // 
            this.txbGDCSKH.Location = new System.Drawing.Point(56, 137);
            this.txbGDCSKH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbGDCSKH.Name = "txbGDCSKH";
            this.txbGDCSKH.Size = new System.Drawing.Size(211, 31);
            this.txbGDCSKH.TabIndex = 1;
            this.txbGDCSKH.Text = "Nguyễn Ngọc Huy";
            // 
            // txbForBan
            // 
            this.txbForBan.Location = new System.Drawing.Point(56, 28);
            this.txbForBan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbForBan.Name = "txbForBan";
            this.txbForBan.Size = new System.Drawing.Size(211, 31);
            this.txbForBan.TabIndex = 1;
            this.txbForBan.Text = "Nguyễn Hoài Nam";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(507, 202);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 25);
            this.label15.TabIndex = 0;
            this.label15.Text = ":";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(277, 200);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 25);
            this.label14.TabIndex = 0;
            this.label14.Text = "Landline:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 200);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Mobile:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 143);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mr:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(277, 150);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(208, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Giám Đốc HTKT và CSKH";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(277, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Phó Ban Doanh Thác";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 78);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mobile:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mr:";
            // 
            // txbKHMS
            // 
            this.txbKHMS.Location = new System.Drawing.Point(201, 7);
            this.txbKHMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbKHMS.Name = "txbKHMS";
            this.txbKHMS.Size = new System.Drawing.Size(408, 31);
            this.txbKHMS.TabIndex = 9;
            this.txbKHMS.Text = "Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích" +
    " hệ thống gpon cho nhu cầu năm 2020";
            // 
            // txbIDContract
            // 
            this.txbIDContract.Location = new System.Drawing.Point(201, 58);
            this.txbIDContract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbIDContract.Name = "txbIDContract";
            this.txbIDContract.Size = new System.Drawing.Size(408, 31);
            this.txbIDContract.TabIndex = 9;
            this.txbIDContract.Text = "111-2020/CUVT-ANSV/DTRR-KHMS";
            // 
            // txbPOID
            // 
            this.txbPOID.Location = new System.Drawing.Point(201, 109);
            this.txbPOID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbPOID.Name = "txbPOID";
            this.txbPOID.Size = new System.Drawing.Size(408, 31);
            this.txbPOID.TabIndex = 9;
            this.txbPOID.Text = "5133/CUVT-KV";
            // 
            // txbPONumber
            // 
            this.txbPONumber.Location = new System.Drawing.Point(201, 160);
            this.txbPONumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbPONumber.Name = "txbPONumber";
            this.txbPONumber.Size = new System.Drawing.Size(408, 31);
            this.txbPONumber.TabIndex = 9;
            this.txbPONumber.Text = "PO4";
            // 
            // txbNTKTID
            // 
            this.txbNTKTID.Location = new System.Drawing.Point(201, 211);
            this.txbNTKTID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbNTKTID.Name = "txbNTKTID";
            this.txbNTKTID.Size = new System.Drawing.Size(408, 31);
            this.txbNTKTID.TabIndex = 9;
            this.txbNTKTID.Text = "NTKTxxx";
            // 
            // dateTimePickerNTKT
            // 
            this.dateTimePickerNTKT.Location = new System.Drawing.Point(201, 313);
            this.dateTimePickerNTKT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerNTKT.Name = "dateTimePickerNTKT";
            this.dateTimePickerNTKT.Size = new System.Drawing.Size(284, 31);
            this.dateTimePickerNTKT.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 372);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Import KHGH Dự Kiến";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(201, 364);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(284, 31);
            this.textBox11.TabIndex = 9;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(496, 360);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(110, 38);
            this.btnChoose.TabIndex = 11;
            this.btnChoose.Text = "Choose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(19, 798);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 38);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txbNoD
            // 
            this.txbNoD.Location = new System.Drawing.Point(201, 415);
            this.txbNoD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbNoD.Name = "txbNoD";
            this.txbNoD.Size = new System.Drawing.Size(284, 31);
            this.txbNoD.TabIndex = 13;
            this.txbNoD.Text = "0";
            this.txbNoD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 418);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 25);
            this.label16.TabIndex = 14;
            this.label16.Text = "Tổng số device";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 272);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 25);
            this.label17.TabIndex = 6;
            this.label17.Text = "Ngày tạo";
            // 
            // dateTimePickerNTKTCreated
            // 
            this.dateTimePickerNTKTCreated.Location = new System.Drawing.Point(201, 262);
            this.dateTimePickerNTKTCreated.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerNTKTCreated.Name = "dateTimePickerNTKTCreated";
            this.dateTimePickerNTKTCreated.Size = new System.Drawing.Size(284, 31);
            this.dateTimePickerNTKTCreated.TabIndex = 10;
            // 
            // NTKTInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(629, 852);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txbNoD);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.dateTimePickerNTKTCreated);
            this.Controls.Add(this.dateTimePickerNTKT);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.txbNTKTID);
            this.Controls.Add(this.txbPONumber);
            this.Controls.Add(this.txbPOID);
            this.Controls.Add(this.txbIDContract);
            this.Controls.Add(this.txbKHMS);
            this.Controls.Add(this.gbContact);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NTKTInfor";
            this.Text = "s";
            this.Load += new System.EventHandler(this.NTKTInfor_Load);
            this.gbContact.ResumeLayout(false);
            this.gbContact.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbContact;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txbMobileForBan;
        private System.Windows.Forms.TextBox txbLandLineGDCSKH;
        private System.Windows.Forms.TextBox txbMobileGDCSKH;
        private System.Windows.Forms.TextBox txbGDCSKH;
        private System.Windows.Forms.TextBox txbForBan;
        private System.Windows.Forms.TextBox txbKHMS;
        private System.Windows.Forms.TextBox txbIDContract;
        private System.Windows.Forms.TextBox txbPOID;
        private System.Windows.Forms.TextBox txbPONumber;
        private System.Windows.Forms.TextBox txbNTKTID;
        private System.Windows.Forms.DateTimePicker dateTimePickerNTKT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txbExt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txbNoD;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateTimePickerNTKTCreated;
    }
}