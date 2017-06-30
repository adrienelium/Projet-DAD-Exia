using System;
using System.Net;
using System.Net.Mail;

namespace FrontWcfService.App_Code
{
    public class MailManager
    {
        private static MailManager instance;

        private MailAddress fromAddress;
        private MailAddress toAddress;

        

        public static MailManager getInstance()
        {
            if (instance == null)
            {
                instance = new MailManager();
            }
            return instance;
        }

        private MailManager()
        {
            fromAddress = new MailAddress("meltzer.adrien@gmail.com", "DAD System");           
        }

        public void sendEmailResult(string username_destinataire)
        {
            toAddress = new MailAddress(getAdresseMail(username_destinataire), "To Name");
            const string fromp = "vicefoufoune66";
            const string subject = "DAD Manager : Un résultat a été trouvé.";
            const string body = "Veuillez vous connectez, le résultat pour votre demande de Bruteforce a été trouvé";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromp)
            };

            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

            smtp.Send(message);
        }

        private string getAdresseMail(string username)
        {
            ModelUser userModel = new ModelUser();
            return userModel.getMailByUsername(username);
        }
    }
}