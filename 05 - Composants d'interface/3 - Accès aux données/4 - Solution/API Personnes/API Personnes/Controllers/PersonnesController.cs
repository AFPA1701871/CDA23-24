using API_Personnes.Helpers;
using API_Personnes.Models.Data;
using API_Personnes.Models.DTO;
using API_Personnes.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API_Personnes.Controllers
{
    [Route("api/Personnes")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        private readonly PersonnesService _service;
        private readonly IMapper _mapper;

        public PersonnesController(PersonnesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Personnes
        [HttpGet]
        public ActionResult<IEnumerable<Personne>> GetAllPersonnes()
        {
            IEnumerable<Personne> listePersonnes = _service.GetAllPersonnes();
            return Ok(_mapper.Map<IEnumerable<PersonnesDTO>>(listePersonnes));
        }
        //GET api/Personnes/{id}
        [HttpGet("{id}", Name = "GetPersonneById")]
        public ActionResult<PersonnesDTO> GetPersonneById(int id)
        {
            var commandItem = _service.GetPersonneById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<PersonnesDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/personnes
        [HttpPost]
        public ActionResult<PersonnesDTO> CreatePersonne(Personne personne)
        {
            //on ajoute l’objet à la base de données
            _service.AddPersonnes(personne);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetPersonneById), new { Id = personne.IdPersonne }, personne);

        }



        //PUT api/personnes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePersonne(int id, PersonnesDTO personne)
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
