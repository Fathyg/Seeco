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
    public class TblDrawingDetsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblDrawingDetsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblDrawingDets
        public async Task<IActionResult> Index(int did)
        {
            var projectsDbContext = _context.TblDrawingDet.Include(t => t.Drawing).Where(t => t.DrawingId == did);
            ViewBag.dr = _context.TblDrawings.Where(t => t.Id == did).FirstOrDefault().DrawingName;
            ViewBag.did = did;
            ViewBag.pid = _context.TblDrawings.Include(t => t.Item).Where(t => t.Id == did).FirstOrDefault().Item.ProjectId;
            return View(await projectsDbContext.ToListAsync());
        }

        // GET: TblDrawingDets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrawingDet = await _context.TblDrawingDet
                .Include(t => t.Drawing)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDrawingDet == null)
            {
                return NotFound();
            }
            ViewBag.dr = _context.TblDrawings.Where(t => t.Id == tblDrawingDet.DrawingId).FirstOrDefault().DrawingName;
            ViewBag.did = tblDrawingDet.DrawingId;
            ViewBag.pid = _context.TblDrawings.Include(t => t.Item).Where(t => t.Id == tblDrawingDet.DrawingId).FirstOrDefault().Item.ProjectId;
            return View(tblDrawingDet);
        }

        // GET: TblDrawingDets/Create
        public IActionResult Create(int did)
        {
            ViewData["DrawingId"] = new SelectList(_context.TblDrawings, "Id", "DrawingName");
            ViewBag.dr = _context.TblDrawings.Where(t => t.Id == did).FirstOrDefault().DrawingName;
            ViewBag.did = did;
            ViewBag.pid = _context.TblDrawings.Include(t => t.Item).Where(t => t.Id == did).FirstOrDefault().Item.ProjectId;
            return View();
        }

        // POST: TblDrawingDets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DrawingId,Date,DecisionMaker,Decisions")] TblDrawingDet tblDrawingDet)
        {
            if (ModelState.IsValid)
            {
                int did = (int)tblDrawingDet.DrawingId;
                _context.Add(tblDrawingDet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { did = did });
            }
            ViewData["DrawingId"] = new SelectList(_context.TblDrawings, "Id", "DrawingName", tblDrawingDet.DrawingId);
            return View(tblDrawingDet);
        }

        // GET: TblDrawingDets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrawingDet = await _context.TblDrawingDet.FindAsync(id);
            if (tblDrawingDet == null)
            {
                return NotFound();
            }
            ViewData["DrawingId"] = new SelectList(_context.TblDrawings, "Id", "DrawingName", tblDrawingDet.DrawingId);
            ViewBag.dr = _context.TblDrawings.Where(t => t.Id == tblDrawingDet.DrawingId).FirstOrDefault().DrawingName;
            ViewBag.did = tblDrawingDet.DrawingId;
            ViewBag.pid = _context.TblDrawings.Include(t => t.Item).Where(t => t.Id == tblDrawingDet.DrawingId).FirstOrDefault().Item.ProjectId;
            return View(tblDrawingDet);
        }

        // POST: TblDrawingDets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DrawingId,Date,DecisionMaker,Decisions")] TblDrawingDet tblDrawingDet)
        {
            if (id != tblDrawingDet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int did = (int)tblDrawingDet.DrawingId;
                try
                {
                    _context.Update(tblDrawingDet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDrawingDetExists(tblDrawingDet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { did = did });
            }
            ViewData["DrawingId"] = new SelectList(_context.TblDrawings, "Id", "DrawingName", tblDrawingDet.DrawingId);
            return View(tblDrawingDet);
        }

        // GET: TblDrawingDets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrawingDet = await _context.TblDrawingDet
                .Include(t => t.Drawing)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDrawingDet == null)
            {
                return NotFound();
            }
            ViewBag.dr = _context.TblDrawings.Where(t => t.Id == tblDrawingDet.DrawingId).FirstOrDefault().DrawingName;
            ViewBag.did = tblDrawingDet.DrawingId;
            ViewBag.pid = _context.TblDrawings.Include(t => t.Item).Where(t => t.Id == tblDrawingDet.DrawingId).FirstOrDefault().Item.ProjectId;
            return View(tblDrawingDet);
        }

        // POST: TblDrawingDets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDrawingDet = await _context.TblDrawingDet.FindAsync(id);
            int did = (int)tblDrawingDet.DrawingId;
            _context.TblDrawingDet.Remove(tblDrawingDet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { did = did });
        }

        private bool TblDrawingDetExists(int id)
        {
            return _context.TblDrawingDet.Any(e => e.Id == id);
        }
    }
}
