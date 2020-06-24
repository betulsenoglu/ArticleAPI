using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Abstract;
using Blog.Domain.Definitions.Responses;
using Blog.Domain.Entities.Models.Article;
using Blog.Repository.Abstract;

namespace Blog.Business.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepo;

        public ArticleService(IArticleRepository articleRepo)
        {
            _articleRepo = articleRepo;
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
                result = _articleRepo.GetByIdAsync(id).Result;
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

        public async Task<ServiceResponse<IList<Article>>> SearchInArticles(string key)
        {
            bool status;
            string message;
            IList<Article> result = null;
            try
            {
                result = _articleRepo.SearchInArticlesAsync(key).Result;
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
            try
            {
                result = model != null && !string.IsNullOrWhiteSpace(model.Url) &&
                         !string.IsNullOrWhiteSpace(model.Title) && await _articleRepo.CreateAsync(model);
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
                Data = result ? model : null,
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
                result = await _articleRepo.UpdateAsync(id, model);
                message = result != null ? "Successfully Completed!" : "Content Not Found!";
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

        public async Task<ServiceResponse<bool>> DeleteAsync(string id)
        {
            bool status;
            string message;
            bool result = false;
            try
            {
                result = await _articleRepo.DeleteAsync(id);
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

        public ServiceResponse<List<Article>> GetAll()
        {
            bool status;
            string message;
            List<Article> result = null;
            try
            {
                result = _articleRepo.Query().Where(x => x.Status == 0).OrderByDescending(x => x.CreatedDate)
                    .ThenBy(x => x._Id)
                    .ToList();
                // result = await _articleRepo.GetAll();

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