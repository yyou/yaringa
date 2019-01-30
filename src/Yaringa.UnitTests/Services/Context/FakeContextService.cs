using System;

using Yaringa.Services;

namespace Yaringa.UnitTests.Services {
    public class FakeContextService : IContextService {
        public Int64 UserId { get; set; } = 1;
        public String AccessToken { get; set; } = "";
        public String RefreshToken { get; set; } = "";
        public DateTime TokenExpiryDateTime { get; set; } = DateTime.Now.AddSeconds(1799);
    }
}
