using IEscola.Api.Filters;
using IEscola.Application.Interfaces;
using IEscola.Application.Interfaces.DataService;
using IEscola.Application.Services;
using IEscola.Application.Services.DataService;
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
            services.AddHttpContextAccessor();
            //var settings = configuration.GetSection("Settings").Get<Settings>();
            services.Configure<Settings>(configuration.GetSection("Settings"));

            services.AddSingleton<ISettings, Settings>();

            services.AddScoped<ISettingsService, SettingsService>();

            // Services
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IViaCepService, ViaCepService>();


            // Repositories
            services.AddSingleton<IDisciplinaRepository, DisciplinaRepository>();
            services.AddSingleton<IProfessorRepository, ProfessorRepository>();
            services.AddSingleton<IAlunoRepository, AlunoRepository>();
            services.AddSingleton<IEnderecoRepository, EnderecoRepository>();


            // Outros objetos
            services.AddScoped<INotificador, Notificador>();


            // ActionFilter
            services.AddScoped<AuthorizationActionFilterAsyncAttribute>();

            // Data Services
            services.AddScoped<IViaCepDataService, ViaCepServiceData>();

            // Vida útil dos objetos na memória -> Quando a aplicação "subir"

            // services.AddSingleton -> Instancia única na memória()
            // services.AddScoped -> Instancia única na memória() durante a requisição
            // services.AddTransient -> Uma instancia nova por chamada(E não request)


            // Alerta Singleton não pode ter dependencia para Scoped
            return services;
        }
    }
}
