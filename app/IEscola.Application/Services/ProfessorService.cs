using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.HttpObjects.Professor.Request;
using IEscola.Application.HttpObjects.Professor.Response;
using IEscola.Application.Interfaces;
using IEscola.Application.Services.Validators;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Application.Services
{
    public class ProfessorService : ServiceBase, IProfessorService
    {
        private readonly IProfessorRepository _repository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IAlunoRepository _alunoRepository;

        public ProfessorService(IProfessorRepository repository,
            INotificador notificador,
            IDisciplinaRepository disciplinaRepository,
            IAlunoRepository alunoRepository) : base(notificador)
        {
            _repository = repository;
            _disciplinaRepository = disciplinaRepository;
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<ProfessorResponse>> GetAsync()
        {
            var list = await _repository.GetAsync();

            return list.Select(d => Map(d));
        }

        public async Task<ProfessorResponse> GetAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var professor = await _repository.GetAsync(id);

            if (professor is null)
            {
                NotificarErro("Professor não encontrado");
                return default;
            };

            // Retornar
            return Map(professor);
        }

        public async Task<ProfessorFullResponse> GetFullAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var professor = await _repository.GetAsync(id);

            if (professor is null)
            {
                NotificarErro("Professor não encontrado");
                return default;
            };

            var tasks = new Task[]
            {
                Task.Run(async () => professor.Disciplina = await _disciplinaRepository.GetAsync(professor.DisciplinaId)),
                Task.Run(async () => professor.Alunos = await _alunoRepository.GetByProfessorIdAsync(id))
            };
            Task.WaitAll(tasks);

            // Retornar
            return MapFull(professor);
        }

        public async Task<ProfessorResponse> InsertAsync(ProfessorInsertRequest professorRequest)
        {
            // Mapear para o objeto de domínio
            var id = Guid.NewGuid();
            var professor = new Professor(id, professorRequest.Nome, professorRequest.Cpf, professorRequest.DataNascimento, professorRequest.DisciplinaId)
            {
                Tratamento = professorRequest.Tratamento,
                DataUltimaAlteracao = DateTime.UtcNow,
                UsuarioUltimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            ValidaInsert(professor);

            if (TemNotificacao())
                return default;

            // Processar
            await _repository.InsertAsync(professor);

            // Retornar
            return Map(professor);
        }

        public async Task<ProfessorResponse> UpdateAsync(ProfessorUpdateRequest professorRequest)
        {
            // Mapear para o objeto de domínio
            var professor = new Professor(professorRequest.Id, professorRequest.Nome, professorRequest.Cpf, professorRequest.DataNascimento, professorRequest.DisciplinaId)
            {
                Tratamento = professorRequest.Tratamento,
                DataUltimaAlteracao = DateTime.UtcNow,
                UsuarioUltimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            // Validar se a disciplina do Id existe
            var disc = await GetAsync(professor.Id);
            if (disc is null) return default;

            ValidaUpdate(professor);

            if (TemNotificacao())
                return default;

            if (professorRequest.Ativo)
                professor.Ativar();
            else
                professor.Inativar();

            // Processar
            await _repository.UpdateAsync(professor);

            // Retornar
            return Map(professor);
        }



        public async Task DeleteAsync(Guid id)
        {
            var professor = await _repository.GetAsync(id);

            if (professor is null)
            {
                NotificarErro("Professor não encontrado");
                return;
            }

            await _repository.DeleteAsync(professor);
        }

        #region Private Methods

        private void ValidaInsert(Professor professor)
        {
            /// Validar a professor
            if (string.IsNullOrWhiteSpace(professor.Nome))
                NotificarErro("Nome não preenchido");

            if (!CpfValidator.ValidarCPF(professor.Cpf)) // TODO: Validar o CPF
                NotificarErro("Cpf não preenchido");

            if (professor.DataNascimento >= DateTime.Today.AddYears(-18)) // Professor deve ser maior que 18 ano
                NotificarErro("Data de nascimento inválida");
        }

        private void ValidaUpdate(Professor professor)
        {
            if (professor.Id == Guid.Empty)
                NotificarErro("Id não preenchido");

            ValidaInsert(professor);
        }


        private static ProfessorResponse Map(Professor professor)
        {
            return new ProfessorResponse
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Cpf = professor.Cpf,
                DataNascimento = professor.DataNascimento,
                Tratamento = professor.Tratamento,
                Ativo = professor.Ativo
            };
        }

        private static ProfessorFullResponse MapFull(Professor professor)
        {
            return new ProfessorFullResponse
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Cpf = professor.Cpf,
                DataNascimento = professor.DataNascimento,
                Tratamento = professor.Tratamento,
                Ativo = professor.Ativo,
                Disciplina = new DisciplinaResponse
                {
                    Id = professor.DisciplinaId,
                    Nome = professor.Disciplina.Nome,
                    Descricao = professor.Disciplina.Descricao,
                    Ativo = professor.Disciplina.Ativo
                },
                Alunos = professor.Alunos.Select(a => new AlunoResponse
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    NumeroMatricula = a.NumeroMatricula,
                    DataNascimento = a.DataNascimento,
                    ProfessorId = a.ProfessorId,
                    Ativo = a.Ativo
                })
            };
        }
        #endregion
    }
}
