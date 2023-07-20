using IEscola.Application.Interfaces;
using IEscola.Application.Services;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using IEscola.Tests.Fixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IEscola.Tests
{
    [Collection(nameof(DisciplinaCollection))]
    public class DisciplinaServiceTests
    {
        readonly DisciplinaFixtureTest _disciplinaFixtureTest;

        public DisciplinaServiceTests(DisciplinaFixtureTest disciplinaFixtureTest)
        {
            _disciplinaFixtureTest = disciplinaFixtureTest;
        }

        [Fact(DisplayName = "Disciplina deve estar válida")]
        [Trait("Disciplina", "Disciplina Fixture Tests")]
        public async Task DisciplinaService_InsertDisciplina_DeveRetornarSucesso()
        {
            // Arrange
            var disciplinaInsert = _disciplinaFixtureTest.GerarDisciplinaInsertValida();
            var disciplinaRepo = new Mock<IDisciplinaRepository>();
            var notificador = new Mock<INotificador>();

            var disciplinaService = new DisciplinaService(disciplinaRepo.Object, notificador.Object);

            // Act
            var resultado = await disciplinaService.InsertAsync(disciplinaInsert);


            // Assert
            Assert.False(disciplinaService.TemNotificacao());
            disciplinaRepo.Verify(r => r.InsertAsync(It.IsAny<Disciplina>()));
        }
    }
}
