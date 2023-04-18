using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private List<Professor> professorList = new List<Professor> {
            new Professor(1, "Antonio", "01234567890", new DateTime(1990, 2, 27)),
            new Professor(2, "José", "22222222222", new DateTime(1985, 2, 21)),
            new Professor(3, "João", "11111111111", new DateTime(1983, 12, 31)),
            new Professor(4, "Maria", "01234567800", new DateTime(1989, 3, 15))
        };


        // GET: api/<ProfessorController>
        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            return Ok(professorList);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public ActionResult<Professor> Get(int id)
        {
            if (id <= 0)
                return BadRequest("id deve ser maior que zero");

            var professor = professorList.FirstOrDefault(p => p.Id == id);
            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
