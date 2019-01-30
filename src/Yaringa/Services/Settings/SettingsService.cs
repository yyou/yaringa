using System;

namespace Yaringa.Services {
    public class SettingsService : ISettingsService {
        public SettingsService(IAppStore appStore) {
            _appStore = appStore;
        }

        public String BaseUrl {
            get {
                return _appStore.GetValueOrDefault<String>(nameof(BaseUrl));
            }
            set {
                _appStore.AddOrUpdateValue(nameof(BaseUrl), value);
            }
        }

        private IAppStore _appStore;
    }
}
