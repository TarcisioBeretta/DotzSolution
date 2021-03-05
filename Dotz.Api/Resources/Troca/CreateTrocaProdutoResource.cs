using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Api.Resources.Troca
{
    public class CreateTrocaProdutoResource
    {
        [Required(ErrorMessage = "O campo \"ProdutoId\" é obrigatório", AllowEmptyStrings = false)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo \"Quantidade\" é obrigatório", AllowEmptyStrings = false)]
        public int Quantidade { get; set; }
    }
}
