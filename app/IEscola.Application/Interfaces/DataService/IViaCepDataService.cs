using IEscola.Application.HttpObjects.ViaCep;
using System.Threading.Tasks;

namespace IEscola.Application.Interfaces.DataService
{
    public interface IViaCepDataService
    {
        Task<ViaCepResponse> ExecutaConsultaCepAsync(string cep);
    }
}
