using Day6ofLearning.Abstractions;
using Day6ofLearning.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day6ofLearning.Services
{
    public class GenericService<T>
    where T : Entity
    {
        private readonly IReadRepository<T> _reader;
        private readonly IWriteRepository<T> _writer;
        private readonly IProcessor<T> _processor;

        public GenericService(
            IReadRepository<T> reader,
            IWriteRepository<T> writer,
            IProcessor<T> processor)
        {
            _reader = reader;
            _writer = writer;
            _processor = processor;
        }

        public void Execute(int id)
        {
            var item = _reader.GetById(id);
            _processor.Process(item);
            _writer.Save(item);
        }
    }
}
