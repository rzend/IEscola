using IEscola.Application.HttpObjects.Endereco.Request;
using IEscola.Application.HttpObjects.Endereco.Response;
using IEscola.Application.HttpObjects.ViaCep;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Application.Services
{
    public class EnderecoService : ServiceBase, IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IViaCepService _viaCepService;

        public EnderecoService(INotificador notificador, IEnderecoRepository repository, IViaCepService viaCepService) : base(notificador)
        {
            _repository = repository;
            _viaCepService = viaCepService;
        }

        public async Task<IEnumerable<EnderecoResponse>> GetAsync()
        {
            var list = await _repository.GetAsync();

            return list.Select(d => Map(d));
        }

        public async Task<EnderecoResponse> GetAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var endereco = await _repository.GetAsync(id);

            if (endereco is null)
            {
                NotificarErro("Aluno não encontrado");
                return default;
            };

            return Map(endereco);
        }

        public async Task<EnderecoResponse> InsertAsync(EnderecoInsertRequest enderecoRequest)
        {
            ValidaEndereco(enderecoRequest);

            await ValidarCep(enderecoRequest);

            var id = Guid.NewGuid();
            var endereco = new Endereco(id, enderecoRequest.Logradouro, enderecoRequest.Bairro, enderecoRequest.Numero, enderecoRequest.Cep, enderecoRequest.Cidade, enderecoRequest.UF);

            await _repository.InsertAsync(endereco);

            // Retornar
            return Map(endereco);
        }        

        public async Task<EnderecoResponse> UpdateAsync(EnderecoUpdateRequest enderecoRequest)
        {
            if (enderecoRequest.Id == Guid.Empty)
                NotificarErro("Id não preenchido");

            ValidaEnderecoUpdate(enderecoRequest);

            await ValidarCep(enderecoRequest);          
           
            var endereco = new Endereco(enderecoRequest.Id, enderecoRequest.Logradouro, enderecoRequest.Bairro, enderecoRequest.Numero, enderecoRequest.Cep, enderecoRequest.Cidade, enderecoRequest.UF);

            await _repository.UpdateAsync(endereco);

            // Retornar
            return Map(endereco);
        }

        public async Task DeleteAsync(Guid id)
        {
            var endereco = await _repository.GetAsync(id);

            if (endereco is null)
            {
                NotificarErro("Aluno não encontrado");
                return;
            }

            await _repository.DeleteAsync(endereco);
        }

        #region Private Methods
        private static EnderecoResponse Map(Endereco endereco)
        {
            return new EnderecoResponse
            {
                Id = endereco.Id,
                Logradouro = endereco.Logradouro,
                Bairro = endereco.Bairro,
                Numero = endereco.Numero,
                Cep = endereco.Cep,
                Cidade = endereco.Cidade,
                UF = endereco.UF
            };
        }

        private void ValidaEndereco(EnderecoInsertRequest enderecoRequest)
        {
            if (string.IsNullOrWhiteSpace(enderecoRequest.Logradouro))
                NotificarErro("Logradouro não preenchido");

            if (string.IsNullOrWhiteSpace(enderecoRequest.Bairro))
                NotificarErro("Bairro não preenchido");

            if (string.IsNullOrWhiteSpace(enderecoRequest.Numero.ToString()))
                NotificarErro("Número não preenchido");

            if (string.IsNullOrWhiteSpace(enderecoRequest.Cep.ToString()))
                NotificarErro("Cep não preenchido");

            if (string.IsNullOrWhiteSpace(enderecoRequest.Cidade))
                NotificarErro("Cidade não preenchida");

            if (string.IsNullOrWhiteSpace(enderecoRequest.UF))
                NotificarErro("UF não preenchida");
        }

        private void ValidaEnderecoUpdate(EnderecoUpdateRequest enderecoRequest)
        {
            if (string.IsNullOrWhiteSpace(enderecoRequest.Logradouro))
                NotificarErro("Logradouro não preenchido");

            if (string.IsNullOrWhiteSpace(enderecoRequest.Bairro))
                NotificarErro("Bairro não preenchido");

            if (string.IsNullOrWhiteSpace(enderecoRequest.Numero.ToString()))
                NotificarErro("Número não preenchido");

            if (string.IsNullOrWhiteSpace(enderecoRequest.Cep.ToString()))
                NotificarErro("Cep não preenchido");

            if (string.IsNullOrWhiteSpace(enderecoRequest.Cidade))
                NotificarErro("Cidade não preenchida");

            if (string.IsNullOrWhiteSpace(enderecoRequest.UF))
                NotificarErro("UF não preenchida");
        }
        private async Task ValidarCep(EnderecoInsertRequest enderecoRequest)
        {
            var validaCep = await _viaCepService.RealizaConsultaCep(enderecoRequest.Cep);

            if (!validaCep.cep.Equals(enderecoRequest.Cep))
                NotificarErro("Cep não encontrado");
        }

        private async Task ValidarCep(EnderecoUpdateRequest enderecoRequest)
        {
            var validaCep = await _viaCepService.RealizaConsultaCep(enderecoRequest.Cep);

            if (!validaCep.cep.Equals(enderecoRequest.Cep))
                NotificarErro("Cep não encontrado");
        }

        #endregion
    }
}
