using Day6ofLearning.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day6ofLearning.Abstractions
{
    public interface IWriteRepository<in T>
    where T : Entity
    {
        void Save(T entity);
    }
}
