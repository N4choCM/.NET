using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntitiesController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ILogger<BaseEntitiesController> _logger;


        public BaseEntitiesController(UniversityDBContext context, ILogger<BaseEntitiesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/BaseEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseEntity>>> GetBaseEntity()
        {
            _logger.LogTrace($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Trace Level Log");
            _logger.LogDebug($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Debug Level Log");
            _logger.LogInformation($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Information Level Log");
            _logger.LogWarning($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Warning Level Log");
            _logger.LogError($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Error Level Log");
            _logger.LogCritical($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Critical Level Log");

            if (_context.BaseEntity == null)
            {
              return NotFound();
            }
            return await _context.BaseEntity.ToListAsync();
        }

        // GET: api/BaseEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseEntity>> GetBaseEntity(int id)
        {
            _logger.LogTrace($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Trace Level Log");
            _logger.LogDebug($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Debug Level Log");
            _logger.LogInformation($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Information Level Log");
            _logger.LogWarning($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Warning Level Log");
            _logger.LogError($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Error Level Log");
            _logger.LogCritical($"{nameof(BaseEntitiesController)} - {nameof(GetBaseEntity)} - Critical Level Log");

            if (_context.BaseEntity == null)
            {
              return NotFound();
            }
            var baseEntity = await _context.BaseEntity.FindAsync(id);

            if (baseEntity == null)
            {
                return NotFound();
            }

            return baseEntity;
        }

        // PUT: api/BaseEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseEntity(int id, BaseEntity baseEntity)
        {
            if (id != baseEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseEntityExists(id))
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

        // POST: api/BaseEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseEntity>> PostBaseEntity(BaseEntity baseEntity)
        {
          if (_context.BaseEntity == null)
          {
              return Problem("Entity set 'UniversityDBContext.BaseEntity'  is null.");
          }
            _context.BaseEntity.Add(baseEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseEntity", new { id = baseEntity.Id }, baseEntity);
        }

        // DELETE: api/BaseEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseEntity(int id)
        {
            if (_context.BaseEntity == null)
            {
                return NotFound();
            }
            var baseEntity = await _context.BaseEntity.FindAsync(id);
            if (baseEntity == null)
            {
                return NotFound();
            }

            _context.BaseEntity.Remove(baseEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseEntityExists(int id)
        {
            return (_context.BaseEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
