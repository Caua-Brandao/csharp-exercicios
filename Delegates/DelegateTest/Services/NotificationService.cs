using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest.Services
{
    static class NotificationService
    {
        static public void LogToConsole(string message)
        {
            Console.WriteLine("[LOG] " + message);
        }

        static public void SendEMail(string message)
        {
            Console.WriteLine("[EMAIL] " + message);
        }

        static public void SendSms(string message)
        {
            Console.WriteLine("[SMS] " + message);
        }
    }
}
