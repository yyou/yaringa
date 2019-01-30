using Yaringa.Services;

namespace Yaringa.UnitTests.Services {
    public class FakeDependencyService : IDependencyService {
        public T Get<T>() where T : class {
            return ViewModelLocator.Resolve<T>();
        }
    }
}
