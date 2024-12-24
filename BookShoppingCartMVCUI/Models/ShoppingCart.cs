using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShoppingCartMVCUI.Models
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public String UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<CartDetail> cartDetails { get; set; }
    }
}
