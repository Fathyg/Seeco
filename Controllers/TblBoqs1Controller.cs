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
    public class TblBoqs1Controller : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblBoqs1Controller(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblBoqs1
        public async Task<IActionResult> Index(int pid)
        {
            var projectsDbContext1 = _context.TblBoq.Include(t => t.Item).Where(t => t.Item.ProjectId == pid);
            var projectsDbContext = _context.TblItems.Include(t => t.Project).Where(t => t.ProjectId == pid);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            ViewBag.itName = projectsDbContext.Select(b => b.ItemName).ToList();
            ViewBag.itNo = projectsDbContext.Select(b => b.ItemNo).ToList();
            return View(await projectsDbContext1.ToListAsync());
        }

        public async Task<IActionResult> Search(int pid, string itName, string itNo, string itType)
        {
            var items = _context.TblBoq.Include(t => t.Item).Where(t => t.Item.ProjectId == pid);

            if (!string.IsNullOrEmpty(itName))
            {
                items = items.Where(b => b.Item.ItemName.Contains(itName));
            }

            if (!string.IsNullOrEmpty(itNo))
            {
                items = items.Where(b => b.Item.ItemNo == itNo);
            }

            if (!string.IsNullOrEmpty(itType))
            {
                items = items.Where(b => b.Item.ItemType == itType);
            }
            var projectsDbContext = _context.TblItems.Include(t => t.Project).Where(t => t.ProjectId == pid);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            ViewBag.itName = projectsDbContext.Select(b => b.ItemName).ToList();
            ViewBag.itNo = projectsDbContext.Select(b => b.ItemNo).ToList();
            return View("Index", await items.ToListAsync());
        }

        // GET: TblBoqs1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBoq = await _context.TblBoq
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblBoq == null)
            {
                return NotFound();
            }
            ViewBag.pid = tblBoq.Item.ProjectId;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == tblBoq.Item.ProjectId).FirstOrDefault().Name;
            return View(tblBoq);
        }

        // GET: TblBoqs1/Create
        public IActionResult Create(int pid)
        {
            List<TblItems> lst = _context.TblItems.Where(t => t.ProjectId == pid).ToList();
            ViewData["ItemId"] = new SelectList(lst, "Id", "ItemNo");
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View();
        }

        // POST: TblBoqs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemId,Unit,Qty,Uprice,Notes")] TblBoq tblBoq)
        {
            int? pid = _context.TblItems.Where(t => t.Id == tblBoq.ItemId).FirstOrDefault().ProjectId;
            if (ModelState.IsValid)
            {
               
                _context.Add(tblBoq);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index), new { pid = pid });
            }
          //  int pid = (int)tblBoq.Item.ProjectId;
            List<TblItems> lst = _context.TblItems.Where(t => t.ProjectId == pid).ToList();

            ViewData["ItemId"] = new SelectList(lst, "Id", "ItemNo", tblBoq.ItemId);
            return View(tblBoq);
        }

        // GET: TblBoqs1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBoq = await _context.TblBoq.FindAsync(id);
            if (tblBoq == null)
            {
                return NotFound();
            }

            int? pid = _context.TblItems.Where(t => t.Id == tblBoq.ItemId).FirstOrDefault().ProjectId;
            List<TblItems> lst = _context.TblItems.Where(t => t.ProjectId == pid).ToList();
            ViewData["ItemId"] = new SelectList(lst, "Id", "ItemNo", tblBoq.ItemId);
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblBoq);
        }

        // POST: TblBoqs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemId,Unit,Qty,Uprice,Notes")] TblBoq tblBoq)
        {
            if (id != tblBoq.Id)
            {
                return NotFound();
            }
            int? pid = _context.TblItems.Where(t => t.Id == tblBoq.ItemId).FirstOrDefault().ProjectId;
            if (ModelState.IsValid)
            {
          
                try
                {
                    _context.Update(tblBoq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBoqExists(tblBoq.Id))
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
            List<TblItems> lst = _context.TblItems.Where(t => t.ProjectId == pid).ToList();
            ViewData["ItemId"] = new SelectList(lst, "Id", "ItemNo", tblBoq.ItemId);
            return View(tblBoq);
        }

        // GET: TblBoqs1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var tblBoq = await _context.TblBoq
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblBoq == null)
            {
                return NotFound();
            }
            int? pid = _context.TblItems.Where(t => t.Id == tblBoq.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            return View(tblBoq);
        }

        // POST: TblBoqs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBoq = await _context.TblBoq.FindAsync(id);
            int? pid = _context.TblItems.Where(t => t.Id == tblBoq.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            _context.TblBoq.Remove(tblBoq);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { pid = pid });
        }

        private bool TblBoqExists(int id)
        {
            return _context.TblBoq.Any(e => e.Id == id);
        }
    }
}
