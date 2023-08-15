using BlogProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Poco
{
    public class User: AuditableEntity
    {
        public User()
        {
            Articles= new HashSet<Article>();
            Comments = new HashSet<Comment>();
            Likes =new HashSet<Like>();
            UserFollowedCategories =new HashSet<UserFollowedCategory>();
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       
        
        public virtual IEnumerable<Article> Articles { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual IEnumerable<UserFollowedCategory> UserFollowedCategories { get; set; }
        public virtual IEnumerable<Like> Likes { get; set; }
        
    }
}
