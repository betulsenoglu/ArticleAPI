using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Business.Abstract;
using Blog.Core.IoCHandler;
using Blog.Domain.Definitions.Responses;
using Blog.Domain.Entities.Enums;
using Blog.Domain.Entities.Models.Article;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;

namespace Blog.UI.Controllers.API
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("/api")]
    public class ArticleController : Controller
    {
        IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }

        [Microsoft.AspNetCore.Mvc.Route("GET_ALL_ACTIVE_ARTICLES")]
        [HttpGet]
        public async Task<ServiceResponse<List<Article>>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        [Microsoft.AspNetCore.Mvc.Route("GET_ALL_ARTICLES")]
        [HttpGet]
        public ServiceResponse<List<Article>> GetAllArticlesAsync()
        {
            return _service.GetAll();
        }

        [Microsoft.AspNetCore.Mvc.Route("GET_ARTICLE_BY_ID")]
        [HttpGet]
        public ServiceResponse<Article> GetByIdAsync(string id)
        {
            return _service.GetByIdAsync(id);
        }

        [Microsoft.AspNetCore.Mvc.Route("CREATE_AN_ARTICLE")]
        [HttpPost]
        public async Task<ServiceResponse<Article>> Create([FromBody] Article model)
        {
            var isCreated = await _service.CreateAsync(model);
            return isCreated;
        }

        [Microsoft.AspNetCore.Mvc.Route("SEARCH_IN_ARTICLES")]
        [HttpGet]
        public async Task<ServiceResponse<IList<Article>>> SearchInArticles(string key)
        {
            return await _service.SearchInArticles(key);
        }

        [Microsoft.AspNetCore.Mvc.Route("UPDATE_AN_ARTICLE")]
        [HttpPut]
        public async Task<ServiceResponse<Article>> UpdateAsync(string id, [FromBody] Article model)
        {
            return await _service.UpdateAsync(id, model);
        }

        [Microsoft.AspNetCore.Mvc.Route("DELETE_ARTICLE_BY_ID")]
        [HttpDelete]
        public async Task<ServiceResponse<bool>> DeleteAsync(string id)
        {
            return await _service.DeleteAsync(id);
        }

        [Microsoft.AspNetCore.Mvc.Route("DELETE_BY_UPDATING_STATUS")]
        [HttpPut]
        public async Task<ServiceResponse<bool>> UpdateAsync(string id)
        {
            return await _service.DeleteViaUpdate(id);
        }
    }
}