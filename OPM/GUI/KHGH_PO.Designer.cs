
namespace OPM.GUI
{
    partial class KHGH_PO
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
            this.dataKHGH = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.vbxn = new System.Windows.Forms.TextBox();
            this.mpo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataKHGH)).BeginInit();
            this.SuspendLayout();
            // 
            // dataKHGH
            // 
            this.dataKHGH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataKHGH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataKHGH.Location = new System.Drawing.Point(12, 37);
            this.dataKHGH.Name = "dataKHGH";
            this.dataKHGH.RowTemplate.Height = 25;
            this.dataKHGH.Size = new System.Drawing.Size(844, 418);
            this.dataKHGH.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kế hoạch giao hàng";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(740, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // vbxn
            // 
            this.vbxn.Enabled = false;
            this.vbxn.Location = new System.Drawing.Point(344, 9);
            this.vbxn.Name = "vbxn";
            this.vbxn.Size = new System.Drawing.Size(157, 23);
            this.vbxn.TabIndex = 3;
            // 
            // mpo
            // 
            this.mpo.Enabled = false;
            this.mpo.Location = new System.Drawing.Point(600, 9);
            this.mpo.Name = "mpo";
            this.mpo.Size = new System.Drawing.Size(195, 23);
            this.mpo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số văn bản xác nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(539, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mã PO";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(609, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cannel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // KHGH_PO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 497);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mpo);
            this.Controls.Add(this.vbxn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataKHGH);
            this.Name = "KHGH_PO";
            this.Text = "KHGH_PO";
            this.Load += new System.EventHandler(this.KHGH_PO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataKHGH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataKHGH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox vbxn;
        private System.Windows.Forms.TextBox mpo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}