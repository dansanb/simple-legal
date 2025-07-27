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
    public class PartyEntityController : Controller
    {
        private readonly AppDbContext _context;

        public PartyEntityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PartyEntity
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parties.ToListAsync());
        }

        // GET: PartyEntity/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyEntity = await _context.Parties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyEntity == null)
            {
                return NotFound();
            }

            return View(partyEntity);
        }

        // GET: PartyEntity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartyEntity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Company,Phone,Email,Address,Address2,City,State,Id,DateCreated,DateUpdated")] PartyEntity partyEntity)
        {
            if (ModelState.IsValid)
            {
                partyEntity.Id = Guid.NewGuid();
                _context.Add(partyEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partyEntity);
        }

        // GET: PartyEntity/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyEntity = await _context.Parties.FindAsync(id);
            if (partyEntity == null)
            {
                return NotFound();
            }
            return View(partyEntity);
        }

        // POST: PartyEntity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FirstName,LastName,Company,Phone,Email,Address,Address2,City,State,Id,DateCreated,DateUpdated")] PartyEntity partyEntity)
        {
            if (id != partyEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partyEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyEntityExists(partyEntity.Id))
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
            return View(partyEntity);
        }

        // GET: PartyEntity/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyEntity = await _context.Parties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyEntity == null)
            {
                return NotFound();
            }

            return View(partyEntity);
        }

        // POST: PartyEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var partyEntity = await _context.Parties.FindAsync(id);
            if (partyEntity != null)
            {
                _context.Parties.Remove(partyEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyEntityExists(Guid id)
        {
            return _context.Parties.Any(e => e.Id == id);
        }
    }
}
