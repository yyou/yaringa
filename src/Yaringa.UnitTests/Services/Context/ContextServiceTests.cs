using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using Yaringa.Services;

namespace Yaringa.UnitTests.Services {
    [TestClass]
    public class ContextServiceTests {
        [TestInitialize]
        public void Initialize() {
            Service = CreateService();
        }

        [TestMethod]
        public void UserId_CanSaveAndRetrieveValue() {
            Service.UserId = 123;
            Assert.AreEqual(123, Service.UserId);
        }

        [TestMethod]
        public void UserId_DefaultValue() {
            Assert.AreEqual(0, Service.UserId);
        }

        [TestMethod]
        public void AccessToken_CanSaveAndRetrieveValue() {
            Service.AccessToken = "any text";
            Assert.AreEqual("any text", Service.AccessToken);
        }

        [TestMethod]
        public void AccessToken_DefaultValue() {
            Assert.IsNull(Service.AccessToken);
        }

        [TestMethod]
        public void RefreshToken_CanSaveAndRetrieveValue() {
            Service.RefreshToken = "any text";
            Assert.AreEqual("any text", Service.RefreshToken);
        }

        [TestMethod]
        public void RefreshToken_DefaultValue() {
            Assert.IsNull(Service.RefreshToken);
        }

        [TestMethod]
        public void TokenExpiryDateTime_CanSaveAndRetrieveValue() {
            Service.TokenExpiryDateTime = new DateTime(2019, 1, 1);
            Assert.AreEqual(new DateTime(2019, 1, 1), Service.TokenExpiryDateTime);
        }

        private ContextService CreateService() {
            var settingsService = new FakeAppStore();
            return new ContextService(settingsService);
        }

        protected ContextService Service;
    }
}
