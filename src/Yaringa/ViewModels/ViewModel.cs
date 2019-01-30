using System;
using System.Threading.Tasks;

using Yaringa.Services;

namespace Yaringa.ViewModels {
    /// <summary>
    /// Base class for all view models.
    /// </summary>
    public abstract class ViewModel : ExtendedBindableObject {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public ViewModel() {
            DialogService = ViewModelLocator.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
        }

        /// <summary>
        /// Initialize with data which may be from remote server side and subscribe messages from messaging center.
        /// This method is used by NavigationService and unit testing code.
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public virtual Task InitializeAsync(object navigationData) {
            return Task.FromResult(false);
        }

        /// <summary>
        /// Clean up the resources that is linked to this view model.
        /// For now, it's for unsubscribing the messages from messaging center.
        /// This method is used by NavigationService and unit testing code.
        /// </summary>
        public virtual Task CleanUpAsync() {
            return Task.FromResult(false);
        }

        /// <summary>
        /// This method provides a wrapper for any method which takes one parameter without return-type AND
        /// is going to be called in a command. 
        /// It shows loading icon when starting internal method and hide the loading icon when finished.
        /// </summary>
        /// <param name="func">The function / method that is going to be called in this method.</param>
        /// <param name="messageSettings">Error message box settings</param>
        /// <returns></returns>
        protected virtual async Task InvokeAsync<T>(Func<T, Task> func, T arg, InvokingSettings messageSettings = null) {
            var fn2 = new Func<Task>(async () => {
                await func(arg);
            });

            await InvokeAsync(fn2, messageSettings);
        }

        /// <summary>
        /// This method provides a wrapper for any method which takes no parameters without return type AND
        /// is going to be called in a command. 
        /// </summary>
        /// <param name="func">The function / method that is going to be called in this method.</param>
        /// <param name="invokingSettings">Settings for invoking</param>
        /// <returns></returns>
        protected virtual async Task InvokeAsync(Func<Task> func, InvokingSettings invokingSettings = null) {
            InvokingSettings settings = invokingSettings ?? new InvokingSettings();
            try {
                if (settings.Confirmation != null) {
                    var confirmation = settings.Confirmation;
                    var result = await DialogService.ConfirmAsync(
                        confirmation.Message, confirmation.Title,
                        confirmation.OkButtonLabel, confirmation.CancelButtonLabel,
                        confirmation.CancellationToken);
                    if (result == false) {
                        return;
                    }
                }

                DialogService.ShowLoading(settings.BusyMessage);
                await func();
                DialogService.HideLoading(settings.BusyMessage);

                if (settings.Info != null) {
                    var info = settings.Info;
                    await DialogService.ShowAlertAsync(
                        info.Message, info.Title, info.ButtonLabel);
                }

                if (settings.Callback != null) {
                    await settings.Callback();
                }
            } catch (Exception) {
                DialogService.HideLoading(settings.BusyMessage);
                throw;
            }
        }        
    }
}
