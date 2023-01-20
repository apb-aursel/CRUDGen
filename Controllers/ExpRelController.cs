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
    public class ExpRelController : ControllerBase
    {
        private readonly DbCtx _context;

        public ExpRelController(DbCtx context)
        {
            _context = context;
        }

        // GET: api/ExpRel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ARQ_EXPEDIENTRELACIONAT>>> GetARQ_EXPEDIENTRELACIONAT()
        {
          if (_context.ARQ_EXPEDIENTRELACIONAT == null)
          {
              return NotFound();
          }
            return await _context.ARQ_EXPEDIENTRELACIONAT.ToListAsync();
        }

        // GET: api/ExpRel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ARQ_EXPEDIENTRELACIONAT>> GetARQ_EXPEDIENTRELACIONAT(string id)
        {
          if (_context.ARQ_EXPEDIENTRELACIONAT == null)
          {
              return NotFound();
          }
            var aRQ_EXPEDIENTRELACIONAT = await _context.ARQ_EXPEDIENTRELACIONAT.FindAsync(id);

            if (aRQ_EXPEDIENTRELACIONAT == null)
            {
                return NotFound();
            }

            return aRQ_EXPEDIENTRELACIONAT;
        }

        // PUT: api/ExpRel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutARQ_EXPEDIENTRELACIONAT(string id, ARQ_EXPEDIENTRELACIONAT aRQ_EXPEDIENTRELACIONAT)
        {
            if (id != aRQ_EXPEDIENTRELACIONAT.NOMINTERN)
            {
                return BadRequest();
            }

            _context.Entry(aRQ_EXPEDIENTRELACIONAT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ARQ_EXPEDIENTRELACIONATExists(id))
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

        // POST: api/ExpRel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ARQ_EXPEDIENTRELACIONAT>> PostARQ_EXPEDIENTRELACIONAT(ARQ_EXPEDIENTRELACIONAT aRQ_EXPEDIENTRELACIONAT)
        {
          if (_context.ARQ_EXPEDIENTRELACIONAT == null)
          {
              return Problem("Entity set 'DbCtx.ARQ_EXPEDIENTRELACIONAT'  is null.");
          }
            _context.ARQ_EXPEDIENTRELACIONAT.Add(aRQ_EXPEDIENTRELACIONAT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetARQ_EXPEDIENTRELACIONAT", new { id = aRQ_EXPEDIENTRELACIONAT.NOMINTERN }, aRQ_EXPEDIENTRELACIONAT);
        }

        // DELETE: api/ExpRel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteARQ_EXPEDIENTRELACIONAT(string id)
        {
            if (_context.ARQ_EXPEDIENTRELACIONAT == null)
            {
                return NotFound();
            }
            var aRQ_EXPEDIENTRELACIONAT = await _context.ARQ_EXPEDIENTRELACIONAT.FindAsync(id);
            if (aRQ_EXPEDIENTRELACIONAT == null)
            {
                return NotFound();
            }

            _context.ARQ_EXPEDIENTRELACIONAT.Remove(aRQ_EXPEDIENTRELACIONAT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ARQ_EXPEDIENTRELACIONATExists(string id)
        {
            return (_context.ARQ_EXPEDIENTRELACIONAT?.Any(e => e.NOMINTERN == id)).GetValueOrDefault();
        }
    }
}
