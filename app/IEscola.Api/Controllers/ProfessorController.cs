using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using IEscola.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using IEscola.Application.HttpObjects.Professor.Response;
using IEscola.Api.DeafultResponse;
using IEscola.Application.HttpObjects.Professor.Request;
using IEscola.Api.Filters;
using System.Threading.Tasks;


namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    //[AuthorizationActionFilterAsync]
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
        public async Task<IActionResult> Get()
        {
            var list = await _service.GetAsync();
            return SimpleResponse(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<ProfessorResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(Guid id)
        {
            var professor = await _service.GetAsync(id);

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
        public async Task<IActionResult> Post([FromBody] ProfessorInsertRequest professor)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = await _service.InsertAsync(professor);

            return SimpleResponse(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(SimpleResponseObject<ProfessorResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put([FromBody] ProfessorUpdateRequest professor)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = await _service.UpdateAsync(professor);

            return SimpleResponse(response);
        }

        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);

            return SimpleResponse();
        }
    }
}
