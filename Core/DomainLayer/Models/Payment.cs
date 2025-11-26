using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Payment
    {
        public int Id { get; set; }
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

        public string Status { get; set; } // Success - Failed - Pending

        public DateTime CreatedAt { get; set; }
    }
}
