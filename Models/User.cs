using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        public object Obfuscate()
        {
            const string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";

            var obfuscatedEmail = Regex.Replace(Email, pattern, m => new string('*', m.Length));
            
            return new {Email = obfuscatedEmail, Name};
        }

        public object ToAnonymousObject()
        {
            return new {Email, Name};
        }
    }
}