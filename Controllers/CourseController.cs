using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnetcore5demo.Models;

namespace aspnetcore5demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ContosoUniversityContext db;
        public CourseController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("Courseid/{Courseid}")]
        public ActionResult<IEnumerable<Course>> GetCourseByCourseid(int Courseid)
        {
            return db.Courses.Where(c => c.CourseId == Courseid).ToList();
        }
        
        [HttpGet("Courseid/{Coursid}/{Credits}")]
        public ActionResult<IEnumerable<Course>> GetCourseByIdandCred(int Coursid,int Credits)
        {
            return db.Courses.Where(c => c.CourseId == Coursid && c.Credits == Credits).ToList();
        }
        
        [HttpGet("")]
        public ActionResult<IEnumerable<Course>> GetCourse()
        {
            return this.db.Courses.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            return db.Courses.Find(id);
        }

        [HttpPost("")]
        public ActionResult<Course> PostCourse(Course model)
        {
            db.Courses.Add(model);
            db.SaveChanges();
            return Created("/api/Course/"+model.CourseId,model);
        }

        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, Course model)
        {
            var c = db.Courses.Find(id);
            c.Title = model.Title;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Course> DeleteCourseById(int id)
        {
            var c = db.Courses.Find(id);
            db.Courses.Remove(c);
            return Ok(id);
        }

        [HttpGet("depart/")]
        public ActionResult<IEnumerable<Department>> GetDepartment()
        {
            return db.Departments.Asnotracking();
        }

        [HttpGet("depart/{id}")]
        public ActionResult<IEnumerable<Course>> GetDepartment(int id)
        {
            return db.Courses.Where(c => c.DepartmentId ==id).ToList(); 
        }
        
    }
}