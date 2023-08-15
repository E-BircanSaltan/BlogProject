using BlogProject.Business.Abstract;
using BlogProject.DAL.Abstract.DataManagent;
using BlogProject.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Concrete
{
    public class ArticleManager : IArticleServise
    {
        private readonly IUnitOfWork _uow;
        public ArticleManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Article> AddAsync(Article Entity)
        {
            await _uow.ArticleRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Article>> GetAllAsync(Expression<Func<Article, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.ArticleRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Article> GetAsync(Expression<Func<Article, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.ArticleRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Article Entity)
        {
            await _uow.ArticleRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Article Entity)
        {
            await _uow.ArticleRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
