using BlogProject.DAL.Abstract;
using BlogProject.DAL.Abstract.DataManagent;
using BlogProject.DAL.Concrete.EntityFramework.Context;
using BlogProject.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.EntityFramework.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly BlogProjectContext _blogProjectContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EfUnitOfWork(BlogProjectContext blogProjectContext, IHttpContextAccessor httpContextAccessor)
        {
            _blogProjectContext = blogProjectContext;
            _httpContextAccessor = httpContextAccessor;

            AboutRepository = new EfAboutRepository(_blogProjectContext);
            ArticleRepository = new EfArticleRepository(_blogProjectContext);
            CategoryRepository = new EfCategoryRepository(_blogProjectContext);
            CommentRepository = new EfCommentRepository(_blogProjectContext);
            LikeRepository = new EfLikeRepository(_blogProjectContext);
            UserRepository = new EfUserRepository(_blogProjectContext);
            UserFollowedCategoryRepository = new EfUserFollowedCategory(_blogProjectContext);

        }

        public IAboutRepository AboutRepository { get; }

        public IArticleRepository ArticleRepository { get; }

        public ILikeRepository LikeRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public ICommentRepository CommentRepository { get; }

        public IUserRepository UserRepository { get; }

        public IUserFollowedCategoryRepository UserFollowedCategoryRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (EntityEntry<AuditableEntity> item in _blogProjectContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.AddedUser = 1;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.Guid = Guid.NewGuid();
                    item.Entity.AddedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                    if (item.Entity.IsActive == null)
                    {
                        item.Entity.IsActive = true;
                    }
                    item.Entity.IsDelete = false;
                }

                else if (item.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                }
            }
            return await _blogProjectContext.SaveChangesAsync();
        }
    }
}
