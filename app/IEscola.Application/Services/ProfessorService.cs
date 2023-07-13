using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.HttpObjects.Professor.Request;
using IEscola.Application.HttpObjects.Professor.Response;
using IEscola.Application.Interfaces;
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

        public IEnumerable<ProfessorResponse> Get()
        {
            var list = _repository.Get();

            return list.Select(d => Map(d));
        }

        public ProfessorResponse Get(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var professor = _repository.Get(id);

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

            var professor = _repository.Get(id);

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

        public ProfessorResponse Insert(ProfessorInsertRequest professorRequest)
        {
            /// Validar a professor
            if (string.IsNullOrWhiteSpace(professorRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (string.IsNullOrWhiteSpace(professorRequest.Cpf)) // TODO: Validar o CPF
                NotificarErro("Cpf não preenchido");

            if (TemNotificacao())
                return default;

            // Mapear para o objeto de domínio
            var id = Guid.NewGuid();
            var professor = new Professor(id, professorRequest.Nome, professorRequest.Cpf, professorRequest.DataNascimento, professorRequest.DisciplinaId)
            {
                Tratamento = professorRequest.Tratamento,
                DataUltimaAlteracao = DateTime.UtcNow,
                UsuarioUltimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            // Processar
            _repository.Insert(professor);

            // Retornar
            return Map(professor);
        }

        public ProfessorResponse Update(ProfessorUpdateRequest professorRequest)
        {

            if (professorRequest.Id == Guid.Empty)
                NotificarErro("Id não preenchido");

            /// Validar a professor
            if (string.IsNullOrWhiteSpace(professorRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (string.IsNullOrWhiteSpace(professorRequest.Cpf)) // TODO: Validar o CPF
                NotificarErro("Cpf não preenchido");

            if (TemNotificacao())
                return default;

            // Validar se a disciplina do Id existe
            var disc = Get(professorRequest.Id);
            if (disc is null) return default;

            // Mapear para o objeto de domínio
            var professor = new Professor(professorRequest.Id, professorRequest.Nome, professorRequest.Cpf, professorRequest.DataNascimento, professorRequest.DisciplinaId)
            {
                Tratamento = professorRequest.Tratamento,
                DataUltimaAlteracao = DateTime.UtcNow,
                UsuarioUltimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            if (professorRequest.Ativo)
                professor.Ativar();
            else
                professor.Inativar();

            // Processar
            _repository.Update(professor);

            // Retornar
            return Map(professor);
        }

        public void Delete(Guid id)
        {
            var professor = _repository.Get(id);

            if (professor is null)
            {
                NotificarErro("Professor não encontrado");
                return;
            }

            _repository.Delete(professor);
        }

        #region Private Methods
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
                Alunos = professor.Alunos.Select(a => new AlunoResponse { 
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
