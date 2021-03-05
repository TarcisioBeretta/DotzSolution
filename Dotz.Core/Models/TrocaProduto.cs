namespace Dotz.Core.Models
{
    public class TrocaProduto
    {
        public int Id { get; set; }
        public int TrocaId { get; set; }
        public int ProdutoId { get; set; }
        public Troca Troca { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
