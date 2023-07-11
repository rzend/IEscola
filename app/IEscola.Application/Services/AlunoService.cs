using IEscola.Application.HttpObjects.Aluno.Request;
using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<AlunoResponse>> Get()
        {
            var list = await _repository.Get();

            return list.Select(d => Map(d));
        }

        public AlunoResponse Get(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var aluno = _repository.Get(id);

            if (aluno is null)
            {
                NotificarErro("Aluno não encontrado");
                return default;
            };

            // Retornar
            return Map(aluno);
        }

        public AlunoResponse Insert(AlunoInsertRequest alunoRequest)
        {
            // Validar a Professor
            if (string.IsNullOrWhiteSpace(alunoRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (alunoRequest.NumeroMatricula <= 0)
                NotificarErro("Número matrícula deve ser maior que zero");

            if (TemNotificacao())
                return default;

            // Validar existencia de professor
            var prof = _professorRepository.Get(alunoRequest.ProfessorId);
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
            _repository.Insert(aluno);

            // Retornar
            return Map(aluno);
        }

        public AlunoResponse Update(AlunoUpdateRequest alunoRequest)
        {
            // Validar a Professor

            if (alunoRequest.Id == Guid.Empty)
                NotificarErro("Id não preenchido");

            if (string.IsNullOrWhiteSpace(alunoRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (alunoRequest.NumeroMatricula <= 0)
                NotificarErro("Número matrícula deve ser maior que zero");

            if (TemNotificacao())
                return default;

            // Validar se a Professor do Id existe
            var aln = Get(alunoRequest.Id);
            if (aln is null) return default;

            // Validar existencia de professor
            var prof = _professorRepository.Get(alunoRequest.ProfessorId);
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

            _repository.Update(aluno);

            return Map(aluno);
        }

        public void Delete(Guid id)
        {
            var aluno = _repository.Get(id);

            if (aluno is null)
            {
                NotificarErro("Aluno não encontrado");
                return;
            }
            _repository.Delete(aluno);
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
