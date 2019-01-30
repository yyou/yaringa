using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading.Tasks;

namespace Yaringa.UnitTests {
    /// <summary>
    /// This class provides common functions for testing service class.
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    [TestClass]
    public abstract class ServiceTests<TService> {
        [TestInitialize]
        public async Task InitializeAsync() {
            FakeRegistration.Register();
            Service = await CreateServiceAsync();
        }

        /// <summary>
        /// This method is for derived class to implement to create a service object.
        /// </summary>
        /// <returns></returns>
        protected abstract Task<TService> CreateServiceAsync();

        /// <summary>
        /// The service object being tested.
        /// </summary>
        protected TService Service;
    }
}
