using AutoMapper;
using Schools.Data.Dtos;
using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Profiles
{
    public class StudentsCoursesProfile:Profile
    {
        public StudentsCoursesProfile()
        {

            CreateMap<StudentsCourse, StudentsCourseDTOIn>();
            CreateMap<StudentsCourseDTOIn, StudentsCourse>();

            CreateMap<StudentsCourse, StudentsCourseDTOAvecEtudiantEtCours>();
            CreateMap<StudentsCourseDTOAvecEtudiantEtCours, StudentsCourse>();

            CreateMap<StudentsCourse, StudentsCourseDTOAvecCours>();
            CreateMap<StudentsCourseDTOAvecCours, StudentsCourse>();

            CreateMap<StudentsCourse, StudentsCourseDTOOut>();
            CreateMap<StudentsCourseDTOOut, StudentsCourse>();

            CreateMap<StudentsCourse, StudentsCourseDTOAvecEtudiant>();
            CreateMap<StudentsCourseDTOAvecEtudiant, StudentsCourse>();

        }
    }
}
