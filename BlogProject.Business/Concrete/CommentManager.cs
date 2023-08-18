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
    public class CommentManager : ICommentServise
    {
        private readonly IUnitOfWork _uow;

        public CommentManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Comment> AddAsync(Comment Entity)
        {
            await _uow.CommentRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(Expression<Func<Comment, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.CommentRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Comment> GetAsync(Expression<Func<Comment, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.CommentRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Comment Entity)
        {
            await _uow.CommentRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Comment Entity)
        {
            await _uow.CommentRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync(); 
        }
    }
}
