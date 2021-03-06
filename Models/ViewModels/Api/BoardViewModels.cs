using System.Collections.Generic;
using Models.Entities;

namespace Models.ViewModels.Api
{
    public class BoardViewModels
    {
        public List<Project> Projects { get; set; }
        
        public int Pages { get; set; }
        
        public int CurrentPage { get; set; }

        public List<Category> Categories { get; set; }
        
        public List<Category> AllCategories { get; set; }
    }
}