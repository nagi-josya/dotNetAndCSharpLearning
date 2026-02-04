using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatePractice2.Domain
{
    public class User
    {
        public int Id { get; }
        public string Name { get;}
        public string Role { get; }

        public User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
    }
}
