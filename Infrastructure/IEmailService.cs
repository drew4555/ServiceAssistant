using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }  
}