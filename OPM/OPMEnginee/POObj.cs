using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class POObj : ContractObj
    {
        private string pOId = "XXXX/CUVT-KV";
        public string POId
        {
            get => pOId;
            set
            {
                pOId = value;
                try
                {
                    string query = string.Format("SELECT * FROM dbo.PO WHERE POId = '{0}'", value);
                    DataTable table = OPMDBHandler.ExecuteQuery(query);
                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        ContractId = (row["ContractId"] == null || row["ContractId"] == DBNull.Value) ? "" : row["ContractId"].ToString();
                        POName = (row["POName"] == null || row["POName"] == DBNull.Value) ? "" : row["POName"].ToString();
                        POGoodsQuantity = (row["POGoodsQuantity"] == null || row["POGoodsQuantity"] == DBNull.Value) ? 0 : (double)row["POGoodsQuantity"];
                        POCreatedDate = (row["POCreatedDate"] == null || row["POCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POCreatedDate"];
                        POConfirmRequestDeadline = (row["POConfirmRequestDeadline"] == null || row["POConfirmRequestDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmRequestDeadline"];
                        PODefaultPerformDate = (row["PODefaultPerformDate"] == null || row["PODefaultPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODefaultPerformDate"];
                        POPerformDate = (row["POPerformDate"] == null || row["POPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POPerformDate"];
                        PODeadline = (row["PODeadline"] == null || row["PODeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODeadline"];
                        POConfirmId = (row["POConfirmId"] == null || row["POConfirmId"] == DBNull.Value) ? "" : row["POConfirmId"].ToString();
                        POConfirmCreatedDate = (row["POConfirmCreatedDate"] == null || row["POConfirmCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmCreatedDate"];
                        POAdvancePercentage = (row["POAdvancePercentage"] == null || row["POAdvancePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvancePercentage"];
                        POAdvanceId = (row["POAdvanceId"] == null || row["POAdvanceId"] == DBNull.Value) ? "" : row["POAdvanceId"].ToString();
                        POAdvanceCreatedDate = (row["POAdvanceCreatedDate"] == null || row["POAdvanceCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceCreatedDate"];
                        POAdvanceGuaranteePercentage = (row["POAdvanceGuaranteePercentage"] == null || row["POAdvanceGuaranteePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvanceGuaranteePercentage"];
                        POAdvanceGuaranteeCreatedDate = (row["POAdvanceGuaranteeCreatedDate"] == null || row["POAdvanceGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceGuaranteeCreatedDate"];
                        POAdvanceRequestId = (row["POAdvanceRequestId"] == null || row["POAdvanceRequestId"] == DBNull.Value) ? "" : row["POAdvanceRequestId"].ToString();
                        POAdvanceRequestCreatedDate = (row["POAdvanceRequestCreatedDate"] == null || row["POAdvanceRequestCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceRequestCreatedDate"];
                        POGuaranteeDate = (row["POGuaranteeDate"] == null || row["POGuaranteeDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POGuaranteeDate"];
                        POReportOfAcceptanceAndHandlingOfGoodsDate = (row["POReportOfAcceptanceAndHandlingOfGoodsDate"] == null || row["POReportOfAcceptanceAndHandlingOfGoodsDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POReportOfAcceptanceAndHandlingOfGoodsDate"];
                        POOfferToGuaranteePOWarrantyDate = (row["POOfferToGuaranteePOWarrantyDate"] == null || row["POOfferToGuaranteePOWarrantyDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POOfferToGuaranteePOWarrantyDate"];
                        POAdjustmentConfirmationDate = (row["POOfferToGuaranteePOWarrantyDate"] == null || row["POOfferToGuaranteePOWarrantyDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POOfferToGuaranteePOWarrantyDate"];
                        POAdjustmentConfirmationNumber = (row["POAdjustmentConfirmationNumber"] == null || row["POAdjustmentConfirmationNumber"] == DBNull.Value) ? "" : row["POAdjustmentConfirmationNumber"].ToString();
                        POGoodQuantityAfterAdjustment = (row["POGoodQuantityAfterAdjustment"] == null || row["POGoodQuantityAfterAdjustment"] == DBNull.Value) ? 0 : (double)row["POGoodQuantityAfterAdjustment"];
                        POQualityCertificationDate = (row["POQualityCertificationDate"] == null || row["POQualityCertificationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POQualityCertificationDate"];
                        POFactoryQualityCertificationDate = (row["POFactoryQualityCertificationDate"] == null || row["POFactoryQualityCertificationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POFactoryQualityCertificationDate"];
                        POAcceptanceLicenceDate = (row["POAcceptanceLicenceDate"] == null || row["POAcceptanceLicenceDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAcceptanceLicenceDate"];
                        POInstallLicenseDate = (row["POInstallLicenseDate"] == null || row["POInstallLicenseDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POInstallLicenseDate"];
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi khi kết nối bảng PO trong CSDL " + e.Message);
                }
            }
        }
        public string POName { get; set; } = "POX";
        public DateTime POCreatedDate { get; set; } = DateTime.Now;
        public double POGoodsQuantity { get; set; } = 0;
        public double POSpareGoodsQuantity => Math.Round(POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero);
        public DateTime POConfirmRequestDeadline { get; set; } = DateTime.Now;
        public DateTime PODefaultPerformDate { get; set; } = DateTime.Now;
        public DateTime POPerformDate { get; set; } = DateTime.Now;
        public DateTime PODeadline { get; set; } = DateTime.Now;
        public double POTotalValue => ContractGoodsUnitPrice * POGoodsQuantity;
        public string POConfirmId { get; set; } = "XXXX/ANSV-DO";
        public DateTime POConfirmCreatedDate { get; set; } = DateTime.Now;
        public string POAdvanceId { get; set; } = "XXXX/ANSV-TCKT";
        public DateTime POAdvanceCreatedDate { get; set; } = DateTime.Now;
        public int POAdvancePercentage { get; set; } = 50;
        public DateTime POAdvanceGuaranteeCreatedDate { get; set; } = DateTime.Now;
        public int POAdvanceGuaranteePercentage { get; set; } = 50;
        public string POAdvanceRequestId { get; set; } = "XXXX/ANSV-TCKT";
        public DateTime POAdvanceRequestCreatedDate { get; set; } = DateTime.Now;
        public DateTime POGuaranteeDate { get; set; } = DateTime.Now;
        public DateTime POReportOfAcceptanceAndHandlingOfGoodsDate { get; set; } = DateTime.Now;
        public DateTime POOfferToGuaranteePOWarrantyDate { get; set; } = DateTime.Now;
        public string POAdjustmentConfirmationNumber { get; set; } = "XXXX/ANSV-DO";
        public double POGoodQuantityAfterAdjustment { get; set; } = 0;
        public double POTotalValueAfterAdjustment => ContractGoodsUnitPrice * POGoodQuantityAfterAdjustment;
        public DateTime POAdjustmentConfirmationDate { get; set; } = DateTime.Now;
        public DateTime POQualityCertificationDate { get; set; } = DateTime.Now;
        public DateTime POFactoryQualityCertificationDate { get; set; } = DateTime.Now;
        public DateTime POAcceptanceLicenceDate { get; set; } = DateTime.Now;
        public DateTime POInstallLicenseDate { get; set; } = DateTime.Now;
        public POObj() { }
        public POObj(ContractObj contract)
        {
            ContractId = contract.ContractId;
            ContractCreatedDate = contract.ContractCreatedDate;
            ContractName = contract.ContractName;
            ContractShoppingPlan = contract.ContractShoppingPlan;
            ContractType = contract.ContractType;
            SiteId = contract.SiteId;
            ContractValidityDate = contract.ContractValidityDate;
            ContractDeadline = contract.ContractDeadline;
            ContractGoodsDesignation = contract.ContractGoodsDesignation;
            ContractGoodsCode = contract.ContractGoodsCode;
            ContractGoodsManufacture = contract.ContractGoodsManufacture;
            ContractGoodsOrigin = contract.ContractGoodsOrigin;
            ContractGoodsDesignation1 = contract.ContractGoodsDesignation1;
            ContractGoodsCode1 = contract.ContractGoodsCode1;
            ContractGoodsCode2 = contract.ContractGoodsCode2;
            ContractGoodsSpecies = contract.ContractGoodsSpecies;
            ContractGoodsNote = contract.ContractGoodsNote;
            ContractGoodsUnit = contract.ContractGoodsUnit;
            ContractGoodsUnitPrice = contract.ContractGoodsUnitPrice;
            ContractGoodsQuantity = contract.ContractGoodsQuantity;
            ContractGoodsLicenseName = contract.ContractGoodsLicenseName;
            ContractGoodsLicenseUnitPrice = contract.ContractGoodsLicenseUnitPrice;
            ContractGuaranteeCreatedDate = contract.ContractGuaranteeCreatedDate;
            POGuaranteeRatio = contract.POGuaranteeRatio;
            POGuaranteeValidityPeriod = contract.POGuaranteeValidityPeriod;
            ContractGuaranteeDeadline = contract.ContractGuaranteeDeadline;
            ContractAccoutingCode = contract.ContractAccoutingCode;
        }
        public void SetContractOfPOObj(ContractObj contract)
        {
            ContractId = contract.ContractId;
            ContractCreatedDate = contract.ContractCreatedDate;
            ContractName = contract.ContractName;
            ContractShoppingPlan = contract.ContractShoppingPlan;
            ContractType = contract.ContractType;
            SiteId = contract.SiteId;
            ContractValidityDate = contract.ContractValidityDate;
            ContractDeadline = contract.ContractDeadline;
            ContractGoodsDesignation = contract.ContractGoodsDesignation;
            ContractGoodsCode = contract.ContractGoodsCode;
            ContractGoodsManufacture = contract.ContractGoodsManufacture;
            ContractGoodsOrigin = contract.ContractGoodsOrigin;
            ContractGoodsDesignation1 = contract.ContractGoodsDesignation1;
            ContractGoodsCode1 = contract.ContractGoodsCode1;
            ContractGoodsCode2 = contract.ContractGoodsCode2;
            ContractGoodsSpecies = contract.ContractGoodsSpecies;
            ContractGoodsNote = contract.ContractGoodsNote;
            ContractGoodsUnit = contract.ContractGoodsUnit;
            ContractGoodsUnitPrice = contract.ContractGoodsUnitPrice;
            ContractGoodsQuantity = contract.ContractGoodsQuantity;
            ContractGoodsLicenseName = contract.ContractGoodsLicenseName;
            ContractGoodsLicenseUnitPrice = contract.ContractGoodsLicenseUnitPrice;
            ContractGuaranteeCreatedDate = contract.ContractGuaranteeCreatedDate;
            POGuaranteeRatio = contract.POGuaranteeRatio;
            POGuaranteeValidityPeriod = contract.POGuaranteeValidityPeriod;
            ContractGuaranteeDeadline = contract.ContractGuaranteeDeadline;
            ContractAccoutingCode = contract.ContractAccoutingCode;
        }
        public POObj SetContractOfPOObj(POObj po, ContractObj contract)
        {
            po.ContractId = contract.ContractId;
            po.ContractCreatedDate = contract.ContractCreatedDate;
            po.ContractName = contract.ContractName;
            po.ContractShoppingPlan = contract.ContractShoppingPlan;
            po.ContractType = contract.ContractType;
            po.SiteId = contract.SiteId;
            po.ContractValidityDate = contract.ContractValidityDate;
            po.ContractDeadline = contract.ContractDeadline;
            po.ContractGoodsDesignation = contract.ContractGoodsDesignation;
            po.ContractGoodsCode = contract.ContractGoodsCode;
            po.ContractGoodsManufacture = contract.ContractGoodsManufacture;
            po.ContractGoodsOrigin = contract.ContractGoodsOrigin;
            po.ContractGoodsDesignation1 = contract.ContractGoodsDesignation1;
            po.ContractGoodsCode1 = contract.ContractGoodsCode1;
            po.ContractGoodsCode2 = contract.ContractGoodsCode2;
            po.ContractGoodsSpecies = contract.ContractGoodsSpecies;
            po.ContractGoodsNote = contract.ContractGoodsNote;
            po.ContractGoodsUnit = contract.ContractGoodsUnit;
            po.ContractGoodsUnitPrice = contract.ContractGoodsUnitPrice;
            po.ContractGoodsQuantity = contract.ContractGoodsQuantity;
            po.ContractGoodsLicenseName = contract.ContractGoodsLicenseName;
            po.ContractGoodsLicenseUnitPrice = contract.ContractGoodsLicenseUnitPrice;
            po.ContractGuaranteeCreatedDate = contract.ContractGuaranteeCreatedDate;
            po.POGuaranteeRatio = contract.POGuaranteeRatio;
            po.POGuaranteeValidityPeriod = contract.POGuaranteeValidityPeriod;
            po.ContractGuaranteeDeadline = contract.ContractGuaranteeDeadline;
            po.ContractAccoutingCode = contract.ContractAccoutingCode;
            return po;
        }


        public POObj(string POId, string POName, double POGoodsQuantity, DateTime POCreatedDate, DateTime POConfirmRequestDeadline, DateTime PODefaultPerformDate, DateTime POPerformDate, DateTime PODeadline, string POConfirmId, DateTime POConfirmCreatedDate, string POAdvanceId, int POAdvancePercentage, DateTime POAdvanceCreatedDate, int POAdvanceGuaranteePercentage, DateTime POAdvanceGuaranteeCreatedDate, string POAdvanceRequestId, DateTime POAdvanceRequestCreatedDate, DateTime POGuaranteeDate)
        {
            this.POId = POId;
            this.POName = POName;
            this.POGoodsQuantity = POGoodsQuantity;
            this.POCreatedDate = POCreatedDate;
            this.POConfirmRequestDeadline = POConfirmRequestDeadline;
            this.PODefaultPerformDate = PODefaultPerformDate;
            this.POPerformDate = POPerformDate;
            this.PODeadline = PODeadline;
            this.POConfirmId = POConfirmId;
            this.POConfirmCreatedDate = POConfirmCreatedDate;
            this.POAdvanceId = POAdvanceId;
            this.POAdvanceCreatedDate = POAdvanceCreatedDate;
            this.POAdvancePercentage = POAdvancePercentage;
            this.POAdvanceGuaranteeCreatedDate = POAdvanceGuaranteeCreatedDate;
            this.POAdvanceGuaranteePercentage = POAdvanceGuaranteePercentage;
            this.POAdvanceRequestId = POAdvanceRequestId;
            this.POAdvanceRequestCreatedDate = POAdvanceRequestCreatedDate;
            this.POGuaranteeDate = POGuaranteeDate;
        }
        public POObj(DataRow row)
        {
            POId = row["POId"].ToString();
            ContractId = (row["ContractId"] == null || row["ContractId"] == DBNull.Value) ? "" : row["ContractId"].ToString();
            POName = (row["POName"] == null || row["POName"] == DBNull.Value) ? "" : row["POName"].ToString();
            POCreatedDate = (row["POCreatedDate"] == null || row["POCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POCreatedDate"];
            POGoodsQuantity = (row["POGoodsQuantity"] == null || row["POGoodsQuantity"] == DBNull.Value) ? 0 : (double)row["POGoodsQuantity"];
            POConfirmRequestDeadline = (row["POConfirmRequestDeadline"] == null || row["POConfirmRequestDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmRequestDeadline"];
            PODefaultPerformDate = (row["PODefaultPerformDate"] == null || row["PODefaultPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODefaultPerformDate"];
            POPerformDate = (row["POPerformDate"] == null || row["POPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POPerformDate"];
            PODeadline = (row["PODeadline"] == null || row["PODeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODeadline"];
            POConfirmId = (row["POConfirmId"] == null || row["POConfirmId"] == DBNull.Value) ? "" : row["POConfirmId"].ToString();
            POConfirmCreatedDate = (row["POConfirmCreatedDate"] == null || row["POConfirmCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmCreatedDate"];
            POAdvancePercentage = (row["POAdvancePercentage"] == null || row["POAdvancePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvancePercentage"];
            POAdvanceId = (row["POAdvanceId"] == null || row["POAdvanceId"] == DBNull.Value) ? "" : row["POAdvanceId"].ToString();
            POAdvanceCreatedDate = (row["POAdvanceCreatedDate"] == null || row["POAdvanceCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceCreatedDate"];
            POAdvanceGuaranteePercentage = (row["POAdvanceGuaranteePercentage"] == null || row["POAdvanceGuaranteePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvanceGuaranteePercentage"];
            POAdvanceGuaranteeCreatedDate = (row["POAdvanceGuaranteeCreatedDate"] == null || row["POAdvanceGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceGuaranteeCreatedDate"];
            POAdvanceRequestId = (row["POAdvanceRequestId"] == null || row["POAdvanceRequestId"] == DBNull.Value) ? "" : row["POAdvanceRequestId"].ToString();
            POAdvanceRequestCreatedDate = (row["POAdvanceRequestCreatedDate"] == null || row["POAdvanceRequestCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceRequestCreatedDate"];
            POGuaranteeDate = (row["POGuaranteeDate"] == null || row["POGuaranteeDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POGuaranteeDate"];
            POReportOfAcceptanceAndHandlingOfGoodsDate = (row["POReportOfAcceptanceAndHandlingOfGoodsDate"] == null || row["POReportOfAcceptanceAndHandlingOfGoodsDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POReportOfAcceptanceAndHandlingOfGoodsDate"];
            POOfferToGuaranteePOWarrantyDate = (row["POOfferToGuaranteePOWarrantyDate"] == null || row["POOfferToGuaranteePOWarrantyDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POOfferToGuaranteePOWarrantyDate"];
            POAdjustmentConfirmationDate = (row["POOfferToGuaranteePOWarrantyDate"] == null || row["POOfferToGuaranteePOWarrantyDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POOfferToGuaranteePOWarrantyDate"];
            POAdjustmentConfirmationNumber = (row["POAdjustmentConfirmationNumber"] == null || row["POAdjustmentConfirmationNumber"] == DBNull.Value) ? "" : row["POAdjustmentConfirmationNumber"].ToString();
            POGoodQuantityAfterAdjustment = (row["POGoodQuantityAfterAdjustment"] == null || row["POGoodQuantityAfterAdjustment"] == DBNull.Value) ? 0 : (double)row["POGoodQuantityAfterAdjustment"];
            POQualityCertificationDate = (row["POQualityCertificationDate"] == null || row["POQualityCertificationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POQualityCertificationDate"];
            POFactoryQualityCertificationDate = (row["POFactoryQualityCertificationDate"] == null || row["POFactoryQualityCertificationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POFactoryQualityCertificationDate"];
            POAcceptanceLicenceDate = (row["POAcceptanceLicenceDate"] == null || row["POAcceptanceLicenceDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAcceptanceLicenceDate"];
            POInstallLicenseDate = (row["POInstallLicenseDate"] == null || row["POInstallLicenseDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POInstallLicenseDate"];
        }
        public POObj(string id)
        {
            POId = id;
            try
            {
                string query = string.Format("SELECT * FROM dbo.PO WHERE POId = '{0}'", id);
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    ContractId = (row["ContractId"] == null || row["ContractId"] == DBNull.Value) ? "" : row["ContractId"].ToString();
                    POName = (row["POName"] == null || row["POName"] == DBNull.Value) ? "" : row["POName"].ToString();
                    POGoodsQuantity = (row["POGoodsQuantity"] == null || row["POGoodsQuantity"] == DBNull.Value) ? 0 : (double)row["POGoodsQuantity"];
                    POCreatedDate = (row["POCreatedDate"] == null || row["POCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POCreatedDate"];
                    POConfirmRequestDeadline = (row["POConfirmRequestDeadline"] == null || row["POConfirmRequestDeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmRequestDeadline"];
                    PODefaultPerformDate = (row["PODefaultPerformDate"] == null || row["PODefaultPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODefaultPerformDate"];
                    POPerformDate = (row["POPerformDate"] == null || row["POPerformDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POPerformDate"];
                    PODeadline = (row["PODeadline"] == null || row["PODeadline"] == DBNull.Value) ? DateTime.Now : (DateTime)row["PODeadline"];
                    POConfirmId = (row["POConfirmId"] == null || row["POConfirmId"] == DBNull.Value) ? "" : row["POConfirmId"].ToString();
                    POConfirmCreatedDate = (row["POConfirmCreatedDate"] == null || row["POConfirmCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POConfirmCreatedDate"];
                    POAdvancePercentage = (row["POAdvancePercentage"] == null || row["POAdvancePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvancePercentage"];
                    POAdvanceId = (row["POAdvanceId"] == null || row["POAdvanceId"] == DBNull.Value) ? "" : row["POAdvanceId"].ToString();
                    POAdvanceCreatedDate = (row["POAdvanceCreatedDate"] == null || row["POAdvanceCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceCreatedDate"];
                    POAdvanceGuaranteePercentage = (row["POAdvanceGuaranteePercentage"] == null || row["POAdvanceGuaranteePercentage"] == DBNull.Value) ? 0 : (int)row["POAdvanceGuaranteePercentage"];
                    POAdvanceGuaranteeCreatedDate = (row["POAdvanceGuaranteeCreatedDate"] == null || row["POAdvanceGuaranteeCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceGuaranteeCreatedDate"];
                    POAdvanceRequestId = (row["POAdvanceRequestId"] == null || row["POAdvanceRequestId"] == DBNull.Value) ? "" : row["POAdvanceRequestId"].ToString();
                    POAdvanceRequestCreatedDate = (row["POAdvanceRequestCreatedDate"] == null || row["POAdvanceRequestCreatedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAdvanceRequestCreatedDate"];
                    POGuaranteeDate = (row["POGuaranteeDate"] == null || row["POGuaranteeDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POGuaranteeDate"];
                    POReportOfAcceptanceAndHandlingOfGoodsDate = (row["POReportOfAcceptanceAndHandlingOfGoodsDate"] == null || row["POReportOfAcceptanceAndHandlingOfGoodsDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POReportOfAcceptanceAndHandlingOfGoodsDate"];
                    POOfferToGuaranteePOWarrantyDate = (row["POOfferToGuaranteePOWarrantyDate"] == null || row["POOfferToGuaranteePOWarrantyDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POOfferToGuaranteePOWarrantyDate"];
                    POAdjustmentConfirmationDate = (row["POOfferToGuaranteePOWarrantyDate"] == null || row["POOfferToGuaranteePOWarrantyDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POOfferToGuaranteePOWarrantyDate"];
                    POAdjustmentConfirmationNumber = (row["POAdjustmentConfirmationNumber"] == null || row["POAdjustmentConfirmationNumber"] == DBNull.Value) ? "" : row["POAdjustmentConfirmationNumber"].ToString();
                    POGoodQuantityAfterAdjustment = (row["POGoodQuantityAfterAdjustment"] == null || row["POGoodQuantityAfterAdjustment"] == DBNull.Value) ? 0 : (double)row["POGoodQuantityAfterAdjustment"];
                    POQualityCertificationDate = (row["POQualityCertificationDate"] == null || row["POQualityCertificationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POQualityCertificationDate"];
                    POFactoryQualityCertificationDate = (row["POFactoryQualityCertificationDate"] == null || row["POFactoryQualityCertificationDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POFactoryQualityCertificationDate"];
                    POAcceptanceLicenceDate = (row["POAcceptanceLicenceDate"] == null || row["POAcceptanceLicenceDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POAcceptanceLicenceDate"];
                    POInstallLicenseDate = (row["POInstallLicenseDate"] == null || row["POInstallLicenseDate"] == DBNull.Value) ? DateTime.Now : (DateTime)row["POInstallLicenseDate"];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi kết nối bảng PO trong CSDL " + e.Message);
            }
        }
        public bool POExist()
        {
            string query = string.Format("SELECT * FROM dbo.PO WHERE POId = '{0}'", POId);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public static bool POExist(string id)
        {
            string query = string.Format("SELECT * FROM dbo.PO WHERE POId = '{0}'", id);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int POInsert(string id)
        {
            if (POObj.POExist(id)) return 0;
            if (ContractObj.ContractExist(ContractId))
            {
                string query = string.Format(@"SET DATEFORMAT DMY INSERT INTO dbo.PO(POId,ContractId,POName,POCreatedDate,POGoodsQuantity,POConfirmRequestDeadline,PODefaultPerformDate,POPerformDate,PODeadline,POConfirmId,POConfirmCreatedDate,POAdvanceId,POAdvanceCreatedDate,POAdvancePercentage,POAdvanceGuaranteeCreatedDate,POAdvanceGuaranteePercentage,POAdvanceRequestId,POAdvanceRequestCreatedDate,POGuaranteeDate,POReportOfAcceptanceAndHandlingOfGoodsDate,POOfferToGuaranteePOWarrantyDate,POAdjustmentConfirmationNumber,POGoodQuantityAfterAdjustment,POAdjustmentConfirmationDate,POQualityCertificationDate,POFactoryQualityCertificationDate,POAcceptanceLicenceDate,POInstallLicenseDate)VALUES('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},'{14}',{15},'{16}','{17}','{18}','{19}','{20}','{21}',{22},'{23}','{24}','{25}','{26}','{27}')", id, ContractId, POName, POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGoodsQuantity, POConfirmRequestDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODefaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POConfirmId, POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceId, POAdvanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvancePercentage, POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceGuaranteePercentage, POAdvanceRequestId, POAdvanceRequestCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGuaranteeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POReportOfAcceptanceAndHandlingOfGoodsDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POOfferToGuaranteePOWarrantyDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdjustmentConfirmationNumber, POGoodQuantityAfterAdjustment, POAdjustmentConfirmationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POQualityCertificationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POFactoryQualityCertificationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAcceptanceLicenceDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POInstallLicenseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                return OPMDBHandler.ExecuteNonQuery(query);
            }
            return 0;
        }
        public int POUpdate(string newId, string oldId)             //Giữ nguyên IdContract đổi Id
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.PO SET POId = '{0}', ContractId = '{1}', POName = '{2}', POCreatedDate = '{3}', POGoodsQuantity = {4},POConfirmRequestDeadline = '{5}',PODefaultPerformDate = '{6}',POPerformDate = '{7}',PODeadline = '{8}',POConfirmId = '{9}',POConfirmCreatedDate = '{10}',POAdvanceId = '{11}',POAdvanceCreatedDate = '{12}', POAdvancePercentage = {13}, POAdvanceGuaranteeCreatedDate = '{14}', POAdvanceGuaranteePercentage = {15}, POAdvanceRequestId = '{16}', POAdvanceRequestCreatedDate= '{17}',POGuaranteeDate='{18}',POReportOfAcceptanceAndHandlingOfGoodsDate='{19}',POOfferToGuaranteePOWarrantyDate = '{20}',POAdjustmentConfirmationNumber = '{21}',POGoodQuantityAfterAdjustment = {22}, POAdjustmentConfirmationDate = '{23}',POQualityCertificationDate = '{24}',POFactoryQualityCertificationDate = '{25}',POAcceptanceLicenceDate = '{26}',POInstallLicenseDate = '{27}' WHERE POId = '{28}'", newId, ContractId, POName, POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGoodsQuantity, POConfirmRequestDeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODefaultPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POConfirmId, POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceId, POAdvanceCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvancePercentage, POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdvanceGuaranteePercentage, POAdvanceRequestId, POAdvanceRequestCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POGuaranteeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POReportOfAcceptanceAndHandlingOfGoodsDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POOfferToGuaranteePOWarrantyDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAdjustmentConfirmationNumber, POGoodQuantityAfterAdjustment, POAdjustmentConfirmationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POQualityCertificationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POFactoryQualityCertificationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POAcceptanceLicenceDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), POInstallLicenseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")), oldId);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static int PODelete(string id)
        {
            string query = string.Format("DELETE FROM dbo.PO WHERE POId = '{0}'", id);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
        public static double POGoodsQuantityTotalByContractId(string ContractId)
        {
            string query = string.Format(@"SELECT SUM(POGoodsQuantity) FROM PO WHERE ContractId = '{0}'", ContractId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return tem;
        }
        public static double POSpareGoodsQuantityTotalByContractId(string ContractId)
        {
            string query = string.Format(@"SELECT SUM(POGoodsQuantity) FROM PO WHERE ContractId = '{0}'", ContractId);
            var tem1 = OPMDBHandler.ExecuteScalar(query);
            double tem = (tem1 == null || tem1 == DBNull.Value) ? 0 : (double)tem1;
            return Math.Round(tem * 0.02, 0, MidpointRounding.AwayFromZero);
        }
        public static DataTable PODeliveryPlanQuantity(string POId)
        {
            string query = string.Format(@"SELECT VNPTId, SUM(DeliveryPlanQuantity) AS DeliveryPlanQuantity, (SELECT dbo.Contract.ContractGoodsUnitPrice FROM dbo.Contract, dbo.PO WHERE po.POId = '{0}' AND dbo.PO.ContractId = dbo.Contract.ContractId) AS ContractGoodsUnitPrice FROM DeliveryPlan WHERE POId = '{0}' GROUP BY VNPTId", POId);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static List<POObj> POGetList()
        {
            List<POObj> list = new List<POObj>();
            string query = string.Format("SELECT * FROM dbo.PO");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                POObj po = new POObj(item);
                list.Add(po);
            }
            return list;
        }
        public static List<POObj> POGetListByContractId(string contractId)
        {
            List<POObj> list = new List<POObj>();
            string query = string.Format("SELECT * FROM dbo.PO Where ContractId = '{0}' Order By POName", contractId);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                POObj po = new POObj(item);
                list.Add(po);
            }
            return list;
        }

    }
}