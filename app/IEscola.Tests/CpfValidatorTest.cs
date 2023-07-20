using IEscola.Application.Services.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IEscola.Tests
{
    public class CpfValidatorTest
    {
        [Fact(DisplayName = "Cpf válido")]
        [Trait("Cpf", "Cpf válido")]
        public void CpfValidator_ValidarCpf_CpfValido()
        {
            // Arrange
            string cpf = "14736092084";

            // Act
            var resultado = CpfValidator.ValidarCPF(cpf);

            // Assert
            Assert.True(resultado);
        }

        // Cpf inválido
        // 

        [Theory(DisplayName = "Valida lista e Cpfs")]
        [Trait("Cpf", "Cpf invalido")]
        [InlineData("")]
        [InlineData("2986745989")]
        [InlineData("29867459891")]
        [InlineData("298674598J1")]
        [InlineData("11111111111")]
        public void CpfValidator_ValidarCpf_CpfInvalido(string cpf) 
        {
            // Arrange
            //string cpf = "14736092084";

            // Act
            var resultado = CpfValidator.ValidarCPF(cpf);

            // Assert
            Assert.False(resultado);
        }

        [Theory(DisplayName = "Valida lista e Cpfs")]
        [Trait("Cpf", "Cpf invalido")]
        [InlineData("", false)]
        [InlineData("14736092084", true)]
        [InlineData("29867459891", false)]
        [InlineData("298674598J1", false)]
        [InlineData("11111111111", false)]
        public void CpfValidator_ValidarCpf_RetornaCpfvalidos(string cpf, bool cpfValido)
        {
            // Arrange
            //string cpf = "14736092084";

            // Act
            var resultado = CpfValidator.ValidarCPF(cpf);

            // Assert
            Assert.Equal(resultado, cpfValido);
        }
    }
}
