using Yaringa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yaringa.Services {
    public interface INavigationService {
        /// <summary>
        /// The ViewModel of the second top page in the page stack.
        /// </summary>
        ViewModel PreviousPageViewModel { get; }

        /// <summary>
        /// The ViewModel of the top page in the page stack.
        /// </summary>
        ViewModel CurrentPageViewModel { get; }

        Task InitializeAsync();
            

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModel;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();

        Task PopUp();

        Task ShowModalAsync<TViewModel>(object parameter) where TViewModel : ViewModel;

        Task PopUpModalAsync();
    }
}
