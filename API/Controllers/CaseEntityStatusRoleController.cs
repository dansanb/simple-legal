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
    public class CaseEntityStatusRoleController : Controller
    {
        private readonly AppDbContext _context;

        public CaseEntityStatusRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CaseEntityStatusRole
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaseStatusRoles.ToListAsync());
        }

        // GET: CaseEntityStatusRole/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityStatusRole = await _context.CaseStatusRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseEntityStatusRole == null)
            {
                return NotFound();
            }

            return View(caseEntityStatusRole);
        }

        // GET: CaseEntityStatusRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaseEntityStatusRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,DateCreated,DateUpdated")] CaseEntityStatusRole caseEntityStatusRole)
        {
            if (ModelState.IsValid)
            {
                caseEntityStatusRole.Id = Guid.NewGuid();
                _context.Add(caseEntityStatusRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caseEntityStatusRole);
        }

        // GET: CaseEntityStatusRole/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityStatusRole = await _context.CaseStatusRoles.FindAsync(id);
            if (caseEntityStatusRole == null)
            {
                return NotFound();
            }
            return View(caseEntityStatusRole);
        }

        // POST: CaseEntityStatusRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,DateCreated,DateUpdated")] CaseEntityStatusRole caseEntityStatusRole)
        {
            if (id != caseEntityStatusRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseEntityStatusRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseEntityStatusRoleExists(caseEntityStatusRole.Id))
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
            return View(caseEntityStatusRole);
        }

        // GET: CaseEntityStatusRole/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseEntityStatusRole = await _context.CaseStatusRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseEntityStatusRole == null)
            {
                return NotFound();
            }

            return View(caseEntityStatusRole);
        }

        // POST: CaseEntityStatusRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var caseEntityStatusRole = await _context.CaseStatusRoles.FindAsync(id);
            if (caseEntityStatusRole != null)
            {
                _context.CaseStatusRoles.Remove(caseEntityStatusRole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseEntityStatusRoleExists(Guid id)
        {
            return _context.CaseStatusRoles.Any(e => e.Id == id);
        }
    }
}
