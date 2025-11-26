using Shared.Dto_s.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> ProcessPaymentAsync(CreatePaymentDto dto);
        Task<PaymentResponseDto> GetPaymentAsync(int id);
    }
}
