using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace OPM.OPMWordHandler
{
    class OpmWordHandler
    {
        //Mẫu 39. Công văn xác nhận điều chỉnh hợp đồng
        public static string Temp39_POAdjustmentConfirmation(string poid)
        {
            POObj po = new POObj(poid);
            object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPM\Template\Mẫu 39. Công văn xác nhận điều chỉnh đơn hàng.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm 1>", string.Format("ngày {0} tháng {1} năm {2}", po.POAdjustmentConfirmationDate.Day, po.POAdjustmentConfirmationDate.Month, po.POAdjustmentConfirmationDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<POAdjustmentConfirmationNumber>", po.POAdjustmentConfirmationNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsQuantity>", po.ContractGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodQuantityAfterAdjustment>", po.POGoodQuantityAfterAdjustment);
                //OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POConfirmCreatedDate.Day, po.POConfirmCreatedDate.Month, po.POConfirmCreatedDate.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                //OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteeCreatedDate>", po.POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##0.##}", po.POTotalValue * 1.1));
                //OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeRatio>", po.POGuaranteeRatio.ToString());
                //OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeValidityPeriod>", po.POGuaranteeValidityPeriod.ToString());

                //Tạo file BLHĐ trong thư mục D:\OPM
                try
                {
                    string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                    Directory.CreateDirectory(folder);
                    myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));

                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", filename.ToString()) + e.Message);
                }
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(string.Format(@"Không đọc được file {0} do lỗi ", path.ToString()) + e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 37
        public static string Temp37_POBBXNCDLicense(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 37. Biên bản xác nhận cài đặt License vào hệ thống.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            Word.Document myDoc = null;
            try
            {
                //NTKT_Thanh ntkt = new NTKT_Thanh(id);
                POObj po = new POObj(poid);
                ContractObj contract = new ContractObj(po.ContractId);
                SiteObj site = new SiteObj(contract.SiteId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 37. Biên bản xác nhận cài đặt License vào hệ thống_{2}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
                object missing = Missing.Value;
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;
                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POInstallLicenseDate.Day, po.POInstallLicenseDate.Month, po.POInstallLicenseDate.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", po.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);


                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmCreatedDate>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<POQualityCertificationDate>", po.POQualityCertificationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POInstallLicenseDate>", po.POInstallLicenseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                //OpmWordHandler.FindAndReplace(wordApp, "<SitePhonenumber>", po.SitePhonenumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative1>", po.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<SiteFaxNumber>", po.SiteFaxNumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<SitePosition1>", po.SitePosition1);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", po.SiteHeadquater);
                //OpmWordHandler.FindAndReplace(wordApp, "<SiteAddress>", po.SiteAddress);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", po.SiteBankAccount);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_CNBQPM>", ntkt.Date_CNBQPM.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Total>", ntkt.Numberofdevice2 + ntkt.Numberofdevice);
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 36
        public static string Temp36_POBBNTLicense(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 36. Biên bản nghiệm thu License.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                //NTKT_Thanh ntkt = new NTKT_Thanh(id);
                POObj po = new POObj(poid);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 36. Biên bản nghiệm thu License_{2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;
                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POAcceptanceLicenceDate.Day, po.POAcceptanceLicenceDate.Month, po.POAcceptanceLicenceDate.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", po.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);


                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmCreatedDate>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<POQualityCertificationDate>", po.POQualityCertificationDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POInstallLicenseDate>", po.POInstallLicenseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                OpmWordHandler.FindAndReplace(wordApp, "<SitePhonenumber>", po.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative1>", po.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteFaxNumber>", po.SiteFaxNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePosition1>", po.SitePosition1);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", po.SiteHeadquater);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteAddress>", po.SiteAddress);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", po.SiteBankAccount);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_CNBQPM>", ntkt.Date_CNBQPM.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Total>", ntkt.Numberofdevice2 + ntkt.Numberofdevice);
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Mẫu 33: Đề nghị bảo lãnh bảo hành hợp đồng theo đơn hàng
        public static string Temp33_POOfferToGuaranteeWarranty(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 33. Văn bản đề nghị mở BLBH PO.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                POObj po = new POObj(poid);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 33. Văn bản đề nghị mở BLBH PO_{2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                //OpmWordHandler.FindAndReplace(wordApp, "<SiteAddress>", po.SiteAddress);
                //OpmWordHandler.FindAndReplace(wordApp, "<SitePhonenumber>", po.SitePhonenumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<SiteFaxNumber>", po.SiteFaxNumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative1>", po.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<SitePosition1>", po.SitePosition1);
                //OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                //OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                //OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                //OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", po.ContractGoodsCode);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsManufacture>", po.ContractGoodsManufacture);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", po.ContractGoodsOrigin);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<POOfferToGuaranteePOWarrantyDate>", po.POOfferToGuaranteePOWarrantyDate);
                OpmWordHandler.FindAndReplace(wordApp, "<POReportOfAcceptanceAndHandlingOfGoodsDate>", po.POReportOfAcceptanceAndHandlingOfGoodsDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();

            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Mẫu 30: Biên bản thanh lý hợp đồng
        public static string Temp30_ContractLiquidationRecords(string contractId)
        {
            object path = @"D:\OPM\Template\Mẫu 30. Biên bản thanh lý hợp đồng.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                ContractObj contract = new ContractObj(contractId);
                object filename = string.Format(@"D:\OPM\{0}\Mẫu 30. Biên bản thanh lý hợp đồng {0}.docx", contract.ContractId.Trim().Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", contract.ContractLiquidationRecordsDate.Day, contract.ContractLiquidationRecordsDate.Month, contract.ContractLiquidationRecordsDate.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", contract.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteAddress>", contract.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePhonenumber>", contract.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteFaxNumber>", contract.SiteFaxNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative1>", contract.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePosition1>", contract.SitePosition1);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteBankAccount>", contract.SiteBankAccount);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteNameOfBank>", contract.SiteNameOfBank);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteTaxCode>", contract.SiteTaxCode);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", contract.ContractGoodsCode);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", contract.ContractGoodsDesignation);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsManufacture>", contract.ContractGoodsManufacture);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", contract.ContractGoodsOrigin);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", contract.ContractGoodsUnit);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsNote>", contract.ContractGoodsNote);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsQuantity>", contract.ContractGoodsQuantity);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", contract.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractValue>", contract.ContractValue);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractVAT>", Math.Round(contract.ContractValue * 0.1));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractAfterVATValue>", contract.ContractValue * 1.1);
                OpmWordHandler.FindAndReplace(wordApp, "<Số tiền bằng chữ>", NumberToString(Math.Round(contract.ContractValue * 1.1)));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractTotalAmountPaid>", contract.ContractTotalAmountPaid);
                OpmWordHandler.FindAndReplace(wordApp, "<Số tiền còn lại>", contract.ContractValue * 1.1 - contract.ContractTotalAmountPaid);
                OpmWordHandler.FindAndReplace(wordApp, "<Số tiền bằng chữ 1>", NumberToString(Math.Round(contract.ContractValue * 1.1 - contract.ContractTotalAmountPaid)));

                //Thêm phần căn cứ vào biên bản
                System.Collections.Generic.List<POObj> pOs = POObj.POGetListByContractId(contractId);
                
                int temp = pOs.Count;
                Word.Table table1 = myDoc.Tables[1];
                Word.Table table2 = myDoc.Tables[2];
                for (int i=0; i< temp;i++)
                {
                    string temp1 = "Căn cứ Thư đặt hàng " + pOs[i].POName + " số " + pOs[i].POId + " ngày " + pOs[i].POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")) + " của " + pOs[i].SiteName + ";";
                    string temp2 = "Căn cứ Biên bản nghiệm thu, bàn giao hàng hóa theo đơn đặt hàng " + pOs[i].POName;
                    table1.Cell(i + 1, 1).Range.Text = temp1;
                    table1.Rows.Add();
                    table2.Cell(i + 1, 1).Range.Text = temp2; 
                    table2.Rows.Add();
                }

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}", contract.ContractId.Trim().Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
                //Word.Table table = myDoc.Tables[3];
                //for (i = 0; i < rowCount; i++)
                //{
                //    table.Rows.Add();
                //    table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                //    table.Cell(i + 2, 2).Range.Text = dataTable.Rows[i].ItemArray[1].ToString();
                //    table.Cell(i + 2, 3).Range.Text = dataTable.Rows[i].ItemArray[2].ToString();
                //    table.Cell(i + 2, 4).Range.Text = dataTable.Rows[i].ItemArray[3].ToString();
                //}

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); 
                myDoc.Close();
                wordApp.Quit();
                return e.Message;
            }
        }
        //Mẫu 29: Biên bản xác nhận khối lượng hoàn thành
        public static string Temp29_ContractReportOfConpletedVolume(string contractId)
        {
            object path = @"D:\OPM\Template\Mẫu 29. Biên bản xác nhận khối lượng hoàn thành.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                ContractObj contract = new ContractObj(contractId);
                object filename = string.Format(@"D:\OPM\{0}\Mẫu 29. Biên bản xác nhận khối lượng hoàn thành {0}.docx", contract.ContractId.Trim().Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", contract.ContractReportOfConpletedVolumeDate.Day, contract.ContractReportOfConpletedVolumeDate.Month, contract.ContractReportOfConpletedVolumeDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", contract.ContractShoppingPlan);
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", contract.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteAddress>", contract.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePhonenumber>", contract.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteFaxNumber>", contract.SiteFaxNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative1>", contract.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePosition1>", contract.SitePosition1);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", contract.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", contract.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsManufacture>", contract.ContractGoodsManufacture);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", contract.ContractGoodsOrigin);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", contract.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsNote>", contract.ContractGoodsNote);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsQuantity>", contract.ContractGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", contract.ContractGoodsUnitPrice);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractValue>", contract.ContractValue);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractVAT>", Math.Round(contract.ContractValue*0.1));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractAfterVATValue>", Math.Round(contract.ContractValue * 1.1));
                OpmWordHandler.FindAndReplace(wordApp, "<Số tiền bằng chữ>", NumberToString(Math.Round(contract.ContractValue * 1.1)));
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}", contract.ContractId.Trim().Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();

            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Mẫu 28: Biên bản nghiệm thu và bàn giao hàng hoá
        public static string Temp28_POReportOfAcceptanceAndHandlingOfGoods(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 28. Biên bản nghiệm thu bàn giao hàng hóa.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                POObj po = new POObj(poid);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 28. Biên bản nghiệm thu bàn giao hàng hóa_{2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                //OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteAddress>", po.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePhonenumber>", po.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteFaxNumber>", po.SiteFaxNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative1>", po.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePosition1>", po.SitePosition1);
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", po.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsManufacture>", po.ContractGoodsManufacture);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", po.ContractGoodsOrigin);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsNote>", po.ContractGoodsNote);
                OpmWordHandler.FindAndReplace(wordApp, "<POReportOfAcceptanceAndHandlingOfGoodsDate>", po.POReportOfAcceptanceAndHandlingOfGoodsDate);
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();

            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 26 - Biên bản xác nhận tiến độ thực hiện giao hàng
        public static void Temp26_MinutesConfirmingDeliveryProgressPO(string poid)
        {
            try
            {
                POObj po = new POObj(poid);
                List< PODeliveryProgressObj> list = PODeliveryProgressObj.PODeliveryProgressGetListByPOId(poid);
                for(int n = 0;n<list.Count;n++)
                {
                    if (list[n].PODeliveryProgressRemainingQuantity == 0)
                    {
                        if(list[n].PODeliveryProgressLastDeliveredDate <= list[n].PODeadline)
                        {
                            Word.Application wordApp = new Word.Application();
                            object missing = Missing.Value;
                            object path;
                            object filename;
                            object readOnly = true;
                            wordApp.Visible = false;
                            Word.Document myDoc = null;
                            path = @"D:\OPM\Template\Mẫu 26. Biên bản xác nhận tiến độ_Đúng hạn.docx";
                            if (!File.Exists(path.ToString()))
                            {
                                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                                return;
                            }
                            filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 26. Biên bản xác nhận tiến độ_Đúng hạn_{2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), list[n].PODeliveryProgressVNPTName.Replace('/', '-'));
                            //object isVisible = false;

                            myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing);
                            myDoc.Activate();
                            //find and replace
                            OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                            OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                            OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                            OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                            OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                            OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            OpmWordHandler.FindAndReplace(wordApp, "<PODeadline>", po.PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            SiteObj vnpt = new SiteObj(list[n].PODeliveryProgressVNPTId);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SitePosition1>", vnpt.SitePosition1);
                            OpmWordHandler.FindAndReplace(wordApp, "<PODeliveryProgressLastDeliveredDate>", list[n].PODeliveryProgressLastDeliveredDate);
                            //Tạo file BLHĐ trong thư mục D:\OPM
                            string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                            Directory.CreateDirectory(folder);
                            myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing);
                            MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                            myDoc.Close();
                            wordApp.Quit();
                        }
                        else
                        {
                            Word.Application wordApp = new Word.Application();
                            object missing = Missing.Value;
                            object path;
                            object filename;
                            object readOnly = true;
                            wordApp.Visible = false;
                            Word.Document myDoc = null;
                            path = @"D:\OPM\Template\Mẫu 26. Biên bản xác nhận tiến độ_Chậm tiến độ.docx";
                            if (!File.Exists(path.ToString()))
                            {
                                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                                return;
                            }
                            filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 26. Biên bản xác nhận tiến độ_Chậm tiến độ_{2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), list[n].PODeliveryProgressVNPTName.Replace('/', '-'));
                            //object isVisible = false;

                            myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing);
                            myDoc.Activate();
                            //find and replace
                            OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                            OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                            OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                            OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                            OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                            OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            OpmWordHandler.FindAndReplace(wordApp, "<PODeadline>", po.PODeadline.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                            OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                            OpmWordHandler.FindAndReplace(wordApp, "<PODeliveryProgressDeliveryQuantity>", list[n].PODeliveryProgressDeliveryQuantity);
                            OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsNote>", po.ContractGoodsNote);
                            SiteObj vnpt = new SiteObj(list[n].PODeliveryProgressVNPTId);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                            OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SitePosition1>", vnpt.SitePosition1);
                            OpmWordHandler.FindAndReplace(wordApp, "<PODeliveryProgressLastDeliveredDate>", list[n].PODeliveryProgressLastDeliveredDate);
                            //Tạo bảng chi tiết trễ tiến độ
                            DataTable dataTable = PLObj.GetDataTableByPOIdAndVNPTId(poid, list[n].PODeliveryProgressVNPTId);
                            int rowCount = dataTable.Rows.Count;
                            int columnCount = dataTable.Columns.Count;
                            int i;
                            Word.Table table = myDoc.Tables[5];
                            for (i = 0; i < rowCount; i++)
                            {
                                table.Rows.Add();
                                table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                                table.Cell(i + 2, 2).Range.Text = po.ContractGoodsDesignation;
                                table.Cell(i + 2, 3).Range.Text = dataTable.Rows[i].ItemArray[3].ToString(); ;
                                DateTime temp = (DateTime)dataTable.Rows[i].ItemArray[4];
                                table.Cell(i + 2, 4).Range.Text = temp.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"));
                                if(temp<=po.PODeadline)
                                {
                                    table.Cell(i + 2, 5).Range.Text = "0";
                                }
                                else
                                {
                                    TimeSpan t = temp - po.PODeadline;
                                    table.Cell(i + 2, 5).Range.Text = t.TotalDays.ToString();
                                }
                                //string temp = dataTable.Rows[i].ItemArray[1].ToString();
                                //double temp1 = double.Parse(temp);
                                //table.Cell(i + 2, 3).Range.Text = temp;
                                //table.Cell(i + 2, 4).Range.Text = (Math.Round(temp1 * 0.02, 0, MidpointRounding.AwayFromZero)).ToString();
                                //table.Cell(i + 2, 5).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.ContractGoodsUnitPrice);
                                //table.Cell(i + 2, 6).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", temp1 * po.ContractGoodsUnitPrice);
                                //table.Cell(i + 2, 7).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", temp1 * 0.02 * po.ContractGoodsUnitPrice);
                                //table.Cell(i + 2, 8).Range.Text = dataTable.Rows[i].ItemArray[2].ToString();
                            }
                            //OpmWordHandler.FindAndReplace(wordApp, "12:00:00 SA", "");
                            //MessageBox.Show(i.ToString());
                            //table.Cell(i + 2, 2).Range.Text = "TỔNG CỘNG";
                            //table.Cell(i + 2, 3).Range.Text = po.POGoodsQuantity.ToString();
                            //Tạo file BLHĐ trong thư mục D:\OPM
                            string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                            Directory.CreateDirectory(folder);
                            myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing);
                            MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                            myDoc.Close();
                            wordApp.Quit();

                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Vẫn chưa giao hết số lượng của đơn hàng {0}, {1} yêu cầu giao {2}, đã giao {3} tính đến ngày {4}", po.POName, list[n].PODeliveryProgressVNPTName, list[n].PODeliveryProgressDeliveryQuantity, list[n].PODeliveryProgressDeliveredQuantity, list[n].PODeliveryProgressLastDeliveredDate));
                    }

                }
            }
            catch (Exception e)
            {
                //myDoc.Close();
                //wordApp.Quit();
                MessageBox.Show(e.Message);
                return;
            }
        }

        //Tạo mẫu 25 - Đề nghị phát hoá đơn cho các viễn thông tỉnh theo PO
        public static string Temp25_InvoicingRequestPO(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 25. Đề nghị phát hoá đơn cho các viễn thông tỉnh theo PO.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                POObj po = new POObj(poid);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 25. Đề nghị phát hoá đơn cho các viễn thông tỉnh theo PO_{2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<POInvoicingRequestDate>", po.POInvoicingRequestDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                //OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                //OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                //OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                //Tạo bảng phụ lục yêu cầu phát hoá đơn
                DataTable dataTable = DeliveryPlanObj.InvoicingRequestDataTable(poid);
                int rowCount = dataTable.Rows.Count;
                int columnCount = dataTable.Columns.Count;
                int i;
                Word.Table table = myDoc.Tables[3];
                for (i = 0; i < rowCount; i++)
                {
                    table.Rows.Add();
                    table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                    table.Cell(i + 2, 2).Range.Text = dataTable.Rows[i].ItemArray[0].ToString();
                    string temp = dataTable.Rows[i].ItemArray[1].ToString();
                    double temp1 = double.Parse(temp);
                    table.Cell(i + 2, 3).Range.Text = temp;
                    table.Cell(i + 2, 4).Range.Text = (Math.Round(temp1* 0.02, 0, MidpointRounding.AwayFromZero)).ToString();
                    table.Cell(i + 2, 5).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.ContractGoodsUnitPrice);
                    table.Cell(i + 2, 6).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", temp1*po.ContractGoodsUnitPrice);
                    table.Cell(i + 2, 7).Range.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", temp1*0.02 * po.ContractGoodsUnitPrice);
                    DateTime temp2 = (DateTime)dataTable.Rows[i].ItemArray[2];
                    table.Cell(i + 2, 8).Range.Text = temp2.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"));
                }
                //OpmWordHandler.FindAndReplace(wordApp, "12:00:00 SA", "");
                //MessageBox.Show(i.ToString());
                //table.Cell(i + 2, 2).Range.Text = "TỔNG CỘNG";
                //table.Cell(i + 2, 3).Range.Text = po.POGoodsQuantity.ToString();
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();

            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }

        //Tạo mẫu 24 - Giấy chứng nhận chất lượng từ nhà máy tổng hợp PO
        public static string Temp24_POCNCLNMTongHop(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 24. Giấy chứng nhận chất lượng từ nhà máy tổng hợp PO.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                //NTKT_Thanh ntkt = new NTKT_Thanh(id);
                POObj po = new POObj(poid);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 24. Giấy chứng nhận chất lượng từ nhà máy tổng hợp PO_{2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POQualityCertificationDate.Day, po.POQualityCertificationDate.Month, po.POQualityCertificationDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", po.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();

            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }

        //Tạo mẫu 23
        public static string Temp23_POCNCL_TongHop(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 23. Giấy chứng nhận chất lượng tổng hợp PO.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                //NTKT_Thanh ntkt = new NTKT_Thanh(id);
                POObj po = new POObj(poid);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 23. Giấy chứng nhận chất lượng tổng hợp PO_{2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", po.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", po.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", po.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<POGoodsQuantity1>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POFactoryQualityCertificationDate.Day, po.POFactoryQualityCertificationDate.Month, po.POFactoryQualityCertificationDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));




                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 22: Phiếu bảo hành
        public static string Temp22_PLWarranty(string PLId)
        {
            object path = @"D:\OPM\Template\Mẫu 22. Mẫu phiếu bảo hành.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                PLObj pl = new PLObj(PLId);
                SiteObj vnpt = new SiteObj(pl.VNPTId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\DP{2}\Mẫu 22. Mẫu phiếu bảo hành_{3}.docx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                //OpmWordHandler.FindAndReplace(wordApp, "<DPVNPTTechANSVContractNumber>", pl.DPVNPTTechANSVContractNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", pl.ContractId);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", pl.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", pl.SiteName);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", pl.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", pl.POName);
                //OpmWordHandler.FindAndReplace(wordApp, "<POId>", pl.POId);
                //OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", pl.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<PLDate>", pl.PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy1>", vnpt.SiteProxy1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative2>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy2>", vnpt.SiteProxy1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative3>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy3>", vnpt.SiteProxy1);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation1>", pl.ContractGoodsDesignation1);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", pl.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", pl.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", pl.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsManufacture>", pl.ContractGoodsManufacture);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", pl.ContractGoodsOrigin);
                OpmWordHandler.FindAndReplace(wordApp, "<PLQuantity>", pl.PLQuantity);
                //OpmWordHandler.FindAndReplace(wordApp, "<PLQuantity1>", Math.Round(pl.PLQuantity * 0.02));
                //OpmWordHandler.FindAndReplace(wordApp, "<PLQuantityTotal>", pl.PLQuantity + Math.Round(pl.PLQuantity * 0.02));
                //OpmWordHandler.FindAndReplace(wordApp, "<PLQualityInspectionCertificateDate>", pl.PLQualityInspectionCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                //OpmWordHandler.FindAndReplace(wordApp, "<DPId>", pl.DPId);
                //OpmWordHandler.FindAndReplace(wordApp, "<DeviceCaseNumberRange>", DeviceObj.DeviceCaseNumberRange(PLId));
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<TotalPreVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<VAT>", 0.1 * pl.PLQuantity * pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<TotalAfterVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice * 1.1);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 20: Giấy chứng nhận chất lượng
        public static string Temp20_PLQualityInspectionCertificate(string PLId)
        {
            object path = @"D:\OPM\Template\Mẫu 20. Giấy chứng nhận chất lượng gửi tỉnh.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                PLObj pl = new PLObj(PLId);
                SiteObj vnpt = new SiteObj(pl.VNPTId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\DP{2}\Mẫu 20. Giấy chứng nhận chất lượng gửi tỉnh_{3}.docx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<DPVNPTTechANSVContractNumber>", pl.DPVNPTTechANSVContractNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", pl.ContractId);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", pl.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", pl.SiteName);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", pl.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", pl.POName);
                //OpmWordHandler.FindAndReplace(wordApp, "<POId>", pl.POId);
                //OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", pl.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<PLDate>", pl.PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy1>", vnpt.SiteProxy1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative2>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy2>", vnpt.SiteProxy1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative3>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy3>", vnpt.SiteProxy1);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation1>", pl.ContractGoodsDesignation1);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", pl.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", pl.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", pl.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsManufacture>", pl.ContractGoodsManufacture);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", pl.ContractGoodsOrigin);
                OpmWordHandler.FindAndReplace(wordApp, "<PLQuantity>", pl.PLQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<PLQuantity1>", Math.Round(pl.PLQuantity * 0.02));
                OpmWordHandler.FindAndReplace(wordApp, "<PLQuantityTotal>", pl.PLQuantity + Math.Round(pl.PLQuantity * 0.02));
                OpmWordHandler.FindAndReplace(wordApp, "<PLQualityInspectionCertificateDate>", pl.PLQualityInspectionCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                
                //OpmWordHandler.FindAndReplace(wordApp, "<DPId>", pl.DPId);
                //OpmWordHandler.FindAndReplace(wordApp, "<DeviceCaseNumberRange>", DeviceObj.DeviceCaseNumberRange(PLId));
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<TotalPreVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<VAT>", 0.1 * pl.PLQuantity * pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<TotalAfterVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice * 1.1);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 19: Giấy chứng nhận chất lượng từ nhà máy
        public static string Temp19_PLQualityInspectionCertificateInFactory(string PLId)
        {
            object path = @"D:\OPM\Template\Mẫu 19. Giấy chứng nhận chất lượng từ nhà máy gửi tỉnh.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                PLObj pl = new PLObj(PLId);
                SiteObj vnpt = new SiteObj(pl.VNPTId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\DP{2}\Mẫu 19. Giấy chứng nhận chất lượng từ nhà máy gửi tỉnh_{3}.docx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", pl.ContractId);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", pl.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", pl.SiteName);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", pl.ContractShoppingPlan);
                //OpmWordHandler.FindAndReplace(wordApp, "<POName>", pl.POName);
                //OpmWordHandler.FindAndReplace(wordApp, "<POId>", pl.POId);
                //OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", pl.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<PLDate>", pl.PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy1>", vnpt.SiteProxy1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative2>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy2>", vnpt.SiteProxy1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative3>", vnpt.SiteRepresentative1);
                //OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy3>", vnpt.SiteProxy1);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation1>", pl.ContractGoodsDesignation1);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", pl.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", pl.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", pl.ContractGoodsCode);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", pl.ContractGoodsOrigin);
                OpmWordHandler.FindAndReplace(wordApp, "<PLQuantity>", pl.PLQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<PLQuantity1>", Math.Round(pl.PLQuantity * 0.02));
                OpmWordHandler.FindAndReplace(wordApp, "<DPId>", pl.DPId);
                OpmWordHandler.FindAndReplace(wordApp, "<DeviceCaseNumberRange>", DeviceObj.DeviceCaseNumberRange(PLId));
                OpmWordHandler.FindAndReplace(wordApp, "<PLQualityInspectionCertificateInFactoryDate>", pl.PLQualityInspectionCertificateInFactoryDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<TotalPreVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<VAT>", 0.1 * pl.PLQuantity * pl.ContractGoodsUnitPrice);
                //OpmWordHandler.FindAndReplace(wordApp, "<TotalAfterVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice * 1.1);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 18: Biên bản giao nhận hàng hoá
        public static string Temp18_PLGoodsDeliveryRecord(string PLId)
        {
            object path = @"D:\OPM\Template\Mẫu 18.  Biên bản giao nhận hàng hóa.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                PLObj pl = new PLObj(PLId);
                SiteObj vnpt = new SiteObj(pl.VNPTId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\DP{2}\Mẫu 18.  Biên bản giao nhận hàng hóa_{3}.docx", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'),pl.VNPTId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", pl.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", pl.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", pl.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", pl.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", pl.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", pl.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", pl.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PLDate>", pl.PLDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteName>", vnpt.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteAddress>", vnpt.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SitePhonenumber>", vnpt.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteFaxNumber>", vnpt.SiteFaxNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative1>", vnpt.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy1>", vnpt.SiteProxy1);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative2>", vnpt.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy2>", vnpt.SiteProxy1);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteRepresentative3>", vnpt.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<vnpt.SiteProxy3>", vnpt.SiteProxy1);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", pl.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", pl.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", pl.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", pl.ContractGoodsOrigin);
                OpmWordHandler.FindAndReplace(wordApp, "<PLQuantity>", pl.PLQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<PLQuantity1>", Math.Round(pl.PLQuantity*0.02));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnitPrice>", pl.ContractGoodsUnitPrice);
                OpmWordHandler.FindAndReplace(wordApp, "<TotalPreVAT>", pl.PLQuantity *pl.ContractGoodsUnitPrice);
                OpmWordHandler.FindAndReplace(wordApp, "<VAT>", 0.1*pl.PLQuantity * pl.ContractGoodsUnitPrice);
                OpmWordHandler.FindAndReplace(wordApp, "<TotalAfterVAT>", pl.PLQuantity * pl.ContractGoodsUnitPrice*1.1);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsNote>", pl.ContractGoodsNote);
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\DP{2}", pl.ContractId.Trim().Replace('/', '-'), pl.POName.Replace('/', '-'), pl.DPId.Replace('/', '-'), pl.VNPTId.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }

        //Tạo mẫu 11: Biên bản nghiệm thu kỹ thuật
        public static string Temp11_NTKTBBNTKT(string ntktId)
        {
            object path = @"D:\OPM\Template\Mẫu 11. Biên bản nghiệm thu kỹ thuật.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                NTKTObj ntkt = new NTKTObj(ntktId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 11. Biên bản nghiệm thu kỹ thuật_{3}.docx", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", ntkt.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", ntkt.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", ntkt.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", ntkt.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", ntkt.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", ntkt.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", ntkt.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", ntkt.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", ntkt.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmCreatedDate>", ntkt.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTId>", ntkt.NTKTId);
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTCreatedDate>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<TechnicalAcceptanceReportDate>", ntkt.TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTCreatedDate>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteAddress>", ntkt.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePhonenumber>", ntkt.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteFaxNumber>", ntkt.SiteFaxNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative1>", ntkt.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePosition1>", ntkt.SitePosition1);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative2>", ntkt.SiteRepresentative2);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePosition2>", ntkt.SitePosition2);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", ntkt.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", ntkt.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", ntkt.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTQuantity>", ntkt.NTKTQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTQuantity1>", Math.Round(0.02 * ntkt.NTKTQuantity, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsManufacture>", ntkt.ContractGoodsManufacture);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", ntkt.ContractGoodsOrigin);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsNote>", ntkt.ContractGoodsNote);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractConformityCertificateNumber>", ntkt.ContractConformityCertificateNumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT2%>", Math.Round(ntkt.NTKTQuantity * 1.02 * 0.02, 0, MidpointRounding.AwayFromZero));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT0.2%>", Math.Round(ntkt.NTKTQuantity * 1.02 * 0.002, 0, MidpointRounding.AwayFromZero));

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase);
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 10: Chứng nhận bản quyền phần mềm
        public static string Temp10_NTKTCNBQPM(string ntktId)
        {
            object path = @"D:\OPM\Template\Mẫu 10. Chứng nhận bản quyền phần mềm.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            Word.Document myDoc = null;
            try
            {
                NTKTObj ntkt = new NTKTObj(ntktId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 10. Chứng nhận bản quyền phần mềm_{3}.docx", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));
                object missing = Missing.Value;
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", ntkt.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", ntkt.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", ntkt.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTQuantity>", ntkt.NTKTQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTQuantity1>", Math.Round(0.02 * ntkt.NTKTQuantity, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTCreatedDate>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTQuantityTotal>", Math.Round(1.02 * ntkt.NTKTQuantity, 0, MidpointRounding.AwayFromZero));

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase);
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 9
        public static string Temp09_NTKTBBKTKT(string ntktId)
        {
            object path = @"D:\OPM\Template\Mẫu 9. Biên bản kiểm tra kỹ thuật.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                NTKTObj ntkt = new NTKTObj(ntktId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 9. Biên bản kiểm tra kỹ thuật_{3}.docx", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", ntkt.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", ntkt.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", ntkt.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", ntkt.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", ntkt.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", ntkt.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", ntkt.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", ntkt.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", ntkt.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmCreatedDate>", ntkt.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTId>", ntkt.NTKTId);
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTCreatedDate>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<TechnicalAcceptanceReportDate>", ntkt.TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteAddress>", ntkt.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePhonenumber>", ntkt.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteFaxNumber>", ntkt.SiteFaxNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteRepresentative1>", ntkt.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<SitePosition1>", ntkt.SitePosition1);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsDesignation>", ntkt.ContractGoodsDesignation);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsCode>", ntkt.ContractGoodsCode);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsUnit>", ntkt.ContractGoodsUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTQuantity>", ntkt.NTKTQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTQuantity1>", Math.Round(0.02 * ntkt.NTKTQuantity, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsManufacture>", ntkt.ContractGoodsManufacture);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsOrigin>", ntkt.ContractGoodsOrigin);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGoodsNote>", ntkt.ContractGoodsNote);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractConformityCertificateNumber>", ntkt.ContractConformityCertificateNumber);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT2%>", Math.Round(ntkt.NTKTQuantity * 1.02*0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT0.2%>", Math.Round(ntkt.NTKTQuantity * 1.02 * 0.002, 0, MidpointRounding.AwayFromZero));
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase);
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 8
        public static string Temp08_NTKTRequest(string ntktId)
        {
            object path = @"D:\OPM\Template\Mẫu 8. Đề nghị nghiệm thu kỹ thuật.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                NTKTObj ntkt = new NTKTObj(ntktId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 8. Đề nghị nghiệm thu kỹ thuật_{3}.docx", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTId>", ntkt.NTKTId);
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.NTKTCreatedDate.Day, ntkt.NTKTCreatedDate.Month, ntkt.NTKTCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTPhase>", ntkt.NTKTPhase);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", ntkt.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", ntkt.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", ntkt.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", ntkt.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", ntkt.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", ntkt.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", ntkt.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<NTKTTestExpectedDate>", ntkt.NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", ntkt.ContractId.Trim().Replace('/', '-'), ntkt.POName.Replace('/', '-'), ntkt.NTKTPhase);
                Directory.CreateDirectory(folder);
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(e.Message);
                return e.Message;
            }
        }

        //Tạo mẫu 6
        public static void Word_POBaoLanh(string txbKHMS, string txbIDContract, string txbPOCode, string txbPOName, string confirmpo_number, string TimePickerDateCreatedPO, string confirmpo_datecreated, string confirmpo_dateactive, string txbValuePO, string bltupo, string txbDurationConfirm)
        {
            POObj po = new POObj(txbPOCode);
            ContractObj contract = new ContractObj(txbIDContract);
            //Khởi tạo vào check forder
            string DriveName = "";
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                if (String.Compare(driveInfo.Name.ToString().Substring(0, 3), @"D:\") == 0 || String.Compare(driveInfo.Name.ToString().Substring(0, 3), @"E:\") == 0)
                {
                    DriveName = driveInfo.Name.ToString().Substring(0, 3);
                    break;
                }
            }
            //Check xem forder đã đc khởi tạo hay chưa?
            //Nếu chưa khởi tạo thì tiên hành khởi tạo
            string FoderName = String.Format(po.POId);
            string strPODirectory = DriveName + "OPM\\" + po.ContractId.Trim().Replace('/', '-') + "\\" + po.POName.Trim().Replace('/', '-') + "\\" + FoderName.Trim().Replace('/', '-');
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\3.Bao lanh PO.docx";
            //object filename = string.Format(DriveName + @"\OPM\{0}\{1}\XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            //
            object path = DriveName + @"\OPM\Template\Mau 4. Van ban mo thuc hien bao lanh PO.docx";
            if (File.Exists(path.ToString()))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                OpmWordHandler.FindAndReplace(wordApp, "<confirmpo_datecreate>", confirmpo_datecreated);
                OpmWordHandler.FindAndReplace(wordApp, "<confirmpo_number>", confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<txbPOName>", txbPOName);
                OpmWordHandler.FindAndReplace(wordApp, "<txbIDContract>", txbIDContract);
                OpmWordHandler.FindAndReplace(wordApp, "<txbKHMS>", txbKHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<txbPOCode>", txbPOCode);
                OpmWordHandler.FindAndReplace(wordApp, "<TimePickerDateCreatedPO>", TimePickerDateCreatedPO);
                OpmWordHandler.FindAndReplace(wordApp, "<confirmpo_dateactive>", confirmpo_dateactive);
                OpmWordHandler.FindAndReplace(wordApp, "<txbValuePO>", txbValuePO);
                OpmWordHandler.FindAndReplace(wordApp, "<bltupo>", bltupo);
                OpmWordHandler.FindAndReplace(wordApp, "<txbActiveAfter>", txbDurationConfirm);
                //Save as
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file bảo lãnh thành công"));
                myDoc.Close();
                wordApp.Quit();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản mẫu");
            }
        }
        //Tạo mẫu 6 - Thành
        public static string Temp6_POAdvanceRequest(string poid)
        {
            POObj po = new POObj(poid);
            object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 6. Văn bản đề nghị tạm ứng đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPM\Template\Mẫu 6. Văn bản đề nghị tạm ứng đơn hàng.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceRequestId>", po.POAdvanceRequestId.ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteePercentage>", po.POAdvanceGuaranteePercentage.ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractSiteId>", po.SiteId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POAdvanceRequestCreatedDate.Day, po.POAdvanceRequestCreatedDate.Month, po.POAdvanceRequestCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm1>", string.Format("ngày {0} tháng {1} năm {2}", po.ContractCreatedDate.Day, po.ContractCreatedDate.Month, po.ContractCreatedDate.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                //OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteeCreatedDate>", po.POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##}", (po.POTotalValue / 100) * po.POAdvanceGuaranteePercentage));
                //OpmWordHandler.FindAndReplace(wordApp, "<POTotalValueString>", NumberToString(Math.Round(((po.POTotalValue / 100) * po.POAdvanceGuaranteePercentage), 0, MidpointRounding.AwayFromZero).ToString()));
                OpmWordHandler.FindAndReplace(wordApp, "<POTotalValueString>", NumberToString((po.POTotalValue / 100) * po.POAdvanceGuaranteePercentage).ToString());
                //OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeValidityPeriod>", po.POGuaranteeValidityPeriod.ToString());

                //Tạo file BLHĐ trong thư mục D:\OPM
                try
                {
                    string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                    Directory.CreateDirectory(folder);
                    myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));

                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format(@"Không đọc được file {0} do lỗi ", filename.ToString()) + e.Message);
                }
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(string.Format(@"Không đọc được file {0} do lỗi ", path.ToString()) + e.Message);
                return e.Message;
            }
        }

        //Tạo mẫu 5 - Văn bản mở bảo lãnh tạm ứng cho đơn hàng
        public static string Temp5_POAdvanceGuarantee(string poid)
        {
            POObj po = new POObj(poid);
            object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 5. Văn bản mở bảo lãnh tạm ứng đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPM\Template\Mẫu 5. Văn bản mở bảo lãnh tạm ứng đơn hàng.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteeCreatedDate>", po.POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractSiteId>", po.SiteId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                //OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POConfirmCreatedDate.Day, po.POConfirmCreatedDate.Month, po.POConfirmCreatedDate.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.POTotalValue * 1.1));
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteePercentage>", po.POAdvanceGuaranteePercentage.ToString());
                //OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeValidityPeriod>", po.POGuaranteeValidityPeriod.ToString());

                //Tạo file BLHĐ trong thư mục D:\OPM
                try
                {
                    string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                    Directory.CreateDirectory(folder);
                    myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));

                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format(@"Không đọc được file {0} do lỗi ", filename.ToString()) + e.Message);
                }
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(string.Format(@"Không đọc được file {0} do lỗi ", path.ToString()) + e.Message);
                return e.Message;
            }
        }

        //Tạo mẫu 4 - Đề nghị bảo lãnh thực hiện hợp đồng cho đơn hàng
        public static string Temp4_POPerformanceGuarantee(string poid)
        {
            POObj po = new POObj(poid);
            object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 4. Đề nghị bảo lãnh thực hiện hợp đồng cho đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            object path = @"D:\OPM\Template\Mẫu 4. Văn bản mở bảo lãnh thực hiện đơn hàng.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeDate>", po.POGuaranteeDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                //OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                //OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POConfirmCreatedDate.Day, po.POConfirmCreatedDate.Month, po.POConfirmCreatedDate.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##}", po.POTotalValue * 1.1));
                OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeRatio>", po.POGuaranteeRatio.ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeValidityPeriod>", po.POGuaranteeValidityPeriod.ToString());

                //Tạo file BLHĐ trong thư mục D:\OPM
                try
                {
                    string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                    Directory.CreateDirectory(folder);
                    myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));

                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", filename.ToString()) + e.Message);
                }
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(string.Format(@"Không đọc được file {0} do lỗi ", path.ToString()) + e.Message);
                return e.Message;
            }
        }

        //Tạo mẫu 3 - Văn bản xác nhận hiệu lực đơn hàng và phụ lục kế hạch giao hàng
        public static string Temp3_POConfirm(string poid)
        {
            POObj po = new POObj(poid);
            object path = @"D:\OPM\Template\Mẫu 3. Văn bản xác nhận hiệu lực đơn hàng.docx";
            object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 3. Văn bản xác nhận hiệu lực đơn hàng {2}.docx", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                object readOnly = true;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", po.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POConfirmCreatedDate.Day, po.POConfirmCreatedDate.Month, po.POConfirmCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //Tạo bảng phụ lục kế hoạch giao hàng dự kiến
                DataTable dataTable = DeliveryPlanObj.DeliveryPlanDataTable(poid);
                int rowCount = dataTable.Rows.Count;
                int columnCount = dataTable.Columns.Count;
                int i;
                Word.Table table = myDoc.Tables[3];
                for (i = 0; i < rowCount; i++)
                {
                    table.Rows.Add();
                    table.Cell(i + 2, 1).Range.Text = (i+1).ToString();
                    table.Cell(i + 2, 2).Range.Text = dataTable.Rows[i].ItemArray[1].ToString(); 
                    table.Cell(i + 2, 3).Range.Text = dataTable.Rows[i].ItemArray[2].ToString();
                    DateTime temp = (DateTime)dataTable.Rows[i].ItemArray[3];
                    table.Cell(i + 2, 4).Range.Text = temp.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"));
                }
                //OpmWordHandler.FindAndReplace(wordApp, "12:00:00 SA", "");
                //MessageBox.Show(i.ToString());
                table.Cell(i + 2, 2).Range.Text = "TỔNG CỘNG";
                table.Cell(i + 2, 3).Range.Text = po.POGoodsQuantity.ToString();
                //Tạo file BLHĐ trong thư mục D:\OPM
                try
                {
                    string folder = string.Format(@"D:\OPM\{0}\{1}", po.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
                    Directory.CreateDirectory(folder);
                    myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", filename.ToString()) + e.Message);
                }
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(string.Format(@"Không đọc được file {0} do lỗi ", path.ToString()) + e.Message);
                return e.Message;
            }
        }
        //Tạo mẫu 1 - Đề nghị mở bảo lãnh thực hiện hợp đồng
        public static string Temp1_ContractGuarantee(string contractId)
        {
            object path = @"D:\OPM\Template\Mẫu 1. Đề nghị mở bảo lãnh thực hiện hợp đồng.docx";
            object filename = string.Format(@"D:\OPM\{0}\Mẫu 1. Đề nghị mở bảo lãnh thực hiện hợp đồng {0}.docx", contractId.Trim().Replace('/', '-'));
            string strPODirectory = string.Format(@"D:\OPM\{0}", contractId.Trim().Replace('/', '-'));
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            try
            {
                ContractObj contract = new ContractObj(contractId);
                object readOnly = true;
                object isVisible = false;
                wordApp.Visible = false;
                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", contract.ContractId.Trim());
                OpmWordHandler.FindAndReplace(wordApp, "<ContractGuaranteeCreatedDate>", contract.ContractGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractSignedDate>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteName>", contract.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeRatio>", contract.POGuaranteeRatio);
                OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeValidityPeriod>", contract.POGuaranteeValidityPeriod);
                //Tạo file BLHĐ trong thư mục D:\OPM
                try
                {
                    string folder = string.Format(@"D:\OPM\{0}", contractId.Trim().Replace('/', '-'));
                    Directory.CreateDirectory(folder);
                    myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format(@"Không tạo được file {0} do lỗi ", filename.ToString()) + e.Message);
                }
                myDoc.Close();
                wordApp.Quit();
                return filename.ToString();
            }
            catch (Exception e)
            {
                myDoc.Close();
                wordApp.Quit();
                MessageBox.Show(string.Format(@"Không đọc được file {0} do lỗi ", path.ToString()) + e.Message);
                return e.Message;
            }
        }
        public static void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        //Mẫu 19
        public static void Word_DPCNKTCL(string txbIDContract, string txbPOName, string txbIdDP, string diaChi, string mahangHD, string tenhangHD, string maHangSP, string tenHangSP, string soLuong, string GhiChu, string dtpOutCap)
        {
            //Khởi tạo vào check forder
            string DriveName = "";
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                if (String.Compare(driveInfo.Name.ToString().Substring(0, 3), @"D:\") == 0 || String.Compare(driveInfo.Name.ToString().Substring(0, 3), @"E:\") == 0)
                {
                    DriveName = driveInfo.Name.ToString().Substring(0, 3);
                    break;
                }
            }
            //Check xem forder đã đc khởi tạo hay chưa?
            //Nếu chưa khởi tạo thì tiên hành khởi tạo
            string strPODirectory = DriveName + "OPM\\" + txbIDContract.Trim().Replace('/', '-') + "\\" + txbPOName.Trim().Replace('/', '-') + "\\" + txbIdDP.Trim().Replace('/', '-');
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\Kiem tra CL_" + diaChi + ".docx";
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            //
            object path = DriveName + @"\OPM\Template\Mau 19. Giay CNCL NM gui tinh.docx";
            if (File.Exists(path.ToString()))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                FindAndReplace(wordApp, "<Idcontract>", " " + txbIDContract);
                FindAndReplace(wordApp, "<Tentinh>", " " + diaChi);
                FindAndReplace(wordApp, "<Loaisanpham>", " " + maHangSP);
                FindAndReplace(wordApp, "<Mahang>", " " + mahangHD);
                FindAndReplace(wordApp, "<Tenthietbi>", " " + tenhangHD);
                FindAndReplace(wordApp, "<Thucxuat>", " " + soLuong);
                FindAndReplace(wordApp, "<Ghichu>", " " + GhiChu);
                FindAndReplace(wordApp, "<dtpOutCap>", " " + dtpOutCap);
                //Save as
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                myDoc.Close();
                wordApp.Quit();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản mẫu 19");
            }
        }
        //Mẫu 22
        public static void Word_PBH(string txbIDContract, string txbPOName, string txbPOCode, string txbIdDP, string diaChi, string mahangHD, string tenhangHD, string maHangSP, string tenHangSP, string soLuong, string GhiChu)
        {
            //Khởi tạo vào check forder
            string DriveName = "";
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                if (String.Compare(driveInfo.Name.ToString().Substring(0, 3), @"D:\") == 0 || String.Compare(driveInfo.Name.ToString().Substring(0, 3), @"E:\") == 0)
                {
                    DriveName = driveInfo.Name.ToString().Substring(0, 3);
                    break;
                }
            }
            //Check xem forder đã đc khởi tạo hay chưa?
            //Nếu chưa khởi tạo thì tiên hành khởi tạo
            string strPODirectory = DriveName + "OPM\\" + txbIDContract.Trim().Replace('/', '-') + "\\" + txbPOName.Trim().Replace('/', '-') + "\\" + txbIdDP.Trim().Replace('/', '-');
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\Phieu bao hanh_" + diaChi + ".docx";
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDoc = null;
            //
            object path = DriveName + @"\OPM\Template\Mau22. Mau phieu bao hanh.docx";
            if (File.Exists(path.ToString()))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                FindAndReplace(wordApp, "<NumberDP>", " " + txbIdDP);
                FindAndReplace(wordApp, "<Ponumber>", " " + txbPOCode);
                FindAndReplace(wordApp, "<tentinh>", " " + diaChi);
                FindAndReplace(wordApp, "<idconntract>", " " + txbIDContract);
                FindAndReplace(wordApp, "<tenhang>", " " + tenhangHD);
                FindAndReplace(wordApp, "<LoaiHang>", " " + mahangHD);
                FindAndReplace(wordApp, "<SoLuong>", " " + soLuong);
                //Save as
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                myDoc.Close();
                wordApp.Quit();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản mẫu 20");
            }
        }
        public static string NumberToString(double number)
        {
            return NumberToString(Math.Round(number, 0, MidpointRounding.AwayFromZero).ToString());
        }

        public static string NumberToString(string number)
        {
            string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string doc;
            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            doc = "";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) doc += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') doc += "lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) doc += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    doc += "mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc += "mốt ";
                                    else
                                        doc += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    doc += "lăm ";
                                else
                                    doc += cs[5] + " ";
                                break;
                            default:
                                doc += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }

                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc += dv[n - j - 1] + " ";
                        }
                    }
                }


                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc += "tỉ ";
                        rd = 0;
                    }
                    else
                        if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }

            if (len == 1)
                if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];

            return doc;
        }

    }
}
