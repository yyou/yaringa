using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Yaringa.Services;

namespace Yaringa.UnitTests.Services {
    public class FakeDialogService : IDialogService {
        public async Task<Boolean> ConfirmAsync(
            String message, String title = null, String okText = null, 
            String cancelText = null, CancellationToken? cancelToken = null) {

            return true;
        }

        public async Task ShowAlertAsync(String message, String title = "", String buttonLabel = "") {
            Debug.WriteLine(title + ": " + message);
        }

        public void ShowLoading(String title) {
            Debug.WriteLine(title);
        }

        public void HideLoading(String title) {

        }
    }
}
