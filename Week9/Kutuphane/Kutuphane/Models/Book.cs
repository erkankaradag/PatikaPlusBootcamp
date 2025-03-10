using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string AuthorName { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        [Range(0, int.MaxValue)]
        public int CopiesAvailable { get; set; }

    }
}
