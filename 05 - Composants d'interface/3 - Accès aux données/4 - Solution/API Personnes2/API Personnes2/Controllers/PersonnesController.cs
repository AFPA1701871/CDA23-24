using API_Personnes2.Helpers;
using API_Personnes2.Models.Data;
using API_Personnes2.Models.DTOs;
using API_Personnes2.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Personnes2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        private readonly PersonnesServices _service;
        private readonly IMapper _mapper;

        public PersonnesController(PersonnesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Personnes
        [HttpGet]
        public ActionResult<IEnumerable<Personne>> GetAllPersonnes()
        {
            IEnumerable<Personne> listePersonnes = _service.GetAllPersonnes();
            return Ok(_mapper.Map<IEnumerable<PersonnesDto>>(listePersonnes));
        }


        //GET api/Personnes/{id}
        [HttpGet("{id}", Name = "GetPersonneById")]
        public ActionResult<PersonnesDto> GetPersonneById(int id)
        {
            var item = _service.GetPersonneById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<PersonnesDto>(item));
            }
            return NotFound();
        }

        //POST api/personnes
        [HttpPost]
        public ActionResult<PersonnesDto> CreatePersonne(PersonnesDto personneDTO)
        {
            Personne personnePOCO = _mapper.Map<Personne>(personneDTO);
            //on ajoute l’objet à la base de données
            _service.AddPersonnes(personnePOCO);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetPersonneById), new { Id = personnePOCO.IdPersonne }, personnePOCO);

        }

        //PUT api/personnes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePersonne(int id, PersonnesDto personne)
        {
            var personneFromRepo = _service.GetPersonneById(id);
            if (personneFromRepo == null)
            {
                return NotFound();
            }
            personneFromRepo.Dump();
            _mapper.Map(personne, personneFromRepo);
            personneFromRepo.Dump();
            personne.Dump();
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdatePersonne(personneFromRepo);

            return NoContent();
        }

        //PATCH api/personnes/{id}

        // Exemple d'appel
        //[{  "op":"replace",
        //    "path":"prenom",
        //    "value":"test"
        //    }]

        [HttpPatch("{id}")]
        public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<Personne> patchDoc)
        {
            patchDoc.Dump();
            var personneFromRepo = _service.GetPersonneById(id);
            if (personneFromRepo == null)
            {
                return NotFound();
            }

            var personneToPatch = _mapper.Map<Personne>(personneFromRepo);
            //var personneToPatch = personneFromRepo;
            patchDoc.ApplyTo(personneToPatch, ModelState);

            if (!TryValidateModel(personneToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(personneToPatch, personneFromRepo);

            _service.UpdatePersonne(personneFromRepo);

            return NoContent();
        }
        //DELETE api/personnes/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePersonne(int id)
        {
            var personneModelFromRepo = _service.GetPersonneById(id);
            if (personneModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeletePersonne(personneModelFromRepo);

            return NoContent();
        }

    }
}
