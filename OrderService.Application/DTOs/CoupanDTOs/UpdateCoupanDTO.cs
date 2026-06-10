using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.DTOs.CoupanDTOs
{
    public class UpdateCoupanDTO
    {
        public bool IsActive { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
