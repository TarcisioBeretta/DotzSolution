using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Api.Resources.Auth
{
    public class LoginResource
    {
        [Required(ErrorMessage = "O campo \"Email\" é obrigatório", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo \"Senha\" é obrigatório", AllowEmptyStrings = false)]
        public string Senha { get; set; }
    }
}
