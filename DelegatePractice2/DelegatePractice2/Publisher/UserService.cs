using DelegatePractice2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatePractice2.Publisher
{
    public class UserService
    {
        public event EventHandler<UserLoggedEventArgs> UserLoggedIn;

        public void UserLogged(User user)
        {
            Console.WriteLine($"User - {user.Name} Logged In");

            UserLoggedIn?.Invoke(this, new UserLoggedEventArgs(user));
        }
    }
}
