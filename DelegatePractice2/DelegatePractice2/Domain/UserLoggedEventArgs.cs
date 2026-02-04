using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatePractice2.Domain
{
    public class UserLoggedEventArgs: EventArgs
    {
        public User User { get; }

        public UserLoggedEventArgs(User user)
        {
            User = user;
        }
    }
}
