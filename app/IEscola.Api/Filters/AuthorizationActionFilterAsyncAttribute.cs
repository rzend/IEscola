using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Flurl.Http;

namespace IEscola.Api.Filters
{
    public class AuthorizationActionFilterAsyncAttribute : Attribute, IAsyncActionFilter
    {
        private const string API_KEY = "api-key";
        private const string AUTHORIZATION = "Authorization";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _settingsService = (ISettingsService)context.HttpContext.RequestServices.GetService(typeof(ISettingsService));

            if (!context.HttpContext.Request.Headers.TryGetValue(API_KEY, out var extractedApiKey))
            {
                MakeErroApiKeyNaoPreenchida(context);
                return;
            }

            if (extractedApiKey != _settingsService.GetSettings().MyApiKey)
            {
                MakeErroApiKeyNaoPreenchida(context);
                return;
            }


            if (!context.HttpContext.Request.Headers.TryGetValue(AUTHORIZATION, out var token))
            {
                MakeErroTokenInvalido(context);
                return;
            }

            if (!await TokenIsValidAsync(token))
            {
                MakeErroTokenInvalido(context);
                return;
            }

            await next();
        }

        private static void MakeErroTokenInvalido(ActionExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                StatusCode = 403,
                Content = "Token inválido"
            };
        }

        private static void MakeErroApiKeyNaoPreenchida(ActionExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                StatusCode = 403,
                Content = "ApiKey não encontrada ou inválida"
            };
        }

        public async Task<bool> TokenIsValidAsync(string token)
        {
            try
            {
                var flurResponse = await "http://localhost:3683/api/Auth/authenticated"
                        .AllowAnyHttpStatus()
                        .WithOAuthBearerToken(token.ToCleanToken())
                        .GetAsync();

                return flurResponse.StatusCode >= 200 && flurResponse.StatusCode < 300;
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine($"Exception com statusCode: {ex.StatusCode}");
                return false;
            }
        }
        // Flurl -> Fluent url
    }
}
