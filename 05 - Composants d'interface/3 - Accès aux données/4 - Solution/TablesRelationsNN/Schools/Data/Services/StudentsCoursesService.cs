using Microsoft.EntityFrameworkCore;
using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Services
{
    public class StudentsCoursesService
    {

        private readonly schoolsContext _context;

        public StudentsCoursesService(schoolsContext context)
        {
            _context = context;
        }

        public void AddStudentsCourse(StudentsCourse obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.StudentsCourses.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteStudentsCourse(StudentsCourse obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.StudentsCourses.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<StudentsCourse> GetAllStudentsCourses()
        {
            return _context.StudentsCourses.Include("Course").Include("Student").ToList();
        }

        public StudentsCourse GetStudentsCourseById(int id)
        {
            return _context.StudentsCourses.Include("Student").Include("Course").FirstOrDefault(obj => obj.StudentCourseId == id);
        }

        public void UpdateStudentsCourse(StudentsCourse obj)
        {
            _context.SaveChanges();
        }


    }
}
