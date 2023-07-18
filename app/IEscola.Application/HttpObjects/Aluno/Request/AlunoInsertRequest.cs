using System;
using System.ComponentModel.DataAnnotations;

namespace IEscola.Application.HttpObjects.Aluno.Request
{
    public class AlunoInsertRequest
    {
        [Required(ErrorMessage = "Nome não preenchido.")]
        [MinLength(3, ErrorMessage = "Nome deve ter mais que 3 caracteres")]
        [MaxLength(128, ErrorMessage = "Nome deve ter menos que 128 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "NumeroMatricula não preenchido.")]
        [Range(1, int.MaxValue, ErrorMessage = "NumeroMatricula deve ser maior que 0")]
        public int NumeroMatricula { get; set; }

        [Required(ErrorMessage = "DataNascimento não preenchido.")]
        [DataType(DataType.DateTime, ErrorMessage = "DataNascimento em formato inválido")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "ProfessorId não preenchido.")]
        public Guid ProfessorId { get; set; }
    }
}
