using Day6ofLearning.Abstractions;
using Day6ofLearning.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day6ofLearning.Infrastructure
{
    public class UserReadRepository : IReadRepository<User>
    {
        public User GetById(int id)
            => new User { Id = id, Name = "John Doe" };
    }
}
