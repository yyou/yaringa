﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yaringa.Models.Token {
    public class TokenException : Exception
    {
        public TokenException() : base() {

        }

        public TokenException(string message): base(message) {

        }

        public TokenException(string message, Exception innerException) : base(message, innerException) {

        }
    }
}
