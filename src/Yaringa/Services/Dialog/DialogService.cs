using Acr.UserDialogs;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yaringa.Services {
    public class DialogService : IDialogService {
        public Task ShowAlertAsync(string message, string title, string buttonLabel) {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public void ShowLoading(string title) {
            UserDialogs.Instance.Loading(title).Show();
        }

        public void HideLoading(string title) {
            UserDialogs.Instance.Loading(title).Hide();
        }

        public async Task<Boolean> ConfirmAsync(String message, String title = null,
            String okText = null, String cancelText = null, CancellationToken? cancelToken = null) {
            return await UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText, cancelToken);
        }
    }
}
