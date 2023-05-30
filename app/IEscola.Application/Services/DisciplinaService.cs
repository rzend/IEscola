using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace IEscola.Application.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        IDisciplinaRepository _repository;

        public DisciplinaService(IDisciplinaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Disciplina> Get()
        {
            var list = _repository.Get();
            return list;
        }

        public Disciplina Get(Guid id)
        {
            var disciplina = _repository.Get(id);
            return disciplina;
        }

        public void Insert(Disciplina disciplina)
        {
            _repository.Insert(disciplina);
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
