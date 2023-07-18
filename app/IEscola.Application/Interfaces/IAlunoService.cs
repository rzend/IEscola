using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEscola.Application.HttpObjects.Aluno.Request;
using IEscola.Application.HttpObjects.Aluno.Response;

namespace IEscola.Application.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoResponse>> GetAsync();
        Task<AlunoResponse> GetAsync(Guid id);

        Task<AlunoResponse> InsertAsync(AlunoInsertRequest professor);
        Task<AlunoResponse> UpdateAsync(AlunoUpdateRequest professor);
        Task DeleteAsync(Guid id);
    }
}
