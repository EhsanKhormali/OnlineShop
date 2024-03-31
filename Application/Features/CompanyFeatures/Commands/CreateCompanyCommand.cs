using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CompanyFeatures.Commands
{
    public class CreateCompanyCommand : IRequest
    {
        public string? Name { get; set; }
        public DateTime? OperationStartTime { get; set; } = DateTime.MinValue;
        public DateTime? OperationEndTime { get; set; } = DateTime.MinValue;
        public bool IsValid { get; set; }
        public string? Description { get; set; } = null;
        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand>
        {
            private readonly IApplicationDbContext _context;
            public CreateCompanyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
            {
                var company = new Company();
                company.Name = command.Name;
                company.OperationStartTime = command.OperationStartTime;
                company.OperationEndTime = command.OperationEndTime;
                company.IsValid = command.IsValid;
                company.Description = command.Description;
                _context.Companies.Add(company);
                 _context.SaveChanges();
                return;
            }
        }
    }
}
