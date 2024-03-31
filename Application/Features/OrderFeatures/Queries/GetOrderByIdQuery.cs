using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int OrderId { get; set; }
        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
        {
            private readonly IApplicationDbContext _context;
            public GetOrderByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Order> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
            {
                var order = _context.Orders.Where(a => a.OrderId == query.OrderId).FirstOrDefault();
                return order;
            }
        }
    }
}
