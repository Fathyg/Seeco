using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seeco.Models;

namespace Seeco.Controllers
{
    public class TblRequestsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblRequestsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblRequests
        public async Task<IActionResult> Index(int pid)
        {
            var projectsDbContext = _context.TblRequests.Include(t => t.ConsultantTeam).Include(t => t.ContractorTeam).Include(t => t.SubItem)
                .Where(t => t.ConsultantTeam.ProjectId == pid);
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.subitem = _context.TblSubItemsSpecifications.Where(t => t.Item.ProjectId == pid).Select(t => t.SubItemName).ToList();
            return View(await projectsDbContext.ToListAsync());
        }

        // GET: TblRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRequests = await _context.TblRequests
                .Include(t => t.ConsultantTeam)
                .Include(t => t.ContractorTeam)
                .Include(t => t.SubItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblRequests == null)
            {
                return NotFound();
            }
            int? pid= _context.TblItems.Include(t => t.Project).Where(t => t.Id == tblRequests.SubItem.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name; 
            return View(tblRequests);
        }

        // GET: TblRequests/Create
        public IActionResult Create(int pid)
        {
            ViewData["ConsultantTeamId"] = new SelectList(_context.TblConsultantsTeams, "Id", "ResponsibleName");
            ViewData["ContractorTeamId"] = new SelectList(_context.TblContractorsTeams, "Id", "ResponsibleName");
            ViewData["SubItemId"] = new SelectList(_context.TblSubItemsSpecifications, "Id", "SubItemName");
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View();
        }

        // POST: TblRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubItemId,Date,Subject,ContractorTeamId,ConsultantTeamId,FilePath,Decisions")] TblRequests tblRequests, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file == null || file.Length == 0)
                {
                    return Content("File not selected");
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Requests", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                tblRequests.FilePath = path;

                int? pid = _context.TblItems.Include(t => t.Project).Where(t => t.Id == tblRequests.SubItem.ItemId).FirstOrDefault().ProjectId;

                _context.Add(tblRequests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { pid = pid });
            }
            ViewData["ConsultantTeamId"] = new SelectList(_context.TblConsultantsTeams, "Id", "ResponsibleName", tblRequests.ConsultantTeamId);
            ViewData["ContractorTeamId"] = new SelectList(_context.TblContractorsTeams, "Id", "ResponsibleName", tblRequests.ContractorTeamId);
            ViewData["SubItemId"] = new SelectList(_context.TblSubItemsSpecifications, "Id", "SubItemName", tblRequests.SubItemId);
            return View(tblRequests);
        }

        // GET: TblRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRequests = await _context.TblRequests.FindAsync(id);
            if (tblRequests == null)
            {
                return NotFound();
            }
            int? pid = _context.TblItems.Include(t => t.Project).Where(t => t.Id == tblRequests.SubItem.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewData["ConsultantTeamId"] = new SelectList(_context.TblConsultantsTeams, "Id", "Id", tblRequests.ConsultantTeamId);
            ViewData["ContractorTeamId"] = new SelectList(_context.TblContractorsTeams, "Id", "Id", tblRequests.ContractorTeamId);
            ViewData["SubItemId"] = new SelectList(_context.TblSubItemsSpecifications, "Id", "Id", tblRequests.SubItemId);
            return View(tblRequests);
        }

        // POST: TblRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubItemId,Date,Subject,ContractorTeamId,ConsultantTeamId,FilePath,Decisions")] TblRequests tblRequests, IFormFile file)
        {
            if (id != tblRequests.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (file == null || file.Length == 0)
                {
                    return Content("File not selected");
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Requests", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                tblRequests.FilePath = path;

                int? pid = _context.TblItems.Include(t => t.Project).Where(t => t.Id == tblRequests.SubItem.ItemId).FirstOrDefault().ProjectId;

                try
                {
                    _context.Update(tblRequests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRequestsExists(tblRequests.Id))
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
            ViewData["ConsultantTeamId"] = new SelectList(_context.TblConsultantsTeams, "Id", "Id", tblRequests.ConsultantTeamId);
            ViewData["ContractorTeamId"] = new SelectList(_context.TblContractorsTeams, "Id", "Id", tblRequests.ContractorTeamId);
            ViewData["SubItemId"] = new SelectList(_context.TblSubItemsSpecifications, "Id", "Id", tblRequests.SubItemId);
            return View(tblRequests);
        }

        // GET: TblRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRequests = await _context.TblRequests
                .Include(t => t.ConsultantTeam)
                .Include(t => t.ContractorTeam)
                .Include(t => t.SubItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblRequests == null)
            {
                return NotFound();
            }
            int? pid = _context.TblItems.Include(t => t.Project).Where(t => t.Id == tblRequests.SubItem.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblRequests);
        }

        // POST: TblRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRequests = await _context.TblRequests.FindAsync(id);
            int? pid = _context.TblItems.Include(t => t.Project).Where(t => t.Id == tblRequests.SubItem.ItemId).FirstOrDefault().ProjectId;
            _context.TblRequests.Remove(tblRequests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { pid = pid });
        }

        private bool TblRequestsExists(int id)
        {
            return _context.TblRequests.Any(e => e.Id == id);
        }
    }
}
