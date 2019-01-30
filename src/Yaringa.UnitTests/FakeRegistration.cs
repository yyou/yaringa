using Xamarin.Forms;
using Xamarin.Forms.Mocks;

using Yaringa.Models.Token;
using Yaringa.Services;
using Yaringa.UnitTests.Models.Token;
using Yaringa.UnitTests.Services;

namespace Yaringa.UnitTests {
    public static class FakeRegistration {
        
        //Register default fake implementations for common services.
        public static void Register() {
            MockForms.Init();

            ViewModelLocator.RegisterSingleton<IContextService, FakeContextService>();
            ViewModelLocator.RegisterSingleton<IAppStore, FakeAppStore>();
            ViewModelLocator.RegisterSingleton<IAppProfile, FakeAppProfile>();
            ViewModelLocator.RegisterSingleton<INavigationService, FakeNavigationService>();
            ViewModelLocator.RegisterSingleton<IDialogService, FakeDialogService>();
            ViewModelLocator.RegisterSingleton<IDependencyService, FakeDependencyService>();
            ViewModelLocator.RegisterSingleton<ISettingsService, FakeSettingsService>();
            ViewModelLocator.RegisterSingleton<ITokensClient, FakeTokensClient>();

            Application.Current = new Application();
        }
    }
}
