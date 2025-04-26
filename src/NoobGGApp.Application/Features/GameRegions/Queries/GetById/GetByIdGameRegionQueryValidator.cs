using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetById
{
    public sealed class GetByIdGameRegionQueryValidator : AbstractValidator<GetByIdGameRegionQuery>
    {
        private readonly IApplicationDbContext _context;
        public GetByIdGameRegionQueryValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.")
                .MustAsync(CheckIfGameRegionExists)
                .WithMessage("GameRegion is not found");
        }
        private Task<bool> CheckIfGameRegionExists(long id, CancellationToken cancellationToken)
        {
            return _context
                .GameRegions
                .AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
   
}
