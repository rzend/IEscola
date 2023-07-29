using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Infra.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly List<Professor> _professorList = new List<Professor> {
            new Professor(Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94"), "Antonio", "01234567890", new DateTime(1990, 2, 27), Guid.Parse("292499B0-2B09-4787-92CF-8C352456EAE0"), Guid.Parse("090A5118-6280-4D00-BF98-64CBF017E30F")),
            new Professor(Guid.Parse("EB093931-E526-4EAB-B444-D9ED7B583F43"), "José", "22222222222", new DateTime(1985, 2, 21), Guid.Parse("292499B0-2B09-4787-92CF-8C352456EAE0"), Guid.Parse("E72732F9-E5EA-4006-AE66-734135EE6C2F")),
            new Professor(Guid.Parse("3BF8376A-2E89-4B28-91B5-FA9999BBD1A3"), "João", "11111111111", new DateTime(1983, 12, 31), Guid.Parse("FF829D06-A51E-413A-A800-8DA041F60AA6"), Guid.Parse("9AC90B2E-6F9D-4BD6-9F38-D83845C074DC")),
            new Professor(Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB"), "Maria", "01234567800", new DateTime(1989, 3, 15), Guid.Parse("FF829D06-A51E-413A-A800-8DA041F60AA6"), Guid.Parse("090A5118-6280-4D00-BF98-64CBF017E30F"))
        };

        public async Task<IEnumerable<Professor>> GetAsync()
        {
            return await Task.FromResult(_professorList); 
        }

        public async Task<Professor> GetAsync(Guid id)
        {
            return await Task.FromResult(_professorList.FirstOrDefault(d => d.Id == id));
        }

        public async Task InsertAsync(Professor professor)
        {
             await Task.Run(() => _professorList.Add(professor));
        }

        public async Task UpdateAsync(Professor professor)
        {
            var prof = await GetAsync(professor.Id);

            await DeleteAsync(prof);

            await InsertAsync(professor);
        }

        public async Task DeleteAsync(Professor professor)
        {
            await Task.Run(() => _professorList.Remove(professor));
        }
    }
}
