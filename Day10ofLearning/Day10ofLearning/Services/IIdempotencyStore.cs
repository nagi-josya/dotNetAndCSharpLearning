using Day10ofLearning.Models;

namespace Day10ofLearning.Services
{
    public interface IIdempotencyStore
    {
        bool TryGet(string key, out IdempotencyRecord record);
        IdempotencyRecord GetOrAdd(string key, Func<IdempotencyRecord> factory);
    }
}
