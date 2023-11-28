using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Tables_1_vers_plusieurs.Models.Data;
using Tables_1_vers_plusieurs.Models.Dtos;
using Tables_1_vers_plusieurs.Models.Services;
using System.Diagnostics;

namespace Tables_1_vers_plusieurs.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MarqueController : ControllerBase
    {
        private readonly MarqueService _service;
        private readonly IMapper _mapper;

        public MarqueController(MarqueService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]/* RELATION DTO Avec relation mais sans boucle*/
        public ActionResult<IEnumerable<MarqueDtoAvecModeles>> GetAllMarque()
        {
            var listeMarque = _service.GetAllMarques();
            return Ok(_mapper.Map<IEnumerable<MarqueDtoAvecModeles>>(listeMarque));
        }

        [HttpGet("{id}", Name = "GetMarqueById")]/* RELATION DTO Avec relation mais sans boucle*/
        public ActionResult<MarqueDtoAvecModeles> GetMarqueById(int id)
        {
            var vItem = _service.GetMarqueById(id);
            if (vItem != null)
            {
                return Ok(_mapper.Map<MarqueDtoAvecModeles>(vItem));
            }
            return NotFound();
        }

        [HttpPost]/* RELATION DTO Sans relation*/
        public ActionResult<MarqueDtoSansModeles> CreateMarque(MarqueDtoSansModeles v)
        {
            _service.AddMarque(_mapper.Map<Marque>(v));
            return CreatedAtRoute(nameof(GetMarqueById), new { Id = v.IdMarque }, v);
        }

        [HttpPut("{id}")]/* RELATION DTO Sans relation*/
        public ActionResult UpdateMarque(int id, MarqueDtoSansModeles v)
        {
            var vFromRepo = _service.GetMarqueById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(v, vFromRepo);
            _service.UpdateMarque(vFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialMarqueUpdate(int id, JsonPatchDocument<Marque> patchDoc)
        {
            var vFromRepo = _service.GetMarqueById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }

            var vToPatch = _mapper.Map<Marque>(vFromRepo);
            patchDoc.ApplyTo(vToPatch, ModelState);

            if (!TryValidateModel(vToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(vToPatch, vFromRepo);
            _service.UpdateMarque(vFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMarque(int id)
        {
            var vModelFromRepo = _service.GetMarqueById(id);
            if (vModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteMarque(vModelFromRepo);
            return NoContent();
        }
       
    }
}