using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProfessorController : MainController
    {
        private List<Professor> professorList = new List<Professor> {
            new Professor(Guid.Parse("36062FEB-2011-4142-BC38-48413606BC94"), "Antonio", "01234567890", new DateTime(1990, 2, 27)),
            new Professor(Guid.Parse("EB093931-E526-4EAB-B444-D9ED7B583F43"), "José", "22222222222", new DateTime(1985, 2, 21)),
            new Professor(Guid.Parse("3BF8376A-2E89-4B28-91B5-FA9999BBD1A3"), "João", "11111111111", new DateTime(1983, 12, 31)),
            new Professor(Guid.Parse("1A4559C2-F0E1-4010-9AEA-6B03D07C22BB"), "Maria", "01234567800", new DateTime(1989, 3, 15))
        };


        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(professorList);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        // [ProducesResponseType(Type = typeof(IEnumerable<Professor>), StatusCode = 200)] // TODO: Verificar o motivo do erro
        public IActionResult Get(Guid id)
        {
            if  ( Guid.Empty == id)
                return BadRequest("id inválido");

            var professor = professorList.FirstOrDefault(p => p.Id == id);
            if (professor != null)
                professor.Tratamento = Constantes.TratamentoProfessor;

            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {


            return Ok();
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Professor professor)
        {
            return Ok();
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
