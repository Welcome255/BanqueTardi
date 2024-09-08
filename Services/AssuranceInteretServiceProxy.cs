using Assurance.ApplicationCore.Entites;
using BanqueTardi.DTO;
using BanqueTardi.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace BanqueTardi.Services
{
    public class AssuranceInteretServiceProxy: IAssuranceInteretServices
    {
        private readonly HttpClient _httpClient;
        private const string _assuranceClientApiUrl = "api/Assurances/";
        public AssuranceInteretServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Ajouter(IEnumerable<InteretRequestDTO> comptes)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(comptes), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(_assuranceClientApiUrl + "CalculInteret", content);
        }
    }
}
