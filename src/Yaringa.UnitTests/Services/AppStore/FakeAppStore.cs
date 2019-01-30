using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yaringa.Services;

namespace Yaringa.UnitTests.Services {
    public class FakeAppStore : IAppStore {
        public Task AddOrUpdateValue<T>(String key, T value) {
            _dict[key] = value;
            return Task.FromResult(true);
        }

        public T GetValueOrDefault<T>(String key, T defaultValue = default(T)) {
            if (_dict.ContainsKey(key)) {
                return (T)_dict[key];
            } else {
                return defaultValue;
            }
        }

        private Dictionary<string, object> _dict = new Dictionary<string, object>();
    }
}
