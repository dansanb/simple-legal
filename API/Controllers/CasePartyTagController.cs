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
    public class CasePartyTagController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CasePartyTagController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CasePartyTag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CasePartyTag>>> GetCasePartyTags()
        {
            return await _context.CasePartyTags.ToListAsync();
        }

        // GET: api/CasePartyTag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CasePartyTag>> GetCasePartyTag(Guid id)
        {
            var casePartyTag = await _context.CasePartyTags.FindAsync(id);

            if (casePartyTag == null)
            {
                return NotFound();
            }

            return casePartyTag;
        }

        // PUT: api/CasePartyTag/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasePartyTag(Guid id, CasePartyTag casePartyTag)
        {
            if (id != casePartyTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(casePartyTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasePartyTagExists(id))
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

        // POST: api/CasePartyTag
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CasePartyTag>> PostCasePartyTag(CasePartyTag casePartyTag)
        {
            _context.CasePartyTags.Add(casePartyTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasePartyTag", new { id = casePartyTag.Id }, casePartyTag);
        }

        // DELETE: api/CasePartyTag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCasePartyTag(Guid id)
        {
            var casePartyTag = await _context.CasePartyTags.FindAsync(id);
            if (casePartyTag == null)
            {
                return NotFound();
            }

            _context.CasePartyTags.Remove(casePartyTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CasePartyTagExists(Guid id)
        {
            return _context.CasePartyTags.Any(e => e.Id == id);
        }
    }
}
