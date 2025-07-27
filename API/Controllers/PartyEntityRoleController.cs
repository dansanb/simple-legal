using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core;
using Core.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyEntityRoleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PartyEntityRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PartyEntityRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartyEntityRole>>> GetPartyRoles()
        {
            return await _context.PartyRoles.ToListAsync();
        }

        // GET: api/PartyEntityRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartyEntityRole>> GetPartyEntityRole(Guid id)
        {
            var partyEntityRole = await _context.PartyRoles.FindAsync(id);

            if (partyEntityRole == null)
            {
                return NotFound();
            }

            return partyEntityRole;
        }

        // PUT: api/PartyEntityRole/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartyEntityRole(Guid id, PartyEntityRole partyEntityRole)
        {
            if (id != partyEntityRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(partyEntityRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyEntityRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PartyEntityRole
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartyEntityRole>> PostPartyEntityRole(PartyEntityRole partyEntityRole)
        {
            _context.PartyRoles.Add(partyEntityRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartyEntityRole", new { id = partyEntityRole.Id }, partyEntityRole);
        }

        // DELETE: api/PartyEntityRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartyEntityRole(Guid id)
        {
            var partyEntityRole = await _context.PartyRoles.FindAsync(id);
            if (partyEntityRole == null)
            {
                return NotFound();
            }

            _context.PartyRoles.Remove(partyEntityRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartyEntityRoleExists(Guid id)
        {
            return _context.PartyRoles.Any(e => e.Id == id);
        }
    }
}
