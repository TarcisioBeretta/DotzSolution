using Dotz.Core.Models;
using System.Threading.Tasks;

namespace Dotz.Core.Services
{
    public interface IAuthService
    {
        Task<UsuarioToken> Login(string email, string password);
    }
}
