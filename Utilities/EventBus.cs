using System;
using System.Collections.Concurrent;

namespace Social_Sports_Hub.Utilities
{
    // Minimal pub/sub so teammate code that calls EventBus.Publish/Subscribe compiles.
    public static class EventBus
    {
        private static readonly ConcurrentDictionary<string, ConcurrentBag<Action<object?>>> _routes
            = new();

        public static void Subscribe(string topic, Action<object?> handler)
        {
            var bag = _routes.GetOrAdd(topic, _ => new ConcurrentBag<Action<object?>>());
            bag.Add(handler);
        }

        public static void Publish(string topic, object? payload = null)
        {
            if (!_routes.TryGetValue(topic, out var bag)) return;
            foreach (var handler in bag)
                handler(payload);
        }
    }
}
