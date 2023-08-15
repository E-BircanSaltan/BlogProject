using BlogProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Poco
{
    public class UserFollowedCategory : AuditableEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }  
        
    }
}
