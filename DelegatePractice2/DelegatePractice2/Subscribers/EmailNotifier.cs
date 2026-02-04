using DelegatePractice2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatePractice2.Subscribers
{
    public class EmailNotifier
    {
        public void OnUserLogged(object sender, UserLoggedEventArgs e)
        {
            Console.WriteLine($"📧 Email sent for user {e.User.Name}");
        }
    }
}
