using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Api.Resources.Troca
{
    public class UpdateTrocaResource
    {
        [Required(ErrorMessage = "O campo \"Produtos\" é obrigatório", AllowEmptyStrings = false)]
        public IEnumerable<CreateTrocaProdutoResource> Produtos { get; set; }
    }
}
