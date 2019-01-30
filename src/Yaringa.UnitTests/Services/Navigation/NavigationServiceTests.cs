using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yaringa.Services;
using Xamarin.Forms;

namespace Yaringa.UnitTests.Services {
    [TestClass]
    public class NavigationServiceTests : ServiceTests<NavigationService> {
        [TestMethod]
        public async Task PreviousPageViewModel_LessThan2PageInNavigationStack_ReturnsNull() {
            await Service.NavigateToAsync<LoginViewModel>();
            Assert.IsNull(Service.PreviousPageViewModel);
        }

        [TestMethod]
        public async Task PreviousPageViewModel_2PageInNavigationStack_ReturnsBottomPage() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.NavigateToAsync<LandingViewModel>();
            Assert.AreEqual(typeof(LoginViewModel), Service.PreviousPageViewModel.GetType());
        }

        [TestMethod]
        public void CurrentPageViewModel_LessThan1PageInNavigationStack_ReturnsNull() {
            Assert.IsNull(Service.CurrentPageViewModel);
        }

        [TestMethod]
        public async Task CurrentPageViewModel_OnePageInNavigationStack_ReturnsThatPagesViewModel() {
            await Service.NavigateToAsync<LoginViewModel>();
            Assert.AreEqual(typeof(LoginViewModel), Service.CurrentPageViewModel.GetType());
        }

        [TestMethod]
        public async Task CurrentPageViewModel_MoreThanOnePageInNavigationStack_ReturnsTopPagesViewModel() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.NavigateToAsync<LandingViewModel>();
            Assert.AreEqual(typeof(LandingViewModel), Service.CurrentPageViewModel.GetType());
        }

        [TestMethod]
        public async Task NavigateToAsync_NavigateToLoginPage_CanNavigateToLoginPage() {
            await Service.NavigateToAsync<LoginViewModel>();

            Assert.AreEqual(1, Application.Current.MainPage.Navigation.NavigationStack.Count);
            Assert.AreEqual(typeof(LoginViewModel), Service.CurrentPageViewModel.GetType());
        }

        [TestMethod]
        public async Task NavigateToAsync_NavigateToOtherPage_CanNavigateToPage() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.NavigateToAsync<LandingViewModel>();

            Assert.AreEqual(2, Application.Current.MainPage.Navigation.NavigationStack.Count);
            Assert.AreEqual(typeof(LandingViewModel), Service.CurrentPageViewModel.GetType());
        }

        [TestMethod]
        public async Task RemoveLastFromBackStackAsync_WithoutPageInNavigationStack_DoNothing() {
            await Service.RemoveLastFromBackStackAsync();
            Assert.IsNull(Service.CurrentPageViewModel);
        }

        [TestMethod]
        public async Task RemoveLastFromBackStackAsync_WithOnePageInNavigationStack_DoNothing() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.RemoveLastFromBackStackAsync();

            Assert.AreEqual(1, Application.Current.MainPage.Navigation.NavigationStack.Count);
            Assert.AreEqual(typeof(LoginViewModel), Service.CurrentPageViewModel.GetType());
        }

        [TestMethod]
        public async Task RemoveLastFromBackStackAsync_With2PagesInNavigationStack_CanRemovePreviousPage() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.NavigateToAsync<LandingViewModel>();
            await Service.RemoveLastFromBackStackAsync();

            Assert.AreEqual(1, Application.Current.MainPage.Navigation.NavigationStack.Count);
            Assert.AreEqual(typeof(LandingViewModel), Service.CurrentPageViewModel.GetType());
        }

        [TestMethod]
        public async Task RemoveBackStackAsync_WithoutPageInNavigationStack_DoNothing() {
            await Service.RemoveBackStackAsync();
            Assert.IsNull(Service.CurrentPageViewModel);
        }

        [TestMethod]
        public async Task RemoveBackStackAsync_WithOnePageInNavigationStack_DoNothing() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.RemoveBackStackAsync();

            Assert.AreEqual(1, Application.Current.MainPage.Navigation.NavigationStack.Count);
            Assert.AreEqual(typeof(LoginViewModel), Service.CurrentPageViewModel.GetType());
        }

        [TestMethod]
        public async Task RemoveBackStackAsync_MoreThanOnePageInNavigationStack_RemoveAllBottomPages() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.NavigateToAsync<LandingViewModel>();
            await Service.RemoveBackStackAsync();

            Assert.AreEqual(1, Application.Current.MainPage.Navigation.NavigationStack.Count);
            Assert.AreEqual(typeof(LandingViewModel), Service.CurrentPageViewModel.GetType());
        }

        [TestMethod]
        public async Task PopUpAsync_WithoutPageInNavigationStack_DoNothing() {
            await Service.PopUpAsync();

            Assert.IsNull(Service.CurrentPageViewModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task PopUpAsync_WithOnePageInNavigationStack_ThrowException() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.PopUpAsync();
        }

        [TestMethod]
        public async Task PopUpAsync_WithMoreThanOnePageInNavigationStack_PopUpTheTopPage() {
            await Service.NavigateToAsync<LoginViewModel>();
            await Service.NavigateToAsync<LandingViewModel>();
            await Service.PopUpAsync();

            Assert.AreEqual(1, Application.Current.MainPage.Navigation.NavigationStack.Count);
            Assert.AreEqual(typeof(LoginViewModel), Service.CurrentPageViewModel.GetType());
        }

        protected override async Task<NavigationService> CreateServiceAsync() {
            var contextService = ViewModelLocator.Resolve<IContextService>();
            var appProfile = ViewModelLocator.Resolve<IAppProfile>();
            var service = new NavigationService(contextService, appProfile);
            return service;
        }
    }
}
