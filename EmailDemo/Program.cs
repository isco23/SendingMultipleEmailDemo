using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Send();
            Console.ReadLine();
        }

        public static void Send()
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("zarni.galaxysoftware@gmail.com");
            string ccMailList = "zarniaung.al@gmail.com,stylemen.7@gmail.com";
            string[] ccMail = ccMailList.Split(',');
            foreach (var item in ccMail)
            {
                msg.CC.Add(new MailAddress(item));                
            }

            string bccMailList = "zarniaung.al23@gmail.com";
            string[] bccMail = bccMailList.Split(',');
            foreach (var item in bccMail)
            {
                msg.Bcc.Add(new MailAddress(item));
            }

            msg.Subject = "Hello";
            msg.Body = "Welcome";
            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "zarni.galaxysoftware@gmail.com"; 
            ntwd.Password = "Hades.al23";   
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.DeliveryMethod = SmtpDeliveryMethod.Network;
            smt.Send(msg);
        }
    }
}
