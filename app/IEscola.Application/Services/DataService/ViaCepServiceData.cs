using Flurl.Http;
using IEscola.Application.HttpObjects.ViaCep;
using IEscola.Application.Interfaces.DataService;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEscola.Application.Services.DataService
{
    public class ViaCepServiceData : IViaCepDataService
    {
        public async Task<ViaCepResponse> ExecutaConsultaCepAsync(string cep)
        {
            var url =  $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                //HttpClient client = new HttpClient();
                //var response = await client.GetAsync(url);

                //var result =  await response.Content.ReadAsStringAsync();
                //var jsonObject = JsonConvert.DeserializeObject<ViaCepResponse>(result);

                //return jsonObject;

                var flurResponse = await url
                    .AllowAnyHttpStatus()
                    .GetAsync();

                return await flurResponse.GetJsonAsync<ViaCepResponse>();

            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine($"Exception com statusCode: {ex.StatusCode}");
                return default;
            }
        }
    }
}
