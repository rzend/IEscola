using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAsync();
        Task<IEnumerable<Aluno>> GetByProfessorIdAsync(Guid professorId);
        Task<Aluno> GetAsync(Guid id);
        Task InsertAsync(Aluno aluno);
        Task UpdateAsync(Aluno aluno);
        Task DeleteAsync(Aluno aluno);
    }
}
