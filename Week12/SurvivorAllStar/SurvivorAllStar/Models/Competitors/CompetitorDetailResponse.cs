namespace SurvivorAllStar.Models.Competitors
{
    public class CompetitorDetailResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoyId { get; set; }
    }
}
