using Dotz.Core.Models;
using System.Threading.Tasks;

namespace Dotz.Core.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);
    }
}
