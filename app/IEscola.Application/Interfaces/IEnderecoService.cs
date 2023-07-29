using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.HttpObjects.Endereco.Request;
using IEscola.Application.HttpObjects.Endereco.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoResponse>> GetAsync();
        Task<EnderecoResponse> GetAsync(Guid id);
        Task<EnderecoResponse> InsertAsync(EnderecoInsertRequest disciplina);
        Task<EnderecoResponse> UpdateAsync(EnderecoUpdateRequest disciplina);
        Task DeleteAsync(Guid id);
    }
}
