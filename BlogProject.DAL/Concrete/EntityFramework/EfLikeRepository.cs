using BlogProject.DAL.Abstract;
using BlogProject.DAL.Concrete.EntityFramework.DataManagement;
using BlogProject.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.EntityFramework
{
    public class EfLikeRepository : EfRepository<Like>, ILikeRepository
    {
        public EfLikeRepository(DbContext context) : base(context)
        {
        }
    }
}
