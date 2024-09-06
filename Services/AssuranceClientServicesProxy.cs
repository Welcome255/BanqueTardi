using Assurance.ApplicationCore.Entites;
using BanqueTardi.DTO;
using BanqueTardi.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace BanqueTardi.Services
{
    public class AssuranceClientServicesProxy : IAssuranceClientServices
    {
        private readonly HttpClient _httpClient;
        private const string _assuranceClientApiUrl = "api/Assurances/";
        public AssuranceClientServicesProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Ajouter(AssuranceTardi Assurance)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Assurance), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(_assuranceClientApiUrl + "Creation", content);
        }

        public async Task Modifier(AssuranceTardi Assurance)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Assurance), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(_assuranceClientApiUrl + Assurance.ClientID, content);
        }

        public async Task<AssuranceTardi> Obtenir(int id)
        {
            return await _httpClient.GetFromJsonAsync<AssuranceTardi>(_assuranceClientApiUrl + id);
        }

        public async Task<List<AssuranceTardiDTO>> ObtenirTout()
        {
            return await _httpClient.GetFromJsonAsync<List<AssuranceTardiDTO>>(_assuranceClientApiUrl);
        }

        public async Task Supprimer(int id)
        {
            await _httpClient.DeleteAsync(_assuranceClientApiUrl + id); 
        }
        public async Task Confirmer(int id)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(new {statut = true}), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(_assuranceClientApiUrl+ "Confirmer/" + id, content );
        }
    }
}
