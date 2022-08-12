using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperStore.Domain.Payment.CreateOrder;
using System.Threading.Tasks;

namespace SuperStore.Api.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand request)
        {
            var response = await _mediator.Send(request);

            if (!response.IsValid)
            {
                return BadRequest(response.Notifications);
            }

            return Ok(response.OrderId);
        }
    }
}
