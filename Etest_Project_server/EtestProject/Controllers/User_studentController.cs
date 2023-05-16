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
    public class User_studentController : ControllerBase
    {
        private readonly TestContext _context;

        public User_studentController(TestContext context)
        {
            _context = context;
        }

        // GET: api/User_student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_student>>> GetUserStudentTable()
        {
          if (_context.UserStudentTable == null)
          {
              return NotFound();
          }
            return await _context.UserStudentTable.Include(t=>t.grades).ThenInclude(s=>s.listOfErrors).ToListAsync();
        }

         
        // GET: api/User_student/{name}
        [HttpGet("{name}")]
        public async Task<ActionResult<User_student>> GetUser_student(string name)
        {
            if (_context.UserStudentTable == null)
            {
                return NotFound();
            }

            var user_student = await _context.UserStudentTable.FirstOrDefaultAsync(u => u.Name == name);

            if (user_student == null)
            {
                return NotFound();
            }

            return user_student;
        }


        // PUT: api/User_student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_student(int id, User_student user_student)
        {
            if (id != user_student.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_studentExists(id))
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

        // POST: api/User_student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_student>> PostUser_student(User_student user_student)
        {
            if (_context.UserStudentTable == null)
            {
                return Problem("Entity set 'TestContext.UserStudentTable' is null.");
            }

            _context.UserStudentTable.Add(user_student);
            await _context.SaveChangesAsync();

            // Find the user by name instead of ID
            var createdUser = await _context.UserStudentTable.FirstOrDefaultAsync(u => u.Name == user_student.Name);

            if (createdUser == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetUser_student", new { name = createdUser.Name }, createdUser);
        }

        // DELETE: api/User_student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_student(int id)
        {
            if (_context.UserStudentTable == null)
            {
                return NotFound();
            }
            var user_student = await _context.UserStudentTable.FindAsync(id);
            if (user_student == null)
            {
                return NotFound();
            }

            _context.UserStudentTable.Remove(user_student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_studentExists(int id)
        {
            return (_context.UserStudentTable?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
