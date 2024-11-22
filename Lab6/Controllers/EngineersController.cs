using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6.Data;
using Lab6.Models;

namespace Lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineersController : ControllerBase
    {
        private readonly Lab6DbContext _context;

        public EngineersController(Lab6DbContext context)
        {
            _context = context;
        }

        // GET: api/Engineers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceEngineer>>> GetEngineers()
        {
            return await _context.MaintenanceEngineers
                                 .Include(e => e.EngineerSkills) // Load related skills
                                 .ToListAsync();
        }

        // GET: api/Engineers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceEngineer>> GetEngineer(int id)
        {
            var engineer = await _context.MaintenanceEngineers
                                         .Include(e => e.EngineerSkills) // Load related skills
                                         .FirstOrDefaultAsync(e => e.EngineerId == id);

            if (engineer == null)
            {
                return NotFound();
            }

            return engineer;
        }

        // PUT: api/Engineers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEngineer(int id, MaintenanceEngineer engineer)
        {
            if (id != engineer.EngineerId)
            {
                return BadRequest();
            }

            _context.Entry(engineer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineerExists(id))
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

        // POST: api/Engineers
        [HttpPost]
        public async Task<ActionResult<MaintenanceEngineer>> PostEngineer(MaintenanceEngineer engineer)
        {
            _context.MaintenanceEngineers.Add(engineer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEngineer", new { id = engineer.EngineerId }, engineer);
        }

        // DELETE: api/Engineers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEngineer(int id)
        {
            var engineer = await _context.MaintenanceEngineers.FindAsync(id);
            if (engineer == null)
            {
                return NotFound();
            }

            _context.MaintenanceEngineers.Remove(engineer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper to check if an engineer exists
        private bool EngineerExists(int id)
        {
            return _context.MaintenanceEngineers.Any(e => e.EngineerId == id);
        }
    }
}
