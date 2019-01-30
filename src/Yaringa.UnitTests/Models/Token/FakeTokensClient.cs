using System;
using System.Threading;
using System.Threading.Tasks;
using Yaringa.Models.Token;

namespace Yaringa.UnitTests.Models.Token {
    public class FakeTokensClient : ITokensClient {
        public async Task<TokenDTO> CreateAsync(TokenCreationDTO dto) {
            return new TokenDTO() {
                Access_token = "part1.part2.part3",
                Token_type = "bearer",
                Expires_in = 1799,
                Refresh_token = "1234567890",
            };
        }

        public Task<TokenDTO> CreateAsync(TokenCreationDTO dto, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public async Task<TokenDTO> RefreshAsync(TokenRefreshDTO dto) {
            return new TokenDTO() {
                Access_token = "part1.part2.part3",
                Token_type = "bearer",
                Expires_in = 1799,
                Refresh_token = "1234567890",
            };
        }

        public Task<TokenDTO> RefreshAsync(TokenRefreshDTO dto, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
