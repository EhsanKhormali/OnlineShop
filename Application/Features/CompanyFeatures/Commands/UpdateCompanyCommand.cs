using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CompanyFeatures.Commands
{
    public class UpdateCompanyCommand : IRequest
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public DateTime? OperationStartTime { get; set; } = DateTime.MinValue;
        public DateTime? OperationEndTime { get; set; } = DateTime.MinValue;
        public bool IsValid { get; set; }
        public string? Description { get; set; } = null;
        public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCompanyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task Handle(UpdateCompanyCommand command, CancellationToken cancellationToken)
            {
                var company = _context.Companies.Where(a => a.CompanyId == command.CompanyId).FirstOrDefault();

                if (company == null)
                {
                    return;
                }
                else
                {
                    company.Name = command.Name;
                    company.OperationStartTime = command.OperationStartTime;
                    company.OperationEndTime = command.OperationEndTime;
                    company.Description = command.Description;
                    company.IsValid = command.IsValid;
                    await _context.SaveChanges();
                    return;
                }
            }
        }
    }
}
