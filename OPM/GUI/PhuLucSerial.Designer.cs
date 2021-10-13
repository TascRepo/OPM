
namespace OPM.GUI
{
    partial class PhuLucSerial
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maPO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdDP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txbnamefilePO = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(973, 403);
            this.dataGridView1.TabIndex = 0;
            // 
            // maPO
            // 
            this.maPO.Enabled = false;
            this.maPO.Location = new System.Drawing.Point(295, 6);
            this.maPO.Name = "maPO";
            this.maPO.Size = new System.Drawing.Size(205, 23);
            this.maPO.TabIndex = 67;
            this.maPO.Text = "XX/CUVT-KV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 66;
            this.label1.Text = "Mã PO";
            // 
            // txtIdDP
            // 
            this.txtIdDP.Enabled = false;
            this.txtIdDP.Location = new System.Drawing.Point(59, 6);
            this.txtIdDP.Name = "txtIdDP";
            this.txtIdDP.Size = new System.Drawing.Size(127, 23);
            this.txtIdDP.TabIndex = 65;
            this.txtIdDP.Text = "DPXXX/202X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 64;
            this.label4.Text = "Số DP";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(521, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 23);
            this.button3.TabIndex = 68;
            this.button3.Text = "Import file Serial";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 69;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(521, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 70;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txbnamefilePO
            // 
            this.txbnamefilePO.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txbnamefilePO.Location = new System.Drawing.Point(704, 6);
            this.txbnamefilePO.Name = "txbnamefilePO";
            this.txbnamefilePO.Size = new System.Drawing.Size(281, 23);
            this.txbnamefilePO.TabIndex = 71;
            // 
            // PhuLucSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 470);
            this.Controls.Add(this.txbnamefilePO);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.maPO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdDP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PhuLucSerial";
            this.Text = "PhuLucSerial";
            this.Load += new System.EventHandler(this.PhuLucSerial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox maPO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdDP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txbnamefilePO;
    }
}