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
    public class ESC1ARQDemo_InetumController : ControllerBase
    {
        private readonly DbCtx _context;

        public ESC1ARQDemo_InetumController(DbCtx context)
        {
            _context = context;
        }

        // GET: api/ESC1ARQDemo_Inetum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ARQDemo_Inetum>>> GetARQDemo_Inetum()
        {
            return await _context.ARQDemo_Inetum.ToListAsync();
        }

        // GET: api/ESC1ARQDemo_Inetum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ARQDemo_Inetum>> GetARQDemo_Inetum(int id)
        {
            var aRQDemo_Inetum = await _context.ARQDemo_Inetum.FindAsync(id);

            if (aRQDemo_Inetum == null)
            {
                return NotFound();
            }

            return aRQDemo_Inetum;
        }

        // PUT: api/ESC1ARQDemo_Inetum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutARQDemo_Inetum(int id, ARQDemo_Inetum aRQDemo_Inetum)
        {
            if (id != aRQDemo_Inetum.ARQ_Id)
            {
                return BadRequest();
            }

            _context.Entry(aRQDemo_Inetum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ARQDemo_InetumExists(id))
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

        // POST: api/ESC1ARQDemo_Inetum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ARQDemo_Inetum>> PostARQDemo_Inetum(ARQDemo_Inetum aRQDemo_Inetum)
        {
            _context.ARQDemo_Inetum.Add(aRQDemo_Inetum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ARQDemo_InetumExists(aRQDemo_Inetum.ARQ_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetARQDemo_Inetum", new { id = aRQDemo_Inetum.ARQ_Id }, aRQDemo_Inetum);
        }

        // DELETE: api/ESC1ARQDemo_Inetum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteARQDemo_Inetum(int id)
        {
            var aRQDemo_Inetum = await _context.ARQDemo_Inetum.FindAsync(id);
            if (aRQDemo_Inetum == null)
            {
                return NotFound();
            }

            _context.ARQDemo_Inetum.Remove(aRQDemo_Inetum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ARQDemo_InetumExists(int id)
        {
            return _context.ARQDemo_Inetum.Any(e => e.ARQ_Id == id);
        }
    }
}
