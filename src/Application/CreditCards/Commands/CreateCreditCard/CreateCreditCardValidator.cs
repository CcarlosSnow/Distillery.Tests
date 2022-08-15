using FluentValidation;

namespace Distillery.Application.CreditCards.Commands.CreateCreditCard;
public class CreateCreditCardValidator : AbstractValidator<CreateCreditCardCommand>
{
    public CreateCreditCardValidator()
    {
        RuleFor(x => x.CardNumber)
            .NotEmpty()
            .Length(15);

        RuleFor(x => x.TotalCredit)
            .NotEmpty();
    }
}
