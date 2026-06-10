using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.DTOs.CoupanDTOs
{
    public  class CreateCoupanDTO
    {
        public string Coupan { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal FlatDiscount { get; set; }
        public decimal MinimumAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
