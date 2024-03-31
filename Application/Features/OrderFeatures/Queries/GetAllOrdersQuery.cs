using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Orders.ToListAsync();
                return productList.AsReadOnly();
            }
        }
    }
}
