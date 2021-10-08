
namespace OPM.GUI
{
    partial class FormDPWarranty
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
            this.txtIdDP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewWarranty = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarranty)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdDP
            // 
            this.txtIdDP.Enabled = false;
            this.txtIdDP.Location = new System.Drawing.Point(53, 12);
            this.txtIdDP.Name = "txtIdDP";
            this.txtIdDP.Size = new System.Drawing.Size(144, 23);
            this.txtIdDP.TabIndex = 20;
            this.txtIdDP.Text = "DPXXX/202X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Số DP";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 44;
            this.label10.Text = "Loại SP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 15);
            this.label9.TabIndex = 60;
            this.label9.Text = "Phân bổ và số lượng hàng phụ";
            // 
            // dataGridViewWarranty
            // 
            this.dataGridViewWarranty.AllowUserToOrderColumns = true;
            this.dataGridViewWarranty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarranty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.soLuong});
            this.dataGridViewWarranty.Location = new System.Drawing.Point(9, 59);
            this.dataGridViewWarranty.Name = "dataGridViewWarranty";
            this.dataGridViewWarranty.RowTemplate.Height = 25;
            this.dataGridViewWarranty.Size = new System.Drawing.Size(368, 214);
            this.dataGridViewWarranty.TabIndex = 58;
            // 
            // Checked
            // 
            this.Checked.HeaderText = "TT";
            this.Checked.Name = "Checked";
            // 
            // soLuong
            // 
            this.soLuong.HeaderText = "Số lượng";
            this.soLuong.Name = "soLuong";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.Location = new System.Drawing.Point(133, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 25);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(261, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 23);
            this.textBox1.TabIndex = 61;
            this.textBox1.Text = "Hàng bảo hành";
            // 
            // FormDPWarranty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 310);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridViewWarranty);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIdDP);
            this.Controls.Add(this.label4);
            this.Name = "FormDPWarranty";
            this.Text = "FormDPWarranty";
            this.Load += new System.EventHandler(this.FormDPWarranty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarranty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdDP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewWarranty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuong;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox1;
    }
}