using Yaringa.Models.Token;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Yaringa.Services;

namespace Yaringa {
    /// <summary>
    /// Base class for client libraries.
    /// This class should be inherited by all the API client classes except the class TokensClient.
    /// The inherited class should have a constructor to assign the properties 'ContextService' and 'TokensClient'.
    /// </summary>
    public class WebApiClient {
        public WebApiClient() {
        }

        protected virtual async Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellationToken) {
            var accessToken = ContextService.AccessToken;
            if (string.IsNullOrWhiteSpace(accessToken)) {
                throw new TokenException("Unable to get local access token.");
            }

            var refreshToken = ContextService.RefreshToken;
            if (string.IsNullOrWhiteSpace(refreshToken)) {
                throw new TokenException("Unable to get local refresh token.");
            }

            var tokenExpiry = ContextService.TokenExpiryDateTime;
            var now = DateTime.Now;
            if (tokenExpiry <= now || tokenExpiry.Subtract(now).TotalMinutes < 5) {
                try {
                    TokenDTO tokenDto = await TokensClient.RefreshAsync(new TokenRefreshDTO() {
                        Client_id = "Client_id_value",
                        Grant_type = "refresh_token",
                        Refresh_token = refreshToken,
                    });
                    SaveTokenInfo(tokenDto);
                } catch (Exception ex) {
                    throw new TokenException("Unable to refresh the token", ex);
                }
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", ContextService.AccessToken);
            return client;
        }

        protected IContextService ContextService { get; set; }
        protected TokensClient TokensClient { get; set; }

        private void SaveTokenInfo(TokenDTO token) {
            TokenInfo info = TokenInfoParser.Parse(token.Access_token);
            ContextService.UserId = info.UserId;            
            ContextService.AccessToken = token.Access_token;
            ContextService.RefreshToken = token.Refresh_token;
            ContextService.TokenExpiryDateTime = DateTime.Now.AddSeconds(token.Expires_in);
        }
    }
}
