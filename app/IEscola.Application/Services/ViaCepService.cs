using IEscola.Application.HttpObjects.ViaCep;
using IEscola.Application.Interfaces;
using IEscola.Application.Interfaces.DataService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IEscola.Application.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly IViaCepDataService _service;

        public ViaCepService(IViaCepDataService service)
        {
            _service = service;
        }

        public async Task<ViaCepResponse> RealizaConsultaCep(string cep)
        {
            return await _service.ExecutaConsultaCepAsync(cep);
        }
    }
}
