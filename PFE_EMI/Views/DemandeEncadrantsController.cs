using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFE_EMI.Data;
using PFE_EMI.Models.Display;

namespace PFE_EMI.Views
{
    public class DemandeEncadrantsController : Controller
    {
        private readonly PFEContext _context;

        public DemandeEncadrantsController(PFEContext context)
        {
            _context = context;
        }

        // GET: DemandeEncadrants
        public async Task<IActionResult> Index()
        {
            return View(await _context.DemandeEncadrant.ToListAsync());
        }

        // GET: DemandeEncadrants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeEncadrant = await _context.DemandeEncadrant
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demandeEncadrant == null)
            {
                return NotFound();
            }

            return View(demandeEncadrant);
        }

        // GET: DemandeEncadrants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DemandeEncadrants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ID_Etudiant,ID_Prof,liens_complementaires,SujetPFE,professeurChoisis")] DemandeEncadrant demandeEncadrant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demandeEncadrant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demandeEncadrant);
        }

        // GET: DemandeEncadrants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeEncadrant = await _context.DemandeEncadrant.FindAsync(id);
            if (demandeEncadrant == null)
            {
                return NotFound();
            }
            return View(demandeEncadrant);
        }

        // POST: DemandeEncadrants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ID_Etudiant,ID_Prof,liens_complementaires,SujetPFE,professeurChoisis")] DemandeEncadrant demandeEncadrant)
        {
            if (id != demandeEncadrant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demandeEncadrant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandeEncadrantExists(demandeEncadrant.ID))
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
            return View(demandeEncadrant);
        }

        // GET: DemandeEncadrants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeEncadrant = await _context.DemandeEncadrant
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demandeEncadrant == null)
            {
                return NotFound();
            }

            return View(demandeEncadrant);
        }

        // POST: DemandeEncadrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demandeEncadrant = await _context.DemandeEncadrant.FindAsync(id);
            _context.DemandeEncadrant.Remove(demandeEncadrant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandeEncadrantExists(int id)
        {
            return _context.DemandeEncadrant.Any(e => e.ID == id);
        }
    }
}
