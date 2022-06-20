
namespace OPM.GUI
{
    partial class DPCreatDocInfo
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.btnCreatDocument = new System.Windows.Forms.Button();
            this.checkBoxTemp14_DPCreatedbyANSV = new System.Windows.Forms.CheckBox();
            this.checkBoxTemp13_DPExportRequestForm_ANSV = new System.Windows.Forms.CheckBox();
            this.checkBoxTemp12_DPCreatedbyOPM = new System.Windows.Forms.CheckBox();
            this.checkBoxTemp16_DPExportRequestForm_VNPTTech = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(892, 759);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(130, 40);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // btnCreatDocument
            // 
            this.btnCreatDocument.Location = new System.Drawing.Point(694, 759);
            this.btnCreatDocument.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreatDocument.Name = "btnCreatDocument";
            this.btnCreatDocument.Size = new System.Drawing.Size(130, 40);
            this.btnCreatDocument.TabIndex = 22;
            this.btnCreatDocument.Text = "CreatDoc";
            this.btnCreatDocument.UseVisualStyleBackColor = true;
            this.btnCreatDocument.Click += new System.EventHandler(this.btnCreatDocument_Click);
            // 
            // checkBoxTemp14_DPCreatedbyANSV
            // 
            this.checkBoxTemp14_DPCreatedbyANSV.AutoSize = true;
            this.checkBoxTemp14_DPCreatedbyANSV.Location = new System.Drawing.Point(56, 159);
            this.checkBoxTemp14_DPCreatedbyANSV.Name = "checkBoxTemp14_DPCreatedbyANSV";
            this.checkBoxTemp14_DPCreatedbyANSV.Size = new System.Drawing.Size(274, 29);
            this.checkBoxTemp14_DPCreatedbyANSV.TabIndex = 18;
            this.checkBoxTemp14_DPCreatedbyANSV.Text = "Mẫu 14. DP do kho ANSV tạo";
            this.checkBoxTemp14_DPCreatedbyANSV.UseVisualStyleBackColor = true;
            // 
            // checkBoxTemp13_DPExportRequestForm_ANSV
            // 
            this.checkBoxTemp13_DPExportRequestForm_ANSV.AutoSize = true;
            this.checkBoxTemp13_DPExportRequestForm_ANSV.Location = new System.Drawing.Point(56, 101);
            this.checkBoxTemp13_DPExportRequestForm_ANSV.Name = "checkBoxTemp13_DPExportRequestForm_ANSV";
            this.checkBoxTemp13_DPExportRequestForm_ANSV.Size = new System.Drawing.Size(339, 29);
            this.checkBoxTemp13_DPExportRequestForm_ANSV.TabIndex = 19;
            this.checkBoxTemp13_DPExportRequestForm_ANSV.Text = "Mẫu 13. Phiếu yêu cầu xuất kho ANSV";
            this.checkBoxTemp13_DPExportRequestForm_ANSV.UseVisualStyleBackColor = true;
            // 
            // checkBoxTemp12_DPCreatedbyOPM
            // 
            this.checkBoxTemp12_DPCreatedbyOPM.AutoSize = true;
            this.checkBoxTemp12_DPCreatedbyOPM.Location = new System.Drawing.Point(56, 45);
            this.checkBoxTemp12_DPCreatedbyOPM.Name = "checkBoxTemp12_DPCreatedbyOPM";
            this.checkBoxTemp12_DPCreatedbyOPM.Size = new System.Drawing.Size(233, 29);
            this.checkBoxTemp12_DPCreatedbyOPM.TabIndex = 20;
            this.checkBoxTemp12_DPCreatedbyOPM.Text = "Mẫu 12. DP do OPM tạo";
            this.checkBoxTemp12_DPCreatedbyOPM.UseVisualStyleBackColor = true;
            // 
            // checkBoxTemp16_DPExportRequestForm_VNPTTech
            // 
            this.checkBoxTemp16_DPExportRequestForm_VNPTTech.AutoSize = true;
            this.checkBoxTemp16_DPExportRequestForm_VNPTTech.Location = new System.Drawing.Point(56, 216);
            this.checkBoxTemp16_DPExportRequestForm_VNPTTech.Name = "checkBoxTemp16_DPExportRequestForm_VNPTTech";
            this.checkBoxTemp16_DPExportRequestForm_VNPTTech.Size = new System.Drawing.Size(327, 29);
            this.checkBoxTemp16_DPExportRequestForm_VNPTTech.TabIndex = 18;
            this.checkBoxTemp16_DPExportRequestForm_VNPTTech.Text = "Mẫu 16. Phiếu yêu cầu xuất kho Tech";
            this.checkBoxTemp16_DPExportRequestForm_VNPTTech.UseVisualStyleBackColor = true;
            // 
            // DPCreatDocInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1078, 844);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.btnCreatDocument);
            this.Controls.Add(this.checkBoxTemp16_DPExportRequestForm_VNPTTech);
            this.Controls.Add(this.checkBoxTemp14_DPCreatedbyANSV);
            this.Controls.Add(this.checkBoxTemp13_DPExportRequestForm_ANSV);
            this.Controls.Add(this.checkBoxTemp12_DPCreatedbyOPM);
            this.Name = "DPCreatDocInfo";
            this.Text = "DPCreatDocInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button btnCreatDocument;
        private System.Windows.Forms.CheckBox checkBoxTemp14_DPCreatedbyANSV;
        private System.Windows.Forms.CheckBox checkBoxTemp13_DPExportRequestForm_ANSV;
        private System.Windows.Forms.CheckBox checkBoxTemp12_DPCreatedbyOPM;
        private System.Windows.Forms.CheckBox checkBoxTemp16_DPExportRequestForm_VNPTTech;
    }
}