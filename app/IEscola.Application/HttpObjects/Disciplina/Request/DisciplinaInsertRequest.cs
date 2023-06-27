using System.ComponentModel.DataAnnotations;

namespace IEscola.Application.HttpObjects.Disciplina.Request
{
    public class DisciplinaInsertRequest
    {
        [Required(ErrorMessage = "Nome não preenchido.")]
        [MinLength(3, ErrorMessage = "Nome deve ter mais que 3 caracteres")]
        [MaxLength(128, ErrorMessage = "Nome deve ter menos que 128 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descricao não preenchido.")]
        [MinLength(3, ErrorMessage = "Descricao deve ter mais que 3 caracteres")]
        [MaxLength(512, ErrorMessage = "Descricao deve ter menos que 512 caracteres")]
        public string Descricao { get; set; }
    }
}
