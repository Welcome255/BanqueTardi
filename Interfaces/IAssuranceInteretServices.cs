using Assurance.ApplicationCore.Entites;
using BanqueTardi.DTO;
using BanqueTardi.Models;

namespace BanqueTardi.Interfaces
{
    public interface IAssuranceInteretServices
    {
      
        Task Ajouter(IEnumerable<InteretRequestDTO> interet);
       
    }
}
