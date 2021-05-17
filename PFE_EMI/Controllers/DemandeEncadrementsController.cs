using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFE_EMI.Data;
using PFE_EMI.Models;

namespace PFE_EMI.Controllers
{
    public class DemandeEncadrementsController : Controller
    {
        private readonly PFEContext _context;

        public DemandeEncadrementsController(PFEContext context)
        {
            _context = context;
        }

        // GET: DemandeEncadrements
        public async Task<IActionResult> Index()
        {

            foreach (var item in _context.DemandeEncadrements)
            {

            }
            _context.Professeurs.Find
            return View(await _context.DemandeEncadrements.ToListAsync());
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
            return View();
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
    }
}
