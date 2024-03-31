using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public DateTime OrderDate { get; set; }
        public string OrdereUser { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateOrderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var order = new Order();
                order.OrderDate = command.OrderDate;
                order.OrdereUser = command.OrdereUser;
                order.ProductId = command.ProductId;
                order.Description = command.Description;
                _context.Orders.Add(order);
                await _context.SaveChanges();
                return order.OrderId;
            }
        }
    }
}
