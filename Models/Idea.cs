using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Enums;
using Models.Interfaces;
using Models.Relationships;

namespace Models
{
    public class Idea : IEntityTimeStamped, IEntityUserProp
    {
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(256)")]
        public string Title { get; set; }
        
        [Column(TypeName="text")]
        public string Description { get; set; }
        
        public List<UserVote> Votes { get; set; }
        
        public List<IdeaCategoryRelationship> IdeaCategoryRelationships { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; }
        
        public List<Comment> Comments { get; set; }
        public User User { get; set; }
        
        public Tag Tag { get; set; }
    }
}