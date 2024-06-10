namespace Basket.API.Data;

public class BasketRepository(IDocumentSession session)
    : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellation = default)
    {
        var basket = await session.LoadAsync<ShoppingCart>(userName, cancellation);

        return basket is null ? throw new BasketNotFoundException(userName) : basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellation = default)
    {
        session.Store(basket);
        await session.SaveChangesAsync();
        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        session.Delete<ShoppingCart>(userName);
        await session.SaveChangesAsync(cancellationToken);

        return true;
    }
}
