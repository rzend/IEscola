using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> Get();
        Aluno Get(Guid id);
        void Insert(Aluno aluno);
        void Update(Aluno aluno);
        void Delete(Aluno aluno);
    }
}
