using IEscola.Application.HttpObjects.Professor.Request;
using IEscola.Application.HttpObjects.Professor.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Application.Interfaces
{
    public interface IProfessorService
    {
        IEnumerable<ProfessorResponse> Get();
        ProfessorResponse Get(Guid id);
        Task<ProfessorFullResponse> GetFullAsync(Guid id);
        ProfessorResponse Insert(ProfessorInsertRequest disciplina);
        ProfessorResponse Update(ProfessorUpdateRequest disciplina);
        void Delete(Guid id);
    }
}
