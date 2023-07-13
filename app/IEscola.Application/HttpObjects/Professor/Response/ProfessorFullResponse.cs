using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.HttpObjects.Disciplina.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEscola.Application.HttpObjects.Professor.Response
{
    public class ProfessorFullResponse : ProfessorResponse
    {
        public DisciplinaResponse Disciplina { get; set; }

        public IEnumerable<AlunoResponse> Alunos { get; set; }
    }
}
