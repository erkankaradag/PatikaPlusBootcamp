using SurvivorAllStar.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurvivorAllStar.Models.Categories
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
    }
}
