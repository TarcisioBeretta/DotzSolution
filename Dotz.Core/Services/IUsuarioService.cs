using Dotz.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Core.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> Create(Usuario newUsuario);
        Task<Usuario> Update(Usuario usuarioToBeUpdated, Usuario usuario);
        Task Delete(Usuario usuario);
    }
}
