using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Business.Abstract;
using Blog.Domain.Definitions.Responses;
using Blog.Domain.Entities.Enums;
using Blog.Domain.Entities.Models.Article;
using Microsoft.AspNetCore.Mvc;

namespace Blog.UI.Controllers.API
{
    [ApiController]
    public class ArticleController : Controller
    {
        IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }

        [Route("GET_ALL_ACTIVE_ARTICLES")]
        [HttpGet]
        public async Task<ServiceResponse<List<Article>>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        [Route("CREATE_AN_ARTICLE")]
        [HttpPost]
        public async Task<ServiceResponse<Article>> Create([FromBody] Article model)
        {
            var entity = new Article()
            {
                Title = !string.IsNullOrWhiteSpace(model.Title) ?  model.Title : string.Empty,
                Description = !string.IsNullOrWhiteSpace(model.Description) ?  model.Description : string.Empty,
                Text = !string.IsNullOrWhiteSpace(model.Text) ?  model.Text : string.Empty,
                Url = !string.IsNullOrWhiteSpace(model.Url) ?  model.Url : string.Empty,
                Writers = model.Writers != null && model.Writers.Count > 0 ? model.Writers : null,
                Sources = model.Sources != null && model.Sources.Count > 0 ? model.Sources : null,
                Status = Status.Active,
                CreatedDate = DateTime.Now
            };
            var isCreated = await _service.CreateAsync(entity);
            return isCreated;
        }
    }
}