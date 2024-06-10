namespace Basket.API.Basket.StoreBasket;

public record StoreBaketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

internal class StoreBasketCommandValidation : AbstractValidator<StoreBaketCommand>
{
    public StoreBasketCommandValidation()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class StoreBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<StoreBaketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBaketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;

        var result = await repository.StoreBasket(cart);

        return new StoreBasketResult(result.UserName);
    }
}