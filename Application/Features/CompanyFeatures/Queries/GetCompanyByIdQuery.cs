using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CompanyFeatures.Queries
{
    public class GetCompanyByIdQuery : IRequest<Company>
    {
        public int CompanyId { get; set; }
        public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Company>
        {
            private readonly IApplicationDbContext _context;
            public GetCompanyByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Company> Handle(GetCompanyByIdQuery query, CancellationToken cancellationToken)
            {
                var company = _context.Companies.Where(a => a.CompanyId == query.CompanyId).FirstOrDefault();
                if (company == null) return null;
                return company;
            }
        }
    }
}
