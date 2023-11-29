using Microsoft.EntityFrameworkCore;
using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Services
{

    public class CoursesService
    {

        private readonly schoolsContext _context;

        public CoursesService(schoolsContext context)
        {
            _context = context;
        }

        public void AddCourse(Course obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Courses.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteCourse(Course obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Courses.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.Include("StudentsCourses.Student").ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Include("StudentsCourses.Student").FirstOrDefault(obj => obj.CourseId == id);
        }

        public void UpdateCourse(Course obj)
        {
            _context.SaveChanges();
        }


    }
}
