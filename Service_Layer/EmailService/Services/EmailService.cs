using Service_Layer.EmailService.Interfaces;
using Service_Layer.EmailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.EmailService.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(EmailMessage message)
        {
            await Task.CompletedTask;
        }
    }
}
