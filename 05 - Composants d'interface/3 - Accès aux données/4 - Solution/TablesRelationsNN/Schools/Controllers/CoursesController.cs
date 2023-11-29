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

namespace Schools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly CoursesService _service;
        private readonly IMapper _mapper;

        public CoursesController(CoursesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Courses
        [HttpGet]
        public ActionResult<IEnumerable<CourseDTOAvecStudentCourse>> GetAllCourses()
        {
            IEnumerable<Course> listeCourses = _service.GetAllCourses();
            return Ok(_mapper.Map<IEnumerable<CourseDTOAvecStudentCourse>>(listeCourses));
        }

        //GET api/Courses/{i}
        [HttpGet("{id}", Name = "GetCourseById")]
        public ActionResult<CourseDTOAvecStudentCourse> GetCourseById(int id)
        {
            Course commandItem = _service.GetCourseById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CourseDTOAvecStudentCourse>(commandItem));
            }
            return NotFound();
        }

        //POST api/Courses
        [HttpPost]
        public ActionResult<CourseDTOOut> CreateCourse(CourseDTOIn obj)
        {
            Course newCourse = _mapper.Map<Course>(obj);
            _service.AddCourse(newCourse);
            return CreatedAtRoute(nameof(GetCourseById), new { Id = newCourse.CourseId }, newCourse);
        }

        //POST api/Courses/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, CourseDTOIn obj)
        {
            Course objFromRepo = _service.GetCourseById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateCourse(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Courses/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCourseUpdate(int id, JsonPatchDocument<Course> patchDoc)
        {
            Course objFromRepo = _service.GetCourseById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Course objToPatch = _mapper.Map<Course>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateCourse(objFromRepo);
            return NoContent();
        }

        //DELETE api/Courses/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            Course obj = _service.GetCourseById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteCourse(obj);
            return NoContent();
        }




    }
}
