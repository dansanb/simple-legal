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
    public class PartyEntityRoleController : Controller
    {
        private readonly AppDbContext _context;

        public PartyEntityRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PartyEntityRole
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartyRoles.ToListAsync());
        }

        // GET: PartyEntityRole/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyEntityRole = await _context.PartyRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyEntityRole == null)
            {
                return NotFound();
            }

            return View(partyEntityRole);
        }

        // GET: PartyEntityRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartyEntityRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,DateCreated,DateUpdated")] PartyEntityRole partyEntityRole)
        {
            if (ModelState.IsValid)
            {
                partyEntityRole.Id = Guid.NewGuid();
                _context.Add(partyEntityRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partyEntityRole);
        }

        // GET: PartyEntityRole/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyEntityRole = await _context.PartyRoles.FindAsync(id);
            if (partyEntityRole == null)
            {
                return NotFound();
            }
            return View(partyEntityRole);
        }

        // POST: PartyEntityRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,DateCreated,DateUpdated")] PartyEntityRole partyEntityRole)
        {
            if (id != partyEntityRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partyEntityRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyEntityRoleExists(partyEntityRole.Id))
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
            return View(partyEntityRole);
        }

        // GET: PartyEntityRole/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyEntityRole = await _context.PartyRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyEntityRole == null)
            {
                return NotFound();
            }

            return View(partyEntityRole);
        }

        // POST: PartyEntityRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var partyEntityRole = await _context.PartyRoles.FindAsync(id);
            if (partyEntityRole != null)
            {
                _context.PartyRoles.Remove(partyEntityRole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyEntityRoleExists(Guid id)
        {
            return _context.PartyRoles.Any(e => e.Id == id);
        }
    }
}
