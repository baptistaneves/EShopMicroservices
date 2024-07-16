using Discount.Grpc;

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

public class StoreBasketCommandHandler
    (IBasketRepository repository, 
    DiscountProtoService.DiscountProtoServiceClient discountProto)
    : ICommandHandler<StoreBaketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBaketCommand command, CancellationToken cancellationToken)
    {
        await DeductDiscount(command.Cart);

        var result = await repository.StoreBasket(command.Cart);

        return new StoreBasketResult(result.UserName);
    }

    private async Task DeductDiscount(ShoppingCart cart)
    {
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
            item.Price -= coupon.Amount;
        }
    }
}