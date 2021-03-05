using Dotz.Core.Models;
using Dotz.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DotzDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> GetByListIdAsync(List<int> id)
        {
            return await DotzDbContext.Produtos.Where(o => id.Contains(o.Id)).ToListAsync();
        }

        private DotzDbContext DotzDbContext
        {
            get { return Context as DotzDbContext; }
        }
    }
}
