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

namespace PFE_EMI.Controllers
{
   

    public class RemarqueProfsController : Controller
    {
        private readonly PFEContext _context;
        private int ID_ETUDIANT = 12345;
        public RemarqueProfsController(PFEContext context)
        {
            _context = context;
        }

        // GET: RemarqueProfs
        public IActionResult Index()
        {
            ICollection<RemarqueProf> list = _context.RemarqueProf.Where<RemarqueProf>(rem => rem.id_student == ID_ETUDIANT).ToArray<RemarqueProf>();


            RemarqueProf item = list.ElementAt(0);
            Professeur p = _context.Professeurs.Find(item.id_prof);
            string lname = "";
            foreach (var namePart in p.Lname.Split(" "))
            {
                lname += namePart.Substring(0, 1).ToUpper() + ". ";
            }
            item.id_prof = p.Fname.ToUpper() + " " + lname;

            var titreSujet = _context.PFEs.First(pfe => pfe.id_student == 12345).sujet;

            RemarqueDisplay remarque = new RemarqueDisplay { prof = item.id_prof, titrePFE = titreSujet, listeRemarques = list };

            return View(remarque);


        }

        // GET: RemarqueProfs/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: RemarqueProfs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RemarqueProfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_remarque,id_prof,id_student,remarque,liens_complementaires")] RemarqueProf remarqueProf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(remarqueProf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remarqueProf);
        }

        // GET: RemarqueProfs/Edit/5
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

        // POST: RemarqueProfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_remarque,id_prof,id_student,remarque,liens_complementaires")] RemarqueProf remarqueProf)
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

        // GET: RemarqueProfs/Delete/5
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

        // POST: RemarqueProfs/Delete/5
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

        [HttpPost, ActionName("changeSeenState")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> changeSeenState(int id_remarque)
        {
            RemarqueProf remarqueProf = _context.RemarqueProf.Find(id_remarque);
            remarqueProf.seen = !remarqueProf.seen;
            _context.RemarqueProf.Update(remarqueProf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
