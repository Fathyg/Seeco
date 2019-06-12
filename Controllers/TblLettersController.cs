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
    public class TblLettersController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblLettersController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblLetters
        public async Task<IActionResult> Index(int pid)
        {
            var projectsDbContext = _context.TblLetters.Include(t => t.Project).Where(t => t.ProjectId == pid);
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;
            ViewBag.subject = projectsDbContext.Select(b => b.Subject).Distinct().ToList();
            return View(await projectsDbContext.ToListAsync());
        }

        public async Task<IActionResult> Search(int pid, string subject, DateTime? d1, DateTime? d2)
        {
            var projectsDbContext = _context.TblLetters.Include(t => t.Project).Where(t => t.ProjectId == pid);

            ViewBag.subject = projectsDbContext.Select(b => b.Subject).Distinct().ToList();


            if (! string.IsNullOrEmpty(subject))
            {
                projectsDbContext = projectsDbContext.Where(b => b.Subject.Contains(subject));
            }

            if (! string.IsNullOrEmpty(d1.ToString()))
            {
                projectsDbContext = projectsDbContext.Where(b => b.Date >= d1);
            }

            if (! string.IsNullOrEmpty(d2.ToString()))
            {
                projectsDbContext = projectsDbContext.Where(b => b.Date <= d2);
            }
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            ViewBag.pid = pid;

            return View("Index", await projectsDbContext.ToListAsync());
        }
        // GET: TblLetters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLetters = await _context.TblLetters
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblLetters == null)
            {
                return NotFound();
            }

            ViewBag.pr = _context.TblProjects.Where(t => t.Id == tblLetters.ProjectId).FirstOrDefault().Name;
            ViewBag.pid = tblLetters.ProjectId;
            return View(tblLetters);
        }

        // GET: TblLetters/Create
        public IActionResult Create(int pid)
        {
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Name");
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View();
        }

        // POST: TblLetters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,Date,DateReceived,IssuedBy,DirectedTo,Subject,FilePath,Descriptiopn")] TblLetters tblLetters, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file == null || file.Length==0)
                {
                    return Content("File not selected");
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagesLetters", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                tblLetters.FilePath = path;
                 
                _context.Add(tblLetters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { pid = tblLetters.ProjectId });
            }
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Name", tblLetters.ProjectId);
            return View(tblLetters);
        }

        // GET: TblLetters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLetters = await _context.TblLetters.FindAsync(id);
            if (tblLetters == null)
            {
                return NotFound();
            }
            int pid = (int)tblLetters.ProjectId;
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Name", tblLetters.ProjectId);
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblLetters);
        }

        // POST: TblLetters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,Date,DateReceived,IssuedBy,DirectedTo,Subject,FilePath,Descriptiopn")] TblLetters tblLetters)
        {
            if (id != tblLetters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int pid = (int)tblLetters.ProjectId;
                try
                {
                    _context.Update(tblLetters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLettersExists(tblLetters.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.TblProjects, "Id", "Name", tblLetters.ProjectId);
            return View(tblLetters);
        }

        // GET: TblLetters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLetters = await _context.TblLetters
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblLetters == null)
            {
                return NotFound();
            }
            int pid = (int)tblLetters.ProjectId;
            ViewBag.pid = pid;
            ViewBag.pr = _context.TblProjects.Where(t => t.Id == pid).FirstOrDefault().Name;
            return View(tblLetters);
        }

        // POST: TblLetters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblLetters = await _context.TblLetters.FindAsync(id);
            int pid = (int)tblLetters.ProjectId;
            _context.TblLetters.Remove(tblLetters);
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
                {".csv", "text/csv"}
            };
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/ImagesLetters", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private bool TblLettersExists(int id)
        {
            return _context.TblLetters.Any(e => e.Id == id);
        }
    }
}
