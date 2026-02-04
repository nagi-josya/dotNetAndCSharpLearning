using DelegatePractice2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatePractice2.Subscribers
{
    public class AuditLogger
    {
        public void OnUserLogged(object sender, UserLoggedEventArgs e)
        {
            Console.WriteLine($"📧 Audit log for user {e.User.Name}");
        }
    }
}
