using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IEscola.Application.HttpObjects.ViaCep
{
    public  class ViaCepResponse
    {
        [JsonProperty("logradouro")]
        public string logradouro { get; set; }

        [JsonProperty("bairro")]
        public string bairro { get; set; }

        [JsonProperty("complemento")]
        public string complemento { get; set; }

        [JsonProperty("localidade")]
        public string localidade { get; set; }

        [JsonProperty("numero")]
        public string numero { get; set; }

        [JsonProperty("cep")]
        public string cep { get; set; }

        [JsonProperty("cidade")]
        public string cidade { get; set; }

        [JsonProperty("uf")]
        public string uf { get; set; }

        [JsonProperty("ibge")]
        public string ibge { get; set; }

        [JsonProperty("gia")]
        public string gia { get; set; }

        [JsonProperty("ddd")]
        public string ddd { get; set; }

        [JsonProperty("siafi")]
        public string siafi { get; set; }
    }
}
