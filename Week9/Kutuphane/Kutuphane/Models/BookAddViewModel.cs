using System.ComponentModel.DataAnnotations;
namespace Kutuphane.Models
{
    public class BookAddViewModel
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public string Genre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int CopiesAvailable { get; set; }
    }
}

