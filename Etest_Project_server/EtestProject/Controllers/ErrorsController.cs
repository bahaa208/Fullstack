using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EtestProject.Data;
using EtestProject.Models;

namespace EtestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly TestContext _context;

        public ErrorsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Errors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Errors>>> GetErrorsTable()
        {
          if (_context.ErrorsTable == null)
          {
              return NotFound();
          }
            return await _context.ErrorsTable.ToListAsync();
        }

        // GET: api/Errors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Errors>> GetErrors(int id)
        {
          if (_context.ErrorsTable == null)
          {
              return NotFound();
          }
            var errors = await _context.ErrorsTable.FindAsync(id);

            if (errors == null)
            {
                return NotFound();
            }

            return errors;
        }

        // PUT: api/Errors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErrors(int id, Errors errors)
        {
            if (id != errors.Id)
            {
                return BadRequest();
            }

            _context.Entry(errors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorsExists(id))
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

        // POST: api/Errors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Errors>> PostErrors(Errors errors)
        {
            errors.Id = 0;
          if (_context.ErrorsTable == null)
          {
              return Problem("Entity set 'TestContext.ErrorsTable'  is null.");
          }
            _context.ErrorsTable.Add(errors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErrors", new { id = errors.Id }, errors);
        }

        // DELETE: api/Errors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErrors(int id)
        {
            if (_context.ErrorsTable == null)
            {
                return NotFound();
            }
            var errors = await _context.ErrorsTable.FindAsync(id);
            if (errors == null)
            {
                return NotFound();
            }

            _context.ErrorsTable.Remove(errors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErrorsExists(int id)
        {
            return (_context.ErrorsTable?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
