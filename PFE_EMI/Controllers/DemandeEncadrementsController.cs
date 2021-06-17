using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFE_EMI.Data;
using PFE_EMI.Models;
using PFE_EMI.Models.Display;

namespace PFE_EMI.Controllers
{
    [Authorize(Roles = "Professeur")]
    public class DemandeEncadrementsController : Controller
    {
        private readonly PFEContext _context;
        public Boolean hasAcceptedRequest = false;

        private int ID_ETUDIANT = 12345;

        public DemandeEncadrementsController(PFEContext context)
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
                Professeur p = _context.Professeurs.Find(item.ID_Prof);
                string lname = "";
                 foreach(var namePart in p.Lname.Split(" "))
                {
                    lname += namePart.Substring(0, 1).ToUpper()+". ";
                }
                 item.ID_Prof = p.Fname.ToUpper() + " " + lname;

                //item.ID_Prof = ""; // change later
                list_res.Add(item);
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
            ICollection<DemandeEncadrements> demandes = _context.DemandeEncadrements.ToArray<DemandeEncadrements>();
            List<Prof> profs = new List<Prof>();
            foreach (Professeur p in list)
            {
                if (p.Disponible == 1)
                {
                    var exists = false;
                    foreach(DemandeEncadrements de in demandes)
                    {
                        if (de.ID_Prof == p.ID_prof && de.ETAT != -1)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        profs.Add(new Prof { ID = p.ID_prof, nom = p.Lname });
                    }
                }
            }

            DemandeEncadrant demande = new DemandeEncadrant { nomProfs = profs,ID_Etudiant= ID_ETUDIANT };
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
