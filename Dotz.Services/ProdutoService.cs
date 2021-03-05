using Dotz.Core;
using Dotz.Core.Models;
using Dotz.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _unitOfWork.Produtos.GetAllAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _unitOfWork.Produtos.GetByIdAsync(id);
        }

        public async Task<Produto> Create(Produto newProduto)
        {
            await _unitOfWork.Produtos.AddAsync(newProduto);
            await _unitOfWork.CommitAsync();
            return newProduto;
        }

        public async Task<Produto> Update(Produto produtoToBeUpdated, Produto produto)
        {
            produtoToBeUpdated.Nome = produto.Nome;
            produtoToBeUpdated.Descricao = produto.Descricao;
            produtoToBeUpdated.Pontos = produto.Pontos;
            await _unitOfWork.CommitAsync();
            return produtoToBeUpdated;
        }

        public async Task Delete(Produto produto)
        {
            _unitOfWork.Produtos.Remove(produto);
            await _unitOfWork.CommitAsync();
        }
    }
}
