using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<IEnumerable<Disciplina>> GetAsync();
        Task<Disciplina> GetAsync(Guid id);

        Task InsertAsync(Disciplina disciplina);
        Task UpdateAsync(Disciplina disciplina);
        Task DeleteAsync(Disciplina disciplina);
    }
}
