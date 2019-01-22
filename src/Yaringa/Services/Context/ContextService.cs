using System;

namespace Yaringa.Services {
    public class ContextService : IContextService {
        private IApplicationStore _applicationStore;

        public ContextService(IApplicationStore applicationStore) {
            _applicationStore = applicationStore;
        }

        public long UserId {
            get => _applicationStore.GetValueOrDefault<long>(nameof(UserId));
            set => _applicationStore.AddOrUpdateValue(nameof(UserId), value);
        }

        public string AccessToken {
            get => _applicationStore.GetValueOrDefault<string>(nameof(AccessToken));
            set => _applicationStore.AddOrUpdateValue(nameof(AccessToken), value);
        }

        public string RefreshToken {
            get => _applicationStore.GetValueOrDefault<String>(nameof(RefreshToken));
            set => _applicationStore.AddOrUpdateValue(nameof(RefreshToken), value);
        }

        public DateTime TokenExpiryDateTime {
            get => _applicationStore.GetValueOrDefault<DateTime>(nameof(TokenExpiryDateTime));
            set => _applicationStore.AddOrUpdateValue(nameof(TokenExpiryDateTime), value);
        }
    }
}
