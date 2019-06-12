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
    public class TblContractorsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblContractorsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblContractors
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblContractors.ToListAsync());
        }

        // GET: TblContractors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContractors = await _context.TblContractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblContractors == null)
            {
                return NotFound();
            }

            return View(tblContractors);
        }

        // GET: TblContractors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblContractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phones,Faxes,Ceo,Parent,Email,WebSite,Notes")] TblContractors tblContractors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblContractors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblContractors);
        }

        // GET: TblContractors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContractors = await _context.TblContractors.FindAsync(id);
            if (tblContractors == null)
            {
                return NotFound();
            }
            return View(tblContractors);
        }

        // POST: TblContractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phones,Faxes,Ceo,Parent,Email,WebSite,Notes")] TblContractors tblContractors)
        {
            if (id != tblContractors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblContractors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblContractorsExists(tblContractors.Id))
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
            return View(tblContractors);
        }

        // GET: TblContractors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContractors = await _context.TblContractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblContractors == null)
            {
                return NotFound();
            }

            return View(tblContractors);
        }

        // POST: TblContractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblContractors = await _context.TblContractors.FindAsync(id);
            _context.TblContractors.Remove(tblContractors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblContractorsExists(int id)
        {
            return _context.TblContractors.Any(e => e.Id == id);
        }
    }
}
