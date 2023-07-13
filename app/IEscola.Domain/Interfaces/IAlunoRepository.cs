using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> Get();
        Task<IEnumerable<Aluno>> GetByProfessorIdAsync(Guid professorId);
        Aluno Get(Guid id);
        void Insert(Aluno aluno);
        void Update(Aluno aluno);
        void Delete(Aluno aluno);
    }
}
