using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Model
{
   public class MsmqModel
   {
        MessageQueue messageQueue = new MessageQueue();
        public void Sender(string token)
        {
            messageQueue.Path = @".\private$\Tokens";
            try
            {
                //checking path exist or not
                if (!MessageQueue.Exists(messageQueue.Path))
                {
                    //path is not there then create path
                    MessageQueue.Create(messageQueue.Path);
                }
                //Delegates for sending email
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
                messageQueue.Send(token);
                messageQueue.BeginReceive();
                messageQueue.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var message = messageQueue.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("usagu2020@gmail.com", "Saguna@123")
                };
                mailMessage.From = new MailAddress("usagu2020@gmail.com");
                mailMessage.To.Add(new MailAddress("usagu2020@gmail.com"));
                mailMessage.Body = token;
                mailMessage.Subject = "Forget Password link";
                smtpClient.Send(mailMessage);
            }
            catch (Exception)
            {
                messageQueue.BeginReceive();
            }
        }
    }
}
