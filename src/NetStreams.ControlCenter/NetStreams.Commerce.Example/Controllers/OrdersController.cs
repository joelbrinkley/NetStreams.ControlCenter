using Microsoft.AspNetCore.Mvc;
using NetStreams.Commerce.Example.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetStreams.Commerce.Example.Controllers
{
    [Route("api/v1/[Controller]")]
    public class OrdersController: ControllerBase
    {
        private readonly IMessageProducer<string, OrderSubmitted> _producer;

        public OrdersController(IMessageProducer<string, OrderSubmitted> producer)
        {
            this._producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder(List<string> orderDetails)
        {
            var orderSubmitted = new OrderSubmitted
            {
                OrderId = Guid.NewGuid().ToString(),
                Order = orderDetails
            };

            await _producer.ProduceAsync(orderSubmitted.OrderId, orderSubmitted);

            return Ok();
        }
    }
}
