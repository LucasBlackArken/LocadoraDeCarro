using FluentValidation;
using LocadoraDeCarro.Application.Commands.Aluguel;

namespace LocadoraDeCarro.Application.Validator.Aluguel
{
    public class DevolverCarroCommandValidator : AbstractValidator<DevolverCarroCommand>
    {
        public DevolverCarroCommandValidator()
        {
            RuleFor(x => x.AluguelId).GreaterThan(0);
        }
    }
}
