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
    public class ArticleMap : BaseMap<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)

        {
            builder.ToTable("Article");
            builder.Property(q => q.Title).IsRequired();
            builder.Property(q => q.Content).IsRequired();
            builder.Property(q => q.Image).IsRequired();

            builder.HasOne(q => q.User).WithMany(q => q.Articles).HasForeignKey(q => q.UserId).OnDelete(DeleteBehavior.Cascade);
                        
            builder.HasOne(q=> q.Category).WithMany(q => q.Articles).HasForeignKey(q =>q.CategoryId).OnDelete(DeleteBehavior.Cascade);
            



        }
    }
    
}
