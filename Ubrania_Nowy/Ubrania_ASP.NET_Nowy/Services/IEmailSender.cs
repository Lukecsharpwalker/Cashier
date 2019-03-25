using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ubrania_ASP.NET_Nowy.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
