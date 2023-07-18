using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetAsync();
        Task<Professor> GetAsync(Guid id);

        Task InsertAsync(Professor professor);
        Task UpdateAsync(Professor professor);
        Task DeleteAsync(Professor professor);
    }
}
