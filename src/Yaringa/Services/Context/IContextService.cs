using System;

namespace Yaringa.Services {
    public interface IContextService {
        long UserId { get; set; }
        string AccessToken { get; set; }
        string RefreshToken { get; set; }

        /// <summary>
        /// Expiry datetime of access token. 
        /// The initial value of this property is the calculation result
        /// from current datetime (local datetime) plus the seconds in 'expiry_in' from the
        /// result of calling api 'api/token'.
        /// </summary>
        DateTime TokenExpiryDateTime { get; set; }
    }
}
