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
    public class AboutMap : BaseMap<About>
    {
        public override void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("About"); //Tablo isimlendirme
            builder.Property(q=>q.Details).IsRequired();
            builder.Property(q=>q.Description).IsRequired();
            builder.Property(q=>q.Image).IsRequired();
            
        }
    }
}
