namespace Day9ofLearning.Services
{
    public interface ICacheService
    {
        void Set(string key, string value);
    }

    public class CacheService : ICacheService
    {
        private readonly Dictionary<string, string> _cache = new();
        private readonly RequestTracker _tracker;

        public void Set(string key, string value)
        {
            _cache[key] = value;
        }
    }

}
