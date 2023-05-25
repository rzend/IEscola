using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Disciplina> Get()
        {
            return _disciplinaList;
        }

        public Disciplina Get(Guid id)
        {
            return _disciplinaList.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Disciplina disciplina)
        {
            _disciplinaList.Add(disciplina);
        }

        public void Update(Guid id, Disciplina disciplina)
        {
            var disc = Get(id);

            _disciplinaList.Remove(disc);

            disciplina.Id = id;

            _disciplinaList.Add(disciplina);
        }

        public void Delete(Disciplina disciplina)
        {
            _disciplinaList.Remove(disciplina);
        }
    }
}
