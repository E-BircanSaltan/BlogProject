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
    public class CommentMap : BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.Property(q=>q.Text);
            builder.HasOne(q => q.User).WithMany(q => q.Comments).HasForeignKey(q => q.UserId).OnDelete(DeleteBehavior.ClientSetNull); 
            builder.HasOne(q => q.Article).WithMany(q => q.Comments).HasForeignKey(q => q.ArticleId).OnDelete(DeleteBehavior.ClientSetNull); 
            




        }
    }
}
