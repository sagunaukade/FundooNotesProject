using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingMicroservice.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IBusControl _bus;
        public TicketController(IBusControl bus)
        {
            _bus = bus;
        }
        [HttpPost("Ticket")]
        public async Task<IActionResult> CreateTicket(TicketModel ticket)
        {
            if (ticket != null)
            {
                ticket.BookedOn = DateTime.Now;
                //ticketqueue sending data
                Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(ticket);
                return Ok("Success");
            }
            return BadRequest();
        }
    }
}
