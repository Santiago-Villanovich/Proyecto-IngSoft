using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Services
{
    public class MailProvider
    {
        public string sendMail(List<string> to, string asunto, string body)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "santiagovillanovich@yahoo.com"; //mi mail
            string displayName = "GoComp"; //Nombre que se muestra en el mail
            try
            {
                SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
                client.Credentials = new NetworkCredential(from, "sa7918vi"); //tu contrasenia
                client.EnableSsl = true; //En caso de que tu servidor de correo no utilice cifrado SSL,poner en false


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                foreach (var item in to)
                {
                    mail.To.Add(item.Trim()); //destinatario
                }
                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;

                client.Send(mail);
                msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            }

            return msge;
        }
    }
}
