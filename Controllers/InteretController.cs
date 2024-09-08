using BanqueTardi.ContexteDb;
using BanqueTardi.DTO;
using BanqueTardi.Interfaces;
using BanqueTardi.Models;
using BanqueTardi.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanqueTardi.Controllers
{
    public class InteretController : Controller
    {
        private readonly IAssuranceInteretServices _assuranceInteretServices;
        private readonly BanqueTardiContexte _contexte;
        public InteretController(IAssuranceInteretServices interetServices, BanqueTardiContexte contexte)
        {
            _assuranceInteretServices = interetServices;
            _contexte = contexte;
        }
        // GET: InteretController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InteretController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InteretController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InteretController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InteretController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InteretController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InteretController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InteretController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Envoyer()
        {
            List<Client> listeClients = _contexte.Clients.ToList();
            foreach (Client client in listeClients)
            {
                List<InteretRequestDTO> listeObjetInteretDTODuClient = new List<InteretRequestDTO>();
                var Donnee = DonneeGeneraleClient(client.ClientID);
                foreach (Compte compte in Donnee.Comptes)
                {
                    InteretRequestDTO interetCompteDTO = new InteretRequestDTO()
                    {
                        ClientID = client.ClientID,
                        Montant = compte.Solde,
                        DateFin = DateTime.Now,
                        DateDebutCalcul = (compte.Operations.Any(op => op.Libelle == "Intêret")) ? compte.Operations.Last(op => op.Libelle == "Intéret").DateTransaction : compte.Operations.First().DateTransaction,
                        TauxInteret = compte.TauxInteret,
                    };
                    listeObjetInteretDTODuClient.Add(interetCompteDTO);
                }
                _assuranceInteretServices.Ajouter(listeObjetInteretDTODuClient);

            }
            return RedirectToAction(nameof(Index), controllerName: "Comptes");
        }

        public BanqueIndexData DonneeGeneraleClient(string id)
        {
            BanqueIndexData viewModel = new BanqueIndexData();
            viewModel.Client = _contexte.Clients
                .AsNoTracking()
                .Include(c => c.Comptes)
                !.ThenInclude(cpt => cpt.Operations)
                .Where(c => c.ClientID == id).Single();

            viewModel.Comptes = viewModel.Client.Comptes!.ToList();

            viewModel.Operations = viewModel.Comptes.GroupBy(cpt => cpt.TypeCompte)
                .ToDictionary(
                    grp => grp.Key, // Type de compte
                    grp => grp
                        .SelectMany(cpt => cpt.Operations!)
                        .OrderByDescending(op => op.DateTransaction)
                        .Take(10)
                        .ToList()
                );
            return viewModel;
        }
    }
}
