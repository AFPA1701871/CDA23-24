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
    public class ClientsController:ControllerBase
    {

        //  namespace : t
        //  entity : Client
        private readonly ClientsServices _service;
        private readonly IMapper _mapper;

        public ClientsController(ClientsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientsDtoAvecCommandes>> GetAllClients()
        {
            var listeClients = _service.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientsDtoAvecCommandes>>(listeClients));
        }

        [HttpGet("{id}", Name = "GetClientsById")]
        public ActionResult<ClientsDtoAvecCommandes> GetClientsById(int id)
        {
            var cliItem = _service.GetClientById(id);
            if (cliItem != null)
            {
                return Ok(_mapper.Map<ClientsDtoAvecCommandes>(cliItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ClientsDtoAvecCommandes> CreateClient(ClientsDtoIN c)
        {
            Client cli = _mapper.Map<Client>(c);
            _service.AddClient(cli);
            return CreatedAtRoute(nameof(GetClientsById), new { Id = cli.IdClient }, cli);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id, ClientsDtoIN cli)
        {
            var cliFromRepo = _service.GetClientById(id);
            if (cliFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(cli, cliFromRepo);
            _service.UpdateClient(cliFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialClientsUpdate(int id, JsonPatchDocument<Client> patchDoc)
        {
            var cliFromRepo = _service.GetClientById(id);
            if (cliFromRepo == null)
            {
                return NotFound();
            }

            var cliToPatch = _mapper.Map<Client>(cliFromRepo);
            patchDoc.ApplyTo(cliToPatch, ModelState);

            if (!TryValidateModel(cliToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(cliToPatch, cliFromRepo);
            _service.UpdateClient(cliFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            var cliModelFromRepo = _service.GetClientById(id);
            if (cliModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteClient(cliModelFromRepo);
            return NoContent();
        }
    }
}
