using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace IEscola.Application.Services
{
    public class DisciplinaService : ServiceBase, IDisciplinaService
    {
        IDisciplinaRepository _repository;
        INotificador _notificador;

        public DisciplinaService(IDisciplinaRepository repository, 
            INotificador notificador) : base(notificador)
        {
            _repository = repository;
            _notificador = notificador;
        }

        public IEnumerable<Disciplina> Get()
        {
            var list = _repository.Get();
            return list;
        }

        public Disciplina Get(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var disciplina = _repository.Get(id);
            return disciplina;
        }

        public void Insert(DisciplinaInsertRequest disciplinaRequest)
        {
            // Validar a disciplina
            if (string.IsNullOrWhiteSpace(disciplinaRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (string.IsNullOrWhiteSpace(disciplinaRequest.Descricao))
                NotificarErro("Descricao não preenchida");

            if (TemNotificacao())
                return;

            // Mapear para o objeto de domínio
            var disciplina = new Disciplina(Guid.NewGuid(), disciplinaRequest.Nome, disciplinaRequest.Descricao);
            disciplina.DataUltimaAlteracao = DateTime.UtcNow;
            disciplina.UsuarioUltimaAlteracao = "antonio";
            disciplina.UsuarioCadastro = "antonio";

            // Processar
            _repository.Insert(disciplina);

            // Retornar
        }

        public void Update(Guid id, Disciplina disciplina)
        {
            _repository.Update(id, disciplina);
        }

        public void Delete(Disciplina disciplina)
        {
            _repository.Delete(disciplina);
        }
    }
}
