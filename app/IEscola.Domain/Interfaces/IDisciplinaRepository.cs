using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IEscola.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        IEnumerable<Disciplina> Get();
        Disciplina Get(Guid id);

        void Insert(Disciplina disciplina);
        void Update(Guid id, Disciplina disciplina);
        void Delete(Disciplina disciplina);
    }
}
