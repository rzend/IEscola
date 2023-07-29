using System;
using System.Collections.Generic;

namespace IEscola.Domain.Entities
{
    public class Professor : EntityBase
    {
        public Professor(Guid id, string nome, string cpf, DateTime? dataNascimento, Guid disciplinaId, Guid enderecoId)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            DisciplinaId = disciplinaId;
            EnderecoId = enderecoId;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public IEnumerable<Aluno> Alunos { get; set; }
        public Guid DisciplinaId { get; private set; }
        public Disciplina Disciplina { get; set; }
        public string Tratamento { get; set; }
        public Endereco Endereco { get; set; }
        public Guid EnderecoId { get; private set; }
    }
}
