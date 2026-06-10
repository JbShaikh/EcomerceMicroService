using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Application.DTOs.StockInventry
{
    public class IncreaseStockDTOs
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
