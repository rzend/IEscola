using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IEscola.Infra.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly List<Professor> _professorList = new List<Professor> {
            new Professor(Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94"), "Antonio", "01234567890", new DateTime(1990, 2, 27)),
            new Professor(Guid.Parse("EB093931-E526-4EAB-B444-D9ED7B583F43"), "José", "22222222222", new DateTime(1985, 2, 21)),
            new Professor(Guid.Parse("3BF8376A-2E89-4B28-91B5-FA9999BBD1A3"), "João", "11111111111", new DateTime(1983, 12, 31)),
            new Professor(Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB"), "Maria", "01234567800", new DateTime(1989, 3, 15))
        };

        public void Delete(Professor professor)
        {
            _professorList.Remove(professor);
        }

        public IEnumerable<Professor> Get()
        {
            return _professorList;
        }

        public Professor Get(Guid id)
        {
            return _professorList.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Professor professor)
        {
            _professorList.Add(professor);
        }

        public void Update(Professor professor)
        {
            var prof = Get(professor.Id);

            _professorList.Remove(prof);

            _professorList.Add(professor);
        }
    }
}
