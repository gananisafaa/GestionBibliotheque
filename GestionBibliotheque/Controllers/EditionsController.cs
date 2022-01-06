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
    public class EditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Editions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Edition.ToListAsync());
        }

        // GET: Editions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edition = await _context.Edition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (edition == null)
            {
                return NotFound();
            }

            return View(edition);
        }

        // GET: Editions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatePublication,NbPages,NbCopies")] Edition edition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edition);
        }

        // GET: Editions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edition = await _context.Edition.FindAsync(id);
            if (edition == null)
            {
                return NotFound();
            }
            return View(edition);
        }

        // POST: Editions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatePublication,NbPages,NbCopies")] Edition edition)
        {
            if (id != edition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditionExists(edition.Id))
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
            return View(edition);
        }

        // GET: Editions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edition = await _context.Edition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (edition == null)
            {
                return NotFound();
            }

            return View(edition);
        }

        // POST: Editions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var edition = await _context.Edition.FindAsync(id);
            _context.Edition.Remove(edition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditionExists(int id)
        {
            return _context.Edition.Any(e => e.Id == id);
        }
    }
}
