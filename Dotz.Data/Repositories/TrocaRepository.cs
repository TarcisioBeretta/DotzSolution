using Dotz.Core.Models;
using Dotz.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Data.Repositories
{
    public class TrocaRepository : Repository<Troca>, ITrocaRepository
    {
        public TrocaRepository(DotzDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Troca>> GetAllWithProdutos()
        {
            return await DotzDbContext.Trocas.Include(o => o.Produtos).ThenInclude(o => o.Produto).ToListAsync();
        }

        public async Task<Troca> GetByIdWithProdutos(int id)
        {
            return await DotzDbContext.Trocas.Include(o => o.Produtos).ThenInclude(o => o.Produto).SingleOrDefaultAsync(o => o.Id == id);
        }

        private DotzDbContext DotzDbContext
        {
            get { return Context as DotzDbContext; }
        }
    }
}
