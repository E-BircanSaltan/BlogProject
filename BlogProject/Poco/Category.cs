using BlogProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogProject.Entity.Poco
{
    public class Category : AuditableEntity
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            UserFollowedCategories = new HashSet<UserFollowedCategory>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        

        public virtual IEnumerable<Article> Articles { get; set; }
        public virtual IEnumerable<UserFollowedCategory> UserFollowedCategories { get; set; }
        
    }
}
