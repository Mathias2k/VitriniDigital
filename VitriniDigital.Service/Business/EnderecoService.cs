using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VitriniDigital.Domain.Config;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.Service.Business
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepo;
        private readonly IHttpClienteService _httpClienteService;
        private readonly ApiConfiguration _configuration;
        public EnderecoService(IEnderecoRepository enderecoRepo,
                               IHttpClienteService httpClienteService,
                               ApiConfiguration configuration)
        {
            _enderecoRepo = enderecoRepo;
            _httpClienteService = httpClienteService;
            _configuration = configuration;
        }
        public async Task<string> AddEnderecoAsync(EnderecoDTO endDto)
        {
            var endereco = Endereco.EnderecoFactory.AdicionarEstabelecimento(endDto);

            //get lat and long
            var localizacaoGoogle = await GetLatituteAndLongitudeAsync(endDto);

            if (localizacaoGoogle != null)
                if (localizacaoGoogle.results.Any())
                {
                    endereco.Latitude = localizacaoGoogle.results[0].geometry.location.lat.ToString() ?? "00000";
                    endereco.Longitude = localizacaoGoogle.results[0].geometry.location.lng.ToString() ?? "00000";
                }

            //get cep
            if (string.IsNullOrEmpty(endDto.CEP))
            {
                var lstCeps = await GetCEPAsync(endDto);
                if (lstCeps.Any())
                    endereco.CEP = lstCeps.FirstOrDefault().cep.Replace("-", "");
                else
                    endereco.CEP = "00000000";
            }

            return await _enderecoRepo.InsertAsync(endereco);
        }
        public async Task<Endereco> GetEnderecoByIdAsync(string idEnd)
        {
            return await _enderecoRepo.SelectByIdAsync(idEnd);
        }
        public async Task UpdateEnderecoAsync(Endereco endereco)
        {
            await _enderecoRepo.UpdateAsync(endereco);
        }
        private async Task<GoogleMapsResponse> GetLatituteAndLongitudeAsync(EnderecoDTO endDto)
        {
            string urlGetLocalizacao = _configuration.UrlGetLocalizacao.Replace("LOCREPLACE", endDto.Logradouro);
            var response = await _httpClienteService.HttpClientGetAsync(urlGetLocalizacao);

            return JsonSerializer.Deserialize<GoogleMapsResponse>(response.Content.ReadAsStream());
        }
        private async Task<List<CepResponse>> GetCEPAsync(EnderecoDTO endDto)
        {
            string urlGetCEP = _configuration.UrlGetCEP
                                    .Replace("UFREPLACE", endDto.UF)
                                    .Replace("CIDADEREPLACE", endDto.Cidade)
                                    .Replace("LOGRADOUROREPLACE", endDto.Logradouro);

            var response = await _httpClienteService.HttpClientGetAsync(urlGetCEP);
            return JsonSerializer.Deserialize<List<CepResponse>>(response.Content.ReadAsStream());
        }

        //public async Task DeleteEnderecoAsync(string id)
        //{
        //    await _enderecoRepo.DeleteAsync(id);
        //}
    }
}