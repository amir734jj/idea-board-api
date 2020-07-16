using System.Collections.Generic;
using Models.Interfaces;
using Models.Relationships;

namespace Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<IdeaCategoryRelationship> IdeaCategoryRelationships { get; set; }
    }
}