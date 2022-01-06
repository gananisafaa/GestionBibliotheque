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
    public class OeuvresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OeuvresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Oeuvres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Oeuvre.Include(o => o.Auteur).Include(o => o.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Oeuvres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oeuvre = await _context.Oeuvre
                .Include(o => o.Auteur)
                .Include(o => o.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oeuvre == null)
            {
                return NotFound();
            }

            return View(oeuvre);
        }

        // GET: Oeuvres/Create
        public IActionResult Create()
        {
            ViewData["AuteurID"] = new SelectList(_context.Set<Auteur>(), "Id", "Id");
            ViewData["GenreID"] = new SelectList(_context.Genre, "Id", "Id");
            return View();
        }

        // POST: Oeuvres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,AuteurID,GenreID,Langue,Resume")] Oeuvre oeuvre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oeuvre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuteurID"] = new SelectList(_context.Set<Auteur>(), "Id", "Id", oeuvre.AuteurID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "Id", "Id", oeuvre.GenreID);
            return View(oeuvre);
        }

        // GET: Oeuvres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oeuvre = await _context.Oeuvre.FindAsync(id);
            if (oeuvre == null)
            {
                return NotFound();
            }
            ViewData["AuteurID"] = new SelectList(_context.Set<Auteur>(), "Id", "Id", oeuvre.AuteurID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "Id", "Id", oeuvre.GenreID);
            return View(oeuvre);
        }

        // POST: Oeuvres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,AuteurID,GenreID,Langue,Resume")] Oeuvre oeuvre)
        {
            if (id != oeuvre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oeuvre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OeuvreExists(oeuvre.Id))
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
            ViewData["AuteurID"] = new SelectList(_context.Set<Auteur>(), "Id", "Id", oeuvre.AuteurID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "Id", "Id", oeuvre.GenreID);
            return View(oeuvre);
        }

        // GET: Oeuvres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oeuvre = await _context.Oeuvre
                .Include(o => o.Auteur)
                .Include(o => o.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oeuvre == null)
            {
                return NotFound();
            }

            return View(oeuvre);
        }

        // POST: Oeuvres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oeuvre = await _context.Oeuvre.FindAsync(id);
            _context.Oeuvre.Remove(oeuvre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OeuvreExists(int id)
        {
            return _context.Oeuvre.Any(e => e.Id == id);
        }
    }
}
