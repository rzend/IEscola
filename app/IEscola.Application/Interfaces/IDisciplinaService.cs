using IEscola.Application.HttpObjects.Disciplina.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Application.Interfaces
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<DisciplinaResponse>> GetAsync();
        Task<DisciplinaResponse> GetAsync(Guid id);
        Task<DisciplinaResponse> InsertAsync(DisciplinaInsertRequest disciplina);
        Task<DisciplinaResponse> UpdateAsync(DisciplinaUpdateRequest disciplina);
        Task DeleteAsync(Guid id);
    }
}
