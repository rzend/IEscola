using System;
using System.ComponentModel.DataAnnotations;

namespace IEscola.Application.HttpObjects.Professor.Request
{
    public class ProfessorInsertRequest
    {
        [Required(ErrorMessage = "Nome não preenchido.")]
        [MinLength(3, ErrorMessage = "Nome deve ter mais que 3 caracteres")]
        [MaxLength(128, ErrorMessage = "Nome deve ter menos que 128 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cpf não preenchido.")]
        [MinLength(11, ErrorMessage = "Cpf deve ter 11 algarimos")]
        [MaxLength(11, ErrorMessage = "Cpf deve ter 11 algarimos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "DataNascimento não preenchido.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Tratamento não preenchido.")]
        [MinLength(3, ErrorMessage = "Tratamento deve ter mais que 3 caracteres")]
        [MaxLength(15, ErrorMessage = "Tratamento deve ter menos que 15 caracteres")]
        public string Tratamento { get; set; }

        [Required(ErrorMessage = "DisciplinaIdId não preenchido.")]
        public Guid DisciplinaId { get; set; }
    }
}
