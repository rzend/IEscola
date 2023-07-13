using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using IEscola.Application.Interfaces;
using IEscola.Application.HttpObjects.Disciplina.Request;
using Microsoft.AspNetCore.Http;
using IEscola.Application.HttpObjects.Professor.Response;
using IEscola.Api.DeafultResponse;
using IEscola.Application.HttpObjects.Professor.Request;
using IEscola.Api.Filters;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [AuthorizationActionFilterAsync]
    public class ProfessorController : MainController
    {
        private readonly IProfessorService _service;

        public ProfessorController(INotificador notificador, IProfessorService professorService) : base(notificador)
        {
            _service = professorService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SimpleResponseObject<IEnumerable<ProfessorResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public IActionResult Get()
        {
            var list = _service.Get();
            return SimpleResponse(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<ProfessorResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public IActionResult Get(Guid id)
        {
            var professor = _service.Get(id);

            return SimpleResponse(professor);
        }

        [HttpGet("FullResponse/{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<ProfessorFullResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> FullResponse(Guid id)
        {
            var professor = await _service.GetFullAsync(id);

            return SimpleResponse(professor);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SimpleResponseObject<ProfessorResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public IActionResult Post([FromBody] ProfessorInsertRequest professor)
        {

            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = _service.Insert(professor);

            return SimpleResponse(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(SimpleResponseObject<ProfessorResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public IActionResult Put([FromBody] ProfessorUpdateRequest professor)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = _service.Update(professor);

            return SimpleResponse(response);
        }

        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return SimpleResponse();
        }
    }
}
