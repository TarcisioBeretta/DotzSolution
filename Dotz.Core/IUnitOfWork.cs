using Dotz.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Dotz.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IProdutoRepository Produtos { get; }
        ITrocaRepository Trocas { get; }
        Task<int> CommitAsync();
    }
}
