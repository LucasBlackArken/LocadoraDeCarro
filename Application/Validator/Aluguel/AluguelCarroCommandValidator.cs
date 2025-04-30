using FluentValidation;
using LocadoraDeCarro.Application.Commands.Aluguel;

namespace LocadoraDeCarro.Application.Validator.Aluguel;

public class AluguelCarroCommandValidator : AbstractValidator<AluguelCarroCommand>
{
    public AluguelCarroCommandValidator()
    {
        RuleFor(x => x.CarroId).GreaterThan(0);
        RuleFor(x => x.DataInicio).LessThan(x => x.DataFim).WithMessage("A data de início deve ser anterior à data de fim.");
        RuleFor(x => x.DataFim).GreaterThan(x => x.DataInicio).WithMessage("A data de fim deve ser posterior à data de início.");
    }
}
                                                                