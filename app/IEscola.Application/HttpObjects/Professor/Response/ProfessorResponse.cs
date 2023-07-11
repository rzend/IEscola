using System;

namespace IEscola.Application.HttpObjects.Professor.Response
{
    public class ProfessorResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        
        public DateTime? DataNascimento { get; set; }
        public string Tratamento { get; set; }
        public bool Ativo { get; set; }
    }
}
