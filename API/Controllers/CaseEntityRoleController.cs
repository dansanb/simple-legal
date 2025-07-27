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
    public class CaseEntityRoleController : Controller
    {
        private readonly AppDbContext _context;

        public CaseEntityRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CaseEntityRole
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaseRoles.ToListAsync());
        }

        // GET: CaseEntityRole/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityRole = await _context.CaseRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseEntityRole == null)
            {
                return NotFound();
            }

            return View(caseEntityRole);
        }

        // GET: CaseEntityRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaseEntityRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,DateCreated,DateUpdated")] CaseEntityRole caseEntityRole)
        {
            if (ModelState.IsValid)
            {
                caseEntityRole.Id = Guid.NewGuid();
                _context.Add(caseEntityRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caseEntityRole);
        }

        // GET: CaseEntityRole/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityRole = await _context.CaseRoles.FindAsync(id);
            if (caseEntityRole == null)
            {
                return NotFound();
            }
            return View(caseEntityRole);
        }

        // POST: CaseEntityRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,DateCreated,DateUpdated")] CaseEntityRole caseEntityRole)
        {
            if (id != caseEntityRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseEntityRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseEntityRoleExists(caseEntityRole.Id))
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
            return View(caseEntityRole);
        }

        // GET: CaseEntityRole/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityRole = await _context.CaseRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseEntityRole == null)
            {
                return NotFound();
            }

            return View(caseEntityRole);
        }

        // POST: CaseEntityRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var caseEntityRole = await _context.CaseRoles.FindAsync(id);
            if (caseEntityRole != null)
            {
                _context.CaseRoles.Remove(caseEntityRole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseEntityRoleExists(Guid id)
        {
            return _context.CaseRoles.Any(e => e.Id == id);
        }
    }
}
