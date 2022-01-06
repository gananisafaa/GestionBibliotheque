using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionBibliotheque.Data;
using GestionBibliotheque.Models;

namespace GestionBibliotheque.Controllers
{
    public class EmprunteursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmprunteursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emprunteurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emprunteur.ToListAsync());
        }

        // GET: Emprunteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprunteur = await _context.Emprunteur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprunteur == null)
            {
                return NotFound();
            }

            return View(emprunteur);
        }

        // GET: Emprunteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emprunteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Email,Tel")] Emprunteur emprunteur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprunteur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emprunteur);
        }

        // GET: Emprunteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprunteur = await _context.Emprunteur.FindAsync(id);
            if (emprunteur == null)
            {
                return NotFound();
            }
            return View(emprunteur);
        }

        // POST: Emprunteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Email,Tel")] Emprunteur emprunteur)
        {
            if (id != emprunteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprunteur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprunteurExists(emprunteur.Id))
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
            return View(emprunteur);
        }

        // GET: Emprunteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprunteur = await _context.Emprunteur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprunteur == null)
            {
                return NotFound();
            }

            return View(emprunteur);
        }

        // POST: Emprunteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprunteur = await _context.Emprunteur.FindAsync(id);
            _context.Emprunteur.Remove(emprunteur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprunteurExists(int id)
        {
            return _context.Emprunteur.Any(e => e.Id == id);
        }
    }
}
