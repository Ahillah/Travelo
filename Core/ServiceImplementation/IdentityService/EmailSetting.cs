using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.IdentityService
{
    public static class EmailSetting
    {
        public static void SendEmail (Email email)
        {
            var Client = new SmtpClient(host: "smtp.gmail.com", port: 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential(
                userName: "ahillah871@gmail.com",
                password: "amwujhtqrnnlmwyc"
            );

            Client.Send(
                from: "ahillah871@gmail.com",
                recipients: email.To,
                subject: email.Subject,
                body: email.Body
            );

        }
    }
}
