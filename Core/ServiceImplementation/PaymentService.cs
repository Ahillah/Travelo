using AutoMapper;
using DomainLayer.Models;
using DomainLayer.RepositoryInterface;
using ServiceAbstraction;
using Shared.Dto_s.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation
{
    public class PaymentService(IPaymentRepository paymentRepository, IMapper mapper) : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaymentResponseDto> ProcessPaymentAsync(CreatePaymentDto dto)
        {
            string status = "Success";

            var payment = _mapper.Map<Payment>(dto);
            payment.CreatedAt = DateTime.Now;
            payment.Status = status;

            await _paymentRepository.AddPaymentAsync(payment);

            return _mapper.Map<PaymentResponseDto>(payment);
        }
        public async Task<PaymentResponseDto> GetPaymentAsync(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null)
                return null;

            return _mapper.Map<PaymentResponseDto>(payment);
        }

    
    }
}
