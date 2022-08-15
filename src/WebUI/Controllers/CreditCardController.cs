using Distillery.Application.CardBalances.Commands.CreateCardBalance;
using Distillery.Application.CreditCards.Commands.CreateCreditCard;
using Distillery.Application.CreditCards.Queries.GetCreditCardById;
using Microsoft.AspNetCore.Mvc;

namespace Distillery.WebUI.Controllers;
public class CreditCardController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCreditCardCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPost]
    [Route("{Id:int}/pay")]
    public async Task<ActionResult<int>> Consumes(int Id, [FromBody] CreateCardBalanceCommand command)
    {
        command.CreditCardId = Id;
        return await Mediator.Send(command);
    }

    [HttpGet]
    [Route("{Id:int}")]
    public async Task<ActionResult<GetCreditCardByIdDto>> Get(int Id)
    {
        return await Mediator.Send(new GetCreditCardByIdQuery(Id));
    }
}
