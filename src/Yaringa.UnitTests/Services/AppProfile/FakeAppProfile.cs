using System;

using Yaringa.Services;
using Yaringa.ViewModels;
using Xamarin.Forms;

namespace Yaringa.UnitTests.Services {
    public class FakeAppProfile : IAppProfile {
        public Type LoginViewModelType => typeof(LoginViewModel);

        public Type LandingViewModelType => typeof(LandingViewModel);
    }

    //Fake viewmodels.
    public class LoginViewModel : ViewModel {

    }

    public class LandingViewModel: ViewModel {

    }
}
