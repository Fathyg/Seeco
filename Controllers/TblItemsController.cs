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
    public class TblItemsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblItemsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblItems
        public async Task<IActionResult> Index(int pid)
        {
            var projectsDbContext = _context.TblItems.Include(t => t.Project).Where(t => t.ProjectId == pid);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            ViewBag.itName = projectsDbContext.Select(b => b.ItemName).ToList();
            ViewBag.itNo = projectsDbContext.Select(b => b.ItemNo).ToList();
            return View(await projectsDbContext.ToListAsync());
        }

        public async Task<IActionResult> Search(int pid, string itName, string itNo, string itType)
        {
            var items = _context.TblItems.Include(t => t.Project).Where(t => t.ProjectId == pid);

            if (! string.IsNullOrEmpty(itName))
            {
                items = items.Where(b => b.ItemName.Contains(itName));
            }

            if (! string.IsNullOrEmpty(itNo))
            {
                items = items.Where(b => b.ItemNo == itNo);
            }

            if (! string.IsNullOrEmpty(itType))
            {
                items = items.Where(b => b.ItemType == itType);
            }
            var projectsDbContext = _context.TblItems.Include(t => t.Project).Where(t => t.ProjectId == pid);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            ViewBag.itName = projectsDbContext.Select(b => b.ItemName).ToList();
            ViewBag.itNo = projectsDbContext.Select(b => b.ItemNo).ToList();
            return View("Index", await items.ToListAsync());
        }

        // GET: TblItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItems = await _context.TblItems
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblItems == null)
            {
                return NotFound();
            }
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == tblItems.ProjectId).FirstOrDefault().Name;
            ViewBag.pid = tblItems.ProjectId;
            return View(tblItems);
        }

        // GET: TblItems/Create
        public IActionResult Create(int pid)
        {
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Name");
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View();
        }

        // POST: TblItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,ItemName,ItemNo,ItemType,Description")] TblItems tblItems)
        {
            if (ModelState.IsValid)
            {
                int pid = (int)tblItems.ProjectId;
                _context.Add(tblItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { pid = pid });
            }
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Name", tblItems.ProjectId);
            return View(tblItems);
        }

        // GET: TblItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItems = await _context.TblItems.FindAsync(id);
            if (tblItems == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Name", tblItems.ProjectId);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == tblItems.ProjectId).FirstOrDefault().Name;
            ViewBag.pid = tblItems.ProjectId;
            return View(tblItems);
        }

        // POST: TblItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,ItemName,ItemNo,ItemType,Description")] TblItems tblItems)
        {
            if (id != tblItems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblItemsExists(tblItems.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { pid = tblItems.ProjectId });
            }
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Name", tblItems.ProjectId);
            return View(tblItems);
        }

        // GET: TblItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItems = await _context.TblItems
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblItems == null)
            {
                return NotFound();
            }
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == tblItems.ProjectId).FirstOrDefault().Name;
            ViewBag.pid = tblItems.ProjectId;
            return View(tblItems);
        }

        // POST: TblItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblItems = await _context.TblItems.FindAsync(id);
            int pid = (int)tblItems.ProjectId;
            _context.TblItems.Remove(tblItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { pid = pid });
        }

        private bool TblItemsExists(int id)
        {
            return _context.TblItems.Any(e => e.Id == id);
        }
    }
}
