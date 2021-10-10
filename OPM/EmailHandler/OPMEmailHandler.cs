using System.Net.Mail;

namespace OPM.EmailHandler
{
    class OPMEmailHandler : IEmailHandler
    {
        public static void fSendEmail(string htmlString, string strSendFile)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("johantesttoiec10@gmail.com");
            mail.To.Add("phongbui@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "This is for testing SMTP mail from GMAIL";
            System.Net.Mail.Attachment attachment;
            attachment = new Attachment(strSendFile);
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("johantesttoiec10@gmail.com", "nuocmat172");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
    }
}
