using BlogProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Poco
{
    public class About : AuditableEntity
    {
        
        public string Description { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        
       
    }
}
