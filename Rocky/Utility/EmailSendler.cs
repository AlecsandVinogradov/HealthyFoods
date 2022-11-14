using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity.UI.Services;
using HealthyFood.Utility;

namespace HealthyFood.Utility
{
    public class EmailSendler : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public MailJetSettings _mailJetSettings { get; set; }
        public EmailSendler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }
        public async Task Execute(string email, string subject, string body)
        {
            _mailJetSettings = _configuration.GetSection("MailJet").Get<MailJetSettings>();
            MailjetClient client = new MailjetClient(_mailJetSettings.ApiKey, _mailJetSettings.SecretKey);

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From",
       new JObject {
        {"Email", "AlexandrPivovarov@proton.me"},
        {"Name", "alexandr"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
         email
         }, {
          "Name",
          "alexandr"
         }
        }
       }
      }, {
       "Subject",
      subject
      },
         {
       "HTMLPart",
       body
       }
     }
             });
            await client.PostAsync(request);
        }
    }
}
