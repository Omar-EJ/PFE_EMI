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
    public class DisponibiliteProfController : Controller
    {
        private readonly PFEContext _context;

        public DisponibiliteProfController(PFEContext context)
        {
            _context = context;
        }

        // GET: DisponibiliteProf
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professeurs.ToListAsync());
        }

        // GET: DisponibiliteProf/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeurs
                .FirstOrDefaultAsync(m => m.ID_prof == id);
            if (professeur == null)
            {
                return NotFound();
            }

            return View(professeur);
        }

        // GET: DisponibiliteProf/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisponibiliteProf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_prof,Fname,Lname,Disponible")] Professeur professeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professeur);
        }

        // GET: DisponibiliteProf/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeurs.FindAsync(id);
            if (professeur == null)
            {
                return NotFound();
            }
            return View(professeur);
        }

        // POST: DisponibiliteProf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID_prof,Fname,Lname,Disponible")] Professeur professeur)
        {
            if (id != professeur.ID_prof)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesseurExists(professeur.ID_prof))
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
            return View(professeur);
        }

        // GET: DisponibiliteProf/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professeur = await _context.Professeurs
                .FirstOrDefaultAsync(m => m.ID_prof == id);
            if (professeur == null)
            {
                return NotFound();
            }

            return View(professeur);
        }

        // POST: DisponibiliteProf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var professeur = await _context.Professeurs.FindAsync(id);
            _context.Professeurs.Remove(professeur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesseurExists(string id)
        {
            return _context.Professeurs.Any(e => e.ID_prof == id);
        }
    }
}
