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
    public class CaseEntityNoteController : Controller
    {
        private readonly AppDbContext _context;

        public CaseEntityNoteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CaseEntityNote
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaseNotes.ToListAsync());
        }

        // GET: CaseEntityNote/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityNote = await _context.CaseNotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseEntityNote == null)
            {
                return NotFound();
            }

            return View(caseEntityNote);
        }

        // GET: CaseEntityNote/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaseEntityNote/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Note,Id,DateCreated,DateUpdated")] CaseEntityNote caseEntityNote)
        {
            if (ModelState.IsValid)
            {
                caseEntityNote.Id = Guid.NewGuid();
                _context.Add(caseEntityNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caseEntityNote);
        }

        // GET: CaseEntityNote/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityNote = await _context.CaseNotes.FindAsync(id);
            if (caseEntityNote == null)
            {
                return NotFound();
            }
            return View(caseEntityNote);
        }

        // POST: CaseEntityNote/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Note,Id,DateCreated,DateUpdated")] CaseEntityNote caseEntityNote)
        {
            if (id != caseEntityNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseEntityNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseEntityNoteExists(caseEntityNote.Id))
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
            return View(caseEntityNote);
        }

        // GET: CaseEntityNote/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityNote = await _context.CaseNotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseEntityNote == null)
            {
                return NotFound();
            }

            return View(caseEntityNote);
        }

        // POST: CaseEntityNote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var caseEntityNote = await _context.CaseNotes.FindAsync(id);
            if (caseEntityNote != null)
            {
                _context.CaseNotes.Remove(caseEntityNote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseEntityNoteExists(Guid id)
        {
            return _context.CaseNotes.Any(e => e.Id == id);
        }
    }
}
