using Microsoft.Extensions.Configuration;
using SV.Business.Interfaces;
using SV.Models.Entities;
using SV.Models.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace SV.WebApp.Services
{
    public class EmailService
    {
        private EmailModel EmailModel;

        public EmailService(IConfiguration configuration, IRepository<EmailTemplate> emailTempRepository)
        {
            EmailModel = new EmailModel();
            configuration.GetSection("EmailSetting").Bind(EmailModel);

            var emailTemp = emailTempRepository.GetByID(1);
            EmailModel.DisplayName = emailTemp.SenderName;
            EmailModel.Subject = emailTemp.Subject;
            EmailModel.Body = emailTemp.Body;
        }

        public bool Send(MailAddress toMailAddress, string surl)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(EmailModel.FromEmailAddres, EmailModel.DisplayName);
                message.To.Add(toMailAddress);
                message.Subject = ReplaceTags(EmailModel.Subject, toMailAddress.DisplayName, surl);
                message.IsBodyHtml = true;  
                message.Body = ReplaceTags(EmailModel.Body, toMailAddress.DisplayName, surl);
                smtp.Port = EmailModel.Port;
                smtp.Host = EmailModel.Host; 
                smtp.EnableSsl = EmailModel.EnableSsl;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(EmailModel.Username, EmailModel.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                
                return true;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public bool SendWithSMTP(MailAddress toMailAddress, string surl)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(EmailModel.FromEmailAddres);
                message.To.Add(toMailAddress);
                message.Subject = ReplaceTags(EmailModel.Subject, toMailAddress.DisplayName, surl);
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = ReplaceTags(EmailModel.Body, toMailAddress.DisplayName, surl);
                smtp.Port = EmailModel.Port;
                smtp.Host = EmailModel.Host;
                smtp.EnableSsl = EmailModel.EnableSsl;
                smtp.UseDefaultCredentials = true;

                //smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

                return true;
        }
            catch (Exception ex) 
            { 
                throw ex; 
            }
}

        private string ReplaceTags(string text, string name, string surl)
        {
            text = text.Replace("#Name", name);
            text = text.Replace("#surl", surl);

            return text;
        }
    }
}
