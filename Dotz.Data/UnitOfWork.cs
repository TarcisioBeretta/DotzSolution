using System.Threading.Tasks;
using Dotz.Core;
using Dotz.Core.Repositories;
using Dotz.Data.Repositories;

namespace Dotz.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DotzDbContext _context;
        private UsuarioRepository _usuarioRepository;
        private ProdutoRepository _produtoRepository;
        private TrocaRepository _trocaRepository;

        public UnitOfWork(DotzDbContext context)
        {
            _context = context;
        }

        public IUsuarioRepository Usuarios => _usuarioRepository ??= new UsuarioRepository(_context);
        public IProdutoRepository Produtos => _produtoRepository ??= new ProdutoRepository(_context);
        public ITrocaRepository Trocas => _trocaRepository ??= new TrocaRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
