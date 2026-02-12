using Day10ofLearning.Models;
using System.Collections.Concurrent;

namespace Day10ofLearning.Services
{
    public class InMemoryIdempotencyStore : IIdempotencyStore
    {
        private readonly ConcurrentDictionary<string, IdempotencyRecord> _store = new();

        public bool TryGet(string key, out IdempotencyRecord record)
            => _store.TryGetValue(key, out record!);

        public IdempotencyRecord GetOrAdd(string key, Func<IdempotencyRecord> factory)
            => _store.GetOrAdd(key, _ => factory());
    }
}
