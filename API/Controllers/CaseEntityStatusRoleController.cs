using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using API.DTO.AgGrid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core;
using Core.Models;

namespace API.Controllers
{
    [Route("api/case-status-roles")]
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

        [HttpPost("paged")]
        public IActionResult GetCasesPaged([FromBody] AgGridOperationDto? gom)
        {
            var query = _context.CaseStatusRoles.AsQueryable();
            if (gom == null)
            {
                gom = new AgGridOperationDto()
                {
                    StartRow = 0,
                    EndRow = 5,
                };
            }

            Func<string, AgGridFilterDto, List<object>, string> getConditionFromModel =
                (string colName, AgGridFilterDto model, List<object> values) =>
                {
                    string modelResult = "";

                    switch (model.FilterType)
                    {
                        case "text":
                            switch (model.Type)
                            {
                                case "equals":
                                    modelResult = $"{colName} = \"{model.Filter}\"";
                                    break;
                                case "notEqual":
                                    modelResult = $"{colName} <> \"{model.Filter}\"";
                                    break;
                                case "contains":
                                    modelResult = $"{colName}.Contains(@{values.Count})";
                                    values.Add(model.Filter);
                                    break;
                                case "notContains":
                                    modelResult = $"!{colName}.Contains(@{values.Count})";
                                    values.Add(model.Filter);
                                    break;
                                case "startsWith":
                                    modelResult = $"{colName}.StartsWith(@{values.Count})";
                                    values.Add(model.Filter);
                                    break;
                                case "endsWith":
                                    modelResult = $"{colName}.EndsWith(@{values.Count})";
                                    values.Add(model.Filter);
                                    break;
                            }

                            break;
                        case "number":
                            switch (model.Type)
                            {
                                case "equals":
                                    modelResult = $"{colName} = {model.Filter}";
                                    break;
                                case "notEqual":
                                    modelResult = $"{colName} <> {model.Filter}";
                                    break;
                                case "lessThan":
                                    modelResult = $"{colName} < {model.Filter}";
                                    break;
                                case "lessThanOrEqual":
                                    modelResult = $"{colName} <= {model.Filter}";
                                    break;
                                case "greaterThan":
                                    modelResult = $"{colName} > {model.Filter}";
                                    break;
                                case "greaterThanOrEqual":
                                    modelResult = $"{colName} >= {model.Filter}";
                                    break;
                                case "inRange":
                                    modelResult = $"({colName} >= {model.Filter} AND {colName} <= {model.FilterTo})";
                                    break;
                            }

                            break;
                        case "date":
                            values.Add(DateTime.Parse(model.DateFrom));

                            switch (model.Type)
                            {
                                case "equals":
                                    modelResult = $"{colName} = @{values.Count - 1}";
                                    break;
                                case "notEqual":
                                    modelResult = $"{colName} <> @{values.Count - 1}";
                                    break;
                                case "lessThan":
                                    modelResult = $"{colName} < @{values.Count - 1}";
                                    break;
                                case "lessThanOrEqual":
                                    modelResult = $"{colName} <= @{values.Count - 1}";
                                    break;
                                case "greaterThan":
                                    modelResult = $"{colName} > @{values.Count - 1}";
                                    break;
                                case "greaterThanOrEqual":
                                    modelResult = $"{colName} >= @{values.Count - 1}";
                                    break;
                                case "inRange":
                                    values.Add(DateTime.Parse(model.DateTo));
                                    modelResult =
                                        $"({colName} >= @{values.Count - 2} AND {colName} <= @{values.Count - 1})";
                                    break;
                            }

                            break;
                    }

                    return modelResult;
                };

            if (gom.FilterModel != null)
            {
                foreach (var f in gom.FilterModel)
                {
                    string condition, tmp;
                    List<object> conditionValues = new List<object>();

                    if (!string.IsNullOrWhiteSpace(f.Value.LogicOperator))
                    {
                        tmp = getConditionFromModel(f.Key, f.Value.Condition1, conditionValues);
                        condition = tmp;

                        tmp = getConditionFromModel(f.Key, f.Value.Condition2, conditionValues);
                        condition = $"{condition} {f.Value.LogicOperator} {tmp}";
                    }
                    else
                    {
                        tmp = getConditionFromModel(f.Key, f.Value, conditionValues);
                        condition = tmp;
                    }

                    if (conditionValues.Count == 0)
                    {
                        query = query.Where(condition);
                    }
                    else
                    {
                        query = query.Where(condition, conditionValues.ToArray());
                    }
                }
            }

            if (gom.FilterModel != null)
            {
                foreach (var s in gom.SortModel)
                {
                    switch (s.Sort)
                    {
                        case "asc":
                            query = query.OrderBy(s.ColId);
                            break;
                        case "desc":
                            query = query.OrderBy($"{s.ColId} descending");
                            break;
                    }
                }
            }

            query = query
                .Skip(gom.StartRow)
                .Take(gom.EndRow - gom.StartRow);


            var result = query
                .AsNoTracking()
                .Include(b => b.CaseRole)
                .ToArray();

            return Ok(result);
        }
    }
}
