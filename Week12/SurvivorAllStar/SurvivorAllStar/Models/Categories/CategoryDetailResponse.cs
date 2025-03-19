using SurvivorAllStar.Models.Competitors;

namespace SurvivorAllStar.Models.Categories
{
    public class CategoryDetailResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public List<CompetitorListResponse> Competitors { get; set; }
    }
}
