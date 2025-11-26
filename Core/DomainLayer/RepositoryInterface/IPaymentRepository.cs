using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface
{
    public interface IPaymentRepository 
    {
        Task<Payment> AddPaymentAsync(Payment payment);
        Task<Payment> GetPaymentByIdAsync(int id);
    }
}
