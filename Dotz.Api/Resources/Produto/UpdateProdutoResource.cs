using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Api.Resources.Produto
{
    public class UpdateProdutoResource
    {
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"Descricao\" é obrigatório", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo \"Pontos\" é obrigatório", AllowEmptyStrings = false)]
        public float Pontos { get; set; }
    }
}
