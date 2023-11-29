using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentsCourses = new HashSet<StudentsCourse>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentsCourse> StudentsCourses { get; set; }
    }
}
