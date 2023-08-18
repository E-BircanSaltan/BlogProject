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
    public class UserMap : BaseMap<User> 
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(q => q.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(q => q.LastName).HasMaxLength(40).IsRequired();
            builder.Property(q => q.UserName).IsRequired();
            builder.Property(q => q.Password).IsRequired();
            






        }
    }
}
