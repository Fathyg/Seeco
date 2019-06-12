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
    public class TblDrawingsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblDrawingsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblDrawings
        public async Task<IActionResult> Index(int? pid)
        {
            var projectsDbContext = _context.TblDrawings.Include(t => t.Item).ThenInclude(t => t.Project).Where(t => t.Item.ProjectId == pid);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            ViewBag.DName = projectsDbContext.Select(t => t.DrawingName).Distinct().ToList();
           
            return View(await projectsDbContext.ToListAsync());
        }

        public async Task<IActionResult> Search(int pid, string DName, DateTime? d1, DateTime? d2)
        {
            var projectsDbContext = _context.TblDrawings.Include(t => t.Item).ThenInclude(t => t.Project).Where(t => t.Item.ProjectId == pid);

            if (! string.IsNullOrEmpty(DName))
            {
                projectsDbContext = projectsDbContext.Where(t => t.DrawingName == DName);
            }

            if (! string.IsNullOrEmpty(d1.ToString()))
            {
                projectsDbContext = projectsDbContext.Where(t => t.DateIssued >= d1);
            }

            if (! string.IsNullOrEmpty(d2.ToString()))
            {
                projectsDbContext = projectsDbContext.Where(t => t.DateIssued <= d2);
            }

            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            ViewBag.DName = projectsDbContext.Select(t => t.DrawingName).Distinct().ToList();


            return View("Index", await projectsDbContext.ToListAsync());
        }

        // GET: TblDrawings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrawings = await _context.TblDrawings
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDrawings == null)
            {
                return NotFound();
            }
            int pid = (int)_context.TblItems.Where(t => t.Id == tblDrawings.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            return View(tblDrawings);
        }

        // GET: TblDrawings/Create
        public IActionResult Create(int pid)
        {
            ViewData["ItemId"] = new SelectList(_context.TblItems, "Id", "ItemName");
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View();
        }

        // POST: TblDrawings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemId,DrawingName,DrawingType,DateIssued,DateReceived,DrawBy,Receiver,FilePath,Notes")] TblDrawings tblDrawings, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file == null || file.Length == 0)
                {
                    return Content("File not selected");
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Drawings", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                tblDrawings.FilePath = path;
                _context.Add(tblDrawings);
                await _context.SaveChangesAsync();
                int pid = (int)_context.TblItems.Where(t => t.Id == tblDrawings.ItemId).FirstOrDefault().ProjectId;
                return RedirectToAction(nameof(Index), new { pid = pid });
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "Id", "ItemName", tblDrawings.ItemId);
            return View(tblDrawings);
        }

        // GET: TblDrawings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrawings = await _context.TblDrawings.FindAsync(id);
            if (tblDrawings == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "Id", "ItemName", tblDrawings.ItemId);
            int pid = (int)_context.TblItems.Where(t => t.Id == tblDrawings.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblDrawings);
        }

        // POST: TblDrawings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemId,DrawingName,DrawingType,DateIssued,DateReceived,DrawBy,Receiver,FilePath,Notes")] TblDrawings tblDrawings)
        {
            if (id != tblDrawings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int pid = (int)_context.TblItems.Where(t => t.Id == tblDrawings.ItemId).FirstOrDefault().ProjectId;
                try
                {
                    _context.Update(tblDrawings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDrawingsExists(tblDrawings.Id))
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
            ViewData["ItemId"] = new SelectList(_context.TblItems, "Id", "ItemName", tblDrawings.ItemId);
            return View(tblDrawings);
        }

        // GET: TblDrawings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDrawings = await _context.TblDrawings
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDrawings == null)
            {
                return NotFound();
            }
            int pid = (int)_context.TblItems.Where(t => t.Id == tblDrawings.ItemId).FirstOrDefault().ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblDrawings);
        }

        // POST: TblDrawings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDrawings = await _context.TblDrawings.FindAsync(id);
            int pid = (int)_context.TblItems.Where(t => t.Id == tblDrawings.ItemId).FirstOrDefault().ProjectId;
            _context.TblDrawings.Remove(tblDrawings);
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
                           "wwwroot/Drawings", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private bool TblDrawingsExists(int id)
        {
            return _context.TblDrawings.Any(e => e.Id == id);
        }
    }
}
