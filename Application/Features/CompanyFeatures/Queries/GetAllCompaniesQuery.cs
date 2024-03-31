using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CompanyFeatures.Queries
{
    public class GetAllCompaniesQuery : IRequest<IEnumerable<Company>>
    {

        public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<Company>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCompaniesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery query, CancellationToken cancellationToken)
            {
                var companyList = await _context.Companies.ToListAsync();
                return companyList.AsReadOnly();
            }
        }
    }
}
