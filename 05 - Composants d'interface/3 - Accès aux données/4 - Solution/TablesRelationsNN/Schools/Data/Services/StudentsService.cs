using Microsoft.EntityFrameworkCore;
using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Services
{
    public class StudentsServices
    {
        private readonly schoolsContext _context;

        public StudentsServices(schoolsContext context)
        {
            _context = context;
        }

        public void AddStudents(Student obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Students.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteStudents(Student obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Students.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {

            return _context.Students.Include("Grade").Include("StudentsCourses.Course").ToList();
        }

        public Student GetStudentsById(int id)
      {
            return _context.Students.Include("Grade").Include("StudentsCourses.Course").FirstOrDefault(obj => obj.StudentId == id);
        }

        public void UpdateStudents(Student obj)
        {
            _context.SaveChanges();
        }


    }
}
