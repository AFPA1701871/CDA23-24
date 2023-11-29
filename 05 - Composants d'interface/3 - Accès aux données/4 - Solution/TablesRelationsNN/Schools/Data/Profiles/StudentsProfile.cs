using AutoMapper;
using Schools.Data.Dtos;
using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {

            CreateMap<Student, StudentDTOIn>();
            CreateMap<StudentDTOIn, Student>();
            CreateMap<Student, StudentDTOAvecGrade>();
            CreateMap<StudentDTOAvecGrade, Student>();

            CreateMap<Student, StudentDTOOut>();
            CreateMap<StudentDTOOut, Student>();

            CreateMap<Student, StudentDTOAvecGradeEtCourses>();
            CreateMap<StudentDTOAvecGradeEtCourses, Student>();

        }
    }
}
