﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.DTO.Article
{
    public class ArticleDTOBase
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string Image { get; set; }
        public Guid CategoryGuid { get; set; }
        public Guid UserGuid{ get; set; }
    }
}
