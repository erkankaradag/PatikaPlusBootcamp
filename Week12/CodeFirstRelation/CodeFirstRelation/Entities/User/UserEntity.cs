using CodeFirstRelation.Entities;
namespace CodeFirstRelation.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }          // Kullanıcının benzersiz kimliği
        public string UserName { get; set; } // Kullanıcının Kullanıcı adı
        public string Email { get; set; }  // Kullanıcının Email adresi

        // Bir kullanıcın birden fazla kitabı olabilir
        public List<PostEntity> Posts { get; set; }
    }
}
