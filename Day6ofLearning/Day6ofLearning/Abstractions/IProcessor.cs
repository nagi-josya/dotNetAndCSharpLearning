using System;
using System.Collections.Generic;
using System.Text;

namespace Day6ofLearning.Abstractions
{
    public interface IProcessor<in T>
    {
        void Process(T item);
    }
}
