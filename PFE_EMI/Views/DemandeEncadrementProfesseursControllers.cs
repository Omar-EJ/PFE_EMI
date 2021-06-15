using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFE_EMI.Data;
using PFE_EMI.Models;
using PFE_EMI.Models.Display;

namespace PFE_EMI.Views
{
    public class DemandeEncadrementProfesseursControllers : Controller
    {
        private readonly PFEContext _context;
        private string ID_PROF = "kabbaj";
        public DemandeEncadrementProfesseursControllers(PFEContext context)
        {
            _context = context;
        }

        // GET: DemandeEncadrementProfesseursControllers
        public IActionResult Index()
        {
            List<DemandePourProfesseur> list_res = new List<DemandePourProfesseur>();
            ICollection<DemandeEncadrements> list = _context.DemandeEncadrements.Where<DemandeEncadrements>(x => x.ID_Prof.Equals(ID_PROF)).ToArray<DemandeEncadrements>();
            foreach (var item in list)
            {
                Etudiant p = _context.Etudiants.Find(item.ID_Etudiant);
                string nom = "";
                if (p != null)
                {
                    nom = p.Fname + " " + p.Lname;
                }


                DemandePourProfesseur dpp = new DemandePourProfesseur
                {
                    ID_ETUDIANT = item.ID_Etudiant,
                    ETAT = item.ETAT,
                    liens = item.liens_complementaires,
                    nomEtudiant = nom,
                    sujet = item.SujetPFE,
                    date_depot = item.date_depot,
                    branche = p.Branch,
                    specialty = p.Specialty

                };
                //item.ID_Prof = ""; // change later
                list_res.Add(dpp);
            }
            // return View(await _context.DemandeEncadrements.ToListAsync());


            return View(list_res);
        }

        // GET: DemandeEncadrementProfesseursControllers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DemandeEncadrements demande = _context.DemandeEncadrements.Where<DemandeEncadrements>(x => x.ID_Etudiant == id && x.ID_Prof == ID_PROF).First();

            var demandeEncadrements = await _context.DemandeEncadrements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demandeEncadrements == null)
            {
                return NotFound();
            }

            return View(demandeEncadrements);
        }

        // GET: DemandeEncadrementProfesseursControllers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DemandeEncadrementProfesseursControllers/Create
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

        // GET: DemandeEncadrementProfesseursControllers/Edit/5
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

        // POST: DemandeEncadrementProfesseursControllers/Edit/5
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

        // GET: DemandeEncadrementProfesseursControllers/Delete/5
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

        // POST: DemandeEncadrementProfesseursControllers/Delete/5
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

        public async Task<IActionResult> AccepterDemande(int ID_ETUDIANT)
        {
            DemandeEncadrements demande = _context.DemandeEncadrements.Where<DemandeEncadrements>(x => (x.ID_Etudiant == ID_ETUDIANT && x.ID_Prof == ID_PROF && x.ETAT ==0)).First();
            demande.ETAT = 1;
            _context.DemandeEncadrements.Update(demande);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> RefuserDemande(int ID_ETUDIANT)
        {
            DemandeEncadrements demande = _context.DemandeEncadrements.Where<DemandeEncadrements>(x => (x.ID_Etudiant == ID_ETUDIANT && x.ID_Prof == ID_PROF && x.ETAT == 0)).First();
            demande.ETAT = -2;
            _context.DemandeEncadrements.Update(demande);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
