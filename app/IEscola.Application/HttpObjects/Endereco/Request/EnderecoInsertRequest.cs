using System.ComponentModel.DataAnnotations;

namespace IEscola.Application.HttpObjects.Endereco.Request
{
    public class EnderecoInsertRequest
    {
        [Required(ErrorMessage = "Logradouro não preenchido.")]
        [MinLength(2, ErrorMessage = "Logradouro deve ter mais que 2 caracteres")]
        [MaxLength(128, ErrorMessage = "Logradouro deve ter menos que 128 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Bairro não preenchido.")]
        [MinLength(5, ErrorMessage = "Nome deve ter mais que 5 caracteres")]
        [MaxLength(128, ErrorMessage = "Nome deve ter menos que 128 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Número não preenchido.")]
        [MinLength(1, ErrorMessage = "Número deve ter 1 algarimos")]
        [MaxLength(10, ErrorMessage = "Número deve ter 10 algarimos")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Cep não preenchido.")]
        [MinLength(9, ErrorMessage = "Cep deve ter 9 algarimos, certifique-se de digitar da forma correta, usando hifen")]
        [MaxLength(9, ErrorMessage = "Cep deve ter 9 algarimos, certifique-se de digitar da forma correta, usando hifen")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Cidade não preenchido.")]
        [MinLength(3, ErrorMessage = "Cidade deve ter mais que 3 caracteres")]
        [MaxLength(128, ErrorMessage = "Cidade deve ter menos que 128 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "UF não preenchido.")]
        [MinLength(1, ErrorMessage = "UF deve ter mais que 1 caracteres")]
        [MaxLength(2, ErrorMessage = "UF deve ter menos que 2 caracteres")]
        public string UF { get; set; }
    }
}
