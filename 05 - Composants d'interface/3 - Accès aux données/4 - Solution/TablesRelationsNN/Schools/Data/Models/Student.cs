using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentsCourses = new HashSet<StudentsCourse>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual ICollection<StudentsCourse> StudentsCourses { get; set; }
    }
}
