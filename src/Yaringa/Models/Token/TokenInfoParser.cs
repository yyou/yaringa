using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yaringa.Models.Token {
    public class TokenInfoParser {
        public static TokenInfo Parse(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) {
                throw new Exception("Empty token payload");
            }

            string[] parts = accessToken.Split('.');
            if (parts.Length != 3) {
                throw new Exception("Invalid token");
            }

            var part1 = parts[1];
            string incoming = part1.Replace('_', '/').Replace('-', '+');
            switch (part1.Length % 4) {
                case 2: incoming += "=="; break;
                case 3: incoming += "="; break;
            }
            byte[] bytes = Convert.FromBase64String(incoming);
            string payload = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            TokenInfo info = JsonConvert.DeserializeObject<TokenInfo>(payload);

            return info;
        }
    }
}
