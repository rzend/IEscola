using System;

namespace IEscola.Application.HttpObjects.Aluno.Response
{
    public class AlunoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid ProfessorId { get; set; }

        public int NumeroMatricula { get; set; }

        public DateTime? DataNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
