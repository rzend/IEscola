using IEscola.Domain.Entities;
using IEscola.Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    public class DisciplinaController : MainController
    {


        // GET: api/<DisciplinaController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Disciplina>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var repository = new DisciplinaRepository();
            var list = repository.Get();

            return Ok(list);
        }

        // GET api/<DisciplinaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid id)
        {
            if (Guid.Empty == id)
                return BadRequest("id inválido");

            var repository = new DisciplinaRepository();
            var disciplina = repository.Get(id);

            return Ok(disciplina);
        }

        // POST api/<DisciplinaController>
        [HttpPost]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Disciplina disciplina, [FromHeader, Required] DadosLigacao dadosLigacao)
        {

            var repository = new DisciplinaRepository();
            repository.Insert(disciplina);

            return Ok(disciplina);
        }

        // PUT api/<DisciplinaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Put(Guid id, [FromBody] Disciplina disciplina)
        {
            var repository = new DisciplinaRepository();
            repository.Update(id, disciplina);

            return Ok(disciplina);
        }

        // DELETE api/<DisciplinaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {
            var repository = new DisciplinaRepository();
            var disciplina = repository.Get(id);

            repository.Delete(disciplina);

            return Ok();
        }
    }

    public class DadosLigacao
    {
        [FromHeader]
        [Required]
        public string CorrelationId { get; set; }

        [FromHeader]
        [Required]
        public string FlowId { get; set; }
    }
}
