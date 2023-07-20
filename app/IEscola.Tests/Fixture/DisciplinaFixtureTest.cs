using IEscola.Application.HttpObjects.Disciplina.Request;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IEscola.Tests.Fixture
{
    [CollectionDefinition(nameof(DisciplinaCollection))]
    public class DisciplinaCollection : ICollectionFixture<DisciplinaFixtureTest> { }

    public class DisciplinaFixtureTest : IDisposable
    {
        public DisciplinaInsertRequest GerarDisciplinaInsertValida()
        {
            return new DisciplinaInsertRequest
            {
                Nome = "Matemática",
                Descricao = "A melhor de todas"
            };
        }

        public DisciplinaInsertRequest GerarDisciplinaInsertInvalida()
        {
            return new DisciplinaInsertRequest
            {
                Nome = "Ma",
                Descricao = "A"
            };
        }

        public void Dispose() { }
    }
}
