using Schools.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public  class StudentDTOIn
    {
        public StudentDTOIn()
        {
        }

        // les données présentes dans la tables uniquement
        public string Name { get; set; }
        public int GradeId { get; set; }

    }


    public  class StudentDTOOut
    {
        public StudentDTOOut()
        {
           
        }
        // les données de la table sans les id et sans les clés etrangères
        public string Name { get; set; }
    }

    public  class StudentDTOAvecGrade
    {
        public StudentDTOAvecGrade()
        {
        }
        // les colonnes de la table sans les id
        public string Name { get; set; }
        public int GradeId { get; set; }

        // ajouter les données attachées
        // ATTENTION il faut retourner un DTOOut
        public virtual GradeDTOOut Grade { get; set; }
    }

    public  class StudentDTOAvecGradeEtCourses
    {
        public StudentDTOAvecGradeEtCourses()
        {
            StudentsCourses = new HashSet<StudentsCourseDTOAvecCours>();
        }

        public string Name { get; set; }
        public int GradeId { get; set; }

        public virtual GradeDTOOut Grade { get; set; }
        public virtual ICollection<StudentsCourseDTOAvecCours> StudentsCourses { get; set; }
    }
}
