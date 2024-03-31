using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands
{
    public class DeleteOrderByIdCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteOrderByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
            {
                var order = await _context.Orders.Where(a => a.OrderId == command.OrderId).FirstOrDefaultAsync();
                if (order == null) return default;
                _context.Orders.Remove(order);
                await _context.SaveChanges();
                return order.OrderId;
            }
        }
    }
}
