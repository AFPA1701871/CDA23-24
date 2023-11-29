using AutoMapper;
using Schools.Data.Dtos;
using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Profiles
{
    public class GradesProfile:Profile
    {
        public GradesProfile()
        {

            CreateMap<Grade, GradeDTOIn>();
            CreateMap<GradeDTOIn, Grade>();

            CreateMap<Grade, GradeDTOOut>();
            CreateMap<Grade, GradeDTOAvecStudents>();
            CreateMap<GradeDTOOut, Grade>();
            CreateMap<GradeDTOAvecStudents, Grade>();
        }
    }
}
