using IEscola.Application.HttpObjects.Professor.Request;
using IEscola.Application.HttpObjects.Professor.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Application.Interfaces
{
    public interface IProfessorService
    {
        Task<IEnumerable<ProfessorResponse>> GetAsync();
        Task<ProfessorResponse> GetAsync(Guid id);
        Task<ProfessorFullResponse> GetFullAsync(Guid id);
        Task<ProfessorResponse> InsertAsync(ProfessorInsertRequest disciplina);
        Task<ProfessorResponse> UpdateAsync(ProfessorUpdateRequest disciplina);
        Task DeleteAsync(Guid id);
    }
}
