using Dotz.Core;
using Dotz.Core.Models;
using Dotz.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Services
{
    public class TrocaService : ITrocaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrocaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Troca>> GetAll()
        {
            return await _unitOfWork.Trocas.GetAllWithProdutos();
        }

        public async Task<Troca> GetById(int id)
        {
            return await _unitOfWork.Trocas.GetByIdWithProdutos(id);
        }

        public async Task<Troca> Create(Troca newTroca)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(newTroca.UsuarioId);
            var valorTotal = await SomarPontosProdutos(newTroca);

            usuario.Saldo -= valorTotal;

            await _unitOfWork.Trocas.AddAsync(newTroca);
            await _unitOfWork.CommitAsync();
            return newTroca;
        }

        public async Task<Troca> Update(Troca trocaToBeUpdated, Troca newTroca)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(trocaToBeUpdated.UsuarioId);
            var valorTotal = await SomarPontosProdutos(newTroca);
            var valorTotalEstornado = await SomarPontosProdutos(trocaToBeUpdated);

            usuario.Saldo += valorTotalEstornado;
            usuario.Saldo -= valorTotal;

            trocaToBeUpdated.Produtos = newTroca.Produtos;
            await _unitOfWork.CommitAsync();
            return trocaToBeUpdated;
        }

        public async Task Delete(Troca troca)
        {
            _unitOfWork.Trocas.Remove(troca);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> SaldoInsuficiente(Troca newTroca)
        {
            var saldo = await ConsultarSaldoUsuario(newTroca.UsuarioId);
            var valorTotal = await SomarPontosProdutos(newTroca);
            return valorTotal > saldo;
        }

        public async Task<bool> SaldoInsuficiente(Troca trocaToBeUpdated, Troca newTroca)
        {
            var saldo = await ConsultarSaldoUsuario(trocaToBeUpdated.UsuarioId);
            var valorTotal = await SomarPontosProdutos(newTroca);
            var valorTotalEstornado = await SomarPontosProdutos(trocaToBeUpdated);
            return valorTotal > (saldo + valorTotalEstornado);
        }

        private async Task<float> ConsultarSaldoUsuario(int isuarioId)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(isuarioId);
            return usuario.Saldo;
        }

        private async Task<float> SomarPontosProdutos(Troca troca)
        {
            float soma = 0;

            foreach(var trocaProduto in troca.Produtos)
            {
                var produto = await _unitOfWork.Produtos.GetByIdAsync(trocaProduto.ProdutoId);
                soma += (produto.Pontos * trocaProduto.Quantidade);
            }

            return soma;
        }
    }
}
