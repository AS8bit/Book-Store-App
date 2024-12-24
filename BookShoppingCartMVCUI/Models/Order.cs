using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShoppingCartMVCUI.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public String UserId { get; set; }
        public DateTime CreateDate { get; set;} = DateTime.UtcNow;
        [Required]
        public int OrderStatusId { get; set; }
        public bool IsDeleted { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }

    }
}
