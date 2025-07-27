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
    public class CasePartyTagController : Controller
    {
        private readonly AppDbContext _context;

        public CasePartyTagController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CasePartyTag
        public async Task<IActionResult> Index()
        {
            return View(await _context.CasePartyTags.ToListAsync());
        }

        // GET: CasePartyTag/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casePartyTag = await _context.CasePartyTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casePartyTag == null)
            {
                return NotFound();
            }

            return View(casePartyTag);
        }

        // GET: CasePartyTag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasePartyTag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCreated,DateUpdated")] CasePartyTag casePartyTag)
        {
            if (ModelState.IsValid)
            {
                casePartyTag.Id = Guid.NewGuid();
                _context.Add(casePartyTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casePartyTag);
        }

        // GET: CasePartyTag/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casePartyTag = await _context.CasePartyTags.FindAsync(id);
            if (casePartyTag == null)
            {
                return NotFound();
            }
            return View(casePartyTag);
        }

        // POST: CasePartyTag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DateCreated,DateUpdated")] CasePartyTag casePartyTag)
        {
            if (id != casePartyTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casePartyTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasePartyTagExists(casePartyTag.Id))
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
            return View(casePartyTag);
        }

        // GET: CasePartyTag/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casePartyTag = await _context.CasePartyTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casePartyTag == null)
            {
                return NotFound();
            }

            return View(casePartyTag);
        }

        // POST: CasePartyTag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var casePartyTag = await _context.CasePartyTags.FindAsync(id);
            if (casePartyTag != null)
            {
                _context.CasePartyTags.Remove(casePartyTag);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasePartyTagExists(Guid id)
        {
            return _context.CasePartyTags.Any(e => e.Id == id);
        }
    }
}
