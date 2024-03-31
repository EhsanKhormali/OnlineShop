using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CompanyFeatures.Commands
{
    public class DeleteCompanyByIdCommand : IRequest<int>
    {
        public int CompanyId { get; set; }
        public class DeleteCompanytByIdCommandHandler : IRequestHandler<DeleteCompanyByIdCommand,int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCompanytByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCompanyByIdCommand command, CancellationToken cancellationToken)
            {
                var company = await _context.Companies.Where(a => a.CompanyId == command.CompanyId).FirstOrDefaultAsync();
                if (company == null) return default;
                _context.Companies.Remove(company);
                await _context.SaveChanges();
                return company.CompanyId;
            }
        }
    }
}
