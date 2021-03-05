using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dotz.Core.Models
{
    public class Troca
    {
        public Troca()
        {
            Produtos = new Collection<TrocaProduto>();
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<TrocaProduto> Produtos { get; set; }
    }
}
