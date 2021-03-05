using Dotz.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Core.Repositories
{
    public interface ITrocaRepository : IRepository<Troca>
    {
        Task<IEnumerable<Troca>> GetAllWithProdutos();
        Task<Troca> GetByIdWithProdutos(int id);
    }
}
