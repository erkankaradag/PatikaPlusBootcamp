using CodeFirstRelation.Entities;

namespace CodeFirstRelation.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }           // Gönderinin benzersiz kimliği
        public string Title { get; set; }    // Gönderinin başlığı
        public string Content { get; set; }    // Gönderinin içeriği
        public int UserId { get; set; }         // Gönderinin yazarı (kullanıcının kimliği).

        // Her gönderi sadece bir yazar tarafından yazılmıştır
        public UserEntity User { get; set; }
    }
}
