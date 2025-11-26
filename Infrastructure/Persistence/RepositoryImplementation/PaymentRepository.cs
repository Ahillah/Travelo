using DomainLayer.Models;
using DomainLayer.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementation
{
    public class PaymentRepository(TraveloIdentityDbContext context) : IPaymentRepository
    {
        private readonly TraveloIdentityDbContext _context = context;

        public async Task<Payment> AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }
    }
}
