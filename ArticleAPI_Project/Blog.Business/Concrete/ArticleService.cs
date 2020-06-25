using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Abstract;
using Blog.Cache.Models;
using Blog.Cache.Redis.Abstract;
using Blog.Core.IoCHandler;
using Blog.Domain.Definitions.Responses;
using Blog.Domain.Entities.Enums;
using Blog.Domain.Entities.Models.Article;
using Blog.Repository.Abstract;

namespace Blog.Business.Concrete
{
    // ToDo : Implementation of REDIS Cache
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepo;
        private IRedisCacheService _cache;
        public ArticleService(IArticleRepository articleRepo, IRedisCacheService cache)
        {
            _articleRepo = articleRepo;
            _cache = cache;
        }

        public async Task<ServiceResponse<List<Article>>> GetAllAsync()
        {
            bool status;
            string message;
            List<Article> result = null;
            try
            {
                result = _articleRepo.Query().Where(x => x.Status == 0).OrderByDescending(x => x.CreatedDate)
                    .ThenBy(x => x._Id)
                    .ToList();

                // result = await _articleRepo.GetAllAsync();
                message = result.Count > 0 ? "Successfully Completed!" : "Content Not Found!";
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<List<Article>>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public ServiceResponse<Article> GetByIdAsync(string id)
        {
            bool status;
            string message;
            Article result = null;
            try
            {
                result = !string.IsNullOrWhiteSpace(id) ? _articleRepo.GetByIdAsync(id).Result : null;
                message = result != null ? "Successfully Completed!" : "Content Not Found!";
                status = result != null;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<Article>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public async Task<ServiceResponse<IList<Article>>> SearchInArticles(string key)
        {
            bool status;
            string message;
            IList<Article> result = null;
            var articleService = ServiceCollectionManager.CurrentInstance.Resolve<IArticleRepository>(); // Info : Dependency Injected by IOC Container

            try
            {
                result = articleService.SearchInArticlesAsync(key).Result;
                message = result.Count > 0 ? "Successfully Completed!" : "Content Not Found!";
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<IList<Article>>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public async Task<ServiceResponse<Article>> CreateAsync(Article model)
        {
            bool status;
            string message;
            bool result = false;
            Article entity = null;
            try
            {
                if (model != null)
                {
                    entity = new Article()
                    {
                        Title = !string.IsNullOrWhiteSpace(model.Title) ? model.Title : string.Empty,
                        Description = !string.IsNullOrWhiteSpace(model.Description) ? model.Description : string.Empty,
                        Text = !string.IsNullOrWhiteSpace(model.Text) ? model.Text : string.Empty,
                        Url = !string.IsNullOrWhiteSpace(model.Url) ? model.Url : string.Empty,
                        Writers = model.Writers != null && model.Writers.Count > 0 ? model.Writers : null,
                        Sources = model.Sources != null && model.Sources.Count > 0 ? model.Sources : null,
                        Status = Status.Active,
                        CreatedDate = DateTime.Now
                    };
                }

                if (entity != null)
                    result = !string.IsNullOrWhiteSpace(entity.Url) &&
                             !string.IsNullOrWhiteSpace(entity.Title) && await _articleRepo.CreateAsync(entity);

                message = result ? "Successfully Completed!" : "Content Not Found!";
                status = result;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<Article>()
            {
                Data = result ? entity : null,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public async Task<ServiceResponse<Article>> UpdateAsync(string id, Article model)
        {
            bool status;
            string message;
            Article result = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Url) &&
                    !string.IsNullOrWhiteSpace(model.Title) && !string.IsNullOrWhiteSpace(id))
                {
                    model.UpdatedDate = DateTime.Now;
                    result = await _articleRepo.UpdateAsync(id, model);
                    message = result != null ? "Successfully Completed!" : "Content Not Found!";
                    status = true;
                }
                else
                {
                    message = "Content Not Found!";
                    status = false;
                }
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<Article>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(string id)
        {
            bool status;
            string message;
            bool result = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    result = await _articleRepo.DeleteAsync(id);
                    message = result ? "Successfully Completed!" : "Content Not Found!";
                    status = true;
                }
                else
                {
                    message = "Content Not Found!";
                    status = false;
                }
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<bool>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public ServiceResponse<List<Article>> GetAll()
        {
            bool status;
            string message;
            List<Article> result = null;
            try
            {
                // result = _articleRepo.Query().Where(x => x.Status == 0).OrderByDescending(x => x.CreatedDate)
                //     .ThenBy(x => x._Id)
                //     .ToList();
                result = _articleRepo.GetAll();

                message = result.Count > 0 ? "Successfully Completed!" : "Content Not Found!";
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<List<Article>>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public ServiceResponse<Article> GetById(string id)
        {
            bool status;
            string message;
            Article result = null;
            try
            {
                result = _articleRepo.GetById(id);
                message = "Successfully Completed!";
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<Article>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public ServiceResponse<bool> Update(string id, Article model)
        {
            bool status;
            string message;
            bool result = false;
            try
            {
                result = _articleRepo.Update(id, model);
                message = result ? "Successfully Completed!" : "Content Not Found!";
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<bool>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public async Task<ServiceResponse<bool>> DeleteViaUpdate(string id)
        {
            bool status;
            string message;
            bool result = false;
            try
            {
                result = await _articleRepo.DeleteViaUpdate(id);
                message = result ? "Successfully Completed!" : "Content Not Found!";
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<bool>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }

        public ServiceResponse<bool> Delete(string id)
        {
            bool status;
            string message;
            bool result = false;
            try
            {
                result = _articleRepo.Delete(id);
                message = result ? "Successfully Completed!" : "Content Not Found!";
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = "An Error Occured!";
                // ToDo : logging
            }

            return new ServiceResponse<bool>()
            {
                Data = result,
                Message = message,
                Status = status ? "success" : "fail"
            };
        }
    }
}