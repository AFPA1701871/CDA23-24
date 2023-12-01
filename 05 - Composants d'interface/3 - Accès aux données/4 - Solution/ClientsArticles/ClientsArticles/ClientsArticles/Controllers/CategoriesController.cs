using AutoMapper;
using ClientsArticles.Models.DTOs;
using ClientsArticles.Models.Data;
using ClientsArticles.Models.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.JsonPatch;
using System.Diagnostics;
namespace ClientsArticles.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {

        //  namespace : namespace
        //  entity : Categorie
        private readonly CategoriesServices _service;
        private readonly IMapper _mapper;

        public CategoriesController(CategoriesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriesDtoOUT>> GetAllCategories()
        {
            var listeCategories = _service.GetAllCategories();
            return Ok(_mapper.Map<IEnumerable<CategoriesDtoOUT>>(listeCategories));
        }

        [HttpGet("{id}", Name = "GetCategoriesById")]
        public ActionResult<CategoriesDtoOUT> GetCategoriesById(int id)
        {
            var vItem = _service.GetCategorieById(id);
            if (vItem != null)
            {
                return Ok(_mapper.Map<CategoriesDtoOUT>(vItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CategoriesDtoOUT> CreateCategories(CategoriesDtoIN v)
        {
            Categorie categ = _mapper.Map<Categorie>(v);
            _service.AddCategorie(categ);
            return CreatedAtRoute(nameof(GetCategoriesById), new { Id = categ.IdCategorie }, categ);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategories(int id, CategoriesDtoIN v)
        {
            var vFromRepo = _service.GetCategorieById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(v, vFromRepo);
            _service.UpdateCategorie(vFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCategoriesUpdate(int id, JsonPatchDocument<Categorie> patchDoc)
        {
            var vFromRepo = _service.GetCategorieById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }

            var vToPatch = _mapper.Map<Categorie>(vFromRepo);
            patchDoc.ApplyTo(vToPatch, ModelState);

            if (!TryValidateModel(vToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(vToPatch, vFromRepo);
            _service.UpdateCategorie(vFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategories(int id)
        {
            var vModelFromRepo = _service.GetCategorieById(id);
            if (vModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteCategorie(vModelFromRepo);
            return NoContent();
        }
    }
}
