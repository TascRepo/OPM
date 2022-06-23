
namespace OPM.GUI
{
    partial class ContractCreatDocInfo
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
            this.checkBoxTemp1_ContractGuarantee = new System.Windows.Forms.CheckBox();
            this.checkBoxTemp29_ContractReportOfConpletedVolume = new System.Windows.Forms.CheckBox();
            this.checkBoxTemp30_ContractLiquidationRecords = new System.Windows.Forms.CheckBox();
            this.btnCreatDocument = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxTemp1_ContractGuarantee
            // 
            this.checkBoxTemp1_ContractGuarantee.AutoSize = true;
            this.checkBoxTemp1_ContractGuarantee.Location = new System.Drawing.Point(64, 36);
            this.checkBoxTemp1_ContractGuarantee.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTemp1_ContractGuarantee.Name = "checkBoxTemp1_ContractGuarantee";
            this.checkBoxTemp1_ContractGuarantee.Size = new System.Drawing.Size(284, 19);
            this.checkBoxTemp1_ContractGuarantee.TabIndex = 0;
            this.checkBoxTemp1_ContractGuarantee.Text = "Mẫu 1. Đề nghị mở bảo lãnh thực hiện hợp đồng";
            this.checkBoxTemp1_ContractGuarantee.UseVisualStyleBackColor = true;
            // 
            // checkBoxTemp29_ContractReportOfConpletedVolume
            // 
            this.checkBoxTemp29_ContractReportOfConpletedVolume.AutoSize = true;
            this.checkBoxTemp29_ContractReportOfConpletedVolume.Location = new System.Drawing.Point(64, 65);
            this.checkBoxTemp29_ContractReportOfConpletedVolume.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTemp29_ContractReportOfConpletedVolume.Name = "checkBoxTemp29_ContractReportOfConpletedVolume";
            this.checkBoxTemp29_ContractReportOfConpletedVolume.Size = new System.Drawing.Size(347, 19);
            this.checkBoxTemp29_ContractReportOfConpletedVolume.TabIndex = 0;
            this.checkBoxTemp29_ContractReportOfConpletedVolume.Text = "Mẫu 29. Biên bản xác nhận khối lượng hoàn thành hợp đồng";
            this.checkBoxTemp29_ContractReportOfConpletedVolume.UseVisualStyleBackColor = true;
            // 
            // checkBoxTemp30_ContractLiquidationRecords
            // 
            this.checkBoxTemp30_ContractLiquidationRecords.AutoSize = true;
            this.checkBoxTemp30_ContractLiquidationRecords.Location = new System.Drawing.Point(64, 94);
            this.checkBoxTemp30_ContractLiquidationRecords.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTemp30_ContractLiquidationRecords.Name = "checkBoxTemp30_ContractLiquidationRecords";
            this.checkBoxTemp30_ContractLiquidationRecords.Size = new System.Drawing.Size(218, 19);
            this.checkBoxTemp30_ContractLiquidationRecords.TabIndex = 0;
            this.checkBoxTemp30_ContractLiquidationRecords.Text = "Mẫu 30. Biên bản thanh lý hợp đồng";
            this.checkBoxTemp30_ContractLiquidationRecords.UseVisualStyleBackColor = true;
            // 
            // btnCreatDocument
            // 
            this.btnCreatDocument.Location = new System.Drawing.Point(452, 463);
            this.btnCreatDocument.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreatDocument.Name = "btnCreatDocument";
            this.btnCreatDocument.Size = new System.Drawing.Size(91, 24);
            this.btnCreatDocument.TabIndex = 17;
            this.btnCreatDocument.Text = "CreatDoc";
            this.btnCreatDocument.UseVisualStyleBackColor = true;
            this.btnCreatDocument.Click += new System.EventHandler(this.btnCreatDocument_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(590, 463);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(91, 24);
            this.buttonClose.TabIndex = 17;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ContractCreatDocInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(755, 506);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.btnCreatDocument);
            this.Controls.Add(this.checkBoxTemp30_ContractLiquidationRecords);
            this.Controls.Add(this.checkBoxTemp29_ContractReportOfConpletedVolume);
            this.Controls.Add(this.checkBoxTemp1_ContractGuarantee);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ContractCreatDocInfo";
            this.Text = "ContractCreatDocInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTemp1_ContractGuarantee;
        private System.Windows.Forms.CheckBox checkBoxTemp29_ContractReportOfConpletedVolume;
        private System.Windows.Forms.CheckBox checkBoxTemp30_ContractLiquidationRecords;
        private System.Windows.Forms.Button btnCreatDocument;
        private System.Windows.Forms.Button buttonClose;
    }
}