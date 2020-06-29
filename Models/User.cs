using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        
        public List<Idea> Ideas { get; set; }
        
        public List<Comment> Comments { get; set; }
    }
}