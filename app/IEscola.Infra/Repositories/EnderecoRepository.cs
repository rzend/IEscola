using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscola.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly List<Endereco> _enderecoList = new List<Endereco>
        {
            new Endereco(Guid.Parse("090A5118-6280-4D00-BF98-64CBF017E30F"),"Dolores Rios Moncayo", "Jardim Casa Branca", 80, 18077610, "Sorocaba", "SP"),
            new Endereco(Guid.Parse("E72732F9-E5EA-4006-AE66-734135EE6C2F"),"Thadeu Grembecki", "Jardim Prestes de Barros", 75, 18021285, "Sorocaba", "SP"),
            new Endereco(Guid.Parse("9AC90B2E-6F9D-4BD6-9F38-D83845C074DC"),"José Jorge Nardi de Souza", "Parque Campolim", 240, 18047670, "Sorocaba", "SP")
        };

        public async Task<IEnumerable<Endereco>> GetAsync()
        {
            return await Task.FromResult(_enderecoList);
        }

        public async Task<Endereco> GetAsync(Guid id)
        {
            return await Task.FromResult(_enderecoList.FirstOrDefault(d => d.Id == id));
        }

        public async Task InsertAsync(Endereco endereco)
        {
            await Task.Run(() => _enderecoList.Add(endereco));
        }

        public async Task UpdateAsync(Endereco endereco)
        {
            var end = await GetAsync(endereco.Id);

            await DeleteAsync(end);

            await InsertAsync(endereco);
        }

        public async Task DeleteAsync(Endereco endereco)
        {
            await Task.Run(() => _enderecoList.Remove(endereco));
        }
                
    }
}
