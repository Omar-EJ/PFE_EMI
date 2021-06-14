using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFE_EMI.Data;
using PFE_EMI.Models;
using PFE_EMI.Models.Display;

namespace PFE_EMI.Controllers.professeur
{
    public class DemandeEncadrementsProfsController : Controller
    {
        private readonly PFEContext _context;
        public Boolean hasAcceptedRequest = false;
        public string myID = "kabbaj";

        public DemandeEncadrementsProfsController(PFEContext context)
        {
            _context = context;
            hasAcceptedRequest = setHasAcceptedRequests();
        }

        public Boolean setHasAcceptedRequests()
        {
            ICollection<DemandeEncadrements> list = _context.DemandeEncadrements.ToArray<DemandeEncadrements>();
            foreach (var item in list)
            {
                if (item.ETAT == 1)
                {
                    return true;
                }
            }
            return false;
        }

        // GET: DemandeEncadrements
        public IActionResult Index()
        {
            List<DemandeEncadrements> list_res = new List<DemandeEncadrements>();
            ICollection<DemandeEncadrements> list = _context.DemandeEncadrements.ToArray<DemandeEncadrements>();
            foreach (var item in list)
            {
                Etudiant e = _context.Etudiants.Find(item.ID_Etudiant);
                if(item.ID_Prof.Equals(myID))
                {
                    list_res.Add(item);
                }
            }
            // return View(await _context.DemandeEncadrements.ToListAsync());
            ICollection CateringItems = new List<DemandeEncadrements>(list_res);
            return View(CateringItems);
        }

        // GET: DemandeEncadrements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeEncadrements = await _context.DemandeEncadrements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demandeEncadrements == null)
            {
                return NotFound();
            }

            return View(demandeEncadrements);
        }

        // GET: DemandeEncadrements/Create
        public IActionResult Create()
        {

            ICollection<Professeur> list = _context.Professeurs.ToArray<Professeur>();
            List<Prof> profs = new List<Prof>();
            foreach (Professeur p in list)
            {
                if (p.Disponible == 1)
                {
                    profs.Add(new Prof { ID = p.ID_prof, nom = p.Lname });
                }
            }

            DemandeEncadrant demande = new DemandeEncadrant { nomProfs = profs };
            return View(demande);
        }

        // POST: DemandeEncadrements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ID_Etudiant,ID_Prof,liens_complementaires,SujetPFE,date_depot,ETAT")] DemandeEncadrements demandeEncadrements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demandeEncadrements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demandeEncadrements);
        }

        // GET: DemandeEncadrements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeEncadrements = await _context.DemandeEncadrements.FindAsync(id);
            if (demandeEncadrements == null)
            {
                return NotFound();
            }
            return View(demandeEncadrements);
        }

        // POST: DemandeEncadrements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ID_Etudiant,ID_Prof,liens_complementaires,SujetPFE,date_depot,ETAT")] DemandeEncadrements demandeEncadrements)
        {
            if (id != demandeEncadrements.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demandeEncadrements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandeEncadrementsExists(demandeEncadrements.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(demandeEncadrements);
        }

        // GET: DemandeEncadrements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeEncadrements = await _context.DemandeEncadrements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demandeEncadrements == null)
            {
                return NotFound();
            }

            return View(demandeEncadrements);
        }

        // POST: DemandeEncadrements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demandeEncadrements = await _context.DemandeEncadrements.FindAsync(id);
            _context.DemandeEncadrements.Remove(demandeEncadrements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandeEncadrementsExists(int id)
        {
            return _context.DemandeEncadrements.Any(e => e.ID == id);
        }

        [HttpPost, ActionName("cancelRequest")]
        public async Task<IActionResult> cancelRequest(int id){
            DemandeEncadrements encadrement = _context.DemandeEncadrements.Find(id);
            encadrement.ETAT = -1;
            _context.DemandeEncadrements.Update(encadrement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
