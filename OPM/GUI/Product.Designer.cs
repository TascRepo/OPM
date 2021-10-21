
namespace OPM.GUI
{
    partial class Product
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
            this.dtgProduct = new System.Windows.Forms.DataGridView();
            this.mH = new System.Windows.Forms.ComboBox();
            this.tH = new System.Windows.Forms.ComboBox();
            this.mSP = new System.Windows.Forms.TextBox();
            this.tSP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách sản phẩm trên hệ thống";
            // 
            // dtgProduct
            // 
            this.dtgProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProduct.Location = new System.Drawing.Point(12, 38);
            this.dtgProduct.Name = "dtgProduct";
            this.dtgProduct.RowTemplate.Height = 25;
            this.dtgProduct.Size = new System.Drawing.Size(610, 400);
            this.dtgProduct.TabIndex = 1;
            this.dtgProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProduct_CellContentClick);
            this.dtgProduct.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProduct_CellMouseLeave);
            this.dtgProduct.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgProduct_CellMouseMove);
            // 
            // mH
            // 
            this.mH.FormattingEnabled = true;
            this.mH.Location = new System.Drawing.Point(668, 69);
            this.mH.Name = "mH";
            this.mH.Size = new System.Drawing.Size(200, 23);
            this.mH.TabIndex = 2;
            this.mH.SelectedIndexChanged += new System.EventHandler(this.mH_SelectedIndexChanged);
            // 
            // tH
            // 
            this.tH.FormattingEnabled = true;
            this.tH.Location = new System.Drawing.Point(668, 151);
            this.tH.Name = "tH";
            this.tH.Size = new System.Drawing.Size(200, 23);
            this.tH.TabIndex = 3;
            // 
            // mSP
            // 
            this.mSP.Location = new System.Drawing.Point(668, 222);
            this.mSP.Name = "mSP";
            this.mSP.Size = new System.Drawing.Size(200, 23);
            this.mSP.TabIndex = 4;
            // 
            // tSP
            // 
            this.tSP.Location = new System.Drawing.Point(668, 298);
            this.tSP.Name = "tSP";
            this.tSP.Size = new System.Drawing.Size(200, 23);
            this.tSP.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(805, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Lưu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(668, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(668, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mã sản phẩm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(668, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tên sản phẩm";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(711, 374);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tSP);
            this.Controls.Add(this.mSP);
            this.Controls.Add(this.tH);
            this.Controls.Add(this.mH);
            this.Controls.Add(this.dtgProduct);
            this.Controls.Add(this.label1);
            this.Name = "Product";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgProduct;
        private System.Windows.Forms.ComboBox mH;
        private System.Windows.Forms.ComboBox tH;
        private System.Windows.Forms.TextBox mSP;
        private System.Windows.Forms.TextBox tSP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
    }
}