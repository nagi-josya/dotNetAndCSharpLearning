using Day6ofLearning.Abstractions;
using Day6ofLearning.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day6ofLearning.Infrastructure
{
    public class EntityWriteRepository : IWriteRepository<Entity>
    {
        public void Save(Entity entity)
            => Console.WriteLine($"Saved entity with ID {entity.Id}");
    }
}
