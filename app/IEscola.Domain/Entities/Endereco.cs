using System;
using System.Collections.Generic;
using System.Text;

namespace IEscola.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public Endereco(Guid id, string logradouro, string bairro, string numero, string cep, string cidade, string uF)
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
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}
