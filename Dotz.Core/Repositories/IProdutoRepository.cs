using Dotz.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Core.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetByListIdAsync(List<int> id);
    }
}
