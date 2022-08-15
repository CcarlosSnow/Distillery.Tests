using FluentValidation;

namespace Distillery.Application.CardBalances.Commands.CreateCardBalance;
public class CreateCardBalanceValidator : AbstractValidator<CreateCardBalanceCommand>
{
    public CreateCardBalanceValidator()
    {
        RuleFor(x => x.MovementDate)
            .NotEmpty();

        RuleFor(x => x.Amout)
            .NotEmpty();

        RuleFor(x => x.CreditCardId)
            .NotEmpty();
    }
}
