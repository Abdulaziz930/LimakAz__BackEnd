using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Utils;

namespace EduHome.Areas.AdminPanel.Utils
{
    public static class EmailUtil
    {
        public static async Task SendEmailAsync(string email, string body, string subject)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(Constants.EmailAdress);

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential network = new NetworkCredential(Constants.EmailAdress, Constants.EmailPassword);
                    smtp.Credentials = network;
                    smtp.Port = 587;
                    try
                    {
                        await smtp.SendMailAsync(mail);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }
    }
}
