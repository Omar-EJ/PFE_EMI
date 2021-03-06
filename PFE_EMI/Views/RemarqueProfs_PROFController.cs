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

namespace PFE_EMI.Views
{
    public class RemarqueProfs_PROFController : Controller
    {
        private readonly PFEContext _context;
        private string ID_PROF = "kabbaj";

        public RemarqueProfs_PROFController(PFEContext context)
        {
            _context = context;
        }

        // GET: RemarqueProfs_PROF
        public  IActionResult Index()
        {
            List<ListePFEEtudiants> resultat = new List<ListePFEEtudiants>();

            ICollection<RemarqueProf> list = _context.RemarqueProf.Where<RemarqueProf>(rem => rem.id_prof == ID_PROF).ToArray<RemarqueProf>();
            HashSet<string> mySet = new HashSet<string>();
            foreach (RemarqueProf element in list)
            {

                Etudiant etud = _context.Etudiants.Where<Etudiant>(e => e.ID == element.id_student).FirstOrDefault();
                var name = etud.Fname.ToUpper() + " " + etud.Lname;
                if (!mySet.Add(name))
                {
                    continue;
                }
                DemandeEncadrements demande = _context.DemandeEncadrements.Where<DemandeEncadrements>(dem => dem.ID_Etudiant == element.id_student && dem.ID_Prof == ID_PROF).FirstOrDefault();
                var pfe = demande.SujetPFE;
                ListePFEEtudiants lpe = new ListePFEEtudiants
                {
                    IdEtudiant = element.id_student,
                    nameEtudiant = name,
                    nomPFE = pfe,

                };
                resultat.Add(lpe);

            }
            Professeur p = _context.Professeurs.Where<Professeur>(prof => prof.ID_prof == ID_PROF).First();

            ICollection res = new List<ListePFEEtudiants>(resultat);


            return View(res);
        }

        // GET: RemarqueProfs_PROF/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ICollection<RemarqueProf> list = _context.RemarqueProf.Where<RemarqueProf>(rem =>rem.id_prof==ID_PROF && rem.id_student == id).ToArray<RemarqueProf>();

            RemarqueProf item = list.ElementAt(0);
            Etudiant e = _context.Etudiants.Find(item.id_student);
            
            var titreSujet = _context.PFEs.First(pfe => pfe.id_student == id).sujet;

            var lienSujet = _context.PFEs.First(pfe => pfe.id_student == id).lien_PFE;

            RemarqueDisplayProf remarque = new RemarqueDisplayProf {id_Etudiant = e.ID, lienPFE = lienSujet, etudiant = e.Fname.ToUpper() + " " + e.Lname, titrePFE = titreSujet, listeRemarques = list };

            return View(remarque);
        }

        // GET: RemarqueProfs_PROF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RemarqueProfs_PROF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_remarque,id_prof,id_student,remarque,liens_complementaires,seen,date_remarque")] RemarqueProf remarqueProf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(remarqueProf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remarqueProf);
        }

        // GET: RemarqueProfs_PROF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remarqueProf = await _context.RemarqueProf.FindAsync(id);
            if (remarqueProf == null)
            {
                return NotFound();
            }
            return View(remarqueProf);
        }

        // POST: RemarqueProfs_PROF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_remarque,id_prof,id_student,remarque,liens_complementaires,seen,date_remarque")] RemarqueProf remarqueProf)
        {
            if (id != remarqueProf.id_remarque)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(remarqueProf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemarqueProfExists(remarqueProf.id_remarque))
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
            return View(remarqueProf);
        }

        // GET: RemarqueProfs_PROF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remarqueProf = await _context.RemarqueProf
                .FirstOrDefaultAsync(m => m.id_remarque == id);
            if (remarqueProf == null)
            {
                return NotFound();
            }

            return View(remarqueProf);
        }

        // POST: RemarqueProfs_PROF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var remarqueProf = await _context.RemarqueProf.FindAsync(id);
            _context.RemarqueProf.Remove(remarqueProf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemarqueProfExists(int id)
        {
            return _context.RemarqueProf.Any(e => e.id_remarque == id);
        }

        

        [HttpPost, ActionName("addCommentary")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addCommentary(int id_Etudiant, string remarque, string liensremarque)
        {
            RemarqueProf remarqueProf = new RemarqueProf
            {
                date_remarque = DateTime.Now,
                id_prof = ID_PROF,
                id_student = id_Etudiant,
                remarque = remarque,
                liens_complementaires = liensremarque,
                seen = false
            };
            _context.RemarqueProf.Add(remarqueProf);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details),new { id = id_Etudiant });
        }


    }
}
