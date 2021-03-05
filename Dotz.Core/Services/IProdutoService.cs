using Dotz.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Core.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> Create(Produto newProduto);
        Task<Produto> Update(Produto produtoToBeUpdated, Produto produto);
        Task Delete(Produto produto);
    }
}
