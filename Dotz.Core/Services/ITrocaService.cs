using Dotz.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Core.Services
{
    public interface ITrocaService
    {
        Task<IEnumerable<Troca>> GetAll();
        Task<Troca> GetById(int id);
        Task<Troca> Create(Troca newTroca);
        Task<Troca> Update(Troca trocaToBeUpdated, Troca troca);
        Task Delete(Troca troca);
        Task<bool> SaldoInsuficiente(Troca newTroca);
        Task<bool> SaldoInsuficiente(Troca trocaToBeUpdated, Troca newTroca);
    }
}
