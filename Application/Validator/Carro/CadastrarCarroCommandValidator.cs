using FluentValidation;
using LocadoraDeCarro.Application.Commands.Carro;

namespace LocadoraDeCarro.Application.Validator.Carro;

public class CadastrarCarroCommandValidator : AbstractValidator<CadastrarCarroCommand>
{
    public CadastrarCarroCommandValidator()
    {
        RuleFor(x => x.Marca).NotEmpty().WithMessage("Digite uma marca válida");
        RuleFor(x => x.Modelo).NotEmpty().WithMessage("Digite um modelo válida");
        RuleFor(x => x.Ano).InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Digite ano válido, a partir de 1900");
        RuleFor(x => x.ValorDiaria).GreaterThan(0).WithMessage("Deve ser maior que zero");
    }
}
