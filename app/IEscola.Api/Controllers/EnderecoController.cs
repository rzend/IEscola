using IEscola.Api.DeafultResponse;
using IEscola.Application.HttpObjects.Aluno.Request;
using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.HttpObjects.Endereco.Request;
using IEscola.Application.HttpObjects.Endereco.Response;
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
    [ApiController]
    public class EnderecoController : MainController
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(INotificador notificador, IEnderecoService enderecoService) : base(notificador)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SimpleResponseObject<IEnumerable<EnderecoResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var list = await _enderecoService.GetAsync();
            return SimpleResponse(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<EnderecoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var endereco = await _enderecoService.GetAsync(id);

            return SimpleResponse(endereco);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SimpleResponseObject<EnderecoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] EnderecoInsertRequest endereco)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = await _enderecoService.InsertAsync(endereco);

            return SimpleResponse(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(SimpleResponseObject<EnderecoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put([FromBody] EnderecoUpdateRequest endereco)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = await _enderecoService.UpdateAsync(endereco);

            return SimpleResponse(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _enderecoService.DeleteAsync(id);

            return SimpleResponse();
        }
    }
}
