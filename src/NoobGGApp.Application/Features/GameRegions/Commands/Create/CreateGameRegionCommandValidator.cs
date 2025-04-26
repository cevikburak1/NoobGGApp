using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create
{
    public sealed class CreateGameRegionCommandValidator : AbstractValidator<CreateGameRegionCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateGameRegionCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(100)
                .WithMessage("Name must not exceed 100 characters.")
                .MustAsync((command, name, cancellationToken) => CheckIfGameRegionAlreadyExists(name,command.GameId, cancellationToken))
                .WithMessage("Game Region already exists");

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code is required.")
                .MaximumLength(10)
                .WithMessage("Code must not exceed 10 characters.")
                .Must(CheckIfCodeIsValid)
                .WithMessage("Code is invalid");

            RuleFor(x => x.GameId)
                .NotEmpty()
                .WithMessage("GameId is required.")
                .MustAsync(CheckIfGameExists)
                .WithMessage("Game is not found");

        }

        private async Task<bool> CheckIfGameRegionAlreadyExists(string name,long gameId, CancellationToken cancellationToken)
        {
            return !await _context
                .GameRegions
                .AnyAsync(x => x.Name.ToLower() == name.ToLower() && x.GameId == gameId, cancellationToken);
        }
        private Task<bool> CheckIfGameExists(long gameId, CancellationToken cancellationToken)
        {
            return _context
                .Games
                .AnyAsync(x => x.Id == gameId, cancellationToken);
        }
        private bool CheckIfCodeIsValid(string code)
        {
            if (code.Length==10 && code.Contains("-"))
            return true;
            else
                return false;
        }
    }
    
}
