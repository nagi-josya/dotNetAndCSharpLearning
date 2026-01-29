using Day6ofLearning.Abstractions;
using Day6ofLearning.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day6ofLearning.Processors
{
    public class EntityLogger : IProcessor<Entity>
    {
        public void Process(Entity item)
            => Console.WriteLine($"Processing entity {item.Id}");
    }
}
