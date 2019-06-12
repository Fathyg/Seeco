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
    public class TblProjectsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblProjectsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblProjects
        public async Task<IActionResult> Index()
        {
            var projectsDbContext = _context.TblProjects.Include(t => t.Contract);
            return View(await projectsDbContext.ToListAsync());
        }

        // GET: TblProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProjects = await _context.TblProjects
                .Include(t => t.Contract)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblProjects == null)
            {
                return NotFound();
            }

            return View(tblProjects);
        }



        // GET: TblProjects/Create
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.TblContracts, "Id", "Id");
            return View();
        }

        // POST: TblProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,ContractId,StartDate,FinishDate,Period,Notes")] TblProjects tblProjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProjects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractId"] = new SelectList(_context.TblContracts, "Id", "Id", tblProjects.ContractId);
            return View(tblProjects);
        }

        public IActionResult Project(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pr = _context.TblProjects.Where(t => t.Id == id).FirstOrDefault().Name;
            ViewBag.pr = pr;

            ViewBag.pid = id;
            return View();
        }

        // GET: TblProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProjects = await _context.TblProjects.FindAsync(id);
            if (tblProjects == null)
            {
                return NotFound();
            }
            ViewData["ContractId"] = new SelectList(_context.TblContracts, "Id", "Id", tblProjects.ContractId);
            return View(tblProjects);
        }

        // POST: TblProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,ContractId,StartDate,FinishDate,Period,Notes")] TblProjects tblProjects)
        {
            if (id != tblProjects.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProjectsExists(tblProjects.Id))
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
            ViewData["ContractId"] = new SelectList(_context.TblContracts, "Id", "Id", tblProjects.ContractId);
            return View(tblProjects);
        }

        // GET: TblProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProjects = await _context.TblProjects
                .Include(t => t.Contract)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblProjects == null)
            {
                return NotFound();
            }

            return View(tblProjects);
        }

        // POST: TblProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProjects = await _context.TblProjects.FindAsync(id);
            _context.TblProjects.Remove(tblProjects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProjectsExists(int id)
        {
            return _context.TblProjects.Any(e => e.Id == id);
        }
    }
}
