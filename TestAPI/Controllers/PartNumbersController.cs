using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartNumbersController : ControllerBase
    {
        private readonly AppDBcontext _context;

        public PartNumbersController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: api/PartNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartNumbers>>> GetPartNumbers()
        {
            return await _context.PartNumbers.ToListAsync();
        }

        // GET: api/PartNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartNumbers>> GetPartNumbers(int id)
        {
            var partNumbers = await _context.PartNumbers.FindAsync(id);

            if (partNumbers == null)
            {
                return NotFound();
            }

            return partNumbers;
        }

        // PUT: api/PartNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartNumbers(int id, PartNumbers partNumbers)
        {
            if (id != partNumbers.PKPartNumbers)
            {
                return BadRequest();
            }

            _context.Entry(partNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartNumbersExists(id))
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

        // POST: api/PartNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartNumbers>> PostPartNumbers(PartNumbers partNumbers)
        {
            _context.PartNumbers.Add(partNumbers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartNumbers", new { id = partNumbers.PKPartNumbers }, partNumbers);
        }

        // DELETE: api/PartNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartNumbers(int id)
        {
            var partNumbers = await _context.PartNumbers.FindAsync(id);
            if (partNumbers == null)
            {
                return NotFound();
            }

            _context.PartNumbers.Remove(partNumbers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartNumbersExists(int id)
        {
            return _context.PartNumbers.Any(e => e.PKPartNumbers == id);
        }
    }
}
