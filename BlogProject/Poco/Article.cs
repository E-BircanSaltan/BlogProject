using BlogProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Poco
{
    public class Article : AuditableEntity
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
            Likes=new HashSet<Like>();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        

        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual IEnumerable<Like> Likes { get; set; }


    }
}
