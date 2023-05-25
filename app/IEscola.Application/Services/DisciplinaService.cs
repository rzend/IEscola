using IEscola.Domain.Entities;
using IEscola.Infra.Repositories;
using System;
using System.Collections.Generic;

namespace IEscola.Application.Services
{
    public class DisciplinaService
    {
        DisciplinaRepository _repository;
        public DisciplinaService()
        {
            _repository = new DisciplinaRepository();
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
