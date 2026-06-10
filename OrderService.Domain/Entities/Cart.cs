using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        //Navigation Property
        public Customer Customer { get; set; }
        public List<CartItem> CartItems { get; set; } = new();
    }
}
