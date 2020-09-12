using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCorePostgresSqlTelerik.Data;
using NetCorePostgresSqlTelerik.Models;

namespace NetCorePostgresSqlTelerik.Controllers
{
    [Authorize(Roles = "Istruttore,Administrator")]
    public class CorsiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CorsiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Corsi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Corsi.ToListAsync());
        }

        // GET: Corsi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corsi = await _context.Corsi
                .FirstOrDefaultAsync(m => m.id == id);
            if (corsi == null)
            {
                return NotFound();
            }

            return View(corsi);
        }

        // GET: Corsi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corsi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descrizione,titolo,numMaxPrenotati,dIniziale,dFinale,ore")] Corsi corsi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corsi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corsi);
        }

        // GET: Corsi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corsi = await _context.Corsi.FindAsync(id);
            if (corsi == null)
            {
                return NotFound();
            }
            return View(corsi);
        }

        // POST: Corsi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descrizione,titolo,numMaxPrenotati,dIniziale,dFinale,ore")] Corsi corsi)
        {
            if (id != corsi.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corsi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorsiExists(corsi.id))
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
            return View(corsi);
        }

        // GET: Corsi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corsi = await _context.Corsi
                .FirstOrDefaultAsync(m => m.id == id);
            if (corsi == null)
            {
                return NotFound();
            }

            return View(corsi);
        }

        // POST: Corsi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corsi = await _context.Corsi.FindAsync(id);
            _context.Corsi.Remove(corsi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorsiExists(int id)
        {
            return _context.Corsi.Any(e => e.id == id);
        }
    }
}
