using IEscola.Application.HttpObjects.Aluno.Request;
using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IEscola.Application.Services
{
    public class AlunoService : ServiceBase, IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly IProfessorRepository _professorRepository;

        public AlunoService(IAlunoRepository repository,
            INotificador notificador,
            IProfessorRepository professorRepository) : base(notificador)
        {
            _repository = repository;
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<AlunoResponse>> GetAsync()
        {
            var list = await _repository.GetAsync();

            return list.Select(d => Map(d));
        }

        public async Task<AlunoResponse> GetAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var aluno = await _repository.GetAsync(id);

            if (aluno is null)
            {
                NotificarErro("Aluno não encontrado");
                return default;
            };

            // Retornar
            return Map(aluno);
        }

        public async Task<IEnumerable<AlunoResponse>> GetByProfessorIdAsync(Guid professorId)
        {
            if (Guid.Empty == professorId)
            {
                NotificarErro("id inválido");
                return default;
            }

            // Validar existencia de professor
            var prof = _professorRepository.GetAsync(professorId);
            if (prof is null)
            {
                NotificarErro("Professor não encontrado");
                return default;
            }

            var alunos = await _repository.GetByProfessorIdAsync(professorId);

            // Retornar
            return alunos.Select(a => Map(a));
        }

        public async Task<AlunoResponse> InsertAsync(AlunoInsertRequest alunoRequest)
        {
            // Validar a Professor
            if (string.IsNullOrWhiteSpace(alunoRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (alunoRequest.NumeroMatricula <= 0)
                NotificarErro("Número matrícula deve ser maior que zero");
            
            if (alunoRequest.DataNascimento >= DateTime.Today.AddYears(-1)) // Aluno deve ser maior que 1 ano
                NotificarErro("Data de nascimento inválida");

            if (TemNotificacao())
                return default;

            // Validar existencia de professor
            var prof = await _professorRepository.GetAsync(alunoRequest.ProfessorId);
            if (prof is null)
            {
                NotificarErro("Professor não encontrado");
                return default;
            }

            // Mapear para o objeto de domínio
            var id = Guid.NewGuid();
            var aluno = new Aluno(id, alunoRequest.Nome, alunoRequest.DataNascimento, alunoRequest.NumeroMatricula, alunoRequest.ProfessorId)
            {
                DataUltimaAlteracao = DateTime.Now,
                UsuarioUltimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            // Processar
            await _repository.InsertAsync(aluno);

            // Retornar
            return Map(aluno);
        }

        public async Task<AlunoResponse> UpdateAsync(AlunoUpdateRequest alunoRequest)
        {
            // Validar a Professor

            if (alunoRequest.Id == Guid.Empty)
                NotificarErro("Id não preenchido");

            if (string.IsNullOrWhiteSpace(alunoRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (alunoRequest.NumeroMatricula <= 0)
                NotificarErro("Número matrícula deve ser maior que zero");

            if (alunoRequest.DataNascimento >= DateTime.Today.AddYears(-1)) // Aluno deve ser maior que 1 ano
                NotificarErro("Data de nascimento inválida");

            if (TemNotificacao())
                return default;

            // Validar se a Professor do Id existe
            var aln = await GetAsync(alunoRequest.Id);
            if (aln is null) return default;

            // Validar existencia de professor
            var prof = await _professorRepository.GetAsync(alunoRequest.ProfessorId);
            if (prof is null)
            {
                NotificarErro("Professor não encontrado");
                return default;
            }

            var aluno = new Aluno(alunoRequest.Id, alunoRequest.Nome, alunoRequest.DataNascimento, alunoRequest.NumeroMatricula, alunoRequest.ProfessorId)
            {
                DataUltimaAlteracao = DateTime.Now,
                UsuarioUltimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            if (alunoRequest.Ativo)
                aluno.Ativar();
            else
                aluno.Inativar();

            await _repository.UpdateAsync(aluno);

            return Map(aluno);
        }

        public async Task DeleteAsync(Guid id)
        {
            var aluno = await _repository.GetAsync(id);

            if (aluno is null)
            {
                NotificarErro("Aluno não encontrado");
                return;
            }
            await _repository.DeleteAsync(aluno);
        }

        #region Private Methods
        private static AlunoResponse Map(Aluno aluno)
        {
            return new AlunoResponse
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                NumeroMatricula = aluno.NumeroMatricula,
                DataNascimento = aluno.DataNascimento,
                ProfessorId = aluno.ProfessorId,
                Ativo = aluno.Ativo
            };
        }
        #endregion
    }
}
