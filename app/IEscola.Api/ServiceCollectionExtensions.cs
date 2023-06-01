using IEscola.Application.Interfaces;
using IEscola.Application.Services;
using IEscola.Domain.Interfaces;
using IEscola.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IEscola.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIEscolaServices(this IServiceCollection services, IConfiguration configuration)
        {

            // Container de DI
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();

            services.AddScoped<INotificador, Notificador>();

            // Vida útil dos objetos na memória -> Quando a aplicação "subir"

            // services.AddSingleton -> Instancia única na memória()
            // services.AddScoped -> Instancia única na memória() durante a requisição
            // services.AddTransient -> Uma instancia nova por chamada(E não request)


            // Alerta Singleton não pode ter dependencia para Scoped
            return services;
        }
    }
}
