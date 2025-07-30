using API.DTO.AgGrid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Core;
using Core.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseEntityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CaseEntityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseEntity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseEntity>>> GetCases()
        {
            return await _context.Cases.ToListAsync();
        }

        // GET: api/CaseEntity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseEntity>> GetCaseEntity(Guid id)
        {
            var caseEntity = await _context.Cases.FindAsync(id);

            if (caseEntity == null)
            {
                return NotFound();
            }

            return caseEntity;
        }

        // PUT: api/CaseEntity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseEntity(Guid id, CaseEntity caseEntity)
        {
            if (id != caseEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseEntityExists(id))
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

        // POST: api/CaseEntity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseEntity>> PostCaseEntity(CaseEntity caseEntity)
        {
            _context.Cases.Add(caseEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseEntity", new { id = caseEntity.Id }, caseEntity);
        }

        // DELETE: api/CaseEntity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseEntity(Guid id)
        {
            var caseEntity = await _context.Cases.FindAsync(id);
            if (caseEntity == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(caseEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseEntityExists(Guid id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }

        // POST: api/[controller]/paged
        [HttpPost("paged")]
        public IActionResult GetCasesPaged([FromBody] AgGridOperationDto gom)
        {
            var query = _context.Cases.AsQueryable();

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

            query = query
                .Skip(gom.StartRow)
                .Take(gom.EndRow - gom.StartRow);


            var result = query
                .AsNoTracking()
                .ToArray();

            return Ok(result);
        }
    }
}