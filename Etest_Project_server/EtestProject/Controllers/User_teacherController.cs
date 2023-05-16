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
    public class User_teacherController : ControllerBase
    {
        private readonly TestContext _context;

        public User_teacherController(TestContext context)
        {
            _context = context;
        }

        // GET: api/User_teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_teacher>>> GetUserTeacherTable()
        {
            if (_context.UserTeacherTable == null)
            {
                return NotFound();
            }
            return await _context.UserTeacherTable.Include(t => t.tests).ThenInclude(t1 => t1.AllQuestionInTest).ThenInclude(q => q.listAnswer).ToListAsync();
        }

        // GET: api/User_teacher/5
        [HttpGet("{name}")]
        public async Task<ActionResult<User_teacher>> GetUser_teacher(string name)
        {
            var user_teacher = await _context.UserTeacherTable.Include(t => t.tests).ThenInclude(t1 => t1.AllQuestionInTest).ThenInclude(q => q.listAnswer).FirstOrDefaultAsync(ut => ut.Name == name);

            if (user_teacher == null)
            {
                return NotFound();
            }

            return user_teacher;
        }

        // PUT: api/User_teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_teacher(string id, User_teacher user_teacher)
        {
            if (id != user_teacher.Name)
            {
                return BadRequest();
            }

            _context.Entry(user_teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_teacherExists(id))
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

        // POST: api/User_teacher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
   
        public async Task<ActionResult<User_teacher>> PostUser_teacher(User_teacher user_teacher)
        {
            if (_context.UserTeacherTable == null)
            {
                return Problem("Entity set 'TestContext.UserTeacherTable' is null.");
            }

            _context.UserTeacherTable.Add(user_teacher);
            await _context.SaveChangesAsync();

            // Find the user by name instead of ID
            var createdUser = await _context.UserTeacherTable.FirstOrDefaultAsync(u => u.Name == user_teacher.Name);

            if (createdUser == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetUser_teacher", new { name = createdUser.Name }, createdUser);
        }


        // DELETE: api/User_teacher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_teacher(int id)
        {
            if (_context.UserTeacherTable == null)
            {
                return NotFound();
            }
            var user_teacher = await _context.UserTeacherTable.FindAsync(id);
            if (user_teacher == null)
            {
                return NotFound();
            }

            _context.UserTeacherTable.Remove(user_teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_teacherExists(string id)
        {
            return (_context.UserTeacherTable?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
