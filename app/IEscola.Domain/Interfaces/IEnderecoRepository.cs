using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public  interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> GetAsync();
        Task<Endereco> GetAsync(Guid id);
        Task InsertAsync(Endereco endereco);
        Task UpdateAsync(Endereco endereco);
        Task DeleteAsync(Endereco endereco);
    }
}
