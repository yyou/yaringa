using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Yaringa.Services;
using Yaringa.ViewModels;

namespace Yaringa.UnitTests.Services {
    public class FakeNavigationService : INavigationService {
        private List<ViewModel> _viewModels;

        public FakeNavigationService() {
            _viewModels = new List<ViewModel>();
        }

        public ViewModel PreviousPageViewModel {
            get {
                if (_viewModels.Count() < 2) {
                    return null;
                }
                return _viewModels[_viewModels.Count() - 2];
            }
        }

        public ViewModel CurrentPageViewModel {
            get {
                if (_viewModels.Count() < 1) {
                    return null;
                }
                return _viewModels[_viewModels.Count() - 1];
            }
        }

        public Task InitializeAsync() {
            throw new NotImplementedException();
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : ViewModel {
            var viewModel = ViewModelLocator.Resolve<TViewModel>();
            await viewModel.InitializeAsync(null);
            _viewModels.Add(viewModel);
        }

        public async Task NavigateToAsync<TViewModel>(Object parameter) where TViewModel : ViewModel {
            var viewModel = ViewModelLocator.Resolve<TViewModel>();
            await viewModel.InitializeAsync(parameter);
            _viewModels.Add(viewModel);
        }

        public async Task PopUpAsync() {
            if (_viewModels.Count() > 0) {
                var viewModel = _viewModels.Last();
                _viewModels.Remove(viewModel);
            }
        }

        public async Task RemoveBackStackAsync() {
            if (_viewModels.Count() > 1) {
                _viewModels = _viewModels.Skip(_viewModels.Count() - 1).ToList();
            }
        }

        public async Task RemoveLastFromBackStackAsync() {
            if (_viewModels.Count() > 1) {
                var last = _viewModels.Last();
                _viewModels = _viewModels.Take(_viewModels.Count() - 2).ToList();
                _viewModels.Add(last);
            }
        }

        public Task PopUpModalAsync() {
            throw new NotImplementedException();
        }

        public Task ShowModalAsync<TViewModel>(Object parameter) where TViewModel : ViewModel {
            throw new NotImplementedException();
        }
    }
}
