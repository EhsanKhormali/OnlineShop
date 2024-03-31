using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrdereUser { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateOrderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
            {
                var order = _context.Orders.Where(a => a.OrderId == command.OrderId).FirstOrDefault();

                if (order == null)
                {
                    return default;
                }
                else
                {
                    order.OrderDate = command.OrderDate;
                    order.OrdereUser = command.OrdereUser;
                    order.Description = command.Description;
                    order.ProductId = command.ProductId;
                    await _context.SaveChanges();
                    return order.OrderId;
                }
            }
        }
    }
}
