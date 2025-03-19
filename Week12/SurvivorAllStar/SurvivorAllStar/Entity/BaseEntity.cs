namespace SurvivorAllStar.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now.ToUniversalTime();
            ModifiedDate = DateTime.Now.ToUniversalTime();
            IsDeleted = false;
        }
    }
}
