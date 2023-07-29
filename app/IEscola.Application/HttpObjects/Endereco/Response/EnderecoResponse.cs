using System;

namespace IEscola.Application.HttpObjects.Endereco.Response
{
    public class EnderecoResponse
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
