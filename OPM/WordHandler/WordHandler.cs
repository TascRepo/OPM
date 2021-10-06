using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using WordOffice = Microsoft.Office.Interop.Word;
using System.Reflection;
using OPM.OPMEnginee;
using OPM.WordHandler;
using OPM.GUI;
using System.Globalization;
using OPM.DBHandler;
using System.IO;
namespace OPM.WordHandler
{
    class OpmWordHandler
    {
        private string _nameWordfile;
        public OpmWordHandler()
        {
        }
        ~OpmWordHandler()
        { }

        public string FileName
        {
            set { _nameWordfile = value; }
            get { return _nameWordfile; }
        }
        //Tạo mẫu 37
        public static string Temp37_BBXNCDLicense(string id)
        {
            //NTKT_Thanh ntkt = new NTKT_Thanh(id);
            PO_Thanh po = new PO_Thanh(id);
            Contract contract = new Contract(po.Id_contract);
            Site_Info site = new Site_Info(contract.Id_siteA);
            object filename = string.Format(@"D:\OPM\{0}\{1}\BBXNCDLicense_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 37. Biên bản xác nhận cài đặt License vào hệ thống.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.Confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.Numberofdevice);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.Numberofdevice + Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));

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
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Mẫu 37. Biên bản xác nhận cài đặt License vào hệ thống.docx!");
            }
            return filename.ToString();
        }
        //Tạo mẫu 36
        public static string Temp36_BBNTLicense(string id)
        {
            //NTKT_Thanh ntkt = new NTKT_Thanh(id);
            PO_Thanh po = new PO_Thanh(id);
            Contract contract = new Contract(po.Id_contract);
            Site_Info site = new Site_Info(contract.Id_siteA);
            object filename = string.Format(@"D:\OPM\{0}\{1}\BBNTLicense_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 36. Biên bản nghiệm thu License.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.Confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.Numberofdevice);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.Numberofdevice + Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));

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
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Mẫu 36. Biên bản nghiệm thu License.docx!");
            }
            return filename.ToString();
        }

        //Tạo mẫu 24
        public static string Temp24_CNCLNMTongHop(string id)
        {
            //NTKT_Thanh ntkt = new NTKT_Thanh(id);
            PO_Thanh po = new PO_Thanh(id);
            Contract contract = new Contract(po.Id_contract);
            Site_Info site = new Site_Info(contract.Id_siteA);
            object filename = string.Format(@"D:\OPM\{0}\{1}\CNCLNM_Tong_Hop_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 24. Giấy CNCL NM tổng hợp.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.Confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.Numberofdevice);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.Numberofdevice + Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));

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
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Mẫu 24. Giấy CNCL NM tổng hợp.docx!");
            }
            return filename.ToString();
        }

        //Tạo mẫu 23
        public static string Temp23_CNCL_TongHop(string id)
        {
            //NTKT_Thanh ntkt = new NTKT_Thanh(id);
            PO_Thanh po = new PO_Thanh(id);
            Contract contract = new Contract(po.Id_contract);
            Site_Info site = new Site_Info(contract.Id_siteA);
            object filename = string.Format(@"D:\OPM\{0}\{1}\CNCL_Tong_Hop_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'),po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 23. GIAY_CNCL_TONG_HOP.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.Confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.Numberofdevice);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice2>", Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Total>", po.Numberofdevice+ Math.Round(po.Numberofdevice * 0.02, 0, MidpointRounding.AwayFromZero));

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
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Mẫu 23. GIAY_CNCL_TONG_HOP.docx!");
            }
            return filename.ToString();
        }

        //Tạo mẫu 11
        public static string Temp11_BBNTKT(string id)
        {
            NTKT_Thanh ntkt = new NTKT_Thanh(id);
            PO_Thanh po = new PO_Thanh(ntkt.Id_po);
            Contract contract = new Contract(po.Id_contract);
            Site_Info site = new Site_Info(contract.Id_siteA);
            object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\BBNTKT_{3}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), ntkt.Number, ntkt.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 11. Biên bản nghiệm thu kỹ thuật.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.Create_date.Day, ntkt.Create_date.Month, ntkt.Create_date.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.Confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.Numberofdevice);

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
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), ntkt.Number);
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Mẫu 11. Biên bản nghiệm thu kỹ thuật.docx!");
            }
            return filename.ToString();
        }
        //Tạo mẫu 10
        public static string Temp10_CNBQPM(string id)
        {
            NTKT_Thanh ntkt = new NTKT_Thanh(id);
            PO_Thanh po = new PO_Thanh(ntkt.Id_po);
            Contract contract = new Contract(po.Id_contract);
            Site_Info site = new Site_Info(contract.Id_siteA);
            object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\CNBQPM_{3}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), ntkt.Number, ntkt.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            object path = @"D:\OPM\Template\Mẫu 10. Chứng nhận bản quyền phần mềm.docx";
            if (File.Exists(path.ToString()))
            {
                object readOnly = true;
                //object isVisible = false;
                wordApp.Visible = false;

                WordOffice.Document myDoc = wordApp.Documents.Open(ref path, ref missing, ref readOnly,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing);
                myDoc.Activate();
                //find and replace
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.Create_date.Day, ntkt.Create_date.Month, ntkt.Create_date.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.Confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.Numberofdevice);

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
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Total>", ntkt.Numberofdevice+ ntkt.Numberofdevice2);

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), ntkt.Number);
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Mẫu 10. Chứng nhận bản quyền phần mềm.docx!");
            }
            return filename.ToString();
        }
        //Tạo mẫu 9
        public static string Temp09_BBKTKT(string id)
        {
            NTKT_Thanh ntkt = new NTKT_Thanh(id);
            PO_Thanh po = new PO_Thanh(ntkt.Id_po);
            Contract contract = new Contract(po.Id_contract);
            Site_Info site = new Site_Info(contract.Id_siteA);
            object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\BBKTKT_{3}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), ntkt.Number, ntkt.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 9. Biên bản kiểm tra kỹ thuật.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.Create_date.Day, ntkt.Create_date.Month, ntkt.Create_date.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);

                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_number>", po.Confirmpo_number);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Numberofdevice>", po.Numberofdevice);

                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice>", ntkt.Numberofdevice);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Numberofdevice2>", ntkt.Numberofdevice2);
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Create_date>", ntkt.Create_date.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.KT2%>", Math.Round((ntkt.Numberofdevice+ ntkt.Numberofdevice2)*0.02, 0, MidpointRounding.AwayFromZero));
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
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), ntkt.Number);
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy Mẫu 9. Biên bản kiểm tra kỹ thuật.doc! ");
            }
            return filename.ToString();
        }
        //Tạo mẫu 8
        public static string Temp08_NTKTRequest(string id)
        {
            NTKT_Thanh ntkt = new NTKT_Thanh(id);
            PO_Thanh po = new PO_Thanh(ntkt.Id_po);
            Contract contract = new Contract(po.Id_contract);
            object filename = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}\YCNTKT_{3}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), ntkt.Number,ntkt.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 8. De nghi NTKT.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}", ntkt.Create_date.Day, ntkt.Create_date.Month, ntkt.Create_date.Year));
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Activedate>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Id>", ntkt.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Number>", ntkt.Number);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id_siteA>", contract.Id_siteA);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Po_number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Id>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Namecontract>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<contract.Datesigned>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Id>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<po.Datecreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<po.Confirmpo_datecreated>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ntkt.Deliver_date_expected>", ntkt.Deliver_date_expected.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}\NTKT{2}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), ntkt.Number);
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Mẫu 8. De nghi NTKT.docx! ");
            }
            return filename.ToString();
        }

        //Tạo mẫu 3
        public static void Word_POConfirm(string id,string ConfirmPO_Number,string txbIDContract)
        {
            PO_Thanh po = new PO_Thanh(id);
            Contract contract = new Contract(po.Id_contract);
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
            string strPODirectory = DriveName + "OPM\\"+ po.Id_contract + "\\" + po.Po_number + "-" + FoderName; 
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\Xac nhan don hang.docx";
            //object filename = string.Format(DriveName + @"\OPM\{0}\{1}\XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            //
            object path = DriveName + @"LP\Mau 3. van ban xac nhan hieu luc don hang.docx";
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
                OpmWordHandler.FindAndReplace(wordApp, "<yyyy>", " " + DateTime.Now.ToString("yyyy") + " ");
                OpmWordHandler.FindAndReplace(wordApp, "<ConfirmPO_Number>", po.Confirmpo_number);
                //OpmWordHandler.FindAndReplace(wordApp, "<Signed_Date>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteA>", contract.Id_siteA);
                OpmWordHandler.FindAndReplace(wordApp, "<PO_Number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_ID>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_Name>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_DateCreated>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PO_ID>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<PO_DateCreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PO_ConfirmDateActive>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                //FileLocation = path
                Microsoft.Office.Interop.Word.Table tab = myDoc.Tables[3];
                Delivery_PO po1 = new Delivery_PO();
                DataTable dt_PO = new DataTable();
                if(po1.CheckDelivery_PO(ConfirmPO_Number, id) == 1)
                {
                    string sql = po1.querySQL(ConfirmPO_Number);
                    DataTable table1 = OPMDBHandler.ExecuteQuery(sql);
                    for (int i = 2; i < table1.Rows.Count - 1 ; i++)
                    {
                        Object objMiss = Missing.Value;
                        tab.Rows.Add(ref objMiss);
                        tab.Cell(i, 1).Range.Text = (i - 1).ToString();
                        tab.Cell(i, 2).Range.Text = table1.Rows[i][2].ToString();
                        tab.Cell(i, 3).Range.Text = table1.Rows[i][3].ToString();
                        tab.Cell(i, 4).Range.Text = table1.Rows[i][4].ToString();
                        tab.Cell(i, 5).Range.Text = table1.Rows[i][5].ToString();
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
        public static void Word_POTamUng(string id)
        {
            PO_Thanh po = new PO_Thanh(id);
            Contract contract = new Contract(po.Id_contract);
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
            string strPODirectory = DriveName + "OPM\\" + po.Id_contract + "\\" + po.Po_number + "-" + FoderName;
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\Van ban de nghi tam ung.docx";
            //object filename = string.Format(DriveName + @"\OPM\{0}\{1}\XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            //
            object path = DriveName + @"LP\Mau 5. Van ban mo tam ung PO.docx";
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
                FindAndReplace(wordApp, "<MM>", " " + DateTime.Now.ToString("MM") + " ");
                FindAndReplace(wordApp, "<yyyy>", " " + DateTime.Now.ToString("yyyy") + " ");
                FindAndReplace(wordApp, "<Number>", " " + po.Confirmpo_number);
                FindAndReplace(wordApp, "<PO_Name>", " " + po.Po_number);
                FindAndReplace(wordApp, "<Contract_ID>", " " + contract.Id);
                FindAndReplace(wordApp, "<Contract_Name>", " " + contract.Namecontract);
                FindAndReplace(wordApp, "<Signed_DateContract>", " " + po.Dateconfirm.ToString());
                FindAndReplace(wordApp, "<Signed_DatePO>", " " + po.Datecreated.ToString());
                FindAndReplace(wordApp, "<Total_Value>", " " + po.Totalvalue);
                FindAndReplace(wordApp, "<Value_Tamung>", " " + po.Tupo);
                FindAndReplace(wordApp, "<Site_B>", " " + contract.Id_siteB);
                FindAndReplace(wordApp, "<Active_Date>", " " + po.Datecreated.ToString());
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
        public static void Word_POBaoLanh(string id)
        {
            PO_Thanh po = new PO_Thanh(id);
            Contract contract = new Contract(po.Id_contract);
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
            string strPODirectory = DriveName + "OPM\\" + po.Id_contract + "\\" + po.Po_number + "-" + FoderName;
            if (!Directory.Exists(strPODirectory))
            {
                Directory.CreateDirectory(strPODirectory);
            }
            object filename = strPODirectory + @"\Bao lanh PO.docx";
            //object filename = string.Format(DriveName + @"\OPM\{0}\{1}\XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            //
            object path = DriveName + @"LP\Mau 4. Van ban mo thuc hien bao lanh PO.docx";
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
                FindAndReplace(wordApp, "<PO_Name>", " " + po.Po_number);
                FindAndReplace(wordApp, "<Contract_ID>", " " + contract.Id);
                FindAndReplace(wordApp, "<Contract_Name>", " " + contract.Namecontract);
                FindAndReplace(wordApp, "<Signed_DateContract>", " " + contract.Datesigned.ToString());
                FindAndReplace(wordApp, "<Signed_DatePO>", " " + contract.Datesigned.ToString());
                FindAndReplace(wordApp, "<Total_Value>", " " + contract.Valuecontract);
                FindAndReplace(wordApp, "<Value_Tamung>", " " + po.Tupo);
                FindAndReplace(wordApp, "<Site_B>", " " + contract.Id_siteB);
                FindAndReplace(wordApp, "<Active_Date>", " " + po.Dateconfirm.ToString());
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
            PO_Thanh po = new PO_Thanh(id);
            Contract contract = new Contract(po.Id_contract);
            object filename = string.Format(@"D:\OPM\{0}\{1}\XacnhanPO_{2}.docx", contract.Id.Trim().Replace('/', '-'),po.Po_number.Replace('/', '-'), po.Id.Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 3. VB xác nhận hiệu lực đơn hàng.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<Ngày tháng năm>", string.Format("ngày {0} tháng {1} năm {2}",DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                //OpmWordHandler.FindAndReplace(wordApp, "<Now>", contract.Activedate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<ConfirmPO_Number>", po.Confirmpo_number);
                //OpmWordHandler.FindAndReplace(wordApp, "<Signed_Date>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<SiteA>", contract.Id_siteA);
                OpmWordHandler.FindAndReplace(wordApp, "<PO_Number>", po.Po_number);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_ID>", contract.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_Name>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<KHMS>", contract.KHMS);
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_DateCreated>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PO_ID>", po.Id);
                OpmWordHandler.FindAndReplace(wordApp, "<PO_DateCreated>", po.Datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<PO_ConfirmDateActive>", po.Confirmpo_datecreated.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));

                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}\{1}", contract.Id.Trim().Replace('/', '-'), po.Po_number.Replace('/', '-'));
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                myDoc.Close();
                wordApp.Quit();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản mẫu 3.docx! ");
            }
            return filename.ToString();
        }


        //Tạo mẫu 1
        public static string Temp1_CreatContractGuarantee(string id)
        {
            Contract contract = new Contract(id);
            object filename = string.Format(@"D:\OPM\{0}\BLHD_{0}.docx", id.Trim().Replace('/', '-'));
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myDoc = null;
            object path = @"D:\OPM\Template\Mẫu 1. Đề nghị mở bảo lãnh thực hiện HĐ.docx";
            if (File.Exists(path.ToString()))
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
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_Code>", id.Trim());
                OpmWordHandler.FindAndReplace(wordApp, "<Date_Created>", contract.GaranteeCreatedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<Contract_Name>", contract.Namecontract);
                OpmWordHandler.FindAndReplace(wordApp, "<Signed_Date>", contract.Datesigned.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ")));
                OpmWordHandler.FindAndReplace(wordApp, "<Site_A>", contract.Id_siteA);
                OpmWordHandler.FindAndReplace(wordApp, "<blvalue>", contract.Blvalue);
                OpmWordHandler.FindAndReplace(wordApp, "<DurationPO>", contract.Durationpo);
                //Tạo file BLHĐ trong thư mục D:\OPM
                string folder = string.Format(@"D:\OPM\{0}", id.Trim().Replace('/', '-'));
                Directory.CreateDirectory(folder);
                try
                {
                    myDoc.SaveAs2(ref filename);
                    MessageBox.Show(string.Format("Đã tạo file {0}", filename.ToString()));
                    myDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản mẫu 1! ");
            }
            return filename.ToString();
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
        private static ConvertDateFormat convertDateFormat = new ConvertDateFormat();
        public static void CreateWordDocument(object filename, object SaveAs, string strName, string strFirstname, string strBirthday, string strDate)
        {
            WordOffice.Application wordApp = new WordOffice.Application();
            object missing = Missing.Value;
            WordOffice.Document myWordDoc = null;

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
                FindAndReplace(wordApp, "<name>", strName);
                FindAndReplace(wordApp, "<firstname>", strFirstname);
                //this.FindAndReplace(wordApp, "<birthday>", dateTimePicker1.Value.ToShortDateString());
                FindAndReplace(wordApp, "<birthday>", strBirthday);
                //this.FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());
                string[] dates = convertDateFormat.ConvertFormatDate(strDate, "yyyy-MM-dd", "dd/MM/yyyy");
                FindAndReplace(wordApp, "<date>", dates[0]+"/"+dates[1]+"/"+dates[2]+" ");
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
            MessageBox.Show("File Created!");
        }

        public static void Create_BLTU_Contract(object filename, object SaveAs, string strPOnumber, string strIdContract, string strSigndate, string strPOdate)
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
                    FindAndReplace(wordApp, "<tempPO>", " " + strPOnumber + " ");
                    FindAndReplace(wordApp, "<temp_IdContract>", " " + strIdContract + " ");
                    //this.FindAndReplace(wordApp, "<birthday>", dateTimePicker1.Value.ToShortDateString());
                    FindAndReplace(wordApp, "<tmp_signdate>", " " + strSigndate + " ");
                    //this.FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());
                    string[] date_po = convertDateFormat.ConvertFormatDate(strPOdate, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<date_po>", " " + date_po[0] + "/" + date_po[1] + "/" + date_po[2] + " ");
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
                MessageBox.Show("File Created!");
            }
            catch(Exception)
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File did'nt Created!");
            }
        }
        public static void Create_BLTH_PO(object filename, object SaveAs,string strPOnumber)
        { }
        public static void Create_BLTU_PO(object filename, object SaveAs,string strPOnumber, string strIdContract, string strContractName, string strSigneddateContract, string strPOSigneddate, string strPOValueNotVAT, string strPOValueTU, string strSiteB, string strActiveDatePO)
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
                    FindAndReplace(wordApp, "<PO_Name>", " " + strPOnumber);
                    FindAndReplace(wordApp, "<Contract_ID>", " " + strIdContract);
                    FindAndReplace(wordApp, "<Contract_Name>", " " + strContractName);
                    string[] Signed_DateContract = convertDateFormat.ConvertFormatDate(strSigneddateContract, "dd-MM-yyyy", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<Signed_DateContract>", " " + Signed_DateContract[0] + "/" + Signed_DateContract[1] + "/" + Signed_DateContract[2]);
                    string[] Signed_DatePO = convertDateFormat.ConvertFormatDate(strPOSigneddate, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<Signed_DatePO>", " " + Signed_DateContract[0] + "/" + Signed_DateContract[1] + "/" + Signed_DateContract[2]);
                    FindAndReplace(wordApp, "<Total_Value>", " " + strPOValueNotVAT);
                    FindAndReplace(wordApp, "<Value_Tamung>", " " + strPOValueTU);
                    FindAndReplace(wordApp, "<Site_B>", " " + strSiteB);
                    string[] Active_Date = convertDateFormat.ConvertFormatDate(strActiveDatePO, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<Active_Date>", " " + Active_Date[0] + "/" + Active_Date[1] + "/" + Active_Date[2]);
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
                MessageBox.Show("File Bảo Lãnh Thực Hiện Created!");
            }
            catch
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Bảo Lãnh Thực Hiện không được Created!");
            }

        }

        public static void Create_DNTU_PO(object filename, object SaveAs)
        { }
        public static void Create_RQNTKT_PO(object filename, object SaveAs, NTKT nTKT, PO objPO, ContractObj contractObj)
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

                    FindAndReplace(wordApp, "<NTKT_ID>", " " + nTKT.ID_NTKT + " ");
                    string[] Date_NTKT_DuKien = convertDateFormat.ConvertFormatDate(nTKT.DateDuKienNTKT, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<Date_NTKT_DuKien>", " " + Date_NTKT_DuKien[0] + "/" + Date_NTKT_DuKien[1] + "/" + Date_NTKT_DuKien[2]);

                    FindAndReplace(wordApp, "<PO_Number>", " " + nTKT.PONumber + " ");
                    FindAndReplace(wordApp, "<PO_ID>", " " + nTKT.POID + " ");
                    string[] Created_DatePO = convertDateFormat.ConvertFormatDate(objPO.DateCreatedPO, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<Created_DatePO>", " " + Created_DatePO[0] + "/" + Created_DatePO[1] + "/" + Created_DatePO[2]);

                    FindAndReplace(wordApp, "<KHMS>", " " + nTKT.KHMS + " ");
                    FindAndReplace(wordApp, "<Contract_ID>", " " + nTKT.IDContract + " ");
                    FindAndReplace(wordApp, "<Contract_Name>", " " + contractObj.NameContract + " ");
                    string[] SignedDate_Contract = convertDateFormat.ConvertFormatDate(contractObj.DateSigned, "dd-MM-yyyy", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<SignedDate_Contract>", " " + SignedDate_Contract[0] + "/" + SignedDate_Contract[1] + "/" + SignedDate_Contract[2]);
                    FindAndReplace(wordApp, "<Site_B>", " " + contractObj.SiteB + " ");

                    FindAndReplace(wordApp, "<Mr_PhoBan>", " " + nTKT.MrPhoBan + " ");
                    FindAndReplace(wordApp, "<Mobile>", " " + nTKT.MrPhoBanMobile + " ");

                    FindAndReplace(wordApp, "<Mr_GD_HTKT_CSKH>", " " + nTKT.MrGD_CSKH + " ");
                    FindAndReplace(wordApp, "<Mr_GD_Mobile>", " " + nTKT.MrGD_CSKH_mobile + " ");

                    FindAndReplace(wordApp, "<MrGDLandLine>", " " + nTKT.MrGD_CSKH_Landline + " ");
                    FindAndReplace(wordApp, "<Ext>", " " + nTKT.MrrGD_CSKH_LandlineExt + " ");

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
                MessageBox.Show("File Yêu Cầu Nghiệm Thu Kỹ Thuật Đã Được Created!");
            }
            catch
            {
                myWordDoc.Close();

                wordApp.Quit();
                MessageBox.Show("File Yêu Cầu Nghiệm Thu Kỹ Thuật không Được Created thành công!");
            }
        }

        public static void PrintDocument(object filename)
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

                    myWordDoc.Application.ActivePrinter = "PCL6 V4 Driver for Universal Print";
                    myWordDoc.PrintOut();
                }
                else
                {
                    MessageBox.Show("File not Found!");
                }

                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Created!");
            }
            catch(Exception)
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Created không thành công!");

            }
        }

        public static void PrintDocumentA(object filename)
        {
            return;
        }

        public static void  CreateBLTH_Contract(object filename, object SaveAs, string strContractCode, string strContractName, string strSigneddate,string tbxSiteB,string txbGaranteeValue,string txbGaranteeActiveDate)
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
                    FindAndReplace(wordApp, "<Contract_Code>", " " + strContractCode + " ");
                    FindAndReplace(wordApp, "<Contract_Name>", " " + strContractName + " ");
                    FindAndReplace(wordApp, "<Signed_Date>", " " + strSigneddate + " ");
                    FindAndReplace(wordApp, "<Site_B>", " " + tbxSiteB + " ");
                    FindAndReplace(wordApp, "<Grt_Val>", " " + txbGaranteeValue + " ");
                    FindAndReplace(wordApp, "<Grt_Act_Date>", " " + txbGaranteeActiveDate + " ");

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
                MessageBox.Show("File Bảo Lãnh Thực Hiện Hợp Đồng Đã Được Tạo");
            }
            catch(Exception)
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Bảo Lãnh Thực Hiện Hợp Đồng không Được Tạo thành công");
            }
        }
           
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
                    string[] dateNow = convertDateFormat.ConvertFormatDate(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<DateNow>", " " + dateNow[0] + "/" + dateNow[1] + "/" + dateNow[2]);
                    FindAndReplace(wordApp, "<PO_Number>", " " + confirmPO.PONumber + " ");
                    FindAndReplace(wordApp, "<PO_ID>", " " + confirmPO.POID + " ");
                    string[] PO_CreatedDate = convertDateFormat.ConvertFormatDate(objPO.DateCreatedPO, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<PO_DateCreated>", " " + PO_CreatedDate[0] + "/" + PO_CreatedDate[1] + "/" + PO_CreatedDate[2]);

                    FindAndReplace(wordApp, "<KHMS>", " " + confirmPO.KHMS + " ");
                    FindAndReplace(wordApp, "<Contract_ID>", " " + confirmPO.IDContract + " ");
                    FindAndReplace(wordApp, "<Contract_Name>", " " + contractObj.NameContract + " ");
                    string[] Contract_DateSigned = convertDateFormat.ConvertFormatDate(contractObj.DateSigned, "dd-MM-yyyy", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<Contract_DateSigned>", " " + Contract_DateSigned[0] + "/" + Contract_DateSigned[1] + "/" + Contract_DateSigned[2]);
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
            catch(Exception)
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Xác Nhận Đơn Hàng không Được Created!");
            }
        }


        public static void Create_BBKTKT_HH(object filename, object SaveAs,ContractObj contractObject ,PO objPO, NTKT nTKT, SiteInfo siteInfo, SiteInfo siteInfoA)
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
                    FindAndReplace(wordApp, "<PO_Number>", " " + objPO.PONumber + " ");
                    FindAndReplace(wordApp, "<PO_ID>", " " + objPO.IDPO + " ");
                    string[] PO_CreatedDate = convertDateFormat.ConvertFormatDate(objPO.DateCreatedPO, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<PO_CreatedDate>", " " + PO_CreatedDate[0] + "/" + PO_CreatedDate[1] + "/" + PO_CreatedDate[2]);
                    FindAndReplace(wordApp, "<XNDH_ID>", " " + objPO.IDPO + " ");
                    string[] XNDH_CreatedDate = convertDateFormat.ConvertFormatDate(objPO.DefaultActiveDatePO, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<XNDH_CreatedDate>", " " + XNDH_CreatedDate[0] + "/" + XNDH_CreatedDate[1] + "/" + XNDH_CreatedDate[2]);
                    FindAndReplace(wordApp, "<NTKT_ID>", " " + nTKT.ID_NTKT + " ");
                    string[] NTKT_CreatedDate = convertDateFormat.ConvertFormatDate(nTKT.getCreateDate, "yyyy-MM-dd", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<NTKT_CreatedDate>", " " + NTKT_CreatedDate[0] + "/" + NTKT_CreatedDate[1] + "/" + NTKT_CreatedDate[2]);
                    FindAndReplace(wordApp, "<DC>", " " + (Math.Round(nTKT.NumberOfDevice - (nTKT.NumberOfDevice) * 0.02)) + " ");
                    FindAndReplace(wordApp, "<PDC>", " " + (Math.Round((nTKT.NumberOfDevice) * 0.02)) + " ");
                    string[] dateNow = convertDateFormat.ConvertFormatDate(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<DateNow>", " " + dateNow[0] + "/" + dateNow[1] + "/" + dateNow[2]);

                    FindAndReplace(wordApp, "<Contract_ID>", " " + contractObject.IdContract + " ");
                    FindAndReplace(wordApp, "<Contract_Name>", " " + contractObject.NameContract + " ");
                    FindAndReplace(wordApp, "<KHMS>", " " + contractObject.KHMS + " ");
                    string[] Contract_DateSigned = convertDateFormat.ConvertFormatDate(contractObject.DateSigned, "dd-MM-yyyy", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<Contract_DateSigned>", " " + Contract_DateSigned[0] + "/" + Contract_DateSigned[1] + "/" + Contract_DateSigned[2]);
                    FindAndReplace(wordApp, "<Site_B>", " " + contractObject.SiteB + " ");

                    FindAndReplace(wordApp, "<Address_Site_B>", " " + siteInfo.Address + " ");
                    FindAndReplace(wordApp, "<LandLine_Site_B>", " " + siteInfo.Phonenumber + " ");
                    FindAndReplace(wordApp, "<Fax_Site_B>", " " + siteInfo.Tin + " ");

                    FindAndReplace(wordApp, "<LandLine_Site_A>", " " + siteInfoA.Phonenumber + " ");
                    FindAndReplace(wordApp, "<Fax_Site_A>", " " + siteInfoA.Tin + " ");
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
                MessageBox.Show("File Biên Bản Kiểm Tra Kĩ Thuật Hàng Hóa Được Tạo");
            }
            catch (Exception)
            {
                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Biên Bản Kiểm Tra Kĩ Thuật Hàng Hóa không Tạo thành công");
            }
        }
        // tạo chứng chỉ phần mềm
        public static void Create_Sofware_Certificate_Template(object filename, object SaveAs, string idContract, string pOnumber, string KHMS,string idNTKT, float numoD)
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
                    string[] dateNow = convertDateFormat.ConvertFormatDate(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<DateNow>", " " + dateNow[0] + "/" + dateNow[1] + "/" + dateNow[2]);
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
                    string[] dateNow = convertDateFormat.ConvertFormatDate(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", "dd/MM/yyyy");
                    FindAndReplace(wordApp, "<dd>/<MM>/<yyyy>", " " + dateNow[0] + "/" + dateNow[1] + "/" + dateNow[2]);
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
    }
}
