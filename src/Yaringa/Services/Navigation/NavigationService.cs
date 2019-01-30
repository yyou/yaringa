using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Xamarin.Forms;

using Yaringa.ViewModels;

namespace Yaringa.Services {
    public class NavigationService : INavigationService {
        private readonly IContextService _contextService;
        private readonly IAppProfile _appProfile;

        public ViewModel PreviousPageViewModel {
            get {
                var mainPage = Application.Current.MainPage as CustomNavigationView;
                if (mainPage == null) {
                    return null;
                }
                var stack = mainPage.Navigation.NavigationStack;
                if (stack.Count() < 2) {
                    return null;
                }
                var viewModel = stack[stack.Count() - 2].BindingContext;
                return viewModel as ViewModel;
            }
        }

        public ViewModel CurrentPageViewModel {
            get {
                var mainPage = Application.Current.MainPage as CustomNavigationView;
                if (mainPage == null) {
                    return null;
                }
                var stack = mainPage.Navigation.NavigationStack;
                if (stack.Count() < 1) {
                    return null;
                }
                var viewModel = stack.Last().BindingContext;
                return viewModel as ViewModel;
            }
        }

        public NavigationService(IContextService contextService, IAppProfile appProfile) {
            _contextService = contextService;
            _appProfile = appProfile;
        }

        public Task InitializeAsync() {
            if (string.IsNullOrEmpty(_contextService.AccessToken))
                return InternalNavigateToAsync(_appProfile.LoginViewModelType, null);
            else
                return InternalNavigateToAsync(_appProfile.LandingViewModelType, null);
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : ViewModel {
            await InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public async Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModel {
            await InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        /// <summary>
        /// Remove the second top page in the navigation stack.
        /// </summary>
        /// <returns></returns>
        public async Task RemoveLastFromBackStackAsync() {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null && mainPage.Navigation.NavigationStack.Count > 1) {
                var stack = mainPage.Navigation.NavigationStack;
                var page = stack[stack.Count - 2];
                mainPage.Navigation.RemovePage(page);

                var viewModel = page.BindingContext as ViewModel;
                await viewModel.CleanUpAsync();
            }
        }

        /// <summary>
        /// Remove all the pages in the navigation stack except the top one.
        /// </summary>
        /// <returns></returns>
        public async Task RemoveBackStackAsync() {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null) {
                var stack = mainPage.Navigation.NavigationStack;
                for (int i = stack.Count - 2; i >= 0; i--) {
                    var page = stack[i];
                    mainPage.Navigation.RemovePage(page);

                    var viewModel = page.BindingContext as ViewModel;
                    await viewModel.CleanUpAsync();
                }
            }
        }

        public async Task PopUpAsync() {
            var mainPage = Application.Current.MainPage as CustomNavigationView;
            if (mainPage != null) {
                var stack = mainPage.Navigation.NavigationStack;
                if (stack.Count < 1) {
                    return;
                }
                var lastPage = stack[stack.Count - 1];
                mainPage.Navigation.RemovePage(lastPage);

                var viewModel = lastPage.BindingContext as ViewModel;
                await viewModel.CleanUpAsync();
            }
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter) {
            Page page = CreatePage(viewModelType, parameter);

            if (viewModelType == _appProfile.LoginViewModelType) {
                Application.Current.MainPage = new CustomNavigationView(page);
            } else {
                var navigationPage = Application.Current.MainPage as CustomNavigationView;
                if (navigationPage != null) {
                    await navigationPage.PushAsync(page, false);
                } else {
                    Application.Current.MainPage = new CustomNavigationView(page);
                }
            }

            await (page.BindingContext as ViewModel).InitializeAsync(parameter);
        }

        //Get view type based on viewmodel type.
        //view naming convention: XxxPage
        //view model naming convention: XxxViewModel
        private Type GetPageTypeForViewModel(Type viewModelType) {
            var fullName = viewModelType.FullName;
            var index = fullName.LastIndexOf('.');

            var ns = fullName.Substring(0, index);
            ns = ns.Replace("Model", string.Empty);

            var className = fullName.Substring(index + 1);
            className = className.Replace("ViewModel", "Page");

            var viewName = ns + "." + className;

            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(
                CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter) {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null) {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            //try-catch is for debugging only.
            try {
                Page page = Activator.CreateInstance(pageType) as Page;
                return page;
            } catch (Exception ex) {
                var s = ex.Message;
                throw;
            }
        }

        public async Task ShowModalAsync<TViewModel>(object parameter) where TViewModel : ViewModel {
            await InternalShowModalAsync(typeof(TViewModel), parameter);
        }

        private async Task InternalShowModalAsync(Type viewModelType, object parameter) {
            Page page = CreatePage(viewModelType, parameter);
            var popUpPage = (PopupPage)page;
            if (popUpPage == null) {
                throw new InvalidCastException(
                    $"Please implement page {page.GetType()} with Rg.Plugins.Popup.Pages.PopUpPage.");
            }
            await PopupNavigation.Instance.PushAsync(popUpPage, false);
            await (page.BindingContext as ViewModel).InitializeAsync(parameter);
        }

        public async Task PopUpModalAsync() {
            await PopupNavigation.Instance.PopAsync(false);
        }
    }
}
