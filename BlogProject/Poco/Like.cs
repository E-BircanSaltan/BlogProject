using BlogProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Poco
{
    public class Like :AuditableEntity
    {
        
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }    
        public int UserId { get; set; }
        public virtual User User { get; set; }
          


    }
}
