using Dotz.Api.Resources.Usuario;
using System.Collections.Generic;

namespace Dotz.Api.Resources.Troca
{
    public class TrocaResource
    {
        public int Id { get; set; }
        public IEnumerable<TrocaProdutoResource> Produtos { get; set; }
    }
}
