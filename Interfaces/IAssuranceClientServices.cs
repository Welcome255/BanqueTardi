using Assurance.ApplicationCore.Entites;
using BanqueTardi.DTO;

namespace BanqueTardi.Interfaces
{
    public interface IAssuranceClientServices
    {
        Task<List<AssuranceTardiDTO>> ObtenirTout();
        Task<AssuranceTardi> Obtenir(int id);
        Task Ajouter(AssuranceTardi Assurance);
        Task Supprimer(int id);
        Task Modifier(AssuranceTardi Assurance);
        Task Confirmer(int id);
    }
}
