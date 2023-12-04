using ClientsArticles.Models.Data;
using ClientsArticles.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClientsArticles.Models.DTOs;

namespace ClientsArticles.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ArticlesController:ControllerBase
    {

        //  namespace : namespace
        //  entity : Article
        private readonly ArticlesServices _service;
        private readonly IMapper _mapper;

        public ArticlesController(ArticlesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticlesDtoAplati>> GetAllArticles()
        {
            var listeArticles = _service.GetAllArticles();
            return Ok(_mapper.Map<IEnumerable<ArticlesDtoAplati>>(listeArticles));
        }

        [HttpGet("{id}", Name = "GetArticlesById")]
        public ActionResult<ArticlesDtoAvecCategorie> GetArticlesById(int id)
        {
            var ArtItem = _service.GetArticleById(id);
            if (ArtItem != null)
            {
                return Ok(_mapper.Map<ArticlesDtoAvecCategorie>(ArtItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ArticlesDtoOUT> CreateArticle(ArticlesDtoIN art)
        {
            Article a = _mapper.Map<Article>(art);
            _service.AddArticle(a);
            return CreatedAtRoute(nameof(GetArticlesById), new { Id = a.IdArticle }, a);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateArticles(int id, ArticlesDtoIN art)
        {
            var artFromRepo = _service.GetArticleById(id);
            if (artFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(art, artFromRepo);
            _service.UpdateArticle(artFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialArticlesUpdate(int id, JsonPatchDocument<Article> patchDoc)
        {
            var ArtFromRepo = _service.GetArticleById(id);
            if (ArtFromRepo == null)
            {
                return NotFound();
            }

            var ArtToPatch = _mapper.Map<Article>(ArtFromRepo);
            patchDoc.ApplyTo(ArtToPatch, ModelState);

            if (!TryValidateModel(ArtToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(ArtToPatch, ArtFromRepo);
            _service.UpdateArticle(ArtFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticles(int id)
        {
            var ArtModelFromRepo = _service.GetArticleById(id);
            if (ArtModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteArticle(ArtModelFromRepo);
            return NoContent();
        }
    }
}
