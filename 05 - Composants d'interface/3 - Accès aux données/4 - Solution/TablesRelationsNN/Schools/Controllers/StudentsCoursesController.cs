using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Schools.Data.Dtos;
using Schools.Data.Models;
using Schools.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Schools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsCoursesController : ControllerBase
    {

        private readonly StudentsCoursesService _service;
        private readonly IMapper _mapper;

        public StudentsCoursesController(StudentsCoursesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/StudentsCourses
        [HttpGet]
        public ActionResult<IEnumerable<StudentsCourseDTOAvecEtudiantEtCours>> GetAllStudentsCourses()
        {
            IEnumerable<StudentsCourse> listeStudentsCourses = _service.GetAllStudentsCourses();
            return Ok(_mapper.Map<IEnumerable<StudentsCourseDTOAvecEtudiantEtCours>>(listeStudentsCourses));
        }

        //GET api/StudentsCourses/{i}
        [HttpGet("{id}", Name = "GetStudentsCourseById")]
        public ActionResult<StudentsCourseDTOAvecEtudiantEtCours> GetStudentsCourseById(int id)
        {
            StudentsCourse commandItem = _service.GetStudentsCourseById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<StudentsCourseDTOAvecEtudiantEtCours>(commandItem));
            }
            return NotFound();
        }

        //POST api/StudentsCourses
        [HttpPost]
        public ActionResult<StudentsCourseDTOOut> CreateStudentsCourse(StudentsCourseDTOIn obj)
        {
            StudentsCourse newObj = _mapper.Map<StudentsCourse>(obj);
            _service.AddStudentsCourse(newObj);
            return CreatedAtRoute(nameof(GetStudentsCourseById), new { Id = newObj.StudentCourseId }, newObj);
        }

        //POST api/StudentsCourses/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStudentsCourse(int id, StudentsCourseDTOIn obj)
        {
            StudentsCourse objFromRepo = _service.GetStudentsCourseById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateStudentsCourse(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/StudentsCourses/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialStudentsCourseUpdate(int id, JsonPatchDocument<StudentsCourse> patchDoc)
        {
            StudentsCourse objFromRepo = _service.GetStudentsCourseById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            StudentsCourse objToPatch = _mapper.Map<StudentsCourse>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateStudentsCourse(objFromRepo);
            return NoContent();
        }

        //DELETE api/StudentsCourses/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteStudentsCourse(int id)
        {
            StudentsCourse obj = _service.GetStudentsCourseById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteStudentsCourse(obj);
            return NoContent();
        }


    }
}
