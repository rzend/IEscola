using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IEscola.Application.Interfaces
{
    public interface IDisciplinaService
    {
        IEnumerable<DisciplinaResponse> Get();
        DisciplinaResponse Get(Guid id);

        DisciplinaResponse Insert(DisciplinaInsertRequest disciplina);
        DisciplinaResponse Update(DisciplinaUpdateRequest disciplina);
        void Delete(Disciplina disciplina);
    }
}
