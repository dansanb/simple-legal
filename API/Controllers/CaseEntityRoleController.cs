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
    public class CaseEntityRoleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CaseEntityRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseEntityRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseEntityRole>>> GetCaseRoles()
        {
            return await _context.CaseRoles.ToListAsync();
        }

        // GET: api/CaseEntityRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseEntityRole>> GetCaseEntityRole(Guid id)
        {
            var caseEntityRole = await _context.CaseRoles.FindAsync(id);

            if (caseEntityRole == null)
            {
                return NotFound();
            }

            return caseEntityRole;
        }

        // PUT: api/CaseEntityRole/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseEntityRole(Guid id, CaseEntityRole caseEntityRole)
        {
            if (id != caseEntityRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseEntityRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseEntityRoleExists(id))
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

        // POST: api/CaseEntityRole
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseEntityRole>> PostCaseEntityRole(CaseEntityRole caseEntityRole)
        {
            _context.CaseRoles.Add(caseEntityRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseEntityRole", new { id = caseEntityRole.Id }, caseEntityRole);
        }

        // DELETE: api/CaseEntityRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseEntityRole(Guid id)
        {
            var caseEntityRole = await _context.CaseRoles.FindAsync(id);
            if (caseEntityRole == null)
            {
                return NotFound();
            }

            _context.CaseRoles.Remove(caseEntityRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseEntityRoleExists(Guid id)
        {
            return _context.CaseRoles.Any(e => e.Id == id);
        }
    }
}
