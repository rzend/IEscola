using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        IEnumerable<Disciplina> Get();
        Task<Disciplina> GetAsync(Guid id);

        void Insert(Disciplina disciplina);
        void Update(Disciplina disciplina);
        void Delete(Disciplina disciplina);
    }
}
