using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yaringa.Services;

namespace Yaringa.UnitTests.Services {
    public class FakeSettingsService : ISettingsService {
        public String BaseUrl { get; set; } = "https://myapi.com/api";
    }
}
