using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDGen.Models;

namespace CRUDGen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        private readonly DbCtx _context;

        public ExpedienteController(DbCtx context)
        {
            _context = context;
        }

        // GET: api/Expediente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ARQ_EXPEDIENT>>> GetARQ_EXPEDIENT()
        {
            return await _context.ARQ_EXPEDIENT.ToListAsync();
        }

        // GET: api/Expediente/5
        [HttpGet("{nomintern}")]
        public async Task<ActionResult<ARQ_EXPEDIENT>> GetARQ_EXPEDIENT(string nomintern)
        {
            var aRQ_EXPEDIENT = await _context.ARQ_EXPEDIENT.FindAsync(nomintern);

            if (aRQ_EXPEDIENT == null)
            {
                return NotFound();
            }

            return aRQ_EXPEDIENT;
        }

        // PUT: api/Expediente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{nomintern}")]
        public async Task<IActionResult> PutARQ_EXPEDIENT(int id, ARQ_EXPEDIENT aRQ_EXPEDIENT)
        {
            if (id != aRQ_EXPEDIENT.ARQ_EXPEDIENT_ID)
            {
                return BadRequest();
            }

            _context.Entry(aRQ_EXPEDIENT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ARQ_EXPEDIENTExists(id))
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

        // POST: api/Expediente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ARQ_EXPEDIENT>> PostARQ_EXPEDIENT(ARQ_EXPEDIENT aRQ_EXPEDIENT)
        {
            _context.ARQ_EXPEDIENT.Add(aRQ_EXPEDIENT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetARQ_EXPEDIENT", new { id = aRQ_EXPEDIENT.ARQ_EXPEDIENT_ID }, aRQ_EXPEDIENT);
        }

        // DELETE: api/Expediente/5
        [HttpDelete("{nomintern}")]
        public async Task<IActionResult> DeleteARQ_EXPEDIENT(int id)
        {
            var aRQ_EXPEDIENT = await _context.ARQ_EXPEDIENT.FindAsync(id);
            if (aRQ_EXPEDIENT == null)
            {
                return NotFound();
            }

            _context.ARQ_EXPEDIENT.Remove(aRQ_EXPEDIENT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ARQ_EXPEDIENTExists(int id)
        {
            return _context.ARQ_EXPEDIENT.Any(e => e.ARQ_EXPEDIENT_ID == id);
        }
    }
}
