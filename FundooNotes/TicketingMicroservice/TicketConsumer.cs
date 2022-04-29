using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingMicroservice
{
    public class TicketConsumer : IConsumer<TicketModel>
    {
        public async Task Consume(ConsumeContext<TicketModel> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
