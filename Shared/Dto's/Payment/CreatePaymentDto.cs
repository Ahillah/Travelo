using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Payment
{
    public class CreatePaymentDto
    {
        public string PaymentMethod { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string CVC { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public decimal Amount { get; set; }

    }
}
