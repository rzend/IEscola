using IEscola.Application.HttpObjects.Professor.Request;
using IEscola.Application.HttpObjects.Professor.Response;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IEscola.Application.Services
{
    public class ProfessorService : ServiceBase, IProfessorService
    {
        private readonly IProfessorRepository _repository;

        public ProfessorService(IProfessorRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;
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
            var professor = new Professor(id, professorRequest.Nome, professorRequest.Cpf, professorRequest.DataNascimento)
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
            var professor = new Professor(professorRequest.Id, professorRequest.Nome, professorRequest.Cpf, professorRequest.DataNascimento)
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
        #endregion
    }
}
