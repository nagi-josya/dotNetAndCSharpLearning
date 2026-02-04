using DelegatePractice2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatePractice2.Subscribers
{
    public class SecurityMonitor
    {
        public void OnUserLogged(object sender, UserLoggedEventArgs e)
        {
            Console.WriteLine($"📧 Security monitor for user {e.User.Name}");
        }
    }
}
