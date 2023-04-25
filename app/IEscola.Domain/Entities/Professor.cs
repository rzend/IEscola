using System;
using System.Collections.Generic;

namespace IEscola.Domain.Entities
{
    public class Professor : EntityBase
    {
        public Professor(int id, string nome, string cpf, DateTime? dataNascimento)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento; 
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public IEnumerable<Aluno> Alunos { get; set; }
        public string Tratamento { get; set; }
    }
}
