using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NimapProject.Data;
using NimapProject.Model;

namespace NimapProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nimapsController : ControllerBase
    {
        private readonly NimapProjectContext _context;

        public nimapsController(NimapProjectContext context)
        {
            _context = context;
        }

        // GET: api/nimaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<nimap>>> Getnimap()
        {
          if (_context.nimap == null)
          {
              return NotFound();
          }
            return await _context.nimap.ToListAsync();
        }

        // GET: api/nimaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<nimap>> Getnimap(int id)
        {
          if (_context.nimap == null)
          {
              return NotFound();
          }
            var nimap = await _context.nimap.FindAsync(id);

            if (nimap == null)
            {
                return NotFound();
            }

            return nimap;
        }

        // PUT: api/nimaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnimap(int id, nimap nimap)
        {
            if (id != nimap.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(nimap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nimapExists(id))
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

        // POST: api/nimaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<nimap>> Postnimap(nimap nimap)
        {
          if (_context.nimap == null)
          {
              return Problem("Entity set 'NimapProjectContext.nimap'  is null.");
          }
            _context.nimap.Add(nimap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnimap", new { id = nimap.ProductId }, nimap);
        }

        // DELETE: api/nimaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletenimap(int id)
        {
            if (_context.nimap == null)
            {
                return NotFound();
            }
            var nimap = await _context.nimap.FindAsync(id);
            if (nimap == null)
            {
                return NotFound();
            }

            _context.nimap.Remove(nimap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool nimapExists(int id)
        {
            return (_context.nimap?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
