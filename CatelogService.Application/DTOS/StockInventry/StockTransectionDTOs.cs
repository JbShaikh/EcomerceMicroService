using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Application.DTOs.StockInventry
{
    public class StockTransectionDTOs
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string TransectionType { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
