using System;

namespace IEscola.Domain.Entities
{
    public class Aluno : EntityBase
    {
        public Aluno(Guid id, string nome, DateTime dataNascimento, int numeroMatricula, Guid professorId)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            NumeroMatricula = numeroMatricula;
            ProfessorId = professorId;
        }

        public string Nome { get; private set; }
        public DateTime? DataNascimento { get; private set; }

        public Guid ProfessorId { get; private set; }

        public int NumeroMatricula { get; set; }


        public void SetProfessorId(Guid professorId)
        {
            ProfessorId = professorId;
        }
    }
}
