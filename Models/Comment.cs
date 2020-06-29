using System;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Interfaces;

namespace Models
{
    public class Comment : IEntityTimeStamped
    {
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(256)")]
        public string Text { get; set; }
        
        public User User { get; set; }
        
        public Idea Idea { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; }
    }
}