using Dotz.Core.Models;
using Dotz.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dotz.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DotzDbContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await DotzDbContext.Usuarios.SingleOrDefaultAsync(m => m.Email == email);
        }

        private DotzDbContext DotzDbContext
        {
            get { return Context as DotzDbContext; }
        }
    }
}
