using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
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
        //Tạo mẫu 37
        public static string Temp37_BBXNCDLicense(string poid)
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
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 37. BBXNCDLicense_{2}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.SiteId);



                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.SiteTaxCode);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.SiteType);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.SiteHeadquater);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.SiteBankAccount);
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
        public static string Temp36_BBNTLicense(string poid)
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
                ContractObj contract = new ContractObj(po.ContractId);
                SiteObj site = new SiteObj(contract.SiteId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 36. BBNTLicense_{2}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.SiteId);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.SiteTaxCode);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.SiteType);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.SiteHeadquater);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.SiteBankAccount);
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
        //Tạo mẫu 24
        public static string Temp24_CNCLNMTongHop(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 24. Giấy CNCL NM tổng hợp.docx";
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
                ContractObj contract = new ContractObj(po.ContractId);
                //Site_Info site = new Site_Info(contract.Id_siteA);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 24. CNCLNM_Tong_Hop_{2}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.SiteId);



                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.Phonenumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.Representative);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.Tin);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.Type);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.Headquater_info);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.Address);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.Account);
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

        //Tạo mẫu 23
        public static string Temp23_CNCL_TongHop(string poid)
        {
            object path = @"D:\OPM\Template\Mẫu 23. GIAY_CNCL_TONG_HOP.docx";
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
                ContractObj contract = new ContractObj(po.ContractId);
                SiteObj site = new SiteObj(contract.SiteId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 23. CNCL_Tong_Hop_{2}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.POId.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.SiteId);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.POGoodsQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.POGoodsQuantity + Math.Round(po.POGoodsQuantity * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.Phonenumber);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.Representative);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.Tin);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.Type);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.Headquater_info);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.Address);
                //OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.Account);
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
        //Tạo mẫu 18: Biên bản giao nhận hàng hoá
        public static string Temp18_GoodsDeliveryRecord(string PLId)
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
        public static string Temp11_BBNTKT(string ntktId)
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
                POObj po = new POObj(ntkt.POId);
                ContractObj contract = new ContractObj(po.ContractId);
                SiteObj site = new SiteObj(contract.SiteId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 11. BBNTKT_{3}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.NTKTCreatedDate.Day, ntkt.NTKTCreatedDate.Month, ntkt.NTKTCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.SiteId);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.POGoodsQuantity);

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.NTKTId);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.NTKTPhase);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.NTKTQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.NTKTExtraQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.TechnicalInspectionReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.SiteTaxCode);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.SiteType);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.SiteHeadquater);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.SiteBankAccount);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.NTKTPhase);
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
        public static string Temp10_CNBQPM(string ntktId)
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
                POObj po = new POObj(ntkt.POId);
                ContractObj contract = new ContractObj(po.ContractId);
                SiteObj site = new SiteObj(contract.SiteId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 10. CNBQPM_{3}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.NTKTCreatedDate.Day, ntkt.NTKTCreatedDate.Month, ntkt.NTKTCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.SiteId);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.POGoodsQuantity);

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.NTKTId);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.NTKTPhase);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.NTKTQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.NTKTExtraQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.TechnicalInspectionReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.SiteTaxCode);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.SiteType);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.SiteHeadquater);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.SiteBankAccount);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_CNBQPM>", ntkt.NTKTLicenseCertificateDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Total>", ntkt.NTKTQuantity + ntkt.NTKTExtraQuantity);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.NTKTPhase);
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
        public static string Temp09_BBKTKT(string ntktId)
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
                POObj po = new POObj(ntkt.POId);
                ContractObj contract = new ContractObj(po.ContractId);
                SiteObj site = new SiteObj(contract.SiteId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 9. BBKTKT_{3}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.NTKTCreatedDate.Day, ntkt.NTKTCreatedDate.Month, ntkt.NTKTCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.SiteId);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.POGoodsQuantity);

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.NTKTId);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.NTKTPhase);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.NTKTQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.NTKTExtraQuantity);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.NTKTCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT2%>", Math.Round((ntkt.NTKTQuantity + ntkt.NTKTExtraQuantity) * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT0.2%>", Math.Round((ntkt.NTKTQuantity + ntkt.NTKTExtraQuantity) * 0.002, 0, MidpointRounding.AwayFromZero));

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.TechnicalAcceptanceReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.TechnicalInspectionReportDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.SitePhonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.SiteRepresentative1);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.SiteTaxCode);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.SiteName);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.SiteType);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.SiteHeadquater);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.SiteAddress);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.SiteBankAccount);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.NTKTPhase);
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
            object path = @"D:\OPM\Template\Mẫu 8. De nghi NTKT.docx";
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
                POObj po = new POObj(ntkt.POId);
                ContractObj contract = new ContractObj(po.ContractId);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 8.YCNTKT_{3}.docx", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.NTKTPhase, ntkt.NTKTId.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.NTKTCreatedDate.Day, ntkt.NTKTCreatedDate.Month, ntkt.NTKTCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ContractValidityDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.NTKTId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.NTKTPhase);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.SiteId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.POConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.NTKTTestExpectedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.ContractId.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.NTKTPhase);
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
        public static string Temp6_CreatPOAdvanceReques(string poid)
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
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractSiteId>", po.SiteId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POAdvanceRequestCreatedDate.Day, po.POAdvanceRequestCreatedDate.Month, po.POAdvanceRequestCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm1>", string.Format("ngày {0} tháng {1} năm {2}", po.ContractCreatedDate.Day, po.ContractCreatedDate.Month, po.ContractCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteeCreatedDate>", po.POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##0.##}", (po.POTotalValue / 100) * po.POAdvanceGuaranteePercentage));
                //OpmWordHandler.FindAndReplace(wordApp, "<POTotalValueString>", NumberToString(Math.Round(((po.POTotalValue / 100) * po.POAdvanceGuaranteePercentage), 0, MidpointRounding.AwayFromZero).ToString()));
                OpmWordHandler.FindAndReplace(wordApp, "<POTotalValueString>", NumberToString((po.POTotalValue / 100) * po.POAdvanceGuaranteePercentage).ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteePercentage>", po.POAdvanceGuaranteePercentage.ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<POGuaranteeValidityPeriod>", po.POGuaranteeValidityPeriod.ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceRequestId>", po.POAdvanceRequestId.ToString());

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

        //Tạo mẫu 5 - Thành
        public static string Temp5_CreatPOAdvanceGuarantee(string poid)
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
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractSiteId>", po.SiteId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POConfirmCreatedDate.Day, po.POConfirmCreatedDate.Month, po.POConfirmCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteeCreatedDate>", po.POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##0.##}", po.POTotalValue * 1.1));
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteePercentage>", po.POAdvanceGuaranteePercentage.ToString());
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

        //Tạo mẫu 4 - Thành
        public static string Temp4_CreatPOPerformanceGuarantee(string poid)
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
                OpmWordHandler.FindAndReplace(wordApp, "<ContractId>", po.ContractId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractSiteId>", po.SiteId);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractName>", po.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractShoppingPlan>", po.ContractShoppingPlan);
                OpmWordHandler.FindAndReplace(wordApp, "<ContractCreatedDate>", po.ContractCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POId>", po.POId);
                OpmWordHandler.FindAndReplace(wordApp, "<POName>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", po.POConfirmCreatedDate.Day, po.POConfirmCreatedDate.Month, po.POConfirmCreatedDate.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<POConfirmId>", po.POConfirmId);
                OpmWordHandler.FindAndReplace(wordApp, "<POCreatedDate>", po.POCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POPerformDate>", po.POPerformDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POAdvanceGuaranteeCreatedDate>", po.POAdvanceGuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<POTotalValue>", string.Format(new CultureInfo("vi-VN"), "{0:#,##0.##}", po.POTotalValue * 1.1));
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

        //Tạo mẫu 3 - Thành
        public static string Temp3_CreatPOConfirm(string poid)
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
                OpmWordHandler.FindAndReplace(wordApp, "<ContractSiteId>", po.SiteId);
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
                    table.Cell(i + 2, 4).Range.Text = dataTable.Rows[i].ItemArray[3].ToString();
                }
                OpmWordHandler.FindAndReplace(wordApp, "12:00:00 SA", "");
                MessageBox.Show(i.ToString());
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
        //Tạo mẫu 1 - Thành
        public static string Temp1_CreatContractGuarantee(string contractId)
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
                OpmWordHandler.FindAndReplace(wordApp, "<ContractSiteId>", contract.SiteId);
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
