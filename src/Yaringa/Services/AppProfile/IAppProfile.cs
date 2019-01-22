using System;
using System.Collections.Generic;
using System.Text;

namespace Yaringa.Services
{
    /// <summary>
    /// Interface to provide information about the actual view model in the app.
    /// The implementation of this interface will be in the mobile app project.
    /// </summary>
    public interface IAppProfile {
        Type LoginViewModelType { get; }
        Type LandingViewModelType { get; }
    }
}
