using Dotz.Core;
using Dotz.Core.Models;
using Dotz.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _unitOfWork.Usuarios.GetAllAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _unitOfWork.Usuarios.GetByIdAsync(id);
        }

        public async Task<Usuario> Create(Usuario newUsuario)
        {
            await _unitOfWork.Usuarios.AddAsync(newUsuario);
            await _unitOfWork.CommitAsync();
            return newUsuario;
        }

        public async Task<Usuario> Update(Usuario usuarioToBeUpdated, Usuario usuario)
        {
            usuarioToBeUpdated.Nome = usuario.Nome;
            usuarioToBeUpdated.Email = usuario.Email;
            usuarioToBeUpdated.Senha = usuario.Senha;
            usuarioToBeUpdated.Saldo = usuario.Saldo;
            await _unitOfWork.CommitAsync();
            return usuarioToBeUpdated;
        }

        public async Task Delete(Usuario usuario)
        {
            _unitOfWork.Usuarios.Remove(usuario);
            await _unitOfWork.CommitAsync();
        }
    }
}
