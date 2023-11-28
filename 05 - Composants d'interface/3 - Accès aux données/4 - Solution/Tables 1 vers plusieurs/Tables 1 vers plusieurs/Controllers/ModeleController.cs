using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tables_1_vers_plusieurs.Models.Services;
using Tables_1_vers_plusieurs.Models.Dtos;
using Tables_1_vers_plusieurs.Models.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Tables_1_vers_plusieurs.Controllers
{ 
    
    [Route("api/[Controller]")]
    [ApiController]
    public class ModeleController:ControllerBase
    {

        private readonly ModeleService _service;
        private readonly IMapper _mapper;

        public ModeleController(ModeleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]/* RELATION DTO Avec relation mais sans boucle*/
        public ActionResult<IEnumerable<ModeleDtoAvecMarque>> GetAllModeles()
        {
            var listeModeles = _service.GetAllModeles();
            return Ok(_mapper.Map<IEnumerable<ModeleDtoAvecMarque>>(listeModeles));
        }

        [HttpGet("{id}", Name = "GetModeleById")]/* RELATION DTO Avec relation mais sans boucle */
        public ActionResult<ModeleDtoAvecMarque> GetModeleById(int id)
        {
            var modeleItem = _service.GetModeleById(id);
            if (modeleItem != null)
            {
                return Ok(_mapper.Map<ModeleDtoAvecMarque>(modeleItem));
            }
            return NotFound();
        }

        [HttpPost]/* RELATION DTO Sans relation */
        public ActionResult<ModeleDtoSansMarque> CreateModele(ModeleDtoSansMarque modele)
        {
            _service.AddModele(_mapper.Map<Modele>(modele));
            return CreatedAtRoute(nameof(GetModeleById), new { Id = modele.IdModele }, modele);
        }

        [HttpPut("{id}")]/* RELATION DTO Sans relation */
        public ActionResult UpdateModele(int id, ModeleDtoSansMarque modele)
        {
            var modeleFromRepo = _service.GetModeleById(id);
            if (modeleFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(modele, modeleFromRepo);
            _service.UpdateModele(modeleFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialModeleUpdate(int id, JsonPatchDocument<Modele> patchDoc)
        {
            var modeleFromRepo = _service.GetModeleById(id);
            if (modeleFromRepo == null)
            {
                return NotFound();
            }

            var modeleToPatch = _mapper.Map<Modele>(modeleFromRepo);
            patchDoc.ApplyTo(modeleToPatch, ModelState);

            if (!TryValidateModel(modeleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(modeleToPatch, modeleFromRepo);
            _service.UpdateModele(modeleFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteModele(int id)
        {
            var modeleModelFromRepo = _service.GetModeleById(id);
            if (modeleModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteModele(modeleModelFromRepo);
            return NoContent();
        }
    }
}
