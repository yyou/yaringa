using System;
using System.Globalization;
using System.Reflection;

using TinyIoC;

using Xamarin.Forms;

using Yaringa.Models.Token;
using Yaringa.Services;

namespace Yaringa {
    public static class ViewModelLocator {
        private static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        static ViewModelLocator() {
            _container = new TinyIoCContainer();

            // Services - by default, TinyIoC will register interface registrations as singletons.
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IDialogService, DialogService>();
            _container.Register<IDependencyService, Services.DependencyService>();
            _container.Register<IApplicationStore, ApplicationStore>();
            _container.Register<IContextService, ContextService>();
            _container.Register<ITokensClient, TokensClient>();
            _container.Register<ISettingsService, SettingsService>();

            var settings = _container.Resolve<ISettingsService>();
            _container.Register(typeof(string), settings.BaseUrl);
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static void Register<T>(T obj) where T : class {
            _container.Register(obj);
        }

        public static T Resolve<T>() where T : class {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue) {
            var view = bindable as Element;
            if (view == null) {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            if (viewName.EndsWith("Page")) {
                viewName = viewName.Substring(0, viewName.Length - 4) + "ViewModel";
            }

            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null) {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
