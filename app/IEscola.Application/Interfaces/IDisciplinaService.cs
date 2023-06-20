using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IEscola.Application.Interfaces
{
    public interface IDisciplinaService
    {
        IEnumerable<Disciplina> Get();
        Disciplina Get(Guid id);

        void Insert(DisciplinaInsertRequest disciplina);
        void Update(Guid id, Disciplina disciplina);
        void Delete(Disciplina disciplina);
    }
}
