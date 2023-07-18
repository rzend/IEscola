using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Application.Services
{
    public class DisciplinaService : ServiceBase, IDisciplinaService
    {
        readonly IDisciplinaRepository _repository;

        public DisciplinaService(IDisciplinaRepository repository,
            INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DisciplinaResponse>> GetAsync()
        {
            var list = await _repository.GetAsync();

            return list.Select(d => Map(d));
        }

        public async Task<DisciplinaResponse> GetAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var disciplina = await _repository.GetAsync(id);

            if (disciplina is null)
            {
                NotificarErro("Disciplina não encontrada");
                return default;
            };

            // Retornar
            return Map(disciplina);
        }

        public async Task<DisciplinaResponse> InsertAsync(DisciplinaInsertRequest disciplinaRequest)
        {
            // Validar a disciplina
            if (string.IsNullOrWhiteSpace(disciplinaRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (string.IsNullOrWhiteSpace(disciplinaRequest.Descricao))
                NotificarErro("Descricao não preenchida");

            if (TemNotificacao())
                return default;

            // Mapear para o objeto de domínio
            var id = Guid.NewGuid();
            var disciplina = new Disciplina(id, disciplinaRequest.Nome, disciplinaRequest.Descricao)
            {
                DataUltimaAlteracao = DateTime.UtcNow,
                UsuarioUltimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            // Processar
            await _repository.InsertAsync(disciplina);

            // Retornar
            return Map(disciplina);
        }

        public async Task<DisciplinaResponse> UpdateAsync(DisciplinaUpdateRequest disciplinaRequest)
        {
            // Validar a disciplina

            if (disciplinaRequest.Id == Guid.Empty)
                NotificarErro("Id não preenchido");

            if (string.IsNullOrWhiteSpace(disciplinaRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (string.IsNullOrWhiteSpace(disciplinaRequest.Descricao))
                NotificarErro("Descricao não preenchida");

            if (TemNotificacao())
                return default;

            // Validar se a disciplina do Id existe
            var disc = await GetAsync(disciplinaRequest.Id);
            if (disc is null) return default;

            var disciplina = new Disciplina(disciplinaRequest.Id, disciplinaRequest.Nome, disciplinaRequest.Descricao)
            {
                DataUltimaAlteracao = DateTime.UtcNow,
                UsuarioUltimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            if (disciplinaRequest.Ativo)
                disciplina.Ativar();
            else
                disciplina.Inativar();

            await _repository.UpdateAsync(disciplina);

            return Map(disciplina);
        }

        public async Task DeleteAsync(Guid id)
        {
            var disciplina =  await _repository.GetAsync(id);

            if (disciplina is null)
            {
                NotificarErro("Disciplina não encontrada");
                return;
            }

            await _repository.DeleteAsync(disciplina);
        }

        #region Private Methods
        private static DisciplinaResponse Map(Disciplina disciplina)
        {
            return new DisciplinaResponse
            {
                Id = disciplina.Id,
                Nome = disciplina.Nome,
                Descricao = disciplina.Descricao,
                Ativo = disciplina.Ativo
            };
        }
        #endregion
    }
}
