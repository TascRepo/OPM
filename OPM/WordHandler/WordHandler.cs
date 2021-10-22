using OPM.DBHandler;
using OPM.OPMEnginee;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WordOffice = Microsoft.Office.Interop.Word;
namespace OPM.WordHandler
{
    class OpmWordHandler
    {
        //Tạo mẫu 37
        public static string Temp37_BBXNCDLicense(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 37. Biên bản xác nhận cài đặt License vào hệ thống.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            WordOffice.Document myDoc = null;
            try
            {
                //NTKT_Thanh ntkt = new NTKT_Thanh(id);
                PO_Thanh po = new PO_Thanh(id);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                Goods_Thanh contract_Goods = new Goods_Thanh(po.IdContract);
                Site_Info site = new Site_Info(contract.IdSiteA);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 37. BBXNCDLicense_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ActiveDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);

                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name>", contract_Goods.Name);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Origin>", contract_Goods.Origin);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Manufacturer>", contract_Goods.Manufacturer);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Code>", contract_Goods.Code);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Unit>", contract_Goods.Unit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceUnit>", contract_Goods.PriceUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Quantity>", contract_Goods.Quantity);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PricePreTax>", contract_Goods.PricePreTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Tax>", contract_Goods.Tax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceAfterTax>", contract_Goods.PriceAfterTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Note>", contract_Goods.Note);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.License>", contract_Goods.License);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name1>", contract_Goods.Name1);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.IdConfirm);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.NumberOfDevice);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.NumberOfDevice * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.NumberOfDevice + Math.Round(po.NumberOfDevice * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.Phonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.Representative);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.Tin);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.Type);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.Headquater_info);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.Address);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.Account);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_CNBQPM>", ntkt.Date_CNBQPM.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Total>", ntkt.Numberofdevice2 + ntkt.Numberofdevice);



                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
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
        public static string Temp36_BBNTLicense(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 36. Biên bản nghiệm thu License.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            try
            {
                //NTKT_Thanh ntkt = new NTKT_Thanh(id);
                PO_Thanh po = new PO_Thanh(id);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                Goods_Thanh contract_Goods = new Goods_Thanh(po.IdContract);
                Site_Info site = new Site_Info(contract.IdSiteA);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 36. BBNTLicense_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ActiveDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);

                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name>", contract_Goods.Name);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Origin>", contract_Goods.Origin);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Manufacturer>", contract_Goods.Manufacturer);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Code>", contract_Goods.Code);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Unit>", contract_Goods.Unit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceUnit>", contract_Goods.PriceUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Quantity>", contract_Goods.Quantity);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PricePreTax>", contract_Goods.PricePreTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Tax>", contract_Goods.Tax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceAfterTax>", contract_Goods.PriceAfterTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Note>", contract_Goods.Note);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.License>", contract_Goods.License);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name1>", contract_Goods.Name1);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.IdConfirm);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.NumberOfDevice);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.NumberOfDevice * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.NumberOfDevice + Math.Round(po.NumberOfDevice * 0.02, 0, MidpointRounding.AwayFromZero));

                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.Phonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.Representative);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.Tin);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.Type);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.Headquater_info);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.Address);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.Account);
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_CNBQPM>", ntkt.Date_CNBQPM.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Total>", ntkt.Numberofdevice2 + ntkt.Numberofdevice);
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
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
        public static string Temp24_CNCLNMTongHop(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 24. Giấy CNCL NM tổng hợp.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            try
            {
                //NTKT_Thanh ntkt = new NTKT_Thanh(id);
                PO_Thanh po = new PO_Thanh(id);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                Goods_Thanh contract_Goods = new Goods_Thanh(po.IdContract);
                //Site_Info site = new Site_Info(contract.Id_siteA);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 24. CNCLNM_Tong_Hop_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ActiveDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);

                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name>", contract_Goods.Name);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Origin>", contract_Goods.Origin);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Manufacturer>", contract_Goods.Manufacturer);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Code>", contract_Goods.Code);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Unit>", contract_Goods.Unit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceUnit>", contract_Goods.PriceUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Quantity>", contract_Goods.Quantity);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PricePreTax>", contract_Goods.PricePreTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Tax>", contract_Goods.Tax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceAfterTax>", contract_Goods.PriceAfterTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Note>", contract_Goods.Note);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.License>", contract_Goods.License);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name1>", contract_Goods.Name1);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.IdConfirm);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.NumberOfDevice);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.NumberOfDevice * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.NumberOfDevice + Math.Round(po.NumberOfDevice * 0.02, 0, MidpointRounding.AwayFromZero));

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
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
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
        public static string Temp23_CNCL_TongHop(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 23. GIAY_CNCL_TONG_HOP.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            try
            {
                //NTKT_Thanh ntkt = new NTKT_Thanh(id);
                PO_Thanh po = new PO_Thanh(id);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                Goods_Thanh contract_Goods = new Goods_Thanh(po.IdContract);
                Site_Info site = new Site_Info(contract.IdSiteA);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 23. CNCL_Tong_Hop_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ActiveDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);

                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name>", contract_Goods.Name);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Origin>", contract_Goods.Origin);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Manufacturer>", contract_Goods.Manufacturer);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Code>", contract_Goods.Code);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Unit>", contract_Goods.Unit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceUnit>", contract_Goods.PriceUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Quantity>", contract_Goods.Quantity);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PricePreTax>", contract_Goods.PricePreTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Tax>", contract_Goods.Tax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceAfterTax>", contract_Goods.PriceAfterTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Note>", contract_Goods.Note);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.License>", contract_Goods.License);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name1>", contract_Goods.Name1);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.IdConfirm);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.NumberOfDevice);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.NumberOfDevice * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.NumberOfDevice + Math.Round(po.NumberOfDevice * 0.02, 0, MidpointRounding.AwayFromZero));

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
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
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

        //Tạo mẫu 11
        public static string Temp11_BBNTKT(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 11. Biên bản nghiệm thu kỹ thuật.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            try
            {
                NTKT_Thanh ntkt = new NTKT_Thanh(id);
                PO_Thanh po = new PO_Thanh(ntkt.Id_po);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                Goods_Thanh contract_Goods = new Goods_Thanh(po.IdContract);
                Site_Info site = new Site_Info(contract.IdSiteA);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 11. BBNTKT_{3}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.Number, ntkt.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.Create_date.Day, ntkt.Create_date.Month, ntkt.Create_date.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ActiveDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);

                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name>", contract_Goods.Name);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Origin>", contract_Goods.Origin);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Manufacturer>", contract_Goods.Manufacturer);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Code>", contract_Goods.Code);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Unit>", contract_Goods.Unit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceUnit>", contract_Goods.PriceUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Quantity>", contract_Goods.Quantity);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PricePreTax>", contract_Goods.PricePreTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Tax>", contract_Goods.Tax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceAfterTax>", contract_Goods.PriceAfterTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Note>", contract_Goods.Note);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.License>", contract_Goods.License);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name1>", contract_Goods.Name1);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.IdConfirm);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.NumberOfDevice);

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.Phonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.Representative);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.Tin);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.Type);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.Headquater_info);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.Address);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.Account);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.Number);
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
        //Tạo mẫu 10
        public static string Temp10_CNBQPM(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 10. Chứng nhận bản quyền phần mềm.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            WordOffice.Document myDoc=null;
            try
            {
                NTKT_Thanh ntkt = new NTKT_Thanh(id);
                PO_Thanh po = new PO_Thanh(ntkt.Id_po);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                Goods_Thanh contract_Goods = new Goods_Thanh(po.IdContract);
                Site_Info site = new Site_Info(contract.IdSiteA);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 10. CNBQPM_{3}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.Number, ntkt.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.Create_date.Day, ntkt.Create_date.Month, ntkt.Create_date.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ActiveDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);

                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name>", contract_Goods.Name);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Origin>", contract_Goods.Origin);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Manufacturer>", contract_Goods.Manufacturer);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Code>", contract_Goods.Code);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Unit>", contract_Goods.Unit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceUnit>", contract_Goods.PriceUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Quantity>", contract_Goods.Quantity);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PricePreTax>", contract_Goods.PricePreTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Tax>", contract_Goods.Tax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceAfterTax>", contract_Goods.PriceAfterTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Note>", contract_Goods.Note);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.License>", contract_Goods.License);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name1>", contract_Goods.Name1);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.IdConfirm);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.NumberOfDevice);

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.Phonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.Representative);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.Tin);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.Type);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.Headquater_info);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.Address);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.Account);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_CNBQPM>", ntkt.Date_CNBQPM.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Total>", ntkt.Numberofdevice + ntkt.Numberofdevice2);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.Number);
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
        public static string Temp09_BBKTKT(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 9. Biên bản kiểm tra kỹ thuật.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            try
            {
                NTKT_Thanh ntkt = new NTKT_Thanh(id);
                PO_Thanh po = new PO_Thanh(ntkt.Id_po);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                Goods_Thanh contract_Goods = new Goods_Thanh(po.IdContract);
                Site_Info site = new Site_Info(contract.IdSiteA);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 9. BBKTKT_{3}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.Number, ntkt.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.Create_date.Day, ntkt.Create_date.Month, ntkt.Create_date.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ActiveDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);

                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name>", contract_Goods.Name);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Origin>", contract_Goods.Origin);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Manufacturer>", contract_Goods.Manufacturer);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Code>", contract_Goods.Code);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Unit>", contract_Goods.Unit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceUnit>", contract_Goods.PriceUnit);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Quantity>", contract_Goods.Quantity);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PricePreTax>", contract_Goods.PricePreTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Tax>", contract_Goods.Tax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.PriceAfterTax>", contract_Goods.PriceAfterTax);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Note>", contract_Goods.Note);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.License>", contract_Goods.License);
                OpmWordHandler.FindAndReplace(wordApp, "<contract_Goods.Name1>", contract_Goods.Name1);


                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.IdConfirm);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.NumberOfDevice);

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT2%>", Math.Round((ntkt.Numberofdevice + ntkt.Numberofdevice2) * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT0.2%>", Math.Round((ntkt.Numberofdevice + ntkt.Numberofdevice2) * 0.002, 0, MidpointRounding.AwayFromZero));

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBNTKT>", ntkt.Date_BBNTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Date_BBKTKT>", ntkt.Date_BBKTKT.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<site.Phonenumber>", site.Phonenumber);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Representative>", site.Representative);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Tin>", site.Tin);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Id>", site.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Type>", site.Type);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Headquater_info>", site.Headquater_info);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Address>", site.Address);
                OpmWordHandler.FindAndReplace(wordApp, "<site.Account>", site.Account);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.Number);
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
        public static string Temp08_NTKTRequest(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 8. De nghi NTKT.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            try
            {
                NTKT_Thanh ntkt = new NTKT_Thanh(id);
                PO_Thanh po = new PO_Thanh(ntkt.Id_po);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\Mẫu 8.YCNTKT_{3}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.Number, ntkt.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.Create_date.Day, ntkt.Create_date.Month, ntkt.Create_date.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.ActiveDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), ntkt.Number);
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

        //Tạo mẫu 3
        public static void Word_POConfirm(string txbKHMS, string txbIDContract, string txbPOCode, string txbPOName, string confirmpo_number, string TimePickerDateCreatedPO, string confirmpo_datecreated, string confirmpo_dateactive)
        {
            PO_Thanh po = new PO_Thanh(txbPOCode);
            Contract_Thanh contract = new Contract_Thanh(po.IdContract);
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
            string FoderName = String.Format(po.Id);
            string strPODirectory = DriveName + "OPM\\" + po.IdContract.Trim().Replace('/', '-') + "\\" + po.POName.Trim().Replace('/', '-') + "\\" + FoderName.Trim().Replace('/', '-');
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\1.Xac nhan don hang.docx";
            //object filename = string.Format(DriveName + @"\OPM\{0}\{1}\XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            //
            object path = DriveName + @"\OPM\Template\Mau 3. van ban xac nhan hieu luc don hang.docx";
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
                OpmWordHandler.FindAndReplace(wordApp, "<dd>", " " + DateTime.Now.ToString("dd") + " ");
                OpmWordHandler.FindAndReplace(wordApp, "<MM>", " " + DateTime.Now.ToString("MM") + " ");
                OpmWordHandler.FindAndReplace(wordApp, "<mm>", " " + DateTime.Now.ToString("MM") + " ");
                OpmWordHandler.FindAndReplace(wordApp, "<yyyy>", " " + DateTime.Now.ToString("yyyy") + " ");
                OpmWordHandler.FindAndReplace(wordApp, "<ConfirmPO_Number>", po.IdConfirm);
                //OpmWordHandler.FindAndReplace(wordApp, "<Signed_Date>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteA>", contract.IdSiteA);
                OpmWordHandler.FindAndReplace(wordApp, "<PO_Number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_ID>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_Name>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_DateCreated>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PO_ID>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<PO_DateCreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PO_ConfirmDateActive>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<confirmpo_number>", confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<txbPOName>", txbPOName);
                OpmWordHandler.FindAndReplace(wordApp, "<txbIDContract>", txbIDContract);
                OpmWordHandler.FindAndReplace(wordApp, "<txbKHMS>", txbKHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<confirmpo_datecreated>", confirmpo_datecreated);
                OpmWordHandler.FindAndReplace(wordApp, "<txbPOCode>", txbPOCode);
                OpmWordHandler.FindAndReplace(wordApp, "<confirmpo_dateactive>", confirmpo_dateactive);
                OpmWordHandler.FindAndReplace(wordApp, "<TimePickerDateCreatedPO>", TimePickerDateCreatedPO);
                //FileLocation = path
                Microsoft.Office.Interop.Word.Table tab = myDoc.Tables[3];
                Delivery_PO po1 = new Delivery_PO();
                DataTable dt_PO = new DataTable();
                if (po1.CheckDelivery_PO(confirmpo_number, txbPOCode) == 1)
                {
                    string sql = po1.querySQL(confirmpo_number);
                    DataTable table1 = OPMDBHandler.ExecuteQuery(sql);
                    for (int i = 2; i < table1.Rows.Count - 1; i++)
                    {
                        Object objMiss = Missing.Value;
                        tab.Rows.Add(ref objMiss);
                        tab.Cell(i, 1).Range.Text = (i - 1).ToString();
                        tab.Cell(i, 2).Range.Text = table1.Rows[i][2].ToString();
                        tab.Cell(i, 3).Range.Text = table1.Rows[i][3].ToString();
                        tab.Cell(i, 4).Range.Text = table1.Rows[i][4].ToString();
                        tab.Cell(i, 5).Range.Text = table1.Rows[i][5].ToString().Substring(0, 9); 
                    }
                }
                myDoc.SaveAs2(ref filename, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                MessageBox.Show(string.Format("Đã tạo file xac nhan hieu luc dh thành công"));
                myDoc.Close();
                wordApp.Quit();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản mẫu");
            }
        }
        //

        //Tạo mẫu 4 + 5
        public static void Word_POTamUng(string txbKHMS, string txbIDContract, string txbPOCode, string txbPOName, string confirmpo_number, string TimePickerDateCreatedPO, string confirmpo_datecreated, string confirmpo_dateactive, string txbValuePO, string bltupo, string txbDurationConfirm,string svbdntt)
        {
            PO_Thanh po = new PO_Thanh(txbPOCode);
            Contract_Thanh contract = new Contract_Thanh(txbIDContract);
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
            string FoderName = String.Format(po.Id);
            string strPODirectory = DriveName + "OPM\\" + po.IdContract.Trim().Replace('/', '-') + "\\" + po.POName.Trim().Replace('/', '-') + "\\" + FoderName.Trim().Replace('/', '-');
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\2.Van ban de nghi tam ung.docx";
            //object filename = string.Format(DriveName + @"\OPM\{0}\{1}\XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            //
            object path = DriveName + @"\OPM\Template\Mau 5. Van ban mo tam ung PO.docx";
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
                FindAndReplace(wordApp, "<dd>", " " + DateTime.Now.ToString("dd") + " ");
                FindAndReplace(wordApp, "<mm>", " " + DateTime.Now.ToString("MM") + " ");
                FindAndReplace(wordApp, "<yyyy>", " " + DateTime.Now.ToString("yyyy") + " ");
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
        //Tạo mẫu 6
        public static void Word_POBaoLanh(string txbKHMS, string txbIDContract, string txbPOCode, string txbPOName, string confirmpo_number, string TimePickerDateCreatedPO, string confirmpo_datecreated, string confirmpo_dateactive,string txbValuePO,string bltupo, string txbDurationConfirm)
        {
            PO_Thanh po = new PO_Thanh(txbPOCode);
            Contract_Thanh contract = new Contract_Thanh(txbIDContract);
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
            string FoderName = String.Format(po.Id);
            string strPODirectory = DriveName + "OPM\\" + po.IdContract.Trim().Replace('/', '-') + "\\" + po.POName.Trim().Replace('/', '-') + "\\" + FoderName.Trim().Replace('/', '-');
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\3.Bao lanh PO.docx";
            //object filename = string.Format(DriveName + @"\OPM\{0}\{1}\XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
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
        //Tạo mẫu 3
        public static string Temp3_CreatPOConfirm(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 3. VB xác nhận hiệu lực đơn hàng.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            try
            {
                PO_Thanh po = new PO_Thanh(id);
                Contract_Thanh contract = new Contract_Thanh(po.IdContract);
                object filename = string.Format(@"D:\OPM\{0}\{1}\Mẫu 3. XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'), po.Id.Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<Now>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ConfirmPO_Number>", po.IdConfirm);
                //OpmWordHandler.FindAndReplace(wordApp, "<Signed_Date>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteA>", contract.IdSiteA);
                OpmWordHandler.FindAndReplace(wordApp, "<PO_Number>", po.POName);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_ID>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_Name>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_DateCreated>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PO_ID>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<PO_DateCreated>", po.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PO_ConfirmDateActive>", po.ConfirmCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.POName.Replace('/', '-'));
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
        //Tạo mẫu 1
        public static string Temp1_CreatContractGuarantee(string id)
        {
            object path = @"D:\OPM\Template\Mẫu 1. Đề nghị mở bảo lãnh thực hiện hợp đồng.docx";
            if (!File.Exists(path.ToString()))
            {
                MessageBox.Show(string.Format(@"Không tìm thấy {0}", path.ToString()));
                return string.Format(@"Không tìm thấy {0}", path.ToString());
            }

            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            try
            {
                Contract_Thanh contract = new Contract_Thanh(id);
                object filename = string.Format(@"D:\OPM\{0}\Mẫu 1. BLHD_{0}.docx", id.Trim().Replace('/', '-'));
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
                OpmWordHandler.FindAndReplace(wordApp, "<Contract.Id>", contract.Id.Trim());
                OpmWordHandler.FindAndReplace(wordApp, "<contract.GaranteeCreatedDate>", contract.GuaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.ContractName);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.SignedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.IdSiteA);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Blvalue>", contract.GuaranteeValue);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Durationpo>", contract.PoDuration);
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}", id.Trim().Replace('/', '-'));
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
                MessageBox.Show("Không đọc được file mẫu 1 "+ e.Message);
                return e.Message;
            }
        }
        public static void FindAndReplace(WordOffice.Application wordApp, object ToFindText, object replaceWithText)
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
            object read_only = false;
            object visible = true;
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
        //public static void PrintDocument(object filename)
        //{
        //    WordOffice.Application wordApp = new WordOffice.Application();
        //    object missing = Missing.Value;
        //    WordOffice.Document myWordDoc = null;

        //    try
        //    {
        //        if (File.Exists((string)filename))
        //        {
        //            object readOnly = false;
        //            object isVisible = false;
        //            wordApp.Visible = false;

        //            myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing, ref missing);
        //            myWordDoc.Activate();

        //            myWordDoc.Application.ActivePrinter = "PCL6 V4 Driver for Universal Print";
        //            myWordDoc.PrintOut();
        //        }
        //        else
        //        {
        //            MessageBox.Show("File not Found!");
        //        }

        //        myWordDoc.Close();
        //        wordApp.Quit();
        //        MessageBox.Show("File Created!");
        //    }
        //    catch(Exception)
        //    {
        //        myWordDoc.Close();
        //        wordApp.Quit();
        //        MessageBox.Show("File Created không thành công!");

        //    }
        //}

        public static void Create_VBConfirm_PO(object filename, object SaveAs, ConfirmPO confirmPO, PO objPO, ContractObj contractObj)
        {
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myWordDoc = null;

            try
            {
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;

                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);
                    myWordDoc.Activate();

                    //find and replace
                    FindAndReplace(wordApp, "<dd>", " " + DateTime.Now.ToString("dd") + " ");
                    FindAndReplace(wordApp, "<MM>", " " + DateTime.Now.ToString("MM") + " ");
                    FindAndReplace(wordApp, "<yyyy>", " " + DateTime.Now.ToString("yyyy") + " ");

                    FindAndReplace(wordApp, "<XNDH_ID>", " " + confirmPO.ConfirmPOID + " ");
                    //string[] dateNow = convertDateFormat.ConvertFormatDate(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", "dd/MM/yyyy");
                    //FindAndReplace(wordApp, "<DateNow>", " " + dateNow[0] + "/" + dateNow[1] + "/" + dateNow[2]);
                    FindAndReplace(wordApp, "<PO_Number>", " " + confirmPO.PONumber + " ");
                    FindAndReplace(wordApp, "<PO_ID>", " " + confirmPO.POID + " ");
                    //string[] PO_CreatedDate = convertDateFormat.ConvertFormatDate(objPO.DateCreatedPO, "yyyy-MM-dd", "dd/MM/yyyy");
                    //FindAndReplace(wordApp, "<PO_DateCreated>", " " + PO_CreatedDate[0] + "/" + PO_CreatedDate[1] + "/" + PO_CreatedDate[2]);

                    FindAndReplace(wordApp, "<KHMS>", " " + confirmPO.KHMS + " ");
                    FindAndReplace(wordApp, "<Contract_ID>", " " + confirmPO.IDContract + " ");
                    FindAndReplace(wordApp, "<Contract_Name>", " " + contractObj.NameContract + " ");
                    //string[] Contract_DateSigned = convertDateFormat.ConvertFormatDate(contractObj.DateSigned, "dd-MM-yyyy", "dd/MM/yyyy");
                    //FindAndReplace(wordApp, "<Contract_DateSigned>", " " + Contract_DateSigned[0] + "/" + Contract_DateSigned[1] + "/" + Contract_DateSigned[2]);
                    FindAndReplace(wordApp, "<Site_B>", " " + contractObj.SiteB + " ");

                    FindAndReplace(wordApp, "<MrPhoBan>", " " + confirmPO.MrPhoBan + " ");
                    FindAndReplace(wordApp, "<Mobile>", " " + confirmPO.MrPhoBanMobile + " ");

                    FindAndReplace(wordApp, "<MrGDCSKH>", " " + confirmPO.MrGD_CSKH + " ");
                    FindAndReplace(wordApp, "<MrGDMobile>", " " + confirmPO.MrGD_CSKH_mobile + " ");

                    FindAndReplace(wordApp, "<LandLine>", " " + confirmPO.MrGD_CSKH_Landline + " ");
                    FindAndReplace(wordApp, "<Ext>", " " + confirmPO.MrrGD_CSKH_LandlineExt + " ");

                }
                else
                {
                    MessageBox.Show("File Xác Nhận Đơn Hàng Not Found!");
                }

                //Save as
                myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);

                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Xác Nhận Đơn Hàng Đã Được Created!");
            }
            catch (Exception)
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Xác Nhận Đơn Hàng không Được Created!");
            }
        }


        // tạo chứng chỉ phần mềm
        public static void Create_Sofware_Certificate_Template(object filename, object SaveAs, string idContract, string pOnumber, string KHMS, string idNTKT, float numoD)
        {
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myWordDoc = null;

            try
            {
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;

                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);
                    myWordDoc.Activate();
                    NTKT nTKT = new NTKT();
                    int ret = nTKT.GetObjectNTKT(idNTKT, ref nTKT);
                    //find and replace
                    FindAndReplace(wordApp, "<Contract_ID>", " " + idContract + " ");
                    FindAndReplace(wordApp, "<PO_Number>", " " + pOnumber + " ");
                    FindAndReplace(wordApp, "<KHMS>", " " + KHMS + " ");
                    FindAndReplace(wordApp, "<NoD>", " " + (numoD).ToString() + " ");
                    FindAndReplace(wordApp, "<NoD0.98>", " " + (numoD - Math.Round((numoD) * 0.02)).ToString() + " ");
                    FindAndReplace(wordApp, "<NoD0.02>", " " + Math.Round((numoD) * 0.02).ToString() + " ");
                    //string[] dateNow = convertDateFormat.ConvertFormatDate(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", "dd/MM/yyyy");
                    //FindAndReplace(wordApp, "<DateNow>", " " + dateNow[0] + "/" + dateNow[1] + "/" + dateNow[2]);
                }
                else
                {
                    MessageBox.Show("File not Found!");
                }

                //Save as
                myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);

                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Giấy chứng nhận bản quyền phần mềm Được Tạo");
            }
            catch (Exception)
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Giấy chứng nhận bản quyền phần mềm không Tạo thành công");
            }
        }
        //tạo chứng nhận chất lượng
        public static void Create_CNCL(object filename, object SaveAs, string idContract, string pOnumber, string KHMS, string idNTKT, float Nod)
        {
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myWordDoc = null;

            try
            {
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;

                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);
                    myWordDoc.Activate();
                    NTKT nTKT = new NTKT();
                    int ret = nTKT.GetObjectNTKT(idNTKT, ref nTKT);
                    //find and replace
                    FindAndReplace(wordApp, "<Contract_ID>", " " + idContract + " ");
                    FindAndReplace(wordApp, "<PO_Number>", " " + pOnumber + " ");
                    FindAndReplace(wordApp, "<KHMS>", " " + KHMS + " ");
                    FindAndReplace(wordApp, "<Total>", " " + (Nod).ToString() + " ");
                    FindAndReplace(wordApp, "<NofDe>", " " + (Nod - Math.Round((Nod) * 0.02)).ToString() + " ");
                    FindAndReplace(wordApp, "<BHD>", " " + Math.Round((Nod) * 0.02).ToString() + " ");
                    //string[] dateNow = convertDateFormat.ConvertFormatDate(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", "dd/MM/yyyy");
                    //FindAndReplace(wordApp, "<dd>/<MM>/<yyyy>", " " + dateNow[0] + "/" + dateNow[1] + "/" + dateNow[2]);
                }
                else
                {
                    MessageBox.Show("File not Found!");
                }

                //Save as
                myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);

                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File chứng nhận hợp quy của thiết bị được tạo");
            }
            catch (Exception)
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File chứng nhận hợp quy của thiết bị không được tạo thành công");
            }
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
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
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
        //Mẫu 20
        public static void Word_DPCNCL(string txbIDContract, string txbPOName, string txbPOCode, string txbIdDP, string diaChi, string mahangHD, string tenhangHD, string maHangSP, string tenHangSP, string soLuong, string GhiChu,string dtpOutCap)
        {
            //Khởi tạo vào check forder
            //Lấy số lượng bảo hành của tỉnh vừa nhập.
            DP dp = new DP();
            string slp = dp.GetInforSLP(diaChi, txbIdDP, txbPOCode);
            //
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
            object filename = strPODirectory + @"\Chung nhan CL_" + diaChi + ".docx";
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            //
            object path = DriveName + @"\OPM\Template\Mau 20. GIAY CNCL gui tinh.docx";
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
                FindAndReplace(wordApp, "<dtpOutCap>", " " + dtpOutCap);
                FindAndReplace(wordApp, "<Idcontract>", " " + txbIDContract);
                FindAndReplace(wordApp, "<IdPO>", " " + txbPOCode);
                FindAndReplace(wordApp, "<Tentinh>", " " + diaChi);
                FindAndReplace(wordApp, "<Tenhang>", " " + tenhangHD);
                FindAndReplace(wordApp, "<loaihang>", " " + mahangHD);
                FindAndReplace(wordApp, "<Soluong>", " " + soLuong);
                FindAndReplace(wordApp, "<slp>", " " + slp);
                FindAndReplace(wordApp, "<tong>", " " + (Int64.Parse(slp) + Int64.Parse(soLuong)));
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
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
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
        //Mãu 18
        public static void Word_GiaoNhanHangHoa(string txbKHMS, string txbIDContract, string txbPOCode, string txbPOName, string ProvinceName,string dtpRequest, string txbIdDP,string dtpOutCap, string mahangHD,string tenhangHD,string count)
        {
            PO_Thanh po = new PO_Thanh(txbPOCode);
            Contract_Thanh contract = new Contract_Thanh(txbIDContract);
            //Lấy thông tin viễn thông các tỉnh
            DP dp = new DP();
            DataTable dataTable = new DataTable();
            dataTable = dp.GetInforSite(ProvinceName);
            //Lấy thông tin đơn giá của hàng
            DataTable dataTable1 = new DataTable();
            dataTable1 = dp.GetInforPrice(txbIDContract, mahangHD);
            //Lấy số lượng bảo hành của tỉnh vừa nhập.
            string slp = dp.GetInforSLP(ProvinceName, txbIdDP, txbPOCode);
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
            string FoderName = String.Format(po.Id);
            string strPODirectory = DriveName + "OPM\\" + txbIDContract.Trim().Replace('/', '-') + "\\" + txbPOName.Trim().Replace('/', '-') + "\\" + txbIdDP.Trim().Replace('/', '-');
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\Bien ban GNHH "+ProvinceName+".docx";
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            //
            object path = DriveName + @"\OPM\Template\Mau 18. Bien ban giao nhan hang hoa.docx";
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
                OpmWordHandler.FindAndReplace(wordApp, "<txbPOName>", txbPOName);
                OpmWordHandler.FindAndReplace(wordApp, "<txbIDContract>", txbIDContract);
                OpmWordHandler.FindAndReplace(wordApp, "<txbKHMS>", txbKHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<txbPOCode>", txbPOCode);
                OpmWordHandler.FindAndReplace(wordApp, "<dtpRequest>", dtpRequest);
                OpmWordHandler.FindAndReplace(wordApp, "<ProvinceName>", ProvinceName);
                OpmWordHandler.FindAndReplace(wordApp, "<dtpOutCap>", dtpOutCap);
                OpmWordHandler.FindAndReplace(wordApp, "<DiaChi>", dataTable.Rows[0][3].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<Phone>", dataTable.Rows[0][4].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<Fax>", dataTable.Rows[0][5].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<People1>", dataTable.Rows[0][8].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<Position1>", dataTable.Rows[0][9].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<People2>", dataTable.Rows[0][11].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<Position2>", dataTable.Rows[0][12].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<People3>", dataTable.Rows[0][14].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<Position3>", dataTable.Rows[0][15].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<TenHang>", tenhangHD);
                OpmWordHandler.FindAndReplace(wordApp, "<MaHang>", mahangHD);
                OpmWordHandler.FindAndReplace(wordApp, "<slc>", count);
                OpmWordHandler.FindAndReplace(wordApp, "<dg>", dataTable1.Rows[0][7].ToString());
                OpmWordHandler.FindAndReplace(wordApp, "<tt>", Int64.Parse(dataTable1.Rows[0][7].ToString())*Int64.Parse(count));
                OpmWordHandler.FindAndReplace(wordApp, "<gtgt>", (Int64.Parse(dataTable1.Rows[0][7].ToString()) * Int64.Parse(count))*10/100);
                OpmWordHandler.FindAndReplace(wordApp, "<tong>", Int64.Parse(dataTable1.Rows[0][7].ToString()) * Int64.Parse(count) + ((Int64.Parse(dataTable1.Rows[0][7].ToString()) * Int64.Parse(count)) * 10 / 100));
                OpmWordHandler.FindAndReplace(wordApp, "<slp>", slp);
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
                MessageBox.Show("Không tìm thấy bản mẫu");
            }
        }
        //Tạo mẫu 21
        public static void Word_PhuLucSerial(string txbIDContract, string txbPOCode, string txbPOName, string txbIdDP, string ProvinceName)
        {
            PO_Thanh po = new PO_Thanh(txbPOCode);
            Contract_Thanh contract = new Contract_Thanh(po.IdContract);
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
            string FoderName = String.Format(po.Id);
            string strPODirectory = DriveName + "OPM\\" + txbIDContract.Trim().Replace('/', '-') + "\\" + txbPOName.Trim().Replace('/', '-') + "\\" + txbIdDP.Trim().Replace('/', '-');
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\Phu luc Serial "+ ProvinceName+ ".docx";
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = DriveName + @"\OPM\Template\Mau 21. Phu luc Serial.docx";
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
                //FileLocation = path
                Microsoft.Office.Interop.Word.Table tab = myDoc.Tables[1];
                DP dp = new DP();
                DataTable dt_PO = new DataTable();
                if (dp.Check_Serial(txbIdDP, txbPOCode))
                {
                    string sql = dp.querySQL(txbIdDP, txbPOCode);
                    DataTable table1 = OPMDBHandler.ExecuteQuery(sql);
                    for (int i = 2; i < table1.Rows.Count - 1; i++)
                    {
                        Object objMiss = Missing.Value;
                        tab.Rows.Add(ref objMiss);
                        tab.Cell(i, 1).Range.Text = (i - 1).ToString();
                        tab.Cell(i, 2).Range.Text = table1.Rows[i][1].ToString();
                    }
                }
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
                MessageBox.Show("Không tìm thấy bản mẫu");
            }
        }
    }
}
