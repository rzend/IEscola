using System;

namespace IEscola.Application.HttpObjects.Disciplina.Request
{
    public class DisciplinaUpdateRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
