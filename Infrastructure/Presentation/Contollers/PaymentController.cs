using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.Dto_s.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment([FromBody] CreatePaymentDto dto)
        {
            var result = await _paymentService.ProcessPaymentAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var result = await _paymentService.GetPaymentAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
