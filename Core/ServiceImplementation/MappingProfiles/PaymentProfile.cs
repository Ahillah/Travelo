using AutoMapper;
using DomainLayer.Models;
using Shared.Dto_s.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<Payment, PaymentResponseDto>();
        }
    }
}
