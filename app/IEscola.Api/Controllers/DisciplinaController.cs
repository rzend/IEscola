using IEscola.Api.DeafultResponse;
using IEscola.Api.Filters;
using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    //[AuthorizationActionFilterAsync]
    public class DisciplinaController : MainController
    {

        private readonly IDisciplinaService _service;

        public DisciplinaController(IDisciplinaService service, 
            INotificador notificador) : base(notificador)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAsync()
        {
            var list = await _service.GetAsync();

            return SimpleResponse(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var disciplina = await _service.GetAsync(id);

            return SimpleResponse(disciplina);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PostAsync([FromBody] DisciplinaInsertRequest disciplina)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = await _service.InsertAsync(disciplina);

            return SimpleResponse(response);
        }

        [HttpPut()]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutAsync([FromBody] DisciplinaUpdateRequest disciplina)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = await _service.UpdateAsync(disciplina);

            return SimpleResponse(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return SimpleResponse();
        }
    }
}
