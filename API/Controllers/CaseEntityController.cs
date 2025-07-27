using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core;
using Core.Models;

namespace API.Controllers
{
    public class CaseEntityController : Controller
    {
        private readonly AppDbContext _context;

        public CaseEntityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CaseEntity
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cases.ToListAsync());
        }

        // GET: CaseEntity/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntity = await _context.Cases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseEntity == null)
            {
                return NotFound();
            }

            return View(caseEntity);
        }

        // GET: CaseEntity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaseEntity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,DateCreated,DateUpdated")] CaseEntity caseEntity)
        {
            if (ModelState.IsValid)
            {
                caseEntity.Id = Guid.NewGuid();
                _context.Add(caseEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caseEntity);
        }

        // GET: CaseEntity/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntity = await _context.Cases.FindAsync(id);
            if (caseEntity == null)
            {
                return NotFound();
            }
            return View(caseEntity);
        }

        // POST: CaseEntity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,DateCreated,DateUpdated")] CaseEntity caseEntity)
        {
            if (id != caseEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseEntityExists(caseEntity.Id))
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
            return View(caseEntity);
        }

        // GET: CaseEntity/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntity = await _context.Cases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseEntity == null)
            {
                return NotFound();
            }

            return View(caseEntity);
        }

        // POST: CaseEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var caseEntity = await _context.Cases.FindAsync(id);
            if (caseEntity != null)
            {
                _context.Cases.Remove(caseEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseEntityExists(Guid id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
