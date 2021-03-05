using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Api.Resources.Auth
{
    public class UsuarioTokenResource
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
