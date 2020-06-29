using System;
using System.Collections.Generic;
using EfCoreRepository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Interfaces;

namespace Models
{
    public class User : IdentityUser<int>, IEntity
    {
        public string Name { get; set; }
        
        public List<Idea> Ideas { get; set; }
        
        public List<Comment> Comments { get; set; }
        
        public DateTimeOffset LastLoginTime { get; set; }
    }
}