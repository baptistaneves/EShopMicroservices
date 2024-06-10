namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);

internal class DeleteBasketCommandValidation : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidation()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
public class DeleteBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand query, CancellationToken cancellationToken)
    {
        var result =  await repository.DeleteBasket(query.UserName);

        return new DeleteBasketResult(result);
    }
}
