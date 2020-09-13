using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCorePostgresSqlTelerik.Data;
using NetCorePostgresSqlTelerik.Models;

namespace NetCorePostgresSqlTelerik.Controllers
{
    public class PrenotazioniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrenotazioniController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetPrenotazioni([DataSourceRequest] DataSourceRequest request)
        {
            List<Prenotazioni> prenotazioni = new List<Prenotazioni>();

            try
            {
                Prenotazioni p1 = new Prenotazioni();
                p1.idUtente = "1";
                p1.idCorso = 1;
                p1.id = 1;
                prenotazioni.Add(p1);

                Prenotazioni p2 = new Prenotazioni();
                p2.idUtente = "2";
                p2.idCorso = 2;
                p2.id = 2;
                prenotazioni.Add(p2);

                Prenotazioni p3 = new Prenotazioni();
                p3.idUtente = "3";
                p3.idCorso = 3;
                p3.id = 3;
                prenotazioni.Add(p3);

            }
            catch (Exception e)
            {
                Console.WriteLine("Errore : " + e.Message);
            }

            return Json(prenotazioni.ToDataSourceResult(request));
        }

        // GET: Prenotazioni
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prenotazioni.ToListAsync());
        }

        // GET: Prenotazioni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni
                .FirstOrDefaultAsync(m => m.id == id);
            if (prenotazioni == null)
            {
                return NotFound();
            }

            return View(prenotazioni);
        }

        // GET: Prenotazioni/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prenotazioni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,data,ora,idCorso,idUtente")] Prenotazioni prenotazioni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenotazioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prenotazioni);
        }

        // GET: Prenotazioni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni.FindAsync(id);
            if (prenotazioni == null)
            {
                return NotFound();
            }
            return View(prenotazioni);
        }

        // POST: Prenotazioni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,data,ora,idCorso,idUtente")] Prenotazioni prenotazioni)
        {
            if (id != prenotazioni.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenotazioni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrenotazioniExists(prenotazioni.id))
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
            return View(prenotazioni);
        }

        // GET: Prenotazioni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni
                .FirstOrDefaultAsync(m => m.id == id);
            if (prenotazioni == null)
            {
                return NotFound();
            }

            return View(prenotazioni);
        }

        // POST: Prenotazioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prenotazioni = await _context.Prenotazioni.FindAsync(id);
            _context.Prenotazioni.Remove(prenotazioni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrenotazioniExists(int id)
        {
            return _context.Prenotazioni.Any(e => e.id == id);
        }
    }
}
