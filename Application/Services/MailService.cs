using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class MailService :  IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string text, string from = null)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _configuration["Mail:Email"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Plain) { Text = text };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["Mail:Host"], Int32.Parse(_configuration["Mail:Port"]), SecureSocketOptions.Auto);
            smtp.Authenticate(_configuration["Mail:Email"], _configuration["Mail:Password"]);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
