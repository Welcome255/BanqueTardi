using Assurance.ApplicationCore.Entites;
using BanqueTardi.ContexteDb;
using BanqueTardi.DTO;
using BanqueTardi.Interfaces;
using BanqueTardi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BanqueTardi.Controllers
{
    public class AssuranceClientsController : Controller
    {
        private readonly IAssuranceClientServices _assuranceClientServices;
        private readonly BanqueTardiContexte _context;
        public AssuranceClientsController(IAssuranceClientServices assuranceClientServices, BanqueTardiContexte contexte)
        {
            _assuranceClientServices = assuranceClientServices;
            _context = contexte;
        }
        // GET: AssuranceClientsController
        public async Task<ActionResult> Index()
        {
            return View(await _assuranceClientServices.ObtenirTout());
        }

        // GET: AssuranceClientsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _assuranceClientServices.Obtenir(id));
        }

        // GET: AssuranceClientsController/Create
        public ActionResult Create()
        {
            ListeDesClients();
            return View();
        }

        // POST: AssuranceClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AssuranceTardiBodyDTO collection)
        {
            
            AssuranceTardi assurance = new AssuranceTardi()
            {
                ClientID = collection.ClientID,
                NomClient = _context.Clients.First(cl=> cl.ClientID == collection.ClientID).NomClient,
                PrenomClient = _context.Clients.First(cl => cl.ClientID == collection.ClientID).PrenomClient,
                DateDeNaissance = _context.Clients.Where(c => c.ClientID == collection.ClientID).Single().DateNaissance,
                CodePartenaire = "TARDI1010",
                CodeRabais= CodeRabais.PRI,
                Solde = collection.Solde,
                Sexe= collection.Sexe,
                EstDiabetique = collection.EstDiabetique,
                EstFumeur = collection.EstFumeur,
                EstHypertendu = collection.EstHypertendu,
                PratiqueActivitePhysique = collection.PratiqueActivitePhysique,
                Statut = collection.Statut,
            };

         
                if(ModelState.IsValid)
                {
                    await _assuranceClientServices.Ajouter(assurance);
                    return RedirectToAction(nameof(Index));
                }
                
           
                return View(collection);
            
        }

        // GET: AssuranceClientsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _assuranceClientServices.Obtenir(id));
        }

        // POST: AssuranceClientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AssuranceTardi collection)
        {
            if (ModelState.IsValid)
            {
                await _assuranceClientServices.Modifier(collection);
                return RedirectToAction(nameof(Index));
            }
           
                return View(collection);
           
        }

        // GET: AssuranceClientsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _assuranceClientServices.Obtenir(id));
        }

        // POST: AssuranceClientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, AssuranceTardi collection)
        {
            try
            {
                await _assuranceClientServices.Supprimer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Confirmer(int id)
        {
            await _assuranceClientServices.Confirmer(id);
            return RedirectToAction(nameof(Index));
        }

        private void ListeDesClients(object? selectedValue = null)
        {
            ViewData["Client"] = new SelectList((_context.Clients), "ClientID", "FullName", selectedValue);
        }
    }
}
