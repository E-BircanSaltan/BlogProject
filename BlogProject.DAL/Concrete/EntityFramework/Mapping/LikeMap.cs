using BlogProject.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using BlogProject.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.EntityFramework.Mapping
{
    public class LikeMap : BaseMap<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Like");
            

            builder.HasOne(q => q.User).WithMany(q => q.Likes).HasForeignKey(q => q.UserId).OnDelete(DeleteBehavior.ClientSetNull); 
            builder.HasOne(q => q.Article).WithMany(q => q.Likes).HasForeignKey(q => q.ArticleId).OnDelete(DeleteBehavior.ClientSetNull); 


        }
    }
}
