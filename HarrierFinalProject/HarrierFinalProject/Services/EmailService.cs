using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace HarrierFinalProject.Services
{
    public interface IEmailService
    {
        void Send( string to, string subject, string html);
    }

    public class EmailService : IEmailService
    {


        public void Send(string to, string subject, string html)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ilhamcode053@gmail.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);

           
            smtp.Authenticate("ilhamcode053@gmail.com", "123456Test");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        //using (MailMessage mail = private new MailMessage())
        //   {
        //       mail.From = new MailAddress("ilhamcode053@gmail.com");


        //       mail.To.Add(to);
        //       mail.Subject = subject;
        //       mail.Body = html;
        //       mail.IsBodyHtml = true;


        //       using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
        //       {
        //           smtp.Credentials = new NetworkCredential("ilhamcode053@gmail.com", "123456Test");
        //           smtp.EnableSsl = true;
        //           smtp.Send(mail);
        //       }
        //   }


    }
}
