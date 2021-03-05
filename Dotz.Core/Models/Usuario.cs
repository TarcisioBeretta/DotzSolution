using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Core.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Trocas = new Collection<Troca>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public float Saldo { get; set; }
        public ICollection<Troca> Trocas { get; set; }
    }
}
