using System.Collections.Generic;

namespace Wpb.CarsRating.Core.ContextObjects
{
    public class ContextInitializer
    {
        private readonly Dictionary<string, object> _context;

        public ContextInitializer()
        {
            _context = new Dictionary<string, object>();
        }

        public T Get<T>()
        {
            var key = typeof(T).Name;

            if (!_context.ContainsKey(key))
            {
                _context[key] = typeof(T).GetConstructors()[0].Invoke(null);
            }
            return (T)_context[key];
        }
    }
}
