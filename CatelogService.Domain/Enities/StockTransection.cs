using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Domain.Entities
{
    public class StockTransection
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string TransectionType { get; set; }
        public DateTime CreateDate { get; set; }
        //Navigation property
        public Product Product { get; set; }
    }
}
