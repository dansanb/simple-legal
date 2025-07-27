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
    public class PartyEntityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PartyEntityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PartyEntity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartyEntity>>> GetParties()
        {
            return await _context.Parties.ToListAsync();
        }

        // GET: api/PartyEntity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartyEntity>> GetPartyEntity(Guid id)
        {
            var partyEntity = await _context.Parties.FindAsync(id);

            if (partyEntity == null)
            {
                return NotFound();
            }

            return partyEntity;
        }

        // PUT: api/PartyEntity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartyEntity(Guid id, PartyEntity partyEntity)
        {
            if (id != partyEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(partyEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyEntityExists(id))
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

        // POST: api/PartyEntity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartyEntity>> PostPartyEntity(PartyEntity partyEntity)
        {
            _context.Parties.Add(partyEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartyEntity", new { id = partyEntity.Id }, partyEntity);
        }

        // DELETE: api/PartyEntity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartyEntity(Guid id)
        {
            var partyEntity = await _context.Parties.FindAsync(id);
            if (partyEntity == null)
            {
                return NotFound();
            }

            _context.Parties.Remove(partyEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartyEntityExists(Guid id)
        {
            return _context.Parties.Any(e => e.Id == id);
        }
    }
}
