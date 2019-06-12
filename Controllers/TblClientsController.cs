using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seeco.Models;

namespace Seeco.Controllers
{
    public class TblClientsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblClientsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClients.ToListAsync());
        }

        // GET: TblClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClients = await _context.TblClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClients == null)
            {
                return NotFound();
            }

            return View(tblClients);
        }

        // GET: TblClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phones,Faxes,Ceo,Parent,Email,WebSite,Notes")] TblClients tblClients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClients);
        }

        // GET: TblClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClients = await _context.TblClients.FindAsync(id);
            if (tblClients == null)
            {
                return NotFound();
            }
            return View(tblClients);
        }

        // POST: TblClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phones,Faxes,Ceo,Parent,Email,WebSite,Notes")] TblClients tblClients)
        {
            if (id != tblClients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClientsExists(tblClients.Id))
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
            return View(tblClients);
        }

        // GET: TblClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClients = await _context.TblClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClients == null)
            {
                return NotFound();
            }

            return View(tblClients);
        }

        // POST: TblClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClients = await _context.TblClients.FindAsync(id);
            _context.TblClients.Remove(tblClients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClientsExists(int id)
        {
            return _context.TblClients.Any(e => e.Id == id);
        }
    }
}
