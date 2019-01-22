using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yaringa.Services {
    public interface IDialogService {
        Task ShowAlertAsync(string message, string title = "", string buttonLabel = "");
        void ShowLoading(string title);
        void HideLoading(string title);
        Task<Boolean> ConfirmAsync(String message, String title = null, String okText = null, String cancelText = null, CancellationToken? cancelToken = null);
    }
}
