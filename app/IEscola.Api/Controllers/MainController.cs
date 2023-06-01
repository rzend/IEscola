using IEscola.Api.DeafultResponse;
using IEscola.Application;
using IEscola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult SimpleResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new SimpleResponseObject
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new SimpleResponseObject
            {
                Success = false,
                Errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });

        }

        protected ActionResult SimpleResponseError(int statusCode, object result = null)
        {
            return StatusCode(statusCode, new SimpleResponseObject
            {
                Success = false,
                Data = result,
                Errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult SimpleResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return SimpleResponse();
        }

        private void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
