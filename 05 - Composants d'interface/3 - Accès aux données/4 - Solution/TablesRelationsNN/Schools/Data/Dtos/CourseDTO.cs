using Schools.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos

{
    public  class CourseDTOIn
    {
        public CourseDTOIn()
        {
        }

        public string CourseName { get; set; }
        public string Description { get; set; }

    }


    public  class CourseDTOOut
    {
        public CourseDTOOut()
        {
        }

        public string CourseName { get; set; }
        public string Description { get; set; }

    }


    public  class CourseDTOAvecStudentCourse
    {
        public CourseDTOAvecStudentCourse()
        {
            StudentsCourses = new HashSet<StudentsCourseDTOAvecEtudiant>();
        }

        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentsCourseDTOAvecEtudiant> StudentsCourses { get; set; }
    }
}
