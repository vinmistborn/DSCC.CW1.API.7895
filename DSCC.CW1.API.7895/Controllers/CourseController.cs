using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSCC.CW1.DAL._7895.DBO;
using DSCC.CW1.DAL._7895.DalDbContext;
using DSCC.CW1.DAL._7895.Repositories;

namespace DSCC.CW1.API._7895.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _repo;

        /// <summary>
        /// Constructor - registers an instance of IRepository
        /// </summary>
        /// <param name="repo">an instance which is assigned to _repo</param>
        public CourseController(IRepository<Course> repo)
        {
            _repo = repo;
        }

        // GET: api/Course
        /// <summary>
        /// this method will be called when client requests GET
        /// </summary>
        /// <returns>List of Courses</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return await _repo.GetAllAsync();
        }

        /// <summary>
        /// this method returns GET request for a Course with given id
        /// </summary>
        /// <param name="id">id of a Course to be returned</param>
        /// <returns></returns>
        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            //gets the course
            var course = await _repo.GetByIdAsync(id);

            //if there is no a course with specified id
            if (course == null)
            {
                //returns not found 404 status code
                return NotFound();
            }

            return course;
        }

        /// <summary>
        /// this method returns PUT request for a Course with given id
        /// </summary>
        /// <param name="id">id of a Course which should be updated</param>
        /// <param name="course">Course which is passed to update</param>
        /// <returns></returns>
        // PUT: api/Course/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            //checks whether specified id is equal to course id
            if (id != course.Id)
            {
                //if not then returns status code 400 Bad Request
                return BadRequest();
            }

            try
            {
                //if ids are matched, the method updates the course
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

            //if a course is successfully updated, the method
            //returns a status code 204 No Content
            return NoContent();
        }

        /// <summary>
        /// Creates a new Course when POST request is called
        /// </summary>
        /// <param name="course">a new course to be added to the database</param>
        /// <returns>Course</returns>
        // POST: api/Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            //Creates a new Course
            await _repo.CreateAsync(course);

            //Once created, produces response 201 Created and, redirects to GetCourse GET request
            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        /// <summary>
        /// Deletes a course when DELETE request is called
        /// </summary>
        /// <param name="id">id of a course which will be deleted</param>
        /// <returns></returns>
        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            //gets the course with an id
            var course = await _repo.GetByIdAsync(id);
            //if there is no such course
            if (course == null)
            {
                //returns a status code 204 Not Found
                return NotFound();
            }

            //if a course found, then it deletes the course from the database
            await _repo.DeleteAsync(course);

            //after the deletion the status code 204 No Content will be returned
            return NoContent();
        }
    }
}
