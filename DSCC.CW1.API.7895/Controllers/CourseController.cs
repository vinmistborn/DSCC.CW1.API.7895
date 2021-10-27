using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSCC.CW1.API._7895.DBO;
using DSCC.CW1.API._7895.DalDbContext;
using DSCC.CW1.API._7895.Repositories;

namespace DSCC.CW1.API._7895.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _repo;

        public CourseController(IRepository<Course> repo)
        {
            _repo = repo;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return await _repo.GetAllAsync(a => a.Teacher);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _repo.GetByIdAsync(id, a => a.Teacher);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Course/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repo.UpdateAsync(course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repo.Exists(id))
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

        // POST: api/Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            await _repo.CreateAsync(course);

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _repo.DeleteAsync(course);

            return NoContent();
        }
    }
}
