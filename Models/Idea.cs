using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Interfaces;

namespace Models
{
    public class Idea : IEntityTimeStamped
    {
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(256)")]
        public string Title { get; set; }
        
        [Column(TypeName="text")]
        public string Description { get; set; }
        
        public int Votes { get; set; }
        
        public List<IdeaCategoryRelationship> IdeaCategoryRelationships { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; }
        
        public List<Comment> Comments { get; set; }
        public User User { get; set; }
    }
}