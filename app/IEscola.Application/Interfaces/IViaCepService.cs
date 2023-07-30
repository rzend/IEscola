using IEscola.Application.HttpObjects.ViaCep;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IEscola.Application.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCepResponse> RealizaConsultaCep(string cep);
    }
}
