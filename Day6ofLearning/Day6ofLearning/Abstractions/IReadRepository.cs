using Day6ofLearning.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day6ofLearning.Abstractions
{
    public interface IReadRepository<out T>
     where T : Entity
    {
        T GetById(int id);
    }
}
