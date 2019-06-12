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
    public class TblSchedulesController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblSchedulesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblSchedules
        public async Task<IActionResult> Index()
        {
            var projectsDbContext = _context.TblSchedules.Include(t => t.Project);
            return View(await projectsDbContext.ToListAsync());
        }

        // GET: TblSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSchedules = await _context.TblSchedules
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSchedules == null)
            {
                return NotFound();
            }

            return View(tblSchedules);
        }

        // GET: TblSchedules/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Id");
            return View();
        }

        // POST: TblSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,ScheduleNo,ProjectId,SchStartDate,SchEndDate,Period,Decision,DecisionDate,FilePath,Remarks")] TblSchedules tblSchedules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSchedules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Id", tblSchedules.ProjectId);
            return View(tblSchedules);
        }

        // GET: TblSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSchedules = await _context.TblSchedules.FindAsync(id);
            if (tblSchedules == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Id", tblSchedules.ProjectId);
            return View(tblSchedules);
        }

        // POST: TblSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ScheduleNo,ProjectId,SchStartDate,SchEndDate,Period,Decision,DecisionDate,FilePath,Remarks")] TblSchedules tblSchedules)
        {
            if (id != tblSchedules.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSchedules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSchedulesExists(tblSchedules.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Id", tblSchedules.ProjectId);
            return View(tblSchedules);
        }

        // GET: TblSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSchedules = await _context.TblSchedules
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSchedules == null)
            {
                return NotFound();
            }

            return View(tblSchedules);
        }

        // POST: TblSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSchedules = await _context.TblSchedules.FindAsync(id);
            _context.TblSchedules.Remove(tblSchedules);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSchedulesExists(int id)
        {
            return _context.TblSchedules.Any(e => e.Id == id);
        }
    }
}
