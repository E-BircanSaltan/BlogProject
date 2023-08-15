using BlogProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Abstract.DataManagent
{
    public interface IUnitOfWork
    {
        IAboutRepository AboutRepository { get; } /* _uow.AboutRepository.Add(About)*/
        IArticleRepository ArticleRepository { get; }
        ILikeRepository LikeRepository { get; }
        ICategoryRepository CategoryRepository { get; } 
        ICommentRepository CommentRepository { get; }   
        IUserRepository UserRepository { get; }
        IUserFollowedCategoryRepository UserFollowedCategoryRepository { get; } 
        Task<int> SaveChangeAsync();
    }
}
