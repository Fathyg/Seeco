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
    public class TblTechProposalsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblTechProposalsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblTechProposals
        public async Task<IActionResult> Index(int pid)
        {
            var projectsDbContext = _context.TblTechProposals.Include(t => t.ConsultantTeam).Include(t => t.ContractorTeam)
                .Include(t => t.SubItem)
                .ThenInclude(t => t.Item).Where(t => t.SubItem.Item.ProjectId == pid);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            return View(await projectsDbContext.ToListAsync());
        }

        // GET: TblTechProposals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTechProposals = await _context.TblTechProposals
                .Include(t => t.ConsultantTeam)
                .Include(t => t.ContractorTeam)
                .Include(t => t.SubItem).ThenInclude(t => t.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTechProposals == null)
            {
                return NotFound();
            }
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == tblTechProposals.SubItem.Item.ProjectId).FirstOrDefault().Name;
            ViewBag.pid = tblTechProposals.SubItem.Item.ProjectId;
            return View(tblTechProposals);
        }

        // GET: TblTechProposals/Create
        public IActionResult Create(int pid)
        {
            ViewData["ConsultantTeamId"] = new SelectList(_context.TblConsultantsTeams, "Id", "ResponsibleName");
            ViewData["ContractorTeamId"] = new SelectList(_context.TblContractorsTeams, "Id", "ResponsibleName");
            ViewData["SubItemId"] = new SelectList(_context.TblSubItemsSpecifications, "Id", "SubItemName");
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            return View();
        }

        // POST: TblTechProposals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubItemId,Date,ConsultantTeamId,ContractorTeamId,FilePath,Provider,Decesions")] TblTechProposals tblTechProposals, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file == null || file.Length == 0)
                {
                    return Content("File not selected");
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TechProposals", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                tblTechProposals.FilePath = path;

                int? pid = _context.TblItems.Where(t => t.Id == tblTechProposals.SubItem.ItemId).FirstOrDefault().ProjectId;

                _context.Add(tblTechProposals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { pid = pid });
            }
            ViewData["ConsultantTeamId"] = new SelectList(_context.TblConsultantsTeams, "Id", "ResponsibleName", tblTechProposals.ConsultantTeamId);
            ViewData["ContractorTeamId"] = new SelectList(_context.TblContractorsTeams, "Id", "ResponsibleName", tblTechProposals.ContractorTeamId);
            ViewData["SubItemId"] = new SelectList(_context.TblSubItemsSpecifications, "Id", "SubItemName", tblTechProposals.SubItemId);
            return View(tblTechProposals);
        }

        // GET: TblTechProposals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTechProposals = await _context.TblTechProposals.FindAsync(id);
            if (tblTechProposals == null)
            {
                return NotFound();
            }
            ViewData["ConsultantTeamId"] = new SelectList(_context.TblConsultantsTeams, "Id", "ResponsibleName", tblTechProposals.ConsultantTeamId);
            ViewData["ContractorTeamId"] = new SelectList(_context.TblContractorsTeams, "Id", "ResponsibleName", tblTechProposals.ContractorTeamId);
            ViewData["SubItemId"] = new SelectList(_context.TblSubItemsSpecifications, "Id", "SubItemName", tblTechProposals.SubItemId);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == tblTechProposals.SubItem.Item.ProjectId).FirstOrDefault().Name;
            ViewBag.pid = tblTechProposals.SubItem.Item.ProjectId;
            return View(tblTechProposals);
        }

        // POST: TblTechProposals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubItemId,Date,ConsultantTeamId,ContractorTeamId,FilePath,Provider,Decesions")] TblTechProposals tblTechProposals, IFormFile file)
        {
            if (id != tblTechProposals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (file == null || file.Length == 0)
                {
                    return Content("File not selected");
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TechProposals", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                tblTechProposals.FilePath = path;

                int? pid = _context.TblItems.Where(t => t.Id == tblTechProposals.SubItem.ItemId).FirstOrDefault().ProjectId;
                try
                {
                    _context.Update(tblTechProposals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTechProposalsExists(tblTechProposals.Id))
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
            ViewData["ConsultantTeamId"] = new SelectList(_context.TblConsultantsTeams, "Id", "ResponsibleName", tblTechProposals.ConsultantTeamId);
            ViewData["ContractorTeamId"] = new SelectList(_context.TblContractorsTeams, "Id", "ResponsibleName", tblTechProposals.ContractorTeamId);
            ViewData["SubItemId"] = new SelectList(_context.TblSubItemsSpecifications, "Id", "SubItemName", tblTechProposals.SubItemId);
            return View(tblTechProposals);
        }

        // GET: TblTechProposals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTechProposals = await _context.TblTechProposals
                .Include(t => t.ConsultantTeam)
                .Include(t => t.ContractorTeam)
                .Include(t => t.SubItem).ThenInclude(t => t.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTechProposals == null)
            {
                return NotFound();
            }
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == tblTechProposals.SubItem.Item.ProjectId).FirstOrDefault().Name;
            ViewBag.pid = tblTechProposals.SubItem.Item.ProjectId;
            return View(tblTechProposals);
        }

        // POST: TblTechProposals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTechProposals = await _context.TblTechProposals.FindAsync(id);
            int? pid = _context.TblItems.Where(t => t.Id == tblTechProposals.SubItem.ItemId).FirstOrDefault().ProjectId;
            _context.TblTechProposals.Remove(tblTechProposals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { pid = pid });
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".dwg", "image/vnd.dwg" },
                {".dxf", "image/x-dxf" }
            };
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/TechProposals", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private bool TblTechProposalsExists(int id)
        {
            return _context.TblTechProposals.Any(e => e.Id == id);
        }
    }
}
