using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.HttpObjects.Endereco.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEscola.Application.HttpObjects.Professor.Response
{
    public class ProfessorFullResponse : ProfessorResponse
    {
        public DisciplinaResponse Disciplina { get; set; }
        public EnderecoResponse Endereco { get; set; }
        public IEnumerable<AlunoResponse> Alunos { get; set; }
    }
}
