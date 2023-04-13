using System;
using System.Collections.Generic;
using System.Text;

namespace IEscola.Domain.Entities
{
    public class Professor
    {
        public Professor(int id, string nome, string cpf, DateTime? dataNascimento)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }

        public void Inativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
