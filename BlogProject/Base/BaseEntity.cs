﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Base
{
    public class BaseEntity
    {
        public int id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

    }
}
