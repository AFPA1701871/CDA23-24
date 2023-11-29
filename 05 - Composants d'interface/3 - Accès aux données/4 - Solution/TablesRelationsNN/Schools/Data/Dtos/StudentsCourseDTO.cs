using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class StudentsCourseDTOIn
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

    }

    public partial class StudentsCourseDTOOut
    {
        public int StudentCourseId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

    }
    public partial class StudentsCourseDTOAvecEtudiant
    {
        public virtual StudentDTOOut Student { get; set; }
    }

    public partial class StudentsCourseDTOAvecEtudiantEtCours
    {
        public virtual CourseDTOOut Course { get; set; }
        public virtual StudentDTOOut Student { get; set; }
    }

    public partial class StudentsCourseDTOAvecCours
    {
        public virtual CourseDTOOut Course { get; set; }
    }
}
