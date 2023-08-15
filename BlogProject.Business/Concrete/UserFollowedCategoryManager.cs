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
    public class UserFollowedCategoryManager : IUserFollowedCategoryServise
    {
        private readonly IUnitOfWork _uow;

        public UserFollowedCategoryManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<UserFollowedCategory> AddAsync(UserFollowedCategory Entity)
        {
            await _uow.UserFollowedCategoryRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<UserFollowedCategory>> GetAllAsync(Expression<Func<UserFollowedCategory, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.UserFollowedCategoryRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<UserFollowedCategory> GetAsync(Expression<Func<UserFollowedCategory, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.UserFollowedCategoryRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(UserFollowedCategory Entity)
        {
            await _uow.UserFollowedCategoryRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(UserFollowedCategory Entity)
        {
            await _uow.UserFollowedCategoryRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
