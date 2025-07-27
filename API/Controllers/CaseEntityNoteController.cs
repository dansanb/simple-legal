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
    public class CaseEntityNoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CaseEntityNoteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseEntityNote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseEntityNote>>> GetCaseNotes()
        {
            return await _context.CaseNotes.ToListAsync();
        }

        // GET: api/CaseEntityNote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseEntityNote>> GetCaseEntityNote(Guid id)
        {
            var caseEntityNote = await _context.CaseNotes.FindAsync(id);

            if (caseEntityNote == null)
            {
                return NotFound();
            }

            return caseEntityNote;
        }

        // PUT: api/CaseEntityNote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseEntityNote(Guid id, CaseEntityNote caseEntityNote)
        {
            if (id != caseEntityNote.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseEntityNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseEntityNoteExists(id))
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

        // POST: api/CaseEntityNote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseEntityNote>> PostCaseEntityNote(CaseEntityNote caseEntityNote)
        {
            _context.CaseNotes.Add(caseEntityNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseEntityNote", new { id = caseEntityNote.Id }, caseEntityNote);
        }

        // DELETE: api/CaseEntityNote/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseEntityNote(Guid id)
        {
            var caseEntityNote = await _context.CaseNotes.FindAsync(id);
            if (caseEntityNote == null)
            {
                return NotFound();
            }

            _context.CaseNotes.Remove(caseEntityNote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseEntityNoteExists(Guid id)
        {
            return _context.CaseNotes.Any(e => e.Id == id);
        }
    }
}
