using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Infra.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly List<Disciplina> _disciplinaList = new List<Disciplina> {
            new Disciplina ( Guid.Parse("292499B0-2B09-4787-92CF-8C352456EAE0"), "Matemática", "A melhor de todas"),
            new Disciplina ( Guid.Parse("506101B4-D597-44BE-921C-49069023E0DA"), "Língua Portuguesa", "A mais importante"),
            new Disciplina ( Guid.Parse("8C2A1F47-F991-4326-868A-09D38CBC0FA7"), "História", "Para entender de onde viemos"),
            new Disciplina ( Guid.Parse("FF829D06-A51E-413A-A800-8DA041F60AA6"), "Geografia","Para entender o mundo e para onde vamos"),
            new Disciplina ( Guid.Parse("67DA87F3-BD25-4ED2-B9EB-1420E98A9CDD"), "Física", "Para experimentar a Matemática"),
            new Disciplina ( Guid.Parse("F0267664-2D3C-4FCB-B94C-6DD3F5544E10"), "Química","Para aprender que NaCl é sal"),
            new Disciplina ( Guid.Parse("9AA2068E-4704-4E7A-A67F-44F426E195C1"), "Filosofia","Para viajar nas ideias")
        };

        public async Task<IEnumerable<Disciplina>> GetAsync()
        {
            return await Task.FromResult(_disciplinaList);
        }

        public async Task<Disciplina> GetAsync(Guid id)
        {
            await Task.Delay(1_000);
            return await Task.FromResult(_disciplinaList.FirstOrDefault(d => d.Id == id));
        }

        public async Task InsertAsync(Disciplina disciplina)
        {
            await Task.Run(() => _disciplinaList.Add(disciplina));
        }

        public async Task UpdateAsync(Disciplina disciplina)
        {
            var disc = await GetAsync(disciplina.Id);

            await DeleteAsync(disc);

            await InsertAsync(disciplina);
        }

        public async Task DeleteAsync(Disciplina disciplina)
        {
            await Task.Run(() => _disciplinaList.Remove(disciplina));
        }
    }
}
