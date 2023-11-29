using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public  class StudentsCourseDTOIn
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

    }

    public  class StudentsCourseDTOOut
    {
        public int StudentCourseId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

    }
    public  class StudentsCourseDTOAvecEtudiant
    {
        public virtual StudentDTOOut Student { get; set; }
    }

    public  class StudentsCourseDTOAvecEtudiantEtCours
    {
        public virtual CourseDTOOut Course { get; set; }
        public virtual StudentDTOOut Student { get; set; }
    }

    public  class StudentsCourseDTOAvecCours
    {
        public virtual CourseDTOOut Course { get; set; }
    }
}
