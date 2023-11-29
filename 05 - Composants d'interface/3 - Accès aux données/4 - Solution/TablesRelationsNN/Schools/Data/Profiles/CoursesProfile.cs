using AutoMapper;
using Schools.Data.Dtos;
using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Profiles
{
    public class CoursesProfile:Profile
    {
        public CoursesProfile()
        {

            CreateMap<Course, CourseDTOIn>();
            CreateMap<CourseDTOIn, Course>();

            CreateMap<Course, CourseDTOOut>();
            CreateMap<CourseDTOOut, Course>();

            CreateMap<Course, CourseDTOAvecStudentCourse>();
            CreateMap<CourseDTOAvecStudentCourse, Course>();
        }
    }
}
