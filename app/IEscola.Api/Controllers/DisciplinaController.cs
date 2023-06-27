using IEscola.Api.DeafultResponse;
using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    public class DisciplinaController : MainController
    {

        private readonly IDisciplinaService _service;

        public DisciplinaController(IDisciplinaService service, 
            INotificador notificador) : base(notificador)
        {
            _service = service;
        }

        // GET: api/<DisciplinaController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DisciplinaResponse>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var list = _service.Get();

            return SimpleResponse(list);
        }

        // GET api/<DisciplinaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid id)
        {
            var disciplina = _service.Get(id);

            return SimpleResponse(disciplina);
        }

        // POST api/<DisciplinaController>
        [HttpPost]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] DisciplinaInsertRequest disciplina)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = _service.Insert(disciplina);

            return SimpleResponse(response);
        }

        // PUT api/<DisciplinaController>/5
        [HttpPut()]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] DisciplinaUpdateRequest disciplina)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = _service.Update(disciplina);

            return SimpleResponse(response);
        }

        // DELETE api/<DisciplinaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {
            var disciplina = _service.Get(id);

            //_service.Delete(disciplina);

            return SimpleResponse();
        }
    }
}
