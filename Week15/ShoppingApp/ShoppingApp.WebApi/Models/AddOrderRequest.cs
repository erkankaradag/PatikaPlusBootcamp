using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ShoppingApp.WebApi.Models
{
    public class AddOrderRequest
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int Quentity { get; set; }
        [Required]
        public List<int> ProductIds { get; set; }
    }
}