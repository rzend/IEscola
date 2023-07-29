using System;
using System.Collections.Generic;
using System.Text;

namespace IEscola.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public Endereco(Guid id, string logradouro, string bairro, int numero, int cep, string cidade, string uF)
        {
            Id = id;
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Cep = cep;
            Cidade = cidade;
            UF = uF;
        }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}
