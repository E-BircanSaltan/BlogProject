﻿using BlogProject.Entity.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.EntityFramework.Mapping.BaseMap
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(q => q.id);
            builder.Property(q => q.id).ValueGeneratedOnAdd();
            builder.Property(q => q.Guid).ValueGeneratedOnAdd();
        }
    }
}
