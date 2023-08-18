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
    public class AboutManager : IAboutServise
    {
        private readonly IUnitOfWork _uow;

        public AboutManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<About> AddAsync(About Entity)
        {
            
                await _uow.AboutRepository.AddAsync(Entity);
                await _uow.SaveChangeAsync();
                return Entity;
            
        }

        public async Task<IEnumerable<About>> GetAllAsync(Expression<Func<About, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.AboutRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<About> GetAsync(Expression<Func<About, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.AboutRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(About Entity)
        {
            await _uow.AboutRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(About Entity)
        {
            await _uow.AboutRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
