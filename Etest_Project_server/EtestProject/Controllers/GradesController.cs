﻿using System;
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
    public class GradesController : ControllerBase
    {
        private readonly TestContext _context;

        public GradesController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGradeTable()
        {
            if (_context.GradeTable == null)
            {
                return NotFound();
            }
            return await _context.GradeTable.Include(t => t.listOfErrors).ToListAsync();
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            if (_context.GradeTable == null)
            {
                return NotFound();
            }
            var grade = await _context.GradeTable.Include(t => t.listOfErrors).FirstOrDefaultAsync(ut => ut.Id == id);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.Id)
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
          if (_context.GradeTable == null)
          {
              return Problem("Entity set 'TestContext.GradeTable'  is null.");
          }
            _context.GradeTable.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrade", new { id = grade.Id }, grade);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            if (_context.GradeTable == null)
            {
                return NotFound();
            }
            var grade = await _context.GradeTable.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.GradeTable.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeExists(int id)
        {
            return (_context.GradeTable?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
