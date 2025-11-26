using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Payment
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
