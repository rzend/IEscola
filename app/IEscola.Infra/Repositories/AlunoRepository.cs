using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly List<Aluno> _alunoList = new List<Aluno> {
            // Alunos do Professor Antonio
            new Aluno(Guid.Parse("9306A723-FFCE-4464-BD77-151E962E0477"), "Antonio", new DateTime(1990, 2, 27), 2023_01, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("F30E0410-AB8A-4CD3-9BE5-190C71092107"), "José", new DateTime(1985, 2, 21), 2023_02, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("F30E0410-AB8A-4CD3-9BE5-190C71092107"), "João", new DateTime(1983, 12, 31), 2023_03, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("BA6B1AFB-C38A-46BD-A02B-FD27F7E14B0C"), "Maria", new DateTime(1989, 3, 15), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("BD566B7F-0939-4218-8F84-9EDC12421F04"), "James", new DateTime(1988, 11, 15), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("8EB73E54-352C-469D-912F-AEBBC364996E"), "Jessica", new DateTime(1989, 3, 16), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("F2DA4F75-62D9-4E6D-8B69-C554175538A2"), "Roberto", new DateTime(1989, 3, 17), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("ADC0B176-993C-49FD-8199-39656829425D"), "Celso", new DateTime(1989, 12, 18), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("2C603B53-64D7-4C46-B746-E2EC2DF91DBC"), "Karina", new DateTime(1989, 10, 19), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("5CC9481A-1D64-49B4-AA8E-A4671EBA628E"), "Juliana", new DateTime(1989, 4, 21), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("3E1A6BB1-FA05-466B-B809-8D6A954B19FE"), "Rodrigo", new DateTime(1989, 5, 22), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("AFFF0C8C-EC37-496E-8C4E-1ADB6ED2B083"), "Vinicius", new DateTime(1989, 6, 25), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("194570A5-D1A0-4345-B3A9-A0D26610414D"), "Rafael", new DateTime(1993, 3, 30), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("3E846143-7F6F-4CAF-9679-C383E1484E0D"), "Lucas", new DateTime(1998, 3, 15), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),
            new Aluno(Guid.Parse("1CF06F7A-4354-494D-AD40-B17FBA33EA6C"), "Carla", new DateTime(1997, 5, 15), 2023_04, Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94")),


            new Aluno(Guid.Parse("9306A723-FFCE-4464-BD77-151E962E0477"), "Marcos", new DateTime(1990, 2, 27), 2023_01, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("F30E0410-AB8A-4CD3-9BE5-190C71092107"), "Vanessa", new DateTime(1985, 2, 21), 2023_02, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("F30E0410-AB8A-4CD3-9BE5-190C71092107"), "Sandro", new DateTime(1983, 12, 31), 2023_03, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("BA6B1AFB-C38A-46BD-A02B-FD27F7E14B0C"), "Julia Oliveira", new DateTime(1989, 3, 15), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("BD566B7F-0939-4218-8F84-9EDC12421F04"), "Kleber", new DateTime(1988, 11, 15), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("8EB73E54-352C-469D-912F-AEBBC364996E"), "Rute", new DateTime(1989, 3, 16), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("F2DA4F75-62D9-4E6D-8B69-C554175538A2"), "Alberto", new DateTime(1989, 3, 17), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("ADC0B176-993C-49FD-8199-39656829425D"), "Murilo", new DateTime(1989, 12, 18), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("2C603B53-64D7-4C46-B746-E2EC2DF91DBC"), "Mateus", new DateTime(1989, 10, 19), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("5CC9481A-1D64-49B4-AA8E-A4671EBA628E"), "Diogo", new DateTime(1989, 4, 21), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("3E1A6BB1-FA05-466B-B809-8D6A954B19FE"), "Elton", new DateTime(1989, 5, 22), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("AFFF0C8C-EC37-496E-8C4E-1ADB6ED2B083"), "Diego", new DateTime(1989, 6, 25), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("194570A5-D1A0-4345-B3A9-A0D26610414D"), "Jorge", new DateTime(1993, 3, 30), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("3E846143-7F6F-4CAF-9679-C383E1484E0D"), "Laura", new DateTime(1998, 3, 15), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
            new Aluno(Guid.Parse("1CF06F7A-4354-494D-AD40-B17FBA33EA6C"), "Lorena", new DateTime(1997, 5, 15), 2023_04, Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB")),
        };

        public async Task<IEnumerable<Aluno>> GetAsync()
        {
            return await Task.FromResult(_alunoList);
        }

        public async Task<Aluno> GetAsync(Guid id)
        {
            return await Task.FromResult(_alunoList.FirstOrDefault(d => d.Id == id));
        }

        public async Task<IEnumerable<Aluno>> GetByProfessorIdAsync(Guid professorId)
        {
            await Task.Delay(1_000); // Delay para simular lentidão na consulta
            return await Task.FromResult(_alunoList.Where(d => d.ProfessorId == professorId));
        }

        public async Task InsertAsync(Aluno aluno)
        {
            await Task.Run(() => _alunoList.Add(aluno));
        }

        public async Task UpdateAsync(Aluno aluno)
        {
            var disc = await GetAsync(aluno.Id);

            await DeleteAsync(disc);

            await InsertAsync(aluno);
        }

        public async Task DeleteAsync(Aluno aluno)
        {
            await Task.Run(() =>  _alunoList.Remove(aluno)); 
        }
    }
}
