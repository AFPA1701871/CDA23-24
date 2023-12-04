using ClientsArticles.Models.Data;
using ClientsArticles.Models.DTOs;
using ClientsArticles.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientsArticles.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CommandesController:ControllerBase
    {

        //  namespace : namespace
        //  entity : Commande
        private readonly CommandesServices _service;
        private readonly IMapper _mapper;

        public CommandesController(CommandesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandesDtoAvecClientEtArticle >> GetAllCommandes()
        {
            var listeCommandes = _service.GetAllCommandes();
            return Ok(_mapper.Map<IEnumerable<CommandesDtoAvecClientEtArticle>>(listeCommandes));
        }

        [HttpGet("{id}", Name = "GetCommandeById")]
        public ActionResult<CommandesDtoAvecClientEtArticle> GetCommandeById(int id)
        {
            var vItem = _service.GetCommandeById(id);
            if (vItem != null)
            {
                return Ok(_mapper.Map<CommandesDtoAvecClientEtArticle>(vItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandesDtoIN> CreateCommande(CommandesDtoIN c)
        {
            Commande cde = _mapper.Map<Commande>(c);
            _service.AddCommande(cde);
            return CreatedAtRoute(nameof(GetCommandeById), new { Id = cde.IdCommande }, cde);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommande(int id, CommandesDtoIN c)
        {
            var vFromRepo = _service.GetCommandeById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(c, vFromRepo);
            _service.UpdateCommande(vFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialdtUpdate(int id, JsonPatchDocument<Commande> patchDoc)
        {
            var vFromRepo = _service.GetCommandeById(id);
            if (vFromRepo == null)
            {
                return NotFound();
            }

            var vToPatch = _mapper.Map<Commande>(vFromRepo);
            patchDoc.ApplyTo(vToPatch, ModelState);

            if (!TryValidateModel(vToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(vToPatch, vFromRepo);
            _service.UpdateCommande(vFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommande(int id)
        {
            var vModelFromRepo = _service.GetCommandeById(id);
            if (vModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteCommande(vModelFromRepo);
            return NoContent();
        }
    }
}
