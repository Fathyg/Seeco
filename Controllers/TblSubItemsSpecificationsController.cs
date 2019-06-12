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
    public class TblSubItemsSpecificationsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblSubItemsSpecificationsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblSubItemsSpecifications
        public async Task<IActionResult> Index(int pid)
        {
            var projectsDbContext = _context.TblSubItemsSpecifications.Include(t => t.Item).Where(t => t.Item.ProjectId == pid);
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(await projectsDbContext.ToListAsync());
        }

        // GET: TblSubItemsSpecifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubItemsSpecifications = await _context.TblSubItemsSpecifications
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSubItemsSpecifications == null)
            {
                return NotFound();
            }
            int? pid = _context.TblItems.Where(t => t.Id == tblSubItemsSpecifications.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblSubItemsSpecifications);
        }

        // GET: TblSubItemsSpecifications/Create
        public IActionResult Create(int pid)
        {
            ViewData["ItemId"] = new SelectList(_context.TblItems, "Id", "ItemName");
           
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View();
        }

        // POST: TblSubItemsSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemId,SubItemName,Spcifications,Notes")] TblSubItemsSpecifications tblSubItemsSpecifications)
        {
            if (ModelState.IsValid)
            {
                int? pid = _context.TblItems.Where(t => t.Id == tblSubItemsSpecifications.ItemId).FirstOrDefault().ProjectId;
                _context.Add(tblSubItemsSpecifications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { pid = pid });
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "Id", "ItemName", tblSubItemsSpecifications.ItemId);
            return View(tblSubItemsSpecifications);
        }

        // GET: TblSubItemsSpecifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubItemsSpecifications = await _context.TblSubItemsSpecifications.FindAsync(id);
            if (tblSubItemsSpecifications == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "Id", "ItemName", tblSubItemsSpecifications.ItemId);
            int? pid = _context.TblItems.Where(t => t.Id == tblSubItemsSpecifications.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblSubItemsSpecifications);
        }

        // POST: TblSubItemsSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemId,SubItemName,Spcifications,Notes")] TblSubItemsSpecifications tblSubItemsSpecifications)
        {
            if (id != tblSubItemsSpecifications.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int? pid = _context.TblItems.Where(t => t.Id == tblSubItemsSpecifications.ItemId).FirstOrDefault().ProjectId;
                try
                {
                    _context.Update(tblSubItemsSpecifications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSubItemsSpecificationsExists(tblSubItemsSpecifications.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { pid = pid });
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "Id", "ItemName", tblSubItemsSpecifications.ItemId);
            return View(tblSubItemsSpecifications);
        }

        // GET: TblSubItemsSpecifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubItemsSpecifications = await _context.TblSubItemsSpecifications
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSubItemsSpecifications == null)
            {
                return NotFound();
            }
            int? pid = _context.TblItems.Where(t => t.Id == tblSubItemsSpecifications.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblSubItemsSpecifications);
        }

        // POST: TblSubItemsSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSubItemsSpecifications = await _context.TblSubItemsSpecifications.FindAsync(id);
            int? pid = _context.TblItems.Where(t => t.Id == tblSubItemsSpecifications.ItemId).FirstOrDefault().ProjectId;
            _context.TblSubItemsSpecifications.Remove(tblSubItemsSpecifications);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { pid = pid });
        }

        private bool TblSubItemsSpecificationsExists(int id)
        {
            return _context.TblSubItemsSpecifications.Any(e => e.Id == id);
        }
    }
}
