
namespace OPM.GUI
{
    partial class PHD_PO
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbsoHopDong = new System.Windows.Forms.TextBox();
            this.txbmaPO = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txbnamefilePO = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txbsoPO = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã PO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số PO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số hợp đồng";
            // 
            // txbsoHopDong
            // 
            this.txbsoHopDong.Enabled = false;
            this.txbsoHopDong.Location = new System.Drawing.Point(89, 10);
            this.txbsoHopDong.Name = "txbsoHopDong";
            this.txbsoHopDong.Size = new System.Drawing.Size(133, 23);
            this.txbsoHopDong.TabIndex = 3;
            // 
            // txbmaPO
            // 
            this.txbmaPO.Enabled = false;
            this.txbmaPO.Location = new System.Drawing.Point(277, 10);
            this.txbmaPO.Name = "txbmaPO";
            this.txbmaPO.Size = new System.Drawing.Size(100, 23);
            this.txbmaPO.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(886, 420);
            this.dataGridView1.TabIndex = 6;
            // 
            // txbnamefilePO
            // 
            this.txbnamefilePO.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txbnamefilePO.Location = new System.Drawing.Point(710, 10);
            this.txbnamefilePO.Name = "txbnamefilePO";
            this.txbnamefilePO.Size = new System.Drawing.Size(191, 23);
            this.txbnamefilePO.TabIndex = 73;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(574, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 72;
            this.button3.Text = "Import file phát HĐ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(661, 475);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 75;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(792, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 74;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbsoPO
            // 
            this.txbsoPO.Enabled = false;
            this.txbsoPO.Location = new System.Drawing.Point(452, 10);
            this.txbsoPO.Name = "txbsoPO";
            this.txbsoPO.Size = new System.Drawing.Size(100, 23);
            this.txbsoPO.TabIndex = 76;
            // 
            // PHD_PO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 507);
            this.Controls.Add(this.txbsoPO);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txbnamefilePO);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txbmaPO);
            this.Controls.Add(this.txbsoHopDong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PHD_PO";
            this.Text = "PHD_PO";
            this.Load += new System.EventHandler(this.PHD_PO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbsoHopDong;
        private System.Windows.Forms.TextBox txbmaPO;
        //private System.Windows.Forms.TextBox soPO;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txbnamefilePO;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbsoPO;
    }
}