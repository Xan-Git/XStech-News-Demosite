using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using XStech.Models;
using MailKit.Security;


namespace XStech.Utilities
{
    public static class Contact
    {
        private const string siteEmail = "xansdevelopment@gmail.com";
        private static MailboxAddress siteMailbox = new MailboxAddress("XStech", siteEmail);

        public static async Task ReceiveContactForm(ContactForm form, IConfiguration config)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress($"{form.Name}", $"{form.Email}"));
            msg.To.Add(siteMailbox);

            msg.Subject = $"{form.Subject}";

            var plain = new TextPart("plain")
            { Text =
                @$"Hello, {form.Name},

We have received your message! Thank you for getting in touch.

-- XStech"
            };

            var html = new TextPart("html")
            { Text =
                @$"Hello, {form.Name},

This is the HTML version of this message. Thx.

-- XStech

<img src='images/EmailConfirmation.jpg'>"

                
            };
            
            var attachment = new MimePart("image", "jpeg")
            {
                Content = new MimeContent(File.OpenRead("wwwroot/images/EmailConfirmation.jpg"), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Inline),
                ContentTransferEncoding = ContentEncoding.Base64,
                
            };

            var alternative = new Multipart("alternative");
            alternative.Add(plain);
            alternative.Add(html);

            var multipart = new Multipart("mixed");
            multipart.Add(alternative);
           //  multipart.Add(attachment);
            

            msg.Body = multipart;

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(siteEmail, config["Email:AppPassword"]);
                await client.SendAsync(msg);
                await client.DisconnectAsync(true);
            }
        }
    }
}
