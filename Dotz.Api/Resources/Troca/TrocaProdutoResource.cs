using Dotz.Api.Resources.Produto;

namespace Dotz.Api.Resources.Troca
{
    public class TrocaProdutoResource
    {
        public ProdutoResource Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
