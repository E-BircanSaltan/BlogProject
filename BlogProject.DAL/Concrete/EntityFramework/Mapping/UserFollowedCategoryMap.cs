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
    public class UserFollowedCategoryMap :BaseMap<UserFollowedCategory>
    {
        public override void Configure(EntityTypeBuilder<UserFollowedCategory> builder)
        {
            builder.ToTable("UserFollowedCategory");
            

            builder.HasOne(q => q.User).WithMany(q => q.UserFollowedCategories).HasForeignKey(q => q.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(q => q.Category).WithMany(q => q.UserFollowedCategories).HasForeignKey(q => q.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
