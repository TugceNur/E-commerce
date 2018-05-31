using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.Models
{
    public class LoginState
    {
        public static bool _LoginState { get; set; } = false;
        public static bool _RegSuccess { get; set; } = false;
    }
}