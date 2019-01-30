using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using System;
using System.Threading;
using System.Threading.Tasks;

using Yaringa.Services;
using Yaringa.ViewModels;

namespace Yaringa.UnitTests.ViewModels {
    [TestClass]
    public class ViewModelTests {
        [TestInitialize]
        public void Initialize() {
            FakeRegistration.Register();
            SetupCustomMocks();

            _viewModel = new DerivedViewModel();
        }

        [TestMethod]
        public async Task InvokeAsync_WithConfirmationRequired_ShowConfirmationMessageBox() {
            await _viewModel.InvokeAsync(
                async () => { },
                new InvokingSettings() {
                    Confirmation = new ConfirmationMessageSettings() { }
                }
            );

            _dialogServiceMock.Verify(
                dialog => dialog.ConfirmAsync(
                    It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken?>()),
                Times.Once);
        }

        [TestMethod]
        public async Task InvokeAsync_Executed_ShowBusyMessage() {
            await _viewModel.InvokeAsync(async () => { });

            _dialogServiceMock.Verify(
                dialog => dialog.ShowLoading(It.IsAny<string>()),
                Times.Once);
        }

        private void SetupCustomMocks() {
            var mock = new Mock<IDialogService>();
            mock.Setup(
                dialog => dialog.ConfirmAsync(
                    It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken?>()))
                .Returns(Task.FromResult(true));

            mock.Setup(dialog => dialog.ShowLoading(It.IsAny<string>()));
            mock.Setup(dialog => dialog.HideLoading(It.IsAny<string>()));
            mock.Setup(dialog => dialog.ShowAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            ViewModelLocator.Register(mock.Object);
            _dialogServiceMock = mock;
        }

        private Mock<IDialogService> _dialogServiceMock;

        private DerivedViewModel _viewModel;
    }

    public class DerivedViewModel : ViewModel {
        public new async Task InvokeAsync(Func<Task> func, InvokingSettings invokingSettings = null) =>
            await base.InvokeAsync(func, invokingSettings);
    }
}
