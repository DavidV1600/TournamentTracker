using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void SendEmail(string fromAdress, string toAdress, string subject, string body)
        {
            MailAddress fromMailAdress = new MailAddress(fromAdress, "David V");

            MailMessage mail =new MailMessage();
            mail.To.Add(toAdress);
            mail.From = fromMailAdress;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            //Have to put the user, password, host and server port (for Gmail)
            client.Send(mail);
        }
    }
}
