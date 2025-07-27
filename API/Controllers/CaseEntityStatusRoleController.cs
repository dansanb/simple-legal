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
    public class CaseEntityStatusRoleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CaseEntityStatusRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseEntityStatusRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseEntityStatusRole>>> GetCaseStatusRoles()
        {
            return await _context.CaseStatusRoles.ToListAsync();
        }

        // GET: api/CaseEntityStatusRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseEntityStatusRole>> GetCaseEntityStatusRole(Guid id)
        {
            var caseEntityStatusRole = await _context.CaseStatusRoles.FindAsync(id);

            if (caseEntityStatusRole == null)
            {
                return NotFound();
            }

            return caseEntityStatusRole;
        }

        // PUT: api/CaseEntityStatusRole/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseEntityStatusRole(Guid id, CaseEntityStatusRole caseEntityStatusRole)
        {
            if (id != caseEntityStatusRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseEntityStatusRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseEntityStatusRoleExists(id))
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

        // POST: api/CaseEntityStatusRole
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseEntityStatusRole>> PostCaseEntityStatusRole(CaseEntityStatusRole caseEntityStatusRole)
        {
            _context.CaseStatusRoles.Add(caseEntityStatusRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseEntityStatusRole", new { id = caseEntityStatusRole.Id }, caseEntityStatusRole);
        }

        // DELETE: api/CaseEntityStatusRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseEntityStatusRole(Guid id)
        {
            var caseEntityStatusRole = await _context.CaseStatusRoles.FindAsync(id);
            if (caseEntityStatusRole == null)
            {
                return NotFound();
            }

            _context.CaseStatusRoles.Remove(caseEntityStatusRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseEntityStatusRoleExists(Guid id)
        {
            return _context.CaseStatusRoles.Any(e => e.Id == id);
        }
    }
}
