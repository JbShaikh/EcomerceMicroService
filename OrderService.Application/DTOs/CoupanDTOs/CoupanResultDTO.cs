using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.DTOs.CoupanDTOs
{
    public class CoupanResultDTO
    {
        public decimal OrignalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string CoupanCode { get; set; }
    }
}
