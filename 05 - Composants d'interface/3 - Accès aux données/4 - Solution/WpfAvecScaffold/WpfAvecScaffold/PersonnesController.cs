
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WpfAvecScaffold.Models
{
 
    public class PersonnesController : ControllerBase
    {
        private readonly PersonnesServices _service;
        private readonly IMapper _mapper;

        public PersonnesController(PersonnesDbContext context)
        {
            _service = new PersonnesServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PersonnesProfiles>();
            });
            _mapper = config.CreateMapper();
        }

       
        public IEnumerable<PersonnesDto> GetAllPersonnes()
        {
            IEnumerable<Personne> listePersonnes = _service.GetAllPersonnes();
            return _mapper.Map<IEnumerable<PersonnesDto>>(listePersonnes);
        }


       
        public ActionResult<PersonnesDto> GetPersonneById(int id)
        {
            var item = _service.GetPersonneById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<PersonnesDto>(item));
            }
            return NotFound();
        }

       
        public ActionResult<PersonnesDto> CreatePersonne(PersonnesDto personneDTO)
        {
            Personne personnePOCO = _mapper.Map<Personne>(personneDTO);
            //on ajoute l’objet à la base de données
            _service.AddPersonnes(personnePOCO);
            //on retourne le chemin de findById avec l'objet créé
            return CreatedAtRoute(nameof(GetPersonneById), new { Id = personnePOCO.IdPersonne }, personnePOCO);

        }

       
        public ActionResult UpdatePersonne(int id, PersonnesDto personne)
        {
            var personneFromRepo = _service.GetPersonneById(id);
            if (personneFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(personne, personneFromRepo);
            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            _service.UpdatePersonne(personneFromRepo);

            return NoContent();
        }

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
