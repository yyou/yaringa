using System;

namespace Yaringa.Services {
    public class SettingsService : ISettingsService {
        public SettingsService(IApplicationStore applicationStore) {
            _applicationStore = applicationStore;
        }

        public String BaseUrl {
            get {
                return _applicationStore.GetValueOrDefault<String>(nameof(BaseUrl));
            }
            set {
                _applicationStore.AddOrUpdateValue(nameof(BaseUrl), value);
            }
        }

        private IApplicationStore _applicationStore;
    }
}
