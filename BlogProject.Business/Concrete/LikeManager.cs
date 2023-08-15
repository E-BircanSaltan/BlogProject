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
    public class LikeManager : ILikeServise
    {
        private readonly IUnitOfWork _uow;

        public LikeManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Like> AddAsync(Like Entity)
        {
            await _uow.LikeRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Like>> GetAllAsync(Expression<Func<Like, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.LikeRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Like> GetAsync(Expression<Func<Like, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.LikeRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Like Entity)
        {
            await _uow.LikeRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Like Entity)
        {
            await _uow.LikeRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
