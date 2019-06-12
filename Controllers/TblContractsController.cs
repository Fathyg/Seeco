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
    public class TblContractsController : Controller
    {
        private readonly ProjectsDbContext _context;

        public TblContractsController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: TblContracts
        public async Task<IActionResult> Index()
        {
            var projectsDbContext = _context.TblContracts.Include(t => t.Client).Include(t => t.ConsultantContractor).Include(t => t.ConsultantDesign).Include(t => t.ConsultantSupervision).Include(t => t.Contractor);
            return View(await projectsDbContext.ToListAsync());
        }

        // GET: TblContracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContracts = await _context.TblContracts
                .Include(t => t.Client)
                .Include(t => t.ConsultantContractor)
                .Include(t => t.ConsultantDesign)
                .Include(t => t.ConsultantSupervision)
                .Include(t => t.Contractor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblContracts == null)
            {
                return NotFound();
            }

            return View(tblContracts);
        }

        // GET: TblContracts/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.TblClients, "Id", "Id");
            ViewData["ConsultantContractorId"] = new SelectList(_context.TblConsultants, "Id", "Id");
            ViewData["ConsultantDesignId"] = new SelectList(_context.TblConsultants, "Id", "Id");
            ViewData["ConsultantSupervisionId"] = new SelectList(_context.TblConsultants, "Id", "Id");
            ViewData["ContractorId"] = new SelectList(_context.TblContractors, "Id", "Id");
            return View();
        }

        // POST: TblContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,ContractorId,ConsultantDesignId,ConsultantSupervisionId,ConsultantContractorId,Date,BaseValue,Period,Notes")] TblContracts tblContracts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblContracts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.TblClients, "Id", "Id", tblContracts.ClientId);
            ViewData["ConsultantContractorId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantContractorId);
            ViewData["ConsultantDesignId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantDesignId);
            ViewData["ConsultantSupervisionId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantSupervisionId);
            ViewData["ContractorId"] = new SelectList(_context.TblContractors, "Id", "Id", tblContracts.ContractorId);
            return View(tblContracts);
        }

        // GET: TblContracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContracts = await _context.TblContracts.FindAsync(id);
            if (tblContracts == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.TblClients, "Id", "Id", tblContracts.ClientId);
            ViewData["ConsultantContractorId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantContractorId);
            ViewData["ConsultantDesignId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantDesignId);
            ViewData["ConsultantSupervisionId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantSupervisionId);
            ViewData["ContractorId"] = new SelectList(_context.TblContractors, "Id", "Id", tblContracts.ContractorId);
            return View(tblContracts);
        }

        // POST: TblContracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,ContractorId,ConsultantDesignId,ConsultantSupervisionId,ConsultantContractorId,Date,BaseValue,Period,Notes")] TblContracts tblContracts)
        {
            if (id != tblContracts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblContracts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblContractsExists(tblContracts.Id))
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
            ViewData["ClientId"] = new SelectList(_context.TblClients, "Id", "Id", tblContracts.ClientId);
            ViewData["ConsultantContractorId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantContractorId);
            ViewData["ConsultantDesignId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantDesignId);
            ViewData["ConsultantSupervisionId"] = new SelectList(_context.TblConsultants, "Id", "Id", tblContracts.ConsultantSupervisionId);
            ViewData["ContractorId"] = new SelectList(_context.TblContractors, "Id", "Id", tblContracts.ContractorId);
            return View(tblContracts);
        }

        // GET: TblContracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblContracts = await _context.TblContracts
                .Include(t => t.Client)
                .Include(t => t.ConsultantContractor)
                .Include(t => t.ConsultantDesign)
                .Include(t => t.ConsultantSupervision)
                .Include(t => t.Contractor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblContracts == null)
            {
                return NotFound();
            }

            return View(tblContracts);
        }

        // POST: TblContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblContracts = await _context.TblContracts.FindAsync(id);
            _context.TblContracts.Remove(tblContracts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblContractsExists(int id)
        {
            return _context.TblContracts.Any(e => e.Id == id);
        }
    }
}
